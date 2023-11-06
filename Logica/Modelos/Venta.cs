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
    public class Venta
    {
        //propiedades
        public int VentID { get; set; }
        public DateTime VentaFecha { get; set; }
        public int VentaNumero { get; set; }
        public string VentaDia { get; set; }
        public bool Activo { get; set; }

        //Composiciones simples
        public Usuario MiUsuario { get; set; }
        public Proovedor MiProovedor { get; set; }
        public TipoVenta MiTipoVenta { get; set; }

        //Composiciones en lista o complejas 
        public List<VentaProducto> ListaVentaProductos { get; set; }

        //constructor
        public Venta ()
        {
            MiUsuario = new Usuario ();
            MiProovedor= new Proovedor ();
            MiTipoVenta = new TipoVenta ();
            ListaVentaProductos = new List<VentaProducto> ();
        }

        //funciones 
        public DataTable CargarEsquemaDetalle()
        {
            DataTable R = new DataTable ();
            Conexion MiCnn = new Conexion ();
            R = MiCnn.EjecutarSELECT("SPVentaDetalleEsquema", true);

            //como estamos cargando el esquema, tambien viene la indicacion del 
            //PK se debe anular esa opcion
            R.PrimaryKey = null;


            return R;
        }

        public bool Agregar()
        {
            bool R = false;


            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDProovedor", this.MiProovedor.ProovedorId));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDTipoVenta  ", this.MiTipoVenta.TipoVentaID));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@IDUsuario", this.MiUsuario.UsuarioID));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@VentaNumero", this.VentaNumero));

            Object retorno = MiCnn.EjecutarSELECTEscalar("SPVentaAgregar");

            // como la devolucion puede ser de cualquier tipo (string, int,decimal)
            //se captura la respuesta en un Object y luego se hace la convercion al
            //tipo correcto en este caso es un int

            int IDCreada;
            if (retorno != null)
            {
                try
                {
                    IDCreada = Convert.ToInt32(retorno.ToString());
                    this.VentID = IDCreada;

                    //hasta este punto se puede asegurar que el insert en el detalle salio correctamente
                    //se procede con los insert en el detalle

                    foreach(VentaProducto item in this.ListaVentaProductos)
                    {
                       Conexion MiCnnDetalle = new Conexion();

                        //lista del insert de detalle
                        MiCnnDetalle.ListaDeParametros.Add(new SqlParameter("@IDVenta",IDCreada));
                        MiCnnDetalle.ListaDeParametros.Add(new SqlParameter("@IDProducto", item.MiProducto.IDProducto));
                        MiCnnDetalle.ListaDeParametros.Add(new SqlParameter("@Cantidad", item.cantidad));
                        MiCnnDetalle.ListaDeParametros.Add(new SqlParameter("@Precio", item.PrecioUnitario));

                        MiCnnDetalle.EjecutarInsertUpdateDelete("SPVentaProductoAgregar");

                    }
                    R = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }


            return R;
        }

      


    }
}
