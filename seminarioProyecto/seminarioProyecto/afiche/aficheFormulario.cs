using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seminarioProyecto.afiche
{
    public partial class aficheFormulario : Form
    {
        public List<datos> de = new List<datos>();
        public aficheFormulario()
        {
            InitializeComponent();
        }

        private void aficheFormulario_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rp2 = new ReportDataSource("DataSet1", de);
            reportViewer1.LocalReport.DataSources.Add(rp2);
            reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
