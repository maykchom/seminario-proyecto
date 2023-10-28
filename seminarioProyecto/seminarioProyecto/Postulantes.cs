using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seminarioProyecto
{
    public partial class postulantes : Form
    {
        int idPostulante;

        //Datos servidor
        string rutaImg;
        string servidor = "ftp://localhost/cv/";
        string servidorVisita = "http://localhost/cv/";
        string usuario = "mikee";
        string pass = "holamundo";
        string rutaCV = null;
        public postulantes()
        {
            InitializeComponent();

            if (!capaNegocias.metodosComunes.verificarConexion())
            {
                MessageBox.Show("Se perdió la conexión con el servidor", "Sin conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cargarGeneros(cbGenero);
            cargarPostulantes();
        }

        private void guardarDocumentoFtp()
        {
            // Verificar si se ha seleccionado un archivo
            if (string.IsNullOrEmpty(rutaImg))
            {
                //MessageBox.Show("Por favor, seleccione un archivo antes de guardar.");
                return;
            }

            // Obtener el nombre del archivo sin la ruta completa
            string nombreArchivoConExt = Path.GetFileName(rutaImg);
            string nombreArchivoSinExt = Path.GetFileNameWithoutExtension(rutaImg);

            //Obtener la extension del archivo
            string extensionArchivo = Path.GetExtension(rutaImg);

            // Obtén la fecha y hora actual
            DateTime fechaHoraActual = DateTime.Now;

            // Formatea la fecha y hora en una cadena con el formato deseado
            string fechaHoraFormateada = fechaHoraActual.ToString("yyyyMMdd_HHmmss");

            // Ruta donde se guardarán los archivos en el servidor 
            string rutaServidor = servidor + nombreArchivoSinExt + "_" + fechaHoraFormateada + extensionArchivo;

            // Crear una solicitud FTP
            FtpWebRequest solicitudFTP = (FtpWebRequest)WebRequest.Create(rutaServidor);
            solicitudFTP.Method = WebRequestMethods.Ftp.UploadFile;
            solicitudFTP.Credentials = new NetworkCredential(usuario, pass);

            // Leer el archivo local
            using (FileStream fs = new FileStream(rutaImg, FileMode.Open, FileAccess.Read))
            using (Stream rs = solicitudFTP.GetRequestStream())
            {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    rs.Write(buffer, 0, bytesRead);
                }
            }

            //Mostrar la ruta guardada en el textbox
            string nombreGuardar = nombreArchivoSinExt + "_" + fechaHoraFormateada + extensionArchivo;
            string rutaGuardar = servidorVisita + nombreArchivoSinExt + "_" + fechaHoraFormateada + extensionArchivo;
            //tbRutaGuardada.Text = rutaGuardar;

            //Guardar en la BD
            rutaCV = rutaGuardar;
            //if (Capa_Negocios.guardarDocumentos.insertarDocumento(nombreGuardar, rutaGuardar))
            //{
            //    MessageBox.Show("Documento guardado en el servidor", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show("Ocurrió un error al guardar, intente de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void cargarPostulantes()
        {
            DataTable dtPostu;
            dtPostu = capaNegocias.postulantes.obtenerPostulantes();
            dgvPost.DataSource = dtPostu;
            dgvPost.Columns[0].Visible = false;
            dgvPost.Columns[7].Visible = false;
            dgvPost.Columns[8].Visible = false;
            dgvPost.Columns[9].Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is menuAdmin formularioPadre)
            {
                formularioPadre.panelAlFondo();
            }

            this.Close();
        }

        public void cargarGeneros(ComboBox cb)
        {
            DataTable dtz = new DataTable();
            dtz.Clear();
            dtz = capaNegocias.postulantes.obtenerGeneros();
            cb.DisplayMember = "GENERO";
            cb.ValueMember = "ID_GENERO";
            cb.DataSource = dtz;
        }

        private void dgvPost_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btNuevo.Visible = true;
            btnGuardar.Visible = false;
            btnEditar.Visible = true;            
            btnEliminar.Visible = true;

            int RowNo;
            RowNo = e.RowIndex;

            idPostulante = Convert.ToInt32(dgvPost.Rows[RowNo].Cells[0].Value);
            tbNombre.Text = dgvPost.Rows[RowNo].Cells[1].Value.ToString();
            tbApellidos.Text = dgvPost.Rows[RowNo].Cells[2].Value.ToString();
            dtFechaNac.Value = Convert.ToDateTime(dgvPost.Rows[RowNo].Cells[3].Value);
            tbDireccion.Text = dgvPost.Rows[RowNo].Cells[4].Value.ToString();
            tbTelefono.Text = dgvPost.Rows[RowNo].Cells[5].Value.ToString();
            tbCorreo.Text = dgvPost.Rows[RowNo].Cells[6].Value.ToString();
            cbGenero.SelectedValue = Convert.ToInt32(dgvPost.Rows[RowNo].Cells[7].Value);
            rutaCV = dgvPost.Rows[RowNo].Cells[9].Value.ToString();

            if (rutaCV == "")
            {
                lbCV.Visible = false;
            }
            else
            {
                lbCV.Visible = true;
            }
        }

        public void limpiarCampos()
        {
            btNuevo.Visible = false;
            btnGuardar.Visible = true;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;

            //cbGenero.SelectedIndex = 0;
            tbNombre.Clear();
            tbApellidos.Clear();
            dtFechaNac.Value = DateTime.Now;
            tbDireccion.Clear();
            tbTelefono.Clear();
            tbCorreo.Clear();
            dgvPost.ClearSelection();
            tbNombre.Focus();
            rutaCV = null;
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void postulantes_Load(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        public void crearPostulante()
        {
            DateTime fechaNacimiento = Convert.ToDateTime(dtFechaNac.Value);
            DateTime fechaMinima = new DateTime(1950, 01, 01, 0, 0, 0);
            DateTime fechaMaxima = DateTime.Now;


            if (fechaNacimiento.Date < fechaMinima.Date || fechaNacimiento.Date > fechaMaxima.Date)
            {
                MessageBox.Show("La fecha de nacimiento supera lo establecido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (capaNegocias.postulantes.crearPostulante(tbNombre.Text, tbApellidos.Text, fechaNacimiento, tbDireccion.Text, tbTelefono.Text, tbCorreo.Text, Convert.ToInt32(cbGenero.SelectedValue), rutaCV))
            {
                cargarPostulantes();
                limpiarCampos();
                MessageBox.Show("Postulante agreado exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Postulante no agregado, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!capaNegocias.metodosComunes.verificarConexion())
            {
                MessageBox.Show("Se perdió la conexión con el servidor", "Sin conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbNombre.Text) || string.IsNullOrWhiteSpace(tbApellidos.Text) || string.IsNullOrWhiteSpace(tbDireccion.Text) || string.IsNullOrWhiteSpace(tbCorreo.Text) || string.IsNullOrWhiteSpace(tbTelefono.Text))
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

            try
            {
                guardarDocumentoFtp();
                crearPostulante();
            }
            catch (Exception)
            {
                MessageBox.Show("Existe un error en los datos, favor de revisar ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        public void editarPostulante()
        {
            DateTime fechaNacimiento = Convert.ToDateTime(dtFechaNac.Value);
            DateTime fechaMinima = new DateTime(1950, 01, 01, 0, 0, 0);
            DateTime fechaMaxima = DateTime.Now;


            if (fechaNacimiento.Date < fechaMinima.Date || fechaNacimiento.Date > fechaMaxima.Date)
            {
                MessageBox.Show("La fecha de nacimiento supera lo establecido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (capaNegocias.postulantes.editarPostulante(tbNombre.Text, tbApellidos.Text, fechaNacimiento, tbDireccion.Text, tbTelefono.Text, tbCorreo.Text, Convert.ToInt32(cbGenero.SelectedValue), idPostulante, rutaCV))
            {
                cargarPostulantes();
                limpiarCampos();
                MessageBox.Show("Postulante editado exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Postulante no editado, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!capaNegocias.metodosComunes.verificarConexion())
            {
                MessageBox.Show("Se perdió la conexión con el servidor", "Sin conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbNombre.Text) || string.IsNullOrWhiteSpace(tbApellidos.Text) || string.IsNullOrWhiteSpace(tbDireccion.Text) || string.IsNullOrWhiteSpace(tbCorreo.Text) || string.IsNullOrWhiteSpace(tbTelefono.Text))
            {
                MessageBox.Show("No pueden quedar campos vacíos.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string patron = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)*(\.[a-zA-Z]{2,})$";
            if (!Regex.IsMatch(tbCorreo.Text, patron))
            {
                MessageBox.Show("El correo electrónico no es válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                guardarDocumentoFtp();
                editarPostulante();
            }
            catch (Exception)
            {

                MessageBox.Show("Existe un error en los datos, favor de revisar ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!capaNegocias.metodosComunes.verificarConexion())
            {
                MessageBox.Show("Se perdió la conexión con el servidor", "Sin conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("¿Realmente quiere eliminar al/la postulante?", "Eliminar...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {                
                if (capaNegocias.postulantes.eliminarPostulante(idPostulante))
                {
                    cargarPostulantes();
                    limpiarCampos();
                    MessageBox.Show("Postulante eliminado/a exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Postulante no eliminado/a, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ofd1.InitialDirectory = "C:\\Documentos";
            ofd1.Filter = "Archivos PDF|*.pdf";
            ofd1.FilterIndex = 1;
            ofd1.Multiselect = false;

            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                rutaImg = ofd1.FileName;
                //lbDocumento.Text = rutaImg;
                //btSubirDoc.Enabled = true;
                //lbDocumento.Visible = true;
                //btSubirDoc.Focus();
            }
        }

        private void lbCV_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(rutaCV);
        }

        private void tbTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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
    }
}
