using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataApi.datos;
using DataApi.dominio;
using FrontFacturacion.servicios;
using Newtonsoft.Json;
using System.Security.Policy;

namespace FrontFacturacion.formularios
{
    public partial class FrmNuevaFactura : Form
    {
        string urlApi = "http://localhost:5023/";
        Factura nueva;
        public FrmNuevaFactura()
        {
            InitializeComponent();
            nueva = new Factura();
        }

        private async void FrmNuevaFactura_Load(object sender, EventArgs e)
        {

            await CargarArticulosAsync();
            await CargarComboAsync();
            await ProximaFacturaAsync();
            DtpFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            TbxCliente.Text = "CONSUMIDOR FINAL";
        }

        private async Task CargarArticulosAsync()
        {
            string url = urlApi+"articulos";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Articulo> lst = JsonConvert.DeserializeObject<List<Articulo>>(data);
            CbxArticulos.DataSource = lst;
            CbxArticulos.DisplayMember = "descripcion";
            CbxArticulos.ValueMember = "codigo";
            CbxFormaPago.SelectedIndex = -1;
        }


        private async Task CargarComboAsync()
        {
            string url = urlApi + "formasDePago";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            Dictionary<int,string> lst = JsonConvert.DeserializeObject<Dictionary<int, string> > (data);
            CbxFormaPago.DataSource = new BindingSource(lst, null);
            CbxFormaPago.DisplayMember = "Value";
            CbxFormaPago.ValueMember = "Key";
            CbxFormaPago.SelectedIndex = -1;
        }

        private async Task ProximaFacturaAsync()
        {
            string url = urlApi + "proximoNro";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            int next = JsonConvert.DeserializeObject<int>(data);
            if (next > 0)
                LblFactura.Text = "Factura Nº: " + next.ToString();
            else
                MessageBox.Show("Error de datos. No se puede obtener Nº de presupuesto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        private void CalcularTotal()
        {
            double total = nueva.CalcularTotal();
            TbxTotal.Text = total.ToString();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (CbxArticulos.Text.Equals(String.Empty))
            {
                MessageBox.Show("Debe seleccionar un Articulo!",
                "Control", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }
            if (TbxCantidad.Text == "" || !int.TryParse(TbxCantidad.Text,
            out _))
            {
                MessageBox.Show("Debe ingresar una cantidad válida!",
                "Control", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }
            if (DgvDetalles.Rows.Count > 0) {
                foreach (DataGridViewRow row in DgvDetalles.Rows)
                {
                    if (row.Cells["Articulo"].Value.ToString().Equals(CbxArticulos.Text))
                    {
                        if (MessageBox.Show("Ya se agrego este producto\n¿Quiere sumar esta cantidad?", "Control",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            int valor = int.Parse(row.Cells["Cantidad"].Value.ToString()) + int.Parse(TbxCantidad.Text);
                            row.Cells["Cantidad"].Value = valor.ToString();
                            nueva.Detalles[row.Index].Cantidad = valor;
                            CalcularTotal();
                        }
                        return;
                    }
                }
            }

            Articulo item = (Articulo)CbxArticulos.SelectedItem;

            int art = item.Codigo;
            string nom = item.Descripcion;
            double pre = item.Precio;
            Articulo a = new Articulo(art, nom, pre);
            int cantidad = Convert.ToInt32(TbxCantidad.Text);

            Detalle detalle = new Detalle(a, cantidad);
            nueva.AgregarDetalle(detalle);
            DgvDetalles.Rows.Add(new object[] { a.Descripcion,
            cantidad, a.Precio});
            CalcularTotal();
        }

        private void DgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvDetalles.CurrentCell.ColumnIndex == 3 && DgvDetalles.Rows.Count > 0)
            {
                nueva.QuitarDetalle(DgvDetalles.CurrentRow.Index);
                //click button:
                DgvDetalles.Rows.Remove(DgvDetalles.CurrentRow);
                //presupuesto.quitarDetalle();
                CalcularTotal();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (TbxCliente.Text == "")
            {
                MessageBox.Show("Debe ingresar un cliente!", "Control",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (CbxFormaPago.SelectedIndex == -1)
            {
                MessageBox.Show("Debe ingresar una forma de pago!", "Control",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (DgvDetalles.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos detalle!",
                "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            GuardarFactura();
        }
        private async Task<bool> GuardarFacturaAsync(Factura oFactura)
        {
            string url = urlApi+"factura";
            string facturaJson = JsonConvert.SerializeObject(oFactura);
            var result = await ClienteSingleton.GetInstance().PostAsync(url, facturaJson);
            return result.Equals("true");
        }

        private async void GuardarFactura()
        {
            nueva.Cliente = TbxCliente.Text;
            nueva.FormaPago = Convert.ToInt32(CbxFormaPago.SelectedValue);
            nueva.Fecha = DtpFecha.Value;
            if (await GuardarFacturaAsync(nueva))
            {
                MessageBox.Show("Factura registrada", "Informe",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("ERROR. No se pudo registrar la factura",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
