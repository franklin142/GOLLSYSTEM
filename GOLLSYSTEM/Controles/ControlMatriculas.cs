using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GOLLSYSTEM.Forms;
using GOLLSYSTEM.EntityLayer;
using GOLLSYSTEM.DataAccess;
using System.Reflection;

namespace GOLLSYSTEM.Controles
{
    public partial class ControlMatriculas : Form
    {
        public ControlMatriculas()
        {
            InitializeComponent();
        }

        private void ControlMatriculas_Load(object sender, EventArgs e)
        {
            try
            {
                cbxYear.Enabled = false;
                cbxYear.DataSource = YearDAL.getYears(500);
                cbxYear.ValueMember = "Id";
                cbxYear.DisplayMember = "Desde";
                cbxYear.Enabled = true;

                cbxCursos.Enabled = false;
                cbxCursos.DataSource = CursoDAL.getCursosByIdSucursal(Inicio.CurrentSucursal.Id, cbxYear.SelectedItem as Year);
                cbxCursos.ValueMember = "Id";
                cbxCursos.DisplayMember = "Nombre";
                cbxCursos.Enabled = true;
                tmrTaskDgv.Start();
            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex,"Ha ocurrido un error al intentar cargar la información de este control");
                MessageBox.Show("Ha ocurrido un error al intentar cargar la información de este control, por favor comuniquese con el desarrollador al correo franklingranados2@yahoo.com", "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxYear.Enabled)
            {
                cbxCursos.Enabled = false;
                cbxCursos.DataSource = CursoDAL.getCursosByIdSucursal(Inicio.CurrentSucursal.Id, cbxYear.SelectedItem as Year);
                cbxCursos.ValueMember = "Id";
                cbxCursos.DisplayMember = "Nombre";
                cbxCursos.Enabled = true;
                FillDgv(rdbParametros.Checked ? MatriculaDAL.searchMatriculasParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentYear.Id, cbxCursos.Items.Count == 0 ? 0 : (cbxCursos.SelectedItem as Curso).Id) : MatriculaDAL.searchMatriculasNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, 100));

            }
        }

