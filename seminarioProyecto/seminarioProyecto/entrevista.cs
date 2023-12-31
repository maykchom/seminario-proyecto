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
    public partial class entrevista : Form
    {
        private Form formularioHijoActual;
        int idEstado, idPostulacionEntre;
        DateTime fechaInicio, fechaFin;
        public entrevista()
        {
            InitializeComponent();

            if (!capaNegocias.metodosComunes.verificarConexion())
            {
                MessageBox.Show("Se perdió la conexión con el servidor", "Sin conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
        public void cargarPostulantes()
        {
            DataTable dtPostu;
            dtPostu = capaNegocias.entrevistas.obtenerPostulantes(Convert.ToInt32(cbPuestos.SelectedValue));
            dgvPost.DataSource = dtPostu;
            dgvPost.Columns[0].Visible = false;
            dgvPost.Columns[3].Visible = false;
            dgvPost.Columns[6].Visible = false;
            dgvPost.Columns[8].Visible = false;
            dgvPost.Columns[10].Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is menuAdmin formularioPadre)
            {
                formularioPadre.panelAlFondo();
            }

            this.Close();
        }

        private void cbPuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarPostulantes();
            dgvPost.ClearSelection();
            btnRealizarEntrevista.Enabled = false;
        }

        private void entrevista_Load(object sender, EventArgs e)
        {
            dgvPost.ClearSelection();
        }

        private void ejecutarEntrevista()
        {
            abrirFormularioHijo(new entrevistaEjecucion());
            panel1.BringToFront();
        }

        private bool preguntasSinRespuesta()
        {
            DataTable dtRes;
            dtRes = capaNegocias.entrevistas.obtenerTotalResupuestas((int)cbPuestos.SelectedValue);

            // Asumimos que la tercera columna tiene índice 2 (ya que la indexación comienza en 0)
            int indiceColumna = 2;

            foreach (DataRow fila in dtRes.Rows)
            {
                // Verificamos si el valor en la tercera columna es igual a cero
                if (Convert.ToInt32(fila[indiceColumna]) == 0)
                {
                    return true; // Se encontró al menos un cero en la tercera columna
                }
            }

            return false; // No se encontraron ceros en la tercera columna

        }

        private void btnRealizarEntrevista_Click(object sender, EventArgs e)
        {
            if (!capaNegocias.metodosComunes.verificarConexion())
            {
                MessageBox.Show("Se perdió la conexión con el servidor", "Sin conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (idEstado != 1)
            {
                MessageBox.Show("La entrevista ya fué realizada", "Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPost.ClearSelection();
                return;
            }

            DataTable dtPreguntas;
            dtPreguntas = capaNegocias.entrevistas.obtenerPreguntasDisponibles((int)cbPuestos.SelectedValue);
            if (dtPreguntas.Rows.Count < 3)
            {
                MessageBox.Show("El puesto debe tener al menos 2 preguntas dispobibles", "Sin preguntas suficientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (preguntasSinRespuesta())
            {
                MessageBox.Show("En la entrevista del puesto existe(n) pregunta(s) sin respuestas", "Verifique respuestas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DateTime hoy = DateTime.Now; 
            if (hoy.Date >= fechaInicio.Date && hoy.Date <= fechaFin.Date )
            {
                ejecutarEntrevista();
            }
            else if(hoy.Date < fechaInicio.Date)
            {
                MessageBox.Show("Las fechas de convocatoria aún no empiezan", "Fuera de fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (hoy.Date > fechaFin.Date)
            {
                MessageBox.Show("Las fechas de convocatoria ya finalizaron", "Fuera de fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void panelAlFondo()
        {
            panel1.SendToBack();
        }

        private void dgvPost_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowNo;
            RowNo = e.RowIndex;
            idEstado = Convert.ToInt32(dgvPost.Rows[RowNo].Cells[8].Value);
            fechaInicio = Convert.ToDateTime(dgvPost.Rows[RowNo].Cells[4].Value);
            fechaFin = Convert.ToDateTime(dgvPost.Rows[RowNo].Cells[5].Value);      
            idPostulacionEntre = Convert.ToInt32(dgvPost.Rows[RowNo].Cells[6].Value);
            capaNegocias.entrevistaEjecucion.idPuestoEntrevista = Convert.ToInt32(cbPuestos.SelectedValue);
            capaNegocias.entrevistaEjecucion.idPostulacionEntrevista = idPostulacionEntre;
            btnRealizarEntrevista.Enabled = true;
        }

        public void deseleccionarDg()
        {
            dgvPost.ClearSelection();
            btnRealizarEntrevista.Enabled = false;
        }
    }
}
