using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.DataBase;
using PagoAgilFrba.Utiles;

namespace PagoAgilFrba.AbmRol
{
    public partial class ListadoRoles : Form
    {
        SqlServer Server;

        public ListadoRoles()
        {
            Server = new SqlServer();
            InitializeComponent();
            CargarRoles();
        }

        public void CargarRoles() {
            Utiles.Utiles.AgregarBotonDGV(Table_Roles, "Editar");
            DataTable roles = Server.EjecutarSp("SP_Get_Roles");
            if (Utiles.Utiles.handleError(roles)) {
                this.Table_Roles.DataSource = roles;
                
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PantallaRol pantallaRol = new PantallaRol(-1, "", "Si", this);
            pantallaRol.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Table_Roles.SelectedRows.Count > 0)
            {
                DataGridViewRow rolSeleccionado = Table_Roles.SelectedRows[0];
                int idRol = Convert.ToInt32(rolSeleccionado.Cells[1].Value);
                var paramsProcedure = new Dictionary<string, string>();
                paramsProcedure.Add("id_rol", idRol.ToString());
                DataTable resultado = Server.EjecutarSp("SP_Delete_Rol", paramsProcedure);
                if (Utiles.Utiles.handleError(resultado))
                {
                    CargarRoles();
                }
            }
            else
            {
                MessageBox.Show("No hay ningun rol seleccionado (debe seleccionar toda la fila)");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Table_Roles.SelectedRows.Count > 0)
            {
                DataGridViewRow rolSeleccionado = Table_Roles.SelectedRows[0];
                EditarRol(rolSeleccionado);
            }
            else {
                MessageBox.Show("No hay ningun rol seleccionado (debe seleccionar toda la fila)");
            }
        }

        private void EditarRol(DataGridViewRow rol) {
            int idRol = Convert.ToInt32(rol.Cells[1].Value);
            String nombreRol = rol.Cells[2].Value.ToString();
            String activo = rol.Cells[3].Value.ToString();
            PantallaRol pantallaRol = new PantallaRol(idRol, nombreRol, activo, this);
            pantallaRol.ShowDialog();
        }

        private void Table_Roles_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rolSeleccionado = Table_Roles.Rows[e.RowIndex];
            EditarRol(rolSeleccionado);
        }

        private void Table_Roles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Utiles.Utiles.ValidarColumna(Table_Roles, "Editar", e))
            {
                DataGridViewRow rolSeleccionado = Table_Roles.Rows[e.RowIndex];
                EditarRol(rolSeleccionado);
            }
        }
    }
}
