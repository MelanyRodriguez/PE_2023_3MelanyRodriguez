using Logica.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Modelos
{
    public class TipoVenta
    {
        //propiedades
        public int TipoVentaID { get; set; }
        public string TipoVentaDescripcion { get; set; }

        //metodos y funciones

        public DataTable Listar()
        {
            DataTable R = new DataTable();
            Conexion MiCnn = new Conexion();
            R = MiCnn.EjecutarSELECT("SPVentaTipoListar");

            return R;
        }


    }
}
