using PagoAgilFrba.DataBase;
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
            else if (!ValidarCuit(Cuit))
            {
                MessageBox.Show("El cuit ingresado ya esta en uso por otra empresa.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private Boolean ValidarCuit(String Cuit)
        {
            SqlServer sql = new SqlServer();
            var listaParametros = new Dictionary<string, string>();
            listaParametros.Add("cuit", Cuit);
            listaParametros.Add("id_empresa", "-1");
            DataTable tabla = sql.EjecutarSp("SP_Validar_Cuit_Empresa", listaParametros);

            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
                return false;
            }
            else if (tabla.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CrearNuevaEmpresa()
        {
            SqlServer sql = new SqlServer();
            String rubroNombre = this.cmbRubro.Text;
            String idRubro = "";
            var listaParametrosRubro = new Dictionary<string, string>();
            listaParametrosRubro.Add("nombre", rubroNombre);
            DataTable tablaRubro = sql.EjecutarSp("SP_Get_Rubro_By_Nombre", listaParametrosRubro);
            if (tablaRubro.Rows.Count > 0 && tablaRubro.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tablaRubro.Rows[0].ItemArray[1].ToString());
            }
            else
            {
                idRubro = tablaRubro.Rows[0].ItemArray[0].ToString();
            }

            var listaParametros = new Dictionary<string, string>();

            listaParametros.Add("nombre", this.txtNombre.Text);
            listaParametros.Add("direccion", this.txtDireccion.Text);
            listaParametros.Add("cuit", this.txtCuit.Text);
            listaParametros.Add("id_rubro", idRubro);

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

        private void CrearEmpresa_Load(object sender, EventArgs e)
        {
            SqlServer sql = new SqlServer();
            DataTable tabla = sql.EjecutarSp("SP_Get_Rubros");

            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
            }
            this.cmbRubro.DataSource = tabla;
            this.cmbRubro.ValueMember = "nombre";
            this.cmbRubro.SelectedIndex = -1;
        }
    }
}
