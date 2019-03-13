namespace GOLLSYSTEM.Controles
{
    partial class ControlCursos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAnularCurso = new System.Windows.Forms.Button();
            this.dgvCursos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.publico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alumnos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblTiltulo = new System.Windows.Forms.Label();
            this.btnEditarCurso = new System.Windows.Forms.Button();
            this.btnNuevoCurso = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxYear = new System.Windows.Forms.ComboBox();
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.icUpdate = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAnularCurso
            // 
            this.btnAnularCurso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnularCurso.BackColor = System.Drawing.Color.OrangeRed;
            this.btnAnularCurso.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnularCurso.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.btnAnularCurso.ForeColor = System.Drawing.Color.White;
            this.btnAnularCurso.Location = new System.Drawing.Point(19, 421);
            this.btnAnularCurso.Name = "btnAnularCurso";
            this.btnAnularCurso.Size = new System.Drawing.Size(101, 26);
            this.btnAnularCurso.TabIndex = 82;
            this.btnAnularCurso.Text = "Anular Curso";
            this.btnAnularCurso.UseVisualStyleBackColor = false;
            this.btnAnularCurso.Click += new System.EventHandler(this.btnAnularCurso_Click);
            // 
            // dgvCursos
            // 
            this.dgvCursos.AllowUserToAddRows = false;
            this.dgvCursos.AllowUserToDeleteRows = false;
            this.dgvCursos.AllowUserToResizeRows = false;
            this.dgvCursos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCursos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCursos.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCursos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.horario,
            this.publico,
            this.alumnos,
            this.estado});
            this.dgvCursos.Location = new System.Drawing.Point(19, 105);
            this.dgvCursos.MultiSelect = false;
            this.dgvCursos.Name = "dgvCursos";
            this.dgvCursos.ReadOnly = true;
            this.dgvCursos.RowHeadersVisible = false;
            this.dgvCursos.RowTemplate.Height = 30;
            this.dgvCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCursos.Size = new System.Drawing.Size(677, 308);
            this.dgvCursos.TabIndex = 80;
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
            this.nombre.HeaderText = "Curso";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // horario
            // 
            this.horario.HeaderText = "Horario";
            this.horario.Name = "horario";
            this.horario.ReadOnly = true;
            // 
            // publico
            // 
            this.publico.FillWeight = 50F;
            this.publico.HeaderText = "Publico";
            this.publico.Name = "publico";
            this.publico.ReadOnly = true;
            // 
            // alumnos
            // 
            this.alumnos.FillWeight = 50F;
            this.alumnos.HeaderText = "Alumnos";
            this.alumnos.Name = "alumnos";
            this.alumnos.ReadOnly = true;
            // 
            // estado
            // 
            this.estado.FillWeight = 50F;
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.txtBuscar.Location = new System.Drawing.Point(67, 68);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(217, 24);
            this.txtBuscar.TabIndex = 70;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.lblBuscar.Location = new System.Drawing.Point(16, 71);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(51, 18);
            this.lblBuscar.TabIndex = 71;
            this.lblBuscar.Text = "Buscar:";
            // 
            // lblTiltulo
            // 
            this.lblTiltulo.AutoSize = true;
            this.lblTiltulo.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiltulo.Location = new System.Drawing.Point(15, 23);
            this.lblTiltulo.Name = "lblTiltulo";
            this.lblTiltulo.Size = new System.Drawing.Size(229, 34);
            this.lblTiltulo.TabIndex = 69;
            this.lblTiltulo.Text = "Gestión de Cursos";
            // 
            // btnEditarCurso
            // 
            this.btnEditarCurso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarCurso.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEditarCurso.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditarCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarCurso.ForeColor = System.Drawing.Color.Black;
            this.btnEditarCurso.Location = new System.Drawing.Point(478, 419);
            this.btnEditarCurso.Name = "btnEditarCurso";
            this.btnEditarCurso.Size = new System.Drawing.Size(81, 27);
            this.btnEditarCurso.TabIndex = 91;
            this.btnEditarCurso.Text = "Editar";
            this.btnEditarCurso.UseVisualStyleBackColor = false;
            this.btnEditarCurso.Click += new System.EventHandler(this.btnEditarCurso_Click);
            // 
            // btnNuevoCurso
            // 
            this.btnNuevoCurso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoCurso.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnNuevoCurso.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevoCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoCurso.ForeColor = System.Drawing.Color.Black;
            this.btnNuevoCurso.Location = new System.Drawing.Point(565, 419);
            this.btnNuevoCurso.Name = "btnNuevoCurso";
            this.btnNuevoCurso.Size = new System.Drawing.Size(131, 27);
            this.btnNuevoCurso.TabIndex = 90;
            this.btnNuevoCurso.Text = "Nuevo Curso";
            this.btnNuevoCurso.UseVisualStyleBackColor = false;
            this.btnNuevoCurso.Click += new System.EventHandler(this.btnNuevoCurso_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.label1.Location = new System.Drawing.Point(577, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 18);
            this.label1.TabIndex = 93;
            this.label1.Text = "Año:";
            // 
            // cbxYear
            // 
            this.cbxYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxYear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxYear.FormattingEnabled = true;
            this.cbxYear.Location = new System.Drawing.Point(619, 68);
            this.cbxYear.Name = "cbxYear";
            this.cbxYear.Size = new System.Drawing.Size(77, 24);
            this.cbxYear.TabIndex = 98;
            // 
            // picHelp
            // 
            this.picHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picHelp.Image = global::GOLLSYSTEM.Properties.Resources._008_help;
            this.picHelp.Location = new System.Drawing.Point(672, 13);
            this.picHelp.Name = "picHelp";
            this.picHelp.Size = new System.Drawing.Size(28, 28);
            this.picHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHelp.TabIndex = 78;
            this.picHelp.TabStop = false;
            // 
            // icUpdate
            // 
            this.icUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.icUpdate.Image = global::GOLLSYSTEM.Properties.Resources.search_1;
            this.icUpdate.Location = new System.Drawing.Point(284, 68);
            this.icUpdate.Name = "icUpdate";
            this.icUpdate.Size = new System.Drawing.Size(30, 23);
            this.icUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icUpdate.TabIndex = 72;
            this.icUpdate.TabStop = false;
            this.icUpdate.Click += new System.EventHandler(this.icUpdate_Click);
            // 
            // ControlCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 460);
            this.Controls.Add(this.cbxYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEditarCurso);
            this.Controls.Add(this.btnNuevoCurso);
            this.Controls.Add(this.btnAnularCurso);
            this.Controls.Add(this.dgvCursos);
            this.Controls.Add(this.picHelp);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.lblTiltulo);
            this.Controls.Add(this.icUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ControlCursos";
            this.Text = "ControlCursos";
            this.Load += new System.EventHandler(this.ControlCursos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icUpdate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAnularCurso;
        private System.Windows.Forms.DataGridView dgvCursos;
        private System.Windows.Forms.PictureBox picHelp;
        private System.Windows.Forms.PictureBox icUpdate;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lblTiltulo;
        private System.Windows.Forms.Button btnEditarCurso;
        private System.Windows.Forms.Button btnNuevoCurso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn horario;
        private System.Windows.Forms.DataGridViewTextBoxColumn publico;
        private System.Windows.Forms.DataGridViewTextBoxColumn alumnos;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.ComboBox cbxYear;
    }
}