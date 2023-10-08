using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using MySql.Data.MySqlClient;

namespace capaNegocias
{
    public class entrevistaEjecucion
    {
        public static int idPuestoEntrevista;
        public static int idPostulacionEntrevista;

        public static DataTable obtenerPreguntas()
        {
            string cadena = "SELECT * FROM PREGUNTAS WHERE ID_PUESTO = "+idPuestoEntrevista+" AND ID_ESTADO=1";
            return datos.GetDataTable(cadena);
        }

        public static DataTable obtenerRespuestas(int idPregunta)
        {
            string cadena = "SELECT * FROM respuestas WHERE ID_PREGUNTA = "+idPregunta+" AND ID_ESTADO=1";
            return datos.GetDataTable(cadena);
        }

        public static bool guardarResultados(int idPostulacion, int idPregunta, int idRespuesta)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO RESULTADOS (ID_POSTULACION, ID_PREGUNTA, ID_RESPUESTA, ID_ESTADO) " +
            "VALUES(@idPostulacion, @idPregunta, @idRespuesta, 1);";
            cmd.Parameters.AddWithValue("@idPostulacion", idPostulacion);
            cmd.Parameters.AddWithValue("@idPregunta", idPregunta);
            cmd.Parameters.AddWithValue("@idRespuesta", idRespuesta);
            return datos.ExecTransactionParameters(cmd);
        }

        public static bool editarEstadoPostulacion(int idPostulacion)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE POSTULACIONES SET ID_ESTADO_ENTREVISTA = 2 " +
            "WHERE ID_POSTULACION = @idPostulacion;";
            cmd.Parameters.AddWithValue("@idPostulacion", idPostulacion);
            return datos.ExecTransactionParameters(cmd);
        }
    }
}
