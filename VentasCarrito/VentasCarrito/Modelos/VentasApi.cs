namespace VentasCarrito.Modelos
{
    public class VentasApi
    {
        public int id_producto { get; set; }
        public int id_cliente { get; set; }
        public int id_venta { get; set; }
        public string establecimiento { get; set; }
        public decimal precio { get; set; }
        public int cantidad_producto { get; set; }
        public DateTime fecha_venta { get; set; }
        public decimal descuento { get; set; }
        public int existencia { get; set; }

    }
}
