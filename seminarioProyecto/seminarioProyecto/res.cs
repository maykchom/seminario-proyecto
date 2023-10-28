using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace seminarioProyecto
{
    public partial class res : Form
    {
        DataTable dtResObt = new DataTable();
        public res()
        {
            InitializeComponent();
        }

        public void cargarPuestos()
        {
            DataTable dtz = new DataTable();
            dtz.Clear();
            dtz = capaNegocias.resultados.obtenerPuestos();
            cbPu.DisplayMember = "TITULO";
            cbPu.ValueMember = "ID_PUESTO";
            cbPu.DataSource = dtz;
        }

        public void cargarConvocatorias()
        {
            DataTable dtz = new DataTable();
            dtz.Clear();
            dtz = capaNegocias.resultados.obtenerConvocatorias(Convert.ToInt32(cbPu.SelectedValue));
            cbCon.DisplayMember = "CONVOCATORIA";
            cbCon.ValueMember = "ID_CONVOCATORIA";
            cbCon.DataSource = dtz;
        }

        private void res_Load(object sender, EventArgs e)
        {
            if (!capaNegocias.metodosComunes.verificarConexion())
            {
                MessageBox.Show("Se perdió la conexión con el servidor", "Sin conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cargarPuestos();
            dgvRes.ClearSelection(); //AGREGADO
        }

        private void cbPu_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            panel2.Visible = true;
            cargarConvocatorias();
            if (cbCon.Items.Count == 0)
            {
                button1.Enabled = false;
                panel2.Visible = true;
            }
            else
            {
                //button1.Enabled = true;
                //panel2.Visible = false;
            }
        }

        private void cbCon_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrafico();
            dgvRes.ClearSelection(); //AGREGADO
        }

        private void quitarNulos()
        {
            foreach (DataRow row in dtResObt.Rows)
            {
                if (row.IsNull(1)) // El índice 1 corresponde a la segunda columna (cero basado)
                {
                    row[1] = 0; // Reemplazar el valor nulo por cero
                }
            }
        }

        public void cargarGrafico()
        {
            //MessageBox.Show("Se intentó cargar gráfico");
            dtResObt = capaNegocias.resultados.obtenerResultados((int)cbCon.SelectedValue);
            quitarNulos();


            if (dtResObt.Rows.Count == 0)
            {
                dgvRes.ClearSelection(); 
                //AGREGADO
                //panel2.Visible = true;
                //button1.Enabled = false;
                panel2.Visible = true;
                button1.Enabled = false;
                MessageBox.Show("No hay resultados de entrevistas para esa convocatoria", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //MessageBox.Show("Se continuó con el gráfico");

            panel2.Visible = false;
            button1.Enabled = true;

            dgvRes.DataSource = dtResObt;

            //dgvResultados.ClearSelection();

            chart1.Titles.Clear();
            chart1.DataSource = dtResObt;
            chart1.Series["Series1"].XValueMember = "POSTULANTE";
            chart1.Series["Series1"].YValueMembers = "RESULTADO";
            chart1.Series["Series1"].IsValueShownAsLabel = true;

            //Desactivar lines del fondo
            // Puede variar según el número de área de trazado que estés utilizando
            ChartArea chartArea1 = chart1.ChartAreas[0];
            // Desactivar las líneas de la cuadrícula vertical y horizontal
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!capaNegocias.metodosComunes.verificarConexion())
            {
                MessageBox.Show("Se perdió la conexión con el servidor", "Sin conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbPu.Items.Count == 0)
            {
                MessageBox.Show("No hay datos", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataTable dtDatos;
            dtDatos = capaNegocias.metodosComunes.consultaAbiertaSinParametros("SELECT C.ID_CONVOCATORIA, C.FECHA_INICIO, FECHA_FIN, P.TITULO FROM CONVOCATORIAS AS C INNER JOIN puestos AS P ON P.ID_PUESTO = C.ID_PUESTO WHERE ID_CONVOCATORIA = " + cbCon.SelectedValue);
            informe.datos encabezado = new informe.datos();
            encabezado.ID_CONVOCATORIA = dtDatos.Rows[0][0].ToString();
            encabezado.INICIO = dtDatos.Rows[0][1].ToString();
            encabezado.FIN = dtDatos.Rows[0][2].ToString();
            encabezado.TITULO = dtDatos.Rows[0][3].ToString();

            informe.informeFormulario informe = new informe.informeFormulario(dtResObt);
            informe.de.Add(encabezado);
            informe.Show();

            //dtResObt.Clear();
            //dtResObt.Columns.Clear();
            string a = "s";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is menuAdmin formularioPadre)
            {
                formularioPadre.panelAlFondo();
            }

            this.Close();
        }
    }
}
