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
    public partial class respuestas : Form
    {
        int idPregunta = capaNegocias.respuestas.idPregunta;
        public respuestas()
        {
            InitializeComponent();
            cargarRespuestas();            
        }

        public void cargarRespuestas()
        {
            DataTable dtRespuestas;
            dtRespuestas = capaNegocias.respuestas.obtenerPuestos(idPregunta);
            dgvRes.DataSource = dtRespuestas;

            foreach (DataGridViewColumn columna in dgvRes.Columns)
            {
                columna.ReadOnly = true;
            }
            dgvRes.Columns[1].ReadOnly = false;
            dgvRes.Columns[2].ReadOnly = false;


            dgvRes.Columns[0].Visible = false;
            dgvRes.Columns[3].Visible = false;
            dgvRes.Columns[4].Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (valoresListos())
            {
                if (this.ParentForm is menuAdmin formularioPadre)
                {
                    formularioPadre.panelAlFondo();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Valores de las respuestas no repartidos correctamente o se repiten", "Revise...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnGuardarRes_Click(object sender, EventArgs e)
        {
            int numeroFilas = dgvRes.Rows.Count;
            if (capaNegocias.respuestas.crearRespuesta(tbRespuesta.Text, (numeroFilas + 1), idPregunta))
            {
                MessageBox.Show("Respuesta agregada exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarRespuestas();
            }
            else
            {
                MessageBox.Show("No se pudo agregar la respuesta, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //MessageBox.Show(numeroFilas.ToString());
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgvRes_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            btnEditarRes.Visible = true;
            btnEliminarRes.Visible = true;
        }

        public void editarRespuesta(string respuesta, int valor, int idRespuesta)
        {
            if (capaNegocias.respuestas.editarRespuesta(respuesta, valor, idRespuesta))
            {
                MessageBox.Show("Respuesta(s) editada(s) exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarRespuestas();
                //limpiarControles();
            }
            else
            {
                MessageBox.Show("Respuesta(s) no editada(s), intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool valoresListos()
        {
            string s ="a";
            List<int> numeros = new List<int>();

            // Recorrer las filas del DataGridView
            foreach (DataGridViewRow fila in dgvRes.Rows)
            {
                // Obtener el valor en la celda de la columna
                if (fila.Cells[2].Value != null && int.TryParse(fila.Cells[2].Value.ToString(), out int numero))
                {
                    numeros.Add(numero);
                }
            }

            // Verificar que todos los números del 1 al número de filas estén presentes y no se repitan
            for (int i = 1; i <= dgvRes.Rows.Count; i++)
            {
                if (!numeros.Contains(i))
                {
                    return false; // Faltan o se repiten números
                }
            }

            return true; // Todos los números están presentes y no se repiten
        }

        public void guardarCambios(string respuesta, int valor, int idRespuesta)
        {
            if(!capaNegocias.respuestas.editarRespuesta(respuesta,valor, idRespuesta))
            {
                MessageBox.Show("No se pudieron actualizar las respuestas, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }           
        }

        private void btnEditarRes_Click(object sender, EventArgs e)
        {
            if (valoresListos())
            {
                foreach (DataGridViewRow fila in dgvRes.Rows)
                {
                    DataGridViewCell celdaColumna0 = fila.Cells[0];
                    int idRespuesta = (int)celdaColumna0.Value;

                    DataGridViewCell celdaColumna1 = fila.Cells[1];
                    string respuesta = celdaColumna1.Value.ToString();

                    DataGridViewCell celdaColumna2 = fila.Cells[2];
                    int valor = (int)celdaColumna2.Value;
                    //MessageBox.Show("IdRes: "+idRespuesta+" Respuesta: " + respuesta + " Valor: " + valor);
                    guardarCambios(respuesta, valor, idRespuesta);
                }
                    MessageBox.Show("Respuestas actualizadas exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarRespuestas();
            }
            else
            {
                MessageBox.Show("Valores de las respuestas no repartidos correctamente o se repiten", "Revise...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRes_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Exception is NoNullAllowedException )
            {
                MessageBox.Show("No puede quedar el campo vacio","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            if (e.Exception != null && e.Exception is FormatException)
            {
                MessageBox.Show("El campo valor debe ser numérico entero","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
