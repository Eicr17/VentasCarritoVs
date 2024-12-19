using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritosVentaLibrerira.Modelos
{
    public class MdlCliente
    {
        public int Id_Cliente { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Dpi { get; set; }

        public string Telefono { get; set; }

        public double TotalVentas { get; set; }
    }

    
}
