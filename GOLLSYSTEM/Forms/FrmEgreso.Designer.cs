namespace GOLLSYSTEM.Forms
{
    partial class FrmEgreso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEgreso));
            this.pblTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picLogoForm = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblTextNoNit = new System.Windows.Forms.Label();
            this.valTipo = new System.Windows.Forms.Panel();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.lblTextNoDui = new System.Windows.Forms.Label();
            this.dtpFHRegistro = new System.Windows.Forms.DateTimePicker();
            this.valTotal = new System.Windows.Forms.Panel();
            this.valFecha = new System.Windows.Forms.Panel();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTextFechaNac = new System.Windows.Forms.Label();
            this.lblTextNombre = new System.Windows.Forms.Label();
            this.valNombre = new System.Windows.Forms.Panel();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errTotal = new System.Windows.Forms.ErrorProvider(this.components);
            this.errTipo = new System.Windows.Forms.ErrorProvider(this.components);
            this.errConcepto = new System.Windows.Forms.ErrorProvider(this.components);
            this.errFecha = new System.Windows.Forms.ErrorProvider(this.components);
            this.errNombre = new System.Windows.Forms.ErrorProvider(this.components);
            this.pblTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errConcepto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNombre)).BeginInit();
            this.SuspendLayout();
            // 
            // pblTitulo
            // 
            this.pblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.pblTitulo.Controls.Add(this.lblTitulo);
            this.pblTitulo.Controls.Add(this.picLogoForm);
            this.pblTitulo.Location = new System.Drawing.Point(1, 1);
            this.pblTitulo.Name = "pblTitulo";
            this.pblTitulo.Size = new System.Drawing.Size(532, 60);
            this.pblTitulo.TabIndex = 107;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitulo.Location = new System.Drawing.Point(26, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(219, 37);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Nuevo Egreso";
            // 
            // picLogoForm
            // 
            this.picLogoForm.Image = global::GOLLSYSTEM.Properties.Resources.goll_Logo_png;
            this.picLogoForm.Location = new System.Drawing.Point(251, 3);
            this.picLogoForm.Name = "picLogoForm";
            this.picLogoForm.Size = new System.Drawing.Size(73, 54);
            this.picLogoForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoForm.TabIndex = 0;
            this.picLogoForm.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(207, 316);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(81, 32);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblTextNoNit
            // 
            this.lblTextNoNit.AutoSize = true;
            this.lblTextNoNit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextNoNit.Location = new System.Drawing.Point(32, 274);
            this.lblTextNoNit.Name = "lblTextNoNit";
            this.lblTextNoNit.Size = new System.Drawing.Size(43, 20);
            this.lblTextNoNit.TabIndex = 29;
            this.lblTextNoNit.Text = "Tipo:";
            // 
            // valTipo
            // 
            this.valTipo.BackColor = System.Drawing.Color.Gray;
            this.valTipo.Location = new System.Drawing.Point(120, 296);
            this.valTipo.Name = "valTipo";
            this.valTipo.Size = new System.Drawing.Size(166, 2);
            this.valTipo.TabIndex = 28;
            // 
            // txtTipo
            // 
            this.txtTipo.BackColor = System.Drawing.SystemColors.Control;
            this.txtTipo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipo.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtTipo.Location = new System.Drawing.Point(122, 274);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(162, 19);
            this.txtTipo.TabIndex = 4;
            // 
            // lblTextNoDui
            // 
            this.lblTextNoDui.AutoSize = true;
            this.lblTextNoDui.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextNoDui.Location = new System.Drawing.Point(32, 218);
            this.lblTextNoDui.Name = "lblTextNoDui";
            this.lblTextNoDui.Size = new System.Drawing.Size(48, 20);
            this.lblTextNoDui.TabIndex = 22;
            this.lblTextNoDui.Text = "Total:";
            // 
            // dtpFHRegistro
            // 
            this.dtpFHRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFHRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFHRegistro.Location = new System.Drawing.Point(121, 159);
            this.dtpFHRegistro.Name = "dtpFHRegistro";
            this.dtpFHRegistro.Size = new System.Drawing.Size(165, 26);
            this.dtpFHRegistro.TabIndex = 6;
            // 
            // valTotal
            // 
            this.valTotal.BackColor = System.Drawing.Color.Gray;
            this.valTotal.Location = new System.Drawing.Point(122, 240);
            this.valTotal.Name = "valTotal";
            this.valTotal.Size = new System.Drawing.Size(166, 2);
            this.valTotal.TabIndex = 21;
            // 
            // valFecha
            // 
            this.valFecha.BackColor = System.Drawing.Color.Gray;
            this.valFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valFecha.Location = new System.Drawing.Point(120, 186);
            this.valFecha.Name = "valFecha";
            this.valFecha.Size = new System.Drawing.Size(167, 2);
            this.valFecha.TabIndex = 24;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtTotal.Location = new System.Drawing.Point(124, 218);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(162, 19);
            this.txtTotal.TabIndex = 3;
            this.txtTotal.Leave += new System.EventHandler(this.txtTotal_Leave);
            // 
            // lblTextFechaNac
            // 
            this.lblTextFechaNac.AutoSize = true;
            this.lblTextFechaNac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextFechaNac.Location = new System.Drawing.Point(32, 159);
            this.lblTextFechaNac.Name = "lblTextFechaNac";
            this.lblTextFechaNac.Size = new System.Drawing.Size(58, 20);
            this.lblTextFechaNac.TabIndex = 25;
            this.lblTextFechaNac.Text = "Fecha:";
            // 
            // lblTextNombre
            // 
            this.lblTextNombre.AutoSize = true;
            this.lblTextNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextNombre.Location = new System.Drawing.Point(31, 101);
            this.lblTextNombre.Name = "lblTextNombre";
            this.lblTextNombre.Size = new System.Drawing.Size(82, 20);
            this.lblTextNombre.TabIndex = 19;
            this.lblTextNombre.Text = "Concepto:";
            // 
            // valNombre
            // 
            this.valNombre.BackColor = System.Drawing.Color.Gray;
            this.valNombre.Location = new System.Drawing.Point(124, 123);
            this.valNombre.Name = "valNombre";
            this.valNombre.Size = new System.Drawing.Size(166, 2);
            this.valNombre.TabIndex = 18;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtNombre.Location = new System.Drawing.Point(126, 101);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(162, 19);
            this.txtNombre.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(120, 316);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(81, 32);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // errTotal
            // 
            this.errTotal.ContainerControl = this;
            // 
            // errTipo
            // 
            this.errTipo.ContainerControl = this;
            // 
            // errConcepto
            // 
            this.errConcepto.ContainerControl = this;
            // 
            // errFecha
            // 
            this.errFecha.ContainerControl = this;
            // 
            // errNombre
            // 
            this.errNombre.ContainerControl = this;
            // 
            // FrmEgreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 360);
            this.Controls.Add(this.lblTextNoNit);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.valTipo);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblTextNoDui);
            this.Controls.Add(this.pblTitulo);
            this.Controls.Add(this.dtpFHRegistro);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblTextFechaNac);
            this.Controls.Add(this.valNombre);
            this.Controls.Add(this.valTotal);
            this.Controls.Add(this.lblTextNombre);
            this.Controls.Add(this.valFecha);
            this.Controls.Add(this.txtTotal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEgreso";
            this.Text = "Nuevo Egreso";
            this.Load += new System.EventHandler(this.FrmEgreso_Load);
            this.pblTitulo.ResumeLayout(false);
            this.pblTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errConcepto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNombre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pblTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox picLogoForm;
        private System.Windows.Forms.Label lblTextNoNit;
        private System.Windows.Forms.Panel valTipo;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Label lblTextNoDui;
        private System.Windows.Forms.DateTimePicker dtpFHRegistro;
        private System.Windows.Forms.Label lblTextFechaNac;
        private System.Windows.Forms.Panel valTotal;
        private System.Windows.Forms.Panel valFecha;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblTextNombre;
        private System.Windows.Forms.Panel valNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider errTotal;
        private System.Windows.Forms.ErrorProvider errTipo;
        private System.Windows.Forms.ErrorProvider errConcepto;
        private System.Windows.Forms.ErrorProvider errFecha;
        private System.Windows.Forms.ErrorProvider errNombre;
    }
}