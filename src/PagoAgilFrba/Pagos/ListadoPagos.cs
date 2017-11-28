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
    public partial class ListadoPagos : Form
    {
        SqlServer Server;

        public ListadoPagos()
        {
            Server = new SqlServer();
            InitializeComponent();
            Table_Pagos.ReadOnly = true;
            CargarPagos();
        }

        private void CargarPagos()
        {
            Utiles.Utiles.AgregarBotonDGV(Table_Pagos, "Ver");
            DataTable pagos = Server.EjecutarSp("SP_Get_Pagos");
            if (Utiles.Utiles.handleError(pagos))
            {
                Table_Pagos.DataSource = pagos;
            }
        }

        private void Table_Pagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Utiles.Utiles.ValidarColumna(Table_Pagos, "Ver", e))
            {
                DataGridViewRow pago = Table_Pagos.Rows[e.RowIndex];
                String numero = pago.Cells[1].Value.ToString();
                String fecha = pago.Cells[2].Value.ToString();
                String importe = pago.Cells[3].Value.ToString();
                String medio = pago.Cells[4].Value.ToString();
                String cliente = pago.Cells[5].Value.ToString();
                String empresa = pago.Cells[6].Value.ToString();
                String sucursal = pago.Cells[7].Value.ToString();
                DetallePago detalle = new DetallePago(numero, fecha, importe, medio, cliente, empresa, sucursal);
                detalle.ShowDialog();
            }
        }
    }
}
