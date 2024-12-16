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
                                id_cliente = vent.IdCliente,
                                id_producto = vent.IdProducto,
                                id_venta = vent.IdVenta,
                                establecimiento = vent.Establecimiento,
                                precio = vent.Precio,
                                cantidad_producto = vent.CantidadProducto,
                                fecha_venta = vent.Fecha_Venta,
                                descuento = vent.Descuento
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
            var DatosInsercion = new MdlVentasCrearDb();
            var Resp = new MdlMensajeResp();

            try
            {
             
                DatosInsercion.Establecimiento = pRequest.establecimiento;
                DatosInsercion.Precio = pRequest.precio;
                DatosInsercion.Fecha_Venta = pRequest.fecha_venta;
                DatosInsercion.Descuento = pRequest.descuento;
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
                VentasActualizacion.IdVenta = pRequest.id_venta;
                VentasActualizacion.IdCliente = pRequest.id_cliente;
                VentasActualizacion.IdProducto = pRequest.id_producto;
                VentasActualizacion.Establecimiento = pRequest.establecimiento;
                VentasActualizacion.Precio = pRequest.precio;
                VentasActualizacion.CantidadProducto = pRequest.cantidad_producto;
                VentasActualizacion.Fecha_Venta = pRequest.fecha_venta;
                VentasActualizacion.Descuento = pRequest.descuento;
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
                VentasElimianr.IdVenta = pRequest.id_venta;
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
