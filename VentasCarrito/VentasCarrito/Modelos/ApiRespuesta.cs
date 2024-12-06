    namespace VentasCarrito.Modelos
{
    public class ApiRespuesta<T>
    {

        public List<T> Datos { get; set; }
        public string MensajeError { get; set; }
        public int CodigoOperacion { get; set; }
        public int TotalRegistros { get; set; }
    }
}
