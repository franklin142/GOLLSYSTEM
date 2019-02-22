﻿namespace GOLLSYSTEM.Controles
{
    partial class ControlMatriculas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbParametros = new System.Windows.Forms.RadioButton();
            this.rdbTodo = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblTiltulo = new System.Windows.Forms.Label();
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.icUpdate = new System.Windows.Forms.PictureBox();
            this.btnDesertarAlumno = new System.Windows.Forms.Button();
            this.dgvMatriculas = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estudiante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.becado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solvente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuevaMatricula = new System.Windows.Forms.Button();
            this.btnEditarMatricula = new System.Windows.Forms.Button();
            this.cbxCursos = new System.Windows.Forms.ComboBox();
            this.cbxYear = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatriculas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbParametros);
            this.panel1.Controls.Add(this.rdbTodo);
            this.panel1.Location = new System.Drawing.Point(17, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 21);
            this.panel1.TabIndex = 63;
            // 
            // rdbParametros
            // 
            this.rdbParametros.AutoSize = true;
            this.rdbParametros.Checked = true;
            this.rdbParametros.Location = new System.Drawing.Point(157, 3);
            this.rdbParametros.Name = "rdbParametros";
            this.rdbParametros.Size = new System.Drawing.Size(141, 17);
            this.rdbParametros.TabIndex = 38;
            this.rdbParametros.TabStop = true;
            this.rdbParametros.Text = "Curso y año selecciondo";
            this.rdbParametros.UseVisualStyleBackColor = true;
            // 
            // rdbTodo
            // 
            this.rdbTodo.AutoSize = true;
            this.rdbTodo.Location = new System.Drawing.Point(3, 3);
            this.rdbTodo.Name = "rdbTodo";
            this.rdbTodo.Size = new System.Drawing.Size(117, 17);
            this.rdbTodo.TabIndex = 37;
            this.rdbTodo.Text = "Todo los resultados";
            this.rdbTodo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.label2.Location = new System.Drawing.Point(403, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 18);
            this.label2.TabIndex = 62;
            this.label2.Text = "Curso:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.label1.Location = new System.Drawing.Point(574, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 18);
            this.label1.TabIndex = 60;
            this.label1.Text = "Año:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.txtBuscar.Location = new System.Drawing.Point(64, 66);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(217, 24);
            this.txtBuscar.TabIndex = 56;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.lblBuscar.Location = new System.Drawing.Point(13, 69);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(51, 18);
            this.lblBuscar.TabIndex = 57;
            this.lblBuscar.Text = "Buscar:";
            // 
            // lblTiltulo
            // 
            this.lblTiltulo.AutoSize = true;
            this.lblTiltulo.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F);
            this.lblTiltulo.Location = new System.Drawing.Point(12, 21);
            this.lblTiltulo.Name = "lblTiltulo";
            this.lblTiltulo.Size = new System.Drawing.Size(270, 34);
            this.lblTiltulo.TabIndex = 55;
            this.lblTiltulo.Text = "Control de Matriculas";
            // 
            // picHelp
            // 
            this.picHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picHelp.Image = global::GOLLSYSTEM.Properties.Resources._008_help;
            this.picHelp.Location = new System.Drawing.Point(669, 11);
            this.picHelp.Name = "picHelp";
            this.picHelp.Size = new System.Drawing.Size(28, 28);
            this.picHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHelp.TabIndex = 64;
            this.picHelp.TabStop = false;
            // 
            // icUpdate
            // 
            this.icUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.icUpdate.Image = global::GOLLSYSTEM.Properties.Resources.search_1;
            this.icUpdate.Location = new System.Drawing.Point(289, 66);
            this.icUpdate.Name = "icUpdate";
            this.icUpdate.Size = new System.Drawing.Size(30, 23);
            this.icUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icUpdate.TabIndex = 58;
            this.icUpdate.TabStop = false;
            // 
            // btnDesertarAlumno
            // 
            this.btnDesertarAlumno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDesertarAlumno.BackColor = System.Drawing.Color.OrangeRed;
            this.btnDesertarAlumno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDesertarAlumno.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.btnDesertarAlumno.ForeColor = System.Drawing.Color.White;
            this.btnDesertarAlumno.Location = new System.Drawing.Point(16, 419);
            this.btnDesertarAlumno.Name = "btnDesertarAlumno";
            this.btnDesertarAlumno.Size = new System.Drawing.Size(83, 26);
            this.btnDesertarAlumno.TabIndex = 68;
            this.btnDesertarAlumno.Text = "Desertar";
            this.btnDesertarAlumno.UseVisualStyleBackColor = false;
            // 
            // dgvMatriculas
            // 
            this.dgvMatriculas.AllowUserToAddRows = false;
            this.dgvMatriculas.AllowUserToDeleteRows = false;
            this.dgvMatriculas.AllowUserToResizeRows = false;
            this.dgvMatriculas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMatriculas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMatriculas.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMatriculas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMatriculas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatriculas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.estudiante,
            this.telefono,
            this.becado,
            this.solvente});
            this.dgvMatriculas.Location = new System.Drawing.Point(16, 122);
            this.dgvMatriculas.MultiSelect = false;
            this.dgvMatriculas.Name = "dgvMatriculas";
            this.dgvMatriculas.ReadOnly = true;
            this.dgvMatriculas.RowHeadersVisible = false;
            this.dgvMatriculas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMatriculas.Size = new System.Drawing.Size(677, 291);
            this.dgvMatriculas.TabIndex = 66;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // estudiante
            // 
            this.estudiante.HeaderText = "Estudiante";
            this.estudiante.Name = "estudiante";
            this.estudiante.ReadOnly = true;
            // 
            // telefono
            // 
            this.telefono.FillWeight = 50F;
            this.telefono.HeaderText = "Telefono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            // 
            // becado
            // 
            this.becado.FillWeight = 50F;
            this.becado.HeaderText = "Es Becado";
            this.becado.Name = "becado";
            this.becado.ReadOnly = true;
            // 
            // solvente
            // 
            this.solvente.FillWeight = 50F;
            this.solvente.HeaderText = "Al dia con pagos";
            this.solvente.Name = "solvente";
            this.solvente.ReadOnly = true;
            // 
            // btnNuevaMatricula
            // 
            this.btnNuevaMatricula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevaMatricula.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnNuevaMatricula.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevaMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaMatricula.ForeColor = System.Drawing.Color.Black;
            this.btnNuevaMatricula.Location = new System.Drawing.Point(577, 419);
            this.btnNuevaMatricula.Name = "btnNuevaMatricula";
            this.btnNuevaMatricula.Size = new System.Drawing.Size(116, 27);
            this.btnNuevaMatricula.TabIndex = 88;
            this.btnNuevaMatricula.Text = "Matricular";
            this.btnNuevaMatricula.UseVisualStyleBackColor = false;
            // 
            // btnEditarMatricula
            // 
            this.btnEditarMatricula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarMatricula.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEditarMatricula.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditarMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarMatricula.ForeColor = System.Drawing.Color.Black;
            this.btnEditarMatricula.Location = new System.Drawing.Point(490, 419);
            this.btnEditarMatricula.Name = "btnEditarMatricula";
            this.btnEditarMatricula.Size = new System.Drawing.Size(81, 26);
            this.btnEditarMatricula.TabIndex = 89;
            this.btnEditarMatricula.Text = "Editar";
            this.btnEditarMatricula.UseVisualStyleBackColor = false;
            // 
            // cbxCursos
            // 
            this.cbxCursos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxCursos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCursos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxCursos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCursos.FormattingEnabled = true;
            this.cbxCursos.Location = new System.Drawing.Point(456, 66);
            this.cbxCursos.Name = "cbxCursos";
            this.cbxCursos.Size = new System.Drawing.Size(101, 24);
            this.cbxCursos.TabIndex = 101;
            this.cbxCursos.SelectedIndexChanged += new System.EventHandler(this.cbxCursos_SelectedIndexChanged);
            // 
            // cbxYear
            // 
            this.cbxYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxYear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxYear.FormattingEnabled = true;
            this.cbxYear.Location = new System.Drawing.Point(616, 66);
            this.cbxYear.Name = "cbxYear";
            this.cbxYear.Size = new System.Drawing.Size(77, 24);
            this.cbxYear.TabIndex = 100;
            this.cbxYear.SelectedIndexChanged += new System.EventHandler(this.cbxYear_SelectedIndexChanged);
            // 
            // ControlMatriculas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 460);
            this.Controls.Add(this.cbxCursos);
            this.Controls.Add(this.cbxYear);
            this.Controls.Add(this.btnEditarMatricula);
            this.Controls.Add(this.btnNuevaMatricula);
            this.Controls.Add(this.btnDesertarAlumno);
            this.Controls.Add(this.dgvMatriculas);
            this.Controls.Add(this.picHelp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.icUpdate);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.lblTiltulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ControlMatriculas";
            this.Text = "ControlMatriculas";
            this.Load += new System.EventHandler(this.ControlMatriculas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatriculas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picHelp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbParametros;
        private System.Windows.Forms.RadioButton rdbTodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox icUpdate;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lblTiltulo;
        private System.Windows.Forms.Button btnDesertarAlumno;
        private System.Windows.Forms.DataGridView dgvMatriculas;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn estudiante;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn becado;
        private System.Windows.Forms.DataGridViewTextBoxColumn solvente;
        private System.Windows.Forms.Button btnNuevaMatricula;
        private System.Windows.Forms.Button btnEditarMatricula;
        private System.Windows.Forms.ComboBox cbxCursos;
        private System.Windows.Forms.ComboBox cbxYear;
    }
}