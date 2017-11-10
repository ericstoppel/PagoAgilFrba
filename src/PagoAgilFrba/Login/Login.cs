using PagoAgilFrba.Conexiones;
using PagoAgilFrba.Menus;
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
        private int IdUsuario { get; set; }
        private string RolUsuario { get; set; }
        private int _intentos = 0;
        private int _idUsuario;

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString());
            }
            return result.ToString();
        }

        public Cl_Login()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            bool resultado = false;

            DataTable userData;

            if (Txt_Usuario.Text.Length == 0 || Txt_Password.Text.Length == 0)
            {
                MessageBox.Show("Ingresar usuario y password");
                return false;
            }

            string msjLogueo = this.LoguearUsuario(out resultado, out userData);

            if (resultado == false)
            {
                MessageBox.Show(msjLogueo);

                return false;
            }
            else
            {
                string password = userData.Rows[0].ItemArray[0].ToString();
                string username = userData.Rows[0].ItemArray[1].ToString();
                bool activo = Convert.ToBoolean(userData.Rows[0].ItemArray[2]);
                _idUsuario = Convert.ToInt32(userData.Rows[0].ItemArray[3]);
                _intentos = Convert.ToInt32(userData.Rows[0].ItemArray[4]);
                bool passwordMatched = Convert.ToBoolean(userData.Rows[0].ItemArray[5]);

                if (!activo)
                {
                    MessageBox.Show("Usuario bloqueado. No puede acceder.");

                    return false;
                }

                if (!passwordMatched)
                {
                    if (_intentos == 3)
                    {
                        var parametros = new Dictionary<string, string>();
                        SqlServer sql = new SqlServer();

                        parametros.Add("USERNAME", Txt_Usuario.Text);
                        sql.EjecutarSp("PR_BLOQUEAR_USUARIO", parametros);

                        MessageBox.Show("Usuario Bloqueado");

                        return false;
                    }

                    MessageBox.Show("Password o Usuario incorrectos.");

                    return false;
                }
            }

            return true;
        }

        public void LevantarRol(string rol)
        {
            SqlServer sql = new SqlServer();
            var listaParametros = new Dictionary<string, string>();
            DataTable tabla;
            this.RolUsuario = rol;
            listaParametros.Add("Nombre_Rol", rol);
            tabla = sql.EjecutarSp("SP_Get_Funcionalidades_Rol", listaParametros);
            foreach (Control subchild in this.Controls)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    if (subchild.Name == tabla.Rows[i][0].ToString())
                    {
                        subchild.Enabled = tabla.Rows[i][1].Equals(true);
                        subchild.Visible = tabla.Rows[i][1].Equals(true);
                    }
                }
            }
        }


        private string LoguearUsuario(out bool resultado, out DataTable userData)
        {
            string mensaje = "";
            string usuario = Txt_Usuario.Text;
            userData = null;

            var listaParametros = new Dictionary<string, string>();
            SqlServer sqlServer = new SqlServer();

            listaParametros.Add("USERNAME", usuario);
            listaParametros.Add("PASSWORD", Txt_Password.Text);

            DataTable dataTable = sqlServer.EjecutarSp("PR_LOGIN", listaParametros);

            if (dataTable.Rows.Count == 0) {
                resultado = false;
                mensaje = "Password o Usuario Incorrecto";
            }
            else if (dataTable.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                resultado = false;
                mensaje = dataTable.Rows[0].ItemArray[1].ToString();

            }
            else if (dataTable.Rows[0].ItemArray[0].ToString() == "")
            {
                resultado = false;
                mensaje = "Password o Usuario Incorrecto";

            }
            else
            {
                resultado = true;
                userData = dataTable;

            }

            return mensaje;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                var parametros = new Dictionary<string, string>();
                SqlServer sql = new SqlServer();

                parametros.Add("USERNAME", Txt_Usuario.Text);
                sql.EjecutarSp("PR_USUARIO_LOGUEADO", parametros);

                Cl_Roles roles = new Cl_Roles(_idUsuario);
                while (roles.IsAccessible) ;
                if (roles.rol_name.Equals("") == true)
                {
                    Txt_Password.Clear();
                    roles.ShowDialog();
                    MenuInicial menu = new MenuInicial(_idUsuario);
                    menu.LevantarRol(roles.rol_name);
                    menu.ShowDialog();
                }
                else
                {
                    Txt_Password.Clear();
                    MenuInicial menu = new MenuInicial(_idUsuario);
                    menu.LevantarRol(roles.rol_name);
                    menu.ShowDialog();
                }
            }
        }
    }
}
