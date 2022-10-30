using DataApi.dominio;
using FrontFacturacion.servicios.interfaz;
using FrontFacturacion.servicios;
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

namespace FrontFacturacion.formularios
{
    public partial class FrmDetallesFactura : Form
    {
        string urlApi = "http://localhost:5023/";
        int nroFactura;
        Factura factura;
        IServicio servicio;
        public FrmDetallesFactura(int nroFactura, FabricaServicio fabrica)
        {
            this.nroFactura = nroFactura;
            servicio = fabrica.CrearServicio();
            InitializeComponent();
        }

        private async void FrmDetallesFactura_LoadAsync(object sender, EventArgs e)
        {
            await CargarComboAsync();
            CargarFactura();
        }
    


        private async Task CargarComboAsync()
        {
            string url = urlApi + "formasDePago";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            Dictionary<int, string> lst = JsonConvert.DeserializeObject<Dictionary<int, string>>(data);
            CbxFormaPago.DataSource = new BindingSource(lst, null);
            CbxFormaPago.DisplayMember = "Value";
            CbxFormaPago.ValueMember = "Key";
            CbxFormaPago.SelectedIndex = -1;
        }


        private void CargarFactura()
        {
            factura = servicio.ObtenerFacturaPorNro(nroFactura);
            TbxCliente.Text = factura.Cliente;
            CbxFormaPago.SelectedValue = factura.FormaPago;
            DtpFecha.Value = factura.Fecha;

            foreach (Detalle detalle in factura.Detalles)
            {
                DgvDetalles.Rows.Add(new object[] { detalle.Articulo.Descripcion, detalle.Cantidad, detalle.Articulo.Precio });
            }
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            double total = factura.CalcularTotal();
            TbxTotal.Text = total.ToString();
        }
       

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
