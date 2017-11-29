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
            // ListadoPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 427);
            this.Controls.Add(this.Table_Pagos);
            this.Name = "ListadoPagos";
            this.Text = "ListadoPagos";
            ((System.ComponentModel.ISupportInitialize)(this.Table_Pagos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Table_Pagos;
    }
}