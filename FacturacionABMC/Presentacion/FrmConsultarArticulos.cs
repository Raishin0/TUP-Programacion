using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace FacturacionABMC.Presentacion
{
    public partial class FrmConsultarArticulos : Form
    {
        public FrmConsultarArticulos()
        {
            InitializeComponent();
        }

        private void FrmConsultarArticulos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dSArticulos.articulos' Puede moverla o quitarla según sea necesario.
            this.articulosTableAdapter.Fill(this.dSArticulos.articulos);

            this.reportViewer1.RefreshReport();
        }
    }
}
