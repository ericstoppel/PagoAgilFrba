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

namespace PagoAgilFrba.Pagos
{
    public partial class DetallePago : Form
    {
        SqlServer Server;
        String numeroPago;

        public DetallePago(String numero, String fecha, String importe, String medio, String cliente, String empresa, String sucursal)
        {
            Server = new SqlServer();
            InitializeComponent();
            numeroPago = numero;
            lblNumero.Text = numero;
            lblFecha.Text = fecha;
            lblImporte.Text = importe;
            lblMedio.Text = medio;
            lblCliente.Text = cliente;
            lblEmpresa.Text = empresa;
            lblSucursal.Text = sucursal;
            CargarFacturas();
        }

        private void CargarFacturas()
        {
            var paramsProcedure = new Dictionary<string, string>();
            paramsProcedure.Add("numero_pago", numeroPago);
            DataTable facturas = Server.EjecutarSp("SP_Get_Facturas_Pago", paramsProcedure);
            if (Utiles.Utiles.handleError(facturas))
            {
                Table_Facturas.DataSource = facturas;
            }
        }
    }
}
