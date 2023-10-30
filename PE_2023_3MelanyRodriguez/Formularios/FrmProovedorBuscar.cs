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
    public partial class FrmProovedorBuscar : Form
    {
       DataTable DtLista { get; set; }
       Proovedor MiProovedorLocal { get; set; }
        public FrmProovedorBuscar()
        {
            InitializeComponent();
            DtLista = new DataTable();
            MiProovedorLocal = new Proovedor();
        }

        private void FrmProovedorBuscar_Load(object sender, EventArgs e)
        {
            LlenarLista();
        }

        private void LlenarLista()
        {
            DtLista = new DataTable();
            DtLista = MiProovedorLocal.ListarActivos(true, TxtBuscar.Text.Trim());
            DgvLista.DataSource = DtLista;
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text.Count() >2 || string.IsNullOrEmpty(TxtBuscar.Text.Trim()))
            {
                LlenarLista();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
          if (DgvLista.SelectedRows.Count==1)
            {
              DataGridViewRow row = DgvLista.SelectedRows[0];

             int IdProovedor= Convert.ToInt32(row.Cells["CProovedorID"].Value);
            string NombreProovedor= Convert.ToString(row.Cells["CProovedorNombre"].Value);
                //pasar las variables al objeto de venta  del formulario de registro de ventas
                Globales.MiFormRegistroVentas.MiVentaLocal.MiProovedor.ProovedorNombre = NombreProovedor;
                Globales.MiFormRegistroVentas.MiVentaLocal.MiProovedor.ProovedorId = IdProovedor;

            }

            DialogResult = DialogResult.OK;
        }
    }
}
