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
    public partial class FrmProovedorGestion : Form
    {

        //objeto local para el proovedor
        private Logica.Modelos.Proovedor MiProovedorLocal { get; set; }

        //lista local de los proovedores que se visualizan en el datagridview
        private DataTable ListaProovedor { get; set; }


        public FrmProovedorGestion()
        {
            InitializeComponent();

            MiProovedorLocal = new Logica.Modelos.Proovedor();
            ListaProovedor = new DataTable();
        }

        private void FrmProovedorGestion_Load(object sender, EventArgs e)
        {
            //definimos el padre mdi
            MdiParent = Globales.MiFormPrincipal;

            CargarListaTipos();
            CargarListaProovedores();
            ActivarAgregar();
        }

        private void CargarListaProovedores()
        {
            //resetar la lsta de proovedores haciendo re instancia en el objeto
            ListaProovedor = new DataTable();

            if (CboxVerActivos.Checked)
            {
                //si en el cuadro de texto de busqueda hay 3 o mas caracteres se filtra la lista 
                string FiltroBusqueda = "";

                if (!string.IsNullOrEmpty(TxtBuscar.Text.Trim()) && TxtBuscar.Text.Count() >= 3)
                {
                    FiltroBusqueda = TxtBuscar.Text.Trim();
                }
                ListaProovedor = MiProovedorLocal.ListarActivos(true,FiltroBusqueda);
            }

            else
            {
                ListaProovedor = MiProovedorLocal.ListarInactivos();
            }

            DgLista.DataSource = ListaProovedor;
        }

        private void CargarListaTipos()
        {
            Logica.Modelos.ProovedorTipo MiTipo = new Logica.Modelos.ProovedorTipo();
            DataTable dt = new DataTable();
            dt = MiTipo.Listar();

            if (dt != null && dt.Rows.Count > 0)
            {
                CbProovedorTipo.ValueMember = "ID";
                CbProovedorTipo.DisplayMember = "Descrip";
                CbProovedorTipo.DataSource = dt;
                CbProovedorTipo.SelectedIndex = -1;
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
            //de dicho proovedor en el proovedor local y luego dibujar esa info en los controles 
            //graficos

            if (DgLista.SelectedRows.Count == 1)
            {
                LimpiarFormulario();

                //de la coleccion de filas seleccionadasseleccionamos la fila de indice 0
                //osea la primera
                DataGridViewRow MiFila = DgLista.SelectedRows[0];

                //lo que necesito es el valor del ID del proovedor para realizar la consulta
                //y traer todos los datos para llenar el objeto del objeto del proovedor local
                int IdProovedor = Convert.ToInt32(MiFila.Cells["CProovedorID"].Value);

                //para no asumir riesgos se reinstancia el proovedor local
                MiProovedorLocal = new Logica.Modelos.Proovedor();

                //ahora le agregamos el valor obtenido por la fila al ID del proovedor local
                MiProovedorLocal.ProovedorId = IdProovedor;

                //una vez que tengo el objeto local con el valor del id, puedor ir a consultar
                //el proovedor por ese id y llenar el resto de atributos.
                MiProovedorLocal = MiProovedorLocal.ConsultarPorIDRetornaProovedor();

                // validamos que el proovedor local tenga datos 
                if (MiProovedorLocal != null && MiProovedorLocal.ProovedorId > 0)
                {
                    //si cargamos correctamente el proovedor local llenamos los controles
                    TxtProovedorID.Text = Convert.ToString(MiProovedorLocal.ProovedorId);

                    TxtProovedorNombre.Text = MiProovedorLocal.ProovedorNombre;

                    TxtProovedorCedula.Text = MiProovedorLocal.ProovedorCedula;

                    TxtProovedorEmail.Text = MiProovedorLocal.ProovedorEmail;

                    TxtProovedorDireccion.Text = MiProovedorLocal.ProovedorDireccion;

                    //combobox
                    CbProovedorTipo.SelectedValue = MiProovedorLocal.MiTipo.ProovesorTipoID;

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
            TxtProovedorID.Clear();
            TxtProovedorNombre.Clear();
            TxtProovedorCedula.Clear();
            TxtProovedorEmail.Clear();
            TxtProovedorDireccion.Clear();
            TxtProovedorNotas.Clear();
            CbProovedorTipo.SelectedIndex = -1;
        }

        private bool ValidarDatosDigitados()

        //evalua que se hayan digitadolos campos de texto en el formulario
        {
            bool R = false;

            if (!string.IsNullOrEmpty(TxtProovedorNombre.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtProovedorCedula.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtProovedorEmail.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtProovedorDireccion.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtProovedorNotas.Text.Trim()) &&
                CbProovedorTipo.SelectedIndex > -1)

            {
                R = true;
            }
            else
            {
                //que pasa su algo falta
                //nombre
                if (string.IsNullOrEmpty(TxtProovedorNombre.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar un nombre para el proovedor", "Error de validacion", MessageBoxButtons.OK);
                    TxtProovedorNombre.Focus();
                    return false;
                }

                //cedula

                if (string.IsNullOrEmpty(TxtProovedorCedula.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar una cedula para el proovedor", "Error de validacion", MessageBoxButtons.OK);
                    TxtProovedorCedula.Focus();
                    return false;
                }

                //correo
                if (string.IsNullOrEmpty(TxtProovedorEmail.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar un correo para el proovedor", "Error de validacion", MessageBoxButtons.OK);
                    TxtProovedorEmail.Focus();
                    return false;
                }

                //direccion
                if (string.IsNullOrEmpty(TxtProovedorDireccion.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar una direccion para el proovedor", "Error de validacion", MessageBoxButtons.OK);
                    TxtProovedorDireccion.Focus();
                    return false;
                }

                //notas
                if (string.IsNullOrEmpty(TxtProovedorNotas.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar las notas para el proovedor", "Error de validacion", MessageBoxButtons.OK);
                    TxtProovedorNotas.Focus();
                    return false;
                }



                //tipo de proovedor
                if (CbProovedorTipo.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un tipo para el proovedor", "Error de validacion", MessageBoxButtons.OK);
                    CbProovedorTipo.Focus();
                    return false;
                }


            }

            return R;
        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {

            if (ValidarDatosDigitados())
            {
                bool CedulaOK;
                bool EmailOK;

                MiProovedorLocal = new Logica.Modelos.Proovedor();
                //llenar los valores de los atributos con los datos digitados en el form
                MiProovedorLocal.ProovedorNombre = TxtProovedorNombre.Text.Trim();
                MiProovedorLocal.ProovedorCedula = TxtProovedorCedula.Text.Trim();
                MiProovedorLocal.ProovedorEmail = TxtProovedorEmail.Text.Trim();
                MiProovedorLocal.ProovedorDireccion = TxtProovedorDireccion.Text.Trim();
                MiProovedorLocal.ProovedorNotas = TxtProovedorNotas.Text.Trim();
                //compocision del tipo Proovedor
                MiProovedorLocal.MiTipo.ProovesorTipoID = Convert.ToInt32(CbProovedorTipo.SelectedValue);


                //realizar las consultas por correo y por cedula 

                CedulaOK = MiProovedorLocal.ConsultarPorCedula();

                EmailOK = MiProovedorLocal.ConsultarPorEmail();

                string msg = string.Format("¿Esta seguro de agregar el proovedor {0}?", MiProovedorLocal.ProovedorNombre);

                DialogResult respuesta = MessageBox.Show(msg, "???", MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    bool ok = MiProovedorLocal.Agregar();
                    if (ok)
                    {
                        MessageBox.Show("Proovedor guardado correctamente", "(:", MessageBoxButtons.OK);

                        LimpiarFormulario();
                        CargarListaProovedores();
                    }

                    else
                    {
                        MessageBox.Show("El Proovedor no se pudo guardar correctamente", "):", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    //indicar al usuario si falta una consulta

                    if (CedulaOK)
                    {
                        MessageBox.Show("Ya existe un proovedor con la cedula digitada", "Error en validacion", MessageBoxButtons.OK);
                        return;
                    }


                    if (EmailOK)
                    {
                        MessageBox.Show("Ya existe un proovedor con el correo digitado", "Error en validacion", MessageBoxButtons.OK);
                        return;
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

                MiProovedorLocal.ProovedorNombre = TxtProovedorNombre.Text.Trim();
                MiProovedorLocal.ProovedorCedula = TxtProovedorCedula.Text.Trim();
                MiProovedorLocal.ProovedorEmail = TxtProovedorEmail.Text.Trim();
                MiProovedorLocal.ProovedorDireccion = TxtProovedorDireccion.Text.Trim();
                MiProovedorLocal.ProovedorNotas = TxtProovedorNotas.Text.Trim();
                MiProovedorLocal.MiTipo.ProovesorTipoID = Convert.ToInt32(CbProovedorTipo.SelectedValue);



                if (MiProovedorLocal.ConsultarPorID())
                {
                    DialogResult respuesta = MessageBox.Show("Esta seguro de modificar el Proovedor", "???",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes)
                    {
                        if (MiProovedorLocal.Editar())

                        {
                            MessageBox.Show("El Proovedor ha sido modificado correctamente", "(:", MessageBoxButtons.OK);

                            LimpiarFormulario();
                            CargarListaProovedores();
                        }

                    }
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (MiProovedorLocal.ProovedorId > 0 && MiProovedorLocal.ConsultarPorID())
            {
                //tomando en cuenta que puedo estar viendo los usuarios activos e inactivos 
                //este boton va a servir tanto para desactivar como para activar proovedores

                if (CboxVerActivos.Checked)
                {
                    //DESACTIVAR PROOVEDOR

                    DialogResult r = MessageBox.Show("¿Esta seguro de eliminar el Proovedor?",
                                                       "???",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (MiProovedorLocal.Eliminar())

                        {
                            MessageBox.Show("El proovedor ha sido eliminado correctamente", "!!!", MessageBoxButtons.OK);
                            LimpiarFormulario();
                            CargarListaProovedores();
                        }

                    }

                }

                else
                {
                    //ACTIVAR EL PROOVEDOR


                    DialogResult r = MessageBox.Show("¿Esta seguro de Activar el Proovedor?",
                                                        "???",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (MiProovedorLocal.Activar())

                        {
                            MessageBox.Show("El Proovedor ha sido activado correctamente", "!!!", MessageBoxButtons.OK);
                            LimpiarFormulario();
                            CargarListaProovedores();
                        }

                    }
                }


            }
        }

        private void TxtProovedorNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e, true);
        }

        private void TxtProovedorCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresNumeros(e, true);
        }

        private void TxtProovedorEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e, false, true);
        }

        private void TxtProovedorDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e, true);
        }

        private void TxtProovedorNotas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e, true);
        }

        private void TxtProovedorEmail_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtProovedorEmail.Text.Trim()))
            {
                if (!Validaciones.ValidarEmail(TxtProovedorEmail.Text.Trim()))

                {
                    MessageBox.Show("El formato del correo es incorrecto", "Error en validacion", MessageBoxButtons.OK);

                    TxtProovedorEmail.Focus();
                }
            }
        }

        private void TxtProovedorEmail_Enter(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TxtProovedorEmail.Text.Trim()))
            {
                TxtProovedorEmail.DeselectAll();
                TxtProovedorEmail.SelectAll();
            }

        }

        private void CboxVerActivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarListaProovedores();

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
            CargarListaProovedores();
        }
    }
}
