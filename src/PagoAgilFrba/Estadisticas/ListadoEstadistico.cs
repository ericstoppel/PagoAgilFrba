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

namespace PagoAgilFrba.Estadisticas
{
    public partial class ListadoEstadistico : Form
    {
        SqlServer Server;

        public ListadoEstadistico()
        {
            Server = new SqlServer();
            InitializeComponent();
            cmbAnio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoListado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrimestre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoEstadisticas.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = 1990; i < 2050; i++) {
                cmbAnio.Items.Insert(i - 1990, i);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String anio = cmbAnio.Text;
            String periodoSeleccionado = (cmbTrimestre.SelectedIndex + 1).ToString();
            
            var paramsProcedure = new Dictionary<string, string>();
            paramsProcedure.Add("anio", anio);
            paramsProcedure.Add("numero_trimestre", periodoSeleccionado);
            DataTable resultado = Server.EjecutarSp(GetNombreProcedure(), paramsProcedure);
            if (Utiles.Utiles.handleError(resultado))
            {
                Table_Resultados.DataSource = resultado;
            }
        }

        private String GetNombreProcedure() {
            String[] procedures = { "Clientes_Con_Mas_Pagos", "Clientes_Cumplidores",
                                    "Empresas_Mayor_Monto_Rendido", "Porcentaje_Facturas_Cobradas_x_Empresa" };
            int estadistica = cmbTipoEstadisticas.SelectedIndex;
            String procedure = procedures[estadistica];
            String tipoListado = cmbTipoListado.Text;
            return "SP_Estadisticas_" + procedure + "_Listado_" + tipoListado;
        }
    }
}
