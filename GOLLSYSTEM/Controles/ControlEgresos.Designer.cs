namespace GOLLSYSTEM.Controles
{
    partial class ControlEgresos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAnularEgreso = new System.Windows.Forms.Button();
            this.dgvEgresos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.icUpdate = new System.Windows.Forms.PictureBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.rdbYearMonth = new System.Windows.Forms.RadioButton();
            this.rdbTodo = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTiltulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTotalIngresos = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnNuevoEgreso = new System.Windows.Forms.Button();
            this.cbxYear = new System.Windows.Forms.ComboBox();
            this.cbxMonth = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEgresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icUpdate)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAnularEgreso
            // 
            this.btnAnularEgreso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnularEgreso.BackColor = System.Drawing.Color.OrangeRed;
            this.btnAnularEgreso.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnularEgreso.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.btnAnularEgreso.ForeColor = System.Drawing.Color.White;
            this.btnAnularEgreso.Location = new System.Drawing.Point(491, 422);
            this.btnAnularEgreso.Name = "btnAnularEgreso";
            this.btnAnularEgreso.Size = new System.Drawing.Size(83, 26);
            this.btnAnularEgreso.TabIndex = 82;
            this.btnAnularEgreso.Text = "Anular";
            this.btnAnularEgreso.UseVisualStyleBackColor = false;
            // 
            // dgvEgresos
            // 
            this.dgvEgresos.AllowUserToAddRows = false;
            this.dgvEgresos.AllowUserToDeleteRows = false;
            this.dgvEgresos.AllowUserToResizeRows = false;
            this.dgvEgresos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEgresos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEgresos.BackgroundColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEgresos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEgresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEgresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fecha,
            this.tipo,
            this.nombre,
            this.total});
            this.dgvEgresos.Location = new System.Drawing.Point(19, 124);
            this.dgvEgresos.MultiSelect = false;
            this.dgvEgresos.Name = "dgvEgresos";
            this.dgvEgresos.ReadOnly = true;
            this.dgvEgresos.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvEgresos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEgresos.RowTemplate.Height = 30;
            this.dgvEgresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEgresos.Size = new System.Drawing.Size(677, 291);
            this.dgvEgresos.TabIndex = 80;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // fecha
            // 
            this.fecha.FillWeight = 40F;
            this.fecha.HeaderText = "Fecha Registro";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // tipo
            // 
            this.tipo.FillWeight = 60F;
            this.tipo.HeaderText = "Tipo de egreso";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre del egreso";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // total
            // 
            this.total.FillWeight = 30F;
            this.total.HeaderText = "Total en $";
            this.total.Name = "total";
            this.total.ReadOnly = true;
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
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.label1.Location = new System.Drawing.Point(425, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 18);
            this.label1.TabIndex = 74;
            this.label1.Text = "Año:";
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
            // rdbYearMonth
            // 
            this.rdbYearMonth.AutoSize = true;
            this.rdbYearMonth.Checked = true;
            this.rdbYearMonth.Location = new System.Drawing.Point(157, 3);
            this.rdbYearMonth.Name = "rdbYearMonth";
            this.rdbYearMonth.Size = new System.Drawing.Size(134, 17);
            this.rdbYearMonth.TabIndex = 38;
            this.rdbYearMonth.TabStop = true;
            this.rdbYearMonth.Text = "Año y mes selecciondo";
            this.rdbYearMonth.UseVisualStyleBackColor = true;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbYearMonth);
            this.panel1.Controls.Add(this.rdbTodo);
            this.panel1.Location = new System.Drawing.Point(20, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 21);
            this.panel1.TabIndex = 77;
            // 
            // lblTiltulo
            // 
            this.lblTiltulo.AutoSize = true;
            this.lblTiltulo.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F);
            this.lblTiltulo.Location = new System.Drawing.Point(15, 23);
            this.lblTiltulo.Name = "lblTiltulo";
            this.lblTiltulo.Size = new System.Drawing.Size(239, 34);
            this.lblTiltulo.TabIndex = 69;
            this.lblTiltulo.Text = "Control de Egresos";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.label2.Location = new System.Drawing.Point(577, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 18);
            this.label2.TabIndex = 84;
            this.label2.Text = "Mes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label3.Size = new System.Drawing.Size(60, 26);
            this.label3.TabIndex = 85;
            this.label3.Text = "Ingresos";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.lblTotalIngresos);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(23, 421);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(462, 27);
            this.flowLayoutPanel1.TabIndex = 86;
            // 
            // lblTotalIngresos
            // 
            this.lblTotalIngresos.AutoSize = true;
            this.lblTotalIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalIngresos.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotalIngresos.Location = new System.Drawing.Point(60, 0);
            this.lblTotalIngresos.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotalIngresos.Name = "lblTotalIngresos";
            this.lblTotalIngresos.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblTotalIngresos.Size = new System.Drawing.Size(53, 26);
            this.lblTotalIngresos.TabIndex = 86;
            this.lblTotalIngresos.Text = "+390.50";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.OrangeRed;
            this.label4.Location = new System.Drawing.Point(113, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label4.Size = new System.Drawing.Size(60, 26);
            this.label4.TabIndex = 87;
            this.label4.Text = "Ingresos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.OrangeRed;
            this.label5.Location = new System.Drawing.Point(173, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label5.Size = new System.Drawing.Size(33, 26);
            this.label5.TabIndex = 88;
            this.label5.Text = "-230";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkGreen;
            this.label6.Location = new System.Drawing.Point(221, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label6.Size = new System.Drawing.Size(86, 26);
            this.label6.TabIndex = 89;
            this.label6.Text = "GANANCIAS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkGreen;
            this.label7.Location = new System.Drawing.Point(307, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label7.Size = new System.Drawing.Size(46, 26);
            this.label7.TabIndex = 90;
            this.label7.Text = "160.50";
            // 
            // btnNuevoEgreso
            // 
            this.btnNuevoEgreso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoEgreso.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnNuevoEgreso.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevoEgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoEgreso.ForeColor = System.Drawing.Color.Black;
            this.btnNuevoEgreso.Location = new System.Drawing.Point(580, 422);
            this.btnNuevoEgreso.Name = "btnNuevoEgreso";
            this.btnNuevoEgreso.Size = new System.Drawing.Size(116, 27);
            this.btnNuevoEgreso.TabIndex = 87;
            this.btnNuevoEgreso.Text = "Nuevo Egreso";
            this.btnNuevoEgreso.UseVisualStyleBackColor = false;
            // 
            // cbxYear
            // 
            this.cbxYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxYear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxYear.FormattingEnabled = true;
            this.cbxYear.Location = new System.Drawing.Point(467, 69);
            this.cbxYear.Name = "cbxYear";
            this.cbxYear.Size = new System.Drawing.Size(77, 24);
            this.cbxYear.TabIndex = 98;
            // 
            // cbxMonth
            // 
            this.cbxMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMonth.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMonth.FormattingEnabled = true;
            this.cbxMonth.Location = new System.Drawing.Point(619, 70);
            this.cbxMonth.Name = "cbxMonth";
            this.cbxMonth.Size = new System.Drawing.Size(77, 24);
            this.cbxMonth.TabIndex = 99;
            // 
            // ControlEgresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 460);
            this.Controls.Add(this.cbxMonth);
            this.Controls.Add(this.cbxYear);
            this.Controls.Add(this.btnNuevoEgreso);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAnularEgreso);
            this.Controls.Add(this.dgvEgresos);
            this.Controls.Add(this.picHelp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTiltulo);
            this.Controls.Add(this.icUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ControlEgresos";
            this.Text = "ControlEgresos";
            this.Load += new System.EventHandler(this.ControlEgresos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEgresos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icUpdate)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAnularEgreso;
        private System.Windows.Forms.DataGridView dgvEgresos;
        private System.Windows.Forms.PictureBox picHelp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox icUpdate;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.RadioButton rdbYearMonth;
        private System.Windows.Forms.RadioButton rdbTodo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTiltulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblTotalIngresos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.Button btnNuevoEgreso;
        private System.Windows.Forms.ComboBox cbxYear;
        private System.Windows.Forms.ComboBox cbxMonth;
    }
}