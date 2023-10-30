using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Modelos
{
    public class VentaProducto
    {
        public decimal cantidad {  get; set; }
        public decimal PrecioUnitario { get; set; }

        public Producto MiProducto { get; set; }

        public VentaProducto() 
        { 
            MiProducto = new Producto();
        }
      
    }
}
