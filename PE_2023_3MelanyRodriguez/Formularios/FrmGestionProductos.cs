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
    public partial class FrmGestionProductos : Form

    {

        //objeto local para el proovedor
        private Logica.Modelos.Producto MiProductoLocal { get; set; }

        //lista local de los proovedores que se visualizan en el datagridview
        private DataTable ListaProducto { get; set; }

        public FrmGestionProductos()
        {
            InitializeComponent();

            MiProductoLocal = new Logica.Modelos.Producto();
            ListaProducto = new DataTable();
        }

        private void FrmGestionProductos_Load(object sender, EventArgs e)
        {
            //definimos el padre mdi
            MdiParent = Globales.MiFormPrincipal;

            CargarListaCategorias();
            CargarListaProductos();
            ActivarAgregar();
        }

        private void CargarListaProductos()
        {
            //resetar la lsta de productos haciendo re instancia en el objeto
            ListaProducto = new DataTable();

            if (CboxVerActivos.Checked)
            {
                //si en el cuadro de texto de busqueda hay 3 o mas caracteres se filtra la lista 
                string FiltroBusqueda = "";

                if (!string.IsNullOrEmpty(TxtBuscar.Text.Trim()) && TxtBuscar.Text.Count() >= 3)
                {
                    FiltroBusqueda = TxtBuscar.Text.Trim();
                }
                ListaProducto = MiProductoLocal.ListarActivos(FiltroBusqueda);
            }

            else
            {
                ListaProducto = MiProductoLocal.ListarInactivos();
            }

            DgLista.DataSource = ListaProducto;
        }


        private void CargarListaCategorias()
        {
            Logica.Modelos.CategoriaProducto MiCategoria = new Logica.Modelos.CategoriaProducto();
            DataTable dt = new DataTable();
            dt = MiCategoria.Listar();

            if (dt != null && dt.Rows.Count > 0)
            {
                CbCategoriaProducto.ValueMember = "ID";
                CbCategoriaProducto.DisplayMember = "Descrip";
                CbCategoriaProducto.DataSource = dt;
                CbCategoriaProducto.SelectedIndex = -1;
            }
        }

        private void DgLista_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DgLista.ClearSelection();
        }

        private void ActivarAgregar()
        {
            BtnAgregar.Enabled = true;
            BtnEditar.Enabled = false;
            BtnEliminar.Enabled = false;
        }

        private void ActivarEditarEliminar()
        {
            BtnAgregar.Enabled = false;
            BtnEditar.Enabled = true;
            BtnEliminar.Enabled = true;
        }

        private void DgLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //cuando seleccionamos una fila del datagidview se bebe cargar la info
            //de dicho producto en el producto local y luego dibujar esa info en los controles 
            //graficos

            if (DgLista.SelectedRows.Count == 1)
            {

                LimpiarFormulario();

                //de la coleccion de filas seleccionadasseleccionamos la fila de indice 0
                //osea la primera
                DataGridViewRow MiFila = DgLista.SelectedRows[0];

                //lo que necesito es el valor del ID del producto para realizar la consulta
                //y traer todos los datos para llenar el objeto del objeto del producto local
                int IdProducto = Convert.ToInt32(MiFila.Cells["CProductoID"].Value);

                //para no asumir riesgos se reinstancia el productolocal
                MiProductoLocal = new Logica.Modelos.Producto();

                //ahora le agregamos el valor obtenido por la fila al ID del producto local
                MiProductoLocal.IDProducto = IdProducto;

                //una vez que tengo el objeto local con el valor del id, puedor ir a consultar
                //el proovedor por ese id y llenar el resto de atributos.
                MiProductoLocal = MiProductoLocal.ConsultarPorIDRetornaProducto();

                // validamos que el producto local tenga datos 
                if (MiProductoLocal != null && MiProductoLocal.IDProducto > 0)
                {
                    //si cargamos correctamente el producto local llenamos los controles
                    TxtProductoID.Text = Convert.ToString(MiProductoLocal.IDProducto);

                    TxtProductoNombre.Text = MiProductoLocal.NombreProducto;

                    TxtCantidadStock.Text = Convert.ToString(MiProductoLocal.CantidadStock);

                    TxtCostoUnitario.Text = Convert.ToString(MiProductoLocal.CostoUnitario);

                    TxtPrecioVentaUnitario.Text = Convert.ToString(MiProductoLocal.PrecioVentaUnitario);
                    //combobox
                    CbCategoriaProducto.SelectedValue = MiProductoLocal.MiCategoria.CategoriaProductoID;

                    ActivarEditarEliminar();

                }



            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();

            DgLista.ClearSelection();

            ActivarAgregar();
        }

        private void LimpiarFormulario()
        {
            TxtProductoID.Clear();
            TxtProductoNombre.Clear();
            TxtCantidadStock.Clear();
            TxtCostoUnitario.Clear();
            TxtPrecioVentaUnitario.Clear();
            CbCategoriaProducto.SelectedIndex = -1;
        }


        private bool ValidarDatosDigitados()

        //evalua que se hayan digitadolos campos de texto en el formulario
        {
            bool R = false;

            if (!string.IsNullOrEmpty(TxtProductoNombre.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtCantidadStock.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtCostoUnitario.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtPrecioVentaUnitario.Text.Trim()))
                
            {
                R = true;
            }
            else
            {
                //que pasa su algo falta
                //nombre
                if (string.IsNullOrEmpty(TxtProductoNombre.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar un nombre para el producto", "Error de validacion", MessageBoxButtons.OK);
                    TxtProductoNombre.Focus();
                    return false;
                }

                //cantidad strock

                if (string.IsNullOrEmpty(TxtCantidadStock.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar una cantidad stock", "Error de validacion", MessageBoxButtons.OK);
                    TxtCantidadStock.Focus();
                    return false;
                }

                //Costo Unitario
                if (string.IsNullOrEmpty(TxtCostoUnitario.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar un costo unitario", "Error de validacion", MessageBoxButtons.OK);
                    TxtCostoUnitario.Focus();
                    return false;
                }
                //Costo de Venta
                if (string.IsNullOrEmpty(TxtPrecioVentaUnitario.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar un Precio de Venta", "Error de validacion", MessageBoxButtons.OK);
                    TxtPrecioVentaUnitario.Focus();
                    return false;
                }

                //rol de usuario
                if (CbCategoriaProducto.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un categoria del producto", "Error de validacion", MessageBoxButtons.OK);
                    CbCategoriaProducto.Focus();
                    return false;
                }


            }

            return R;
        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {

            if (ValidarDatosDigitados())
            {
                MiProductoLocal = new Logica.Modelos.Producto();
            //llenar los valores de los atributos con los datos digitados en el form
            MiProductoLocal.NombreProducto = TxtProductoNombre.Text.Trim();
            MiProductoLocal.CantidadStock = Convert.ToInt32(TxtCantidadStock.Text.Trim());
            MiProductoLocal.CostoUnitario = Convert.ToInt32(TxtCostoUnitario.Text.Trim());
            MiProductoLocal.PrecioVentaUnitario = Convert.ToInt32(TxtPrecioVentaUnitario.Text.Trim());

            //compocision de categoria
            MiProductoLocal.MiCategoria.CategoriaProductoID = Convert.ToInt32(CbCategoriaProducto.SelectedValue);

            string msg = string.Format("¿Esta seguro de agregar el producto {0}?", MiProductoLocal.NombreProducto);

            DialogResult respuesta = MessageBox.Show(msg, "???", MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.Yes)
            {
                bool ok = MiProductoLocal.Agregar();
                if (ok)
                {
                    MessageBox.Show("Producto guardado correctamente", "(:", MessageBoxButtons.OK);

                    LimpiarFormulario();
                    CargarListaCategorias();
                }

                else
                {
                    MessageBox.Show("El producto no se pudo guardar correctamente", "):", MessageBoxButtons.OK);
                }
            }
        }
    }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosDigitados())
            {
                //no es necesario capturar el ID desde el cuadro de texto ya que al consultarlo
                //ya tenemos datos en el ID, este ID no puede ser modificado, los demas atributos si

                MiProductoLocal.NombreProducto = TxtProductoNombre.Text.Trim();
                MiProductoLocal.CantidadStock = Convert.ToInt32(TxtCantidadStock.Text.Trim());
                MiProductoLocal.CostoUnitario = Convert.ToInt32(TxtCostoUnitario.Text.Trim());
                MiProductoLocal.PrecioVentaUnitario = Convert.ToInt32(TxtPrecioVentaUnitario.Text.Trim());
                MiProductoLocal.MiCategoria.CategoriaProductoID = Convert.ToInt32(CbCategoriaProducto.SelectedValue);

                if (MiProductoLocal.ConsultarPorID())
                {
                    DialogResult respuesta = MessageBox.Show("Esta seguro de modificar el producto", "???",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes)
                    {
                        if (MiProductoLocal.Editar())

                        {
                            MessageBox.Show("El Producto ha sido modificado correctamente", "(:", MessageBoxButtons.OK);

                            LimpiarFormulario();
                            CargarListaProductos();
                        }

                    }
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (MiProductoLocal.IDProducto > 0 && MiProductoLocal.ConsultarPorID())
            {
                //tomando en cuenta que puedo estar viendo los usuarios activos e inactivos 
                //este boton va a servir tanto para desactivar como para activar productos

                if (CboxVerActivos.Checked)
                {
                    //DESACTIVAR PRODUCTO

                    DialogResult r = MessageBox.Show("¿Esta seguro de eliminar el Producto?",
                                                       "???",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (MiProductoLocal.Eliminar())

                        {
                            MessageBox.Show("El Producto ha sido eliminado correctamente", "!!!", MessageBoxButtons.OK);
                            LimpiarFormulario();
                            CargarListaProductos();
                        }

                    }

                }

                else
                {
                    //ACTIVAR EL PRODUCTO


                    DialogResult r = MessageBox.Show("¿Esta seguro de Activar el producto?",
                                                        "???",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (MiProductoLocal.Activar())

                        {
                            MessageBox.Show("El producto ha sido activado correctamente", "!!!", MessageBoxButtons.OK);
                            LimpiarFormulario();
                            CargarListaProductos();
                        }

                    }
                }


            }
        }

        private void TxtProductoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e, true);
        }

        private void TxtCantidadStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled=Validaciones.CaracteresNumeros(e, true);
        }

        private void TxtCostoUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresNumeros(e, true);
        }

        private void TxtPrecioVentaUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresNumeros(e, true);
        }

        private void CboxVerActivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarListaProductos();

            if (CboxVerActivos.Checked)
            {
                BtnEliminar.Text = "ELIMINAR";
            }
            else
            {
                BtnEliminar.Text = "ACTIVAR";
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarListaProductos();
        }
    }

}
