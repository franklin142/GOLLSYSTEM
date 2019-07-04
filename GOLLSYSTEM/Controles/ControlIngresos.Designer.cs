namespace GOLLSYSTEM.Controles
{
    partial class ControlIngresos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAnular = new System.Windows.Forms.Button();
            this.dgvIngresos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nfactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fhregistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.persona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.rdbMontYear = new System.Windows.Forms.RadioButton();
            this.rdbTodo = new System.Windows.Forms.RadioButton();
            this.pnlParametro = new System.Windows.Forms.Panel();
            this.lblTiltulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalIngresos = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalEgresos = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalGanancia = new System.Windows.Forms.Label();
            this.btnNuevoEgreso = new System.Windows.Forms.Button();
            this.cbxMonth = new System.Windows.Forms.ComboBox();
            this.cbxYear = new System.Windows.Forms.ComboBox();
            this.tmrTaskDgv = new System.Windows.Forms.Timer(this.components);
            this.lblPages = new System.Windows.Forms.Label();
            this.pnlIndexer = new System.Windows.Forms.Panel();
            this.lknInicio = new System.Windows.Forms.LinkLabel();
            this.txtCurrentIndex = new System.Windows.Forms.TextBox();
            this.lknBack = new System.Windows.Forms.LinkLabel();
            this.lknNext = new System.Windows.Forms.LinkLabel();
            this.lknFin = new System.Windows.Forms.LinkLabel();
            this.picHelp = new System.Windows.Forms.PictureBox();
            this.icUpdate = new System.Windows.Forms.PictureBox();
            this.picExcel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).BeginInit();
            this.pnlParametro.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlIndexer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAnular
            // 
            this.btnAnular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnular.BackColor = System.Drawing.Color.OrangeRed;
            this.btnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnular.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.btnAnular.ForeColor = System.Drawing.Color.White;
            this.btnAnular.Location = new System.Drawing.Point(491, 421);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(83, 26);
            this.btnAnular.TabIndex = 7;
            this.btnAnular.Text = "Anular";
            this.btnAnular.UseVisualStyleBackColor = false;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // dgvIngresos
            // 
            this.dgvIngresos.AllowUserToAddRows = false;
            this.dgvIngresos.AllowUserToDeleteRows = false;
            this.dgvIngresos.AllowUserToResizeRows = false;
            this.dgvIngresos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIngresos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIngresos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(233)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIngresos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nfactura,
            this.fhregistro,
            this.persona,
            this.concepto,
            this.subtotal,
            this.descuento,
            this.total});
            this.dgvIngresos.Location = new System.Drawing.Point(19, 124);
            this.dgvIngresos.MultiSelect = false;
            this.dgvIngresos.Name = "dgvIngresos";
            this.dgvIngresos.ReadOnly = true;
            this.dgvIngresos.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvIngresos.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvIngresos.RowTemplate.Height = 30;
            this.dgvIngresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngresos.Size = new System.Drawing.Size(677, 262);
            this.dgvIngresos.TabIndex = 8;
            this.dgvIngresos.DoubleClick += new System.EventHandler(this.dgvIngresos_DoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // nfactura
            // 
            this.nfactura.FillWeight = 58F;
            this.nfactura.HeaderText = "No. Factura";
            this.nfactura.Name = "nfactura";
            this.nfactura.ReadOnly = true;
            // 
            // fhregistro
            // 
            this.fhregistro.FillWeight = 55F;
            this.fhregistro.HeaderText = "Fecha";
            this.fhregistro.Name = "fhregistro";
            this.fhregistro.ReadOnly = true;
            // 
            // persona
            // 
            this.persona.FillWeight = 78F;
            this.persona.HeaderText = "Cliente";
            this.persona.Name = "persona";
            this.persona.ReadOnly = true;
            // 
            // concepto
            // 
            this.concepto.FillWeight = 118.6802F;
            this.concepto.HeaderText = "Concepto";
            this.concepto.Name = "concepto";
            this.concepto.ReadOnly = true;
            // 
            // subtotal
            // 
            this.subtotal.FillWeight = 35F;
            this.subtotal.HeaderText = "Sub.";
            this.subtotal.Name = "subtotal";
            this.subtotal.ReadOnly = true;
            // 
            // descuento
            // 
            this.descuento.FillWeight = 35F;
            this.descuento.HeaderText = "Desc.";
            this.descuento.Name = "descuento";
            this.descuento.ReadOnly = true;
            // 
            // total
            // 
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.total.DefaultCellStyle = dataGridViewCellStyle2;
            this.total.FillWeight = 35F;
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.txtBuscar.Location = new System.Drawing.Point(67, 68);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(217, 24);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
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
            // pnlParametro
            // 
            this.pnlParametro.Controls.Add(this.rdbMontYear);
            this.pnlParametro.Controls.Add(this.rdbTodo);
            this.pnlParametro.Location = new System.Drawing.Point(20, 97);
            this.pnlParametro.Name = "pnlParametro";
            this.pnlParametro.Size = new System.Drawing.Size(294, 21);
            this.pnlParametro.TabIndex = 4;
            // 
            // lblTiltulo
            // 
            this.lblTiltulo.AutoSize = true;
            this.lblTiltulo.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F);
            this.lblTiltulo.Location = new System.Drawing.Point(15, 23);
            this.lblTiltulo.Name = "lblTiltulo";
            this.lblTiltulo.Size = new System.Drawing.Size(247, 34);
            this.lblTiltulo.TabIndex = 69;
            this.lblTiltulo.Text = "Control de Ingresos";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.label2.Location = new System.Drawing.Point(577, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 18);
            this.label2.TabIndex = 88;
            this.label2.Text = "Mes:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.label1.Location = new System.Drawing.Point(416, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 18);
            this.label1.TabIndex = 86;
            this.label1.Text = "Año:";
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(19, 420);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(462, 27);
            this.flowLayoutPanel1.TabIndex = 89;
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
            // btnNuevoEgreso
            // 
            this.btnNuevoEgreso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoEgreso.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnNuevoEgreso.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevoEgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoEgreso.ForeColor = System.Drawing.Color.Black;
            this.btnNuevoEgreso.Location = new System.Drawing.Point(580, 421);
            this.btnNuevoEgreso.Name = "btnNuevoEgreso";
            this.btnNuevoEgreso.Size = new System.Drawing.Size(116, 27);
            this.btnNuevoEgreso.TabIndex = 6;
            this.btnNuevoEgreso.Text = "Nuevo Ingreso";
            this.btnNuevoEgreso.UseVisualStyleBackColor = false;
            this.btnNuevoEgreso.Click += new System.EventHandler(this.btnNuevoEgreso_Click);
            // 
            // cbxMonth
            // 
            this.cbxMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMonth.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMonth.FormattingEnabled = true;
            this.cbxMonth.Location = new System.Drawing.Point(619, 68);
            this.cbxMonth.Name = "cbxMonth";
            this.cbxMonth.Size = new System.Drawing.Size(77, 24);
            this.cbxMonth.TabIndex = 3;
            // 
            // cbxYear
            // 
            this.cbxYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxYear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxYear.FormattingEnabled = true;
            this.cbxYear.Location = new System.Drawing.Point(467, 67);
            this.cbxYear.Name = "cbxYear";
            this.cbxYear.Size = new System.Drawing.Size(77, 24);
            this.cbxYear.TabIndex = 2;
            // 
            // tmrTaskDgv
            // 
            this.tmrTaskDgv.Tick += new System.EventHandler(this.tmrTask_Tick);
            // 
            // lblPages
            // 
            this.lblPages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPages.AutoSize = true;
            this.lblPages.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.lblPages.ForeColor = System.Drawing.Color.Black;
            this.lblPages.Location = new System.Drawing.Point(20, 394);
            this.lblPages.Name = "lblPages";
            this.lblPages.Size = new System.Drawing.Size(17, 18);
            this.lblPages.TabIndex = 103;
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
            this.pnlIndexer.Location = new System.Drawing.Point(537, 389);
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
            this.picHelp.Visible = false;
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
            // picExcel
            // 
            this.picExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExcel.Image = global::GOLLSYSTEM.Properties.Resources.microsoft_excel_48;
            this.picExcel.Location = new System.Drawing.Point(629, 7);
            this.picExcel.Name = "picExcel";
            this.picExcel.Size = new System.Drawing.Size(38, 38);
            this.picExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picExcel.TabIndex = 104;
            this.picExcel.TabStop = false;
            this.picExcel.Click += new System.EventHandler(this.picExcel_Click);
            this.picExcel.MouseLeave += new System.EventHandler(this.picExcel_MouseLeave);
            this.picExcel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picExcel_MouseMove);
            // 
            // ControlIngresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 460);
            this.Controls.Add(this.picExcel);
            this.Controls.Add(this.lblPages);
            this.Controls.Add(this.pnlIndexer);
            this.Controls.Add(this.cbxMonth);
            this.Controls.Add(this.cbxYear);
            this.Controls.Add(this.btnNuevoEgreso);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.dgvIngresos);
            this.Controls.Add(this.picHelp);
            this.Controls.Add(this.icUpdate);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.pnlParametro);
            this.Controls.Add(this.lblTiltulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ControlIngresos";
            this.Text = "ControlIngresos";
            this.Load += new System.EventHandler(this.ControlIngresos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).EndInit();
            this.pnlParametro.ResumeLayout(false);
            this.pnlParametro.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.pnlIndexer.ResumeLayout(false);
            this.pnlIndexer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.DataGridView dgvIngresos;
        private System.Windows.Forms.PictureBox picHelp;
        private System.Windows.Forms.PictureBox icUpdate;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.RadioButton rdbMontYear;
        private System.Windows.Forms.RadioButton rdbTodo;
        private System.Windows.Forms.Panel pnlParametro;
        private System.Windows.Forms.Label lblTiltulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalIngresos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalEgresos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalGanancia;
        private System.Windows.Forms.Button btnNuevoEgreso;
        private System.Windows.Forms.ComboBox cbxMonth;
        private System.Windows.Forms.ComboBox cbxYear;
        private System.Windows.Forms.Timer tmrTaskDgv;
        private System.Windows.Forms.Label lblPages;
        private System.Windows.Forms.Panel pnlIndexer;
        private System.Windows.Forms.LinkLabel lknInicio;
        private System.Windows.Forms.TextBox txtCurrentIndex;
        private System.Windows.Forms.LinkLabel lknBack;
        private System.Windows.Forms.LinkLabel lknNext;
        private System.Windows.Forms.LinkLabel lknFin;
        private System.Windows.Forms.PictureBox picExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nfactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn fhregistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn persona;
        private System.Windows.Forms.DataGridViewTextBoxColumn concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
    }
}