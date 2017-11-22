﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.Funcionalidades;
using PagoAgilFrba.Conexiones;
using PagoAgilFrba.AbmCliente;

namespace PagoAgilFrba.Abm_Cliente
{
    public partial class Cl_Abm_Cliente : Form
    {
        public Cl_Abm_Cliente()
        {
            InitializeComponent();
            this.dgvClientes.DataSource = GetClientes();
            AgregarEditar();
            AgregarBorrar();
        }

        private static DataTable GetClientes()
        {
            SqlServer sql = new SqlServer();
            DataTable tabla = sql.EjecutarSp("PR_Get_Clientes");
            if (tabla.Rows.Count > 0 && tabla.Rows[0].ItemArray[0].ToString() == "ERROR")
            {
                MessageBox.Show(tabla.Rows[0].ItemArray[1].ToString());
                return null;
            }
            return tabla;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            CrearCliente crearCliente = new CrearCliente();
            crearCliente.Show();
        }

        private void AgregarEditar()
        {
            if (dgvClientes.Columns.Contains("Editar"))
                dgvClientes.Columns.Remove("Editar");
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Text = "Editar";
            btnEditar.Name = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            dgvClientes.Columns.Add(btnEditar);
        }

        private void AgregarBorrar()
        {
            if (dgvClientes.Columns.Contains("Borrar"))
                dgvClientes.Columns.Remove("Borrar");
            DataGridViewButtonColumn btnBorrar = new DataGridViewButtonColumn();
            btnBorrar.Text = "Borrar";
            btnBorrar.Name = "Borrar";
            btnBorrar.UseColumnTextForButtonValue = true;
            dgvClientes.Columns.Add(btnBorrar);
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvClientes.Columns["Editar"].Index && e.RowIndex >= 0)
            {
                int idAEditar = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["id"].Value);
                EditarCliente editarCliente = new EditarCliente(idAEditar);
                editarCliente.Show();
                return;
            }
           /* if (e.ColumnIndex == dgvClientes.Columns["Borrar"].Index && e.RowIndex >= 0)
            {
                String dniABorrar = dataGridView_Cliente.Rows[e.RowIndex].Cells["Dni"].Value.ToString();
                Decimal idABorrar = comunicador.SelectFromWhere("clie_id", "Cliente", "clie_dni", Convert.ToDecimal(dniClienteAEliminar));
                Boolean resultado = comunicador.EliminarCliente(idClienteAEliminar);
                if (resultado) MessageBox.Show("Se elimino correctamente");
                this.dgvClientes.DataSource = GetClientes();
                AgregarEditar();
                AgregarBorrar();
                return;
            }*/
        }
    }
}