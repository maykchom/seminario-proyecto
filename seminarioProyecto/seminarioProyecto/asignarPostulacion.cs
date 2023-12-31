﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaNegocias;

namespace seminarioProyecto
{
    public partial class asignarPostulacion : Form
    {
        bool convoVacias, postuVacios= false;
        int idPostulacion;
        DateTime fechaFinal;
        public asignarPostulacion()
        {
            InitializeComponent();

            if (!capaNegocias.metodosComunes.verificarConexion())
            {
                MessageBox.Show("Se perdió la conexión con el servidor", "Sin conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cargarPuestos(cbPuestos);
            cargarPostulantes(cbPostulanteAE);
        }

        private void cargarPostulantes()
        {
            DataTable dtPostu;
            dtPostu = capaNegocias.postulaciones.obtenerPostulaciones(Convert.ToInt32(cbFechas.SelectedValue));
            //MessageBox.Show(cbPuestos.SelectedValue.ToString());

            dgvPost.DataSource = dtPostu;
            dgvPost.Columns[0].Visible = false;
            dgvPost.Columns[2].Visible = false;
            dgvPost.Columns[3].Visible = false;
            dgvPost.Columns[4].Visible = false;
            dgvPost.Columns[5].Visible = false;
            dgvPost.Columns[6].Visible = false;
            dgvPost.Columns[7].Visible = false;
            dgvPost.Columns[8].Visible = false;
            dgvPost.Columns[9].Visible = false;

            dgvPost.ClearSelection();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is menuAdmin formularioPadre)
            {
                formularioPadre.panelAlFondo();
            }

            this.Close();
        }

        public bool existePostulante()
        {
            string consulta = "SELECT * FROM postulaciones WHERE ID_CONVOCATORIA = "+Convert.ToInt32(cbFechas.SelectedValue)+" AND ID_POSTULANTE = "+Convert.ToInt32(cbPostulanteAE.SelectedValue)+" AND ID_ESTADO = 1";
            DataTable resultado = metodosComunes.consultaAbiertaSinParametros(consulta);
            if (resultado.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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

        public void cargarConvocatorias(ComboBox cb)
        {
            DataTable dtz = new DataTable();
            dtz.Clear();
            dtz = capaNegocias.postulaciones.obtenerConvocatorias(Convert.ToInt32(cbPuestos.SelectedValue));
            cb.DisplayMember = "CONVOCATORIA";
            cb.ValueMember = "ID_CONVOCATORIA";
            cb.DataSource = dtz;
        }

        public void cargarPostulantes(ComboBox cb)
        {
            DataTable dtz = new DataTable();
            dtz.Clear();
            dtz = capaNegocias.postulaciones.obtenerPostulantes();
            cb.DisplayMember = "POSTULANTE";
            cb.ValueMember = "ID_POSTULANTE";
            cb.DataSource = dtz;
        }

        private void cbPuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGuardar.Visible = true;
            btnEliminar.Visible = false;
            btNuevo.Visible = false;
            dgvPost.ClearSelection();
            cargarConvocatorias(cbFechas);

            if (cbFechas.Items.Count == 0)
            {
                cbFechas.Enabled = false;
                //cbFechas.DataSource = null;
                //cbFechas.Items.Add("No existen convocatorias");
                //cbFechas.SelectedIndex = 0;
                convoVacias = true;
            }
            else
            {
                cbFechas.Enabled = true;
                convoVacias = false;
            }
        }



        public void crearPostulacion()
        {
            if (postulaciones.crearPostulacion(Convert.ToInt32(cbFechas.SelectedValue), Convert.ToInt32(cbPostulanteAE.SelectedValue), sesion.id_usuario))
            {
                cargarPostulantes();                
                MessageBox.Show("Postulación agreada exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Postulación no agregada, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!capaNegocias.metodosComunes.verificarConexion())
            {
                MessageBox.Show("Se perdió la conexión con el servidor", "Sin conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbPuestos.Items.Count == 0)
            {
                MessageBox.Show("No existen puestos", "Revise...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (convoVacias || postuVacios)
            {
                MessageBox.Show("No existe convocatorias o pustulantes", "Revise...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (existePostulante())
            {
                MessageBox.Show("El postulante ya existe en esa convocatoria", "Revise...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (fechaFinal.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Las fechas de convocatoria ya finalizaron", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            crearPostulacion();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!capaNegocias.metodosComunes.verificarConexion())
            {
                MessageBox.Show("Se perdió la conexión con el servidor", "Sin conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("¿Realmente quiere eliminar la postulación?", "Eliminar...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (capaNegocias.postulaciones.eliminarPostulacion(idPostulacion))
                {
                    cargarPostulantes();
                    limpiarCampos();
                    MessageBox.Show("Postulación eliminada exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Postulación no eliminada, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void limpiarCampos()
        {
            btNuevo.Visible = false;
            btnGuardar.Visible = true;
            btnEliminar.Visible = false;

            dgvPost.ClearSelection();
            //cbPostulanteAE.SelectedIndex = 0;
        }

        private void dgvPost_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btNuevo.Visible = true;
            btnGuardar.Visible = false;
            btnEliminar.Visible = true;

            int RowNo;
            RowNo = e.RowIndex;

            idPostulacion = Convert.ToInt32(dgvPost.Rows[RowNo].Cells[0].Value);            
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void asignarPostulacion_Load(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void cbFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarPostulantes();
            DataTable dtFecha = new DataTable();
            dtFecha = capaNegocias.postulaciones.obtenerFechaFin((int)cbFechas.SelectedValue);
            fechaFinal = (DateTime)dtFecha.Rows[0][0];
            //MessageBox.Show(fechaFinal.ToString());

        }

        private void cbPostulanteAE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPostulanteAE.Items.Count == 0)
            {
                cbPostulanteAE.Enabled = false;
                cbPostulanteAE.DataSource = null;
                cbPostulanteAE.Items.Add("No existen postulantes");
                cbPostulanteAE.SelectedIndex = 0;
                postuVacios = true;
            }
            else
            {
                cbPostulanteAE.Enabled = true;
                postuVacios = false;
            }
        }
    }
}
