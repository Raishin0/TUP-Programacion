﻿using DataApi.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApi.datos.Interfaz
{
    public interface IDaoFactura
    {
        List<Articulo> ObtenerArticulos();
        int ObtenerProximoNro();
        bool Crear(Factura oFactura);
        bool Actualizar(Factura oFactura);
        bool Borrar(int nro);
        List<Factura> ObtenerFacturasPorFiltros(DateTime desde, DateTime hasta, string cliente);
        Factura ObtenerFacturaPorNro(int nro);
        DataTable ObtenerReporte(DateTime desde, DateTime hasta);
    }
}