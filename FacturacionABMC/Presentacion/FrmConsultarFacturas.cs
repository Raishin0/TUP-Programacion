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
        HelperDB gestor = new HelperDB();

        public FrmConsultarFacturas()
        {
            InitializeComponent();
            CargarFacturas();
        }

        private void CargarFacturas()
        {
            DataTable dataTable = gestor.ConsultaSQL("SP_CONSULTAR_MAESTRO");
            foreach(DataRow fila in dataTable.Rows)
            {
                DgvFacturas.Rows.Add(new object[] { fila[0], fila[1], fila[2], fila[3] });
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvFacturas.CurrentCell.ColumnIndex == 4)
            {
                QuitarFactura((int)DgvFacturas.CurrentRow.Cells[0].Value);
            }
        }

        private void QuitarFactura(int nroFactura)
        {
            if(MessageBox.Show($"Seguro que quiere quitar la factura Nº{nroFactura}?",
                "Borrar",MessageBoxButtons.YesNo,MessageBoxIcon.Information) 
                == DialogResult.Yes)
            {
                if(gestor.EliminarFactura(nroFactura) >  0)

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
    }
}
