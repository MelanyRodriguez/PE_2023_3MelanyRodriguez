using Logica.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE_2023_3MelanyRodriguez.Formularios
{
    public partial class FrmVentaAgregarProducto : Form
    {
        DataTable ListaProductos { get; set;}
        Producto MiProductoLocal { get; set; }
        public FrmVentaAgregarProducto()
        {
            InitializeComponent();
            ListaProductos = new DataTable();
            MiProductoLocal = new Producto();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (DgvLista.SelectedRows.Count==1)
            {
                // se extraen los balores del producto de la fila seleccionada
                DataGridViewRow row = DgvLista.SelectedRows[0];

                int IdProducto = Convert.ToInt32(row.Cells["CProductoID"].Value);
                string NombreProducto = Convert.ToString(row.Cells["CProductoNombre"].Value);
                string CodigoBarras = Convert.ToString(row.Cells["CProductoCodigoBarras"].Value);
                decimal Precio = Convert.ToDecimal(row.Cells["CPrecioVentaUnitario"].Value);
                decimal Cantidad = NumUDCantidad.Value;

                //se crea una nueva fila de datatable de detalle de formulario
                //de registro de venta y ademas se asigna los valores recolectados
                DataRow MiFila = Globales.MiFormRegistroVentas.ListaProductos.NewRow();

                MiFila["ProductoProductoID"] = IdProducto;
                MiFila["Cantidad"] = Cantidad;
                MiFila["PrecioUnitario"] = Precio;
                MiFila["ProductoNombre"] = NombreProducto;
                MiFila["ProductoCodigoBarras"] = CodigoBarras;

                Globales.MiFormRegistroVentas.ListaProductos.Rows.Add(MiFila);

                DialogResult = DialogResult.OK;




            }

           

        }

        private void FrmVentaAgregarProducto_Load(object sender, EventArgs e)
        {
            LlenarLista();
        }
        private void LlenarLista()
        {
            ListaProductos = new DataTable();
            ListaProductos = MiProductoLocal.ListarEnBusqueda();
            DgvLista.DataSource = ListaProductos;
            DgvLista.ClearSelection();
        }
    }
}
