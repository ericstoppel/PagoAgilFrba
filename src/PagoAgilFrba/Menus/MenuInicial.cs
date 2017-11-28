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
        }

        private void MenuInicial_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Rol_Click(object sender, EventArgs e)
        {
            if (Utiles.Utiles.validarPermisos("Roles"))
            {
                ListadoRoles rol = new ListadoRoles();
                rol.ShowDialog();
            }
        }

        private void Btn_ABM_Cliente_Click(object sender, EventArgs e)
        {
            if (Utiles.Utiles.validarPermisos("Clientes"))
            {
                Cl_Abm_Cliente cliente = new Cl_Abm_Cliente();
                cliente.ShowDialog();
            }
        }

        private void Btn_Empresa_Click(object sender, EventArgs e)
        {
            if (Utiles.Utiles.validarPermisos("Empresas"))
            {
                EmpresaForm empresa = new EmpresaForm();
                empresa.ShowDialog();
            }
        }

        private void Btn_Sucursal_Click(object sender, EventArgs e)
        {
            if (Utiles.Utiles.validarPermisos("Sucursales"))
            {
                SucursalForm sucursal = new SucursalForm();
                sucursal.ShowDialog();
            }
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            if (Utiles.Utiles.validarPermisos("Facturas"))
            {
                ListadoFacturas facturas = new ListadoFacturas();
                facturas.ShowDialog();
            }
        }

        private void btnRendiciones_Click(object sender, EventArgs e)
        {
            if (Utiles.Utiles.validarPermisos("Rendiciones"))
            {
                ListadoRendiciones rendiciones = new ListadoRendiciones();
                rendiciones.ShowDialog();
            }
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            if (Utiles.Utiles.validarPermisos("Pagos"))
            {
                ListadoPagos pagos = new ListadoPagos();
                pagos.ShowDialog();
            }
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            if (Utiles.Utiles.validarPermisos("Estadisticas"))
            {
                ListadoEstadistico listado = new ListadoEstadistico();
                listado.Show();
            }
        }
    }
}
