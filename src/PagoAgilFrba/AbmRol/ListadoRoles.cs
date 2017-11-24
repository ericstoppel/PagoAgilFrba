using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.Conexiones;
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
            DataTable roles = Server.EjecutarSp("SP_Get_Roles");
            if (Utiles.Utiles.handleError(roles)) {
                this.Table_Roles.DataSource = roles;
            } 
        }

        private void Table_Roles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                int idRol = Convert.ToInt32(rolSeleccionado.Cells[0].Value);
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
                int idRol = Convert.ToInt32(rolSeleccionado.Cells[0].Value);
                String nombreRol = rolSeleccionado.Cells[1].Value.ToString();
                String activo = rolSeleccionado.Cells[2].Value.ToString();
                PantallaRol pantallaRol = new PantallaRol(idRol, nombreRol, activo, this);
                pantallaRol.ShowDialog();
            }
            else {
                MessageBox.Show("No hay ningun rol seleccionado (debe seleccionar toda la fila)");
            }
        }
    }
}
