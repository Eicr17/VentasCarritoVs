﻿using Microsoft.AspNetCore.Http;
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
            var respuesta = new ApiRespuesta<ClienteApi>();
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
                respuesta.codigo_operacion = 0;
                respuesta.mensaje_error = string.Empty;
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


            var ClienteInsercion = new SrvCliente();
            var InsercionCliente = new MdlClienteCrear();
            try
            {
                InsercionCliente.Nombre = pRequest.nombre;
                InsercionCliente.Apellido = pRequest.apellido;
                InsercionCliente.Dpi = pRequest.dpi;
                InsercionCliente.Telefono = pRequest.telefono;
                InsercionCliente.TotalVentas = pRequest.totalventas;
                ClienteInsercion.Insertar(InsercionCliente);
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
            var ClienteActualizacion =  new SrvCliente();
            var ActualizacionCliente = new MdlClienteActualizar();

            try
            {
                ActualizacionCliente.Id_Cliente = pRequest.id_cliente;
                ActualizacionCliente.Nombre = pRequest.nombre;
                ActualizacionCliente.Apellido = pRequest.apellido;
                ActualizacionCliente.Dpi = pRequest.dpi;
                ActualizacionCliente.Telefono = pRequest.telefono;
                ActualizacionCliente.TotalVentas = pRequest.totalventas;
                ClienteActualizacion.Actualizar(ActualizacionCliente);
                var resp = new MdlMensajeResp();
                resp.mensaje_exitoso = "La Actualizacion a sido exitosa";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        
        }

        

        [HttpPost]
        [Route("Eliminar")]
        public IActionResult Delete([FromBody] ClienteApi pRequest) 
        {
            var ClienteEliminacion = new SrvCliente();
            var EliminacionCliente = new MdlClienteEliminar();

            try
            {
                EliminacionCliente.Id_Cliente = pRequest.id_cliente;
                ClienteEliminacion.Eliminar(EliminacionCliente);
                var resp = new MdlMensajeResp();
                resp.mensaje_exitoso = "La Eliminacion a sido exitosa";
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
