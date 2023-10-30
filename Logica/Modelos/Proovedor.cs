using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica.Servicios;

namespace Logica.Modelos
{
        public class Proovedor
    {
        public int ProovedorId { get; set; }
        public string ProovedorNombre { get; set; }
        public string ProovedorCedula { get; set; }
        public string ProovedorEmail { get; set; }
        public string ProovedorDireccion { get; set; }
        public string ProovedorNotas { get; set; }
        public bool Activo { get; set; }

        public ProovedorTipo MiTipo { get; set; }

        //Constructor
        public Proovedor()
        {
            
            MiTipo = new ProovedorTipo();
        }

        public bool Agregar()
        {
            bool R = false;


            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.ProovedorNombre));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula ", this.ProovedorCedula));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", this.ProovedorEmail));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Direccion", this.ProovedorDireccion));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Notas", this.ProovedorNotas));
           
            //normalmente los foreing keys tienen que ver con compocisiones, en este caso
            //tenemos que extraer el valor del objeto compuesto 'MiTipo'
            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDTipo", this.MiTipo.ProovesorTipoID));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPProovedorAgregar");

            if (resultado > 0)
            {
                R = true;
            }

            return R;
        }
        public bool Editar()
        {
            bool R = false;


            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.ProovedorNombre));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula ", this.ProovedorCedula));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", this.ProovedorEmail));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Direccion", this.ProovedorDireccion));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Notas", this.ProovedorNotas));

            //normalmente los foreing keys tienen que ver con compocisiones, en este caso
            //tenemos que extraer el valor del objeto compuesto 'MiTipo'
            MiCnn.ListaDeParametros.Add(new SqlParameter("@IdTipo", this.MiTipo.ProovesorTipoID));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.ProovedorId));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPProovedorEditar");

            if (resultado > 0)
            {
                R = true;
            }
            return R;
        }
        public bool Eliminar()
        {
            bool R = false;


            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.ProovedorId));

            int respuesta = MiCnn.EjecutarInsertUpdateDelete("SPProovedorDesactivar");

            if (respuesta > 0)
            {
                R = true;
            }
            return R;
        }

        public bool Activar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();
            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.ProovedorId));
            int respuesta = MiCnn.EjecutarInsertUpdateDelete("SPProovedorActivar");
            if (respuesta > 0)
            {
                R = true;
            }


            return R;
        }

        public bool ConsultarPorCedula()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.ProovedorCedula));

            DataTable consulta = new DataTable();

            consulta = MiCnn.EjecutarSELECT("SPProovedorConsultarPorCedula");

            if (consulta != null && consulta.Rows.Count > 0)
            {
                R = true;
            }
            return R;
        }

        public bool ConsultarPorEmail()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", this.ProovedorEmail));

            DataTable consulta = new DataTable();

            consulta = MiCnn.EjecutarSELECT("SPProovedorConsultarPorCorreo");

            if (consulta != null && consulta.Rows.Count > 0)
            {
                R = true;
            }
            return R;

        }

        public bool ConsultarPorID()
        {
            bool R = false;


            Conexion MiCnn = new Conexion();
            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.ProovedorId));

            //necesito un datatable para capturar la info del proovedor
            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPSPProovedorConsultarPorID");
            if (dt != null && dt.Rows.Count > 0)
            {
                R = true;
            }

            return R;
        }


        public Proovedor ConsultarPorIDRetornaProovedor()
        {
            Proovedor R = new Proovedor();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.ProovedorId));

            //necesito un datatable para capturar la info del proovedor
            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPSPProovedorConsultarPorID");

            if (dt != null && dt.Rows.Count > 0)
            {
                //esta consulta deberia tener un solo registro , se crea un objeto de tipo
                //datarow para capturar la info contenida en index 0 del dt(datatable)
                DataRow dr = dt.Rows[0];

                R.ProovedorId= Convert.ToInt32(dr["ProovedorID"]);
                R.ProovedorNombre = Convert.ToString(dr["ProovedorNombre"]);
                R.ProovedorCedula = Convert.ToString(dr["ProovedorCedula"]);
                R.ProovedorEmail = Convert.ToString(dr["ProovedorEmail"]);
                R.ProovedorDireccion = Convert.ToString(dr["ProovedorDireccion"]);

                //composisiones
                R.MiTipo.ProovesorTipoID = Convert.ToInt32(dr["ProovrdorTipoID"]);
                R.MiTipo.ProovedorTipoDescripcion = Convert.ToString(dr["ProovedorTipoDescripcion"]);


            }


            return R;
            }


        public DataTable ListarActivos(bool VerActivos = true, string pFiltroBusqueda="")
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();
            //en este caso el SP tiene un parametro por lo tanto debemos definir ese parametro 
            //en el objeto conexion
            MiCnn.ListaDeParametros.Add(new SqlParameter("@VerActivos", VerActivos));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@FiltroBusqueda", pFiltroBusqueda));

            R = MiCnn.EjecutarSELECT("SPProovedorListar");
            return R;
        }

        public DataTable ListarInactivos()
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@VerActivos", false));

            R = MiCnn.EjecutarSELECT("SPProovedorListar");
            return R;

            
        }




    }
}
