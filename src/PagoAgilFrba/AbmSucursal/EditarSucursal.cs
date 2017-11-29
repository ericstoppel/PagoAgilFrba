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

namespace PagoAgilFrba.AbmSucursal
{
    public partial class EditarSucursal : Form
    {
        private int idSucursal;
        public EditarSucursal(int idSucursal)
        {
            InitializeComponent();
            this.idSucursal = idSucursal;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditarSucursal_Load(object sender, EventArgs e)
        {
            SqlServer sql = new SqlServer();
            var listaParametros = new Dictionary<string, string>();
            listaParametros.Add("idSucursal", this.idSucursal.ToString());
            DataTable tabla = sql.EjecutarSp("SP_Get_Sucursal_By_Id", listaParametros);
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
            }
            else
            {
                txtNombreSucursal.Text = tabla.Rows[0].ItemArray[1].ToString();
                txtDireccionSucursal.Text = tabla.Rows[0].ItemArray[2].ToString();
                txtCodigoPostalSucursal.Text = tabla.Rows[0].ItemArray[3].ToString();
                txtActivo.Text = tabla.Rows[0].ItemArray[4].ToString();
            }
        }

        private Boolean ValidarSucursalForm()
        {
            String Nombre = this.txtNombreSucursal.Text;
            String Direccion = this.txtDireccionSucursal.Text;
            String CodigoPostal = this.txtCodigoPostalSucursal.Text;
            String Activo = this.txtActivo.Text;

            if (Nombre == "" || Direccion == "" || CodigoPostal == "" || Activo == "")
            {
                MessageBox.Show("Complete todos los campos.");
                return false;
            }
            else if (Activo != "1" && Activo != "0")
            {
                MessageBox.Show("El campo activo tiene que ser un 1 o un 0.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarSucursalForm())
            {
                SqlServer sql = new SqlServer();
                var listaParametros = new Dictionary<string, string>();
                listaParametros.Add("id", this.idSucursal.ToString());
                listaParametros.Add("nombre", this.txtNombreSucursal.Text);
                listaParametros.Add("direccion", this.txtDireccionSucursal.Text);
                listaParametros.Add("codigo_postal", this.txtCodigoPostalSucursal.Text);
                listaParametros.Add("activo", this.txtActivo.Text);

                DataTable tabla = sql.EjecutarSp("SP_Update_Sucursal", listaParametros);
                if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
                {
                    MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
                }
                else
                {
                    MessageBox.Show("Sucursal editada exitosamente.");
                    this.Close();
                }
            }            
        }
    }
}
