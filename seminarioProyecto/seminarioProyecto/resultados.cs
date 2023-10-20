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

        private void cbPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarConvocatorias(cbConvocatoria);
        }

        private void cbConvocatoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            resultadosConvocatoria = capaNegocias.resultados.obtenerResultados((int)cbConvocatoria.SelectedValue);

        }

        public void llenarGrafico()
        {
            //chart1.Titles.Clear();
            //chart1.DataSource = resultadosConvocatoria;
            //chart1.Series["Postulantes"].XValueMember = "POSTULANTE";
            //chart1.Series["Postulantes"].YValueMembers = "RESULTADO";
            //chart1.Titles.Add("Resultados de convocatoria");

            chart1.Palette = ChartColorPalette.Pastel;
            chart1.Titles.Add("Resultados postulantes");
            chart1.Series.Clear();

            for (int i = 0; i < resultadosConvocatoria.Rows.Count; i++)
            {
                Series serie = chart1.Series.Add(resultadosConvocatoria.Rows[i][0].ToString());
                serie.Label = resultadosConvocatoria.Rows[i][1].ToString()+"%";

                serie.Points.Add(Convert.ToDouble(resultadosConvocatoria.Rows[i][1]));
            }
            //chart1.ChartAreas[0].AxisX.IsLabelAutoFit = false;            

            //chart1.ChartAreas[0].Visible = false;
            //chart1.ChartAreas[0].AxisX.CustomLabels.Clear();
        }

        private void chart1_Customize(object sender, EventArgs e)
        {
            //// Borra todas las etiquetas actuales del eje X
            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();

            // Agrega etiquetas numeradas de 1 a 100
            for (int i = 5; i <= 100; i += 5)
            {
                chart1.ChartAreas[0].AxisY.CustomLabels.Add(i - 2.5, i + 2.5, i.ToString());
            }

            // Agregar etiqueta final para llegar a 100
            chart1.ChartAreas[0].AxisY.CustomLabels.Add(97.5, 102.5, "100");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            llenarGrafico();
        }
    }
}
