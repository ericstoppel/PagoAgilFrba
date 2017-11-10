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
            this.SuspendLayout();
            // 
            // Btn_Rol
            // 
            this.Btn_Rol.Location = new System.Drawing.Point(487, 34);
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
            this.Btn_ABM_Cliente.Location = new System.Drawing.Point(187, 91);
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
            this.Btn_Empresa.Location = new System.Drawing.Point(365, 91);
            this.Btn_Empresa.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Empresa.Name = "Btn_Empresa";
            this.Btn_Empresa.Size = new System.Drawing.Size(127, 42);
            this.Btn_Empresa.TabIndex = 12;
            this.Btn_Empresa.Text = "ABM Empresa";
            this.Btn_Empresa.UseVisualStyleBackColor = true;
            this.Btn_Empresa.Click += new System.EventHandler(this.Btn_Empresa_Click);
            // 
            // MenuInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(733, 285);
            this.Controls.Add(this.Btn_Empresa);
            this.Controls.Add(this.Btn_Rol);
            this.Controls.Add(this.Btn_ABM_Cliente);
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
        
    }
}