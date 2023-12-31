﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seminarioProyecto
{
    public partial class menuAdmin : Form
    {
        private Form formularioHijoActual;
        bool finalizarAplicacion = true;
        public menuAdmin()
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
        private void button1_MouseHover(object sender, EventArgs e)
        {
            efectoBotonHover(sender);            
        }
        
        private void efectoBotonHover(object boton)
        {
            Button btn = (Button)boton;
            btn.ForeColor = Color.DarkGray;
        }

        private void efectoBotonLeave(object boton)
        {
            Button btn = (Button)boton;
            btn.ForeColor = Color.Black;
        }

        private void btCrearConvo_MouseLeave(object sender, EventArgs e)
        {
            efectoBotonLeave(sender);
        }


        private void button3_MouseHover(object sender, EventArgs e)
        {
            efectoBotonHover(sender);
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            efectoBotonHover(sender);
        }


        private void button3_MouseLeave(object sender, EventArgs e)
        {
            efectoBotonLeave(sender);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            efectoBotonLeave(sender);
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            efectoBotonHover(sender);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            efectoBotonLeave(sender);
        }

        private void btCrearConvo_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new convocatorias());
            panel1.BringToFront();            
        }

        public void panelAlFondo()
        {
            panel1.SendToBack();
            //MessageBox.Show("hola");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new postulantes());
            panel1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new asignarPostulacion());
            panel1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new entrevista());
            panel1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new confPreguntas());
            panel1.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new res());
            panel1.BringToFront();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbHora.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new puestos());
            panel1.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new usuarios());
            panel1.BringToFront();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            finalizarAplicacion = false;
            this.Close();
            login login = new login();
            login.ShowDialog();
        }

        private void menuAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {            
            if (finalizarAplicacion)
            {
                Application.Exit();
            }
        }

        private void menuAdmin_Load(object sender, EventArgs e)
        {

        }


    }
}
