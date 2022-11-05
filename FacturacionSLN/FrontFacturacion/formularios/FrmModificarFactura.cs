using DataApi.datos.Implementacion;
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
    public partial class FrmModificarFactura : Form
    {
        string urlApi = "http://localhost:5023/";
        Factura factura;

        public FrmModificarFactura(Factura factura)
        {
            this.factura = factura;
            InitializeComponent();
        }

        private async void FrmModificarFactura_LoadAsync(object sender, EventArgs e)
        {
            await CargarArticulosAsync();
            await CargarComboAsync();
            CargarFactura();
        }
        private async Task CargarArticulosAsync()
        {
            string url = urlApi + "articulos";
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
            Dictionary<int, string> lst = JsonConvert.DeserializeObject<Dictionary<int, string>>(data);
            CbxFormaPago.DataSource = new BindingSource(lst, null);
            CbxFormaPago.DisplayMember = "Value";
            CbxFormaPago.ValueMember = "Key";
            CbxFormaPago.SelectedIndex = -1;
        }


        private void CargarFactura()
        {
            TbxCliente.Text = factura.Cliente;
            CbxFormaPago.SelectedValue = factura.FormaPago;
            DtpFecha.Value = factura.Fecha;
            //List<Parametro> lst = new List<Parametro>();
            //lst.Add(new Parametro("@factura_nro", factura.Codigo));
            //DataTable detalles = gestor.ConsultaSQL("SP_CONSULTAR_DETALLE", lst);
            //foreach (DataRow fila in detalles.Rows)
            //{
            //    int cod = (int)fila[0];
            //    string nom = fila[1].ToString();
            //    int can = (int)fila[2];
            //    double pre = double.Parse(fila[3].ToString());
            //    Articulo articulo = new Articulo(cod, nom, pre);
            //    factura.Detalles.Add(new Detalle(articulo, can));
            //    DgvDetalles.Rows.Add(new object[] { (string)fila[1], (int)fila[2], double.Parse(fila[3].ToString()) });
            //}
        }

        private void CalcularTotal()
        {
            double total = factura.CalcularTotal();
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
            if (DgvDetalles.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in DgvDetalles.Rows)
                {
                    if (row.Cells["Articulo"].Value.ToString().Equals(CbxArticulos.Text))
                    {
                        if (MessageBox.Show("Ya se agrego este producto\n¿Quiere sumar esta cantidad?", "Control",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            int valor = int.Parse(row.Cells["Cantidad"].Value.ToString()) + int.Parse(TbxCantidad.Text);
                            row.Cells["Cantidad"].Value = valor.ToString();
                            factura.Detalles[row.Index].Cantidad = valor;
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
            factura.AgregarDetalle(detalle);
            DgvDetalles.Rows.Add(new object[] { a.Descripcion,
            cantidad, a.Precio});
            CalcularTotal();
        }

        private void DgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvDetalles.CurrentCell.ColumnIndex == 3 && DgvDetalles.Rows.Count > 0)
            {
                factura.QuitarDetalle(DgvDetalles.CurrentRow.Index);
                //click button:
                DgvDetalles.Rows.Remove(DgvDetalles.CurrentRow);
                //presupuesto.quitarDetalle();
                CalcularTotal();
            }
        }
        private async void BtnAceptar_ClickAsync(object sender, EventArgs e)
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
            await GuardarFacturaAsync();
        }


        private async Task GuardarFacturaAsync()
        {
            factura.Cliente = TbxCliente.Text;
            factura.FormaPago = Convert.ToInt32(CbxFormaPago.SelectedValue);
            factura.Fecha = DtpFecha.Value;

            //List<Parametro> lst = new List<Parametro>();
            //lst.Add(new Parametro("@factura_nro", factura.Codigo));
            //lst.Add(new Parametro("@forma_pago", factura.FormaPago));
            //lst.Add(new Parametro("@fecha", factura.Fecha));
            //lst.Add(new Parametro("@cliente", factura.Cliente));
            if (await ActualizarAsync(factura))
            {
                MessageBox.Show("Factura modificada", "Informe",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("ERROR. No se pudo modificar la factura",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private async Task<bool> ActualizarAsync(Factura oFactura)
        {

            string url = urlApi + "factura";
            string facturaJson = JsonConvert.SerializeObject(oFactura);
            var result = await ClienteSingleton.GetInstance().PutAsync(url, facturaJson);
            return result.Equals("true");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
