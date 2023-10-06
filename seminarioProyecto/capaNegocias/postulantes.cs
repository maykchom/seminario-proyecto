using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using MySql.Data.MySqlClient;

namespace capaNegocias
{
    public class postulantes
    {
        public static DataTable obtenerGeneros()
        {
            string cadena = "SELECT * FROM GENEROS;";
            return datos.GetDataTable(cadena);
        }
        public static DataTable obtenerPostulantes()
        {
            string strSQL = "SELECT POS.*, GEN.GENERO " +
                "FROM postulantes AS POS " +
                "INNER JOIN generos AS GEN ON POS.ID_GENERO = GEN.ID_GENERO " +
                "WHERE POS.ID_ESTADO = 1 " +
                "ORDER BY POS.ID_POSTULANTE;";
            return datos.GetDataTable(strSQL);
        }

        public static bool crearPostulante(string nombre, string apellidos, DateTime fechaNacimiento, string direccion, string telefono, string correo, int idGenero)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO POSTULANTES (NOMBRES, APELLIDOS, FECHA_NACIMIENTO, DIRECCION, TELEFONO, CORREO, ID_GENERO, ID_ESTADO) " +
                "VALUES(@nombre, @apellidos, @fechaNac, @direccion, @telefono, @correo, @idGenero, 1);";
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellidos", apellidos);
            cmd.Parameters.AddWithValue("@fechaNac", fechaNacimiento);
            cmd.Parameters.AddWithValue("@direccion", direccion);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@correo", correo);
            cmd.Parameters.AddWithValue("@idGenero", idGenero);
            return datos.ExecTransactionParameters(cmd);
        }

        public static bool editarPostulante(string nombre, string apellidos, DateTime fechaNacimiento, string direccion, string telefono, string correo, int idGenero, int idPostu)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE POSTULANTES " +
                "SET NOMBRES = @nombre, APELLIDOS = @apellidos, FECHA_NACIMIENTO = @fechaNac, " +
                "DIRECCION = @direccion, TELEFONO = @telefono, CORREO = @correo, " +
                "ID_GENERO = @idGenero WHERE ID_POSTULANTE = @idPostu;";
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellidos", apellidos);
            cmd.Parameters.AddWithValue("@fechaNac", fechaNacimiento);
            cmd.Parameters.AddWithValue("@direccion", direccion);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@correo", correo);
            cmd.Parameters.AddWithValue("@idGenero", idGenero);
            cmd.Parameters.AddWithValue("@idPostu", idPostu);
            return datos.ExecTransactionParameters(cmd);
        }

        public static bool eliminarPostulante(int idPostulante)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE POSTULANTES SET ID_ESTADO= 2 WHERE ID_POSTULANTE = @idPostulante;";
            cmd.Parameters.AddWithValue("@idPostulante", idPostulante);
            return datos.ExecTransactionParameters(cmd);
        }
    }
}
