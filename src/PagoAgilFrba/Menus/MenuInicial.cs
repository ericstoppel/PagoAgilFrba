using PagoAgilFrba.Abm_Cliente;
using PagoAgilFrba.AbmRol;
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

namespace PagoAgilFrba.Menus
{
    public partial class MenuInicial : Form
    {
        private int IdUsuario { get; set; }
        private string RolUsuario { get; set; }

        public MenuInicial(int idUsuario)
        {
            InitializeComponent();
            this.IdUsuario = idUsuario;
        }

        public void LevantarRol(string rol)
        {
            SqlServer sql = new SqlServer();
            var listaParametros = new Dictionary<string, string>();
            DataTable tabla;
            this.RolUsuario = rol;
            listaParametros.Add("nombre_rol", rol);
            tabla = sql.EjecutarSp("SP_Get_Funcionalidades_Rol", listaParametros);
            foreach (Control subchild in this.Controls)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    if (subchild.Name == tabla.Rows[i][0].ToString())
                    {
                        subchild.Enabled = true;
                        subchild.Visible = true;
                    }
                }
            }
        }

        public int getUsuario()
        {
            return IdUsuario;
        }
      

        private void MenuInicial_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Rol_Click(object sender, EventArgs e)
        {
            Cl_Abm_Rol rol = new Cl_Abm_Rol();
            rol.ShowDialog();
        }

        private void Btn_ABM_Cliente_Click(object sender, EventArgs e)
        {
            Cl_Abm_Cliente cliente = new Cl_Abm_Cliente();
            cliente.ShowDialog();
        }

      

       
    }
}
