using DataApi.datos.Interfaz;
using DataApi.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApi.datos.Implementacion
{
    public class DaoFactura : IDaoFactura
    {
        public int ObtenerProximoNro()
        {
            string sp = "SP_PROXIMO_ID";
            return HelperDB.ObtenerInstancia().ConsultaEscalarSQL(sp, "@next");
        }

        public List<Articulo> ObtenerArticulos()
        {
            List<Articulo> lst = new List<Articulo>();

            string sp = "SP_CONSULTAR_ARTICULOS";
            DataTable t = HelperDB.ObtenerInstancia().ConsultaSQL(sp, null);

            foreach (DataRow dr in t.Rows)
            {
                //Mapear un registro a un objeto del modelo de dominio
                int nro = int.Parse(dr["id_articulo"].ToString());
                string nombre = dr["articulo"].ToString();
                double precio = double.Parse(dr["precio"].ToString());

                Articulo aux = new Articulo(nro, nombre, precio);
                lst.Add(aux);

            }

            return lst;
        }

        public bool Crear(Factura oFactura)
        {
            bool ok = true;
            SqlConnection cnn = HelperDB.ObtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            SqlCommand cmd = new SqlCommand();
            try
            {

                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.Transaction = t;
                cmd.CommandText = "SP_INSERTAR_MAESTRO";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cliente", oFactura.Cliente);
                cmd.Parameters.AddWithValue("@fecha", oFactura.Fecha);
                cmd.Parameters.AddWithValue("@forma_pago", oFactura.FormaPago);

                //parámetro de salida:
                SqlParameter pOut = new SqlParameter();
                pOut.ParameterName = "@factura_nro";
                pOut.DbType = DbType.Int32;
                pOut.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pOut);
                cmd.ExecuteNonQuery();

                int presupuestoNro = (int)pOut.Value;

                SqlCommand cmdDetalle;
                foreach (Detalle item in oFactura.Detalles)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", cnn, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@factura_nro", presupuestoNro);
                    cmdDetalle.Parameters.AddWithValue("@id_articulo", item.Articulo.Codigo);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
                    cmdDetalle.ExecuteNonQuery();

                }
                t.Commit();
            }

            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                ok = false;
            }

            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return ok;
        }

        public bool Actualizar(Factura oFactura)
        {
            bool ok = true;
            SqlConnection cnn = HelperDB.ObtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.Transaction = t;
                cmd.CommandText = "SP_MODIFICAR_MAESTRO";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cliente", oFactura.Cliente);
                cmd.Parameters.AddWithValue("@fecha", oFactura.Fecha);
                cmd.Parameters.AddWithValue("@forma_pago", oFactura.FormaPago);
                cmd.ExecuteNonQuery();

                //SqlCommand cmdDetalle;
                //int detalleNro = 1;
                //foreach (DetallePresupuesto item in oFactura.Detalles)
                //{
                //    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", cnn, t);
                //    cmdDetalle.CommandType = CommandType.StoredProcedure;
                //    cmdDetalle.Parameters.AddWithValue("@presupuesto_nro", oFactura.PresupuestoNro);
                //    cmdDetalle.Parameters.AddWithValue("@detalle", detalleNro);
                //    cmdDetalle.Parameters.AddWithValue("@id_producto", item.Producto.ProductoNro);
                //    cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
                //    cmdDetalle.ExecuteNonQuery();

                //    detalleNro++;
                //}
                t.Commit();
            }

            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                ok = false;
            }

            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return ok;
        }

        public bool Borrar(int nro)
        {
            string sp = "SP_DESACTIVAR_MAESTRO";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@factura_nro", nro));
            int afectadas = HelperDB.ObtenerInstancia().EjecutarSQL(sp, lst);
            return afectadas > 0;
        }

        public List<Factura> ObtenerFacturasPorFiltros(DateTime desde, DateTime hasta, string cliente)
        {
            List<Factura> facturas = new List<Factura>();
            string sp = "SP_CONSULTAR_MAESTRO";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@fecha_1", desde));
            lst.Add(new Parametro("@fecha_2", hasta));
            lst.Add(new Parametro("@cliente", cliente));
            DataTable dt = HelperDB.ObtenerInstancia().ConsultaSQL(sp, lst);

            foreach (DataRow row in dt.Rows)
            {
                Factura factura = new Factura();
                factura.Codigo = int.Parse(row["id_forma_pago"].ToString());
                factura.Cliente = row["cliente"].ToString();
                factura.FormaPago = int.Parse(row["id_forma_pago"].ToString());
                factura.Fecha = DateTime.Parse(row["fecha"].ToString());
                facturas.Add(factura);
            }

            return facturas;
        }

        public DataTable ObtenerReporte(DateTime desde, DateTime hasta)
        {
            string sp = "SP_CONSULTAR_VENTAS_ARTICULOS";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@fecha_1", desde));
            lst.Add(new Parametro("@fecha_2", hasta));
            DataTable dt = HelperDB.ObtenerInstancia().ConsultaSQL(sp, lst);
            return dt;
        }

        public Factura ObtenerFacturaPorNro(int nro)
        {
            Factura factura = new Factura();
            string sp = "SP_CONSULTAR_MAESTRO_DETALLE";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@factura_nro", nro));

            DataTable dt = HelperDB.ObtenerInstancia().ConsultaSQL(sp, lst);
            bool primero = true;

            foreach (DataRow fila in dt.Rows)
            {
                if (primero)
                {
                    factura.Cliente = fila["cliente"].ToString();
                    factura.Fecha = DateTime.Parse(fila["fecha"].ToString());
                    factura.FormaPago = int.Parse(fila["id_forma_pago"].ToString());
                    primero = false;
                }
                int nroProducto = int.Parse(fila["id_articulo"].ToString());
                string nombre = fila["articulo"].ToString();
                double precio = double.Parse(fila["precio"].ToString());
                Articulo producto = new Articulo(nroProducto, nombre, precio);
                int cantidad = int.Parse(fila["cantidad"].ToString());
                Detalle detalle = new Detalle(producto,cantidad);
                factura.AgregarDetalle(detalle);
            
            }

            return factura;
        }
    }
}

