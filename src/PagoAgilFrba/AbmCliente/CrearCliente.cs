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

namespace PagoAgilFrba.AbmCliente
{
    public partial class CrearCliente : Form
    {
        public CrearCliente()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarClienteForm())
            {
                CrearNuevoCliente();
            }
        }

        private Boolean ValidarClienteForm()
        {
            String Nombre = this.txtNombre.Text;
            String Apellido = this.txtApellido.Text;
            String Dni = this.txtDni.Text;
            String Mail = this.txtMail.Text;
            String Direccion = this.txtDireccion.Text;
            String CodigoPostal = this.txtCodigoPostal.Text;
            String FechaNacimiento = this.dtpFechaNacimiento.Text;

            if (Nombre == "" || Apellido == "" || Dni == "" || Mail == "" || Direccion == "" || CodigoPostal == "" || FechaNacimiento == "")
            {
                MessageBox.Show("Complete todos los campos.");
                return false;
            }
            else if (!ValidarMail(Mail)) {
                MessageBox.Show("El mail ingresado ya esta en uso por otro cliente.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private Boolean ValidarMail(String Mail) {
            SqlServer sql = new SqlServer();
            var listaParametros = new Dictionary<string, string>();
            listaParametros.Add("mail", Mail);
            DataTable tabla = sql.EjecutarSp("SP_Validar_Mail_Cliente", listaParametros);

            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
                return false;
            }
            else if (tabla.Rows.Count == 0) {
                return true;
            }
            else 
            {
                return false;
            }
        }

        private void CrearNuevoCliente()
        {
            SqlServer sql = new SqlServer();
            var listaParametros = new Dictionary<string, string>();

            listaParametros.Add("nombre", this.txtNombre.Text);
            listaParametros.Add("apellido", this.txtApellido.Text);
            listaParametros.Add("dni", this.txtDni.Text);
            listaParametros.Add("mail", this.txtMail.Text);
            listaParametros.Add("direccion", this.txtDireccion.Text);
            listaParametros.Add("codigo_postal", this.txtCodigoPostal.Text);
            listaParametros.Add("fecha_nacimiento", this.dtpFechaNacimiento.Value.ToString());
         

            DataTable tabla = sql.EjecutarSp("SP_Create_Cliente", listaParametros);

            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
            }
            else
            {
                MessageBox.Show("Cliente creado exitosamente");
                this.Close();
            }
        }
    }
}
