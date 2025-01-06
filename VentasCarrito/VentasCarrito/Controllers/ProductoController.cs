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
                                precio = prod.Precio,
                                Existencia = prod.Existencia


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
            var  SrvProductoCrear = new SrvProducto();
            var MdProdCrear = new MdlCrearProducto();

            try
            {
                MdProdCrear.Nombre_Producto = Item.nombre_producto;
                MdProdCrear.Marca = Item.marca;
                MdProdCrear.Precio = Item.precio;
                MdProdCrear.Existencia = Item.Existencia;
                SrvProductoCrear.Insertar(MdProdCrear);
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
            var SrvProdActualizar = new SrvProducto();
            var MdProdActualizar = new MdlProductoActualizar();

            try
            {
                MdProdActualizar.Id_Producto = Item.id_producto;
                MdProdActualizar.Nombre_Producto = Item.nombre_producto;
                MdProdActualizar.Marca = Item.marca;
                MdProdActualizar.Precio = Item.precio;
                MdProdActualizar.Existencia = Item.Existencia;
                SrvProdActualizar.Actualizar(MdProdActualizar);
                var resp = new MdlMensajeResp();
                resp.mensaje_exitoso = "Actualizacion Exitosa";
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
               
            }
        
        
        }
        [HttpPut]
        [Route("Eliminar/{pId}")]
        public IActionResult Eliminar(int pId)
        {
            var SrvProdEliminar = new SrvProducto();
            var MdProdEliminar = new MdlProductoEliminar();
            var Resp = new ApiRespuesta();


            try
            {
                MdProdEliminar.Id_Producto = pId;
                SrvProdEliminar.Eliminar(MdProdEliminar);
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
