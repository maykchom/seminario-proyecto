using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seminarioProyecto
{
    public partial class confPreguntas : Form
    {
        int idPregunta;
        public confPreguntas()
        {
            InitializeComponent();
            cargarPuestos(cbPuestos);
        }

        public void cargarPuestos(ComboBox cb)
        {
            DataTable dtz = new DataTable();
            dtz.Clear();
            dtz = capaNegocias.postulaciones.obtenerPuestos();
            cb.DisplayMember = "TITULO";
            cb.ValueMember = "ID_PUESTO";
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

        public void cargarPreguntas()
        {
            DataTable dtPreguntas;
            dtPreguntas = capaNegocias.preguntas.obtenerPreguntas(Convert.ToInt32(cbPuestos.SelectedValue));
            dgvPreg.DataSource = dtPreguntas;
            //dgvPreg.Columns[0].Visible = false;
        }

        public void cargarRespuestas()
        {
            DataTable dtRespuestas;
            dtRespuestas = capaNegocias.preguntas.obtenerRespuestas(idPregunta);
            dgvRes.DataSource = dtRespuestas;
            //dgvPreg.Columns[0].Visible = false;
        }

        private void dgvPreg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowNo;
            RowNo = e.RowIndex;

            idPregunta = Convert.ToInt32(dgvPreg.Rows[RowNo].Cells[1].Value);
            cargarRespuestas();
            //idEstado = Convert.ToInt32(dgvPost.Rows[RowNo].Cells[8].Value);
            //fechaInicio = Convert.ToDateTime(dgvPost.Rows[RowNo].Cells[4].Value);
            //fechaFin = Convert.ToDateTime(dgvPost.Rows[RowNo].Cells[5].Value);
            //idPostulacionEntre = Convert.ToInt32(dgvPost.Rows[RowNo].Cells[6].Value);
            //capaNegocias.entrevistaEjecucion.idPuestoEntrevista = Convert.ToInt32(cbPuestos.SelectedValue);
            //capaNegocias.entrevistaEjecucion.idPostulacionEntrevista = idPostulacionEntre;
            //btnRealizarEntrevista.Enabled = true;
        }

        private void cbPuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarPreguntas();
        }

        private void dgvRes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
