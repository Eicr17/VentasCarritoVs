using CarritosVentaLibrerira.Modelos;
using CarritosVentaLibrerira.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VentasCarrito.Modelos;

namespace VentasCarrito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {

            var respuesta = new ApiRespuesta<VentasApi>();

            var lstProdVentas = new List<MdlVentasDb>();
            var lstVentas = new List<VentasApi>();
            var resp = new ApiRespuesta<VentasApi>();


            try
            {
                lstProdVentas = SrvVentasCarrito.ObtenerVentas();

                lstProdVentas.ForEach(
                    vent =>
                    {
                        lstVentas.Add(
                            new VentasApi
                            {
                                IdCliente = vent.IdCliente,
                                IdProducto = vent.IdProducto,
                                IdVenta = vent.IdVenta,
                                Establecimiento = vent.Establecimiento,
                                Precio = vent.Precio,
                                CantidadProducto = vent.CantidadProducto,
                                Fecha_Venta = vent.Fecha_Venta,
                                Descuento = vent.Descuento
                            }
                            );
                    }
                    );
                resp.Datos = lstVentas;
                resp.CodigoOperacion = 0;
                resp.MensajeError = string.Empty;
                resp.TotalRegistros = lstProdVentas.Count;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

                
        }

        [HttpPost]
        public IActionResult InsertarVenta([FromBody] VentasApi pRequest)
        {
            var InsercionDatos = new SrvVentasCarrito();
            var DatosInsercion = new MdlVentasDb();
            var Resp = new MdlMensajeResp();

            try
            {
                DatosInsercion.IdProducto = pRequest.IdProducto;
                DatosInsercion.IdCliente = pRequest.IdCliente;
                DatosInsercion.IdVenta = pRequest.IdVenta;
                DatosInsercion.Establecimiento = pRequest.Establecimiento;
                DatosInsercion.Precio = pRequest.Precio;
                DatosInsercion.Fecha_Venta = pRequest.Fecha_Venta;
                DatosInsercion.Descuento = pRequest.Descuento;
                InsercionDatos.Insertar(DatosInsercion);
                var resp = new MdlMensajeResp();
                resp.Mensaje = "Insercion Exitosa";
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

        }


        [HttpPut]
        public IActionResult Actualizar([FromBody] VentasApi pRequest)
        {
            var ActalizacionVentas = new SrvVentasCarrito();
            var VentasActualizacion = new MdlVentasDb();
            var resp = new MdlMensajeResp();


            try
            {
                VentasActualizacion.IdVenta = pRequest.IdVenta;
                VentasActualizacion.IdCliente = pRequest.IdCliente;
                VentasActualizacion.IdProducto = pRequest.IdProducto;
                VentasActualizacion.Establecimiento = pRequest.Establecimiento;
                VentasActualizacion.Precio = pRequest.Precio;
                VentasActualizacion.CantidadProducto = pRequest.CantidadProducto;
                VentasActualizacion.Fecha_Venta = pRequest.Fecha_Venta;
                VentasActualizacion.Descuento = pRequest.Descuento;
                ActalizacionVentas.Actualizar(VentasActualizacion);
                resp.Mensaje = "La Actualizacion a sido Exitosa";
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }


        }


        [HttpDelete]
        public IActionResult Delete([FromBody] VentasApi pRequest)
        {

            var EliminarVentas = new SrvVentasCarrito();
            var VentasElimianr = new MdlVentasDb();
            var Resp = new MdlMensajeResp();

            try
            {
                VentasElimianr.IdVenta = pRequest.IdVenta;
                EliminarVentas.Delete(VentasElimianr);
                Resp.Mensaje = "La Eliminacion a sido Exitosa";
                return Ok(Resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }


        }

    }
}
