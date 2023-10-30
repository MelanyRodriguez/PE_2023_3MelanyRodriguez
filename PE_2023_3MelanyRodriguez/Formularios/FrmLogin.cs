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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            //CIERRA LA APP
            Application.Exit();
        }

        private void BtnVerContrasenia_MouseDown(object sender, MouseEventArgs e)
        {
            TxtContrasenia.UseSystemPasswordChar= false;
        }

        private void BtnVerContrasenia_MouseUp(object sender, MouseEventArgs e)
        {
            TxtContrasenia.UseSystemPasswordChar = true;
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {

            //validar que se haya digitado el usuario y la contraseña
            if(!string.IsNullOrEmpty(TxtEmail.Text.Trim()) &&
               !string.IsNullOrEmpty(TxtContrasenia.Text.Trim()))
            {
                string usuario = TxtEmail.Text.Trim();
                string contrasennia = TxtContrasenia.Text.Trim();

                //validar que los datos digitadis sean correctos
                Globales.MiUsuarioGobal = Globales.MiUsuarioGobal.ValidarUsuario(usuario,contrasennia);

                if (Globales.MiUsuarioGobal.UsuarioID >0)
                {
                    //si la validacion es correcta el ID deveria tener un valor
                    //mayor a cero 
                    Globales.MiFormPrincipal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectas", "Error en validacion", MessageBoxButtons.OK);

                    TxtContrasenia.Focus();
                    TxtContrasenia.SelectAll();
                }

            }
            else
            {
                MessageBox.Show("Faltan datos requeridos!", "Error en validacion", MessageBoxButtons.OK);
            }

           
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            //al precionar cierta convinacion de teclas el boton de ingreso directo aparece
            if(e.Shift & e.Alt & e.KeyCode == Keys.A)
            {
                //si presionamos shift + alt + a 
                BtnIngresoDirecto.Visible = true;
            }
        }

        private void BtnIngresoDirecto_Click(object sender, EventArgs e)
        {
            Globales.MiFormPrincipal.Show();
            this.Hide();
        }
    }
}
