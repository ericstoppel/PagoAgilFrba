namespace PagoAgilFrba.AbmSucursal
{
    partial class EditarSucursal
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
            this.txtCodigoPostalSucursal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDireccionSucursal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreSucursal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtActivo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCodigoPostalSucursal
            // 
            this.txtCodigoPostalSucursal.Location = new System.Drawing.Point(115, 117);
            this.txtCodigoPostalSucursal.Name = "txtCodigoPostalSucursal";
            this.txtCodigoPostalSucursal.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoPostalSucursal.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Codigo postal:";
            // 
            // txtDireccionSucursal
            // 
            this.txtDireccionSucursal.Location = new System.Drawing.Point(96, 76);
            this.txtDireccionSucursal.Name = "txtDireccionSucursal";
            this.txtDireccionSucursal.Size = new System.Drawing.Size(100, 20);
            this.txtDireccionSucursal.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Direccion:";
            // 
            // txtNombreSucursal
            // 
            this.txtNombreSucursal.Location = new System.Drawing.Point(88, 38);
            this.txtNombreSucursal.Name = "txtNombreSucursal";
            this.txtNombreSucursal.Size = new System.Drawing.Size(100, 20);
            this.txtNombreSucursal.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nombre:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(102, 187);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Activo: 1. Inactivo: 0.";
            // 
            // txtActivo
            // 
            this.txtActivo.Location = new System.Drawing.Point(105, 153);
            this.txtActivo.Name = "txtActivo";
            this.txtActivo.Size = new System.Drawing.Size(100, 20);
            this.txtActivo.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Activo:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(188, 217);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 36;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(34, 217);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 35;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // EditarSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtActivo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.txtCodigoPostalSucursal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDireccionSucursal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombreSucursal);
            this.Controls.Add(this.label1);
            this.Name = "EditarSucursal";
            this.Text = "EditarSucursal";
            this.Load += new System.EventHandler(this.EditarSucursal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodigoPostalSucursal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDireccionSucursal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreSucursal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtActivo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnVolver;
    }
}