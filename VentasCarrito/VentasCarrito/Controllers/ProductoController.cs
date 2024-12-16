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
                                id_producto = prod.Id_Producto,
                                nombre_producto  =  prod.Nombre_Producto,
                                existencia = prod.Existencia,
                                marca = prod.Marca,
                                precio = prod.Precio


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
            var InsercionProducto = new MdlCrearProductoDb();

            try
            {
                InsercionProducto.Nombre_Producto = Item.nombre_producto;
                InsercionProducto.Existencia = Item.existencia;
                InsercionProducto.Marca = Item.marca;
                InsercionProducto.Precio = Item.precio;
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
                ActualizacionProducto.Id_Producto = Item.id_producto;
                ActualizacionProducto.Nombre_Producto = Item.nombre_producto;
                ActualizacionProducto.Existencia = Item.existencia;
                ActualizacionProducto.Marca = Item.marca;
                ActualizacionProducto.Precio = Item.precio;
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
                EliminacionProducto.Id_Producto = Item.id_producto;
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
