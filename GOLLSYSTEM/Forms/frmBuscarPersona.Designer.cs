﻿namespace GOLLSYSTEM.Forms
{
    partial class frmBuscarPersona
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCursos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pblTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picLogoForm = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.valNombre = new System.Windows.Forms.Panel();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.btnNuevaPersona = new System.Windows.Forms.Button();
            this.icUpdate = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).BeginInit();
            this.pblTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCursos
            // 
            this.dgvCursos.AllowUserToAddRows = false;
            this.dgvCursos.AllowUserToDeleteRows = false;
            this.dgvCursos.AllowUserToResizeRows = false;
            this.dgvCursos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCursos.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCursos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.telefono});
            this.dgvCursos.Location = new System.Drawing.Point(-1, 110);
            this.dgvCursos.MultiSelect = false;
            this.dgvCursos.Name = "dgvCursos";
            this.dgvCursos.ReadOnly = true;
            this.dgvCursos.RowHeadersVisible = false;
            this.dgvCursos.RowTemplate.Height = 30;
            this.dgvCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCursos.Size = new System.Drawing.Size(660, 201);
            this.dgvCursos.TabIndex = 101;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // nombre
            // 
            this.nombre.FillWeight = 169.5432F;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // telefono
            // 
            this.telefono.FillWeight = 30.45685F;
            this.telefono.HeaderText = "Telefono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            // 
            // pblTitulo
            // 
            this.pblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.pblTitulo.Controls.Add(this.lblTitulo);
            this.pblTitulo.Controls.Add(this.picLogoForm);
            this.pblTitulo.Location = new System.Drawing.Point(-1, -1);
            this.pblTitulo.Name = "pblTitulo";
            this.pblTitulo.Size = new System.Drawing.Size(660, 60);
            this.pblTitulo.TabIndex = 105;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitulo.Location = new System.Drawing.Point(17, 11);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(115, 37);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Cliente";
            // 
            // picLogoForm
            // 
            this.picLogoForm.Image = global::GOLLSYSTEM.Properties.Resources.goll_Logo_png;
            this.picLogoForm.Location = new System.Drawing.Point(574, 4);
            this.picLogoForm.Name = "picLogoForm";
            this.picLogoForm.Size = new System.Drawing.Size(73, 54);
            this.picLogoForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoForm.TabIndex = 0;
            this.picLogoForm.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.panel1.Location = new System.Drawing.Point(23, 311);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 2);
            this.panel1.TabIndex = 104;
            // 
            // valNombre
            // 
            this.valNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.valNombre.Location = new System.Drawing.Point(73, 102);
            this.valNombre.Name = "valNombre";
            this.valNombre.Size = new System.Drawing.Size(309, 2);
            this.valNombre.TabIndex = 103;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.ForeColor = System.Drawing.Color.Black;
            this.btnSeleccionar.Location = new System.Drawing.Point(527, 311);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(131, 26);
            this.btnSeleccionar.TabIndex = 102;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.txtBuscar.Location = new System.Drawing.Point(73, 78);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(309, 24);
            this.txtBuscar.TabIndex = 98;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.lblBuscar.Location = new System.Drawing.Point(22, 79);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(51, 18);
            this.lblBuscar.TabIndex = 99;
            this.lblBuscar.Text = "Buscar:";
            // 
            // btnNuevaPersona
            // 
            this.btnNuevaPersona.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevaPersona.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnNuevaPersona.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevaPersona.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaPersona.ForeColor = System.Drawing.Color.Black;
            this.btnNuevaPersona.Location = new System.Drawing.Point(424, 78);
            this.btnNuevaPersona.Name = "btnNuevaPersona";
            this.btnNuevaPersona.Size = new System.Drawing.Size(74, 26);
            this.btnNuevaPersona.TabIndex = 106;
            this.btnNuevaPersona.Text = "Nuevo";
            this.btnNuevaPersona.UseVisualStyleBackColor = false;
            this.btnNuevaPersona.Click += new System.EventHandler(this.btnNuevaPersona_Click);
            // 
            // icUpdate
            // 
            this.icUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.icUpdate.Image = global::GOLLSYSTEM.Properties.Resources.search_1;
            this.icUpdate.Location = new System.Drawing.Point(388, 79);
            this.icUpdate.Name = "icUpdate";
            this.icUpdate.Size = new System.Drawing.Size(30, 23);
            this.icUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icUpdate.TabIndex = 100;
            this.icUpdate.TabStop = false;
            this.icUpdate.Click += new System.EventHandler(this.icUpdate_Click);
            // 
            // frmBuscarPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 336);
            this.Controls.Add(this.btnNuevaPersona);
            this.Controls.Add(this.dgvCursos);
            this.Controls.Add(this.pblTitulo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.valNombre);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.icUpdate);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Name = "frmBuscarPersona";
            this.Text = "frmPersona";
            this.Load += new System.EventHandler(this.frmBuscarPersona_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).EndInit();
            this.pblTitulo.ResumeLayout(false);
            this.pblTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icUpdate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCursos;
        private System.Windows.Forms.Panel pblTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox picLogoForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel valNombre;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.PictureBox icUpdate;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.Button btnNuevaPersona;
    }
}