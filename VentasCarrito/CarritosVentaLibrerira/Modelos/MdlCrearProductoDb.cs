using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritosVentaLibrerira.Modelos
{
    public class MdlCrearProductoDb
    {
        public string Nombre_Producto { get; set; }
        public int Existencia { get; set; }
        public string Marca { get; set; }
        public decimal Precio { get; set; }
    }
}
