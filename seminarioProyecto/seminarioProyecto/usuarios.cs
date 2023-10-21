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
    public partial class usuarios : Form
    {
        string idUsuario, contrasenia;
        public usuarios()
        {
            InitializeComponent();
            cargarUsuarios();
            cargarGeneros();
            cargarRoles();
        }

        public void cargarUsuarios()
        {
            DataTable dtPreguntas;
            dtPreguntas = capaNegocias.usuarios.obtenerUsuarios();
            dgvUsuarios.DataSource = dtPreguntas;
            dgvUsuarios.Columns[7].Visible = false;
            dgvUsuarios.Columns[8].Visible = false;
            dgvUsuarios.Columns[9].Visible = false;
            dgvUsuarios.Columns[10].Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is menuAdmin formularioPadre)
            {
                formularioPadre.panelAlFondo();
            }

            this.Close();
        }

        public void cargarGeneros()
        {
            DataTable dtz = new DataTable();
            dtz.Clear();
            dtz = capaNegocias.usuarios.obtenerGeneros();
            cbGenero.DisplayMember = "GENERO";
            cbGenero.ValueMember = "ID_GENERO";
            cbGenero.DataSource = dtz;
        }

        public void cargarRoles()
        {
            DataTable dtz = new DataTable();
            dtz.Clear();
            dtz = capaNegocias.usuarios.obtenerRoles();
            cbRol.DisplayMember = "ROL";
            cbRol.ValueMember = "ID_ROL";
            cbRol.DataSource = dtz;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarControles();
        }

        private void usuarios_Load(object sender, EventArgs e)
        {
            limpiarControles();
        }

        private void dgvUsuarios_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int RowNo;
            RowNo = e.RowIndex;

            idUsuario = dgvUsuarios.Rows[RowNo].Cells[0].Value.ToString();
            tbNombre.Text = dgvUsuarios.Rows[RowNo].Cells[1].Value.ToString();
            tbApellidos.Text = dgvUsuarios.Rows[RowNo].Cells[2].Value.ToString();
            tbTelefono.Text = dgvUsuarios.Rows[RowNo].Cells[3].Value.ToString();
            tbDireccion.Text = dgvUsuarios.Rows[RowNo].Cells[4].Value.ToString();
            tbCorreo.Text = dgvUsuarios.Rows[RowNo].Cells[5].Value.ToString();
            dtpFechaNaci.Value = Convert.ToDateTime(dgvUsuarios.Rows[RowNo].Cells[6].Value);
            contrasenia = dgvUsuarios.Rows[RowNo].Cells[7].Value.ToString();
            tbUsuario.Text = idUsuario;
            tbContrasenia.Text = dgvUsuarios.Rows[RowNo].Cells[7].Value.ToString();
            cbGenero.SelectedValue = (int)dgvUsuarios.Rows[RowNo].Cells[8].Value;
            cbRol.SelectedValue = (int)dgvUsuarios.Rows[RowNo].Cells[9].Value;

            btnGuardar.Visible = false;
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
            btnNuevo.Visible = true;

            tbUsuario.ReadOnly = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            bool modificacionExitosa = capaNegocias.usuarios.editarUsuario(tbUsuario.Text, tbNombre.Text, tbApellidos.Text, tbTelefono.Text, tbDireccion.Text, tbCorreo.Text, (DateTime)dtpFechaNaci.Value, tbContrasenia.Text, (int)cbGenero.SelectedValue, (int)cbRol.SelectedValue);
            if (modificacionExitosa)
            {
                MessageBox.Show("Puesto editado exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarUsuarios();
                limpiarControles();
            }
            else
            {
                MessageBox.Show("No se pudo editar el puesto, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool insercionExitosa = capaNegocias.usuarios.crearUsuario(tbUsuario.Text, tbNombre.Text, tbApellidos.Text, tbTelefono.Text, tbDireccion.Text, tbCorreo.Text, (DateTime)dtpFechaNaci.Value, tbContrasenia.Text, (int)cbGenero.SelectedValue, (int)cbRol.SelectedValue);
            if (insercionExitosa)
            {
                MessageBox.Show("Usuario agregado exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarUsuarios();
                limpiarControles();
            }
            else
            {
                MessageBox.Show("No se pudo agregar el usuario, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Realmente quiere eliminar al usuario?", "Eliminar...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (capaNegocias.usuarios.eliminarUsuario(idUsuario))
                {
                    MessageBox.Show("Puesto eliminado exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarUsuarios();
                    limpiarControles();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el usuario, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void limpiarControles()
        {
            tbNombre.Clear();
            tbApellidos.Clear();
            tbTelefono.Clear();
            tbDireccion.Clear();
            tbCorreo.Clear();
            dtpFechaNaci.Value = DateTime.Now;          
            tbUsuario.Clear();
            tbContrasenia.Clear();
            cbGenero.SelectedIndex = 0;
            cbRol.SelectedIndex = 0;

            btnGuardar.Visible = true;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnNuevo.Visible = false;

            tbNombre.Focus();

            dgvUsuarios.ClearSelection();

            tbUsuario.ReadOnly = false;
        }
    }
}
