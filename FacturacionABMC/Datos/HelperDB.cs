using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using FacturacionABMC.Dominio;

namespace FacturacionABMC.Datos
{
    public class HelperDB
    {
        private SqlConnection cnn;
        private static HelperDB helperDB;

        private HelperDB()
        {
            cnn = new SqlConnection(Properties.Resources.cnnString);
        }

        public static HelperDB ObtenerInstancia()
        {
            if (helperDB == null)
                helperDB = new HelperDB();
            return helperDB ;
        }

        public DataTable ConsultaSQL(string strSql)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();

            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = strSql;
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();

            return tabla;
        }

        public DataTable ConsultaSQL(string spNombre, List<Parametro> values)
        {
            DataTable tabla = new DataTable();

            cnn.Open();
            SqlCommand cmd = new SqlCommand(spNombre, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (Parametro oParametro in values)
            {
                cmd.Parameters.AddWithValue(oParametro.Clave, oParametro.Valor);
            }

            tabla.Load(cmd.ExecuteReader());
            cnn.Close();

            return tabla;
        }



        public int EjecutarSQL(string strSql, List<Parametro> values)
        {
            int afectadas = 0;
            SqlTransaction t = null;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = strSql;
                cmd.Transaction = t;

                if (values != null)
                {
                    foreach (Parametro param in values)
                    {
                        cmd.Parameters.AddWithValue(param.Clave, param.Valor);
                    }
                }

                afectadas = cmd.ExecuteNonQuery();
                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null) { t.Rollback(); }
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();

            }

            return afectadas;
        }

        public int ProximaFactura()
        {
            SqlCommand cmd = new SqlCommand();
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = "SP_PROXIMO_ID";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pOut = new SqlParameter();
            pOut.ParameterName = "@next";
            pOut.DbType = DbType.Int32;
            pOut.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pOut);
            cmd.ExecuteNonQuery();

            cnn.Close();
            return (int)pOut.Value;

        }

        public bool ConfirmarFactura(Factura oFactura)
        {

            bool resultado = true;

            SqlTransaction t = null;

            try
            {
                cnn.Open();

                t = cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("SP_INSERTAR_MAESTRO", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = t;

                cmd.Parameters.AddWithValue("@fecha", oFactura.Fecha);
                cmd.Parameters.AddWithValue("@cliente", oFactura.Cliente);
                cmd.Parameters.AddWithValue("@forma_pago", oFactura.FormaPago);
                SqlParameter param = new SqlParameter("@factura_nro", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                int presupuestoNro = Convert.ToInt32(param.Value);
                foreach (Detalle oDetalle in oFactura.Detalles)
                {
                    SqlCommand cmdDet = new SqlCommand("SP_INSERTAR_DETALLE", cnn);
                    cmdDet.CommandType = CommandType.StoredProcedure;
                    cmdDet.Transaction = t;
                    cmdDet.Parameters.AddWithValue("@factura_nro",
                    presupuestoNro);
                    cmdDet.Parameters.AddWithValue("@id_articulo",
                    oDetalle.Articulo.Codigo);
                    cmdDet.Parameters.AddWithValue("@cantidad",
                    oDetalle.Cantidad);
                    cmdDet.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch (Exception ex)
            {
                t.Rollback();
                resultado = false;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            return resultado;
        }
    }
}
