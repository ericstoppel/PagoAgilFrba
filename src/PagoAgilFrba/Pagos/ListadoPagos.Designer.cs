namespace PagoAgilFrba.Pagos
{
    partial class ListadoPagos
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
            this.Table_Pagos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Table_Pagos)).BeginInit();
            this.SuspendLayout();
            // 
            // Table_Pagos
            // 
            this.Table_Pagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table_Pagos.Location = new System.Drawing.Point(12, 12);
            this.Table_Pagos.Name = "Table_Pagos";
            this.Table_Pagos.Size = new System.Drawing.Size(848, 374);
            this.Table_Pagos.TabIndex = 0;
            this.Table_Pagos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Table_Pagos_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(267, 394);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Doble click para ver el detalle del pago";
            // 
            // ListadoPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 427);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Table_Pagos);
            this.Name = "ListadoPagos";
            this.Text = "ListadoPagos";
            ((System.ComponentModel.ISupportInitialize)(this.Table_Pagos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Table_Pagos;
        private System.Windows.Forms.Label label1;
    }
}