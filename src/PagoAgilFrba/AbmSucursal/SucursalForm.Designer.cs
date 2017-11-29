namespace PagoAgilFrba.AbmSucursal
{
    partial class SucursalForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCrearSucursal = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.dgvSucursales = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnFiltrarSucursales = new System.Windows.Forms.Button();
            this.txtFiltroCodigoPostal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFiltroDireccion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFiltroNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursales)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sucursales";
            // 
            // btnCrearSucursal
            // 
            this.btnCrearSucursal.Location = new System.Drawing.Point(190, 19);
            this.btnCrearSucursal.Name = "btnCrearSucursal";
            this.btnCrearSucursal.Size = new System.Drawing.Size(75, 23);
            this.btnCrearSucursal.TabIndex = 4;
            this.btnCrearSucursal.Text = "Crear";
            this.btnCrearSucursal.UseVisualStyleBackColor = true;
            this.btnCrearSucursal.Click += new System.EventHandler(this.btnCrearSucursal_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(40, 335);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 5;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dgvSucursales
            // 
            this.dgvSucursales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSucursales.Location = new System.Drawing.Point(40, 168);
            this.dgvSucursales.Name = "dgvSucursales";
            this.dgvSucursales.Size = new System.Drawing.Size(827, 150);
            this.dgvSucursales.TabIndex = 6;
            this.dgvSucursales.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSucursales_CellClick);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(214, 335);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnFiltrarSucursales
            // 
            this.btnFiltrarSucursales.Location = new System.Drawing.Point(304, 91);
            this.btnFiltrarSucursales.Name = "btnFiltrarSucursales";
            this.btnFiltrarSucursales.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrarSucursales.TabIndex = 18;
            this.btnFiltrarSucursales.Text = "Filtrar";
            this.btnFiltrarSucursales.UseVisualStyleBackColor = true;
            this.btnFiltrarSucursales.Click += new System.EventHandler(this.btnFiltrarSucursales_Click);
            // 
            // txtFiltroCodigoPostal
            // 
            this.txtFiltroCodigoPostal.Location = new System.Drawing.Point(176, 127);
            this.txtFiltroCodigoPostal.Name = "txtFiltroCodigoPostal";
            this.txtFiltroCodigoPostal.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroCodigoPostal.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Filtrar por codigo postal:";
            // 
            // txtFiltroDireccion
            // 
            this.txtFiltroDireccion.Location = new System.Drawing.Point(165, 96);
            this.txtFiltroDireccion.Name = "txtFiltroDireccion";
            this.txtFiltroDireccion.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroDireccion.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Filtrar por direccion:";
            // 
            // txtFiltroNombre
            // 
            this.txtFiltroNombre.Location = new System.Drawing.Point(165, 61);
            this.txtFiltroNombre.Name = "txtFiltroNombre";
            this.txtFiltroNombre.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroNombre.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Filtrar por nombre:";
            // 
            // SucursalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 386);
            this.Controls.Add(this.btnFiltrarSucursales);
            this.Controls.Add(this.txtFiltroCodigoPostal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFiltroDireccion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFiltroNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dgvSucursales);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnCrearSucursal);
            this.Controls.Add(this.label1);
            this.Name = "SucursalForm";
            this.Text = "SucursalForm";
            this.Load += new System.EventHandler(this.SucursalForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCrearSucursal;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dgvSucursales;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnFiltrarSucursales;
        private System.Windows.Forms.TextBox txtFiltroCodigoPostal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFiltroDireccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFiltroNombre;
        private System.Windows.Forms.Label label2;
    }
}