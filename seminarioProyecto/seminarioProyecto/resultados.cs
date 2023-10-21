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
    public partial class resultados : Form
    {
        DataTable resultadosConvocatoria = new DataTable();
        bool convoVacias;
        //int idConvo;
        public resultados()
        {
            InitializeComponent();
            cargarPuestos(cbPuesto);
        }

        public void cargarPuestos(ComboBox cb)
        {
            DataTable dtz = new DataTable();
            dtz.Clear();
            dtz = capaNegocias.resultados.obtenerPuestos();
            cb.DisplayMember = "TITULO";
            cb.ValueMember = "ID_PUESTO";
            cb.DataSource = dtz;
        }

        public void cargarConvocatorias(ComboBox cb)
        {
            DataTable dtz = new DataTable();
            dtz.Clear();
            dtz = capaNegocias.resultados.obtenerConvocatorias(Convert.ToInt32(cbPuesto.SelectedValue));
            cb.DisplayMember = "CONVOCATORIA";
            cb.ValueMember = "ID_CONVOCATORIA";
            cb.DataSource = dtz;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is menuAdmin formularioPadre)
            {
                formularioPadre.panelAlFondo();
            }

            this.Close();
        }

        private void convertirNulosCero()
        {
            foreach (DataRow row in resultadosConvocatoria.Rows)
            {
                if (row.IsNull(1)) // El índice 1 corresponde a la segunda columna (cero basado)
                {
                    row[1] = 0; // Reemplazar el valor nulo por cero
                }
            }
        }

        private void cbPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarConvocatorias(cbConvocatoria);

            if (cbConvocatoria.Items.Count == 0)
            {
                //cbConvocatoria.Enabled = false;
                //cbConvocatoria.DataSource = null;
                //cbConvocatoria.Items.Add("No existen convocatorias");
                //cbConvocatoria.SelectedIndex = 0;
                //convoVacias = true;
                btnVer.Visible = false;
            }
            else
            {
                //cbConvocatoria.Enabled = true;
                //convoVacias = false;
                btnVer.Visible = true;
            }
        }

        private void cbConvocatoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void llenarGrafico()
        {
            //resultadosConvocatoria.Clear();
            //resultadosConvocatoria = capaNegocias.resultados.obtenerResultados((int)cbConvocatoria.SelectedValue);

            //if (resultadosConvocatoria.Rows.Count == 0)
            //{
            //    MessageBox.Show("No hay resultados de entrevistas para esa convocatoria", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //dgvResultados.Rows.Clear();
            //    //dgvResultados.Columns.Clear();                
            //    return;
            //}
            //string a = "s";
            //chart1.Series.Clear();

            //string aa = "s";
            //convertirNulosCero();
            //dgvResultados.DataSource = resultadosConvocatoria;
            //dgvResultados.ClearSelection();

            //chart1.Titles.Clear();
            ////chart1.DataSource = resultadosConvocatoria;
            ////chart1.Series["Postulantes"].XValueMember = "POSTULANTE";
            ////chart1.Series["Postulantes"].YValueMembers = "RESULTADO";
            ////chart1.Titles.Add("Resultados de convocatoria");

            //chart1.Palette = ChartColorPalette.Pastel;
            ////chart1.Titles.Add("Resultados postulantes");
            ////chart1.Series.Clear();

            ////for (int i = 0; i < resultadosConvocatoria.Rows.Count; i++)
            ////{
            ////    Series serie = chart1.Series.Add(resultadosConvocatoria.Rows[i][0].ToString());
            ////    serie.Label = resultadosConvocatoria.Rows[i][1].ToString()+"%";

            ////    serie.Points.Add(Convert.ToDouble(resultadosConvocatoria.Rows[i][1]));
            ////    //serie.ChartType = SeriesChartType.Bar;
            ////}

            //for (int i = 0; i < dgvResultados.Rows.Count; i++)
            //{
            //    Series serie = chart1.Series.Add(dgvResultados.Rows[i].Cells[0].Value.ToString());
            //    serie.Label = dgvResultados.Rows[i].Cells[1].Value.ToString() + "%";

            //    serie.Points.Add(Convert.ToDouble(dgvResultados.Rows[i].Cells[1].Value));
            //    //serie.ChartType = SeriesChartType.Bar;
            //}

            ////chart1.ChartAreas[0].AxisX.IsLabelAutoFit = false;            

            ////chart1.ChartAreas[0].Visible = false;
            ////chart1.ChartAreas[0].AxisX.CustomLabels.Clear();

            ////Desactivar lines del fondo
            //// Puede variar según el número de área de trazado que estés utilizando
            //ChartArea chartArea = chart1.ChartAreas[0]; 
            //// Desactivar las líneas de la cuadrícula vertical y horizontal
            //chartArea.AxisX.MajorGrid.Enabled = false;
            //chartArea.AxisY.MajorGrid.Enabled = false;
        }

        public void llenarGraficoo()
        {
            //idConvo = (int)cbConvocatoria.SelectedValue;
            //resultadosConvocatoria.Clear();
            resultadosConvocatoria = capaNegocias.resultados.obtenerResultados((int)cbConvocatoria.SelectedValue);

            string a = "s";
            if (resultadosConvocatoria.Rows.Count == 0)
            {
                MessageBox.Show("No hay resultados de entrevistas para esa convocatoria", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvResultados.Visible = false;
                btnInforme.Visible = false;
            }
            else
            {
                dgvResultados.Visible = true;
                btnInforme.Visible = true;
            }
            //chart2.Series.Clear();

            string aa = "s";
            convertirNulosCero();
            dgvResultados.DataSource = resultadosConvocatoria;
            dgvResultados.ClearSelection();

            chart2.Titles.Clear();
            chart2.DataSource = resultadosConvocatoria;
            chart2.Series["Series2"].XValueMember = "POSTULANTE";
            chart2.Series["Series2"].YValueMembers = "RESULTADO";
            chart2.Series["Series2"].IsValueShownAsLabel = true;

            //Desactivar lines del fondo
            // Puede variar según el número de área de trazado que estés utilizando
            ChartArea chartArea2 = chart2.ChartAreas[0];
            // Desactivar las líneas de la cuadrícula vertical y horizontal
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
        }

        private void chart1_Customize(object sender, EventArgs e)
        {
            //// Borra todas las etiquetas actuales del eje X
            //chart1.ChartAreas[0].AxisX.CustomLabels.Clear();
            //chart1.ChartAreas[0].AxisY.CustomLabels.Clear();

            // Agrega etiquetas numeradas de 1 a 100
            //for (int i = 5; i <= 100; i += 5)
            //{
            //    chart1.ChartAreas[0].AxisY.CustomLabels.Add(i - 2.5, i + 2.5, i.ToString());
            //}

            // Agregar etiqueta final para llegar a 100
            //chart1.ChartAreas[0].AxisY.CustomLabels.Add(97.5, 102.5, "100");


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            llenarGraficoo();
        }

        private void resultados_Load(object sender, EventArgs e)
        {
            
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            DataTable dtDatos;
            dtDatos = capaNegocias.metodosComunes.consultaAbiertaSinParametros("SELECT C.ID_CONVOCATORIA, C.FECHA_INICIO, FECHA_FIN, P.TITULO FROM CONVOCATORIAS AS C INNER JOIN puestos AS P ON P.ID_PUESTO = C.ID_PUESTO WHERE ID_CONVOCATORIA = " + cbConvocatoria.SelectedValue);
            informe.datos encabezado = new informe.datos();
            encabezado.ID_CONVOCATORIA = dtDatos.Rows[0][0].ToString();
            encabezado.INICIO = dtDatos.Rows[0][1].ToString();
            encabezado.FIN = dtDatos.Rows[0][2].ToString();
            encabezado.TITULO = dtDatos.Rows[0][3].ToString();

            informe.informeFormulario informe = new informe.informeFormulario(resultadosConvocatoria);
            informe.de.Add(encabezado);
            informe.Show();

            resultadosConvocatoria.Clear();
            resultadosConvocatoria.Columns.Clear();
            string a = "s";
        }
    }
}
