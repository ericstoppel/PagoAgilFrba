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
            this.Btn_Rol = new System.Windows.Forms.Button();
            this.Btn_ABM_Cliente = new System.Windows.Forms.Button();
            this.Btn_Empresa = new System.Windows.Forms.Button();
            this.Btn_Sucursal = new System.Windows.Forms.Button();
            this.btnFacturas = new System.Windows.Forms.Button();
            this.btnRendiciones = new System.Windows.Forms.Button();
            this.btnPagos = new System.Windows.Forms.Button();
            this.btnEstadisticas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_Rol
            // 
            this.Btn_Rol.Location = new System.Drawing.Point(461, 30);
            this.Btn_Rol.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Rol.Name = "Btn_Rol";
            this.Btn_Rol.Size = new System.Drawing.Size(129, 40);
            this.Btn_Rol.TabIndex = 11;
            this.Btn_Rol.Text = "ABM Rol";
            this.Btn_Rol.UseVisualStyleBackColor = true;
            this.Btn_Rol.Click += new System.EventHandler(this.Btn_Rol_Click);
            // 
            // Btn_ABM_Cliente
            // 
            this.Btn_ABM_Cliente.Location = new System.Drawing.Point(11, 28);
            this.Btn_ABM_Cliente.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_ABM_Cliente.Name = "Btn_ABM_Cliente";
            this.Btn_ABM_Cliente.Size = new System.Drawing.Size(127, 42);
            this.Btn_ABM_Cliente.TabIndex = 2;
            this.Btn_ABM_Cliente.Text = "ABM Cliente";
            this.Btn_ABM_Cliente.UseVisualStyleBackColor = true;
            this.Btn_ABM_Cliente.Click += new System.EventHandler(this.Btn_ABM_Cliente_Click);
            // 
            // Btn_Empresa
            // 
            this.Btn_Empresa.Location = new System.Drawing.Point(317, 28);
            this.Btn_Empresa.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Empresa.Name = "Btn_Empresa";
            this.Btn_Empresa.Size = new System.Drawing.Size(127, 42);
            this.Btn_Empresa.TabIndex = 12;
            this.Btn_Empresa.Text = "ABM Empresa";
            this.Btn_Empresa.UseVisualStyleBackColor = true;
            this.Btn_Empresa.Click += new System.EventHandler(this.Btn_Empresa_Click);
            // 
            // Btn_Sucursal
            // 
            this.Btn_Sucursal.Location = new System.Drawing.Point(169, 28);
            this.Btn_Sucursal.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Sucursal.Name = "Btn_Sucursal";
            this.Btn_Sucursal.Size = new System.Drawing.Size(127, 42);
            this.Btn_Sucursal.TabIndex = 12;
            this.Btn_Sucursal.Text = "ABM Sucursal";
            this.Btn_Sucursal.UseVisualStyleBackColor = true;
            this.Btn_Sucursal.Click += new System.EventHandler(this.Btn_Sucursal_Click);
            // 
            // btnFacturas
            // 
            this.btnFacturas.Location = new System.Drawing.Point(11, 98);
            this.btnFacturas.Margin = new System.Windows.Forms.Padding(2);
            this.btnFacturas.Name = "btnFacturas";
            this.btnFacturas.Size = new System.Drawing.Size(129, 40);
            this.btnFacturas.TabIndex = 13;
            this.btnFacturas.Text = "Manejo de facturas";
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
            this.btnPagos.Text = "Pagos";
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
            this.Controls.Add(this.Btn_Empresa);
            this.Controls.Add(this.Btn_Rol);
            this.Controls.Add(this.Btn_ABM_Cliente);
            this.Controls.Add(this.Btn_Sucursal);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MenuInicial";
            this.Text = "MenuInicial";
            this.Load += new System.EventHandler(this.MenuInicial_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Rol;
        private System.Windows.Forms.Button Btn_ABM_Cliente;
        private System.Windows.Forms.Button Btn_Empresa;
        private System.Windows.Forms.Button Btn_Sucursal;
        private System.Windows.Forms.Button btnFacturas;
        private System.Windows.Forms.Button btnRendiciones;
        private System.Windows.Forms.Button btnPagos;
        private System.Windows.Forms.Button btnEstadisticas;
        
    }
}