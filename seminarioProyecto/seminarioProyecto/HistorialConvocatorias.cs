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
    public partial class historialConvocatorias : Form
    {

        public historialConvocatorias()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is convocatorias formularioPadre)
            {
                formularioPadre.panelAlFondo();
            }

            this.Close();
        }
    }
}
