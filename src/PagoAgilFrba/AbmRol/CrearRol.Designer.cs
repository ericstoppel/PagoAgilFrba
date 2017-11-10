namespace PagoAgilFrba.AbmRol
{
    partial class Cl_Abm_Rol
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
            this.DGV_Roles = new System.Windows.Forms.DataGridView();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Btn_Crear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkHabilitado = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Clb_Funcionalidades = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_NombreRol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Roles)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV_Roles
            // 
            this.DGV_Roles.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.DGV_Roles.AllowUserToAddRows = false;
            this.DGV_Roles.AllowUserToDeleteRows = false;
            this.DGV_Roles.AllowUserToResizeColumns = false;
            this.DGV_Roles.AllowUserToResizeRows = false;
            this.DGV_Roles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Roles.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.DGV_Roles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGV_Roles.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.DGV_Roles.Location = new System.Drawing.Point(13, 13);
            this.DGV_Roles.MultiSelect = false;
            this.DGV_Roles.Name = "DGV_Roles";
            this.DGV_Roles.ReadOnly = true;
            this.DGV_Roles.Size = new System.Drawing.Size(321, 341);
            this.DGV_Roles.TabIndex = 0;
            this.DGV_Roles.UseWaitCursor = true;
            this.DGV_Roles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Roles_CellContentClick);
            this.DGV_Roles.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Roles_RowEnter);
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(53, 310);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancelar.TabIndex = 2;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Btn_Crear
            // 
            this.Btn_Crear.Location = new System.Drawing.Point(134, 310);
            this.Btn_Crear.Name = "Btn_Crear";
            this.Btn_Crear.Size = new System.Drawing.Size(75, 23);
            this.Btn_Crear.TabIndex = 4;
            this.Btn_Crear.Text = "Guardar";
            this.Btn_Crear.UseVisualStyleBackColor = true;
            this.Btn_Crear.Click += new System.EventHandler(this.Btn_Crear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkHabilitado);
            this.groupBox1.Controls.Add(this.Btn_Crear);
            this.groupBox1.Controls.Add(this.Btn_Cancelar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Clb_Funcionalidades);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Txt_NombreRol);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(340, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 341);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Complete los campos";
            // 
            // chkHabilitado
            // 
            this.chkHabilitado.AutoSize = true;
            this.chkHabilitado.Location = new System.Drawing.Point(96, 267);
            this.chkHabilitado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(15, 14);
            this.chkHabilitado.TabIndex = 5;
            this.chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Habilitado";
            // 
            // Clb_Funcionalidades
            // 
            this.Clb_Funcionalidades.FormattingEnabled = true;
            this.Clb_Funcionalidades.Location = new System.Drawing.Point(40, 80);
            this.Clb_Funcionalidades.Name = "Clb_Funcionalidades";
            this.Clb_Funcionalidades.Size = new System.Drawing.Size(209, 184);
            this.Clb_Funcionalidades.TabIndex = 3;
            this.Clb_Funcionalidades.SelectedIndexChanged += new System.EventHandler(this.Clb_Funcionalidades_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Funcionalidades";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Txt_NombreRol
            // 
            this.Txt_NombreRol.Location = new System.Drawing.Point(36, 37);
            this.Txt_NombreRol.Name = "Txt_NombreRol";
            this.Txt_NombreRol.Size = new System.Drawing.Size(212, 20);
            this.Txt_NombreRol.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del Rol";
            // 
            // Cl_Abm_Rol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(606, 366);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DGV_Roles);
            this.Name = "Cl_Abm_Rol";
            this.Text = "ABM_Rol";
            this.Load += new System.EventHandler(this.Cl_Abm_Rol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Roles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Roles;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Button Btn_Crear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox Clb_Funcionalidades;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_NombreRol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkHabilitado;
    }
}