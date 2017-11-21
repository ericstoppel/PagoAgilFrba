using PagoAgilFrba.Conexiones;
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
            this.dgvSucursales.DataSource = GetSucursales();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrearSucursal_Click(object sender, EventArgs e)
        {
            CrearSucursal crearSucursal = new CrearSucursal();
            crearSucursal.Show();
        }

        public static DataTable GetSucursales()
        {
            SqlServer sql = new SqlServer();
            DataTable tabla = sql.EjecutarSp("PR_Get_Sucursales");
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
                return null;
            }
            return tabla;
        }
    }
}
