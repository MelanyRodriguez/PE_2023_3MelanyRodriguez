using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE_2023_3MelanyRodriguez
{
    public static class Globales
    {
        //Estas propiedades al pertenecer a una clase static se auto instancian
        //y se pueden obtener acceso a ellas en la globalidad de la aplicacion

        public static Form MiFormPrincipal = new Formularios.FrmMDI();
        public static Formularios.FrmUsuarioGestion MiFormUsuarioGestion= new Formularios.FrmUsuarioGestion();
        public static Formularios.FrmGestionProductos MiFormGestionProductos = new Formularios.FrmGestionProductos();
        public static Formularios.FrmProovedorGestion MiFormProovedorGestion = new Formularios.FrmProovedorGestion();

        //Debemos tener un objeto de tipo Usuario que permit almacenar 
        //los datos del usuario que se haya logueado correctamente
        public static Logica.Modelos.Usuario MiUsuarioGobal = new Logica.Modelos.Usuario();

        public static Formularios.FrmRegistroVentas MiFormRegistroVentas = new Formularios.FrmRegistroVentas();


    }
}
