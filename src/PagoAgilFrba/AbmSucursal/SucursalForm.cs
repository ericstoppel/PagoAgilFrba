using PagoAgilFrba.DataBase;
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
            DataTable tabla = sql.EjecutarSp("SP_Get_Sucursales");
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
                return null;
            }
            return tabla;
        }

        private void AgregarEditar()
        {
            if (dgvSucursales.Columns.Contains("Editar"))
                dgvSucursales.Columns.Remove("Editar");
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Text = "Editar";
            btnEditar.Name = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            dgvSucursales.Columns.Add(btnEditar);
        }

        private void AgregarBorrar()
        {
            if (dgvSucursales.Columns.Contains("Borrar"))
                dgvSucursales.Columns.Remove("Borrar");
            DataGridViewButtonColumn btnBorrar = new DataGridViewButtonColumn();
            btnBorrar.Text = "Borrar";
            btnBorrar.Name = "Borrar";
            btnBorrar.UseColumnTextForButtonValue = true;
            dgvSucursales.Columns.Add(btnBorrar);
        }

        private void dgvSucursales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSucursales.Columns["Editar"].Index && e.RowIndex >= 0)
            {
                int idAEditar = Convert.ToInt32(dgvSucursales.Rows[e.RowIndex].Cells["id"].Value);
                EditarSucursal editarSucursal = new EditarSucursal(idAEditar);
                editarSucursal.Show();
                return;
            }
            if (e.ColumnIndex == dgvSucursales.Columns["Borrar"].Index && e.RowIndex >= 0)
            {
                SqlServer sql = new SqlServer();
                var listaParametros = new Dictionary<string, string>();
                listaParametros.Add("id", dgvSucursales.Rows[e.RowIndex].Cells["id"].Value.ToString());
                DataTable tabla = sql.EjecutarSp("SP_Baja_Sucursal_By_Id", listaParametros);
                if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
                {
                    MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
                }
                ActualizarSucursalForm();
                return;
            }
        }

        private void SucursalForm_Load(object sender, EventArgs e)
        {
            ActualizarSucursalForm();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarSucursalForm();
        }

        public void ActualizarSucursalForm()
        {
            this.dgvSucursales.DataSource = GetSucursales();
            AgregarEditar();
            AgregarBorrar();
        }

        private void btnFiltrarSucursales_Click(object sender, EventArgs e)
        {
            String filtroNombre = this.txtFiltroNombre.Text;
            String filtroDireccion = this.txtFiltroDireccion.Text;
            String filtroCP = this.txtFiltroCodigoPostal.Text;

            SqlServer sql = new SqlServer();
            var listaParametros = new Dictionary<string, string>();
            listaParametros.Add("nombre", filtroNombre);
            listaParametros.Add("direccion", filtroDireccion);
            listaParametros.Add("codigo_postal", filtroCP);

            DataTable tabla = sql.EjecutarSp("SP_Get_Sucursales_x_Campos", listaParametros);
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
            }
            this.dgvSucursales.DataSource = tabla;
            AgregarEditar();
            AgregarBorrar();
        }
    }
}
