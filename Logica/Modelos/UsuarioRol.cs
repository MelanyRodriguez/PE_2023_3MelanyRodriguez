using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Modelos
{
    public class UsuarioRol
    {
        //propiedades
        public int UsuarioRolID { get; set; }
        public string UsuarioRolDescripcion { get; set; }

        //metodos y funciones

        public DataTable Listar()
        {
            DataTable R=new DataTable();

            Servicios.Conexion MiCnn = new Servicios.Conexion();

            R = MiCnn.EjecutarSELECT("SPUsuarioRolListar");

            return R;
        }

    }
}
