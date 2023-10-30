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
    public partial class FrmMDI : Form
    {
        public FrmMDI()
        {
            InitializeComponent();
        }

        private void FrmMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void gESTIONDEUSUARIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //control para que el formulario de gestion de usuarios se muestre solo una vez
            if (!Globales.MiFormUsuarioGestion.Visible) 
            {
                Globales.MiFormUsuarioGestion=new FrmUsuarioGestion();

                Globales.MiFormUsuarioGestion.Show();
            }
        }

        private void gESTIONDEPROOVEDORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //control para que el formulario de gestion de proovedores se muestre solo una vez
            if (!Globales.MiFormProovedorGestion.Visible)
            {
                Globales.MiFormProovedorGestion = new FrmProovedorGestion();

                Globales.MiFormProovedorGestion.Show();
            }
        }

        private void gESTIONDEPRODUCTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //control para que el formulario de gestion de productos se muestre solo una vez
            if (!Globales.MiFormGestionProductos.Visible)
            {
                Globales.MiFormGestionProductos = new FrmGestionProductos();

                Globales.MiFormGestionProductos.Show();
            }
    }

        private void FrmMDI_Load(object sender, EventArgs e)
        {
            //mostrar el usuario logeado
            string InfoUsuario = string.Format("{0}-{1}({2})",
                                             Globales.MiUsuarioGobal.UsuarioNombre,
                                             Globales.MiUsuarioGobal.UsuarioCorreo,
                                             Globales.MiUsuarioGobal.MiRolTipo.UsuarioRolDescripcion);

            LblUsuario.Text = InfoUsuario;

            switch (Globales.MiUsuarioGobal.MiRolTipo.UsuarioRolID)
            {
                case 1:
                    //si es admin no se oculta nada
                    break;

                    case 2:
                    //si es usuario normal se debe ocultar varias opciones del menu
                    rOLUSUARIOToolStripMenuItem.Visible = false;
                    tipoDeProovedorToolStripMenuItem.Visible = false;
                    tipoDeVentaToolStripMenuItem.Visible = false;
                    cateToolStripMenuItem.Visible = false;
                    break;
            }
        }

        private void rEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //control para que el formulario de registro de ventas se muestre solo una vez
            if (!Globales.MiFormRegistroVentas.Visible)
            {
                Globales.MiFormRegistroVentas = new FrmRegistroVentas();

                Globales.MiFormRegistroVentas.Show();
            }
        }
    }
}
