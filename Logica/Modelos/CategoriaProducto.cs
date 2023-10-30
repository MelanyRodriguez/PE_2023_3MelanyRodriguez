using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Modelos
{
    public class CategoriaProducto
    {
        //propiedades
        public int CategoriaProductoID { get; set; }
        public string CategoriaDescripcion { get; set; }

        //metodos y funciones

        public DataTable Listar()
        {
            DataTable R = new DataTable();


            Servicios.Conexion MiCnn = new Servicios.Conexion();

            R = MiCnn.EjecutarSELECT("SPCategoriaProductoListar");

            return R;
        }


    }
}
