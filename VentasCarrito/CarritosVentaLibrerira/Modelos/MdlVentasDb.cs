using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritosVentaLibrerira.Modelos
{
    public class MdlVentasDb
    {
        public int IdProducto { get; set; }
        public int IdCliente { get; set; }
        public int IdVenta { get; set; }
        public string Establecimiento { get; set; }
        public decimal Precio { get; set; }
        public int CantidadProducto { get; set; }
        public DateTime  Fecha_Venta { get; set; }
        public decimal Descuento { get; set; }
        public int Existencia { get; set; }



    }
}
