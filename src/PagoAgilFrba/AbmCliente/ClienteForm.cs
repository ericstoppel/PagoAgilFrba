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
using PagoAgilFrba.DataBase;
using PagoAgilFrba.AbmCliente;
using PagoAgilFrba.Utiles;

namespace PagoAgilFrba.Abm_Cliente
{
    public partial class Cl_Abm_Cliente : Form
    {
        public Cl_Abm_Cliente()
        {
            InitializeComponent();
            this.dgvClientes.DataSource = GetClientes();
            Utiles.Utiles.AgregarBotonDGV(dgvClientes, "Editar");
            Utiles.Utiles.AgregarBotonDGV(dgvClientes, "Borrar");
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

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvClientes.Columns["Editar"].Index && e.RowIndex >= 0)
            {
                int idAEditar = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["id"].Value);
                EditarCliente editarCliente = new EditarCliente(idAEditar);
                editarCliente.Show();
                return;
            }
            if (e.ColumnIndex == dgvClientes.Columns["Borrar"].Index && e.RowIndex >= 0)
            {
                SqlServer sql = new SqlServer();
                var listaParametros = new Dictionary<string, string>();
                listaParametros.Add("id", dgvClientes.Rows[e.RowIndex].Cells["id"].Value.ToString());
                DataTable tabla = sql.EjecutarSp("SP_Baja_Cliente_By_Id", listaParametros);
                if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
                {
                    MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
                }
                ActualizarClienteForm();
                return;
            }
        }

        private void Cl_Abm_Cliente_Load(object sender, EventArgs e)
        {
            ActualizarClienteForm();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarClienteForm();
        }

        public void ActualizarClienteForm() {
            this.dgvClientes.DataSource = GetClientes();
            AgregarEditar();
            AgregarBorrar();
        }

        private void btnFiltrarClientes_Click(object sender, EventArgs e)
        {

        }
    }
}
