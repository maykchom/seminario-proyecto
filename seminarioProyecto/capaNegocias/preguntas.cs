using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocias
{
    public class preguntas
    {
        public static DataTable obtenerPuestos()
        {
            string cadena = "SELECT * FROM PUESTOS;";
            return datos.GetDataTable(cadena);
        }

        public static DataTable obtenerPreguntas(int idPuesto)
        {
            string cadena = "SELECT PU.ID_PUESTO, PRE.ID_PREGUNTA, PRE.PREGUNTA FROM puestos AS PU " +
                "INNER JOIN preguntas AS PRE ON PRE.ID_PUESTO = PU.ID_PUESTO " +
                "WHERE PU.ID_PUESTO = "+idPuesto+" AND PU.ID_ESTADO = 1 AND PRE.ID_ESTADO = 1 " +
                "ORDER BY ID_PREGUNTA";
            return datos.GetDataTable(cadena);
        }

        public static DataTable obtenerRespuestas(int idPregunta)
        {
            string cadena = "SELECT * FROM RESPUESTAS " +
                "WHERE ID_PREGUNTA = "+idPregunta+" AND ID_ESTADO = 1 " +
                "ORDER BY VALOR DESC;";
            return datos.GetDataTable(cadena);
        }
    }
}
