using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritosVentaLibrerira.Modelos
{
    public  class MdlVentasCrear
    {
        public int Id_Producto { get; set; }
        public int Id_Cliente { get; set; }

        public string Establecimiento { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad_Producto { get; set; }
        public DateTime Fecha_Venta { get; set; }
        public decimal Descuento { get; set; }

    }
}
