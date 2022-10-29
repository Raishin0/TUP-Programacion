using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataApi.dominio
{
    public class Articulo
    {
        private int codigo;
        private string descripcion;
        private double precio;

        public int Codigo { get { return codigo; } set { codigo = value; } }
        public string Descripcion { get { return descripcion; } set { descripcion = value; } }
        public double Precio { get { return precio; } set { precio = value; } }

        public Articulo()
        {
            codigo = -1;
            descripcion = "";
            precio = 0;
        }
        public Articulo(int codigo, string descripcion, double precio)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.precio = precio;
        }

        public override string ToString()
        {
            return descripcion.ToUpper() + ", $" + precio.ToString();
        }
    }
}
