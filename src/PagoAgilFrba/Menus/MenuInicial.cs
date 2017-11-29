using PagoAgilFrba.Abm_Cliente;
using PagoAgilFrba.AbmEmpresa;
using PagoAgilFrba.AbmRol;
using PagoAgilFrba.AbmSucursal;
using PagoAgilFrba.AbmFactura;
using PagoAgilFrba.DataBase;
using PagoAgilFrba.Rendicion;
using PagoAgilFrba.Pagos;
using PagoAgilFrba.Estadisticas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Menus
{
    public partial class MenuInicial : Form
    {
       public MenuInicial()
        {
            InitializeComponent();
            ValidarPermisos();
        }

       private void ValidarPermisos() {
           ValidarFuncionalidad("Clientes", btnClientes);
           ValidarFuncionalidad("Empresas", btnEmpresas);
           ValidarFuncionalidad("Sucursales", btnSucursales);
           ValidarFuncionalidad("Roles", btnRoles);
           ValidarFuncionalidad("Facturas", btnFacturas);
           ValidarFuncionalidad("Pagos", btnPagos);
           ValidarFuncionalidad("Rendiciones", btnRendiciones);
           ValidarFuncionalidad("Estadisticas", btnEstadisticas);
       }

       private void ValidarFuncionalidad(String nombreFuncionalidad, Button boton) {
           if (!Utiles.Utiles.validarPermisos(nombreFuncionalidad))
           {
               boton.Visible = false;
           }
       }

       private void btnClientes_Click(object sender, EventArgs e)
       {
           Cl_Abm_Cliente clientes = new Cl_Abm_Cliente();
           clientes.ShowDialog();
       }

       private void btnSucursales_Click(object sender, EventArgs e)
       {
           SucursalForm sucursales = new SucursalForm();
           sucursales.ShowDialog();
       }

       private void btnEmpresas_Click(object sender, EventArgs e)
       {
           EmpresaForm empresas = new EmpresaForm();
           empresas.ShowDialog();
       }

       private void btnRoles_Click(object sender, EventArgs e)
       {
           ListadoRoles roles = new ListadoRoles();
           roles.ShowDialog();
       }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            ListadoFacturas facturas = new ListadoFacturas();
            facturas.ShowDialog();
        }

        private void btnRendiciones_Click(object sender, EventArgs e)
        {
            ListadoRendiciones rendiciones = new ListadoRendiciones();
            rendiciones.ShowDialog();
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            ListadoPagos pagos = new ListadoPagos();
            pagos.ShowDialog();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            ListadoEstadistico listado = new ListadoEstadistico();
            listado.Show();
        }
    }
}
