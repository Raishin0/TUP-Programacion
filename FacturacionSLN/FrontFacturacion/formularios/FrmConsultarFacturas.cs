using DataApi.dominio;
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
    public partial class FrmConsultarFacturas : Form
    {
        string urlApi = "http://localhost:5023/";
        public FrmConsultarFacturas()
        {
            InitializeComponent();
        }

        private async Task CargarFacturasAsync()
        {
            string url = urlApi + string.Format("facturas?inicio={0}&final={1}&cliente={2}", 
                DtpPrimeraFecha.Value, DtpUltimaFecha.Value,TbxCliente.Text);
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Factura> lst = JsonConvert.DeserializeObject<List<Factura>>(data);
            DgvFacturas.Rows.Clear();
            foreach(Factura fila in lst)
            {
                DgvFacturas.Rows.Add(new object[] { fila.Codigo, fila.Fecha, fila.FormaPago, fila.Cliente});
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvFacturas.CurrentCell.ColumnIndex == 5)
            {
                QuitarFacturaAsync((int)DgvFacturas.CurrentRow.Cells[0].Value);
            }

            if (DgvFacturas.CurrentCell.ColumnIndex == 6)
            {
                ModificarFactura((int)DgvFacturas.CurrentRow.Cells[0].Value,
                    (DateTime)DgvFacturas.CurrentRow.Cells[1].Value, 
                    (int)DgvFacturas.CurrentRow.Cells[2].Value,
                    (string)DgvFacturas.CurrentRow.Cells[3].Value);
            }
            if (DgvFacturas.CurrentCell.ColumnIndex == 7)
            {
                VerFactura((int)DgvFacturas.CurrentRow.Cells[0].Value);
            }
        }

        private void ModificarFactura(int nro, DateTime fecha, int formaPago, string cliente)
        {
            Factura factura = new Factura(nro, fecha, formaPago, cliente);
            FrmModificarFactura frmModificarFactura = new FrmModificarFactura(factura);
            frmModificarFactura.Show();
        }

        private async Task QuitarFacturaAsync(int nroFactura)
        {
            if (MessageBox.Show($"Seguro que quiere quitar la factura Nº{nroFactura}?",
                "Borrar",MessageBoxButtons.YesNo,MessageBoxIcon.Information) 
                == DialogResult.Yes)
            {
                if(await BorrarFacturaAsync(nroFactura))

                {
                    MessageBox.Show("Factura eliminada", "Informe",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DgvFacturas.Rows.Remove(DgvFacturas.CurrentRow);
                }
                else
                {
                    MessageBox.Show("ERROR. No se pudo eliminar la factura",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task<bool> BorrarFacturaAsync(int nroFactura)
        {
            string url = urlApi + "factura/"+nroFactura.ToString();
            var data = await ClienteSingleton.GetInstance().DeleteAsync(url);
            bool res = JsonConvert.DeserializeObject<bool>(data);
            return res;
        }

        private void VerFactura(int nro)
        {
            FrmDetallesFactura frmDetallesFactura = new FrmDetallesFactura(nro);
            frmDetallesFactura.Show();
        }
        private void FrmConsultarFacturas_Load(object sender, EventArgs e)
        {
            DtpPrimeraFecha.Format = DateTimePickerFormat.Short;
            DtpUltimaFecha.Format = DateTimePickerFormat.Short;
            DtpUltimaFecha.Value = DateTime.Today;
        }

        private async void BtnGenerar_ClickAsync(object sender, EventArgs e)
        {
            await CargarFacturasAsync();
        }
    }
}
