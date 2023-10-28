using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaDatos
{
    public class datos
    {
        /// Cadena de conexión
        /// </summary>
        public static string cadenaconexion = "SERVER=localhost;DATABASE=db_sp;uid=sistema; user=root; password=";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        /// 

        public static bool VerificarConexion()
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaconexion))
                {
                    conexion.Open(); // Intenta abrir la conexión
                    return true; // La conexión se estableció exitosamente
                }
            }
            catch (MySqlException)
            {
                return false; // Hubo un error al intentar conectar
            }
        }

        public static DataTable GetDataTable(string strSql)
        {
            //try
            //{

                using (MySqlConnection cn = new MySqlConnection(cadenaconexion))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(strSql, cn))
                    {
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(dr);
                            return dt;
                        }

                    }
                }
            //}
            //catch (Exception)
            //{

            //    //DataTable dt = new DataTable();
            //    //return dt;
            //    throw;
            //}
        }
        //insert, update, delete

        public static bool ExecTransaction(string strSQL)
        {
            bool resultado = false;
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cadenaconexion))
                {
                    cn.Open();
                    using (MySqlTransaction trx = cn.BeginTransaction())
                    {
                        try
                        {
                            using (MySqlCommand cmd = new MySqlCommand(strSQL, cn))
                            {
                                cmd.Transaction = trx;
                                cmd.ExecuteNonQuery();
                            }
                            trx.Commit();
                            resultado = true;
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            resultado = false;
                            throw;
                        }
                    }
                }

            }
            catch (Exception)
            {

            }
            return resultado;
        }

        //ejecuta transacciones con parámetros establecidos para insertar, eliminar y actualizar
        public static bool ExecTransactionParameters(MySqlCommand comando)
        {
            bool resultado = false;
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cadenaconexion))
                {
                    cn.Open();
                    using (MySqlTransaction trx = cn.BeginTransaction())
                    {
                        try
                        {
                            using (comando)
                            {
                                comando.Connection = cn;
                                comando.Transaction = trx;
                                comando.ExecuteNonQuery();
                            }
                            trx.Commit();
                            resultado = true;
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            resultado = false;
                            //"throw" se debe comentar en produccion porque sirve para ejecuar el codigo a pesar de que exista error
                            throw;
                        }
                    }
                }

            }
            catch (Exception)
            {
                //"throw" se debe comentar en produccion porque sirve para ejecuar el codigo a pesar de que exista error
                throw;
            }
            return resultado;
        }
    }
}
