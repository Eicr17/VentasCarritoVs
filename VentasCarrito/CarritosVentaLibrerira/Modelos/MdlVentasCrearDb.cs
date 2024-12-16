using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritosVentaLibrerira.Modelos
{
    public  class MdlVentasCrearDb
    {
        public string Establecimiento { get; set; }
        public decimal Precio { get; set; }
        public int CantidadProducto { get; set; }
        public DateTime Fecha_Venta { get; set; }
        public decimal Descuento { get; set; }

    }
}
