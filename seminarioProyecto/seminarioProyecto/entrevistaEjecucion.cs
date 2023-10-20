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
    public partial class entrevistaEjecucion : Form
    {
        DataTable dtPreguntas;
        DataTable respuestasSeleccionadas = new DataTable();
        int indicePreguntaActual = 0;
        int idPreguntaActual;
        int cantidadPreguntas;
        public entrevistaEjecucion()
        {
            InitializeComponent();
        }

        public void crearColDtRespuestasSeleccionadas()
        {
            respuestasSeleccionadas.Columns.Add("ID_Pregunta", typeof(int));
            respuestasSeleccionadas.Columns.Add("ID_Respuesta", typeof(int));
        }

        public void agregarRespuestasDt()
        {                        
            DataRow newRow = respuestasSeleccionadas.NewRow();
            newRow["ID_Pregunta"] = idPreguntaActual;
            newRow["ID_Respuesta"] = Convert.ToInt32(cbRespuestas.SelectedValue);
            respuestasSeleccionadas.Rows.Add(newRow);
        }

        public void obtenerPreguntas()
        {
            dtPreguntas = capaNegocias.entrevistaEjecucion.obtenerPreguntas();
            cantidadPreguntas = dtPreguntas.Rows.Count;
        }

        public void contarPreguntas()
        {
            lbNoPregunta.Text = "Pregunta " + (indicePreguntaActual + 1) + " de " + cantidadPreguntas;
        }


        public void obtenerRespuestas(int idPre)
        {
            DataTable dtRespuestas = new DataTable();
            dtRespuestas.Clear();
            dtRespuestas = capaNegocias.entrevistaEjecucion.obtenerRespuestas(idPre);          
            cbRespuestas.DisplayMember = "RESPUESTA";
            cbRespuestas.ValueMember = "ID_RESPUESTA";
            cbRespuestas.DataSource = dtRespuestas;
        }

        public void mostrarPregunta()
        {
            if (indicePreguntaActual >= 0 && indicePreguntaActual < dtPreguntas.Rows.Count)
            {                
                string pregunta = dtPreguntas.Rows[indicePreguntaActual][1].ToString();
                int idPregunta = Convert.ToInt32(dtPreguntas.Rows[indicePreguntaActual][0]);
                idPreguntaActual = idPregunta;
                lbPregunta.Text = pregunta;

                obtenerRespuestas(idPregunta);
                mostrarRespuestaAnterior();
                verificarEstadoPregunta();
            }
        }

        public void verificarEstadoPregunta()
        {
            DataRow[] fila = respuestasSeleccionadas.Select($"ID_Pregunta = {idPreguntaActual}");

            if (fila.Length > 0)
            {
                lbEstadoPregunta.Text = "Respondido";
            }
            else
            {
                lbEstadoPregunta.Text = "Sin responder";
            }
        }

        private void mostrarRespuestaAnterior()
        {            
            // Busca la respuesta seleccionada anteriormente para la pregunta actual en el DataTable.
            DataRow[] selectedRows = respuestasSeleccionadas.Select($"ID_Pregunta = {idPreguntaActual}");

            if (selectedRows.Length > 0)
            {
                int idRespuestaSeleccionada = (int)selectedRows[0]["ID_Respuesta"];
                cbRespuestas.SelectedValue = idRespuestaSeleccionada;
            }            
        }

        public void agregarOmodificarRespuestaDt()
        {           

            // Busca la fila correspondiente a la pregunta actual en el DataTable.
            DataRow[] selectedRows = respuestasSeleccionadas.Select($"ID_Pregunta = {idPreguntaActual}");

            if (selectedRows.Length > 0)
            {
                // Si ya hay una fila para la pregunta actual, actualiza la respuesta seleccionada en esa fila.
                selectedRows[0]["ID_Respuesta"] = Convert.ToInt32(cbRespuestas.SelectedValue);
            }
            else
            {
                // Si no existe una fila para la pregunta actual, crea una nueva fila.
                DataRow newRow = respuestasSeleccionadas.NewRow();
                newRow["ID_Pregunta"] = idPreguntaActual;
                newRow["ID_Respuesta"] = Convert.ToInt32(cbRespuestas.SelectedValue);
                respuestasSeleccionadas.Rows.Add(newRow);                
            }
        }

        public void btCancelar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("La entrevista no se guardará hasta terminarla", "¿Realmente desea salir?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                regresarVentanaAnterior();
            }
        }

        public void regresarVentanaAnterior()
        {
            //Mostramos los controles en la ventana
            if (this.ParentForm is entrevista formularioPadre)
            {
                formularioPadre.ControlBox = false;
                if (formularioPadre.ParentForm is menuAdmin formlarioPrincipal)
                {
                    formlarioPrincipal.ControlBox = true;
                }
            }

            //Regresamos a la pantalla de entrevista
            if (this.ParentForm is entrevista fp)
            {
                fp.panelAlFondo();
                fp.cargarPostulantes();
                fp.deseleccionarDg();
            }
            this.Close();
        }

        private void entrevistaEjecucion_Load(object sender, EventArgs e)
        {
            //Ocultamos los controles en la ventana
            if (this.ParentForm is entrevista formularioPadre)
            {
                formularioPadre.ControlBox = false;
                if (formularioPadre.ParentForm is menuAdmin formlarioPrincipal)
                {
                    formlarioPrincipal.ControlBox = false;
                }
            }
            //MessageBox.Show("idPuesto: " + capaNegocias.entrevistaEjecucion.idPuestoEntrevista.ToString() + " idPostulacion: " + capaNegocias.entrevistaEjecucion.idPostulacionEntrevista.ToString());
            obtenerPreguntas();
            crearColDtRespuestasSeleccionadas();
            mostrarPregunta();
            contarPreguntas();
        }

        public void verificarUltimaPregunta()
        {
            int cantidadPreguntas = dtPreguntas.Rows.Count;
            if (cantidadPreguntas == (indicePreguntaActual+1))
            {
                btnSiguientePreg.Text = "Terminar y guardar";
            }
            else
            {
                btnSiguientePreg.Text = "Siguiente";
            }
        }

        private void btnSiguientePreg_Click(object sender, EventArgs e)
        {
            //Verifica si está en el rango de la cantidad de preguntas para guardar las respuestas en el DT
            if (indicePreguntaActual < dtPreguntas.Rows.Count)
            {
                //agregarRespuestasDt();
                agregarOmodificarRespuestaDt();
            }

            // Verifica de que el índice esté dentro de los límites del DT
            if (indicePreguntaActual < dtPreguntas.Rows.Count - 1)
            {
                indicePreguntaActual++; // Avanza al siguiente índice
                mostrarPregunta();
                verificarUltimaPregunta();
            }
            else
            {
                //MessageBox.Show("Entrevista guardada");
                //string a = "s";
                guardarResultados();
                guardarResultadoObtenido();
                guardarValorEntrevista();

            }

            if (indicePreguntaActual > 0)
            {
                btnRegresarPreg.Visible = true;
            }
            else
            {
                btnRegresarPreg.Visible =false;
            }
            contarPreguntas();
        }

        public void guardarResultadoObtenido()
        {
            DataTable resultado;
            int resultadoObtenido = 0;
            resultado = capaNegocias.entrevistaEjecucion.resultadoObtenido();
            if (resultado.Rows.Count > 0)
            {
                resultadoObtenido = Convert.ToInt32(resultado.Rows[0][0]);
                if (!capaNegocias.entrevistaEjecucion.guardarResultadoObtenido(resultadoObtenido))
                {                    
                    MessageBox.Show("Resultado no guardado, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void guardarValorEntrevista()
        {
            DataTable resultado;
            int valorEntrevista = 0;
            resultado = capaNegocias.entrevistaEjecucion.valorEntrevista();
            if (resultado.Rows.Count > 0)
            {
                valorEntrevista = Convert.ToInt32(resultado.Rows[0][0]);
                if (!capaNegocias.entrevistaEjecucion.guardarValorEntrevista(valorEntrevista))
                {
                    MessageBox.Show("Resultado no guardado, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void guardarResultados()
        {
            int idPostulacion = capaNegocias.entrevistaEjecucion.idPostulacionEntrevista;
            foreach (DataRow fila in respuestasSeleccionadas.Rows)
            {
                if (!capaNegocias.entrevistaEjecucion.guardarResultados(idPostulacion, Convert.ToInt32(fila[0]), Convert.ToInt32(fila[1])))
                {
                    //MessageBox.Show("Guardado: idPregunta: " + fila[0].ToString() + " idRespuesta: " + fila[1].ToString());                    
                    MessageBox.Show("Resultado no guardado, intente de nuevo", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    regresarVentanaAnterior();
                    return;
                }
            }

            if (!capaNegocias.entrevistaEjecucion.editarEstadoPostulacion(idPostulacion))
            {
                //MessageBox.Show("Guardado: idPregunta: " + fila[0].ToString() + " idRespuesta: " + fila[1].ToString());                    
                MessageBox.Show("Hubo un error en la postulación, intente de nuevo", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
                regresarVentanaAnterior();
                return;
            }
            else
            {
                MessageBox.Show("La entrevista se completó exitosamente", "Entrevista finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                regresarVentanaAnterior();
            }

        }

        private void btnRegresarPreg_Click(object sender, EventArgs e)
        {
            // Verifica si hay una pregunta anterior.
            if (indicePreguntaActual > 0)
            {
                indicePreguntaActual--;
                mostrarPregunta();
            }
            else
            {
                MessageBox.Show("Esta es la primera pregunta.");
            }

            if (indicePreguntaActual == 0)
            {
                btnRegresarPreg.Visible = false;
                btnSiguientePreg.Focus();
            }
            verificarUltimaPregunta();
            mostrarRespuestaAnterior();
            contarPreguntas();
            btnSiguientePreg.Focus();
        }
    }
}
