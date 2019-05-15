namespace GOLLSYSTEM.Forms
{
    partial class FrmFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFactura));
            this.pblTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picLogoForm = new System.Windows.Forms.PictureBox();
            this.gbxICliente = new System.Windows.Forms.GroupBox();
            this.lblTextTelefono = new System.Windows.Forms.Label();
            this.valTelefono = new System.Windows.Forms.Panel();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.lblTextNombre = new System.Windows.Forms.Label();
            this.valNombre = new System.Windows.Forms.Panel();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbxAgregar = new System.Windows.Forms.GroupBox();
            this.btnContado = new System.Windows.Forms.Button();
            this.btnCancelacion = new System.Windows.Forms.Button();
            this.btnMesualidad = new System.Windows.Forms.Button();
            this.dgvCursos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idproducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.lblNFactura = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.errNombre = new System.Windows.Forms.ErrorProvider(this.components);
            this.errDetalles = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnRemoveDetalle = new System.Windows.Forms.Button();
            this.valDetalles = new System.Windows.Forms.Panel();
            this.dtpFhRegistro = new System.Windows.Forms.DateTimePicker();
            this.pblTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoForm)).BeginInit();
            this.gbxICliente.SuspendLayout();
            this.gbxAgregar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // pblTitulo
            // 
            this.pblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.pblTitulo.Controls.Add(this.lblTitulo);
            this.pblTitulo.Controls.Add(this.picLogoForm);
            this.pblTitulo.Location = new System.Drawing.Point(-1, 1);
            this.pblTitulo.Name = "pblTitulo";
            this.pblTitulo.Size = new System.Drawing.Size(660, 75);
            this.pblTitulo.TabIndex = 3;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitulo.Location = new System.Drawing.Point(13, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(449, 55);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Factura de ingresos";
            // 
            // picLogoForm
            // 
            this.picLogoForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogoForm.Image = global::GOLLSYSTEM.Properties.Resources.goll_Logo_png;
            this.picLogoForm.Location = new System.Drawing.Point(551, 3);
            this.picLogoForm.Name = "picLogoForm";
            this.picLogoForm.Size = new System.Drawing.Size(109, 69);
            this.picLogoForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoForm.TabIndex = 0;
            this.picLogoForm.TabStop = false;
            // 
            // gbxICliente
            // 
            this.gbxICliente.Controls.Add(this.lblTextTelefono);
            this.gbxICliente.Controls.Add(this.valTelefono);
            this.gbxICliente.Controls.Add(this.txtTelefono);
            this.gbxICliente.Controls.Add(this.btnBuscarCliente);
            this.gbxICliente.Controls.Add(this.lblTextNombre);
            this.gbxICliente.Controls.Add(this.valNombre);
            this.gbxICliente.Controls.Add(this.txtNombre);
            this.gbxICliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxICliente.Location = new System.Drawing.Point(18, 161);
            this.gbxICliente.Name = "gbxICliente";
            this.gbxICliente.Size = new System.Drawing.Size(621, 61);
            this.gbxICliente.TabIndex = 1;
            this.gbxICliente.TabStop = false;
            this.gbxICliente.Text = "Cliente";
            // 
            // lblTextTelefono
            // 
            this.lblTextTelefono.AutoSize = true;
            this.lblTextTelefono.Location = new System.Drawing.Point(322, 29);
            this.lblTextTelefono.Name = "lblTextTelefono";
            this.lblTextTelefono.Size = new System.Drawing.Size(62, 16);
            this.lblTextTelefono.TabIndex = 35;
            this.lblTextTelefono.Text = "Teléfono";
            // 
            // valTelefono
            // 
            this.valTelefono.BackColor = System.Drawing.Color.Gray;
            this.valTelefono.Location = new System.Drawing.Point(390, 44);
            this.valTelefono.Name = "valTelefono";
            this.valTelefono.Size = new System.Drawing.Size(99, 2);
            this.valTelefono.TabIndex = 34;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.SystemColors.Control;
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtTelefono.Location = new System.Drawing.Point(390, 22);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.ReadOnly = true;
            this.txtTelefono.Size = new System.Drawing.Size(99, 20);
            this.txtTelefono.TabIndex = 1;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCliente.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarCliente.Location = new System.Drawing.Point(526, 21);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(85, 27);
            this.btnBuscarCliente.TabIndex = 2;
            this.btnBuscarCliente.Text = "Buscar";
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // lblTextNombre
            // 
            this.lblTextNombre.AutoSize = true;
            this.lblTextNombre.Location = new System.Drawing.Point(15, 28);
            this.lblTextNombre.Name = "lblTextNombre";
            this.lblTextNombre.Size = new System.Drawing.Size(57, 16);
            this.lblTextNombre.TabIndex = 19;
            this.lblTextNombre.Text = "Nombre";
            // 
            // valNombre
            // 
            this.valNombre.BackColor = System.Drawing.Color.Gray;
            this.valNombre.Location = new System.Drawing.Point(76, 44);
            this.valNombre.Name = "valNombre";
            this.valNombre.Size = new System.Drawing.Size(240, 2);
            this.valNombre.TabIndex = 18;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtNombre.Location = new System.Drawing.Point(78, 22);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(236, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(463, 469);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(81, 29);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(558, 469);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(81, 29);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // gbxAgregar
            // 
            this.gbxAgregar.Controls.Add(this.btnContado);
            this.gbxAgregar.Controls.Add(this.btnCancelacion);
            this.gbxAgregar.Controls.Add(this.btnMesualidad);
            this.gbxAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAgregar.Location = new System.Drawing.Point(18, 233);
            this.gbxAgregar.Name = "gbxAgregar";
            this.gbxAgregar.Size = new System.Drawing.Size(621, 61);
            this.gbxAgregar.TabIndex = 2;
            this.gbxAgregar.TabStop = false;
            this.gbxAgregar.Text = "Agregar";
            // 
            // btnContado
            // 
            this.btnContado.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnContado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnContado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContado.ForeColor = System.Drawing.Color.Black;
            this.btnContado.Location = new System.Drawing.Point(125, 21);
            this.btnContado.Name = "btnContado";
            this.btnContado.Size = new System.Drawing.Size(134, 27);
            this.btnContado.TabIndex = 2;
            this.btnContado.Text = "Producto/Servicio";
            this.btnContado.UseVisualStyleBackColor = false;
            this.btnContado.Click += new System.EventHandler(this.btnContado_Click);
            // 
            // btnCancelacion
            // 
            this.btnCancelacion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancelacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelacion.ForeColor = System.Drawing.Color.Black;
            this.btnCancelacion.Location = new System.Drawing.Point(265, 21);
            this.btnCancelacion.Name = "btnCancelacion";
            this.btnCancelacion.Size = new System.Drawing.Size(101, 27);
            this.btnCancelacion.TabIndex = 3;
            this.btnCancelacion.Text = "Cancelación";
            this.btnCancelacion.UseVisualStyleBackColor = false;
            this.btnCancelacion.Click += new System.EventHandler(this.btnCancelacion_Click);
            // 
            // btnMesualidad
            // 
            this.btnMesualidad.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnMesualidad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMesualidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMesualidad.ForeColor = System.Drawing.Color.Black;
            this.btnMesualidad.Location = new System.Drawing.Point(18, 21);
            this.btnMesualidad.Name = "btnMesualidad";
            this.btnMesualidad.Size = new System.Drawing.Size(101, 27);
            this.btnMesualidad.TabIndex = 1;
            this.btnMesualidad.Text = "Mensualidad";
            this.btnMesualidad.UseVisualStyleBackColor = false;
            this.btnMesualidad.Click += new System.EventHandler(this.btnMesualidad_Click);
            // 
            // dgvCursos
            // 
            this.dgvCursos.AllowUserToAddRows = false;
            this.dgvCursos.AllowUserToDeleteRows = false;
            this.dgvCursos.AllowUserToResizeRows = false;
            this.dgvCursos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCursos.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dgvCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.producto,
            this.tipo,
            this.precio,
            this.descuento,
            this.subtotal,
            this.idproducto});
            this.dgvCursos.Location = new System.Drawing.Point(18, 308);
            this.dgvCursos.MultiSelect = false;
            this.dgvCursos.Name = "dgvCursos";
            this.dgvCursos.ReadOnly = true;
            this.dgvCursos.RowHeadersVisible = false;
            this.dgvCursos.RowTemplate.Height = 30;
            this.dgvCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCursos.Size = new System.Drawing.Size(621, 124);
            this.dgvCursos.TabIndex = 102;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // producto
            // 
            this.producto.HeaderText = "Producto/Servicio";
            this.producto.Name = "producto";
            this.producto.ReadOnly = true;
            // 
            // tipo
            // 
            this.tipo.FillWeight = 60F;
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            // 
            // precio
            // 
            this.precio.FillWeight = 50F;
            this.precio.HeaderText = "Precio";
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            // 
            // descuento
            // 
            this.descuento.FillWeight = 60F;
            this.descuento.HeaderText = "Descuento";
            this.descuento.Name = "descuento";
            this.descuento.ReadOnly = true;
            // 
            // subtotal
            // 
            this.subtotal.FillWeight = 60F;
            this.subtotal.HeaderText = "Subtotal ";
            this.subtotal.Name = "subtotal";
            this.subtotal.ReadOnly = true;
            // 
            // idproducto
            // 
            this.idproducto.HeaderText = "IdProducto";
            this.idproducto.Name = "idproducto";
            this.idproducto.ReadOnly = true;
            this.idproducto.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotal.Location = new System.Drawing.Point(335, 444);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(49, 20);
            this.lblTotal.TabIndex = 103;
            this.lblTotal.Text = "$0.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(296, 446);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 104;
            this.label2.Text = "Total:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(480, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "N Factura";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Fecha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "Sucursal";
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Location = new System.Drawing.Point(246, 104);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(92, 16);
            this.lblSucursal.TabIndex = 105;
            this.lblSucursal.Text = "Chalatenango";
            // 
            // lblNFactura
            // 
            this.lblNFactura.AutoSize = true;
            this.lblNFactura.Location = new System.Drawing.Point(552, 104);
            this.lblNFactura.Name = "lblNFactura";
            this.lblNFactura.Size = new System.Drawing.Size(78, 16);
            this.lblNFactura.TabIndex = 107;
            this.lblNFactura.Text = "1903022050";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(22, 137);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 2);
            this.panel1.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 446);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 16);
            this.label6.TabIndex = 109;
            this.label6.Text = "Subtotal:";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.ForeColor = System.Drawing.Color.Black;
            this.lblSubtotal.Location = new System.Drawing.Point(70, 444);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(49, 20);
            this.lblSubtotal.TabIndex = 108;
            this.lblSubtotal.Text = "$0.00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(148, 446);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 16);
            this.label8.TabIndex = 111;
            this.label8.Text = "Descuento:";
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.ForeColor = System.Drawing.Color.Coral;
            this.lblDescuento.Location = new System.Drawing.Point(219, 444);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(49, 20);
            this.lblDescuento.TabIndex = 110;
            this.lblDescuento.Text = "$0.00";
            // 
            // errNombre
            // 
            this.errNombre.ContainerControl = this;
            // 
            // errDetalles
            // 
            this.errDetalles.ContainerControl = this;
            // 
            // btnRemoveDetalle
            // 
            this.btnRemoveDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveDetalle.BackColor = System.Drawing.Color.MistyRose;
            this.btnRemoveDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveDetalle.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveDetalle.Location = new System.Drawing.Point(605, 431);
            this.btnRemoveDetalle.Name = "btnRemoveDetalle";
            this.btnRemoveDetalle.Size = new System.Drawing.Size(34, 26);
            this.btnRemoveDetalle.TabIndex = 112;
            this.btnRemoveDetalle.Text = "-";
            this.btnRemoveDetalle.UseVisualStyleBackColor = false;
            this.btnRemoveDetalle.Click += new System.EventHandler(this.btnRemoveDetalle_Click);
            // 
            // valDetalles
            // 
            this.valDetalles.BackColor = System.Drawing.Color.Gray;
            this.valDetalles.Location = new System.Drawing.Point(18, 431);
            this.valDetalles.Name = "valDetalles";
            this.valDetalles.Size = new System.Drawing.Size(610, 2);
            this.valDetalles.TabIndex = 113;
            // 
            // dtpFhRegistro
            // 
            this.dtpFhRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFhRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFhRegistro.Location = new System.Drawing.Point(71, 100);
            this.dtpFhRegistro.Name = "dtpFhRegistro";
            this.dtpFhRegistro.Size = new System.Drawing.Size(88, 22);
            this.dtpFhRegistro.TabIndex = 60;
            // 
            // FrmFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 508);
            this.Controls.Add(this.dtpFhRegistro);
            this.Controls.Add(this.btnRemoveDetalle);
            this.Controls.Add(this.valDetalles);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblNFactura);
            this.Controls.Add(this.lblSucursal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvCursos);
            this.Controls.Add(this.gbxAgregar);
            this.Controls.Add(this.gbxICliente);
            this.Controls.Add(this.pblTitulo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(676, 547);
            this.MinimumSize = new System.Drawing.Size(676, 547);
            this.Name = "FrmFactura";
            this.Text = "Factura";
            this.Load += new System.EventHandler(this.FrmFactura_Load);
            this.pblTitulo.ResumeLayout(false);
            this.pblTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoForm)).EndInit();
            this.gbxICliente.ResumeLayout(false);
            this.gbxICliente.PerformLayout();
            this.gbxAgregar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errDetalles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pblTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox picLogoForm;
        private System.Windows.Forms.GroupBox gbxICliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblTextNombre;
        private System.Windows.Forms.Panel valNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblTextTelefono;
        private System.Windows.Forms.Panel valTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.GroupBox gbxAgregar;
        private System.Windows.Forms.Button btnCancelacion;
        private System.Windows.Forms.Button btnMesualidad;
        private System.Windows.Forms.DataGridView dgvCursos;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.Label lblNFactura;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.ErrorProvider errNombre;
        private System.Windows.Forms.ErrorProvider errDetalles;
        private System.Windows.Forms.Button btnContado;
        private System.Windows.Forms.Button btnRemoveDetalle;
        private System.Windows.Forms.Panel valDetalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn idproducto;
        private System.Windows.Forms.DateTimePicker dtpFhRegistro;
    }
}