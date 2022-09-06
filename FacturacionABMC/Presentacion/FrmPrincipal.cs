using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionABMC.Presentacion
{
    public partial class FrmPrincipal : Form
    {

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void MenuArchivo_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Salir" &&
                MessageBox.Show("Seguro que desea salir?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                Close();
            }
        }

        

        private void MenuFacturas_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Nueva Factura")
            {
                FrmNuevaFactura frmNuevaFactura = new FrmNuevaFactura();
                frmNuevaFactura.Show();
            }
            if (e.ClickedItem.Text == "Consultar Facturas")
            {
                FrmConsultarFacturas frmConsultarFacturas = new FrmConsultarFacturas();
                frmConsultarFacturas.Show();
            }
        }

    }
}
