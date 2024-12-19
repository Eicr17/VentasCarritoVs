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
        [Route("Obtener")]

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
                                fecha_venta =  vent.Fecha_Venta,
                                descuento = vent.Descuento,
                                existencia = vent.Existencia
                            }
                            ); 
                    }
                    );
                resp.datos = lstVentas;
                resp.codigo_operacion = 0;
                resp.mensaje_error = string.Empty;
                resp.total_registros = lstProdVentas.Count;
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

                
        }

        [HttpPost]
        [Route("Insertar")]

        public IActionResult InsertarVenta([FromBody] VentasApi pRequest)
        {
            var InsercionDatos = new SrvVentasCarrito();
            var DatosInsercion = new MdlVentasCrearDb();
            var Resp = new MdlMensajeResp();

            try
            {
                DatosInsercion.Id_Producto = pRequest.id_producto;
                DatosInsercion.Id_Cliente = pRequest.id_cliente;
                DatosInsercion.Establecimiento = pRequest.establecimiento;
                DatosInsercion.Precio = pRequest.precio;
                DatosInsercion.Fecha_Venta = pRequest.fecha_venta;
                DatosInsercion.Descuento = pRequest.descuento;
                DatosInsercion.Existencia = pRequest.existencia;
                InsercionDatos.Insertar(DatosInsercion);
                var resp = new MdlMensajeResp();
                resp.mensaje_exitoso = "Insercion Exitosa";
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

        }


        [HttpPut]
        [Route("Actualizar")]

        public IActionResult Actualizar([FromBody] VentasApi pRequest)
        {
            var ActalizacionVentas = new SrvVentasCarrito();
            var VentasActualizacion = new MdlVentasDb();
            var resp = new MdlMensajeResp();


            try
            {
                VentasActualizacion.IdProducto = pRequest.id_producto;
                VentasActualizacion.IdCliente = pRequest.id_cliente;
                VentasActualizacion.IdVenta = pRequest.id_venta;    
                VentasActualizacion.Establecimiento = pRequest.establecimiento;
                VentasActualizacion.Precio = pRequest.precio;
                VentasActualizacion.CantidadProducto = pRequest.cantidad_producto;
                VentasActualizacion.Fecha_Venta = pRequest.fecha_venta;
                VentasActualizacion.Descuento = pRequest.descuento;
                VentasActualizacion.Existencia = pRequest.existencia;
                ActalizacionVentas.Actualizar(VentasActualizacion);
                resp.mensaje_exitoso = "La Actualizacion a sido Exitosa";
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }


        }


        [HttpPost]
        [Route("Eliminar")]

        public IActionResult Delete([FromBody] VentasApi pRequest)
        {

            var EliminarVentas = new SrvVentasCarrito();
            var VentasEliminar = new MdlVentasDb();
            var Resp = new MdlMensajeResp();

            try
            {
                VentasEliminar.IdVenta = pRequest.id_venta;
                VentasEliminar.IdProducto = pRequest.id_producto;
                VentasEliminar.IdCliente = pRequest.id_venta;

                EliminarVentas.Delete(VentasEliminar);
                Resp.mensaje_exitoso = "La Eliminacion a sido Exitosa";
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
