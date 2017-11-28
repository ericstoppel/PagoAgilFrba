namespace PagoAgilFrba.AbmRol
{
    partial class ListadoRoles
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
            this.Table_Roles = new System.Windows.Forms.DataGridView();
            this.btnNuevoRol = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Table_Roles)).BeginInit();
            this.SuspendLayout();
            // 
            // Table_Roles
            // 
            this.Table_Roles.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Table_Roles.AllowUserToAddRows = false;
            this.Table_Roles.AllowUserToDeleteRows = false;
            this.Table_Roles.AllowUserToResizeColumns = false;
            this.Table_Roles.AllowUserToResizeRows = false;
            this.Table_Roles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table_Roles.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Table_Roles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Table_Roles.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Table_Roles.Location = new System.Drawing.Point(12, 12);
            this.Table_Roles.MultiSelect = false;
            this.Table_Roles.Name = "Table_Roles";
            this.Table_Roles.ReadOnly = true;
            this.Table_Roles.Size = new System.Drawing.Size(621, 186);
            this.Table_Roles.TabIndex = 1;
            this.Table_Roles.UseWaitCursor = true;
            this.Table_Roles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Table_Roles_CellContentClick);
            // 
            // btnNuevoRol
            // 
            this.btnNuevoRol.Location = new System.Drawing.Point(25, 215);
            this.btnNuevoRol.Name = "btnNuevoRol";
            this.btnNuevoRol.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoRol.TabIndex = 2;
            this.btnNuevoRol.Text = "Nuevo Rol";
            this.btnNuevoRol.UseVisualStyleBackColor = true;
            this.btnNuevoRol.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(126, 215);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(233, 215);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // ListadoRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 359);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevoRol);
            this.Controls.Add(this.Table_Roles);
            this.Name = "ListadoRoles";
            this.Text = "ListadoRoles";
            ((System.ComponentModel.ISupportInitialize)(this.Table_Roles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Table_Roles;
        private System.Windows.Forms.Button btnNuevoRol;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
    }
}