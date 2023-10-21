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

namespace seminarioProyecto.informe
{
    public partial class informeFormulario : Form
    {
        public List<datos> de = new List<datos>();
        DataTable Datos = new DataTable();
        public informeFormulario(DataTable datos)
        {
            InitializeComponent();
            Datos = datos;
        }

        private void informeFormulario_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("DataSet1", de);
            ReportDataSource rp2 = new ReportDataSource("DataSet2", Datos);
            reportViewer1.LocalReport.DataSources.Add(rp);
            reportViewer1.LocalReport.DataSources.Add(rp2);
            reportViewer1.RefreshReport();

            this.reportViewer1.RefreshReport();
        }
    }
}
