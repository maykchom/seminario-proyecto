using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocias
{
    public class resultados
    {
        public static DataTable obtenerPuestos()
        {
            string cadena = "SELECT * FROM PUESTOS WHERE ID_ESTADO = 1;";
            return datos.GetDataTable(cadena);
        }

        public static DataTable obtenerConvocatorias(int idPuesto)
        {
            string strSQL = "SELECT ID_CONVOCATORIA, CONCAT(DATE_FORMAT(FECHA_INICIO, '%d/%m/%Y'),'  -  ',DATE_FORMAT(FECHA_FIN, '%d/%m/%Y')) AS Convocatoria " +
            "FROM convocatorias " +
            "WHERE ID_PUESTO = " + idPuesto + " AND ID_ESTADO = 1;";
            return datos.GetDataTable(strSQL);
        }

        public static DataTable obtenerResultados(int idConvocatoria)
        {
            string cadena = "SELECT CONCAT(PP.NOMBRES,' ', PP.APELLIDOS) AS POSTULANTE, " +
                "ROUND((P.VALOR_ENTREVISTA_OBTENIDO / P.VALOR_ENTREVISTA)*100) AS RESULTADO " +
                "FROM convocatorias AS C " +
                "INNER JOIN postulaciones AS P ON P.ID_CONVOCATORIA = C.ID_CONVOCATORIA " +
                "INNER JOIN postulantes AS PP ON PP.ID_POSTULANTE = P.ID_POSTULANTE " +
                "WHERE C.ID_CONVOCATORIA = "+idConvocatoria+" AND C.ID_ESTADO = 1 AND P.ID_ESTADO = 1 AND PP.ID_ESTADO = 1";
            return datos.GetDataTable(cadena);
        }

    }
}
