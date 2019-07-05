namespace GOLLSYSTEM.Reports
{
    partial class Viewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Viewer));
            this.pnlContent = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlMorosos = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.valNota = new System.Windows.Forms.Panel();
            this.flpHorario = new System.Windows.Forms.FlowLayoutPanel();
            this.label22 = new System.Windows.Forms.Label();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblTeacher = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCurso = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlGenerarReporte = new System.Windows.Forms.Panel();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.VisorPDF = new AxAcroPDFLib.AxAcroPDF();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlContent.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlMorosos.SuspendLayout();
            this.pnlGenerarReporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlContent.Controls.Add(this.panel2);
            this.pnlContent.Controls.Add(this.pnlMorosos);
            this.pnlContent.Controls.Add(this.pnlGenerarReporte);
            this.pnlContent.Location = new System.Drawing.Point(18, 71);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.pnlContent.Size = new System.Drawing.Size(255, 441);
            this.pnlContent.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(243, 36);
            this.panel2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Parametros";
            // 
            // pnlMorosos
            // 
            this.pnlMorosos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMorosos.Controls.Add(this.panel6);
            this.pnlMorosos.Controls.Add(this.panel5);
            this.pnlMorosos.Controls.Add(this.valNota);
            this.pnlMorosos.Controls.Add(this.flpHorario);
            this.pnlMorosos.Controls.Add(this.label22);
            this.pnlMorosos.Controls.Add(this.lblDuracion);
            this.pnlMorosos.Controls.Add(this.label21);
            this.pnlMorosos.Controls.Add(this.lblTeacher);
            this.pnlMorosos.Controls.Add(this.label19);
            this.pnlMorosos.Controls.Add(this.cmbYear);
            this.pnlMorosos.Controls.Add(this.label7);
            this.pnlMorosos.Controls.Add(this.cmbCurso);
            this.pnlMorosos.Controls.Add(this.label4);
            this.pnlMorosos.Enabled = false;
            this.pnlMorosos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMorosos.Location = new System.Drawing.Point(6, 48);
            this.pnlMorosos.Name = "pnlMorosos";
            this.pnlMorosos.Size = new System.Drawing.Size(243, 343);
            this.pnlMorosos.TabIndex = 1;
            this.pnlMorosos.Visible = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel6.Location = new System.Drawing.Point(9, 63);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(229, 2);
            this.panel6.TabIndex = 63;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel5.Location = new System.Drawing.Point(8, 118);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(229, 2);
            this.panel5.TabIndex = 62;
            // 
            // valNota
            // 
            this.valNota.BackColor = System.Drawing.Color.LightSkyBlue;
            this.valNota.Location = new System.Drawing.Point(7, 174);
            this.valNota.Margin = new System.Windows.Forms.Padding(4);
            this.valNota.Name = "valNota";
            this.valNota.Size = new System.Drawing.Size(229, 2);
            this.valNota.TabIndex = 61;
            // 
            // flpHorario
            // 
            this.flpHorario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flpHorario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpHorario.Location = new System.Drawing.Point(61, 186);
            this.flpHorario.Name = "flpHorario";
            this.flpHorario.Size = new System.Drawing.Size(169, 141);
            this.flpHorario.TabIndex = 60;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 186);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 16);
            this.label22.TabIndex = 59;
            this.label22.Text = "Horario:";
            // 
            // lblDuracion
            // 
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(4, 154);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(11, 16);
            this.lblDuracion.TabIndex = 58;
            this.lblDuracion.Text = "|";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(5, 128);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 16);
            this.label21.TabIndex = 57;
            this.label21.Text = "Duración:";
            // 
            // lblTeacher
            // 
            this.lblTeacher.AutoSize = true;
            this.lblTeacher.Location = new System.Drawing.Point(6, 98);
            this.lblTeacher.Name = "lblTeacher";
            this.lblTeacher.Size = new System.Drawing.Size(11, 16);
            this.lblTeacher.TabIndex = 56;
            this.lblTeacher.Text = "|";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 75);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(62, 16);
            this.label19.TabIndex = 55;
            this.label19.Text = "Teacher:";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(61, 6);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(60, 24);
            this.cmbYear.TabIndex = 1;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Año:";
            // 
            // cmbCurso
            // 
            this.cmbCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurso.FormattingEnabled = true;
            this.cmbCurso.Location = new System.Drawing.Point(61, 35);
            this.cmbCurso.Name = "cmbCurso";
            this.cmbCurso.Size = new System.Drawing.Size(169, 24);
            this.cmbCurso.TabIndex = 2;
            this.cmbCurso.SelectedIndexChanged += new System.EventHandler(this.cmbCurso_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Curso:";
            // 
            // pnlGenerarReporte
            // 
            this.pnlGenerarReporte.Controls.Add(this.btnGenerarReporte);
            this.pnlGenerarReporte.Location = new System.Drawing.Point(6, 397);
            this.pnlGenerarReporte.Name = "pnlGenerarReporte";
            this.pnlGenerarReporte.Size = new System.Drawing.Size(243, 34);
            this.pnlGenerarReporte.TabIndex = 5;
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGenerarReporte.Location = new System.Drawing.Point(0, 0);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(124, 28);
            this.btnGenerarReporte.TabIndex = 4;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = false;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // VisorPDF
            // 
            this.VisorPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VisorPDF.Enabled = true;
            this.VisorPDF.Location = new System.Drawing.Point(293, 2);
            this.VisorPDF.Name = "VisorPDF";
            this.VisorPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VisorPDF.OcxState")));
            this.VisorPDF.Size = new System.Drawing.Size(330, 280);
            this.VisorPDF.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 100);
            this.panel1.TabIndex = 11;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Britannic Bold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 24);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(290, 30);
            this.lblTitulo.TabIndex = 10;
            this.lblTitulo.Text = "Titulo reporte";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(292, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 549);
            this.panel3.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(290, -1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 18);
            this.panel4.TabIndex = 13;
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(290, 534);
            this.Controls.Add(this.VisorPDF);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(306, 573);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(306, 573);
            this.Name = "Viewer";
            this.Text = "Informe";
            this.Load += new System.EventHandler(this.Viewer_Load);
            this.pnlContent.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlMorosos.ResumeLayout(false);
            this.pnlMorosos.PerformLayout();
            this.pnlGenerarReporte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VisorPDF)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlContent;
        private System.Windows.Forms.Panel pnlMorosos;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbCurso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGenerarReporte;
        private AxAcroPDFLib.AxAcroPDF VisorPDF;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlGenerarReporte;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpHorario;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblTeacher;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel valNota;
    }
}