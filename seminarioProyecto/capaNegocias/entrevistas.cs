using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocias
{
    public class entrevistas
    {
        public static DataTable obtenerPuestos()
        {
            string cadena = "SELECT * FROM PUESTOS;";
            return datos.GetDataTable(cadena);
        }

        public static DataTable obtenerPostulantes(int idPuesto)
        {
            string cadena = "SELECT PP.ID_POSTULANTE, PP.APELLIDOS, PP.NOMBRES, C.ID_CONVOCATORIA, " +
                "DATE_FORMAT(C.FECHA_INICIO, '%d/%m/%Y') AS 'INICIO CONVOCATORIA', " +
                "DATE_FORMAT(C.FECHA_FIN, '%d/%m/%Y') AS 'FIN CONVOCATORIA', P.ID_POSTULACION, " +
                "P.FECHA_POSTULACION, EE.ID_ESTADO_ENTREVISTA, EE.ESTADO_ENTREVISTA AS ESTADO, PU.ID_PUESTO " +
                "FROM postulaciones AS P " +
                "INNER JOIN postulantes AS PP ON PP.ID_POSTULANTE = P.ID_POSTULANTE " +
                "INNER JOIN convocatorias AS C ON C.ID_CONVOCATORIA = P.ID_CONVOCATORIA " +
                "INNER JOIN puestos AS PU ON PU.ID_PUESTO = C.ID_PUESTO " +
                "INNER JOIN estados_entrevista AS EE ON EE.ID_ESTADO_ENTREVISTA = P.ID_ESTADO_ENTREVISTA " +
                "WHERE PU.ID_PUESTO = "+idPuesto+" AND P.ID_ESTADO = 1 AND C.ID_ESTADO = 1 ";
            return datos.GetDataTable(cadena);
        }

        public static DataTable obtenerPreguntasDisponibles(int idPuesto)
        {
            string cadena = "SELECT PR.ID_PREGUNTA " +
                "FROM puestos AS PU " +
                "INNER JOIN preguntas AS PR ON PR.ID_PUESTO = PU.ID_PUESTO " +
                "WHERE PU.ID_PUESTO = "+idPuesto+" AND PR.ID_ESTADO = 1";
            return datos.GetDataTable(cadena);
        }

        public static DataTable obtenerTotalResupuestas(int idPuesto)
        {
            string cadena = "SELECT PR.ID_PREGUNTA, PR.PREGUNTA, COUNT(RE.ID_RESPUESTA) AS TOTALRESPUESTAS " +
                "FROM puestos AS PU " +
                "INNER JOIN preguntas AS PR ON PR.ID_PUESTO = PU.ID_PUESTO " +
                "LEFT JOIN respuestas AS RE ON RE.ID_PREGUNTA = PR.ID_PREGUNTA " +
                "WHERE PU.ID_PUESTO = "+idPuesto+" AND PR.ID_ESTADO = 1 " +
                "GROUP BY PR.ID_PREGUNTA";
            return datos.GetDataTable(cadena);
        }
    }
}
