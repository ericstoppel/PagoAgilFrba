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

namespace PagoAgilFrba.Rendicion
{
    public partial class DetalleRendicion : Form
    {
        SqlServer Server;
        String numeroRendicion;
        ListadoRendiciones listadoRendiciones;

        public DetalleRendicion(ListadoRendiciones listado, String numero, String fecha, String porcentaje, String cantFacturas, String monto, String devolucion)
        {
            Server = new SqlServer();
            InitializeComponent();
            Table_Detalle.ReadOnly = true;
            lblDevolucion.Text = devolucion;
            numeroRendicion = numero;
            lblFecha.Text = fecha;
            lblNumeroRendicion.Text = numero;
            lblPorcentaje.Text = porcentaje;
            lblCantFacturas.Text = cantFacturas;
            lblMonto.Text = "$" + monto;
            listadoRendiciones = listado;
            CargarDetalleRendicion();
            if (devolucion == "Si") {
                grpDevolucion.Enabled = false;
                grpInfoDevolucion.Visible = true;
                CargarDevolucion();
            }
        }

        public void CargarDetalleRendicion() {
            var paramsProcedure = new Dictionary<string, string>();
            paramsProcedure.Add("numero_rendicion", numeroRendicion);

            DataTable detalle = Server.EjecutarSp("SP_Get_Detalle_Rendicion", paramsProcedure);
            if (Utiles.Utiles.handleError(detalle))
            {
                Table_Detalle.DataSource = detalle;
            }
        }

        private void CargarDevolucion()
        {
            var paramsProcedure = new Dictionary<string, string>();
            paramsProcedure.Add("numero_rendicion", numeroRendicion);

            DataTable devolucion = Server.EjecutarSp("SP_Get_Devolucion_x_Numero_Rendicion", paramsProcedure);
            if (Utiles.Utiles.handleError(devolucion))
            {
                lblMotivo.Text = devolucion.Rows[0].ItemArray[1].ToString();
                lblInfo.Text = devolucion.Rows[0].ItemArray[2].ToString();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            String motivo = txtMotivo.Text;
            String info = txtInfo.Text;

            if (motivo != "" && info != "") {
                var paramsProcedure = new Dictionary<string, string>();
                paramsProcedure.Add("motivo", motivo);
                paramsProcedure.Add("id_usuario", Global.IdUsuario);
                paramsProcedure.Add("informacion_adicional", info);
                paramsProcedure.Add("numero_rendicion", numeroRendicion);

                DataTable resultado = Server.EjecutarSp("SP_Create_Devolucion_Rendicion", paramsProcedure);
                if (Utiles.Utiles.handleError(resultado))
                {
                    listadoRendiciones.CargarRendiciones();
                    Close();
                }
                else
                {
                    MessageBox.Show("Faltan completar datos");
                }
            }

            
        }
    }
}
