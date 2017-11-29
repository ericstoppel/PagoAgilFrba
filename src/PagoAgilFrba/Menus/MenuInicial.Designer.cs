namespace PagoAgilFrba.Menus
{
    partial class MenuInicial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRoles = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnEmpresas = new System.Windows.Forms.Button();
            this.btnSucursales = new System.Windows.Forms.Button();
            this.btnFacturas = new System.Windows.Forms.Button();
            this.btnRendiciones = new System.Windows.Forms.Button();
            this.btnPagos = new System.Windows.Forms.Button();
            this.btnEstadisticas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRoles
            // 
            this.btnRoles.Location = new System.Drawing.Point(461, 30);
            this.btnRoles.Margin = new System.Windows.Forms.Padding(2);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(129, 40);
            this.btnRoles.TabIndex = 11;
            this.btnRoles.Text = "ABM Rol";
            this.btnRoles.UseVisualStyleBackColor = true;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(11, 28);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(2);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(127, 42);
            this.btnClientes.TabIndex = 2;
            this.btnClientes.Text = "ABM Cliente";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnEmpresas
            // 
            this.btnEmpresas.Location = new System.Drawing.Point(317, 28);
            this.btnEmpresas.Margin = new System.Windows.Forms.Padding(2);
            this.btnEmpresas.Name = "btnEmpresas";
            this.btnEmpresas.Size = new System.Drawing.Size(127, 42);
            this.btnEmpresas.TabIndex = 12;
            this.btnEmpresas.Text = "ABM Empresa";
            this.btnEmpresas.UseVisualStyleBackColor = true;
            this.btnEmpresas.Click += new System.EventHandler(this.btnEmpresas_Click);
            // 
            // btnSucursales
            // 
            this.btnSucursales.Location = new System.Drawing.Point(169, 28);
            this.btnSucursales.Margin = new System.Windows.Forms.Padding(2);
            this.btnSucursales.Name = "btnSucursales";
            this.btnSucursales.Size = new System.Drawing.Size(127, 42);
            this.btnSucursales.TabIndex = 12;
            this.btnSucursales.Text = "ABM Sucursal";
            this.btnSucursales.UseVisualStyleBackColor = true;
            this.btnSucursales.Click += new System.EventHandler(this.btnSucursales_Click);
            // 
            // btnFacturas
            // 
            this.btnFacturas.Location = new System.Drawing.Point(11, 98);
            this.btnFacturas.Margin = new System.Windows.Forms.Padding(2);
            this.btnFacturas.Name = "btnFacturas";
            this.btnFacturas.Size = new System.Drawing.Size(129, 40);
            this.btnFacturas.TabIndex = 13;
            this.btnFacturas.Text = "Facturas";
            this.btnFacturas.UseVisualStyleBackColor = true;
            this.btnFacturas.Click += new System.EventHandler(this.btnFacturas_Click);
            // 
            // btnRendiciones
            // 
            this.btnRendiciones.Location = new System.Drawing.Point(169, 98);
            this.btnRendiciones.Name = "btnRendiciones";
            this.btnRendiciones.Size = new System.Drawing.Size(127, 40);
            this.btnRendiciones.TabIndex = 14;
            this.btnRendiciones.Text = "Rendiciones";
            this.btnRendiciones.UseVisualStyleBackColor = true;
            this.btnRendiciones.Click += new System.EventHandler(this.btnRendiciones_Click);
            // 
            // btnPagos
            // 
            this.btnPagos.Location = new System.Drawing.Point(317, 98);
            this.btnPagos.Name = "btnPagos";
            this.btnPagos.Size = new System.Drawing.Size(127, 40);
            this.btnPagos.TabIndex = 15;
            this.btnPagos.Text = "Listado de pagos";
            this.btnPagos.UseVisualStyleBackColor = true;
            this.btnPagos.Click += new System.EventHandler(this.btnPagos_Click);
            // 
            // btnEstadisticas
            // 
            this.btnEstadisticas.Location = new System.Drawing.Point(461, 98);
            this.btnEstadisticas.Name = "btnEstadisticas";
            this.btnEstadisticas.Size = new System.Drawing.Size(127, 40);
            this.btnEstadisticas.TabIndex = 16;
            this.btnEstadisticas.Text = "Listado estadistico";
            this.btnEstadisticas.UseVisualStyleBackColor = true;
            this.btnEstadisticas.Click += new System.EventHandler(this.btnEstadisticas_Click);
            // 
            // MenuInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(733, 285);
            this.Controls.Add(this.btnEstadisticas);
            this.Controls.Add(this.btnPagos);
            this.Controls.Add(this.btnRendiciones);
            this.Controls.Add(this.btnFacturas);
            this.Controls.Add(this.btnEmpresas);
            this.Controls.Add(this.btnRoles);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnSucursales);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MenuInicial";
            this.Text = "MenuInicial";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRoles;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnEmpresas;
        private System.Windows.Forms.Button btnSucursales;
        private System.Windows.Forms.Button btnFacturas;
        private System.Windows.Forms.Button btnRendiciones;
        private System.Windows.Forms.Button btnPagos;
        private System.Windows.Forms.Button btnEstadisticas;
        
    }
}