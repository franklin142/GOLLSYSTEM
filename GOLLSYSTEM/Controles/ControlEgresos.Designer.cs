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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.rdbMontYear = new System.Windows.Forms.RadioButton();
            this.rdbTodo = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTiltulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNuevoEgreso = new System.Windows.Forms.Button();
            this.cbxYear = new System.Windows.Forms.ComboBox();
            this.cbxMonth = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalIngresos = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalEgresos = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalGanancia = new System.Windows.Forms.Label();
            this.lblPages = new System.Windows.Forms.Label();
            this.pnlIndexer = new System.Windows.Forms.Panel();
            this.lknInicio = new System.Windows.Forms.LinkLabel();
            this.txtCurrentIndex = new System.Windows.Forms.TextBox();
            this.lknBack = new System.Windows.Forms.LinkLabel();
            this.lknNext = new System.Windows.Forms.LinkLabel();
            this.lknFin = new System.Windows.Forms.LinkLabel();
            this.tmrTaskDgv = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEgresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icUpdate)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlIndexer.SuspendLayout();
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
            this.btnAnularEgreso.TabIndex = 7;
            this.btnAnularEgreso.Text = "Anular";
            this.btnAnularEgreso.UseVisualStyleBackColor = false;
            this.btnAnularEgreso.Click += new System.EventHandler(this.btnAnularEgreso_Click);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEgresos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvEgresos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEgresos.RowTemplate.Height = 30;
            this.dgvEgresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEgresos.Size = new System.Drawing.Size(677, 264);
            this.dgvEgresos.TabIndex = 8;
            this.dgvEgresos.DoubleClick += new System.EventHandler(this.dgvEgresos_DoubleClick);
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
            this.icUpdate.Click += new System.EventHandler(this.icUpdate_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.txtBuscar.Location = new System.Drawing.Point(67, 68);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(217, 24);
            this.txtBuscar.TabIndex = 1;
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
            // rdbMontYear
            // 
            this.rdbMontYear.AutoSize = true;
            this.rdbMontYear.Checked = true;
            this.rdbMontYear.Location = new System.Drawing.Point(157, 3);
            this.rdbMontYear.Name = "rdbMontYear";
            this.rdbMontYear.Size = new System.Drawing.Size(134, 17);
            this.rdbMontYear.TabIndex = 2;
            this.rdbMontYear.TabStop = true;
            this.rdbMontYear.Text = "Año y mes selecciondo";
            this.rdbMontYear.UseVisualStyleBackColor = true;
            // 
            // rdbTodo
            // 
            this.rdbTodo.AutoSize = true;
            this.rdbTodo.Location = new System.Drawing.Point(3, 3);
            this.rdbTodo.Name = "rdbTodo";
            this.rdbTodo.Size = new System.Drawing.Size(117, 17);
            this.rdbTodo.TabIndex = 1;
            this.rdbTodo.Text = "Todo los resultados";
            this.rdbTodo.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbMontYear);
            this.panel1.Controls.Add(this.rdbTodo);
            this.panel1.Location = new System.Drawing.Point(20, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 21);
            this.panel1.TabIndex = 4;
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
            this.btnNuevoEgreso.TabIndex = 6;
            this.btnNuevoEgreso.Text = "Nuevo Egreso";
            this.btnNuevoEgreso.UseVisualStyleBackColor = false;
            this.btnNuevoEgreso.Click += new System.EventHandler(this.btnNuevoEgreso_Click);
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
            this.cbxYear.TabIndex = 2;
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
            this.cbxMonth.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.lblTotalIngresos);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.lblTotalEgresos);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.lblTotalGanancia);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(19, 422);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(462, 27);
            this.flowLayoutPanel1.TabIndex = 100;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label3.Size = new System.Drawing.Size(65, 28);
            this.label3.TabIndex = 85;
            this.label3.Text = "Ingresos";
            // 
            // lblTotalIngresos
            // 
            this.lblTotalIngresos.AutoSize = true;
            this.lblTotalIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalIngresos.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblTotalIngresos.Location = new System.Drawing.Point(65, 0);
            this.lblTotalIngresos.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotalIngresos.Name = "lblTotalIngresos";
            this.lblTotalIngresos.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblTotalIngresos.Size = new System.Drawing.Size(61, 28);
            this.lblTotalIngresos.TabIndex = 86;
            this.lblTotalIngresos.Text = "+390.50";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(126, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label4.Size = new System.Drawing.Size(64, 28);
            this.label4.TabIndex = 87;
            this.label4.Text = "Egresos";
            // 
            // lblTotalEgresos
            // 
            this.lblTotalEgresos.AutoSize = true;
            this.lblTotalEgresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEgresos.ForeColor = System.Drawing.Color.Sienna;
            this.lblTotalEgresos.Location = new System.Drawing.Point(190, 0);
            this.lblTotalEgresos.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotalEgresos.Name = "lblTotalEgresos";
            this.lblTotalEgresos.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblTotalEgresos.Size = new System.Drawing.Size(37, 28);
            this.lblTotalEgresos.TabIndex = 88;
            this.lblTotalEgresos.Text = "-230";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(242, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label6.Size = new System.Drawing.Size(106, 28);
            this.label6.TabIndex = 89;
            this.label6.Text = "GANANCIAS =";
            // 
            // lblTotalGanancia
            // 
            this.lblTotalGanancia.AutoSize = true;
            this.lblTotalGanancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGanancia.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotalGanancia.Location = new System.Drawing.Point(348, 0);
            this.lblTotalGanancia.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotalGanancia.Name = "lblTotalGanancia";
            this.lblTotalGanancia.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblTotalGanancia.Size = new System.Drawing.Size(52, 28);
            this.lblTotalGanancia.TabIndex = 90;
            this.lblTotalGanancia.Text = "160.50";
            // 
            // lblPages
            // 
            this.lblPages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPages.AutoSize = true;
            this.lblPages.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.lblPages.ForeColor = System.Drawing.Color.Black;
            this.lblPages.Location = new System.Drawing.Point(20, 395);
            this.lblPages.Name = "lblPages";
            this.lblPages.Size = new System.Drawing.Size(17, 18);
            this.lblPages.TabIndex = 105;
            this.lblPages.Text = "...";
            // 
            // pnlIndexer
            // 
            this.pnlIndexer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlIndexer.Controls.Add(this.lknInicio);
            this.pnlIndexer.Controls.Add(this.txtCurrentIndex);
            this.pnlIndexer.Controls.Add(this.lknBack);
            this.pnlIndexer.Controls.Add(this.lknNext);
            this.pnlIndexer.Controls.Add(this.lknFin);
            this.pnlIndexer.Location = new System.Drawing.Point(537, 390);
            this.pnlIndexer.Name = "pnlIndexer";
            this.pnlIndexer.Size = new System.Drawing.Size(159, 26);
            this.pnlIndexer.TabIndex = 5;
            // 
            // lknInicio
            // 
            this.lknInicio.ActiveLinkColor = System.Drawing.Color.Black;
            this.lknInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lknInicio.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold);
            this.lknInicio.LinkColor = System.Drawing.Color.DimGray;
            this.lknInicio.Location = new System.Drawing.Point(7, 5);
            this.lknInicio.Name = "lknInicio";
            this.lknInicio.Size = new System.Drawing.Size(45, 18);
            this.lknInicio.TabIndex = 4;
            this.lknInicio.TabStop = true;
            this.lknInicio.Text = "Inicio";
            this.lknInicio.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lknInicio_LinkClicked);
            // 
            // txtCurrentIndex
            // 
            this.txtCurrentIndex.BackColor = System.Drawing.SystemColors.Menu;
            this.txtCurrentIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentIndex.Location = new System.Drawing.Point(70, 3);
            this.txtCurrentIndex.Name = "txtCurrentIndex";
            this.txtCurrentIndex.ReadOnly = true;
            this.txtCurrentIndex.Size = new System.Drawing.Size(33, 20);
            this.txtCurrentIndex.TabIndex = 69;
            this.txtCurrentIndex.Text = "1";
            this.txtCurrentIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCurrentIndex.TextChanged += new System.EventHandler(this.txtCurrentIndex_TextChanged);
            // 
            // lknBack
            // 
            this.lknBack.ActiveLinkColor = System.Drawing.Color.Black;
            this.lknBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lknBack.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.lknBack.LinkColor = System.Drawing.Color.DimGray;
            this.lknBack.Location = new System.Drawing.Point(49, 3);
            this.lknBack.Name = "lknBack";
            this.lknBack.Size = new System.Drawing.Size(18, 18);
            this.lknBack.TabIndex = 3;
            this.lknBack.TabStop = true;
            this.lknBack.Text = "<";
            this.lknBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lknBack_LinkClicked);
            // 
            // lknNext
            // 
            this.lknNext.ActiveLinkColor = System.Drawing.Color.Black;
            this.lknNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lknNext.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.lknNext.LinkColor = System.Drawing.Color.DimGray;
            this.lknNext.Location = new System.Drawing.Point(104, 3);
            this.lknNext.Name = "lknNext";
            this.lknNext.Size = new System.Drawing.Size(18, 18);
            this.lknNext.TabIndex = 1;
            this.lknNext.TabStop = true;
            this.lknNext.Text = ">";
            this.lknNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lknNext_LinkClicked);
            // 
            // lknFin
            // 
            this.lknFin.ActiveLinkColor = System.Drawing.Color.Black;
            this.lknFin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lknFin.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold);
            this.lknFin.LinkColor = System.Drawing.Color.DimGray;
            this.lknFin.Location = new System.Drawing.Point(126, 5);
            this.lknFin.Name = "lknFin";
            this.lknFin.Size = new System.Drawing.Size(29, 18);
            this.lknFin.TabIndex = 2;
            this.lknFin.TabStop = true;
            this.lknFin.Text = "Fin";
            this.lknFin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lknFin_LinkClicked);
            // 
            // tmrTaskDgv
            // 
            this.tmrTaskDgv.Tick += new System.EventHandler(this.tmrTask_Tick);
            // 
            // ControlEgresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 460);
            this.Controls.Add(this.lblPages);
            this.Controls.Add(this.pnlIndexer);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.cbxMonth);
            this.Controls.Add(this.cbxYear);
            this.Controls.Add(this.btnNuevoEgreso);
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
            this.pnlIndexer.ResumeLayout(false);
            this.pnlIndexer.PerformLayout();
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
        private System.Windows.Forms.RadioButton rdbMontYear;
        private System.Windows.Forms.RadioButton rdbTodo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTiltulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.Button btnNuevoEgreso;
        private System.Windows.Forms.ComboBox cbxYear;
        private System.Windows.Forms.ComboBox cbxMonth;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalIngresos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalEgresos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalGanancia;
        private System.Windows.Forms.Label lblPages;
        private System.Windows.Forms.Panel pnlIndexer;
        private System.Windows.Forms.LinkLabel lknInicio;
        private System.Windows.Forms.TextBox txtCurrentIndex;
        private System.Windows.Forms.LinkLabel lknBack;
        private System.Windows.Forms.LinkLabel lknNext;
        private System.Windows.Forms.LinkLabel lknFin;
        private System.Windows.Forms.Timer tmrTaskDgv;
    }
}