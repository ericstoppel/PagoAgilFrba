using PagoAgilFrba.Conexiones;
using PagoAgilFrba.Utiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmRol
{
    public partial class Cl_Abm_Rol : Form
    {
        private int selectedRol = -1;

        public Cl_Abm_Rol()
        {
            InitializeComponent();
            this.Clb_Funcionalidades.DataSource = GetFuncionalidades();
            this.Clb_Funcionalidades.DisplayMember = "Funcionalidades";
            this.chkHabilitado.Checked = false;

            this.DGV_Roles.DataSource = GetRoles();
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            BorrarCampos();
        }

        public static DataTable GetFuncionalidades()
        {
            SqlServer sql = new SqlServer();
            DataTable tabla = sql.EjecutarSp("PR_Get_Funcionalidades");
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
                return null;
            }
            return tabla;
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            this.DGV_Roles.DataSource = GetRoles();
            this.DGV_Roles.AllowUserToAddRows = false;
        }

        public static DataTable GetRoles()
        {
            SqlServer sql = new SqlServer();
            DataTable tabla = sql.EjecutarSp("PR_Get_Roles");
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
                return null;
            }
            return tabla;
        }

        private void CompletarFuncionalidades()
        {
            if (this.Txt_NombreRol.Text.Length > 0)
            {
                GetFuncilidadRol(this.Txt_NombreRol.Text.ToString(), this.Clb_Funcionalidades);
            }
        }

        public static void GetFuncilidadRol(string nombreRol, CheckedListBox funcionalidades)
        {

            SqlServer sql = new SqlServer();
            var listaParametros = new Dictionary<string, string>();

            listaParametros.Add("nombre_rol", nombreRol);

            DataTable tabla = sql.EjecutarSp("SP_Get_Funcionalidades_Rol", listaParametros);
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
                return;
            }

            Int32 cantidad = funcionalidades.Items.Count;
            Int32 cantidad2 = tabla.Rows.Count;
            for (int i = 0; i < cantidad && i < cantidad2; i++)
            {

                for (int j = 0; j < funcionalidades.Items.Count; j++)
                {
                    if (((DataTable)(((ListBox)funcionalidades).DataSource)).Rows[j].ItemArray[0].ToString().Equals(tabla.Rows[i].ItemArray[0].ToString()))
                    {
                        funcionalidades.SetItemChecked(j, true);
                        j = funcionalidades.Items.Count;
                    }
                }


            }
        }

        private void Btn_Crear_Click(object sender, EventArgs e)
        {
            if (this.ValidarForm() == false)
            {
                MessageBox.Show("Por favor complete el Nombre");
                return;
            }

            if (selectedRol != -1)
            {
                ModificarRol();
            }
            else
            {
                CrearRol();
            }

            this.DGV_Roles.DataSource = GetRoles();
        }

        private Boolean ValidarForm()
        {
            return (this.Txt_NombreRol.Text.Length > 0);
        }

        public void CrearRol()
        {
            SqlServer sql = new SqlServer();
            var listaParametros = new Dictionary<string, string>();

            listaParametros.Add("nombre_rol", Txt_NombreRol.Text);
            listaParametros.Add("habilitado", chkHabilitado.Checked.ToString());

            DataTable tabla = sql.EjecutarSp("SP_Create_Rol", listaParametros);

            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
            }
            else
            {
                this.selectedRol = Convert.ToInt32(tabla.Rows[0].ItemArray[0]);

                bool habilitado;
                bool error = false;
                CheckedListBox funcionalidades = Clb_Funcionalidades;

                Int32 cantidad = funcionalidades.Items.Count;
                for (int i = 0; i < cantidad; i++)
                {
                    DataRowView fila = (DataRowView)funcionalidades.Items[i];
                    habilitado = funcionalidades.GetItemChecked(i);
                    error = ModificarFuncionalidad(this.selectedRol, fila.Row[0].ToString(), Convert.ToInt32(habilitado));
                    if (error == true)
                        break;
                }
                if (error == true)
                {
                    MessageBox.Show("Rol creado con inconsistencias");
                }
                else
                {
                    MessageBox.Show("Rol creado exitosamente");
                }

                BorrarCampos();
            }
        }

        public bool ModificarFuncionalidad(int idRol, string funcionalidad, Int32 habilitado)
        {
            SqlServer sql = new SqlServer();
            var listaParametros = new Dictionary<string, string>();

            listaParametros.Add("ID_Rol", idRol.ToString());
            listaParametros.Add("funcionalidad_nombre", funcionalidad);
            listaParametros.Add("habilitado", habilitado.ToString());
            DataTable tabla = sql.EjecutarSp("SP_Update_Funcionalidad_Por_Rol", listaParametros);
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                return true;
            }
            return false;
        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {

        }

        public void ModificarRol()
        {
            SqlServer sql = new SqlServer();
            var listaParametros = new Dictionary<string, string>();

            listaParametros.Add("ID", this.selectedRol.ToString());
            listaParametros.Add("habilitado", chkHabilitado.Checked.ToString());
            listaParametros.Add("nuevo_nombre", Txt_NombreRol.Text);
            DataTable tabla = sql.EjecutarSp("SP_Update_Rol", listaParametros);
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
            }
            else
            {
                bool habilitado;
                bool error = false;
                CheckedListBox funcionalidades = Clb_Funcionalidades;

                Int32 cantidad = funcionalidades.Items.Count;
                for (int i = 0; i < cantidad; i++)
                {
                    DataRowView fila = (DataRowView)funcionalidades.Items[i];
                    habilitado = funcionalidades.GetItemChecked(i);
                    error = ModificarFuncionalidad(this.selectedRol,
                                  fila.Row[0].ToString(),
                                  Convert.ToInt32(habilitado));
                    if (error == true)
                        break;
                }
                if (error == true)
                {
                    MessageBox.Show("Rol modificado con inconsistencias");
                }
                else
                {
                    MessageBox.Show("Rol modificado exitosamente");
                }

                BorrarCampos();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Clb_Funcionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DGV_Roles_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void BorrarCampos()
        {
            this.Txt_NombreRol.Clear();
            this.CompletarFuncionalidades();
            this.chkHabilitado.Checked = false;
            this.selectedRol = -1;
        }

        private void DGV_Roles_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in DGV_Roles.SelectedRows)
            {
                this.selectedRol = Convert.ToInt32(row.Cells[0].Value);

                foreach (int i in Clb_Funcionalidades.CheckedIndices)
                {
                    Clb_Funcionalidades.SetItemCheckState(i, CheckState.Unchecked);
                }

                this.Txt_NombreRol.Text = row.Cells[1].Value.ToString();
                this.chkHabilitado.Checked = Convert.ToBoolean(row.Cells[2].Value);

                this.CompletarFuncionalidades();
            }
        }

        private void DGV_Roles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Cl_Abm_Rol_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
