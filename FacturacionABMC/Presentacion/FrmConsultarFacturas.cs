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
    public partial class FrmConsultarFacturas : Form
    {
        HelperDB gestor = HelperDB.ObtenerInstancia();

        public FrmConsultarFacturas()
        {
            InitializeComponent();
        }

        private void CargarFacturas()
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("@fecha_1", DtpPrimeraFecha.Value));
            parametros.Add(new Parametro("@fecha_2", DtpUltimaFecha.Value));
            parametros.Add(new Parametro("@cliente", TbxCliente.Text));
            DataTable dataTable = gestor.ConsultaSQL("SP_CONSULTAR_MAESTRO",parametros);
            DgvFacturas.Rows.Clear();
            foreach(DataRow fila in dataTable.Rows)
            {
                DgvFacturas.Rows.Add(new object[] { fila[0], fila[1], fila[2], fila[3], fila[4] });
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
                QuitarFactura((int)DgvFacturas.CurrentRow.Cells[0].Value);
            }

            if (DgvFacturas.CurrentCell.ColumnIndex == 6)
            {
                ModificarFactura((int)DgvFacturas.CurrentRow.Cells[0].Value,
                    (DateTime)DgvFacturas.CurrentRow.Cells[1].Value, 
                    (int)DgvFacturas.CurrentRow.Cells[3].Value,
                    (string)DgvFacturas.CurrentRow.Cells[4].Value);
            }
        }

        private void ModificarFactura(int nro, DateTime fecha, int formaPago, string cliente)
        {
            Factura factura = new Factura(nro, fecha, formaPago, cliente);
            FrmModificarFactura frmModificarFactura = new FrmModificarFactura(factura);
            frmModificarFactura.Show();
        }

        private void QuitarFactura(int nroFactura)
        {
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@factura_nro", nroFactura));
            if (MessageBox.Show($"Seguro que quiere quitar la factura Nº{nroFactura}?",
                "Borrar",MessageBoxButtons.YesNo,MessageBoxIcon.Information) 
                == DialogResult.Yes)
            {
                if(gestor.EjecutarSQL("SP_DESACTIVAR_MAESTRO", lst) >  0)

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

        private void FrmConsultarFacturas_Load(object sender, EventArgs e)
        {
            DtpPrimeraFecha.Format = DateTimePickerFormat.Short;
            DtpUltimaFecha.Format = DateTimePickerFormat.Short;
            DtpPrimeraFecha.Value = DateTime.Today;
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            CargarFacturas();
        }
    }
}
