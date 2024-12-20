    namespace VentasCarrito.Modelos
{
    public class ApiRespuestaListado<T>
    {
        public List<T> datos { get; set; }
        public string mensaje { get; set; }     
        public int total_registros { get; set; }
    }
}
