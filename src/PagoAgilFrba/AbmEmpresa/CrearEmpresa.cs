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
    public partial class CrearEmpresa : Form
    {
        public CrearEmpresa()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (ValidarEmpresaForm())
            {
                CrearNuevaEmpresa();
            }
        }

        private Boolean ValidarEmpresaForm()
        {
            String Nombre = this.txtNombre.Text;
            String Direccion = this.txtDireccion.Text;
            String Cuit = this.txtCuit.Text;

            if (Nombre == "" || Cuit == "" || Direccion == "")
            {
                MessageBox.Show("Complete todos los campos.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void CrearNuevaEmpresa()
        {
            SqlServer sql = new SqlServer();
            var listaParametros = new Dictionary<string, string>();

            listaParametros.Add("nombre", this.txtNombre.Text);
            listaParametros.Add("direccion", this.txtDireccion.Text);
            listaParametros.Add("cuit", this.txtCuit.Text);
            listaParametros.Add("id_rubro", "1");

            DataTable tabla = sql.EjecutarSp("SP_Create_Empresa", listaParametros);

            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
            }
            else
            {
                MessageBox.Show("Empresa creada exitosamente");
                this.Close();
            }
        }
    }
}
