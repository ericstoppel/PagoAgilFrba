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
    public partial class PantallaFactura : Form
    {
        SqlServer Server;
        String numeroFactura;
        Decimal total;
        bool editable;
        ListadoFacturas listado;

        public PantallaFactura(ListadoFacturas _listado, String _cliente, String _empresa, String _numeroFactura, String _fechaAlta, String _fechaVencimiento, Decimal _total, String _rendida, String _pagada, String _devolucion)
        {
            Server = new SqlServer();
            InitializeComponent();
            Table_Detalle_Factura.ReadOnly = true;
            listado = _listado;
            numeroFactura = _numeroFactura;
            total = _total;
            editable = _rendida == "No" && _pagada == "No" ? true : false;
            lblCliente.Text = _cliente;
            lblEmpresa.Text = _empresa;
            lblFechaVencimiento.Text = _fechaVencimiento;
            lblFechaAlta.Text = _fechaAlta;
            lblTotal.Text = "$" + _total.ToString();
            lblNumeroFactura.Text = numeroFactura;
            CargarDetalle();
            if (!editable) {
                grpNuevoItem.Enabled = false;
                grpDevolucion.Enabled = false;
                btnEliminar.Enabled = false;
                lblFacturaRendida.Visible = true;
            }
            if (_devolucion == "Si")
            {
                grpNuevoItem.Enabled = false;
                grpDevolucion.Enabled = false;
                grpInfoDevolucion.Visible = true;
                CargarDevolucion();
            }
            if (!Utiles.Utiles.validarPermisos("Devoluciones facturas")) {
                grpInfoDevolucion.Visible = false;
                grpDevolucion.Visible = false;
            }
        }

        private void CargarDevolucion()
        {
            var paramsProcedure = new Dictionary<string, string>();
            paramsProcedure.Add("numero_factura", numeroFactura);

            DataTable devolucion = Server.EjecutarSp("SP_Get_Devolucion_x_Numero_Factura", paramsProcedure);
            if (Utiles.Utiles.handleError(devolucion))
            {
                lblMotivo.Text = devolucion.Rows[0].ItemArray[1].ToString();
                lblInfo.Text = devolucion.Rows[0].ItemArray[2].ToString();
            }
        }

        private void CargarDetalle() {
            var paramsProcedure = new Dictionary<string, string>();
            paramsProcedure.Add("numero_factura", numeroFactura);

            DataTable detalle = Server.EjecutarSp("SP_Get_Detalle_Factura", paramsProcedure);
            if (Utiles.Utiles.handleError(detalle))
            {
                Table_Detalle_Factura.DataSource = detalle;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            String nombreItem = txtNombreItem.Text;
            String monto = txtMontoItem.Text;
            String cantidad = txtCantidad.Text;

            if (nombreItem == "" || monto == "" || cantidad == "")
            {
                MessageBox.Show("Faltan completar datos");
                return;
            }
            
            var paramsProcedure = new Dictionary<string, string>();
            paramsProcedure.Add("numero_factura", numeroFactura);
            paramsProcedure.Add("nombre", nombreItem);
            paramsProcedure.Add("monto", monto);
            paramsProcedure.Add("cantidad", cantidad);

            DataTable resultado = Server.EjecutarSp("SP_Add_Item_Factura", paramsProcedure);
            if (Utiles.Utiles.handleError(resultado))
            {
                total += Convert.ToDecimal(monto) * Convert.ToDecimal(cantidad);
                lblTotal.Text = "$" + total.ToString();
                txtNombreItem.Text = "";
                txtMontoItem.Text = "";
                txtCantidad.Text = "";
                CargarDetalle();
                listado.CargarFacturas();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            String motivo = txtMotivo.Text;
            String info = txtInfo.Text;

            if (motivo != "" && info != "")
            {
                var paramsProcedure = new Dictionary<string, string>();
                paramsProcedure.Add("motivo", motivo);
                paramsProcedure.Add("id_usuario", Global.IdUsuario);
                paramsProcedure.Add("informacion_adicional", info);
                paramsProcedure.Add("numero_factura", numeroFactura);

                DataTable resultado = Server.EjecutarSp("SP_Create_Devolucion_Factura", paramsProcedure);
                if (Utiles.Utiles.handleError(resultado))
                {
                    listado.CargarFacturas();
                    Close();
                }
            }
            else {
                MessageBox.Show("Faltan completar datos");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var paramsProcedure = new Dictionary<string, string>();
            paramsProcedure.Add("numero_factura", numeroFactura);

            DataTable resultado = Server.EjecutarSp("SP_Eliminar_Factura", paramsProcedure);
            if (Utiles.Utiles.handleError(resultado))
            {
                MessageBox.Show("Factura eliminada correctamente");
                listado.CargarFacturas();
                Close();
            }
        }
    }
}
