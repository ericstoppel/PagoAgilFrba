using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.Funcionalidades;
using PagoAgilFrba.Conexiones;
using PagoAgilFrba.AbmCliente;

namespace PagoAgilFrba.Abm_Cliente
{
    public partial class Cl_Abm_Cliente : Form
    {
        public Cl_Abm_Cliente()
        {
            InitializeComponent();
            this.dgvClientes.DataSource = GetClientes();
        }

        private static DataTable GetClientes()
        {
            SqlServer sql = new SqlServer();
            DataTable tabla = sql.EjecutarSp("PR_Get_Clientes");
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
                return null;
            }
            return tabla;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            CrearCliente crearCliente = new CrearCliente();
            crearCliente.Show();
        }
    }
}
