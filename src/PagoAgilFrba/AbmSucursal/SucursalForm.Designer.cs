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
            this.lblSucursal = new System.Windows.Forms.Label();
            this.btnEditarSucursal = new System.Windows.Forms.Button();
            this.btnAgregarSucursal = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSucursal.Location = new System.Drawing.Point(99, 22);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(110, 25);
            this.lblSucursal.TabIndex = 7;
            this.lblSucursal.Text = "Sucursales";
            // 
            // btnEditarSucursal
            // 
            this.btnEditarSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarSucursal.Location = new System.Drawing.Point(83, 148);
            this.btnEditarSucursal.Name = "btnEditarSucursal";
            this.btnEditarSucursal.Size = new System.Drawing.Size(135, 54);
            this.btnEditarSucursal.TabIndex = 1;
            this.btnEditarSucursal.Text = "Modificar o Eliminar Sucursal";
            this.btnEditarSucursal.UseVisualStyleBackColor = true;
            this.btnEditarSucursal.Click += new System.EventHandler(this.btnEditarSucursal_Click);
            // 
            // btnAgregarSucursal
            // 
            this.btnAgregarSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarSucursal.Location = new System.Drawing.Point(83, 65);
            this.btnAgregarSucursal.Name = "btnAgregarSucursal";
            this.btnAgregarSucursal.Size = new System.Drawing.Size(135, 54);
            this.btnAgregarSucursal.TabIndex = 0;
            this.btnAgregarSucursal.Text = "Agregar Sucursal";
            this.btnAgregarSucursal.UseVisualStyleBackColor = true;
            this.btnAgregarSucursal.Click += new System.EventHandler(this.btnAgregarSucursal_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(15, 321);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(144, 35);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "< Volver al Menú Principal";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // SucursalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 386);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblSucursal);
            this.Controls.Add(this.btnEditarSucursal);
            this.Controls.Add(this.btnAgregarSucursal);
            this.Name = "SucursalForm";
            this.Text = "ClienteForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.Button btnEditarSucursal;
        private System.Windows.Forms.Button btnAgregarSucursal;
        private System.Windows.Forms.Button btnVolver;
    }
}