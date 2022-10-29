using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApi.dominio
{
    public class Detalle
    {
        private Articulo articulo;
        private int cantidad;

        public Articulo Articulo { get { return articulo; } set { articulo = value; } }
        public int Cantidad { get { return cantidad; } set { cantidad = value; } }


        public Detalle(Articulo articulo, int cantidad)
        {
            this.articulo = articulo;
            this.cantidad = cantidad;
        }

        public double CalcularSubtotal()
        {
            return articulo.Precio * cantidad;
        }

        public override string ToString()
        {
            return articulo.Codigo.ToString() + " " + cantidad.ToString();
        }
    }
}
