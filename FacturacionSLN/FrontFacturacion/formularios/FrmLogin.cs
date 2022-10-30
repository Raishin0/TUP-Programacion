using FrontFacturacion.servicios;
using FrontFacturacion.servicios.interfaz;
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
    public partial class FrmLogin : Form
    {
        IServicio servicio;
        FabricaServicio fabrica;
        public FrmLogin(FabricaServicio fabrica)
        {
            this.fabrica = fabrica;
            servicio = fabrica.CrearServicio();
            InitializeComponent();
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            if(servicio.Login(TbxUsuario.Text, TbxContrasenia.Text) > 0)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Datos Incorrectos","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Seguro que desea salir?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
