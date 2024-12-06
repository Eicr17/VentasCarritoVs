using CarritosVentaLibrerira.Modelos;
using CarritosVentaLibrerira.Servicios;

namespace VentasCarrito.Modelos
{
    public class MdlMensajeResp
    {
        public List<MdlClienteDb> Cliente { get; set; }
        public List<MdlProductoDb> Producto { get; set; }
        public List<MdlVentasDb> Ventas { get; set; }

        public int Total { get; set; }
        public string MensajeError { get; set; }
        public int CodigoOperacion { get; set; }
        public string Mensaje { get; set; }
    }
}
