using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

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
    }
}
