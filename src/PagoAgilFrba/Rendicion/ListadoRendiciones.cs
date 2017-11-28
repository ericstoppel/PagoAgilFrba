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
    public partial class ListadoRendiciones : Form
    {
        SqlServer Server;

        public ListadoRendiciones()
        {
            Server = new SqlServer();
            InitializeComponent();
            Table_Rendiciones.ReadOnly = true;
            CargarRendiciones();
        }

        public void CargarRendiciones() {
            Utiles.Utiles.AgregarBotonDGV(Table_Rendiciones, "Ver");
            DataTable facturas = Server.EjecutarSp("SP_Get_Rendiciones");
            if (Utiles.Utiles.handleError(facturas))
            {
                Table_Rendiciones.DataSource = facturas;
            }
        }

        private void Table_Rendiciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Utiles.Utiles.ValidarColumna(Table_Rendiciones, "Ver", e))
            {
                DataGridViewRow rendicion = Table_Rendiciones.Rows[e.RowIndex];
                String numero = rendicion.Cells[1].Value.ToString();
                String fecha = rendicion.Cells[2].Value.ToString();
                String porcentaje = rendicion.Cells[3].Value.ToString();
                String devolucion = rendicion.Cells[4].Value.ToString();
                DetalleRendicion detalle = new DetalleRendicion(this, numero, fecha, porcentaje, devolucion);
                detalle.ShowDialog();
            }
        }
    }
}
