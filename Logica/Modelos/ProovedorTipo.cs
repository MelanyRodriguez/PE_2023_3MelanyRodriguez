using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Modelos
{
    public class ProovedorTipo
    {
        //propiedades
        public int ProovesorTipoID { get; set; }
        public string ProovedorTipoDescripcion { get; set; }

        //metodos y funciones

        public DataTable Listar()
        {
            DataTable R = new DataTable();

            Servicios.Conexion MiCnn = new Servicios.Conexion();

            R = MiCnn.EjecutarSELECT("SPProovedorTipoListar");


            return R;
        }



    }
}
