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
        private Form formularioHijoActual;
        int idPregunta;

        public confPreguntas()
        {
            InitializeComponent();
            cargarPuestos(cbPuestos);
        }

        private void abrirFormularioHijo(Form formularioHijo)
        {
            if (formularioHijoActual != null)
            {
                //Abrir solo un formulario
                formularioHijoActual.Close();
            }
            formularioHijoActual = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            panel1.Controls.Add(formularioHijo);
            panel1.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
            //lbTituloFormularioHijo.Text = formularioHijo.Text;
            //lbTituloFormularioHijo.Text = botonActual.Text;
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

        public void panelAlFondo()
        {
            panel1.SendToBack();
            //MessageBox.Show("hola");

        }

        public void cargarPreguntas()
        {
            DataTable dtPreguntas;
            dtPreguntas = capaNegocias.preguntas.obtenerPreguntas(Convert.ToInt32(cbPuestos.SelectedValue));
            dgvPreg.DataSource = dtPreguntas;
            dgvPreg.Columns[0].Visible = false;
            dgvPreg.Columns[1].Visible = false;
            dgvPreg.ClearSelection();
            limpiarControles();
        }

        //public void cargarRespuestas()
        //{
        //    DataTable dtRespuestas;
        //    dtRespuestas = capaNegocias.preguntas.obtenerRespuestas(idPregunta);
        //    dgvRes.DataSource = dtRespuestas;
        //    //dgvPreg.Columns[0].Visible = false;
        //    dgvRes.ClearSelection();
        //}

        private void dgvPreg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowNo;
            RowNo = e.RowIndex;

            idPregunta = Convert.ToInt32(dgvPreg.Rows[RowNo].Cells[1].Value);
            tbPregunta.Text = dgvPreg.Rows[RowNo].Cells[2].Value.ToString();
            btnGuardarPregunta.Visible = false;
            btnEditarPregunta.Visible = true;
            btnEliminarPregunta.Visible = true;
            btnNuevo.Visible = true;
            btnRepuestas.Visible = true;
        }

        private void cbPuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarPreguntas();
        }

        private void dgvRes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void limpiarControles()
        {
            tbPregunta.Clear();
            btnGuardarPregunta.Visible = true;
            btnEditarPregunta.Visible = false;
            btnEliminarPregunta.Visible = false;
            btnRepuestas.Visible = false;
            btnNuevo.Visible = false;
            dgvPreg.ClearSelection();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarControles();
        }

        private void btnGuardarPregunta_Click(object sender, EventArgs e)
        {
            if (capaNegocias.preguntas.crearPregunta(tbPregunta.Text, (int)cbPuestos.SelectedValue))
            {                
                MessageBox.Show("Pregunta agregada exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarPreguntas();
            }
            else
            {
                MessageBox.Show("No se pudo agregar la pregunta, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarPregunta_Click(object sender, EventArgs e)
        {
            if (capaNegocias.preguntas.editarPregunta(tbPregunta.Text, idPregunta))
            {
                MessageBox.Show("Pregunta editada exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarPreguntas();
                limpiarControles();
            }
            else
            {
                MessageBox.Show("No se pudo editar la pregunta, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarPregunta_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Realmente quiere eliminar la pregunta?", "Eliminar...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (capaNegocias.preguntas.eliminarPregunta(idPregunta))
                {
                    cargarPreguntas();
                    limpiarControles();
                    MessageBox.Show("Pregunta eliminada exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Pregunta no eliminada, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRepuestas_Click(object sender, EventArgs e)
        {            
            capaNegocias.respuestas.idPregunta = idPregunta;
            abrirFormularioHijo(new respuestas());
            panel1.BringToFront();
        }

        private void confPreguntas_Load(object sender, EventArgs e)
        {
            limpiarControles();
        }
    }
}
