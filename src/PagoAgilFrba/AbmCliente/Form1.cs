using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.Funcionalidades;
using PagoAgilFrba.Conexiones;

namespace PagoAgilFrba.Abm_Cliente
{
    public partial class Cl_Abm_Cliente : Form
    {
        public Cl_Abm_Cliente()
        {
            InitializeComponent();
        }

        private bool CamposCorrectos()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Por Favor completar todos los campos");
                return false;
            }
            if (txtDNI.Text == "")
            {
                MessageBox.Show("Por Favor completar todos los campos");
                return false;
            }
            if (txtApellido.Text == "")
            {
                MessageBox.Show("Por Favor completar todos los campos");
                return false;
            }
            if (txtTelefono.Text == "")
            {
                MessageBox.Show("Por Favor completar todos los campos");
                return false;
            }
            if (dtpFechaNac.Value >= DateTime.Today)
            {
                MessageBox.Show("Por Favor completar todos los campos");
                return false;
            }
            return true;
        }

        private void BorrarCampos()
        {
            txtNombre.Clear();
            txtDNI.Clear();
            txtMail.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            dtpFechaNac.Text = "";
            txtDireccion.Clear();
            chkActivo.Checked = false;
            txtDNI.Enabled = true;
            txtBuscarDNI.Clear();
            btnEliminar.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarLista();
        }

        private void ActualizarLista()
        {
            SqlServer sql = new SqlServer();
            var parametros = new Dictionary<string, string>();
            parametros.Add("DNI", txtBuscarDNI.Text);
            parametros.Add("NOMBRE", txtBuscarNombre.Text);
            parametros.Add("APELLIDO", txtBuscarApellido.Text);

            DataTable table = sql.EjecutarSp("PR_LISTADO_SELECCION_ABM_CLIENTE", parametros);

            if (table.Rows.Count > 0 && table.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(table.Rows[0].ItemArray[1].ToString());
            }
            else
            {
                listClientes.DataSource = table;
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (CamposCorrectos())
            {
                var parametros = new Dictionary<string, string>();
                SqlServer sql = new SqlServer();

                parametros.Add("NOMBRE", txtNombre.Text);
                parametros.Add("DNI", txtDNI.Text);
                parametros.Add("MAIL", txtMail.Text);
                parametros.Add("APELLIDO", txtApellido.Text);
                parametros.Add("TELEFONO", txtTelefono.Text);
                parametros.Add("FECHANAC", dtpFechaNac.Value.ToString());
                parametros.Add("DIRECCION", txtDireccion.Text);
                parametros.Add("HABILITADO", chkActivo.Checked.ToString());

                DataTable table = sql.EjecutarSp("PR_INSERTAR_MODIFICAR_CLIENTE", parametros);

                if (table.Rows.Count > 0 && table.Rows[0].ItemArray[0].ToString() == "ERROR")
                {
                    MessageBox.Show("Hubo un problema");
                }

                else if (table.Rows.Count > 0 && Int32.Parse((table.Rows[0].ItemArray[0].ToString())) == -1)
                {
                    MessageBox.Show("Hubo un problema");
                }

                else
                {

                    MessageBox.Show("Registro guardado exitosamente");
                    BorrarCampos();

                    ActualizarLista();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (CamposCorrectos())
            {
                var parametros = new Dictionary<string, string>();
                SqlServer sql = new SqlServer();

                parametros.Add("DNI", txtDNI.Text);

                DataTable table = sql.EjecutarSp("PR_BAJA_CLIENTE", parametros);

                if (table.Rows.Count > 0 && table.Rows[0].ItemArray[0].ToString() == "ERROR")
                {
                    MessageBox.Show("Hubo un problema");
                }

                else if (table.Rows.Count > 0 && Int32.Parse((table.Rows[0].ItemArray[0].ToString())) == -1)
                {
                    MessageBox.Show("Hubo un problema");
                }
                else
                {
                    MessageBox.Show("Registro eliminado exitosamente");
                    BorrarCampos();
                    ActualizarLista();
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BorrarCampos();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listClientes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in listClientes.SelectedRows)
            {
                try
                {
                    txtApellido.Text = row.Cells[0].Value.ToString();
                    txtNombre.Text = row.Cells[1].Value.ToString();
                    txtDireccion.Text = row.Cells[2].Value.ToString();
                    txtDNI.Text = row.Cells[3].Value.ToString();
                    chkActivo.Checked = Boolean.Parse(row.Cells[4].Value.ToString());
                    txtMail.Text = row.Cells[6].Value.ToString();
                    txtTelefono.Text = row.Cells[7].Value.ToString();
                    dtpFechaNac.Text = row.Cells[8].Value.ToString();

                    txtDNI.Enabled = false;
                    btnEliminar.Enabled = true;
                }
                catch (Exception ex)
                {
                    // NOTHING TODO
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void chkActivo_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
