using GOLLSYSTEM.DataAccess;
using GOLLSYSTEM.EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOLLSYSTEM.Reports
{
    public partial class Viewer : Form
    {
        public bool ready = false;
        public string TituloReporte { get; set; }
        public string opcReporte = "";
        public Viewer()
        {
            InitializeComponent();
            BringToFront();

        }

        private void Viewer_Load(object sender, EventArgs e)
        {
            switch (opcReporte)
            {
                case "Morosos":

                    pnlMorosos.Enabled = true;
                    pnlMorosos.Visible = true;
                    cmbYear.Enabled = false;
                    cmbYear.DataSource = YearDAL.getYears(500);
                    cmbYear.ValueMember = "Id";
                    cmbYear.DisplayMember = "Desde";
                    cmbYear.Enabled = true;
                    List<Curso> cursos = CursoDAL.getCursosByIdSucursal(Inicio.CurrentSucursal.Id, cmbYear.SelectedItem as Year);

                    cmbCurso.Enabled = false;
                    cmbCurso.DataSource = cursos;
                    cmbCurso.ValueMember = "Id";
                    cmbCurso.DisplayMember = "Nombre";
                    cmbCurso.Enabled = true;
                    lblTitulo.Text = TituloReporte;
                    ready = true;
                    
                    break;
                default:
                    MessageBox.Show("El reporte solicitado no existe.","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    this.Close();
                    break;
            }
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            switch (opcReporte)
            {
                case "Morosos":
                    if (cmbYear.Items.Count == 0)
                        break;
                    if (cmbCurso.Items.Count == 0)
                        break;
                    Informes informes = new Informes();
                    informes.GenerarRepMorosos(VisorPDF, (cmbYear.SelectedItem as Year).Id, (cmbCurso.SelectedItem as Curso).Id);
                    
                    if (this.Width < 965)
                    {
                        this.Width = 965;
                        this.FormBorderStyle = FormBorderStyle.Sizable;
                        this.MinimumSize = new Size(965, 573);
                        this.MaximumSize = new Size(0, 0);
                        this.MaximizeBox = true;
                        VisorPDF.Size = new Size(655, 532);
                        VisorPDF.Location = new Point(294, 2);
                    }
                    break;
                default:
                    MessageBox.Show("El reporte solicitado no existe.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void cmbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ready && cmbCurso.Items.Count > 0)
            {
                Curso curso = CursoDAL.getCursoById((Int64)cmbCurso.SelectedValue);
                lblTeacher.Text = curso.Contrato.Empleado.Persona.Nombre;
                lblDuracion.Text = Convert.ToDateTime(curso.Desde).ToString("dd \"de\" MMMM", new CultureInfo("es-ES")) + " hasta el " + Convert.ToDateTime(curso.Hasta).ToString("dd \"de\" MMMM", new CultureInfo("es-ES"));
                flpHorario.Controls.Clear();
                foreach (Dia dia in curso.Horario)
                {
                    string horario = (dia.HEntrada + " a " + dia.HSalida);

                    flpHorario.Controls.Add(new Label()
                    {
                        Text = dia.Nombre + " " + horario,
                        AutoSize = true,
                        Name = "lbl" + dia.Nombre + curso.Id
                    });
                }
            }
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbYear.Enabled)
            {
                ready = false;
                cmbCurso.Enabled = false;
                cmbCurso.DataSource = CursoDAL.getCursosByIdSucursal(Inicio.CurrentSucursal.Id, cmbYear.SelectedItem as Year);
                cmbCurso.ValueMember = "Id";
                cmbCurso.DisplayMember = "Nombre";
                cmbCurso.Enabled = true;
                ready = true;
            }
            if (ready && cmbCurso.Items.Count > 0)
            {
                Curso curso = CursoDAL.getCursoById((Int64)cmbCurso.SelectedValue);
                lblTeacher.Text = curso.Contrato.Empleado.Persona.Nombre;
                lblDuracion.Text = Convert.ToDateTime(curso.Desde).ToString("dd \"de\" MMMM", new CultureInfo("es-ES")) + " hasta el " + Convert.ToDateTime(curso.Hasta).ToString("dd \"de\" MMMM", new CultureInfo("es-ES"));
                flpHorario.Controls.Clear();
                foreach (Dia dia in curso.Horario)
                {
                    string horario = (dia.HEntrada + " a " + dia.HSalida);

                    flpHorario.Controls.Add(new Label()
                    {
                        Text = dia.Nombre + " " + horario,
                        AutoSize = true,
                        Name = "lbl" + dia.Nombre + curso.Id
                    });
                }
            }
        }
    }
}
