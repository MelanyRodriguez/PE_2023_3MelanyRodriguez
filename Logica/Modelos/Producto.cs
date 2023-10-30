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
    public class Producto
    {
        //propiedades
        public int IDProducto { get; set; }
        public string NombreProducto { get; set; }
        public string CodigoBarras { get; set; }    
        public decimal CantidadStock { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal PrecioVentaUnitario { get; set; }
        public bool Activo { get; set; }

        public CategoriaProducto MiCategoria { get; set; }

        //Constructor
        public Producto()
        {

            MiCategoria = new CategoriaProducto();
        }

        //metodos y funciones

        public bool Agregar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.NombreProducto));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@CantidadStock ", this.CantidadStock));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@CostoUnitario", this.CostoUnitario));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@CostoVentaUnitario", this.PrecioVentaUnitario));

            //normalmente los foreing keys tienen que ver con compocisiones, en este caso
            //tenemos que extraer el valor del objeto compuesto 'MiCategoria'
            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDCategoria", this.MiCategoria.CategoriaProductoID));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPProductoAgregar");

            if (resultado >0)
            {
                R= true;
            }
            return R;
        }

        public bool Editar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.NombreProducto));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@CantidadStock ", this.CantidadStock));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@CostoUnitario", this.CostoUnitario));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@CostoVentaUnitario", this.PrecioVentaUnitario));

            //normalmente los foreing keys tienen que ver con compocisiones, en este caso
            //tenemos que extraer el valor del objeto compuesto 'MiCategoria'
            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDCategoria", this.MiCategoria.CategoriaProductoID));

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.IDProducto));

            int resultado = MiCnn.EjecutarInsertUpdateDelete("SPProductoEditar");

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

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.IDProducto));

            int respuesta = MiCnn.EjecutarInsertUpdateDelete("SPProductoDesactivar");

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
            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.IDProducto));
            int respuesta = MiCnn.EjecutarInsertUpdateDelete("SPProductoActivar");
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
            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.IDProducto));

            //necesito un datatable para capturar la info del Usuario
            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPProductoConsultarPorID");
            if (dt != null && dt.Rows.Count > 0)
            {
                R = true;
            }

            return R;
        }


        public Producto ConsultarPorIDRetornaProducto()
        {
            Producto R = new Producto();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.IDProducto));

            //necesito un datatable para capturar la info del producto
            DataTable dt = new DataTable();

            dt = MiCnn.EjecutarSELECT("SPProductoConsultarPorID");

            if (dt != null && dt.Rows.Count > 0)
            {
                //esta consulta deberia tener un solo registro , se crea un objeto de tipo
                //datarow para capturar la info contenida en index 0 del dt(datatable)
                DataRow dr = dt.Rows[0];

                R.IDProducto = Convert.ToInt32(dr["ProductoID"]);
                R.NombreProducto = Convert.ToString(dr["ProductoNombre"]);
                R.CantidadStock = Convert.ToInt32(dr["CantidadStock"]);
                R.CostoUnitario = Convert.ToInt32(dr["CostoUnitario"]);
                R.PrecioVentaUnitario = Convert.ToInt32(dr["PrecioVentaUnitario"]);

                //composisiones
                R.MiCategoria.CategoriaProductoID = Convert.ToInt32(dr["CategoriaID"]);
                R.MiCategoria.CategoriaDescripcion = Convert.ToString(dr["CategoriaDescripcion"]);


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

            R = MiCnn.EjecutarSELECT("SPProductoListar");
            return R;
        }

        public DataTable ListarInactivos()
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@VerActivos", false));

            R = MiCnn.EjecutarSELECT("SPProductoListar");
            return R;

            
        }

        //nueva funcion para mostrar la lista de items en la lista de busqueda
        //de productos
        public DataTable ListarEnBusqueda()
        {
            DataTable R = new DataTable();
            Conexion MiCnn =new Conexion();
            R = MiCnn.EjecutarSELECT("SPProductoBusquedaListar");
            return R;
        }

    }
}
