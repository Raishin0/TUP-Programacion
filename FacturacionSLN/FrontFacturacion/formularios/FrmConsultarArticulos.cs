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
    public partial class FrmConsultarArticulos : Form
    {
        string urlApi = "http://localhost:5023/";
        public FrmConsultarArticulos()
        {
            InitializeComponent();
        }

        private async void FrmConsultarArticulos_Load(object sender, EventArgs e)
        {
            await CargarArticulosAsync();
        }

        private async Task CargarArticulosAsync()
        {
            string url = urlApi + "articulos";
            var data = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Articulo> lst = JsonConvert.DeserializeObject<List<Articulo>>(data);
            foreach(Articulo articulo in lst)
            {
                dgvArticulos.Rows.Add(new object[] { articulo.Codigo, articulo.Descripcion, articulo.Precio });
            }
        }
    }
}
