using DataApi.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontFacturacion.servicios.interfaz
{
    public interface IServicio
    {
        int Login(string nombre, string contrasenia);
        List<Articulo> ObtenerArticulos();
        Dictionary<int, string> ObtenerFormasPago();
        int ObtenerProximoNro();
        bool Crear(Factura oFactura);
        bool Actualizar(Factura oFactura);
        bool Borrar(int nro);
        List<Factura> ObtenerFacturasPorFiltros(DateTime desde, DateTime hasta, string cliente);
        Factura ObtenerFacturaPorNro(int nro);
        DataTable ObtenerReporte(DateTime desde, DateTime hasta);

    }
}
