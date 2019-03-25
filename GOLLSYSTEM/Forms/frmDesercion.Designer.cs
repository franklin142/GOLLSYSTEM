namespace GOLLSYSTEM.Forms
{
    partial class frmDesercion
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
            this.lblTextDireccion = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.valNota = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pblTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picLogoForm = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFhRegistro = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.valFhRegistro = new System.Windows.Forms.Panel();
            this.errNota = new System.Windows.Forms.ErrorProvider(this.components);
            this.errFhRegistro = new System.Windows.Forms.ErrorProvider(this.components);
            this.pblTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errFhRegistro)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTextDireccion
            // 
            this.lblTextDireccion.AutoSize = true;
            this.lblTextDireccion.Location = new System.Drawing.Point(27, 184);
            this.lblTextDireccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTextDireccion.Name = "lblTextDireccion";
            this.lblTextDireccion.Size = new System.Drawing.Size(183, 16);
            this.lblTextDireccion.TabIndex = 42;
            this.lblTextDireccion.Text = "Razon o motivo de desersion";
            // 
            // txtNota
            // 
            this.txtNota.BackColor = System.Drawing.SystemColors.Control;
            this.txtNota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNota.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtNota.Location = new System.Drawing.Point(29, 204);
            this.txtNota.Margin = new System.Windows.Forms.Padding(4);
            this.txtNota.Multiline = true;
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(402, 83);
            this.txtNota.TabIndex = 41;
            // 
            // valNota
            // 
            this.valNota.BackColor = System.Drawing.Color.Gray;
            this.valNota.Location = new System.Drawing.Point(30, 286);
            this.valNota.Margin = new System.Windows.Forms.Padding(4);
            this.valNota.Name = "valNota";
            this.valNota.Size = new System.Drawing.Size(401, 3);
            this.valNota.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 117);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 44;
            this.label1.Text = "Estudiante";
            // 
            // pblTitulo
            // 
            this.pblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.pblTitulo.Controls.Add(this.lblTitulo);
            this.pblTitulo.Controls.Add(this.picLogoForm);
            this.pblTitulo.Location = new System.Drawing.Point(0, -2);
            this.pblTitulo.Name = "pblTitulo";
            this.pblTitulo.Size = new System.Drawing.Size(461, 100);
            this.pblTitulo.TabIndex = 45;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitulo.Location = new System.Drawing.Point(19, 21);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(241, 55);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Desersión";
            // 
            // picLogoForm
            // 
            this.picLogoForm.Image = global::GOLLSYSTEM.Properties.Resources.goll_Logo_png;
            this.picLogoForm.Location = new System.Drawing.Point(349, 5);
            this.picLogoForm.Name = "picLogoForm";
            this.picLogoForm.Size = new System.Drawing.Size(109, 87);
            this.picLogoForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoForm.TabIndex = 0;
            this.picLogoForm.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(106, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 46;
            this.label2.Text = "Estudiante";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(106, 149);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 48;
            this.label3.Text = "Estudiante";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 152);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 47;
            this.label4.Text = "Curso:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(277, 156);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 49;
            this.label6.Text = "Fecha:";
            // 
            // dtpFhRegistro
            // 
            this.dtpFhRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFhRegistro.Location = new System.Drawing.Point(333, 153);
            this.dtpFhRegistro.Name = "dtpFhRegistro";
            this.dtpFhRegistro.Size = new System.Drawing.Size(98, 22);
            this.dtpFhRegistro.TabIndex = 50;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancelar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(254, 298);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(81, 32);
            this.btnCancelar.TabIndex = 52;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnGuardar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(349, 298);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(81, 32);
            this.btnGuardar.TabIndex = 51;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // valFhRegistro
            // 
            this.valFhRegistro.BackColor = System.Drawing.Color.Gray;
            this.valFhRegistro.Location = new System.Drawing.Point(333, 175);
            this.valFhRegistro.Margin = new System.Windows.Forms.Padding(4);
            this.valFhRegistro.Name = "valFhRegistro";
            this.valFhRegistro.Size = new System.Drawing.Size(99, 2);
            this.valFhRegistro.TabIndex = 44;
            // 
            // errNota
            // 
            this.errNota.ContainerControl = this;
            // 
            // errFhRegistro
            // 
            this.errFhRegistro.ContainerControl = this;
            // 
            // frmDesercion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 342);
            this.Controls.Add(this.valFhRegistro);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dtpFhRegistro);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pblTitulo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.valNota);
            this.Controls.Add(this.lblTextDireccion);
            this.Controls.Add(this.txtNota);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(476, 381);
            this.MinimumSize = new System.Drawing.Size(476, 381);
            this.Name = "frmDesercion";
            this.Text = "frmDesercion";
            this.Load += new System.EventHandler(this.frmDesercion_Load);
            this.pblTitulo.ResumeLayout(false);
            this.pblTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errFhRegistro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTextDireccion;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Panel valNota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pblTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox picLogoForm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFhRegistro;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel valFhRegistro;
        private System.Windows.Forms.ErrorProvider errNota;
        private System.Windows.Forms.ErrorProvider errFhRegistro;
    }
}