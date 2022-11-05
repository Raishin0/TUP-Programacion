using NetFrameworkFront.servicios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace NetFrameworkFront
{
    public partial class FrmReporteVentas : Form
    {
        string urlApi = "http://localhost:5023/";
        public FrmReporteVentas()
        {
            InitializeComponent();
        }

        private void FrmReporteVentas_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private async void BtnGenerar_Click(object sender, EventArgs e)
        {
            string url = urlApi + string.Format("reporte?inicio={0}&final={1}",
                DtpFechaInicio.Value, DtpFechaFinal.Value);
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(data);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataTable));
            reportViewer1.RefreshReport();
        }
    }
}
