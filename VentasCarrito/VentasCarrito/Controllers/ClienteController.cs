using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarritosVentaLibrerira.Modelos;
using VentasCarrito.Modelos;
using CarritosVentaLibrerira.Servicios;


namespace VentasCarrito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("Obtener")]
        public IActionResult Get( )
        {
            var respuesta = new ApiRespuestaListado<ClienteApi>();
            var lstProdCliente = new List<MdlCliente>();
            var lstCliente = new List<ClienteApi>();


            try
            {
                lstProdCliente = SrvCliente.ObtenerCliente();
                lstProdCliente.ForEach(
                    cli =>
                    {
                        lstCliente.Add(
                          new ClienteApi
                          {
                            id_cliente = cli.Id_Cliente,
                            nombre = cli.Nombre,
                            apellido = cli.Apellido,
                            dpi = cli.Dpi,
                            telefono = cli.Telefono,
                            totalventas = cli.TotalVentas
                          }
                          );

                    });

                respuesta.datos = lstCliente;                
                respuesta.mensaje = string.Empty;
                respuesta.total_registros = lstProdCliente.Count;

                return Ok(respuesta);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("Crear")]

        public IActionResult Crear([FromBody] ClienteApi pRequest)
        {


            var SrvCliente = new SrvCliente();
            var MdClienteCreacion = new MdlClienteCrear();
            try
            {
                MdClienteCreacion.Nombre = pRequest.nombre;
                MdClienteCreacion.Apellido = pRequest.apellido;
                MdClienteCreacion.Dpi = pRequest.dpi;
                MdClienteCreacion.Telefono = pRequest.telefono;
                SrvCliente.Insertar(MdClienteCreacion);
                var resp = new MdlMensajeResp();
                resp.mensaje_exitoso = "La insercion a sido exitosa";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("Actualizar")]

        public IActionResult Actualizar([FromBody] ClienteApi pRequest) 
        {
            var SrvClienteActualizacion =  new SrvCliente();
            var MdClientaActualizar = new MdlClienteActualizar();

            try
            {
                MdClientaActualizar.Id_Cliente = pRequest.id_cliente;
                MdClientaActualizar.Nombre = pRequest.nombre;
                MdClientaActualizar.Apellido = pRequest.apellido;
                MdClientaActualizar.Dpi = pRequest.dpi;
                MdClientaActualizar.Telefono = pRequest.telefono;
                SrvClienteActualizacion.Actualizar(MdClientaActualizar);
                var resp = new MdlMensajeResp();
                resp.mensaje_exitoso = "La Actualizacion a sido exitosa";
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
            var SrvClienteEliminacion = new SrvCliente();
            var MdClienteEliminar = new MdlClienteEliminar();
            var Resp = new ApiRespuesta();

            try
            {
                MdClienteEliminar.Id_Cliente = pId;
                SrvClienteEliminacion.Eliminar(MdClienteEliminar);
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
