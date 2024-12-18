using CarritosVentaLibrerira.Modelos;
using CarritosVentaLibrerira.Servicios;

namespace VentasCarrito.Modelos
{
    public class MdlMensajeResp
    {
        public int total { get; set; }
        public string mensaje_error { get; set; }
        public int codigo_operacion { get; set; }
        public string mensaje_exitoso { get; set; }
    }
}
