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
    public partial class login : Form
    {
        public static DataTable datosSesion = new DataTable();
        public login()
        {
            InitializeComponent();
        }
        private void iniciarSesion()
        {
            datosSesion.Clear();
            datosSesion = sesion.iniciarSesion(tbUser.Text, tbPass.Text);
            int value = datosSesion.Rows.Count;

            if (value == 1)
            {

                if (Convert.ToInt32(datosSesion.Rows[0][10]) == 1)
                {
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
                    sesion.id_usuario = datosSesion.Rows[0][0].ToString();
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
            iniciarSesion();
        }
    }
}
