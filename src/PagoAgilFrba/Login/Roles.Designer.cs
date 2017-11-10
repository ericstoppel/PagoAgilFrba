namespace PagoAgilFrba.Login
{
    partial class Cl_Roles
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
            this.Cmb_Roles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Aceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Cmb_Roles
            // 
            this.Cmb_Roles.FormattingEnabled = true;
            this.Cmb_Roles.Location = new System.Drawing.Point(171, 86);
            this.Cmb_Roles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Cmb_Roles.Name = "Cmb_Roles";
            this.Cmb_Roles.Size = new System.Drawing.Size(175, 21);
            this.Cmb_Roles.TabIndex = 0;
            this.Cmb_Roles.SelectedIndexChanged += new System.EventHandler(this.Cmb_Roles_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione un rol";
            // 
            // Btn_Aceptar
            // 
            this.Btn_Aceptar.Location = new System.Drawing.Point(221, 117);
            this.Btn_Aceptar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Aceptar.Name = "Btn_Aceptar";
            this.Btn_Aceptar.Size = new System.Drawing.Size(73, 25);
            this.Btn_Aceptar.TabIndex = 2;
            this.Btn_Aceptar.Text = "Aceptar";
            this.Btn_Aceptar.UseVisualStyleBackColor = true;
            this.Btn_Aceptar.Click += new System.EventHandler(this.Btn_Aceptar_Click);
            // 
            // Cl_Roles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(531, 238);
            this.Controls.Add(this.Btn_Aceptar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cmb_Roles);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Cl_Roles";
            this.Text = "Roles";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox Cmb_Roles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Aceptar;
    }
}