using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmSucursal
{
    public partial class SucursalForm : Form
    {
        public SucursalForm()
        {
            InitializeComponent();
        }

        private void btnAgregarSucursal_Click(object sender, EventArgs e)
        {
            CrearSucursal crearSucursal = new CrearSucursal();
            crearSucursal.Show();
        }

        private void btnEditarSucursal_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

        }
    }
}
