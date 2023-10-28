using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seminarioProyecto
{
    public partial class usuarios : Form
    {
        string idUsuario, contrasenia;
        static readonly string password = "P455W0rd";
        public usuarios()
        {
            InitializeComponent();

            if (!capaNegocias.metodosComunes.verificarConexion())
            {
                MessageBox.Show("Se perdió la conexión con el servidor", "Sin conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cargarUsuarios();
            cargarGeneros();
            cargarRoles();
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

        //Funcion necesaria No.2
        private static byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;
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

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }

                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        //Funcion necesaria No.3
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

        //Funcion necesaria No.4
        public static string descifrar(string textoCifrado)
        {
            if (textoCifrado == null)
            {
                return null;
            }
            // Get the bytes of the string
            var bytesToBeDecrypted = Convert.FromBase64String(textoCifrado);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            passwordBytes = SHA512.Create().ComputeHash(passwordBytes);

            var bytesDecrypted = Decrypt(bytesToBeDecrypted, passwordBytes);

            return Encoding.UTF8.GetString(bytesDecrypted);
        }

        public void cargarUsuarios()
        {
            DataTable dtPreguntas;
            dtPreguntas = capaNegocias.usuarios.obtenerUsuarios();
            dgvUsuarios.DataSource = dtPreguntas;
            dgvUsuarios.Columns[7].Visible = false;
            dgvUsuarios.Columns[8].Visible = false;
            dgvUsuarios.Columns[9].Visible = false;
            dgvUsuarios.Columns[10].Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is menuAdmin formularioPadre)
            {
                formularioPadre.panelAlFondo();
            }

            this.Close();
        }

        public void cargarGeneros()
        {
            DataTable dtz = new DataTable();
            dtz.Clear();
            dtz = capaNegocias.usuarios.obtenerGeneros();
            cbGenero.DisplayMember = "GENERO";
            cbGenero.ValueMember = "ID_GENERO";
            cbGenero.DataSource = dtz;
        }

        public void cargarRoles()
        {
            DataTable dtz = new DataTable();
            dtz.Clear();
            dtz = capaNegocias.usuarios.obtenerRoles();
            cbRol.DisplayMember = "ROL";
            cbRol.ValueMember = "ID_ROL";
            cbRol.DataSource = dtz;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarControles();
        }

        private void usuarios_Load(object sender, EventArgs e)
        {
            limpiarControles();
        }

        private void dgvUsuarios_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int RowNo;
            RowNo = e.RowIndex;

            idUsuario = dgvUsuarios.Rows[RowNo].Cells[0].Value.ToString();
            tbNombre.Text = dgvUsuarios.Rows[RowNo].Cells[1].Value.ToString();
            tbApellidos.Text = dgvUsuarios.Rows[RowNo].Cells[2].Value.ToString();
            tbTelefono.Text = dgvUsuarios.Rows[RowNo].Cells[3].Value.ToString();
            tbDireccion.Text = dgvUsuarios.Rows[RowNo].Cells[4].Value.ToString();
            tbCorreo.Text = dgvUsuarios.Rows[RowNo].Cells[5].Value.ToString();
            dtpFechaNaci.Value = Convert.ToDateTime(dgvUsuarios.Rows[RowNo].Cells[6].Value);
            contrasenia = dgvUsuarios.Rows[RowNo].Cells[7].Value.ToString();
            tbUsuario.Text = idUsuario;
            tbContrasenia.Text = descifrar(dgvUsuarios.Rows[RowNo].Cells[7].Value.ToString());
            cbGenero.SelectedValue = (int)dgvUsuarios.Rows[RowNo].Cells[8].Value;
            cbRol.SelectedValue = (int)dgvUsuarios.Rows[RowNo].Cells[9].Value;

            btnGuardar.Visible = false;
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
            btnNuevo.Visible = true;

            tbUsuario.ReadOnly = true;
            tbUsuario.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!capaNegocias.metodosComunes.verificarConexion())
            {
                MessageBox.Show("Se perdió la conexión con el servidor", "Sin conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbNombre.Text) || string.IsNullOrWhiteSpace(tbApellidos.Text) || string.IsNullOrWhiteSpace(tbDireccion.Text) || string.IsNullOrWhiteSpace(tbCorreo.Text) || string.IsNullOrWhiteSpace(tbTelefono.Text) || string.IsNullOrWhiteSpace(tbContrasenia.Text))
            {
                MessageBox.Show("No pueden quedar campos vacíos.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string patron = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)*(\.[a-zA-Z]{2,})$";
            if (!Regex.IsMatch(tbCorreo.Text, patron))
            {
                MessageBox.Show("El correo electrónico no es válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool modificacionExitosa = capaNegocias.usuarios.editarUsuario(tbUsuario.Text, tbNombre.Text, tbApellidos.Text, tbTelefono.Text, tbDireccion.Text, tbCorreo.Text, (DateTime)dtpFechaNaci.Value,cifrar(tbContrasenia.Text), (int)cbGenero.SelectedValue, (int)cbRol.SelectedValue);
            if (modificacionExitosa)
            {
                MessageBox.Show("Puesto editado exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarUsuarios();
                limpiarControles();
            }
            else
            {
                MessageBox.Show("No se pudo editar el puesto, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!capaNegocias.metodosComunes.verificarConexion())
            {
                MessageBox.Show("Se perdió la conexión con el servidor", "Sin conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbNombre.Text) || string.IsNullOrWhiteSpace(tbApellidos.Text) || string.IsNullOrWhiteSpace(tbDireccion.Text) || string.IsNullOrWhiteSpace(tbCorreo.Text) || string.IsNullOrWhiteSpace(tbTelefono.Text) || string.IsNullOrWhiteSpace(tbContrasenia.Text) || string.IsNullOrWhiteSpace(tbUsuario.Text))
            {
                MessageBox.Show("No pueden quedar campos vacíos.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string patron = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)*(\.[a-zA-Z]{2,})$";
            if (!Regex.IsMatch(tbCorreo.Text, patron))
            {
                MessageBox.Show("El correo electrónico no es válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool insercionExitosa = capaNegocias.usuarios.crearUsuario(tbUsuario.Text, tbNombre.Text, tbApellidos.Text, tbTelefono.Text, tbDireccion.Text, tbCorreo.Text, (DateTime)dtpFechaNaci.Value, cifrar(tbContrasenia.Text), (int)cbGenero.SelectedValue, (int)cbRol.SelectedValue);
            if (insercionExitosa)
            {
                MessageBox.Show("Usuario agregado exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarUsuarios();
                limpiarControles();
            }
            else
            {
                MessageBox.Show("No se pudo agregar el usuario, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!capaNegocias.metodosComunes.verificarConexion())
            {
                MessageBox.Show("Se perdió la conexión con el servidor", "Sin conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("¿Realmente quiere eliminar al usuario?", "Eliminar...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (capaNegocias.usuarios.eliminarUsuario(idUsuario))
                {
                    MessageBox.Show("Puesto eliminado exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarUsuarios();
                    limpiarControles();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el usuario, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Evita que se ingresen caracteres que no son letras
            }
        }

        private void tbApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Evita que se ingresen caracteres que no son letras
            }
        }

        private void tbTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void limpiarControles()
        {
            tbNombre.Clear();
            tbApellidos.Clear();
            tbTelefono.Clear();
            tbDireccion.Clear();
            tbCorreo.Clear();
            dtpFechaNaci.Value = DateTime.Now;          
            tbUsuario.Clear();
            tbContrasenia.Clear();
            //cbGenero.SelectedIndex = 0;
            cbRol.SelectedIndex = 0;

            btnGuardar.Visible = true;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnNuevo.Visible = false;

            tbNombre.Focus();

            dgvUsuarios.ClearSelection();

            tbUsuario.ReadOnly = false;
            tbUsuario.Enabled = true;
        }
    }
}
