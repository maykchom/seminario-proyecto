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
    public class usuarios
    {

        public static DataTable obtenerUsuarios()
        {
            string cadena = "SELECT * FROM USUARIOS WHERE ID_ESTADO = 1;";
            return datos.GetDataTable(cadena);
        }

        public static DataTable obtenerGeneros()
        {
            string cadena = "SELECT * FROM GENEROS";
            return datos.GetDataTable(cadena);
        }

        public static DataTable obtenerRoles()
        {
            string cadena = "SELECT * FROM ROLES";
            return datos.GetDataTable(cadena);
        }

        public static bool crearUsuario(string idUsuario, string nombres, string apellidos, string telefono, string direccion, string correo, DateTime fechaNacimiento, string contra, int idGenero, int idRol)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO USUARIOS (ID_USUARIO, NOMBRES, APELLIDOS, TELEFONO, DIRECCION, CORREO, FECHA_NACIMIENTO, PASSWORD, ID_GENERO, ID_ROL, ID_ESTADO) " +
                "VALUES (@idUsuario, @nombres, @apellidos, @telefono, @direccion, @correo, @fechaNacimiento, @contra, @idGenero, @idRol, 1);";
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            cmd.Parameters.AddWithValue("@nombres", nombres);
            cmd.Parameters.AddWithValue("@apellidos", apellidos);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@direccion", direccion);
            cmd.Parameters.AddWithValue("@correo", correo);
            cmd.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
            cmd.Parameters.AddWithValue("@contra", contra);
            cmd.Parameters.AddWithValue("@idGenero", idGenero);
            cmd.Parameters.AddWithValue("@idRol", idRol);
            return datos.ExecTransactionParameters(cmd);
        }

        public static bool editarUsuario(string idUsuario, string nombres, string apellidos, string telefono, string direccion, string correo, DateTime fechaNacimiento, string contra, int idGenero, int idRol)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE USUARIOS SET NOMBRES = @nombres, APELLIDOS = @apellidos, TELEFONO = @telefono, DIRECCION = @direccion, CORREO = @correo, FECHA_NACIMIENTO = @fechaNacimiento, PASSWORD = @contra, ID_GENERO = @idGenero, ID_ROL = @idRol, ID_ESTADO = 1 WHERE ID_USUARIO = @idUsuario";                
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
            cmd.Parameters.AddWithValue("@nombres", nombres);
            cmd.Parameters.AddWithValue("@apellidos", apellidos);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@direccion", direccion);
            cmd.Parameters.AddWithValue("@correo", correo);
            cmd.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
            cmd.Parameters.AddWithValue("@contra", contra);
            cmd.Parameters.AddWithValue("@idGenero", idGenero);
            cmd.Parameters.AddWithValue("@idRol", idRol);
            return datos.ExecTransactionParameters(cmd);
        }

        public static bool eliminarUsuario(string idUsuario)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE USUARIOS SET ID_ESTADO = 2 WHERE ID_USUARIO = @idUsuario";
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

            return datos.ExecTransactionParameters(cmd);
        }

    }
}
