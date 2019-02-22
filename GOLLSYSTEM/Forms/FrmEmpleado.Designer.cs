namespace GOLLSYSTEM.Forms
{
    partial class FrmEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmpleado));
            this.picLogoForm = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pblTitulo = new System.Windows.Forms.Panel();
            this.gbxInformacion = new System.Windows.Forms.GroupBox();
            this.lblTextDireccion = new System.Windows.Forms.Label();
            this.valDireccion = new System.Windows.Forms.Panel();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.valCargo = new System.Windows.Forms.Panel();
            this.lblTextCargo = new System.Windows.Forms.Label();
            this.cmbCargo = new System.Windows.Forms.ComboBox();
            this.lblTextCorreo = new System.Windows.Forms.Label();
            this.valCorreo = new System.Windows.Forms.Panel();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblTextTelefono = new System.Windows.Forms.Label();
            this.valTelefono = new System.Windows.Forms.Panel();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTextNoNit = new System.Windows.Forms.Label();
            this.valNit = new System.Windows.Forms.Panel();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.lblTextNoDui = new System.Windows.Forms.Label();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.valDui = new System.Windows.Forms.Panel();
            this.valFechaNac = new System.Windows.Forms.Panel();
            this.txtDui = new System.Windows.Forms.TextBox();
            this.lblTextFechaNac = new System.Windows.Forms.Label();
            this.lblTextNombre = new System.Windows.Forms.Label();
            this.valNombre = new System.Windows.Forms.Panel();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.errNombre = new System.Windows.Forms.ErrorProvider(this.components);
            this.errTelefono = new System.Windows.Forms.ErrorProvider(this.components);
            this.errDui = new System.Windows.Forms.ErrorProvider(this.components);
            this.errNit = new System.Windows.Forms.ErrorProvider(this.components);
            this.errCorreo = new System.Windows.Forms.ErrorProvider(this.components);
            this.errFechaNac = new System.Windows.Forms.ErrorProvider(this.components);
            this.errCargo = new System.Windows.Forms.ErrorProvider(this.components);
            this.errDireccion = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picLogoForm)).BeginInit();
            this.pblTitulo.SuspendLayout();
            this.gbxInformacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTelefono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errDui)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errCorreo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errFechaNac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errCargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errDireccion)).BeginInit();
            this.SuspendLayout();
            // 
            // picLogoForm
            // 
            this.picLogoForm.Image = global::GOLLSYSTEM.Properties.Resources.goll_Logo_png;
            this.picLogoForm.Location = new System.Drawing.Point(538, 3);
            this.picLogoForm.Name = "picLogoForm";
            this.picLogoForm.Size = new System.Drawing.Size(109, 87);
            this.picLogoForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoForm.TabIndex = 0;
            this.picLogoForm.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitulo.Location = new System.Drawing.Point(15, 29);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(500, 55);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Registro de Empleado";
            // 
            // pblTitulo
            // 
            this.pblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.pblTitulo.Controls.Add(this.lblTitulo);
            this.pblTitulo.Controls.Add(this.picLogoForm);
            this.pblTitulo.Location = new System.Drawing.Point(-3, -1);
            this.pblTitulo.Name = "pblTitulo";
            this.pblTitulo.Size = new System.Drawing.Size(660, 100);
            this.pblTitulo.TabIndex = 2;
            // 
            // gbxInformacion
            // 
            this.gbxInformacion.Controls.Add(this.lblTextDireccion);
            this.gbxInformacion.Controls.Add(this.valDireccion);
            this.gbxInformacion.Controls.Add(this.txtDireccion);
            this.gbxInformacion.Controls.Add(this.btnCancelar);
            this.gbxInformacion.Controls.Add(this.pictureBox2);
            this.gbxInformacion.Controls.Add(this.btnGuardar);
            this.gbxInformacion.Controls.Add(this.valCargo);
            this.gbxInformacion.Controls.Add(this.lblTextCargo);
            this.gbxInformacion.Controls.Add(this.cmbCargo);
            this.gbxInformacion.Controls.Add(this.lblTextCorreo);
            this.gbxInformacion.Controls.Add(this.valCorreo);
            this.gbxInformacion.Controls.Add(this.txtCorreo);
            this.gbxInformacion.Controls.Add(this.lblTextTelefono);
            this.gbxInformacion.Controls.Add(this.valTelefono);
            this.gbxInformacion.Controls.Add(this.txtTelefono);
            this.gbxInformacion.Controls.Add(this.lblTextNoNit);
            this.gbxInformacion.Controls.Add(this.valNit);
            this.gbxInformacion.Controls.Add(this.txtNit);
            this.gbxInformacion.Controls.Add(this.lblTextNoDui);
            this.gbxInformacion.Controls.Add(this.dtpFechaNac);
            this.gbxInformacion.Controls.Add(this.valDui);
            this.gbxInformacion.Controls.Add(this.valFechaNac);
            this.gbxInformacion.Controls.Add(this.txtDui);
            this.gbxInformacion.Controls.Add(this.lblTextFechaNac);
            this.gbxInformacion.Controls.Add(this.lblTextNombre);
            this.gbxInformacion.Controls.Add(this.valNombre);
            this.gbxInformacion.Controls.Add(this.txtNombre);
            this.gbxInformacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxInformacion.Location = new System.Drawing.Point(12, 118);
            this.gbxInformacion.Name = "gbxInformacion";
            this.gbxInformacion.Size = new System.Drawing.Size(621, 360);
            this.gbxInformacion.TabIndex = 3;
            this.gbxInformacion.TabStop = false;
            this.gbxInformacion.Text = "Información Personal";
            // 
            // lblTextDireccion
            // 
            this.lblTextDireccion.AutoSize = true;
            this.lblTextDireccion.Location = new System.Drawing.Point(9, 256);
            this.lblTextDireccion.Name = "lblTextDireccion";
            this.lblTextDireccion.Size = new System.Drawing.Size(65, 16);
            this.lblTextDireccion.TabIndex = 40;
            this.lblTextDireccion.Text = "Dirección";
            // 
            // valDireccion
            // 
            this.valDireccion.BackColor = System.Drawing.Color.Gray;
            this.valDireccion.Location = new System.Drawing.Point(79, 346);
            this.valDireccion.Name = "valDireccion";
            this.valDireccion.Size = new System.Drawing.Size(315, 2);
            this.valDireccion.TabIndex = 39;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.SystemColors.Control;
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtDireccion.Location = new System.Drawing.Point(78, 256);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(316, 90);
            this.txtDireccion.TabIndex = 38;
            this.txtDireccion.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancelar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(428, 316);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(81, 32);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GOLLSYSTEM.Properties.Resources.jefe;
            this.pictureBox2.Location = new System.Drawing.Point(429, 97);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(176, 195);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnGuardar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(523, 316);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(81, 32);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // valCargo
            // 
            this.valCargo.BackColor = System.Drawing.Color.Gray;
            this.valCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valCargo.Location = new System.Drawing.Point(270, 224);
            this.valCargo.Name = "valCargo";
            this.valCargo.Size = new System.Drawing.Size(131, 2);
            this.valCargo.TabIndex = 25;
            // 
            // lblTextCargo
            // 
            this.lblTextCargo.AutoSize = true;
            this.lblTextCargo.Location = new System.Drawing.Point(216, 207);
            this.lblTextCargo.Name = "lblTextCargo";
            this.lblTextCargo.Size = new System.Drawing.Size(45, 16);
            this.lblTextCargo.TabIndex = 37;
            this.lblTextCargo.Text = "Cargo";
            // 
            // cmbCargo
            // 
            this.cmbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCargo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCargo.FormattingEnabled = true;
            this.cmbCargo.Location = new System.Drawing.Point(271, 201);
            this.cmbCargo.Name = "cmbCargo";
            this.cmbCargo.Size = new System.Drawing.Size(129, 24);
            this.cmbCargo.TabIndex = 36;
            this.cmbCargo.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // lblTextCorreo
            // 
            this.lblTextCorreo.AutoSize = true;
            this.lblTextCorreo.Location = new System.Drawing.Point(9, 154);
            this.lblTextCorreo.Name = "lblTextCorreo";
            this.lblTextCorreo.Size = new System.Drawing.Size(49, 16);
            this.lblTextCorreo.TabIndex = 35;
            this.lblTextCorreo.Text = "Correo";
            // 
            // valCorreo
            // 
            this.valCorreo.BackColor = System.Drawing.Color.Gray;
            this.valCorreo.Location = new System.Drawing.Point(73, 172);
            this.valCorreo.Name = "valCorreo";
            this.valCorreo.Size = new System.Drawing.Size(328, 2);
            this.valCorreo.TabIndex = 34;
            // 
            // txtCorreo
            // 
            this.txtCorreo.BackColor = System.Drawing.SystemColors.Control;
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtCorreo.Location = new System.Drawing.Point(74, 150);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(324, 20);
            this.txtCorreo.TabIndex = 33;
            this.txtCorreo.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // lblTextTelefono
            // 
            this.lblTextTelefono.AutoSize = true;
            this.lblTextTelefono.Location = new System.Drawing.Point(411, 47);
            this.lblTextTelefono.Name = "lblTextTelefono";
            this.lblTextTelefono.Size = new System.Drawing.Size(62, 16);
            this.lblTextTelefono.TabIndex = 32;
            this.lblTextTelefono.Text = "Teléfono";
            // 
            // valTelefono
            // 
            this.valTelefono.BackColor = System.Drawing.Color.Gray;
            this.valTelefono.Location = new System.Drawing.Point(477, 65);
            this.valTelefono.Name = "valTelefono";
            this.valTelefono.Size = new System.Drawing.Size(128, 2);
            this.valTelefono.TabIndex = 31;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.SystemColors.Control;
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtTelefono.Location = new System.Drawing.Point(479, 43);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(124, 20);
            this.txtTelefono.TabIndex = 30;
            this.txtTelefono.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // lblTextNoNit
            // 
            this.lblTextNoNit.AutoSize = true;
            this.lblTextNoNit.Location = new System.Drawing.Point(216, 103);
            this.lblTextNoNit.Name = "lblTextNoNit";
            this.lblTextNoNit.Size = new System.Drawing.Size(48, 16);
            this.lblTextNoNit.TabIndex = 29;
            this.lblTextNoNit.Text = "No. Nit";
            // 
            // valNit
            // 
            this.valNit.BackColor = System.Drawing.Color.Gray;
            this.valNit.Location = new System.Drawing.Point(273, 117);
            this.valNit.Name = "valNit";
            this.valNit.Size = new System.Drawing.Size(128, 2);
            this.valNit.TabIndex = 28;
            // 
            // txtNit
            // 
            this.txtNit.BackColor = System.Drawing.SystemColors.Control;
            this.txtNit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNit.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtNit.Location = new System.Drawing.Point(275, 95);
            this.txtNit.Name = "txtNit";
            this.txtNit.Size = new System.Drawing.Size(124, 20);
            this.txtNit.TabIndex = 27;
            this.txtNit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNit_KeyUp);
            this.txtNit.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // lblTextNoDui
            // 
            this.lblTextNoDui.AutoSize = true;
            this.lblTextNoDui.Location = new System.Drawing.Point(9, 103);
            this.lblTextNoDui.Name = "lblTextNoDui";
            this.lblTextNoDui.Size = new System.Drawing.Size(52, 16);
            this.lblTextNoDui.TabIndex = 22;
            this.lblTextNoDui.Text = "No. Dui";
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNac.Location = new System.Drawing.Point(89, 202);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(106, 22);
            this.dtpFechaNac.TabIndex = 26;
            this.dtpFechaNac.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // valDui
            // 
            this.valDui.BackColor = System.Drawing.Color.Gray;
            this.valDui.Location = new System.Drawing.Point(73, 118);
            this.valDui.Name = "valDui";
            this.valDui.Size = new System.Drawing.Size(124, 2);
            this.valDui.TabIndex = 21;
            // 
            // valFechaNac
            // 
            this.valFechaNac.BackColor = System.Drawing.Color.Gray;
            this.valFechaNac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valFechaNac.Location = new System.Drawing.Point(88, 226);
            this.valFechaNac.Name = "valFechaNac";
            this.valFechaNac.Size = new System.Drawing.Size(107, 2);
            this.valFechaNac.TabIndex = 24;
            // 
            // txtDui
            // 
            this.txtDui.BackColor = System.Drawing.SystemColors.Control;
            this.txtDui.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDui.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDui.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtDui.Location = new System.Drawing.Point(75, 96);
            this.txtDui.Name = "txtDui";
            this.txtDui.Size = new System.Drawing.Size(120, 20);
            this.txtDui.TabIndex = 20;
            this.txtDui.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDui_KeyUp);
            this.txtDui.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // lblTextFechaNac
            // 
            this.lblTextFechaNac.AutoSize = true;
            this.lblTextFechaNac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextFechaNac.Location = new System.Drawing.Point(9, 207);
            this.lblTextFechaNac.Name = "lblTextFechaNac";
            this.lblTextFechaNac.Size = new System.Drawing.Size(74, 16);
            this.lblTextFechaNac.TabIndex = 25;
            this.lblTextFechaNac.Text = "Fecha Nac";
            // 
            // lblTextNombre
            // 
            this.lblTextNombre.AutoSize = true;
            this.lblTextNombre.Location = new System.Drawing.Point(9, 47);
            this.lblTextNombre.Name = "lblTextNombre";
            this.lblTextNombre.Size = new System.Drawing.Size(57, 16);
            this.lblTextNombre.TabIndex = 19;
            this.lblTextNombre.Text = "Nombre";
            // 
            // valNombre
            // 
            this.valNombre.BackColor = System.Drawing.Color.Gray;
            this.valNombre.Location = new System.Drawing.Point(73, 63);
            this.valNombre.Name = "valNombre";
            this.valNombre.Size = new System.Drawing.Size(327, 2);
            this.valNombre.TabIndex = 18;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtNombre.Location = new System.Drawing.Point(75, 41);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(323, 20);
            this.txtNombre.TabIndex = 17;
            this.txtNombre.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // errNombre
            // 
            this.errNombre.ContainerControl = this;
            this.errNombre.Icon = ((System.Drawing.Icon)(resources.GetObject("errNombre.Icon")));
            // 
            // errTelefono
            // 
            this.errTelefono.ContainerControl = this;
            this.errTelefono.Icon = ((System.Drawing.Icon)(resources.GetObject("errTelefono.Icon")));
            // 
            // errDui
            // 
            this.errDui.ContainerControl = this;
            this.errDui.Icon = ((System.Drawing.Icon)(resources.GetObject("errDui.Icon")));
            // 
            // errNit
            // 
            this.errNit.ContainerControl = this;
            this.errNit.Icon = ((System.Drawing.Icon)(resources.GetObject("errNit.Icon")));
            // 
            // errCorreo
            // 
            this.errCorreo.ContainerControl = this;
            this.errCorreo.Icon = ((System.Drawing.Icon)(resources.GetObject("errCorreo.Icon")));
            // 
            // errFechaNac
            // 
            this.errFechaNac.ContainerControl = this;
            this.errFechaNac.Icon = ((System.Drawing.Icon)(resources.GetObject("errFechaNac.Icon")));
            // 
            // errCargo
            // 
            this.errCargo.ContainerControl = this;
            this.errCargo.Icon = ((System.Drawing.Icon)(resources.GetObject("errCargo.Icon")));
            // 
            // errDireccion
            // 
            this.errDireccion.ContainerControl = this;
            this.errDireccion.Icon = ((System.Drawing.Icon)(resources.GetObject("errDireccion.Icon")));
            // 
            // FrmEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 490);
            this.Controls.Add(this.gbxInformacion);
            this.Controls.Add(this.pblTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEmpleado";
            this.Text = "Empleado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEmpleado_FormClosing);
            this.Load += new System.EventHandler(this.FrmEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogoForm)).EndInit();
            this.pblTitulo.ResumeLayout(false);
            this.pblTitulo.PerformLayout();
            this.gbxInformacion.ResumeLayout(false);
            this.gbxInformacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTelefono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errDui)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errCorreo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errFechaNac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errCargo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errDireccion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogoForm;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pblTitulo;
        private System.Windows.Forms.GroupBox gbxInformacion;
        private System.Windows.Forms.Label lblTextNoNit;
        private System.Windows.Forms.Panel valNit;
        private System.Windows.Forms.TextBox txtNit;
        private System.Windows.Forms.Label lblTextNoDui;
        private System.Windows.Forms.Panel valDui;
        private System.Windows.Forms.TextBox txtDui;
        private System.Windows.Forms.Label lblTextNombre;
        private System.Windows.Forms.Panel valNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblTextFechaNac;
        private System.Windows.Forms.Panel valFechaNac;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.Panel valCargo;
        private System.Windows.Forms.Label lblTextCargo;
        private System.Windows.Forms.ComboBox cmbCargo;
        private System.Windows.Forms.Label lblTextCorreo;
        private System.Windows.Forms.Panel valCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblTextTelefono;
        private System.Windows.Forms.Panel valTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblTextDireccion;
        private System.Windows.Forms.Panel valDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ErrorProvider errNombre;
        private System.Windows.Forms.ErrorProvider errTelefono;
        private System.Windows.Forms.ErrorProvider errDui;
        private System.Windows.Forms.ErrorProvider errNit;
        private System.Windows.Forms.ErrorProvider errCorreo;
        private System.Windows.Forms.ErrorProvider errFechaNac;
        private System.Windows.Forms.ErrorProvider errCargo;
        private System.Windows.Forms.ErrorProvider errDireccion;
    }
}