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
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursales)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sucursales";
            // 
            // btnCrearSucursal
            // 
            this.btnCrearSucursal.Location = new System.Drawing.Point(173, 12);
            this.btnCrearSucursal.Name = "btnCrearSucursal";
            this.btnCrearSucursal.Size = new System.Drawing.Size(75, 23);
            this.btnCrearSucursal.TabIndex = 4;
            this.btnCrearSucursal.Text = "Crear";
            this.btnCrearSucursal.UseVisualStyleBackColor = true;
            this.btnCrearSucursal.Click += new System.EventHandler(this.btnCrearSucursal_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(40, 314);
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
            this.dgvSucursales.Location = new System.Drawing.Point(30, 59);
            this.dgvSucursales.Name = "dgvSucursales";
            this.dgvSucursales.Size = new System.Drawing.Size(240, 150);
            this.dgvSucursales.TabIndex = 6;
            // 
            // SucursalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 386);
            this.Controls.Add(this.dgvSucursales);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnCrearSucursal);
            this.Controls.Add(this.label1);
            this.Name = "SucursalForm";
            this.Text = "SucursalForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCrearSucursal;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dgvSucursales;
    }
}