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
    public class convocatorias
    {
        public static DataTable cargarPuestos()
        {
            string cadena = "SELECT * FROM PUESTOS WHERE ID_ESTADO = 1;";
            return datos.GetDataTable(cadena);
        }

        public static DataTable obtenerConvocatorias()
        {
            string strSQL = "SELECT C.ID_CONVOCATORIA, PU.ID_PUESTO, US.ID_USUARIO AS CREADOR, PU.TITULO AS PUESTO, C.FECHA_INICIO AS INICIO, C.FECHA_FIN AS FIN, C.OBSERVACIONES " +
                            "FROM CONVOCATORIAS AS C "+
                            "INNER JOIN PUESTOS AS PU ON PU.ID_PUESTO = C.ID_PUESTO "+
                            "INNER JOIN USUARIOS AS US ON US.ID_USUARIO = C.ID_USUARIO "+
                            "WHERE C.ID_ESTADO = 1 "+
                            "ORDER BY C.ID_CONVOCATORIA";
            return datos.GetDataTable(strSQL);
        }

        public static bool crearConovocatoria(DateTime fechaInicio, DateTime fechaFin, string observaciones, int idPuesto, string idUsuario)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO CONVOCATORIAS (FECHA_INICIO, FECHA_FIN, OBSERVACIONES, ID_PUESTO, ID_USUARIO, ID_ESTADO) " +
                "VALUES(@fechaInicio, @fechaFin, @observaciones, @id_puesto, @id_usuario, 1);";
            cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
            cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
            cmd.Parameters.AddWithValue("@observaciones", observaciones);
            cmd.Parameters.AddWithValue("@id_puesto", idPuesto);
            cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
            return datos.ExecTransactionParameters(cmd);
        }

        public static bool editarConvocatoria(DateTime fechaInicio, DateTime fechaFin, string observaciones, int idPuesto, string idConvocatoria)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE CONVOCATORIAS SET FECHA_INICIO =@fechaInicio, FECHA_FIN=@fechaFin, OBSERVACIONES=@observaciones, ID_PUESTO=@id_puesto WHERE ID_CONVOCATORIA = @id_convo; ";
            cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
            cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
            cmd.Parameters.AddWithValue("@observaciones", observaciones);
            cmd.Parameters.AddWithValue("@id_puesto", idPuesto);
            cmd.Parameters.AddWithValue("@id_convo", idConvocatoria);
            return datos.ExecTransactionParameters(cmd);
        }

        public static bool eliminarConvocatoria(string idConvocatoria)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE CONVOCATORIAS SET ID_ESTADO= 2 WHERE ID_CONVOCATORIA = @id_convo;";
            cmd.Parameters.AddWithValue("@id_convo", idConvocatoria);
            return datos.ExecTransactionParameters(cmd);
        }

        public static DataTable cargarDatosAfiche(string idConvocatoria)
        {
            string cadena = "SELECT C.ID_CONVOCATORIA, DATE_FORMAT(C.FECHA_INICIO, '%d/%m/%Y') AS INICIO, DATE_FORMAT(C.FECHA_FIN, '%d/%m/%Y') AS FIN, OBSERVACIONES, P.ID_PUESTO, TITULO, DESCRIPCION, PERFIL " +
                "FROM convocatorias AS C INNER JOIN puestos AS P ON P.ID_PUESTO = C.ID_PUESTO " +
                "WHERE C.ID_CONVOCATORIA = "+idConvocatoria;
            return datos.GetDataTable(cadena);
        }


    }
}
