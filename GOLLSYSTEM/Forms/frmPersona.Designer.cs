namespace GOLLSYSTEM.Forms
{
    partial class frmPersona
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersona));
            this.pblTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picLogoForm = new System.Windows.Forms.PictureBox();
            this.valNombre = new System.Windows.Forms.Panel();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errNombre = new System.Windows.Forms.ErrorProvider(this.components);
            this.pblTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNombre)).BeginInit();
            this.SuspendLayout();
            // 
            // pblTitulo
            // 
            this.pblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.pblTitulo.Controls.Add(this.lblTitulo);
            this.pblTitulo.Controls.Add(this.picLogoForm);
            this.pblTitulo.Location = new System.Drawing.Point(0, 0);
            this.pblTitulo.Name = "pblTitulo";
            this.pblTitulo.Size = new System.Drawing.Size(463, 60);
            this.pblTitulo.TabIndex = 106;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitulo.Location = new System.Drawing.Point(17, 11);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(279, 37);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Registro de cliente";
            // 
            // picLogoForm
            // 
            this.picLogoForm.Image = global::GOLLSYSTEM.Properties.Resources.goll_Logo_png;
            this.picLogoForm.Location = new System.Drawing.Point(374, 6);
            this.picLogoForm.Name = "picLogoForm";
            this.picLogoForm.Size = new System.Drawing.Size(73, 54);
            this.picLogoForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoForm.TabIndex = 0;
            this.picLogoForm.TabStop = false;
            // 
            // valNombre
            // 
            this.valNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.valNombre.Location = new System.Drawing.Point(94, 123);
            this.valNombre.Name = "valNombre";
            this.valNombre.Size = new System.Drawing.Size(341, 2);
            this.valNombre.TabIndex = 109;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.txtNombre.Location = new System.Drawing.Point(94, 99);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(341, 24);
            this.txtNombre.TabIndex = 107;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Tai Le", 10F);
            this.lblBuscar.Location = new System.Drawing.Point(30, 102);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(58, 18);
            this.lblBuscar.TabIndex = 108;
            this.lblBuscar.Text = "Nombre";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(354, 140);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(81, 26);
            this.btnGuardar.TabIndex = 113;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(267, 140);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(81, 26);
            this.btnCancelar.TabIndex = 114;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // errNombre
            // 
            this.errNombre.ContainerControl = this;
            // 
            // frmPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 188);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.valNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.pblTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(476, 227);
            this.MinimumSize = new System.Drawing.Size(476, 227);
            this.Name = "frmPersona";
            this.Text = "frmPersona";
            this.Load += new System.EventHandler(this.frmPersona_Load);
            this.pblTitulo.ResumeLayout(false);
            this.pblTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNombre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pblTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox picLogoForm;
        private System.Windows.Forms.Panel valNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider errNombre;
    }
}