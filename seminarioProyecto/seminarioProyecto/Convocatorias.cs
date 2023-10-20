using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaNegocias;

namespace seminarioProyecto
{
    public partial class convocatorias : Form
    {
        private Form formularioHijoActual;
        string idConvo;
        public convocatorias()
        {
            InitializeComponent();
            cargarPuestos(cbPuestoAgregar);           
            cargarConvocatorias();
        }

        private void abrirFormularioHijo(Form formularioHijo)
        {
            if (formularioHijoActual != null)
            {
                //Abrir solo un formulario
                formularioHijoActual.Close();
            }
            formularioHijoActual = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            panel1.Controls.Add(formularioHijo);
            panel1.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is menuAdmin formularioPadre)
            {
                formularioPadre.panelAlFondo();
            }

            this.Close();            
        }

        private void btCrearConvo_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new historialConvocatorias());
            panel1.BringToFront();
        }

        public void panelAlFondo()
        {
            panel1.SendToBack();
            //MessageBox.Show("hola");

        }

        public void cargarPuestos(ComboBox cbPuesto)
        {
            DataTable dtz = new DataTable();
            dtz.Clear();
            dtz = capaNegocias.convocatorias.cargarPuestos();
            cbPuesto.DisplayMember = "TITULO";
            cbPuesto.ValueMember = "ID_PUESTO";
            cbPuesto.DataSource = dtz;
        }

        private void cargarConvocatorias()
        {
            DataTable dtConvo;
            dtConvo = capaNegocias.convocatorias.obtenerConvocatorias();
            dgvConvo.DataSource = dtConvo;
            dgvConvo.Columns[0].Visible = false;
            dgvConvo.Columns[1].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpFI1.Value;
            DateTime fechaFin = dtpFI2.Value;
            string obser = tbObser1.Text;
            int idPuesto = Convert.ToInt32(cbPuestoAgregar.SelectedValue);            

            if (capaNegocias.convocatorias.crearConovocatoria(fechaInicio, fechaFin, obser, idPuesto, sesion.id_usuario))
            {
                cargarConvocatorias();
                limpiarCampos();
                MessageBox.Show("Convocatoria creada exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Convocatoria no creada, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvConvo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btNuevo.Visible = true;
            btnGuardar.Visible = false;
            btnEditar.Visible = true;
            btnImprimir.Visible = true;
            btnEliminar.Visible = true;

            int RowNo;
            RowNo = e.RowIndex;
            dtpFI1.Value = Convert.ToDateTime(dgvConvo.Rows[RowNo].Cells[4].Value);
            dtpFI2.Value = Convert.ToDateTime(dgvConvo.Rows[RowNo].Cells[5].Value);
            cbPuestoAgregar.SelectedValue = Convert.ToInt32(dgvConvo.Rows[RowNo].Cells[1].Value);
            tbObser1.Text = dgvConvo.Rows[RowNo].Cells[6].Value.ToString();
            idConvo = dgvConvo.Rows[RowNo].Cells[0].Value.ToString();
            //txtTerritorioID.Text = dgTerritorios.Rows[RowNo].Cells[0].Value.ToString();
        }

        public void limpiarCampos()
        {

            btNuevo.Visible = false;
            btnGuardar.Visible = true;
            btnEditar.Visible = false;
            btnImprimir.Visible = false;
            btnEliminar.Visible = false;
            dtpFI1.Value = DateTime.Now;
            dtpFI2.Value = DateTime.Now;
            cbPuestoAgregar.SelectedIndex = 0;
            tbObser1.Clear();
            dgvConvo.ClearSelection();
            tbObser1.Focus();
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpFI1.Value;
            DateTime fechaFin = dtpFI2.Value;
            string obser = tbObser1.Text;
            int idPuesto = Convert.ToInt32(cbPuestoAgregar.SelectedValue);            

            if (capaNegocias.convocatorias.editarConvocatoria(fechaInicio, fechaFin, obser, idPuesto, idConvo))
            {
                cargarConvocatorias();
                limpiarCampos();
                MessageBox.Show("Convocatoria editado exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Convocatoria no editada, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Realmente quiere eliminar la convocatoria?", "Eliminar...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (capaNegocias.convocatorias.eliminarConvocatoria(idConvo))
                {
                    cargarConvocatorias();
                    limpiarCampos();
                    MessageBox.Show("Convocatoria eliminada exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Convocatoria no eliminada, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void convocatorias_Load(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataTable dtDatos;
            dtDatos = capaNegocias.convocatorias.cargarDatosAfiche(idConvo);
            afiche.datos encabezado = new afiche.datos();
            encabezado.ID_CONVOCATORIA = dtDatos.Rows[0][0].ToString();
            encabezado.INICIO = dtDatos.Rows[0][1].ToString();
            encabezado.FIN = dtDatos.Rows[0][2].ToString();
            encabezado.OBSERVACIONES = dtDatos.Rows[0][3].ToString();
            encabezado.ID_PUESTO = dtDatos.Rows[0][4].ToString();
            encabezado.TITULO = dtDatos.Rows[0][5].ToString();
            encabezado.DESCRIPCION = dtDatos.Rows[0][6].ToString();
            encabezado.PERFIL = dtDatos.Rows[0][7].ToString();
            //string a = "S";

            afiche.aficheFormulario aficheAbrir = new afiche.aficheFormulario();
            aficheAbrir.de.Add(encabezado);
            aficheAbrir.ShowDialog();
            dtDatos.Clear();
            dtDatos.Columns.Clear();

        }
    }
}
