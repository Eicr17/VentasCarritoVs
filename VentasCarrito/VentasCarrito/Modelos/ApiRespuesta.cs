    namespace VentasCarrito.Modelos
{
    public class ApiRespuesta<T>
    {

        public List<T> datos { get; set; }
        public string mensaje_error { get; set; }
        public int codigo_operacion { get; set; }
        public int total_registros { get; set; }
    }
}
