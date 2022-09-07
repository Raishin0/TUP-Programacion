using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacturacionABMC.Datos;
using Microsoft.Reporting.WinForms;

namespace FacturacionABMC.Presentacion
{
    public partial class FrmConsultarVentasArticulos : Form
    {
        HelperDB gestor = new HelperDB();
        public FrmConsultarVentasArticulos()
        {
            InitializeComponent();
        }

        private void FrmConsultarVentasArticulos_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            string strSql = "SP_CONSULTAR_VENTAS_ARTICULOS";
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@fecha_1", DtpFechaInicial.Value));
            parametros.Add(new Parametro("@fecha_2", DtpFechaFinal.Value));

            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { new
ReportParameter("prFechaDesde", DtpFechaInicial.Text), new ReportParameter("prFechaHasta",
DtpFechaFinal.Text) });
            //DATASOURCE
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new
               ReportDataSource("DSArticulos", gestor.ConsultaSQL(strSql, parametros)));
            reportViewer1.RefreshReport();

        }
    }
}
