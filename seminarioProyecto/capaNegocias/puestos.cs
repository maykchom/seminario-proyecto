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
    public class puestos
    {
        public static DataTable obtenerPuestos()
        {
            string cadena = "SELECT * FROM PUESTOS WHERE ID_ESTADO = 1;";
            return datos.GetDataTable(cadena);
        }

        public static bool crearPuesto(string titulo, string descripcion, string perfil)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO PUESTOS (TITULO, DESCRIPCION, PERFIL, ID_ESTADO) VALUES(@titulo, @descripcion, @perfil, 1)";
            cmd.Parameters.AddWithValue("@titulo", titulo);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@perfil", perfil);
            return datos.ExecTransactionParameters(cmd);
        }

        public static bool editarPuesto(int idPuesto, string titulo, string descripcion, string perfil)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE PUESTOS SET TITULO = @titulo, DESCRIPCION = @descripcion, PERFIL = @perfil WHERE ID_PUESTO = @idPuesto";
            cmd.Parameters.AddWithValue("@titulo", titulo);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@perfil", perfil);
            cmd.Parameters.AddWithValue("@idPuesto", idPuesto);
            return datos.ExecTransactionParameters(cmd);
        }

        public static bool eliminarPuesto(int idPuesto)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE PUESTOS SET ID_ESTADO = 2 WHERE ID_PUESTO = @idPuesto";

            cmd.Parameters.AddWithValue("@idPuesto", idPuesto);
            return datos.ExecTransactionParameters(cmd);
        }
    }
}
