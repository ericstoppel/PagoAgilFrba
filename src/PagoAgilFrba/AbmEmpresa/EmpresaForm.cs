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

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class EmpresaForm : Form
    {
        public EmpresaForm()
        {
            InitializeComponent();
        }

        private static DataTable GetEmpresas()
        {
            SqlServer sql = new SqlServer();
            DataTable tabla = sql.EjecutarSp("PR_Get_Empresas");
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
            CrearEmpresa crearEmpresa = new CrearEmpresa();
            crearEmpresa.Show();
        }

        private void AgregarEditar()
        {
            if (dgvEmpresas.Columns.Contains("Editar"))
                dgvEmpresas.Columns.Remove("Editar");
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Text = "Editar";
            btnEditar.Name = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            dgvEmpresas.Columns.Add(btnEditar);
        }

        private void AgregarBorrar()
        {
            if (dgvEmpresas.Columns.Contains("Borrar"))
                dgvEmpresas.Columns.Remove("Borrar");
            DataGridViewButtonColumn btnBorrar = new DataGridViewButtonColumn();
            btnBorrar.Text = "Borrar";
            btnBorrar.Name = "Borrar";
            btnBorrar.UseColumnTextForButtonValue = true;
            dgvEmpresas.Columns.Add(btnBorrar);
        }

        public void ActualizarEmpresaForm()
        {
            this.dgvEmpresas.DataSource = GetEmpresas();
            AgregarEditar();
            AgregarBorrar();
        }

        private void EmpresaForm_Load(object sender, EventArgs e)
        {
            SqlServer sql = new SqlServer();
            DataTable tabla = sql.EjecutarSp("PR_Get_Rubros");

            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
            }
            this.cmbRubro.DataSource = tabla;
            this.cmbRubro.ValueMember = "nombre";
            this.cmbRubro.SelectedIndex = -1;
            ActualizarEmpresaForm();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarEmpresaForm();
        }

        private void dgvEmpresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvEmpresas.Columns["Editar"].Index && e.RowIndex >= 0)
            {
                int idAEditar = Convert.ToInt32(dgvEmpresas.Rows[e.RowIndex].Cells["id"].Value);
                EditarEmpresa editarEmpresa = new EditarEmpresa(idAEditar);
                editarEmpresa.Show();
                return;
            }
            if (e.ColumnIndex == dgvEmpresas.Columns["Borrar"].Index && e.RowIndex >= 0)
            {
                SqlServer sql = new SqlServer();
                var listaParametros = new Dictionary<string, string>();
                listaParametros.Add("id", dgvEmpresas.Rows[e.RowIndex].Cells["id"].Value.ToString());
                DataTable tabla = sql.EjecutarSp("SP_Baja_Empresa_By_Id", listaParametros);
                if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
                {
                    MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
                }
                ActualizarEmpresaForm();
                return;
            }
        }


    }
}
