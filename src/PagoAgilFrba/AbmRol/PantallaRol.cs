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
    public partial class PantallaRol : Form
    {
        SqlServer Server;
        int idRol;
        ListadoRoles listado;
        DataTable funcionalidadesRol;

        public PantallaRol(int idRol, String nombreRol, String activo, ListadoRoles listado)
        {
            this.Server = new SqlServer(); 
            this.idRol = idRol;
            this.listado = listado;
            InitializeComponent();
            txtNombre.Text = nombreRol;
            cbActivo.Checked = activo == "Si" ? true : false;
            CargarFuncionalidades();
        }

        public void CargarFuncionalidades()
        {
            DataTable funcionalidades = Server.EjecutarSp("SP_Get_Funcionalidades");
            if (Utiles.Utiles.handleError(funcionalidades))
            {
                cmbFuncionalidades.DataSource = funcionalidades;
                cmbFuncionalidades.DisplayMember = "nombre";
                if (!CreandoNuevoRol())
                {
                    var paramsProcedure = new Dictionary<string, string>();
                    paramsProcedure.Add("id_rol", idRol.ToString());
                    funcionalidadesRol = Server.EjecutarSp("SP_Get_Funcionalidades_Rol", paramsProcedure);
                    for (int i = 0; i < cmbFuncionalidades.Items.Count; i++)
                    {
                        DataRowView funcionalidad = (DataRowView) cmbFuncionalidades.Items[i];
                        int idFuncionalidad = Convert.ToInt32(funcionalidad[0]);
                        if (RolTieneFuncionalidad(idFuncionalidad)) {
                            cmbFuncionalidades.SetItemChecked(i, true);
                        }
                    }
                }
            }
        }

        private void cmbFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PantallaRol_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreRol = txtNombre.Text;
            int activo = cbActivo.Checked ? 1 : 0;
            string idFuncionalidades = GetIdsFuncionalidades();

            var paramsProcedure = new Dictionary<string, string>();
            paramsProcedure.Add("nombre_rol", nombreRol);
            paramsProcedure.Add("activo", activo.ToString());
            paramsProcedure.Add("lista_funcionalidades", idFuncionalidades);
            DataTable resultado;

            if (CreandoNuevoRol())
            {
                resultado = Server.EjecutarSp("SP_Create_Rol", paramsProcedure);
            }
            else
            {
                paramsProcedure.Add("id_rol", idRol.ToString());
                resultado = Server.EjecutarSp("SP_Update_Rol", paramsProcedure);
            }

            if (Utiles.Utiles.handleError(resultado))
            {
                listado.CargarRoles();
                Close();
            }
        }

        private string GetIdsFuncionalidades()
        {
            string ids = "";
            for (int i = 0; i < cmbFuncionalidades.Items.Count; i++) {
                bool seleccionada = cmbFuncionalidades.GetItemChecked(i);
                if (seleccionada) {
                    DataRowView funcionalidad = (DataRowView) cmbFuncionalidades.Items[i];
                    ids += "," + funcionalidad[0].ToString();
                }
            }
            return ids.Length > 1 ? ids.Substring(1) : ids;
        }

        private bool CreandoNuevoRol() {
            return idRol == -1;
        }

        private bool RolTieneFuncionalidad(int idFuncionalidad) {
            for (int i = 0; i < funcionalidadesRol.Rows.Count; i++) {
                if (Convert.ToInt32(funcionalidadesRol.Rows[i][0]) == idFuncionalidad) {
                    return true;
                }
            }
            return false;
        }
    }
}
