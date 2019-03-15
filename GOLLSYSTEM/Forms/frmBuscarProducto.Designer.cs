namespace GOLLSYSTEM.Forms
{
    partial class frmBuscarProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarProducto));
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pblTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picLogoForm = new System.Windows.Forms.PictureBox();
            this.valProducto = new System.Windows.Forms.Panel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblTituloDgv = new System.Windows.Forms.Label();
            this.btnRegistrarProducto = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblTextTelefono = new System.Windows.Forms.Label();
            this.valAporte = new System.Windows.Forms.Panel();
            this.txtAporte = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.valDescuento = new System.Windows.Forms.Panel();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.errDgvProducto = new System.Windows.Forms.ErrorProvider(this.components);
            this.errAporte = new System.Windows.Forms.ErrorProvider(this.components);
            this.errDescuento = new System.Windows.Forms.ErrorProvider(this.components);
            this.errCantidad = new System.Windows.Forms.ErrorProvider(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlParamMensualidad = new System.Windows.Forms.Panel();
            this.cbxEstudiante = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxYear = new System.Windows.Forms.ComboBox();
            this.cbxCurso = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBecado = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.pblTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errDgvProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errAporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errCantidad)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlParamMensualidad.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AllowUserToResizeRows = false;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre});
            this.dgvProductos.Location = new System.Drawing.Point(12, 99);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowTemplate.Height = 30;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(205, 197);
            this.dgvProductos.TabIndex = 101;
            this.dgvProductos.CurrentCellChanged += new System.EventHandler(this.dgvProductos_CurrentCellChanged);
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
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // pblTitulo
            // 
            this.pblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.pblTitulo.Controls.Add(this.lblTitulo);
            this.pblTitulo.Controls.Add(this.picLogoForm);
            this.pblTitulo.Location = new System.Drawing.Point(-1, -1);
            this.pblTitulo.Name = "pblTitulo";
            this.pblTitulo.Size = new System.Drawing.Size(539, 60);
            this.pblTitulo.TabIndex = 105;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitulo.Location = new System.Drawing.Point(17, 11);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(267, 37);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Detalle de factura";
            // 
            // picLogoForm
            // 
            this.picLogoForm.Image = global::GOLLSYSTEM.Properties.Resources.goll_Logo_png;
            this.picLogoForm.Location = new System.Drawing.Point(460, 0);
            this.picLogoForm.Name = "picLogoForm";
            this.picLogoForm.Size = new System.Drawing.Size(73, 54);
            this.picLogoForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoForm.TabIndex = 0;
            this.picLogoForm.TabStop = false;
            // 
            // valProducto
            // 
            this.valProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.valProducto.Location = new System.Drawing.Point(12, 295);
            this.valProducto.Name = "valProducto";
            this.valProducto.Size = new System.Drawing.Size(205, 3);
            this.valProducto.TabIndex = 104;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.Black;
            this.btnAceptar.Location = new System.Drawing.Point(406, 302);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(86, 26);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblTituloDgv
            // 
            this.lblTituloDgv.AutoSize = true;
            this.lblTituloDgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloDgv.Location = new System.Drawing.Point(12, 71);
            this.lblTituloDgv.Name = "lblTituloDgv";
            this.lblTituloDgv.Size = new System.Drawing.Size(123, 16);
            this.lblTituloDgv.TabIndex = 106;
            this.lblTituloDgv.Text = "Producto o servicio";
            // 
            // btnRegistrarProducto
            // 
            this.btnRegistrarProducto.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnRegistrarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegistrarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarProducto.ForeColor = System.Drawing.Color.Black;
            this.btnRegistrarProducto.Location = new System.Drawing.Point(148, 302);
            this.btnRegistrarProducto.Name = "btnRegistrarProducto";
            this.btnRegistrarProducto.Size = new System.Drawing.Size(69, 26);
            this.btnRegistrarProducto.TabIndex = 6;
            this.btnRegistrarProducto.Text = "+Nuevo";
            this.btnRegistrarProducto.UseVisualStyleBackColor = false;
            this.btnRegistrarProducto.Click += new System.EventHandler(this.btnRegistrarProducto_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(319, 302);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(77, 27);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 110;
            this.label2.Text = "Precio:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblPrecio.Location = new System.Drawing.Point(89, 14);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(49, 20);
            this.lblPrecio.TabIndex = 109;
            this.lblPrecio.Text = "$0.00";
            // 
            // lblTextTelefono
            // 
            this.lblTextTelefono.AutoSize = true;
            this.lblTextTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextTelefono.Location = new System.Drawing.Point(8, 48);
            this.lblTextTelefono.Name = "lblTextTelefono";
            this.lblTextTelefono.Size = new System.Drawing.Size(51, 16);
            this.lblTextTelefono.TabIndex = 113;
            this.lblTextTelefono.Text = "Aporte:";
            // 
            // valAporte
            // 
            this.valAporte.BackColor = System.Drawing.Color.Gray;
            this.valAporte.Location = new System.Drawing.Point(92, 67);
            this.valAporte.Name = "valAporte";
            this.valAporte.Size = new System.Drawing.Size(71, 2);
            this.valAporte.TabIndex = 112;
            // 
            // txtAporte
            // 
            this.txtAporte.BackColor = System.Drawing.SystemColors.Control;
            this.txtAporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAporte.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtAporte.Location = new System.Drawing.Point(102, 45);
            this.txtAporte.Name = "txtAporte";
            this.txtAporte.Size = new System.Drawing.Size(68, 20);
            this.txtAporte.TabIndex = 1;
            this.txtAporte.Text = "0.00";
            this.txtAporte.Enter += new System.EventHandler(this.txtAporte_Enter);
            this.txtAporte.Leave += new System.EventHandler(this.txtAporte_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 116;
            this.label3.Text = "Descuento:";
            // 
            // valDescuento
            // 
            this.valDescuento.BackColor = System.Drawing.Color.Gray;
            this.valDescuento.Location = new System.Drawing.Point(94, 98);
            this.valDescuento.Name = "valDescuento";
            this.valDescuento.Size = new System.Drawing.Size(69, 2);
            this.valDescuento.TabIndex = 115;
            // 
            // txtDescuento
            // 
            this.txtDescuento.BackColor = System.Drawing.SystemColors.Control;
            this.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtDescuento.Location = new System.Drawing.Point(101, 76);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(69, 20);
            this.txtDescuento.TabIndex = 2;
            this.txtDescuento.Text = "0.00";
            this.txtDescuento.Enter += new System.EventHandler(this.txtAporte_Enter);
            this.txtDescuento.Leave += new System.EventHandler(this.txtDescuento_Leave);
            // 
            // errDgvProducto
            // 
            this.errDgvProducto.ContainerControl = this;
            // 
            // errAporte
            // 
            this.errAporte.ContainerControl = this;
            // 
            // errDescuento
            // 
            this.errDescuento.ContainerControl = this;
            // 
            // errCantidad
            // 
            this.errCantidad.ContainerControl = this;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlParamMensualidad);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(223, 83);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(296, 213);
            this.flowLayoutPanel1.TabIndex = 117;
            // 
            // pnlParamMensualidad
            // 
            this.pnlParamMensualidad.Controls.Add(this.cbxEstudiante);
            this.pnlParamMensualidad.Controls.Add(this.label4);
            this.pnlParamMensualidad.Controls.Add(this.cbxYear);
            this.pnlParamMensualidad.Controls.Add(this.cbxCurso);
            this.pnlParamMensualidad.Controls.Add(this.label1);
            this.pnlParamMensualidad.Location = new System.Drawing.Point(3, 3);
            this.pnlParamMensualidad.Name = "pnlParamMensualidad";
            this.pnlParamMensualidad.Size = new System.Drawing.Size(293, 73);
            this.pnlParamMensualidad.TabIndex = 0;
            // 
            // cbxEstudiante
            // 
            this.cbxEstudiante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxEstudiante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEstudiante.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxEstudiante.FormattingEnabled = true;
            this.cbxEstudiante.Location = new System.Drawing.Point(93, 39);
            this.cbxEstudiante.Name = "cbxEstudiante";
            this.cbxEstudiante.Size = new System.Drawing.Size(197, 24);
            this.cbxEstudiante.TabIndex = 106;
            this.cbxEstudiante.SelectedIndexChanged += new System.EventHandler(this.cbxEstudiante_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.label4.Location = new System.Drawing.Point(8, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 18);
            this.label4.TabIndex = 105;
            this.label4.Text = "Estudiante:";
            // 
            // cbxYear
            // 
            this.cbxYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxYear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxYear.FormattingEnabled = true;
            this.cbxYear.Location = new System.Drawing.Point(93, 9);
            this.cbxYear.Name = "cbxYear";
            this.cbxYear.Size = new System.Drawing.Size(56, 24);
            this.cbxYear.TabIndex = 104;
            this.cbxYear.SelectedIndexChanged += new System.EventHandler(this.cbxYear_SelectedIndexChanged);
            // 
            // cbxCurso
            // 
            this.cbxCurso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCurso.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCurso.FormattingEnabled = true;
            this.cbxCurso.Location = new System.Drawing.Point(155, 9);
            this.cbxCurso.Name = "cbxCurso";
            this.cbxCurso.Size = new System.Drawing.Size(135, 24);
            this.cbxCurso.TabIndex = 103;
            this.cbxCurso.SelectedIndexChanged += new System.EventHandler(this.cbxCurso_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 18);
            this.label1.TabIndex = 102;
            this.label1.Text = "Curso:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBecado);
            this.panel2.Controls.Add(this.txtDescuento);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtAporte);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblPrecio);
            this.panel2.Controls.Add(this.valDescuento);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.valAporte);
            this.panel2.Controls.Add(this.lblTextTelefono);
            this.panel2.Location = new System.Drawing.Point(3, 82);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(293, 114);
            this.panel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(89, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 18);
            this.label6.TabIndex = 118;
            this.label6.Text = "$";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(90, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 18);
            this.label5.TabIndex = 117;
            this.label5.Text = "$";
            // 
            // checkBecado
            // 
            this.checkBecado.AutoSize = true;
            this.checkBecado.Enabled = false;
            this.checkBecado.Location = new System.Drawing.Point(227, 3);
            this.checkBecado.Name = "checkBecado";
            this.checkBecado.Size = new System.Drawing.Size(63, 17);
            this.checkBecado.TabIndex = 119;
            this.checkBecado.Text = "Becado";
            this.checkBecado.UseVisualStyleBackColor = true;
            // 
            // frmBuscarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 345);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRegistrarProducto);
            this.Controls.Add(this.lblTituloDgv);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.pblTitulo);
            this.Controls.Add(this.valProducto);
            this.Controls.Add(this.btnAceptar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBuscarProducto";
            this.Text = "Buscar Producto";
            this.Load += new System.EventHandler(this.frmBuscarProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.pblTitulo.ResumeLayout(false);
            this.pblTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errDgvProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errAporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errCantidad)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlParamMensualidad.ResumeLayout(false);
            this.pnlParamMensualidad.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Panel pblTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox picLogoForm;
        private System.Windows.Forms.Panel valProducto;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.Label lblTituloDgv;
        private System.Windows.Forms.Button btnRegistrarProducto;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblTextTelefono;
        private System.Windows.Forms.Panel valAporte;
        private System.Windows.Forms.TextBox txtAporte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel valDescuento;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.ErrorProvider errDgvProducto;
        private System.Windows.Forms.ErrorProvider errAporte;
        private System.Windows.Forms.ErrorProvider errDescuento;
        private System.Windows.Forms.ErrorProvider errCantidad;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlParamMensualidad;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbxEstudiante;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxYear;
        private System.Windows.Forms.ComboBox cbxCurso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBecado;
    }
}