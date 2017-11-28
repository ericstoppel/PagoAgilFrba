namespace PagoAgilFrba.Rendicion
{
    partial class DetalleRendicion
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
            this.Table_Detalle = new System.Windows.Forms.DataGridView();
            this.grpDevolucion = new System.Windows.Forms.GroupBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblNumeroRendicion = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.lblDevolucion = new System.Windows.Forms.Label();
            this.grpInfoDevolucion = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Table_Detalle)).BeginInit();
            this.grpDevolucion.SuspendLayout();
            this.grpInfoDevolucion.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Facturas involucradas:";
            // 
            // Table_Detalle
            // 
            this.Table_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table_Detalle.Location = new System.Drawing.Point(26, 219);
            this.Table_Detalle.Name = "Table_Detalle";
            this.Table_Detalle.Size = new System.Drawing.Size(649, 169);
            this.Table_Detalle.TabIndex = 1;
            // 
            // grpDevolucion
            // 
            this.grpDevolucion.Controls.Add(this.btnAceptar);
            this.grpDevolucion.Controls.Add(this.txtInfo);
            this.grpDevolucion.Controls.Add(this.label3);
            this.grpDevolucion.Controls.Add(this.txtMotivo);
            this.grpDevolucion.Controls.Add(this.label2);
            this.grpDevolucion.Location = new System.Drawing.Point(26, 420);
            this.grpDevolucion.Name = "grpDevolucion";
            this.grpDevolucion.Size = new System.Drawing.Size(685, 103);
            this.grpDevolucion.TabIndex = 2;
            this.grpDevolucion.TabStop = false;
            this.grpDevolucion.Text = "Generar devolucion";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(242, 60);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(116, 37);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(418, 28);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(231, 20);
            this.txtInfo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Informacion adicional:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(54, 28);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(182, 20);
            this.txtMotivo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Motivo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Numero rendicion:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fecha:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Porcentaje comision:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Devolucion:";
            // 
            // lblNumeroRendicion
            // 
            this.lblNumeroRendicion.AutoSize = true;
            this.lblNumeroRendicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroRendicion.Location = new System.Drawing.Point(162, 17);
            this.lblNumeroRendicion.Name = "lblNumeroRendicion";
            this.lblNumeroRendicion.Size = new System.Drawing.Size(60, 24);
            this.lblNumeroRendicion.TabIndex = 7;
            this.lblNumeroRendicion.Text = "label8";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(162, 58);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(60, 24);
            this.lblFecha.TabIndex = 8;
            this.lblFecha.Text = "label8";
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentaje.Location = new System.Drawing.Point(162, 92);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(60, 24);
            this.lblPorcentaje.TabIndex = 9;
            this.lblPorcentaje.Text = "label8";
            // 
            // lblDevolucion
            // 
            this.lblDevolucion.AutoSize = true;
            this.lblDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevolucion.Location = new System.Drawing.Point(162, 126);
            this.lblDevolucion.Name = "lblDevolucion";
            this.lblDevolucion.Size = new System.Drawing.Size(60, 24);
            this.lblDevolucion.TabIndex = 10;
            this.lblDevolucion.Text = "label8";
            // 
            // grpInfoDevolucion
            // 
            this.grpInfoDevolucion.Controls.Add(this.lblInfo);
            this.grpInfoDevolucion.Controls.Add(this.lblMotivo);
            this.grpInfoDevolucion.Controls.Add(this.label8);
            this.grpInfoDevolucion.Controls.Add(this.label9);
            this.grpInfoDevolucion.Location = new System.Drawing.Point(26, 558);
            this.grpInfoDevolucion.Name = "grpInfoDevolucion";
            this.grpInfoDevolucion.Size = new System.Drawing.Size(685, 133);
            this.grpInfoDevolucion.TabIndex = 5;
            this.grpInfoDevolucion.TabStop = false;
            this.grpInfoDevolucion.Text = "Devolucion";
            this.grpInfoDevolucion.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(281, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Informacion adicional:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Motivo:";
            // 
            // lblMotivo
            // 
            this.lblMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivo.Location = new System.Drawing.Point(76, 23);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(199, 107);
            this.lblMotivo.TabIndex = 3;
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(425, 23);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(199, 107);
            this.lblInfo.TabIndex = 4;
            // 
            // DetalleRendicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 694);
            this.Controls.Add(this.grpInfoDevolucion);
            this.Controls.Add(this.lblDevolucion);
            this.Controls.Add(this.lblPorcentaje);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblNumeroRendicion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grpDevolucion);
            this.Controls.Add(this.Table_Detalle);
            this.Controls.Add(this.label1);
            this.Name = "DetalleRendicion";
            this.Text = "DetalleRendicion";
            ((System.ComponentModel.ISupportInitialize)(this.Table_Detalle)).EndInit();
            this.grpDevolucion.ResumeLayout(false);
            this.grpDevolucion.PerformLayout();
            this.grpInfoDevolucion.ResumeLayout(false);
            this.grpInfoDevolucion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Table_Detalle;
        private System.Windows.Forms.GroupBox grpDevolucion;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblNumeroRendicion;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.Label lblDevolucion;
        private System.Windows.Forms.GroupBox grpInfoDevolucion;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}