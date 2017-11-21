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

namespace PagoAgilFrba.AbmSucursal
{
    public partial class CrearSucursal : Form
    {
        public CrearSucursal()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (ValidarSucursalForm()) {
                CrearNuevaSucursal();
            }
        }

        private Boolean ValidarSucursalForm() {
            String NombreSucursal = this.txtNombreSucursal.Text;
            String DireccionSucursal = this.txtDireccionSucursal.Text;
            String CodigoPostalSucursal = this.txtCodigoPostalSucursal.Text;

            if (NombreSucursal == "" || DireccionSucursal == "" || CodigoPostalSucursal == "")
            {
                MessageBox.Show("Complete todos los campos.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void CrearNuevaSucursal() {
            SqlServer sql = new SqlServer();
            var listaParametros = new Dictionary<string, string>();

            listaParametros.Add("nombre", this.txtNombreSucursal.Text);
            listaParametros.Add("direccion", this.txtDireccionSucursal.Text);
            listaParametros.Add("codigo_postal", this.txtCodigoPostalSucursal.Text);

            DataTable tabla = sql.EjecutarSp("SP_Create_Sucursal", listaParametros);

            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
            }
            else
            {
                MessageBox.Show("Sucursal creada exitosamente");
                this.Close();
            }
        }

    }
}

