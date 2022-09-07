using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacturacionABMC.Dominio;
using FacturacionABMC.Datos;

namespace FacturacionABMC.Presentacion
{
    public partial class FrmModificarFactura : Form
    {
        HelperDB gestor = new HelperDB();
        Factura factura;
        public FrmModificarFactura(Factura factura)
        {
            this.factura = factura;

            InitializeComponent();
        }

        private void FrmModificarFactura_Load(object sender, EventArgs e)
        {
            CargarCombo();
            CargarFactura();
        }

        private void CargarCombo()
        {
            DataTable dataTableFP = gestor.ConsultaSQL("SP_CONSULTAR_FORMAS_PAGO");
            if (dataTableFP != null)
            {
                CbxFormaPago.DataSource = dataTableFP;
                CbxFormaPago.DisplayMember = "forma_pago";
                CbxFormaPago.ValueMember = "id_forma_pago";
                CbxFormaPago.SelectedIndex = -1;
            }
        }

        private void CargarFactura()
        {
            TbxCliente.Text = factura.Cliente;
            CbxFormaPago.SelectedValue = factura.FormaPago;
            DtpFecha.Value = factura.Fecha;
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@factura_nro", factura.Codigo));
            DataTable detalles = gestor.ConsultaSQL("SP_CONSULTAR_DETALLE", lst);
            foreach (DataRow fila in detalles.Rows)
            {
                int cod = (int)fila[0];
                string nom = fila[1].ToString();
                int can = (int)fila[2];
                double pre = double.Parse(fila[3].ToString());
                Articulo articulo = new Articulo(cod, nom, pre);
                factura.Detalles.Add(new Detalle(articulo, can));
                DgvDetalles.Rows.Add(new object[] { (string)fila[1], (int)fila[2], double.Parse(fila[3].ToString()) });
            }
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
            GuardarFactura();
        }


        private void GuardarFactura()
        {
            factura.Cliente = TbxCliente.Text;
            factura.FormaPago = Convert.ToInt32(CbxFormaPago.SelectedValue);
            factura.Fecha = DtpFecha.Value;

            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@factura_nro", factura.Codigo));
            lst.Add(new Parametro("@forma_pago", factura.FormaPago));
            lst.Add(new Parametro("@fecha", factura.Fecha));
            lst.Add(new Parametro("@cliente", factura.Cliente));
            if (gestor.EjecutarSQL("SP_MODIFICAR_MAESTRO", lst) > 0)
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
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
