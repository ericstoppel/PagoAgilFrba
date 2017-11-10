using PagoAgilFrba.Funcionalidades;
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
    public partial class Cl_Roles : Form
    {
        public string rol_name;

        public Cl_Roles(int idUsuario)
        {
            InitializeComponent();
            Cmb_Roles.DropDownStyle = ComboBoxStyle.DropDownList;
            rol_name = "";
            Cmb_Roles = LLenarCombo.FillComboBox(Cmb_Roles, "SP_Get_Usuario_Rol", idUsuario);
            if (Cmb_Roles.Items.Count.Equals(1))
            {
                Cmb_Roles.SelectedIndex = 0;
                DataRowView fila = (DataRowView)Cmb_Roles.Items[0];
                rol_name = fila["Nombre"].ToString();
                this.Close();

            }
        }

        private void Roles_Load(object sender, EventArgs e)
        {

        }

        private void Cmb_Roles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {
            DataRowView seleccion = (DataRowView)Cmb_Roles.SelectedItem;
            rol_name = seleccion.Row[0].ToString();
            if (rol_name.Equals("") == true)
                MessageBox.Show("Seleccione un rol");
            else
            {
                this.Close();

            }
        }
    }
}
