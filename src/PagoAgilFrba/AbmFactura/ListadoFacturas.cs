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
    public partial class ListadoFacturas : Form
    {
        SqlServer Server;

        public ListadoFacturas()
        {
            Server = new SqlServer();
            InitializeComponent();
            Table_Facturas.ReadOnly = true;
            CargarFacturas();
            CargarClientes();
            CargarEmpresas();
        }


        public void CargarFacturas()
        {
            Utiles.Utiles.AgregarBotonDGV(Table_Facturas, "Ver");
            DataTable facturas = Server.EjecutarSp("SP_Get_Facturas");
            if (Utiles.Utiles.handleError(facturas))
            {
                Table_Facturas.DataSource = facturas;  
            }
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

        private void btnAgregarFactura_Click(object sender, EventArgs e)
        {
            DataRowView cliente = (DataRowView) cmbClientes.Items[Convert.ToInt32(cmbClientes.SelectedIndex)];
            int idCliente = Convert.ToInt32(cliente[0]);
            DataRowView empresa = (DataRowView)cmbEmpresas.Items[Convert.ToInt32(cmbEmpresas.SelectedIndex)];
            int idEmpresa = Convert.ToInt32(empresa[0]);
            String numeroFactura = txtNumeroFactura.Text;
            DateTime vencimientoFactura = dtpFechaVencimiento.Value;
            String fechaVencimiento = String.Format("{0:yyyy-M-d}", vencimientoFactura);
            DateTime altaFactura = dtpFechaAlta.Value;
            String fechaAlta = String.Format("{0:yyyy-M-d}", altaFactura);

            var paramsProcedure = new Dictionary<string, string>();
            paramsProcedure.Add("id_cliente", idCliente.ToString());
            paramsProcedure.Add("id_empresa", idEmpresa.ToString());
            paramsProcedure.Add("numero_factura", numeroFactura);
            paramsProcedure.Add("fecha_vencimiento", fechaVencimiento);
            paramsProcedure.Add("fecha_alta", fechaAlta);

            DataTable resultado = Server.EjecutarSp("SP_Create_Factura", paramsProcedure);
            if (Utiles.Utiles.handleError(resultado))
            {
                CargarFacturas();
            }

        }

        private void btnRendir_Click(object sender, EventArgs e)
        {
            if (Utiles.Utiles.validarPermisos("Rendiciones"))
            {
                String numerosFactura = GetFacturasSeleccionadas();
                if (numerosFactura == "")
                {
                    MessageBox.Show("No hay facturas seleccionadas");
                    return;
                }
                PantallaRendicion rendicion = new PantallaRendicion(this, numerosFactura);
                rendicion.ShowDialog();
            }
        }

        private String GetFacturasSeleccionadas() {
            if (Table_Facturas.SelectedRows.Count == 0) {
                return "";
            }
            string numerosFactura = "";
            for(int i = 0; i < Table_Facturas.SelectedRows.Count; i++) {
                DataGridViewRow factura = Table_Facturas.Rows[Table_Facturas.SelectedRows[i].Index];
                numerosFactura += "," + factura.Cells[1].Value.ToString();
            }
            return numerosFactura.Substring(1);
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (Utiles.Utiles.validarPermisos("Pagos"))
            {
                String numerosFactura = GetFacturasSeleccionadas();
                if (numerosFactura == "")
                {
                    MessageBox.Show("No hay facturas seleccionadas");
                    return;
                }
                PantallaPago rendicion = new PantallaPago(this, numerosFactura);
                rendicion.ShowDialog();
            }
        }

        private void Table_Facturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Utiles.Utiles.ValidarColumna(Table_Facturas, "Ver", e)) {
                DataGridViewRow facturaSeleccionada = Table_Facturas.Rows[e.RowIndex];
                String cliente = facturaSeleccionada.Cells[3].Value.ToString();
                String empresa = facturaSeleccionada.Cells[2].Value.ToString();
                String numeroFactura = facturaSeleccionada.Cells[1].Value.ToString();
                String fechaAlta = facturaSeleccionada.Cells[4].Value.ToString();
                String vencimiento = facturaSeleccionada.Cells[3].Value.ToString();
                Decimal total = Convert.ToDecimal(facturaSeleccionada.Cells[6].Value);
                String rendida = facturaSeleccionada.Cells[7].Value.ToString();
                String pagada = facturaSeleccionada.Cells[8].Value.ToString();
                String devolucion = facturaSeleccionada.Cells[9].Value.ToString();
                bool facturaRendida = rendida == "Si" ? true : false;
                PantallaFactura factura = new PantallaFactura(this, cliente, empresa, numeroFactura, fechaAlta, vencimiento, total, rendida, pagada, devolucion);
                factura.ShowDialog();
            }
        }
    }
}
