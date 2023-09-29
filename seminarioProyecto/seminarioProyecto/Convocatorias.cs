using System;
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
    public partial class Convocatorias : Form
    {
        public Convocatorias()
        {
            InitializeComponent();
        }        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is Form1 formularioPadre)
            {
                formularioPadre.panelAlFondo();
            }

            this.Close();            
        }

        private void btCrearConvo_Click(object sender, EventArgs e)
        {
            HistorialConvocatorias hc = new HistorialConvocatorias();
            hc.ShowDialog();
            //this.Hide();
        }
    }
}
