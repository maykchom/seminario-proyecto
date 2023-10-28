using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaNegocias;

namespace seminarioProyecto
{
    public partial class login : Form
    {
        public static DataTable datosSesion = new DataTable();
        static readonly string password = "P455W0rd";
        public login()
        {
            InitializeComponent();
        }
        private static byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        public static string cifrar(string texto)
        {
            if (texto == null)
            {
                return null;
            }
            // Get the bytes of the string
            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(texto);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA512.Create().ComputeHash(passwordBytes);

            var bytesEncrypted = Encrypt(bytesToBeEncrypted, passwordBytes);

            return Convert.ToBase64String(bytesEncrypted);
        }

        private void iniciarSesion()
        {

            if (!capaNegocias.metodosComunes.verificarConexion())
            {
                MessageBox.Show("No hay conexión con el servidor", "Sin conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            datosSesion.Clear();
            datosSesion = sesion.iniciarSesion(tbUser.Text, cifrar(tbPass.Text));
            int value = datosSesion.Rows.Count;

            if (value == 1)
            {

                if (Convert.ToInt32(datosSesion.Rows[0][10]) == 1)
                {
                    sesion.id_usuario = datosSesion.Rows[0][0].ToString();
                    sesion.id_rol = (int)datosSesion.Rows[0][9];
                    //MessageBox.Show("Bienvenido/a " + sesion.Rows[0][1].ToString(), "Iniciando sesión como gerente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Convert.ToInt32(datosSesion.Rows[0][9]) == 1)
                    {
                        this.Hide();
                        menuAdmin abrir = new menuAdmin();
                        abrir.Show();

                    }
                    else
                    {
                        this.Hide();
                        menuSecre abrir = new menuSecre();
                        abrir.Show();
                    }
                    //sesion.id_usuario = datosSesion.Rows[0][0].ToString();
                }
                else
                {
                    MessageBox.Show("El usuario " + datosSesion.Rows[0][0].ToString() + " ha sido dado de baja", "No disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Las credenciales son erróneas", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUser.Text) || string.IsNullOrWhiteSpace(tbPass.Text) )
            {
                MessageBox.Show("No pueden quedar campos vacíos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            iniciarSesion();
        }
    }
}
