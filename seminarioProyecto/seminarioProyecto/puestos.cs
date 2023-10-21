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
    public partial class puestos : Form
    {
        int idPuesto;
        public puestos()
        {
            InitializeComponent();
            cargarPuestos();
        }

        public void cargarPuestos()
        {
            DataTable dtPreguntas;
            dtPreguntas = capaNegocias.puestos.obtenerPuestos();
            dgvPuestos.DataSource = dtPreguntas;
            dgvPuestos.Columns[0].Visible = false;
            dgvPuestos.Columns[4].Visible = false;
            limpiarControles();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is menuAdmin formularioPadre)
            {
                formularioPadre.panelAlFondo();
            }

            this.Close();
        }

        private void dgvPuestos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowNo;
            RowNo = e.RowIndex;

            idPuesto = Convert.ToInt32(dgvPuestos.Rows[RowNo].Cells[0].Value);
            tbPuesto.Text = dgvPuestos.Rows[RowNo].Cells[1].Value.ToString();
            tbDescripcion.Text = dgvPuestos.Rows[RowNo].Cells[2].Value.ToString();
            tbPerfilPuesto.Text = dgvPuestos.Rows[RowNo].Cells[3].Value.ToString();

            btnGuardar.Visible = false;
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
            btnNuevo.Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (capaNegocias.puestos.crearPuesto(tbPuesto.Text, tbDescripcion.Text, tbPerfilPuesto.Text))
            {
                MessageBox.Show("Puesto agregado exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarPuestos();
                limpiarControles();
            }
            else
            {
                MessageBox.Show("No se pudo agregar el puesto, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiarControles()
        {
            tbPuesto.Clear();
            tbDescripcion.Clear();
            tbPerfilPuesto.Clear();

            btnGuardar.Visible = true;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnNuevo.Visible = false;

            tbPuesto.Focus();

            dgvPuestos.ClearSelection();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarControles();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (capaNegocias.puestos.editarPuesto(idPuesto, tbPuesto.Text, tbDescripcion.Text, tbPerfilPuesto.Text))
            {
                MessageBox.Show("Puesto editado exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarPuestos();
                limpiarControles();
            }
            else
            {
                MessageBox.Show("No se pudo editar el puesto, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Realmente quiere eliminar el puesto?", "Eliminar...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            { 
                if (capaNegocias.puestos.eliminarPuesto(idPuesto))
                {
                    MessageBox.Show("Puesto eliminado exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarPuestos();
                    limpiarControles();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el puesto, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
