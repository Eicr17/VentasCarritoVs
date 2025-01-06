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

            var respuesta = new ApiRespuestaListado<VentasApi>();

            var lstProdVentas = new List<MdlVentas>();
            var lstVentas = new List<VentasApi>();
            var resp = new ApiRespuestaListado<VentasApi>();


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
                            }
                            ); 
                    }
                    );
                resp.datos = lstVentas;
                resp.mensaje = string.Empty;
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
        [Route("Crear")]

        public IActionResult InsertarVenta([FromBody] VentasApi pRequest)
        {
            var SrvVentasCrear = new SrvVentasCarrito();
            var MdVentasCrear = new MdlVentasCrear();
            var Resp = new MdlMensajeResp();

            try
            {
                MdVentasCrear.Id_Producto = pRequest.id_producto;
                MdVentasCrear.Id_Cliente = pRequest.id_cliente;
                MdVentasCrear.Establecimiento = pRequest.establecimiento;
                MdVentasCrear.Precio = pRequest.precio;
                MdVentasCrear.Cantidad_Producto = pRequest.cantidad_producto;
                MdVentasCrear.Descuento = pRequest.descuento;
                SrvVentasCrear.Insertar(MdVentasCrear);
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
            var SrvVentasActualizar = new SrvVentasCarrito();
            var MdVentasActualizar = new MdlVentasActualizar();
            var resp = new MdlMensajeResp();


            try
            {
                MdVentasActualizar.IdProducto = pRequest.id_producto;
                MdVentasActualizar.IdCliente = pRequest.id_cliente;
                MdVentasActualizar.IdVenta = pRequest.id_venta;
                MdVentasActualizar.Establecimiento = pRequest.establecimiento;
                MdVentasActualizar.Precio = pRequest.precio;
                MdVentasActualizar.CantidadProducto = pRequest.cantidad_producto;
                MdVentasActualizar.Fecha_Venta = pRequest.fecha_venta;
                MdVentasActualizar.Descuento = pRequest.descuento;
                SrvVentasActualizar.Actualizar(MdVentasActualizar);
                resp.mensaje_exitoso = "La Actualizacion a sido Exitosa";
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }


        }


        [HttpPut]
        [Route("Eliminar/{pId}")]

        public IActionResult Delete(int pId)
        {

            var SrvVentasEliminacion = new SrvVentasCarrito();
            var MdVentasEliminar = new MdlVentasEliminar();
            var Resp = new ApiRespuesta();

            try
            {
                MdVentasEliminar.Id_Venta = pId;
                SrvVentasEliminacion.Delete(MdVentasEliminar);
                Resp.exitosa = true;
                Resp.mensaje = "El registro ha sido eliminado";
                
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
    