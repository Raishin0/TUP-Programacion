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
    public partial class FrmLogin : Form
    {
        string urlApi = "http://localhost:5023/";
        public FrmLogin()
        {
            InitializeComponent();
        }

        private async void BtnEntrar_ClickAsync(object sender, EventArgs e)
        {
            if(await LoginAsync(TbxUsuario.Text, TbxContrasenia.Text))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Datos Incorrectos","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private async Task<bool> LoginAsync(string usuario, string password)
        {
            string url = urlApi + string.Format("login?nombre={0}&contrasenia={1}", usuario, password);
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            int value = JsonConvert.DeserializeObject<int>(data);
            return value>0;
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
