﻿using System;
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
    public partial class postulantes : Form
    {
        int idPostulante;
        public postulantes()
        {
            InitializeComponent();
            cargarGeneros(cbGenero);
            cargarPostulantes();
        }

        private void cargarPostulantes()
        {
            DataTable dtPostu;
            dtPostu = capaNegocias.postulantes.obtenerPostulantes();
            dgvPost.DataSource = dtPostu;
            dgvPost.Columns[0].Visible = false;
            dgvPost.Columns[7].Visible = false;
            dgvPost.Columns[8].Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is menuAdmin formularioPadre)
            {
                formularioPadre.panelAlFondo();
            }

            this.Close();
        }

        public void cargarGeneros(ComboBox cb)
        {
            DataTable dtz = new DataTable();
            dtz.Clear();
            dtz = capaNegocias.postulantes.obtenerGeneros();
            cb.DisplayMember = "GENERO";
            cb.ValueMember = "ID_GENERO";
            cb.DataSource = dtz;
        }

        private void dgvPost_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gbPostulantes.Text = "Editar convocatoria";
            btNuevo.Visible = true;
            btnGuardar.Visible = false;
            btnEditar.Visible = true;            
            btnEliminar.Visible = true;

            int RowNo;
            RowNo = e.RowIndex;

            idPostulante = Convert.ToInt32(dgvPost.Rows[RowNo].Cells[0].Value);
            tbNombre.Text = dgvPost.Rows[RowNo].Cells[1].Value.ToString();
            tbApellidos.Text = dgvPost.Rows[RowNo].Cells[2].Value.ToString();
            dtFechaNac.Value = Convert.ToDateTime(dgvPost.Rows[RowNo].Cells[3].Value);
            tbDireccion.Text = dgvPost.Rows[RowNo].Cells[4].Value.ToString();
            tbTelefono.Text = dgvPost.Rows[RowNo].Cells[5].Value.ToString();
            tbCorreo.Text = dgvPost.Rows[RowNo].Cells[6].Value.ToString();
            cbGenero.SelectedValue = Convert.ToInt32(dgvPost.Rows[RowNo].Cells[7].Value);
        }

        public void limpiarCampos()
        {
            gbPostulantes.Text = "Nuevo postulante";
            btNuevo.Visible = false;
            btnGuardar.Visible = true;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;

            cbGenero.SelectedIndex = 0;
            tbNombre.Clear();
            tbApellidos.Clear();
            dtFechaNac.Value = DateTime.Now;
            tbDireccion.Clear();
            tbTelefono.Clear();
            tbCorreo.Clear();
            dgvPost.ClearSelection();
            tbNombre.Focus();
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void postulantes_Load(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        public void crearPostulante()
        {
            DateTime fechaNacimiento = Convert.ToDateTime(dtFechaNac.Value);
            DateTime fechaMinima = new DateTime(1950, 01, 01, 0, 0, 0);
            DateTime fechaMaxima = DateTime.Now;


            if (fechaNacimiento.Date < fechaMinima.Date || fechaNacimiento.Date > fechaMaxima.Date)
            {
                MessageBox.Show("La fecha de nacimiento supera lo establecido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (capaNegocias.postulantes.crearPostulante(tbNombre.Text, tbApellidos.Text, fechaNacimiento, tbDireccion.Text, tbTelefono.Text, tbCorreo.Text, Convert.ToInt32(cbGenero.SelectedValue)))
            {
                cargarPostulantes();
                limpiarCampos();
                MessageBox.Show("Postulante agreado exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Postulante no agregado, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                crearPostulante();
            }
            catch (Exception)
            {
                MessageBox.Show("Existe un error en los datos, favor de revisar ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        public void editarPostulante()
        {
            DateTime fechaNacimiento = Convert.ToDateTime(dtFechaNac.Value);
            DateTime fechaMinima = new DateTime(1950, 01, 01, 0, 0, 0);
            DateTime fechaMaxima = DateTime.Now;


            if (fechaNacimiento.Date < fechaMinima.Date || fechaNacimiento.Date > fechaMaxima.Date)
            {
                MessageBox.Show("La fecha de nacimiento supera lo establecido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (capaNegocias.postulantes.editarPostulante(tbNombre.Text, tbApellidos.Text, fechaNacimiento, tbDireccion.Text, tbTelefono.Text, tbCorreo.Text, Convert.ToInt32(cbGenero.SelectedValue), idPostulante))
            {
                cargarPostulantes();
                limpiarCampos();
                MessageBox.Show("Postulante editado exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Postulante no editado, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            editarPostulante();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Realmente quiere eliminar al/la postulante?", "Eliminar...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {                
                if (capaNegocias.postulantes.eliminarPostulante(idPostulante))
                {
                    cargarPostulantes();
                    limpiarCampos();
                    MessageBox.Show("Postulante eliminado/a exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Postulante no eliminado/a, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
