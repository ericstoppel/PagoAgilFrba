using PagoAgilFrba.Menus;
using PagoAgilFrba.DataBase;
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

namespace PagoAgilFrba.Login
{
    public partial class Cl_Login : Form
    {
        SqlServer Server;

        public Cl_Login()
        {
            Server = new SqlServer();
            InitializeComponent();
        }

   
        private void button1_Click(object sender, EventArgs e)
        {
            String nombreUsuario = txtUsuario.Text;
            String password = txtPassword.Text;

            var paramsProcedure = new Dictionary<string, string>();
            paramsProcedure.Add("username", nombreUsuario);
            paramsProcedure.Add("password", password);
            DataTable usuario = Server.EjecutarSp("SP_Login", paramsProcedure);
            if (Utiles.Utiles.handleError(usuario))
            {
                Global.IdUsuario = usuario.Rows[0].ItemArray[0].ToString();
                String nombre = usuario.Rows[0].ItemArray[1].ToString();
                int idSucursal = Convert.ToInt32(usuario.Rows[0].ItemArray[2]);
                int idRol = Convert.ToInt32(usuario.Rows[0].ItemArray[3]);
                if (idSucursal == -1 || idRol == -1)
                {
                    Cl_Roles roles = new Cl_Roles(idSucursal, idRol);
                    roles.ShowDialog();
                }
                else {
                    Global.IdRol = idRol;
                    Global.IdSucursal = idSucursal;
                    MenuInicial menu = new MenuInicial();
                    menu.ShowDialog();
                }
                Close();
            }
        }
    }
}
