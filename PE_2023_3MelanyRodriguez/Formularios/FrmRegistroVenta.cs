using Logica.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE_2023_3MelanyRodriguez.Formularios
{
    public partial class FrmRegistroVentas : Form
    {

        public Venta MiVentaLocal { get; set; }
        public DataTable ListaProductos { get; set; }
        public FrmRegistroVentas()
        {
            InitializeComponent();
            MiVentaLocal = new Venta();
            ListaProductos = new DataTable();

        }

        private void FrmRegistroVentas_Load(object sender, EventArgs e)
        {
            MdiParent = Globales.MiFormPrincipal;
            LimpiarForm();
            CargarTiposdeVenta();
        }

        private void CargarTiposdeVenta()
        {
            DataTable dtTiposVenta = new DataTable();
            dtTiposVenta = MiVentaLocal.MiTipoVenta.Listar();

            CboxVentaTipo.ValueMember = "ID";
            CboxVentaTipo.DisplayMember = "Descripcion";
            CboxVentaTipo.DataSource = dtTiposVenta;
            CboxVentaTipo.SelectedIndex = -1;
        }

        private void LimpiarForm()
        {
            TxtNombreProovedor.Clear();
            TxtNumeroVenta.Clear();
            TxtTotal.Text = "0";
            TxtTotalCantidad.Text = "0";
            CboxVentaTipo.SelectedIndex = -1;

            // se debe cargar un esquema en el datatable del detalle(ListaProductos)
            //para saber como se llaman los campos, que tipos de datos tienen y 
            //que pueda servir en el datasourse del DgvLista sin que elimine las
            //columnas hechas en el diseño
            ListaProductos = new DataTable();
            ListaProductos = MiVentaLocal.CargarEsquemaDetalle();
            DgLista.DataSource = ListaProductos;



        }
        private void BtnBuscarProovedor_Click(object sender, EventArgs e)
        {
            //se abre un nuevo formulario de busqueda de proovedor, este formulario
            //no es necesario definirlo en los globales

            Form FormBusquedaProovedor = new FrmProovedorBuscar();

            DialogResult respuesta = FormBusquedaProovedor.ShowDialog();

            if (respuesta == DialogResult.OK)
            {
                //usamos las compociciones a proovedor para extraer el valor 
                // del nombre del proovedor
                TxtNombreProovedor.Text = MiVentaLocal.MiProovedor.ProovedorNombre;
            }

        }

        private void BtnProductoAgregar_Click(object sender, EventArgs e)
        {
            Form MiFormBusquedaItem = new FrmVentaAgregarProducto();

            DialogResult respuesta = MiFormBusquedaItem.ShowDialog();

            if (respuesta == DialogResult.OK)
            {
                DgLista.DataSource = ListaProductos;

                Totalizar();
            }
        }


        private void Totalizar()
        {
            //se usa para mostrar los totales en la parte inferor del form
            if (ListaProductos.Rows.Count > 0)
            {
                //se recorre la lista de filas del datatable del detalle y 
                //se realizan las operaciones matematicas para zumarizar
                decimal totalItems = 0;
                decimal totalMonto = 0;

                foreach (DataRow row in ListaProductos.Rows)
                {
                    totalItems += Convert.ToDecimal(row["Cantidad"]);
                    //TotalItems= TotalItems+ algo
                    totalMonto += Convert.ToDecimal(row["PrecioUnitario"]) * Convert.ToDecimal(row["Cantidad"]);
                }

                TxtTotalCantidad.Text = totalItems.ToString();
                //este formato sirve para representar un valor monetario
                TxtTotal.Text = string.Format("{0:C2}", totalMonto);
            }
        }

        private void BtnCrearVenta_Click(object sender, EventArgs e)
        {
            //primero se valida que haya seleccionado un proovedor, un tipo de venta 
            //y que haya minimo una linea en el detalle 
            if (ValidarCompra())
            {
                //los pasos para agregar un encabezado detalle son:
                //1. realizar insert en el encabezado y recolectar el ID recien creado
                //teniendo claro que ese ID se genera a nivel de base de datos

                //2. Con ese ID + el id del producto teneos las dos FK para hacer el insert 
                //en la tabla de detalle

                //se agrega los datos faltantes en el encabezado
                MiVentaLocal.MiTipoVenta.TipoVentaID = Convert.ToInt32(CboxVentaTipo.SelectedValue);
                TxtNumeroVenta.Text = Convert.ToString(MiVentaLocal.VentaNumero);

                //como estoy ingresando con un boton de ingreso rapido en el login
                //no tengo datos por lo pronto wl ID sera quemado
                MiVentaLocal.MiUsuario.UsuarioID = 19;
                //MiVentaLocal.MiUsuario = Globales.MiUsuarioGobal;
                TasladoDetalleListaVisualAObjectoVenta();

                //se procede a la funcion Agregar

                if (MiVentaLocal.Agregar())
                {
                    MessageBox.Show("Venta creada correctamente!!", ":)", MessageBoxButtons.OK);
                    LimpiarForm();
                }
            }
        }
        private void TasladoDetalleListaVisualAObjectoVenta()
        {
            //pasamos los datos del datatable que se usa graficamente el el list<> 
            //del objeto mi venta local

            foreach (DataRow fila in ListaProductos.Rows)
            {
                VentaProducto nuevaventa = new VentaProducto();

                nuevaventa.MiProducto.IDProducto = Convert.ToInt32(fila["ProductoProductoID"]);
                nuevaventa.cantidad = Convert.ToDecimal(fila["Cantidad"]);
                nuevaventa.PrecioUnitario = Convert.ToDecimal(fila["PrecioUnitario"]);

                //una vez tenemos los datos en el nuevo detalle se agrega ese objeto a la lista
                //de los detalles de la venta
                MiVentaLocal.ListaVentaProductos.Add(nuevaventa);



            }
        }

        private bool ValidarCompra()
        {
            bool R = false;
            if (!string.IsNullOrEmpty(TxtNombreProovedor.Text.Trim()) &&
                CboxVentaTipo.SelectedIndex >= 0 &&
                ListaProductos.Rows.Count > 0)
            {
                R = true;
            }
            else
            {
                if (string.IsNullOrEmpty(TxtNombreProovedor.Text.Trim()))
                {
                    MessageBox.Show("Se debe seleccionar un proovedor", "Error en la validacion", MessageBoxButtons.OK);
                    return false;
                }


                if (CboxVentaTipo.SelectedIndex == -1)
                {
                    MessageBox.Show("Se debe seleccionar un tipo de venta", "Error en la validacion", MessageBoxButtons.OK);
                    return false;
                }


                if (ListaProductos.Rows.Count == 0)
                {
                    MessageBox.Show("Debe haber almenos una fila en el detalle", "Error en la validacion", MessageBoxButtons.OK);
                    return false;
                }
            }

            return R;
        }

    }
}
