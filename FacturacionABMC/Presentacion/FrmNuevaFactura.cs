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
using FacturacionABMC.Dominio;
using FacturacionABMC.Datos;

namespace FacturacionABMC.Presentacion
{
    public partial class FrmNuevaFactura : Form
    {
        HelperDB gestor = HelperDB.ObtenerInstancia();
        Factura factura;
        public FrmNuevaFactura()
        {
            InitializeComponent();
        }

        private void FrmNuevaFactura_Load(object sender, EventArgs e)
        {
            factura = new Factura();
            CargarArticulos();

            ProximaFactura();
            DtpFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            TbxCliente.Text = "CONSUMIDOR FINAL";
            this.ActiveControl = CbxArticulos;

            CargarCombo();
        }

        private void CargarCombo()
        {
            DataTable dataTable = gestor.ConsultaSQL("SP_CONSULTAR_FORMAS_PAGO");
            if (dataTable != null)
            {
                CbxFormaPago.DataSource = dataTable;
                CbxFormaPago.DisplayMember = "forma_pago";
                CbxFormaPago.ValueMember = "id_forma_pago";
                CbxFormaPago.SelectedIndex = -1;
            }
        }

        private void ProximaFactura()
        {
            int next = gestor.ProximaFactura();
            if (next > 0)
                LblFactura.Text = "Factura Nº: " + next.ToString();
            else
                MessageBox.Show("Error de datos. No se puede obtener Nº de presupuesto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void CargarArticulos()
        {

            DataTable dataTable = gestor.ConsultaSQL("SP_CONSULTAR_ARTICULOS");
            if (dataTable != null)
            {
                CbxArticulos.DataSource = dataTable;
                CbxArticulos.DisplayMember = "articulo";
                CbxArticulos.ValueMember = "id_articulo";
            }
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
                            factura.Detalles[row.Index].Cantidad = valor;
                            CalcularTotal();
                        }
                        return;
                    }
                }
            }

            DataRowView item = (DataRowView)CbxArticulos.SelectedItem;

            int art = Convert.ToInt32(item.Row.ItemArray[0]);
            string nom = item.Row.ItemArray[1].ToString();
            double pre = Convert.ToDouble(item.Row.ItemArray[2]);
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

        private void GuardarFactura()
        {
            factura.Cliente = TbxCliente.Text;
            factura.FormaPago = Convert.ToInt32(CbxFormaPago.SelectedValue);
            factura.Fecha = DtpFecha.Value;
            if (gestor.ConfirmarFactura(factura))
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
