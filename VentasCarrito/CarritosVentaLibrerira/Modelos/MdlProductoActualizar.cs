using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritosVentaLibrerira.Modelos
{
    public class MdlProductoActualizar
    {
        public int Id_Producto { get; set; }
        public string Nombre_Producto { get; set; }
        public int Existencia { get; set; }
        public string Marca { get; set; }
        public double Precio { get; set; }
    }
}
