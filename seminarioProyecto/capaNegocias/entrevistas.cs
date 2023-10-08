﻿using System;
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
                "WHERE PU.ID_PUESTO = "+idPuesto+" AND P.ID_ESTADO = 1 AND C.ID_ESTADO = 1 "+
                "ORDER BY PP.APELLIDOS";
            return datos.GetDataTable(cadena);
        }

    }
}
