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
    public class sesion
    {
        public static string id_usuario;      
        public static DataTable iniciarSesion(string user, string pass)
        {
            string strSQL = "SELECT * FROM USUARIOS WHERE ID_USUARIO = '"+user+"' AND PASSWORD = '"+pass+"';";            
            return datos.GetDataTable(strSQL);
        }
    }
}
