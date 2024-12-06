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
        public IActionResult Get( )
        {
            var respuesta = new ApiRespuesta<ClienteApi>();
            var lstProdCliente = new List<MdlClienteDb>();
            var lstCliente = new List<ClienteApi>();


            try
            {
                lstProdCliente = SrvCliente.GetCliente();
                lstProdCliente.ForEach(
                    cli =>
                    {
                        lstCliente.Add(
                          new ClienteApi
                          {
                            Id_Cliente = cli.Id_Cliente,
                            Nombre = cli.Nombre,
                            Apellido = cli.Apellido,
                            Dpi = cli.Dpi,
                            Telefono = cli.Telefono,
                            TotalVentas = cli.TotalVentas
                          }
                          );

                    });

                respuesta.Datos = lstCliente;
                respuesta.CodigoOperacion = 0;
                respuesta.MensajeError = string.Empty;
                respuesta.TotalRegistros = lstProdCliente.Count;

                return Ok(respuesta);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Crear([FromBody] ClienteApi pRequest)
        {


            var ClienteInsercion = new SrvCliente();
            var InsercionCliente = new MdlClienteDb();
            try
            {
                InsercionCliente.Id_Cliente = pRequest.Id_Cliente;
                InsercionCliente.Nombre = pRequest.Nombre;
                InsercionCliente.Apellido = pRequest.Apellido;
                InsercionCliente.Dpi = pRequest.Dpi;
                InsercionCliente.Telefono = pRequest.Telefono;
                InsercionCliente.TotalVentas = pRequest.TotalVentas;
                ClienteInsercion.Insertar(InsercionCliente);
                var resp = new MdlMensajeResp();
                resp.Mensaje = "La insercion a sido exitosa";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public IActionResult Actualizar([FromBody] ClienteApi pRequest) 
        {
            var ClienteActualizacion =  new SrvCliente();
            var ActualizacionCliente = new MdlClienteDb();

            try
            {
                ActualizacionCliente.Id_Cliente = pRequest.Id_Cliente;
                ActualizacionCliente.Nombre = pRequest.Nombre;
                ActualizacionCliente.Apellido = pRequest.Apellido;
                ActualizacionCliente.Dpi = pRequest.Dpi;
                ActualizacionCliente.Telefono = pRequest.Telefono;
                ActualizacionCliente.TotalVentas = pRequest.TotalVentas;
                ClienteActualizacion.Actualizar(ActualizacionCliente);
                var resp = new MdlMensajeResp();
                resp.Mensaje = "La Actualizacion a sido exitosa";
                return Ok(resp);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        
        
        }

        

        [HttpDelete]
        public IActionResult Delete([FromBody] ClienteApi pRequest) 
        {
            var ClienteEliminacion = new SrvCliente();
            var EliminacionCliente = new MdlClienteDb();

            try
            {
                EliminacionCliente.Id_Cliente = pRequest.Id_Cliente;
                ClienteEliminacion.Eliminar(EliminacionCliente);
                var resp = new MdlMensajeResp();
                resp.Mensaje = "La Eliminacion a sido exitosa";
                return Ok(resp);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
                throw;
            }

        }

    }
}
