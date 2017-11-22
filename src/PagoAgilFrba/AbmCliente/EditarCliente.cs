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

            }


        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
