using Logica.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Modelos
{
    public class Usuario
    {

        //propiedades

        public int UsuarioID { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioCorreo { get; set; }
        public string UsuarioContrasenia { get; set; }
        public string UsuarioCedula { get; set; }
        public string UsuarioDireccion { get; set; }
        public string UsuarioTelefono { get; set; }
        public bool Activo { get; set; }

        //propiedades compuestas

        public UsuarioRol MiRolTipo { get; set; }

        //cuando tenemos propiedades compuestas con tipos que hemos programado nosotros
        //debemos instanciar dichas propiedades ya que son objetos

        //Constructor
        public Usuario()
        {
            //al crear una nueva instancia de la clase Usuario, se ejecuta el codigo 
            //del constructor y tambien se crea una instancia de la clase usuarioRol
            MiRolTipo = new UsuarioRol();
        }

        //Funciones y metodos 

        public bool Agregar ()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.UsuarioNombre));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo ", this.UsuarioCorreo));

            //Encriptar Contraseña
            Crypto MiEncriptador = new Crypto();
            string ContrasenniaEncriptada = MiEncriptador.EncriptarEnUnSentido(this.UsuarioContrasenia);
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Contrasenia",ContrasenniaEncriptada));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.UsuarioCedula));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Direccion", this.UsuarioDireccion));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Telefono", this.UsuarioTelefono));

            //normalmente los foreing keys tienen que ver con compocisiones, en este caso
            //tenemos que extraer el valor del objeto compuesto 'MiRolTipo'
            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDRol", this.MiRolTipo.UsuarioRolID));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPUsuarioAgregar");

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

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.UsuarioNombre));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo ", this.UsuarioCorreo));
            //Encriptar Contraseña
            Crypto MiEncriptador = new Crypto();
            string ContrasenniaEncriptada = MiEncriptador.EncriptarEnUnSentido(this.UsuarioContrasenia);
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Contrasennia", ContrasenniaEncriptada));

            
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.UsuarioCedula));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Direccion", this.UsuarioDireccion));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Telefono", this.UsuarioTelefono));

            //normalmente los foreing keys tienen que ver con compocisiones, en este caso
            //tenemos que extraer el valor del objeto compuesto 'MiRolTipo'
            MiCnn.ListaDeParametros.Add(new SqlParameter("@IdRol", this.MiRolTipo.UsuarioRolID));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.UsuarioID));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPUsuarioEditar");

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

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.UsuarioID));

            int respuesta = MiCnn.EjecutarInsertUpdateDelete("SPUsuarioDesactivar");

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
            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.UsuarioID));
            int respuesta = MiCnn.EjecutarInsertUpdateDelete("SPUsuarioActivar");
            if (respuesta > 0)
            {
                R = true;
            }


            return R;
        }
        public bool ConsultarPorID()
        {
            bool R = false;
          
          Conexion MiCnn = new Conexion();
          MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.UsuarioID));

            //necesito un datatable para capturar la info del Usuario
            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPUsuarioConsultarPorID");
            if (dt != null && dt.Rows.Count >0)
            {
                R=true;
            }

            return R;
        }

        public Usuario ConsultarPorIDRetornaUsuario()
        {
            Usuario R = new Usuario();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID",this.UsuarioID));

            //necesito un datatable para capturar la info del usuario
            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPUsuarioConsultarPorID");

            if (dt!= null && dt.Rows.Count >0)
            {
                //esta consulta deberia tener un solo registro , se crea un objeto de tipo
                //datarow para capturar la info contenida en index 0 del dt(datatable)
                DataRow dr = dt.Rows[0];
                  
                R.UsuarioID= Convert.ToInt32(dr["UsuarioID"]);
                R.UsuarioNombre = Convert.ToString(dr["UsuarioNombre"]);
                R.UsuarioCedula = Convert.ToString(dr["UsuarioCedula"]);
                R.UsuarioTelefono = Convert.ToString(dr["UsuarioTelefono"]);
                R.UsuarioCorreo = Convert.ToString(dr["UsuarioCorreo"]);
                R.UsuarioDireccion = Convert.ToString(dr["UsuarioDireccion"]);

                R.UsuarioContrasenia= string.Empty;

                //composisiones
                R.MiRolTipo.UsuarioRolID = Convert.ToInt32(dr["UsuarioRolID"]);
                R.MiRolTipo.UsuarioRolDescripcion = Convert.ToString(dr["Descripcion"]);


            }


            return R;
        }

        public bool ConsultarPorCedula()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.UsuarioCedula));

            DataTable consulta = new DataTable();

            consulta = MiCnn.EjecutarSELECT("SPUsuarioConsultarPorCedula");

           if (consulta != null && consulta.Rows.Count >0 )
            {
                R = true;
            }

            return R;
        }

        public bool ConsultarPorCorreo()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", this.UsuarioCorreo));

            DataTable consulta = new DataTable();

            consulta = MiCnn.EjecutarSELECT("SPUsuarioConsultarPorCorreo");

            if (consulta != null && consulta.Rows.Count > 0)
            {
                R = true;
            }

            return R;
        }

        public DataTable ListarActivos(string pFiltroBusqueda)
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();
            //en este caso el SP tiene un parametro por lo tanto debemos definir ese parametro 
            //en el objeto conexion
            MiCnn.ListaDeParametros.Add(new SqlParameter("@VerActivos", true));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@FiltroBusqueda", pFiltroBusqueda));

            R = MiCnn.EjecutarSELECT("SPUsuarioListar");

            return R;
        }

        public DataTable ListarInactivos()
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();
            //en este caso el SP tiene un parametro por lo tanto debemos definir ese parametro 
            //en el objeto conexion
            MiCnn.ListaDeParametros.Add(new SqlParameter("@VerActivos", false));

            R = MiCnn.EjecutarSELECT("SPUsuarioListar");
            return R;
        }

        public Usuario ValidarUsuario(string pEmail, string pContrasenia)

        {
            Usuario R = new Usuario();

            Conexion MiCnn = new Conexion();

            Crypto crypto = new Crypto();
            string ContrasenniaEncriptada = crypto.EncriptarEnUnSentido(pContrasenia);

            MiCnn.ListaDeParametros.Add(new SqlParameter("@usuario", pEmail));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@password", ContrasenniaEncriptada));

            //necesito un datatable para capturar la info del usuario
            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPUsuarioValidarIngreso");

            if (dt != null && dt.Rows.Count > 0)
            {
                //esta consulta deberia tener un solo registro , se crea un objeto de tipo
                //datarow para capturar la info contenida en index 0 del dt(datatable)
                DataRow dr = dt.Rows[0];

                R.UsuarioID = Convert.ToInt32(dr["UsuarioID"]);
                R.UsuarioNombre = Convert.ToString(dr["UsuarioNombre"]);
                R.UsuarioCedula = Convert.ToString(dr["UsuarioCedula"]);
                R.UsuarioTelefono = Convert.ToString(dr["UsuarioTelefono"]);
                R.UsuarioCorreo = Convert.ToString(dr["UsuarioCorreo"]);
                R.UsuarioDireccion = Convert.ToString(dr["UsuarioDireccion"]);

                R.UsuarioContrasenia = string.Empty;

                //composisiones
                R.MiRolTipo.UsuarioRolID = Convert.ToInt32(dr["UsuarioRolID"]);
                R.MiRolTipo.UsuarioRolDescripcion = Convert.ToString(dr["Descripcion"]);


            }


            return R;
        }




    }
}
