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
        [Route("Obtener")]
        public IActionResult Get()
        {
            var Resp = new ApiRespuestaListado<ProductoApi>();
            var lstProdProducto = new List<MdlProducto>();
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
                                marca = prod.Marca,
                                precio = prod.Precio


                          });

                                                  
                   }
                    );
                Resp.datos = lstProducto;                
                Resp.mensaje = string.Empty;
                Resp.total_registros = lstProdProducto.Count;
                return Ok(Resp);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
                throw;
            }


        }

        [HttpPost]
        [Route("Crear")]
        public IActionResult Crear([FromBody] ProductoApi Item)
        {
            var ProductoInsercion = new SrvProducto();
            var InsercionProducto = new MdlCrearProducto();

            try
            {
                InsercionProducto.Nombre_Producto = Item.nombre_producto;
                InsercionProducto.Marca = Item.marca;
                InsercionProducto.Precio = Item.precio;
                ProductoInsercion.Insertar(InsercionProducto);
                var resp = new MdlMensajeResp();
                resp.mensaje_exitoso = "Insercion Exitosa";
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        
        }

        [HttpPut]
        [Route("Actualizar")]
        public IActionResult Actualizar([FromBody] ProductoApi Item) 
        {
            var ProductoActualizacion = new SrvProducto();
            var ActualizacionProducto = new MdlProductoActualizar();

            try
            {
                ActualizacionProducto.Id_Producto = Item.id_producto;
                ActualizacionProducto.Nombre_Producto = Item.nombre_producto;
                ActualizacionProducto.Marca = Item.marca;
                ActualizacionProducto.Precio = Item.precio;
                ProductoActualizacion.Actualizar(ActualizacionProducto);
                var resp = new MdlMensajeResp();
                resp.mensaje_exitoso = "Actualizacion Exitosa";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
               
            }
        
        
        }
        [HttpPost]
        [Route("Eliminar/{pId}")]
        public IActionResult Eliminar(int pId)
        {
            var ProductoEliminacion = new SrvProducto();
            var EliminacionProducto = new MdlProductoEliminar();
            var Resp = new ApiRespuesta();


            try
            {
                EliminacionProducto.Id_Producto = pId;
                ProductoEliminacion.Eliminar(EliminacionProducto);
                Resp.exitosa = true;
                Resp.mensaje = "El registro ha sido eliminado";
                return Ok(Resp);
            }
            catch (Exception ex )
            {
                return BadRequest(ex.Message);
                throw;
            }
        
        }

    }
}
