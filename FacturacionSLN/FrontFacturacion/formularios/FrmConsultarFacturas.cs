using DataApi.dominio;
using FrontFacturacion.servicios;
using FrontFacturacion.servicios.implementacion;
using FrontFacturacion.servicios.interfaz;
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
        IServicio servicio;
        FabricaServicio fabrica;

        public FrmConsultarFacturas(FabricaServicio fabrica)
        {
            this.fabrica = fabrica;
            servicio = fabrica.CrearServicio();
            InitializeComponent();
        }

        private void CargarFacturas()
        {
            List<Factura> lst = servicio.ObtenerFacturasPorFiltros(DtpPrimeraFecha.Value, DtpUltimaFecha.Value, TbxCliente.Text);
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
                QuitarFactura((int)DgvFacturas.CurrentRow.Cells[0].Value);
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
            FrmModificarFactura frmModificarFactura = new FrmModificarFactura(factura,fabrica);
            frmModificarFactura.Show();
        }

        private void QuitarFactura(int nroFactura)
        {
            if (MessageBox.Show($"Seguro que quiere quitar la factura Nº{nroFactura}?",
                "Borrar",MessageBoxButtons.YesNo,MessageBoxIcon.Information) 
                == DialogResult.Yes)
            {
                if(servicio.Borrar(nroFactura))

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
        private void VerFactura(int nro)
        {
            FrmDetallesFactura frmDetallesFactura = new FrmDetallesFactura(nro, fabrica);
            frmDetallesFactura.Show();
        }
        private void FrmConsultarFacturas_Load(object sender, EventArgs e)
        {
            DtpPrimeraFecha.Format = DateTimePickerFormat.Short;
            DtpUltimaFecha.Format = DateTimePickerFormat.Short;
            DtpUltimaFecha.Value = DateTime.Today;
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            CargarFacturas();
        }
    }
}
