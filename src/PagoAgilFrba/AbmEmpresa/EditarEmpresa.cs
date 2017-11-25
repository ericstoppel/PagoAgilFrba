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
    public partial class EditarEmpresa : Form
    {
        private int idEmpresa;
        public EditarEmpresa(int idEmpresa)
        {
            InitializeComponent();
            this.idEmpresa = idEmpresa;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditarEmpresa_Load(object sender, EventArgs e)
        {
            SqlServer sql = new SqlServer();
            DataTable tablaRubros = sql.EjecutarSp("PR_Get_Rubros");

            if (tablaRubros.Rows.Count > 0 && tablaRubros.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tablaRubros.Rows[0].ItemArray[1].ToString());
            }
            this.cmbRubro.DataSource = tablaRubros;
            this.cmbRubro.ValueMember = "nombre";
            this.cmbRubro.SelectedIndex = -1;

            var listaParametros = new Dictionary<string, string>();
            listaParametros.Add("idEmpresa", this.idEmpresa.ToString());
            DataTable tabla = sql.EjecutarSp("SP_Get_Empresa_By_Id", listaParametros);
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
            }
            else
            {
                txtNombre.Text = tabla.Rows[0].ItemArray[1].ToString();
                txtCuit.Text = tabla.Rows[0].ItemArray[2].ToString();
                txtDireccion.Text = tabla.Rows[0].ItemArray[3].ToString();
                cmbRubro.Text = tabla.Rows[0].ItemArray[4].ToString();
                txtActivo.Text = tabla.Rows[0].ItemArray[5].ToString();
            }
        }

        private Boolean ValidarEmpresaForm()
        {
            String Nombre = this.txtNombre.Text;
            String Direccion = this.txtDireccion.Text;
            String Cuit = this.txtCuit.Text;
            String Activo = this.txtActivo.Text;

            if (Nombre == "" || Cuit == "" || Direccion == "")
            {
                MessageBox.Show("Complete todos los campos.");
                return false;
            
            }else if(Activo != "1" && Activo != "0"){
                MessageBox.Show("El campo activo tiene que ser un 1 o un 0.");
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarEmpresaForm())
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
                listaParametros.Add("id", this.idEmpresa.ToString());
                listaParametros.Add("nombre", this.txtNombre.Text);
                listaParametros.Add("direccion", this.txtDireccion.Text);
                listaParametros.Add("cuit", this.txtCuit.Text);
                listaParametros.Add("id_rubro", idRubro);
                listaParametros.Add("activo", this.txtActivo.Text);

                DataTable tabla = sql.EjecutarSp("SP_Update_Empresa", listaParametros);
                if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
                {
                    MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
                }
                else
                {
                    MessageBox.Show("Empresa editada exitosamente.");
                    this.Close();
                }
            }         
        }
    }
}
