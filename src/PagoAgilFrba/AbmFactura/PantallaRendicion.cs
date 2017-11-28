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
    public partial class PantallaRendicion : Form
    {
        SqlServer Server;
        ListadoFacturas listado;
        String numerosFacturas;

        public PantallaRendicion(ListadoFacturas _listado, String _numerosFacturas)
        {
            Server = new SqlServer();
            InitializeComponent();
            listado = _listado;
            numerosFacturas = _numerosFacturas;
            lblNumerosFactura.Text = numerosFacturas;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            String porcentaje = txtPorcentaje.Text;
            if (porcentaje == "" || !Utiles.Utiles.isNumeric(porcentaje))
            {
                MessageBox.Show("Porcentaje invalido");
                return;
            }
            var paramsProcedure = new Dictionary<string, string>();
            paramsProcedure.Add("porcentaje_comision", porcentaje);
            paramsProcedure.Add("numeros_factura", numerosFacturas);

            DataTable resultado = Server.EjecutarSp("SP_Rendir_Facturas", paramsProcedure);
            if (Utiles.Utiles.handleError(resultado))
            {
                listado.CargarFacturas();
                Close();
            }
        }
    }
}
