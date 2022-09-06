using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FacturacionABMC.Dominio
{
    public class Factura
    {
        private int codigo;
        private DateTime fecha;
        private int formaPago;
        private string cliente;
        private List<Detalle> detalles;

        public int Codigo { get { return codigo; } set { codigo = value; } }
        public DateTime Fecha { get{ return fecha; } set { fecha=value; } }
        public int FormaPago { get { return formaPago; } set { formaPago = value; } }
        public string Cliente { get { return cliente; } set { cliente = value; } }
        public List<Detalle> Detalles { get { return detalles; } set { detalles = value; } }

        public Factura()
        {
            this.codigo = -1;
            this.fecha = DateTime.Now;
            this.formaPago = -1;
            this.cliente = "";
            this.detalles = new List<Detalle>();
        }

        public Factura(int codigo, DateTime fecha, int formaPago, string cliente)
        {
            this.codigo = codigo;
            this.fecha = fecha;
            this.formaPago = formaPago;
            this.cliente = cliente;
            this.detalles = new List<Detalle>();
        }

        public void AgregarDetalle(Detalle nuevoDetalle)
        {
            detalles.Add(nuevoDetalle);
        }

        public void QuitarDetalle(int numDetalle)
        {
            detalles.RemoveAt(numDetalle);
        }

        public double CalcularTotal()
        {
            double total = 0;
            foreach (Detalle detalle in detalles)
            {
                total += detalle.CalcularSubtotal();
            }
            return total;
        }

        public override string ToString()
        {
            return codigo.ToString() + " " + fecha.ToString() + " " + formaPago.ToString() + " " + cliente.ToString();
        }
    }
}
