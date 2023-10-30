using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE_2023_3MelanyRodriguez.Formularios
{
    public partial class FrmUsuarioGestion : Form
    {

        //por orden es mejor crear objetos locales que permitan la gestion del tema
        //que estamos tratando, usar objetos individuales en la funcion puede 
        //provocar desorden y complicar la lectura del codigo

        //objeto local para el usuario
        private Logica.Modelos.Usuario MiUsuarioLocal { get; set; }

        //lista local de los usuarios que se visualizan en el datagridview
        private DataTable ListaUsuario { get; set; }




        public FrmUsuarioGestion()
        {
            InitializeComponent();

            MiUsuarioLocal= new Logica.Modelos.Usuario();
            ListaUsuario= new DataTable();
        }

        private void FrmUsuarioGestion_Load(object sender, EventArgs e)
        {
            //definimos el padre mdi
            MdiParent = Globales.MiFormPrincipal;

            CargarListaRoles();
            CargarListaUsuarios();
            ActivarAgregar();
        }

        private void CargarListaUsuarios()
        {
            //resetar la lsta de usuarios haciendo re instancia en el objeto
            ListaUsuario= new DataTable();

            if (CboxVerActivos.Checked)
            {
                //si en el cuadro de texto de busqueda hay 3 o mas caracteres se filtra la lista 
                string FiltroBusqueda = "";

                if (!string.IsNullOrEmpty(TxtBuscar.Text.Trim()) && TxtBuscar.Text.Count() >=3)
                {
                    FiltroBusqueda=TxtBuscar.Text.Trim();
                }

                ListaUsuario = MiUsuarioLocal.ListarActivos(FiltroBusqueda);
            }

            else
            {
                ListaUsuario = MiUsuarioLocal.ListarInactivos();
            }

            DgLista.DataSource= ListaUsuario;

        }

        private void CargarListaRoles()
        {
            Logica.Modelos.UsuarioRol MiRol = new Logica.Modelos.UsuarioRol();
            DataTable dt = new DataTable();
            dt = MiRol.Listar();

            if (dt != null && dt.Rows.Count >0)
            {
                CbUsuarioRol.ValueMember = "ID";
                CbUsuarioRol.DisplayMember = "Descrip";
                CbUsuarioRol.DataSource = dt;
                CbUsuarioRol.SelectedIndex = -1;
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
            //de dicho usuario en el usuario local y luego dibujar esa info en los controles 
            //graficos

             if (DgLista .SelectedRows.Count == 1)
            {

                LimpiarFormulario();

                //de la coleccion de filas seleccionadasseleccionamos la fila de indice 0
                //osea la primera
                DataGridViewRow MiFila = DgLista.SelectedRows[0];

                //lo que necesito es el valor del ID del usuario para realizar la consulta
                //y traer todos los datos para llenar el objeto del objeto del usuario local
                int IdUsuario = Convert.ToInt32(MiFila.Cells["CUsuarioID"].Value);

                //para no asumir riesgos se reinstancia el usuario local
                MiUsuarioLocal = new Logica.Modelos.Usuario();

                //ahora le agregamos el valor obtenido por la fila al ID del usuario local
                MiUsuarioLocal.UsuarioID = IdUsuario;

                //una vez que tengo el objeto local con el valor del id, puedor ir a consultar
                //el usuario por ese id y llenar el resto de atributos.
                MiUsuarioLocal = MiUsuarioLocal.ConsultarPorIDRetornaUsuario();

                // validamos que el usuario local tenga datos 
                if (MiUsuarioLocal != null && MiUsuarioLocal.UsuarioID > 0 )
                {
                    //si cargamos correctamente el usuario local llenamos los controles
                    TxtUsuarioID.Text = Convert.ToString(MiUsuarioLocal.UsuarioID);

                    TxtUsuarioNombre.Text = MiUsuarioLocal.UsuarioNombre;

                    TxtUsuarioCedula.Text = MiUsuarioLocal.UsuarioCedula;

                    TxtUsuarioTelefono.Text = MiUsuarioLocal.UsuarioTelefono;

                    TxtUsuarioCorreo.Text = MiUsuarioLocal.UsuarioCorreo;

                    TxtUsuarioDireccion.Text = MiUsuarioLocal.UsuarioDireccion;

                    //combobox
                    CbUsuarioRol.SelectedValue = MiUsuarioLocal.MiRolTipo.UsuarioRolID;

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
            TxtUsuarioID.Clear();
            TxtUsuarioNombre.Clear();
            TxtUsuarioCedula.Clear();
            TxtUsuarioTelefono.Clear();
            TxtUsuarioCorreo.Clear();
            TxtUsuarioContrasennia.Clear();
            TxtUsuarioDireccion.Clear();
            CbUsuarioRol.SelectedIndex = -1;
        }

        private bool ValidarDatosDigitados(bool OmitirPassword=false)

        //evalua que se hayan digitadolos campos de texto en el formulario
        {
            bool R = false;

            if (!string.IsNullOrEmpty(TxtUsuarioNombre.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUsuarioCedula.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUsuarioTelefono.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUsuarioCorreo.Text.Trim()) &&
                 !string.IsNullOrEmpty(TxtUsuarioDireccion.Text.Trim()) &&
                CbUsuarioRol.SelectedIndex >-1)

            {

               if(OmitirPassword)
                {
                    //Si el password se omite entonces ya paso la evaluacion se ese punto,
                    //retorna true
                    R= true;
                }
               else 

                {
                    //(para agregar) en el caso en el que haya que evaluar la contraseña se debe 
                    //agregar otra condicion logica

                    if (!string.IsNullOrEmpty(TxtUsuarioContrasennia.Text.Trim()))
                    {
                        R= true;
                    }
                    else 
                    {

                        //en caso de que haga falta falta la contraseña , se le indica al usuario
                        MessageBox.Show("Debe digitar una contraseña para el usuario", "Error de validacion", MessageBoxButtons.OK);
                        TxtUsuarioContrasennia.Focus();
                        return false;
                    }

                }


                R = true;
            }
            else
            {
                //que pasa su algo falta
                //nombre
                if (string.IsNullOrEmpty(TxtUsuarioNombre.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar un nombre para el usuario", "Error de validacion", MessageBoxButtons.OK);
                    TxtUsuarioNombre.Focus();
                    return false;
                }

                //cedula

                if (string.IsNullOrEmpty(TxtUsuarioCedula.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar una cedula para el usuario", "Error de validacion", MessageBoxButtons.OK);
                    TxtUsuarioCedula.Focus();
                    return false;
                }

                //telefono
                if (string.IsNullOrEmpty(TxtUsuarioTelefono.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar un telefono para el usuario", "Error de validacion", MessageBoxButtons.OK);
                    TxtUsuarioTelefono.Focus();
                    return false;
                }
                //correo
                if (string.IsNullOrEmpty(TxtUsuarioCorreo.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar un correo para el usuario", "Error de validacion", MessageBoxButtons.OK);
                    TxtUsuarioCorreo.Focus();
                    return false;
                }

                //contrasennia
                if (string.IsNullOrEmpty(TxtUsuarioContrasennia.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar una contraseña para el usuario", "Error de validacion", MessageBoxButtons.OK);
                    TxtUsuarioContrasennia.Focus();
                    return false;
                }

                //direccion
                if (string.IsNullOrEmpty(TxtUsuarioDireccion.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar una direccion para el usuario", "Error de validacion", MessageBoxButtons.OK);
                    TxtUsuarioDireccion.Focus();
                    return false;
                }

                //rol de usuario
                if (CbUsuarioRol.SelectedIndex==-1)
                {
                    MessageBox.Show("Debe seleccionar un rol para el usuario", "Error de validacion", MessageBoxButtons.OK);
                    CbUsuarioRol.Focus();
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

            MiUsuarioLocal = new Logica.Modelos.Usuario();
            //llenar los valores de los atributos con los datos digitados en el form
            MiUsuarioLocal.UsuarioNombre= TxtUsuarioNombre.Text.Trim();
            MiUsuarioLocal.UsuarioCedula = TxtUsuarioCedula.Text.Trim();
            MiUsuarioLocal.UsuarioTelefono = TxtUsuarioTelefono.Text.Trim();
            MiUsuarioLocal.UsuarioCorreo= TxtUsuarioCorreo.Text.Trim();
            MiUsuarioLocal.UsuarioContrasenia = TxtUsuarioContrasennia.Text.Trim();
            MiUsuarioLocal.UsuarioDireccion= TxtUsuarioDireccion.Text.Trim();
            //compocision del rol
            MiUsuarioLocal.MiRolTipo.UsuarioRolID = Convert.ToInt32(CbUsuarioRol.SelectedValue);

            //realizar las consultas por correo y por cedula 

            CedulaOK = MiUsuarioLocal.ConsultarPorCedula();

            EmailOK = MiUsuarioLocal.ConsultarPorCorreo();

            //se puede agregar el usuario ya que no existe un usuario con la cedula y el 
            //correo digitados

            if (CedulaOK==false && EmailOK==false)
            {
                //se solicita al usuario confirmacion de que si quiere agregar o no al usuario
                string msg = string.Format("¿Esta seguro de agregar al usuario {0}?", MiUsuarioLocal.UsuarioNombre);

                DialogResult respuesta = MessageBox.Show(msg, "???", MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    bool ok = MiUsuarioLocal.Agregar();
                    if (ok)
                    {
                        MessageBox.Show("Usuario guardado correctamente", "(:", MessageBoxButtons.OK);

                        LimpiarFormulario();
                        CargarListaUsuarios();
                    }

                    else
                    {
                        MessageBox.Show("El usuario no se pudo guardar correctamente", "):", MessageBoxButtons.OK);
                    }
                }

                else
                {
                    //indicar al usuario si falta una consulta

                    if(CedulaOK)
                    {
                        MessageBox.Show("Ya existe un usuario con la cedula digitada", "Error en validacion", MessageBoxButtons.OK);
                        return;
                    }


                    if (EmailOK)
                    {
                        MessageBox.Show("Ya existe un usuario con el correo digitado", "Error en validacion", MessageBoxButtons.OK);
                        return;
                    }
                }

            }
              

        }
    }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosDigitados(true))
            {
                //no es necesario capturar el ID desde el cuadro de texto ya que al consultarlo
                //ya tenemos datos en el ID, este ID no puede ser modificado, los demas atributos si

                MiUsuarioLocal.UsuarioNombre=TxtUsuarioNombre.Text.Trim();
                MiUsuarioLocal.UsuarioCedula = TxtUsuarioCedula.Text.Trim();
                MiUsuarioLocal.UsuarioTelefono = TxtUsuarioTelefono.Text.Trim();
                MiUsuarioLocal.UsuarioCorreo = TxtUsuarioCorreo.Text.Trim();
                MiUsuarioLocal.UsuarioDireccion = TxtUsuarioDireccion.Text.Trim();
                MiUsuarioLocal.MiRolTipo.UsuarioRolID = Convert.ToInt32(CbUsuarioRol.SelectedValue);

                //como el cuadro de textode la contraseña tiene un caracteren blanco puedo
                //asignar sin problema el valor del cuadro de texto al atributo, en el SP se 
                //evalua si tiene o no datos

                MiUsuarioLocal.UsuarioContrasenia= TxtUsuarioContrasennia.Text.Trim();

                if (MiUsuarioLocal.ConsultarPorID())
                {
                    DialogResult respuesta = MessageBox.Show("Esta seguro de modificar el usuario", "???",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes)
                    {
                        if (MiUsuarioLocal.Editar())

                        {
                            MessageBox.Show("El Usuario ha sido modificado correctamente", "(:", MessageBoxButtons.OK);

                            LimpiarFormulario();
                            CargarListaUsuarios();
                        }

                    }
                }



            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (MiUsuarioLocal.UsuarioID >0 && MiUsuarioLocal.ConsultarPorID())
            {
                //tomando en cuenta que puedo estar viendo los usuarios activos e inactivos 
                //este boton va a servir tanto para desactivar como para activar usuarios
               
                if (CboxVerActivos.Checked)
                {
                    //DESACTIVAR USUARIO

                    DialogResult r = MessageBox.Show("¿Esta seguro de eliminar el Usuario?",
                                                       "???",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (MiUsuarioLocal.Eliminar())

                        {
                            MessageBox.Show("El usuario ha sido eliminado correctamente", "!!!", MessageBoxButtons.OK);
                            LimpiarFormulario();
                            CargarListaUsuarios();
                        }

                    }

                }

                else
                {
                    //ACTIVAR EL USUARIO


                    DialogResult r = MessageBox.Show("¿Esta seguro de Activar el usuario?",
                                                        "???",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        if (MiUsuarioLocal.Activar())

                        {
                            MessageBox.Show("El usuario ha sido activado correctamente", "!!!", MessageBoxButtons.OK);
                            LimpiarFormulario();
                            CargarListaUsuarios();
                        }

                    }
                }


            }
        }

        private void TxtUsuarioNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e, true);
        }

        private void TxtUsuarioCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled= Validaciones.CaracteresNumeros(e, true);
        }

        private void TxtUsuarioTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e);
        }

        private void TxtUsuarioCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e,false,true);
        }

        private void TxtUsuarioContrasennia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e);
        }

        private void TxtUsuarioDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validaciones.CaracteresTexto(e,true);
        }

        private void TxtUsuarioCorreo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtUsuarioCorreo.Text.Trim()))
            {
                if (!Validaciones.ValidarEmail(TxtUsuarioCorreo.Text.Trim()))

                {
                    MessageBox.Show("El formato del correo es incorrecto", "Error en validacion", MessageBoxButtons.OK);

                    TxtUsuarioCorreo.Focus();
                }
            }

        }

        private void TxtUsuarioCorreo_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtUsuarioCorreo.Text.Trim()))
            {
                TxtUsuarioCorreo.DeselectAll();
               TxtUsuarioCorreo.SelectAll();
            }

        }

        private void CboxVerActivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarListaUsuarios();

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
            CargarListaUsuarios();
        }

       
    }
}
