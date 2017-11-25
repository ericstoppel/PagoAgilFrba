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

namespace PagoAgilFrba.AbmCliente
{
    public partial class EditarCliente : Form
    {
        private int idCliente;
        public EditarCliente(int idCliente)
        {
            InitializeComponent();
            this.idCliente = idCliente;
        }

        private void EditarCliente_Load(object sender, EventArgs e)
        {
            SqlServer sql = new SqlServer();
            var listaParametros = new Dictionary<string, string>();
            listaParametros.Add("idCliente", this.idCliente.ToString());
            DataTable tabla = sql.EjecutarSp("SP_Get_Cliente_By_Id", listaParametros);
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
            }
            else {
                txtNombre.Text = tabla.Rows[0].ItemArray[1].ToString();
                txtApellido.Text = tabla.Rows[0].ItemArray[2].ToString();
                txtDni.Text = tabla.Rows[0].ItemArray[3].ToString();
                txtMail.Text = tabla.Rows[0].ItemArray[4].ToString();
                txtDireccion.Text = tabla.Rows[0].ItemArray[5].ToString();
                txtCodigoPostal.Text = tabla.Rows[0].ItemArray[6].ToString();
                dtpFechaNacimiento.Text = tabla.Rows[0].ItemArray[7].ToString();
                txtActivo.Text = tabla.Rows[0].ItemArray[8].ToString();
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
            String Activo = this.txtActivo.Text;

            if (Nombre == "" || Apellido == "" || Dni == "" || Mail == "" || Direccion == "" || CodigoPostal == "" || FechaNacimiento == "")
            {
                MessageBox.Show("Complete todos los campos.");
                return false;
            }else if(Activo != "1" && Activo != "0"){
                MessageBox.Show("El campo activo tiene que ser un 1 o un 0.");
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

        private Boolean ValidarMail(String Mail)
        {
            SqlServer sql = new SqlServer();
            var listaParametros = new Dictionary<string, string>();
            listaParametros.Add("mail", Mail);
            DataTable tabla = sql.EjecutarSp("SP_Validar_Mail_Cliente", listaParametros);

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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarClienteForm()) {
                SqlServer sql = new SqlServer();
                var listaParametros = new Dictionary<string, string>();
                listaParametros.Add("id", this.idCliente.ToString());
                listaParametros.Add("nombre", this.txtNombre.Text);
                listaParametros.Add("apellido", this.txtApellido.Text);
                listaParametros.Add("dni", this.txtDni.Text);
                listaParametros.Add("mail", this.txtMail.Text);
                listaParametros.Add("direccion", this.txtDireccion.Text);
                listaParametros.Add("codigo_postal", this.txtCodigoPostal.Text);
                listaParametros.Add("fecha_nacimiento", this.dtpFechaNacimiento.Value.ToString());
                listaParametros.Add("activo", this.txtActivo.Text);

                DataTable tabla = sql.EjecutarSp("SP_Update_Cliente", listaParametros);
                if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
                {
                    MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
                }
                else
                {
                    MessageBox.Show("Cliente editado exitosamente.");
                    this.Close();
                }
            }            
        }
    }
}