        private void cbxCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCursos.Enabled)
            {
                FillDgv(rdbParametros.Checked ? MatriculaDAL.searchMatriculasParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentYear.Id, cbxCursos.Items.Count == 0 ? 0 : (cbxCursos.SelectedItem as Curso).Id) : MatriculaDAL.searchMatriculasNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, 100));
            }
        }
        private void FillDgv(List<Matricula> lista)
        {
            dgvMatriculas.Rows.Clear();
            DateTime serverDate = YearDAL.getServerDate();
            foreach (Matricula obj in lista)
            {
                String aldia = "Si";
                string proxima = "";
                string pendientes = "";
                List<Cuota> cuotas = obj.Cuotas.Where(a => Convert.ToDateTime(a.FhRegistro).Month <= serverDate.Month).ToList();
                List<Cuota> cuotaspendientes = obj.Cuotas.Where(a => Convert.ToDateTime(a.FhRegistro).Month <= serverDate.Month && a.Total < a.Precio).ToList();

                for (int i = 0; i < cuotas.Count; i++)
                {

                    if (aldia == "Si" && cuotas[i].Total < cuotas[i].Precio)
                    {
                        aldia = "No";
                    }
                    if (1 + i == cuotas.Count)
                    {
                        if (cuotas[i].Total == cuotas[i].Precio)
                        {
                            proxima = obj.DiaLimite + " de " + Convert.ToDateTime(cuotas[i].FhRegistro).AddMonths(1).ToString("MMMM") + " de " + Convert.ToDateTime(cuotas[i].FhRegistro).AddMonths(1).ToString("yyyy");
                        }
                        else
                        {
                            proxima = obj.DiaLimite + " de " + Convert.ToDateTime(cuotas[i].FhRegistro).ToString("MMMM") + " de " + Convert.ToDateTime(cuotas[i].FhRegistro).AddMonths(1).ToString("yyyy");

                        }
                        if (obj.Cuotas.Count == cuotas.Count&& cuotas[i].Total == cuotas[i].Precio)
                        {
                            proxima = "";
                        }
                    }
                }
                for (int i = 0; i < cuotaspendientes.Count; i++)
                {
                    pendientes += ""+Convert.ToDateTime(cuotaspendientes[i].FhRegistro).ToString("MMMM") + " ($" + Decimal.Round(cuotaspendientes[i].Precio - cuotaspendientes[i].Total, 2)+") ";
                }
                if (obj.Estado=="D")
                {
                    pendientes = "Desertado";
                    proxima = "Desertado";
                }
                dgvMatriculas.Rows.Add(
                obj.Id,
                obj.Estudiante.Persona.Nombre,
                obj.Estudiante.Telefono,
                aldia,
                pendientes,
                proxima
                );
            }
        }

        private void icUpdate_Click(object sender, EventArgs e)
        {
            FillDgv(rdbParametros.Checked ? MatriculaDAL.searchMatriculasParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentYear.Id, cbxCursos.Items.Count == 0 ? 0 : (cbxCursos.SelectedItem as Curso).Id) : MatriculaDAL.searchMatriculasNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, 100));
        }

        private void btnNuevaMatricula_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ha ocurrido un error al intentar cargar la información de cursos de este control");
                MessageBox.Show("Ha ocurrido un error al intentar cargar la información cursos de este control, por favor comuniquese con el desarrollador al correo franklingranados2@yahoo.com", "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            List<Curso> cursos = CursoDAL.getCursosByIdSucursal(Inicio.CurrentSucursal.Id,Inicio.CurrentYear);
            if (cursos.Count>0)
            {
                FrmMatricula frmmatricula = new FrmMatricula();
                frmmatricula.opc = "newObject";
                frmmatricula.ShowDialog();
                FillDgv(rdbParametros.Checked ? MatriculaDAL.searchMatriculasParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentYear.Id, cbxCursos.Items.Count == 0 ? 0 : (cbxCursos.SelectedItem as Curso).Id) : MatriculaDAL.searchMatriculasNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, 100));

            }
            else
            {
                MessageBox.Show("No hay cursos registrados en el año seleccionado, para matricular estudiantes primero debe registrar un curso.", "Alerta de validación", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnEditarMatricula_Click(object sender, EventArgs e)
        {
            if (dgvMatriculas.CurrentRow != null)
            {
                FrmMatricula frmmatricula = new FrmMatricula();
                frmmatricula.opc = "updObject";
                frmmatricula.CurrentObject = MatriculaDAL.getMatriculaById((Int64)dgvMatriculas.CurrentRow.Cells[0].Value);
                frmmatricula.EditingObject = MatriculaDAL.getMatriculaById((Int64)dgvMatriculas.CurrentRow.Cells[0].Value);
                frmmatricula.ShowDialog();
                FillDgv(rdbParametros.Checked ? MatriculaDAL.searchMatriculasParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentYear.Id, cbxCursos.Items.Count == 0 ? 0 : (cbxCursos.SelectedItem as Curso).Id) : MatriculaDAL.searchMatriculasNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, 100));
            }
        }

        private void dgvMatriculas_DoubleClick(object sender, EventArgs e)
        {
            if (dgvMatriculas.CurrentRow != null)
            {
                FrmMatricula frmmatricula = new FrmMatricula();
                frmmatricula.opc = "updObject";
                frmmatricula.CurrentObject = MatriculaDAL.getMatriculaById((Int64)dgvMatriculas.CurrentRow.Cells[0].Value);
                frmmatricula.EditingObject = MatriculaDAL.getMatriculaById((Int64)dgvMatriculas.CurrentRow.Cells[0].Value);
                frmmatricula.ShowDialog();
                FillDgv(rdbParametros.Checked ? MatriculaDAL.searchMatriculasParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentYear.Id, cbxCursos.Items.Count == 0 ? 0 : (cbxCursos.SelectedItem as Curso).Id) : MatriculaDAL.searchMatriculasNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, 100));
            }
        }

        private void btnDesertarAlumno_Click(object sender, EventArgs e)
        {
            if (dgvMatriculas.CurrentRow!=null)
            {
                frmDesercion desersion = new frmDesercion();
                desersion.CurrentMatricula = MatriculaDAL.getMatriculaById((Int64)dgvMatriculas.CurrentRow.Cells[0].Value);
                desersion.ShowDialog();
                tmrTaskDgv.Start();

            }

        }

        private void tmrTaskDgv_Tick(object sender, EventArgs e)
        {
            FillDgv(rdbParametros.Checked ? MatriculaDAL.searchMatriculasParametro(Validation.Validation.Val_Injection(txtBuscar.Text), cbxYear.Items.Count == 0 ? 0 : (Int64)cbxYear.SelectedValue, cbxCursos.Items.Count == 0 ? 0 : (Int64)cbxCursos.SelectedValue) : MatriculaDAL.searchMatriculasNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, 100));
            tmrTaskDgv.Stop();
        }
    }
}
