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
using PagoAgilFrba.Menus;

namespace PagoAgilFrba.Login
{
    public partial class Cl_Roles : Form
    {
        SqlServer Server;
        int idSucursal;
        int idRol;

        public Cl_Roles(int _idSucursal, int _idRol)
        {
            Server = new SqlServer();
            InitializeComponent();
            idSucursal = _idSucursal;
            idRol = _idRol;
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSucursal.DropDownStyle = ComboBoxStyle.DropDownList;
            if (idSucursal == -1)
            {
                cmbSucursal.Visible = true;
                lblSucursal.Visible = true;
                CargarSucursales();
            }
            
            if (idRol == -1) {
                cmbRol.Visible = true;
                lblRol.Visible = true;
                CargarRoles();
            }   
        }

        private void CargarDatos(ComboBox combo, String procedure) {
            var paramsProcedure = new Dictionary<string, string>();
            paramsProcedure.Add("id_usuario", Global.IdUsuario.ToString());
            DataTable sucursales = Server.EjecutarSp(procedure, paramsProcedure);
            if (Utiles.Utiles.handleError(sucursales))
            {
                combo.DataSource = sucursales;
                combo.DisplayMember = "Nombre";
            }
        }

        private void CargarRoles() {
            CargarDatos(cmbRol, "SP_Get_Roles_Usuario");
        }

        private void CargarSucursales()
        {
            CargarDatos(cmbSucursal, "SP_Get_Sucursales_Usuario");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (idRol == -1) {
                DataRowView rol = (DataRowView)cmbRol.Items[Convert.ToInt32(cmbRol.SelectedIndex)];
                idRol = Convert.ToInt32(rol[0]);
            }

            if (idSucursal == -1)
            {
                DataRowView sucursal = (DataRowView)cmbSucursal.Items[Convert.ToInt32(cmbSucursal.SelectedIndex)];
                idSucursal = Convert.ToInt32(sucursal[0]);
            }
            Global.IdRol = idRol;
            Global.IdSucursal = idSucursal;
            MenuInicial menu = new MenuInicial();
            menu.ShowDialog();
            Close();
        }


    }
}
