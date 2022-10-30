using DataApi.datos.Implementacion;
using DataApi.dominio;
using DataAPI.fachada;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiFacturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {

        private IDataApi dataApi; //punto de acceso a la API

        public FacturasController()
        {
            dataApi = new DataApiImp();
        }

        [HttpGet("/login")]
        public IActionResult GetArticulos(string nombre, string contrasenia)
        {

            int correcto = -1;
            try
            {
                correcto = dataApi.Login(nombre,contrasenia);
                return Ok(correcto);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
        [HttpGet("/articulos")]
        public IActionResult GetArticulos()
        {

            List<Articulo> lst = null;
            try
            {
                lst = dataApi.ObtenerArticulos();
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpGet("/formasDePago")]
        public IActionResult GetFormasPago()
        {

            Dictionary<int,string> lst = null;
            try
            {
                lst = dataApi.ObtenerFormasPago();
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpGet("/proximoNro")]
        public IActionResult GetProximoNro()
        {

            int nro = -1;
            try
            {
                nro = dataApi.ObtenerProximoNro();
                return Ok(nro);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }


        [HttpGet("/facturas")]
        public IActionResult GetFacturas(string inicio, string final, string? cliente="")
        {
            List<Factura> facturas = null;
            try
            {
                DateTime fechaInicio = DateTime.Parse(inicio);
                DateTime fechaFinal = DateTime.Parse(final);
                facturas = dataApi.ObtenerFacturasPorFiltros(fechaInicio, fechaFinal, cliente);
                return Ok(facturas);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpGet("/factura/{id}")]
        public IActionResult GetFactura(int id)
        {
            Factura factura = null;
            try
            {
                factura = dataApi.ObtenerFacturaPorNro(id);
                return Ok(factura);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpGet("/reporte")]
        public IActionResult GetReporte(string inicio, string final)
        {
            try
            {
                DateTime fechaInicio = DateTime.Parse(inicio);
                DateTime fechaFinal = DateTime.Parse(final);
                string temp = JsonConvert.SerializeObject(dataApi.ObtenerReporte(fechaInicio, fechaFinal));
                return Ok(temp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpPost("/factura")]
        public IActionResult Post(Factura oFactura)
        {

            try
            {
                if (oFactura == null)
                {
                    return BadRequest("Datos de factura incorrectos!");
                }

                return Ok(dataApi.Crear(oFactura));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        // PUT api/<FacturasController>/5
        [HttpPut("/factura")]
        public IActionResult Put(Factura oFactura)
        {

            try
            {
                if (oFactura == null)
                {
                    return BadRequest("Datos de factura incorrectos!");
                }

                return Ok(dataApi.Actualizar(oFactura));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        // DELETE api/<FacturasController>/5
        [HttpDelete("/factura/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(dataApi.Borrar(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
    }
}
