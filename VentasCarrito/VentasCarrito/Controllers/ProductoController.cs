using CarritosVentaLibrerira.Modelos;
using CarritosVentaLibrerira.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VentasCarrito.Modelos;

namespace VentasCarrito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var Resp = new ApiRespuesta<ProductoApi>();
            var lstProdProducto = new List<MdlProductoDb>();
            var lstProducto = new List<ProductoApi>();

            try
            {
                lstProdProducto = SrvProducto.ObtenerProducto();

                lstProdProducto.ForEach(
                    prod =>
                    {
                        lstProducto.Add(
                            new ProductoApi
                            {
                                Id_Producto = prod.Id_Producto,
                                Nombre_Producto  =  prod.Nombre_Producto,
                                Existencia = prod.Existencia,
                                Marca = prod.Marca,
                                Precio = prod.Precio


                          });

                                                  
                   }
                    );
                Resp.Datos = lstProducto;
                Resp.CodigoOperacion = 0;
                Resp.MensajeError = string.Empty;
                Resp.TotalRegistros = lstProdProducto.Count;
                return Ok(Resp);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
                throw;
            }


        }

        [HttpPost]
        public IActionResult Crear([FromBody] ProductoApi Item)
        {
            var ProductoInsercion = new SrvProducto();
            var InsercionProducto = new MdlProductoDb();

            try
            {
                InsercionProducto.Id_Producto = Item.Id_Producto;
                InsercionProducto.Nombre_Producto = Item.Nombre_Producto;
                InsercionProducto.Existencia = Item.Existencia;
                InsercionProducto.Marca = Item.Marca;
                InsercionProducto.Precio = Item.Precio;
                ProductoInsercion.Insertar(InsercionProducto);
                var resp = new MdlMensajeResp();
                resp.Mensaje = "Insercion Exitosa";
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        
        }


        [HttpPut]
        public IActionResult Actualizar([FromBody] ProductoApi Item) 
        {
            var ProductoActualizacion = new SrvProducto();
            var ActualizacionProducto = new MdlProductoDb();

            try
            {
                ActualizacionProducto.Id_Producto = Item.Id_Producto;
                ActualizacionProducto.Nombre_Producto = Item.Nombre_Producto;
                ActualizacionProducto.Existencia = Item.Existencia;
                ActualizacionProducto.Marca = Item.Marca;
                ActualizacionProducto.Precio = Item.Precio;
                ProductoActualizacion.Actualziar(ActualizacionProducto);
                var resp = new MdlMensajeResp();
                resp.Mensaje = "Actualizacion Exitosa";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
               
            }
        
        
        }

        [HttpDelete]
        public IActionResult Eliminar([FromBody] ProductoApi Item)
        {
            var ProductoEliminacion = new SrvProducto();
            var EliminacionProducto = new MdlProductoDb();

            try
            {
                EliminacionProducto.Id_Producto = Item.Id_Producto;
                ProductoEliminacion.Eliminar(EliminacionProducto);
                var resp = new MdlMensajeResp();
                resp.Mensaje = "Eliminacion Exitosa";
                return Ok(resp);
            }
            catch (Exception ex )
            {
                return BadRequest(ex.Message);
                throw;
            }
        
        }

    }
}
