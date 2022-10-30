using DataApi.dominio;
using FrontFacturacion.servicios;
using FrontFacturacion.servicios.implementacion;
using FrontFacturacion.servicios.interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontFacturacion.formularios
{
    public partial class FrmReporteVentas : Form
    {

        IServicio servicio;
        public FrmReporteVentas(FabricaServicio fabrica)
        {
            servicio = fabrica.CrearServicio();
            InitializeComponent();
        }

        void CargarFacturas()
        {
            DataTable lst = servicio.ObtenerReporte(DtpPrimeraFecha.Value, DtpUltimaFecha.Value);
            DgvFacturas.Rows.Clear();
            foreach (DataRow fila in lst.Rows)
            {
                DgvFacturas.Rows.Add(new object[] { fila[0], fila[1], fila[2], fila[3], fila[4], fila[5] });
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            CargarFacturas();
        }
    }
}
