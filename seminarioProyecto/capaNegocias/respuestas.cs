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
    public class respuestas
    {
        public static int idPregunta;
        public static DataTable obtenerPuestos(int idPregunta)
        {
            string cadena = "SELECT * FROM RESPUESTAS WHERE ID_PREGUNTA = "+idPregunta;
            return datos.GetDataTable(cadena);
        }

        public static bool crearRespuesta(string respesta, int valor, int idPregunta)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO RESPUESTAS (RESPUESTA, VALOR, ID_PREGUNTA, ID_ESTADO) VALUES(@respesta, @valor, @idPregunta, 1)";
            cmd.Parameters.AddWithValue("@respesta", respesta);
            cmd.Parameters.AddWithValue("@valor", valor);
            cmd.Parameters.AddWithValue("@idPregunta", idPregunta);
            return datos.ExecTransactionParameters(cmd);
        }

        public static bool editarRespuesta(string respuesta, int valor, int idRespuesta)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE RESPUESTAS SET RESPUESTA = @respuesta, VALOR = @valor WHERE ID_RESPUESTA = @idRespuesta";
            cmd.Parameters.AddWithValue("@respuesta", respuesta);
            cmd.Parameters.AddWithValue("@valor", valor);
            cmd.Parameters.AddWithValue("@idRespuesta", idRespuesta);
            return datos.ExecTransactionParameters(cmd);
        }

    }
}
