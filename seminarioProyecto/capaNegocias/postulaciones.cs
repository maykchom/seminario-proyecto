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
    public class postulaciones
    {
        public static DataTable obtenerPuestos()
        {
            string cadena = "SELECT * FROM PUESTOS;";
            return datos.GetDataTable(cadena);
        }

        //public static DataTable obtenerPostulaciones(int idPuesto)
        //{
        //    string strSQL = "SELECT POST.*, PUES.ID_PUESTO, PUES.TITULO AS PUESTO, CONCAT(POSTU.NOMBRES,' ',POSTU.APELLIDOS) AS POSTULANTE " +
        //    "FROM postulaciones AS POST "+
        //    "INNER JOIN convocatorias AS C ON C.ID_CONVOCATORIA = POST.ID_CONVOCATORIA "+
        //    "INNER JOIN puestos AS PUES ON PUES.ID_PUESTO = C.ID_PUESTO "+
        //    "INNER JOIN postulantes AS POSTU ON POSTU.ID_POSTULANTE = POST.ID_POSTULANTE "+
        //    "WHERE C.ID_PUESTO = "+idPuesto+" AND POST.ID_ESTADO = 1 " +
        //    "ORDER BY POST.ID_POSTULACION;";
        //    return datos.GetDataTable(strSQL);
        //}

        public static DataTable obtenerPostulaciones(int idPuesto)
        {
            string strSQL = "SELECT POST.*, PUES.ID_PUESTO, PUES.TITULO AS PUESTO, CONCAT(POSTU.NOMBRES,' ',POSTU.APELLIDOS) AS POSTULANTE " +
            "FROM postulaciones AS POST " +
            "INNER JOIN convocatorias AS C ON C.ID_CONVOCATORIA = POST.ID_CONVOCATORIA " +
            "INNER JOIN puestos AS PUES ON PUES.ID_PUESTO = C.ID_PUESTO " +
            "INNER JOIN postulantes AS POSTU ON POSTU.ID_POSTULANTE = POST.ID_POSTULANTE " +
            "WHERE C.ID_PUESTO = " + idPuesto + " AND POST.ID_ESTADO = 1 ";
            return datos.GetDataTable(strSQL);
        }

        public static DataTable obtenerConvocatorias(int idPuesto)
        {
            string strSQL = "SELECT ID_CONVOCATORIA, CONCAT(FECHA_INICIO,' | ',FECHA_FIN) AS Convocatoria " +
            "FROM convocatorias " +
            "WHERE ID_PUESTO = " + idPuesto + " AND ID_ESTADO = 1;";
            return datos.GetDataTable(strSQL);
        }

        public static DataTable obtenerPostulantes()
        {
            string strSQL = "SELECT ID_POSTULANTE, CONCAT(NOMBRES,' ',APELLIDOS) AS POSTULANTE " +
            "FROM postulantes " +
            "ORDER BY POSTULANTE";
            return datos.GetDataTable(strSQL);
        }

        public static bool crearPostulacion(int idConcovatoria, int idPostulante, string idUsuario)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO POSTULACIONES (ID_CONVOCATORIA, ID_POSTULANTE, ID_USUARIO, ID_ESTADO, ID_ESTADO_ENTREVISTA) " +
                "VALUES(@idConcovatoria, @idPostulante, @idUsuario, 1, 1);";
            cmd.Parameters.AddWithValue("@idConcovatoria", idConcovatoria);
            cmd.Parameters.AddWithValue("@idPostulante", idPostulante);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            return datos.ExecTransactionParameters(cmd);
        }

        public static bool eliminarPostulacion(int idPostulacion)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE POSTULACIONES SET ID_ESTADO= 2 WHERE ID_POSTULACION = @idPostulacion;";
            cmd.Parameters.AddWithValue("@idPostulacion", idPostulacion);
            return datos.ExecTransactionParameters(cmd);
        }
    }
}
