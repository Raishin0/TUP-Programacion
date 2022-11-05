using Microsoft.Reporting.WinForms;
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

namespace NetFramework
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

            DtmFechaInicio.Value = DateTime.Parse("1/1/2000");
        }

        private async void BtnGenerar_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            string url = urlApi + string.Format("reporte?inicio={0}&final={1}",
                DtmFechaInicio.Value, DtmFechaFinal.Value);
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(data);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataTable));
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("prFechaDesde", DtmFechaInicio.Value.ToString()),
            new ReportParameter("prFechaHasta",DtmFechaFinal.Value.ToString())});
            reportViewer1.RefreshReport();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DtmFechaInicio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DtmFechaFinal_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
