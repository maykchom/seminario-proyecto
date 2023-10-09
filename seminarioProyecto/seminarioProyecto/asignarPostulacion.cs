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
    public partial class asignarPostulacion : Form
    {
        bool convoVacias, postuVacios = false;
        int idPostulacion;
        public asignarPostulacion()
        {
            InitializeComponent();
            cargarPuestos(cbPuestos);
            cargarPuestos(cbPuestosAE);
            cargarPostulantes(cbPostulanteAE);
        }

        private void cargarPostulantes()
        {
            DataTable dtPostu;
            dtPostu = capaNegocias.postulaciones.obtenerPostulaciones(Convert.ToInt32(cbPuestos.SelectedValue));
            //MessageBox.Show(cbPuestos.SelectedValue.ToString());
            string g = "s";
            dgvPost.DataSource = dtPostu;
            dgvPost.Columns[0].Visible = false;
            dgvPost.Columns[2].Visible = false;
            dgvPost.Columns[3].Visible = false;
            dgvPost.Columns[4].Visible = false;
            dgvPost.Columns[5].Visible = false;
            dgvPost.Columns[6].Visible = false;
            dgvPost.Columns[7].Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is menuAdmin formularioPadre)
            {
                formularioPadre.panelAlFondo();
            }

            this.Close();
        }

        public bool existePostulante()
        {
            string consulta = "SELECT * FROM postulaciones WHERE ID_CONVOCATORIA = "+Convert.ToInt32(cbConvocatoriaAE.SelectedValue)+" AND ID_POSTULANTE = "+Convert.ToInt32(cbPostulanteAE.SelectedValue)+" AND ID_ESTADO = 1";
            DataTable resultado = metodosComunes.consultaAbiertaSinParametros(consulta);
            if (resultado.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void cargarPuestos(ComboBox cb)
        {
            DataTable dtz = new DataTable();
            dtz.Clear();
            dtz = capaNegocias.postulaciones.obtenerPuestos();
            cb.DisplayMember = "TITULO";
            cb.ValueMember = "ID_PUESTO";
            cb.DataSource = dtz;
        }

        public void cargarConvocatorias(ComboBox cb)
        {
            DataTable dtz = new DataTable();
            dtz.Clear();
            dtz = capaNegocias.postulaciones.obtenerConvocatorias(Convert.ToInt32(cbPuestosAE.SelectedValue));
            cb.DisplayMember = "CONVOCATORIA";
            cb.ValueMember = "ID_CONVOCATORIA";
            cb.DataSource = dtz;
        }

        public void cargarPostulantes(ComboBox cb)
        {
            DataTable dtz = new DataTable();
            dtz.Clear();
            dtz = capaNegocias.postulaciones.obtenerPostulantes();
            cb.DisplayMember = "POSTULANTE";
            cb.ValueMember = "ID_POSTULANTE";
            cb.DataSource = dtz;
        }

        private void cbPuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarPostulantes();
            btnGuardar.Visible = true;
            btnEliminar.Visible = false;
            btNuevo.Visible = false;
            dgvPost.ClearSelection();
        }

        public void combosVacios()
        {
            if ((cbConvocatoriaAE.Items.Count == 0) || (cbPostulanteAE.Items.Count == 0))
            {
                
            }
        }

        public void convocatoriasVacias()
        {
            if (cbConvocatoriaAE.Items.Count == 0)
            {
                btnGuardar.Visible = false;
                cbConvocatoriaAE.Enabled = false;
            }
            else
            {
                btnGuardar.Visible = true;
                cbConvocatoriaAE.Enabled = true;
            }
        }

        public void postulantesVacios()
        {
            if (cbPostulanteAE.Items.Count == 0)
            {
                btnGuardar.Visible = false;
                cbPostulanteAE.Enabled = false;
            }
            else
            {
                btnGuardar.Visible = true;
                cbPostulanteAE.Enabled = true;
            }
        }
        private void cbPuestosAE_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarConvocatorias(cbConvocatoriaAE);
            if (cbConvocatoriaAE.Items.Count == 0)
            {
                cbConvocatoriaAE.Enabled = false;
                cbConvocatoriaAE.DataSource = null;
                cbConvocatoriaAE.Items.Add("No existen convocatorias");
                cbConvocatoriaAE.SelectedIndex = 0;
                convoVacias = true;
            }
            else
            {
                cbConvocatoriaAE.Enabled = true;
                convoVacias = false;
            }
        }

        public void crearPostulacion()
        {
            if (postulaciones.crearPostulacion(Convert.ToInt32(cbConvocatoriaAE.SelectedValue), Convert.ToInt32(cbPostulanteAE.SelectedValue), sesion.id_usuario))
            {
                cargarPostulantes();                
                MessageBox.Show("Postulación agreada exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Postulación no agregada, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (convoVacias || postuVacios)
            {
                MessageBox.Show("No existe convocatorias o pustulantes", "Revise...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (existePostulante())
            {
                MessageBox.Show("El postulante ya existe en esa convocatoria", "Revise...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            crearPostulacion();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Realmente quiere eliminar la postulación?", "Eliminar...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (capaNegocias.postulaciones.eliminarPostulacion(idPostulacion))
                {
                    cargarPostulantes();
                    limpiarCampos();
                    MessageBox.Show("Postulación eliminada exitosamente", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Postulación no eliminada, intente de nuevo ", "Algo sucedió", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void limpiarCampos()
        {
            btNuevo.Visible = false;
            btnGuardar.Visible = true;
            btnEliminar.Visible = false;

            dgvPost.ClearSelection();
            cbPuestosAE.SelectedIndex = 0;
            cbConvocatoriaAE.SelectedIndex = 0;
            cbPostulanteAE.SelectedIndex = 0;
        }

        private void dgvPost_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btNuevo.Visible = true;
            btnGuardar.Visible = false;
            btnEliminar.Visible = true;

            int RowNo;
            RowNo = e.RowIndex;

            idPostulacion = Convert.ToInt32(dgvPost.Rows[RowNo].Cells[0].Value);            
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void asignarPostulacion_Load(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void cbPostulanteAE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPostulanteAE.Items.Count == 0)
            {
                cbPostulanteAE.Enabled = false;
                cbPostulanteAE.DataSource = null;
                cbPostulanteAE.Items.Add("No existen postulantes");
                cbPostulanteAE.SelectedIndex = 0;
                postuVacios = true;
            }
            else
            {
                cbPostulanteAE.Enabled = true;
                postuVacios = false;
            }
        }
    }
}
