namespace GOLLSYSTEM.Forms
{
    partial class FrmLibro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLibro));
            this.errNombre = new System.Windows.Forms.ErrorProvider(this.components);
            this.errCantidad = new System.Windows.Forms.ErrorProvider(this.components);
            this.errNivel = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.errEdicion = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblTextEdicion = new System.Windows.Forms.Label();
            this.valEdicion = new System.Windows.Forms.Panel();
            this.txtEdicion = new System.Windows.Forms.TextBox();
            this.lblTextNivel = new System.Windows.Forms.Label();
            this.valNivel = new System.Windows.Forms.Panel();
            this.valActividades = new System.Windows.Forms.Panel();
            this.lblTextNombre = new System.Windows.Forms.Label();
            this.valNombre = new System.Windows.Forms.Panel();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.pblTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picLogoForm = new System.Windows.Forms.PictureBox();
            this.lblTextNoDui = new System.Windows.Forms.Label();
            this.gbxInformacion = new System.Windows.Forms.GroupBox();
            this.numActividades = new System.Windows.Forms.NumericUpDown();
            this.numNivel = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.errNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNivel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errEdicion)).BeginInit();
            this.pblTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoForm)).BeginInit();
            this.gbxInformacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numActividades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNivel)).BeginInit();
            this.SuspendLayout();
            // 
            // errNombre
            // 
            this.errNombre.ContainerControl = this;
            this.errNombre.Icon = ((System.Drawing.Icon)(resources.GetObject("errNombre.Icon")));
            // 
            // errCantidad
            // 
            this.errCantidad.ContainerControl = this;
            this.errCantidad.Icon = ((System.Drawing.Icon)(resources.GetObject("errCantidad.Icon")));
            // 
            // errNivel
            // 
            this.errNivel.ContainerControl = this;
            this.errNivel.Icon = ((System.Drawing.Icon)(resources.GetObject("errNivel.Icon")));
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancelar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(290, 341);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(81, 32);
            this.btnCancelar.TabIndex = 28;
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
            this.btnGuardar.Location = new System.Drawing.Point(385, 341);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(81, 32);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // errEdicion
            // 
            this.errEdicion.ContainerControl = this;
            this.errEdicion.Icon = ((System.Drawing.Icon)(resources.GetObject("errEdicion.Icon")));
            // 
            // lblTextEdicion
            // 
            this.lblTextEdicion.AutoSize = true;
            this.lblTextEdicion.Location = new System.Drawing.Point(23, 166);
            this.lblTextEdicion.Name = "lblTextEdicion";
            this.lblTextEdicion.Size = new System.Drawing.Size(53, 16);
            this.lblTextEdicion.TabIndex = 32;
            this.lblTextEdicion.Text = "Edicion";
            // 
            // valEdicion
            // 
            this.valEdicion.BackColor = System.Drawing.Color.Gray;
            this.valEdicion.Location = new System.Drawing.Point(85, 184);
            this.valEdicion.Name = "valEdicion";
            this.valEdicion.Size = new System.Drawing.Size(111, 2);
            this.valEdicion.TabIndex = 31;
            // 
            // txtEdicion
            // 
            this.txtEdicion.BackColor = System.Drawing.SystemColors.Control;
            this.txtEdicion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdicion.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtEdicion.Location = new System.Drawing.Point(87, 162);
            this.txtEdicion.Name = "txtEdicion";
            this.txtEdicion.Size = new System.Drawing.Size(107, 20);
            this.txtEdicion.TabIndex = 30;
            // 
            // lblTextNivel
            // 
            this.lblTextNivel.AutoSize = true;
            this.lblTextNivel.Location = new System.Drawing.Point(322, 114);
            this.lblTextNivel.Name = "lblTextNivel";
            this.lblTextNivel.Size = new System.Drawing.Size(39, 16);
            this.lblTextNivel.TabIndex = 29;
            this.lblTextNivel.Text = "Nivel";
            // 
            // valNivel
            // 
            this.valNivel.BackColor = System.Drawing.Color.Gray;
            this.valNivel.Location = new System.Drawing.Point(375, 133);
            this.valNivel.Name = "valNivel";
            this.valNivel.Size = new System.Drawing.Size(55, 2);
            this.valNivel.TabIndex = 28;
            // 
            // valActividades
            // 
            this.valActividades.BackColor = System.Drawing.Color.Gray;
            this.valActividades.Location = new System.Drawing.Point(181, 133);
            this.valActividades.Name = "valActividades";
            this.valActividades.Size = new System.Drawing.Size(124, 2);
            this.valActividades.TabIndex = 21;
            // 
            // lblTextNombre
            // 
            this.lblTextNombre.AutoSize = true;
            this.lblTextNombre.Location = new System.Drawing.Point(23, 58);
            this.lblTextNombre.Name = "lblTextNombre";
            this.lblTextNombre.Size = new System.Drawing.Size(57, 16);
            this.lblTextNombre.TabIndex = 19;
            this.lblTextNombre.Text = "Nombre";
            // 
            // valNombre
            // 
            this.valNombre.BackColor = System.Drawing.Color.Gray;
            this.valNombre.Location = new System.Drawing.Point(87, 74);
            this.valNombre.Name = "valNombre";
            this.valNombre.Size = new System.Drawing.Size(343, 2);
            this.valNombre.TabIndex = 18;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtNombre.Location = new System.Drawing.Point(89, 52);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(339, 20);
            this.txtNombre.TabIndex = 17;
            // 
            // pblTitulo
            // 
            this.pblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.pblTitulo.Controls.Add(this.lblTitulo);
            this.pblTitulo.Controls.Add(this.picLogoForm);
            this.pblTitulo.Location = new System.Drawing.Point(-5, 0);
            this.pblTitulo.Name = "pblTitulo";
            this.pblTitulo.Size = new System.Drawing.Size(487, 88);
            this.pblTitulo.TabIndex = 4;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitulo.Location = new System.Drawing.Point(15, 23);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(298, 39);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Registro de Libros";
            // 
            // picLogoForm
            // 
            this.picLogoForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogoForm.Image = global::GOLLSYSTEM.Properties.Resources.goll_Logo_png;
            this.picLogoForm.Location = new System.Drawing.Point(363, -3);
            this.picLogoForm.Name = "picLogoForm";
            this.picLogoForm.Size = new System.Drawing.Size(109, 89);
            this.picLogoForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoForm.TabIndex = 0;
            this.picLogoForm.TabStop = false;
            // 
            // lblTextNoDui
            // 
            this.lblTextNoDui.AutoSize = true;
            this.lblTextNoDui.Location = new System.Drawing.Point(23, 114);
            this.lblTextNoDui.Name = "lblTextNoDui";
            this.lblTextNoDui.Size = new System.Drawing.Size(154, 16);
            this.lblTextNoDui.TabIndex = 22;
            this.lblTextNoDui.Text = "Cantidad de actividades";
            // 
            // gbxInformacion
            // 
            this.gbxInformacion.Controls.Add(this.numNivel);
            this.gbxInformacion.Controls.Add(this.numActividades);
            this.gbxInformacion.Controls.Add(this.lblTextEdicion);
            this.gbxInformacion.Controls.Add(this.valEdicion);
            this.gbxInformacion.Controls.Add(this.txtEdicion);
            this.gbxInformacion.Controls.Add(this.lblTextNivel);
            this.gbxInformacion.Controls.Add(this.valNivel);
            this.gbxInformacion.Controls.Add(this.lblTextNoDui);
            this.gbxInformacion.Controls.Add(this.valActividades);
            this.gbxInformacion.Controls.Add(this.lblTextNombre);
            this.gbxInformacion.Controls.Add(this.valNombre);
            this.gbxInformacion.Controls.Add(this.txtNombre);
            this.gbxInformacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxInformacion.Location = new System.Drawing.Point(10, 101);
            this.gbxInformacion.Name = "gbxInformacion";
            this.gbxInformacion.Size = new System.Drawing.Size(459, 229);
            this.gbxInformacion.TabIndex = 5;
            this.gbxInformacion.TabStop = false;
            this.gbxInformacion.Text = "Información General";
            // 
            // numActividades
            // 
            this.numActividades.Location = new System.Drawing.Point(184, 109);
            this.numActividades.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numActividades.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numActividades.Name = "numActividades";
            this.numActividades.Size = new System.Drawing.Size(120, 22);
            this.numActividades.TabIndex = 33;
            this.numActividades.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numNivel
            // 
            this.numNivel.Location = new System.Drawing.Point(374, 109);
            this.numNivel.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numNivel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNivel.Name = "numNivel";
            this.numNivel.Size = new System.Drawing.Size(54, 22);
            this.numNivel.TabIndex = 34;
            this.numNivel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FrmLibro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 385);
            this.Controls.Add(this.pblTitulo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gbxInformacion);
            this.Controls.Add(this.btnGuardar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLibro";
            this.Text = "Registro de Libro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLibro_FormClosing);
            this.Load += new System.EventHandler(this.FrmLibro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNivel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errEdicion)).EndInit();
            this.pblTitulo.ResumeLayout(false);
            this.pblTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoForm)).EndInit();
            this.gbxInformacion.ResumeLayout(false);
            this.gbxInformacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numActividades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNivel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errNombre;
        private System.Windows.Forms.Panel pblTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox picLogoForm;
        private System.Windows.Forms.GroupBox gbxInformacion;
        private System.Windows.Forms.NumericUpDown numActividades;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblTextEdicion;
        private System.Windows.Forms.Panel valEdicion;
        private System.Windows.Forms.TextBox txtEdicion;
        private System.Windows.Forms.Label lblTextNivel;
        private System.Windows.Forms.Panel valNivel;
        private System.Windows.Forms.Label lblTextNoDui;
        private System.Windows.Forms.Panel valActividades;
        private System.Windows.Forms.Label lblTextNombre;
        private System.Windows.Forms.Panel valNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ErrorProvider errCantidad;
        private System.Windows.Forms.ErrorProvider errNivel;
        private System.Windows.Forms.ErrorProvider errEdicion;
        private System.Windows.Forms.NumericUpDown numNivel;
    }
}