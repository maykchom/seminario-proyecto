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
    public partial class menuSecre : Form
    {
        private Form formularioHijoActual;
        public menuSecre()
        {
            InitializeComponent();
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
            //lbTituloFormularioHijo.Text = formularioHijo.Text;
            //lbTituloFormularioHijo.Text = botonActual.Text;
        }

        private void menuSecre_Load(object sender, EventArgs e)
        {
            int i = sesion.id_rol;
        }

        public void panelAlFondo()
        {
            panel1.SendToBack();
            //MessageBox.Show("hola");

        }

        private void btCrearConvo_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new convocatorias());
            panel1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new postulantes());
            panel1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new asignarPostulacion());
            panel1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new res());
            panel1.BringToFront();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            login login = new login();
            login.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbHora.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void menuSecre_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
