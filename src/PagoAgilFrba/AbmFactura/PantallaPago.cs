using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.DataBase;
using PagoAgilFrba.Utiles;

namespace PagoAgilFrba.AbmFactura
{
    public partial class PantallaPago : Form
    {
        SqlServer Server;
        ListadoFacturas listado;
        String numerosFacturas;

        public PantallaPago(ListadoFacturas _listado, String _numerosFacturas)
        {
            Server = new SqlServer();
            InitializeComponent();
            listado = _listado;
            numerosFacturas = _numerosFacturas;
            lblNumerosFactura.Text = numerosFacturas;
            CargarClientes();
            CargarEmpresas();
            CargarMediosPago();
        }

        private void CargarClientes()
        {
            DataTable clientes = Server.EjecutarSp("SP_Get_Nombres_Clientes");
            if (Utiles.Utiles.handleError(clientes))
            {
                cmbClientes.DataSource = clientes;
                cmbClientes.DisplayMember = "nombre";
            }
        }

        private void CargarEmpresas()
        {
            DataTable empresas = Server.EjecutarSp("PR_Get_Empresas");
            if (Utiles.Utiles.handleError(empresas))
            {
                cmbEmpresas.DataSource = empresas;
                cmbEmpresas.DisplayMember = "Nombre";
            }
        }

        private void CargarMediosPago()
        {
            DataTable mediosPago = Server.EjecutarSp("SP_Get_Medios_Pago");
            if (Utiles.Utiles.handleError(mediosPago))
            {
                cmbMedioPago.DataSource = mediosPago;
                cmbMedioPago.DisplayMember = "nombre";
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            String importe = txtImporte.Text;
            if (importe == "" || !Utiles.Utiles.isNumeric(importe)) {
                MessageBox.Show("El importe no es valido");
                return;
            }

            DataRowView cliente = (DataRowView)cmbClientes.Items[Convert.ToInt32(cmbClientes.SelectedIndex)];
            int idCliente = Convert.ToInt32(cliente[0]);
            DataRowView empresa = (DataRowView)cmbEmpresas.Items[Convert.ToInt32(cmbEmpresas.SelectedIndex)];
            int idEmpresa = Convert.ToInt32(empresa[0]);
            DataRowView medioPago = (DataRowView)cmbMedioPago.Items[Convert.ToInt32(cmbMedioPago.SelectedIndex)];
            int idMedioPago = Convert.ToInt32(medioPago[0]);

            var paramsProcedure = new Dictionary<string, string>();
            paramsProcedure.Add("id_cliente", idCliente.ToString());
            paramsProcedure.Add("id_empresa", idEmpresa.ToString());
            paramsProcedure.Add("id_medio_pago", idMedioPago.ToString());
            paramsProcedure.Add("id_usuario", "1");
            paramsProcedure.Add("id_sucursal", "1");
            paramsProcedure.Add("importe", importe);
            paramsProcedure.Add("numeros_factura", numerosFacturas);

            DataTable resultado = Server.EjecutarSp("SP_Create_Pago", paramsProcedure);
            if (Utiles.Utiles.handleError(resultado))
            {
                listado.CargarFacturas();
                Close();
            }
        }
    }
}
