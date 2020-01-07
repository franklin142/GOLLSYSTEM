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
using System.Globalization;

namespace GOLLSYSTEM.Controles
{
    public partial class ControlMatriculas : Form
    {
        List<Curso> cursos = new List<Curso>();
        public ControlMatriculas()
        {
            InitializeComponent();
        }

        private void ControlMatriculas_Load(object sender, EventArgs e)
        {
            try
            {
                

                cbxYear.Enabled = false;
                cbxYear.DataSource = YearDAL.getYears(999999999);
                cbxYear.ValueMember = "Id";
                cbxYear.DisplayMember = "Desde";
                cbxYear.Enabled = true;

                cursos = CursoDAL.getCursosByIdSucursal(Inicio.CurrentSucursal.Id, cbxYear.SelectedItem as Year);
                cbxCursos.Enabled = false;
                cbxCursos.DataSource = cursos;
                cbxCursos.ValueMember = "Id";
                cbxCursos.DisplayMember = "Nombre";
                cbxCursos.Enabled = true;
                lblMatriculados.Text = "0";

                foreach (Curso curso in cursos)
                    lblMatriculados.Text = (Convert.ToInt32(lblMatriculados.Text) + MatriculaDAL.countMatriculasActivasByCurso(curso.Id)).ToString();
                foreach (LstPermiso obj in Inicio.CurrentUser.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Permisos)
                {
                    switch (obj.Permiso.Nombre)
                    {
                        case "Matricular Estudiantes":
                            if (obj.Otorgado)
                            {
                                btnNuevaMatricula.Enabled = true;
                            }
                            break;
                        case "Desertar Estudiantes":
                            if (obj.Otorgado)
                            {
                                btnDesertarAlumno.Enabled = true;
                            }
                            break;
                        default:
                            break;
                    }
                }
                tmrTaskDgv.Start();
            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ha ocurrido un error al intentar cargar la información de este control");
                MessageBox.Show("Ha ocurrido un error al intentar cargar la información de este control, por favor comuniquese con el desarrollador al correo franklingranados2@yahoo.com", "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxYear.Enabled)
            {
                cursos = CursoDAL.getCursosByIdSucursal(Inicio.CurrentSucursal.Id, cbxYear.SelectedItem as Year);
                cbxCursos.Enabled = false;
                cbxCursos.DataSource = cursos;
                cbxCursos.ValueMember = "Id";
                cbxCursos.DisplayMember = "Nombre";
                if (cursos.Count>0)
                {
                    cbxCursos.SelectedIndex = 0;
                }
                cbxCursos.Enabled = true;

                FillDgv(rdbParametros.Checked ? MatriculaDAL.searchMatriculasParametro(txtBuscar.Text, cursos.Count>0? (cbxYear.SelectedItem as Year).Id:0, cbxCursos.Items.Count == 0 ? 0 : (cbxCursos.SelectedItem as Curso).Id) : MatriculaDAL.searchMatriculasNoParametro(txtBuscar.Text, Inicio.CurrentSucursal.Id, 500));
                lblMatriculados.Text = "0";
                foreach (Curso curso in cursos)
                    lblMatriculados.Text = (Convert.ToInt32(lblMatriculados.Text) + MatriculaDAL.countMatriculasActivasByCurso(curso.Id)).ToString();

            }
        }

        private void cbxCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCursos.Enabled)
            {
                FillDgv(rdbParametros.Checked ? MatriculaDAL.searchMatriculasParametro(txtBuscar.Text, cursos.Count > 0 ? (cbxYear.SelectedItem as Year).Id : 0, cbxCursos.Items.Count == 0 ? 0 : (cbxCursos.SelectedItem as Curso).Id) : MatriculaDAL.searchMatriculasNoParametro(txtBuscar.Text, cursos.Count > 0 ? (cbxYear.SelectedItem as Year).Id : 0, 100));
            }
        }
        private void FillDgv(List<Matricula> lista)
        {
            dgvMatriculas.Rows.Clear();
            DateTime serverDate = YearDAL.getServerDate();
            int students = 1;
            foreach (Matricula obj in lista)
            {
                String aldia = "Si";
                string proxima = "";
                string pendientes = "";
                List<Cuota> atrasadas = obj.Cuotas.Where(a => (Convert.ToDateTime(a.FhRegistro) < serverDate || Convert.ToDateTime(a.FhRegistro) == serverDate) && a.Total < a.Precio).ToList();
                List<Cuota> proximas = obj.Cuotas.Where(a => Convert.ToDateTime(a.FhRegistro) > serverDate && a.Total < a.Precio).ToList();

                foreach (Cuota objCuota in atrasadas)
                {
                    pendientes += "(" + Convert.ToDateTime(objCuota.FhRegistro).ToString("MMMM", new CultureInfo("ES-es")) + " $" + Decimal.Round((objCuota.Precio - objCuota.Total), 2) + ") ";
                }
                aldia = atrasadas.Count > 0 ? "No" : "Si";
                DateTime dateProx = proximas.Count > 0 ? atrasadas.Where(a => Convert.ToDateTime(a.FhRegistro).Month == serverDate.Month).FirstOrDefault() != null ? Convert.ToDateTime(atrasadas.Where(a => Convert.ToDateTime(a.FhRegistro).Month == serverDate.Month).FirstOrDefault().FhRegistro) : Convert.ToDateTime((from cuota in proximas orderby Convert.ToDateTime(cuota.FhRegistro) ascending select cuota).FirstOrDefault().FhRegistro) : atrasadas.Count > 0 ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(obj.DiaLimite)) : new DateTime();
                proxima = proximas.Count > 0 || atrasadas.Count > 0 ? dateProx.ToString("dd \"de\" MMMM \"del\" yyyy", new CultureInfo("ES-es")) : "";

                dgvMatriculas.Rows.Add(
                obj.Id,
                students + "-" + obj.Estudiante.Persona.Nombre,
                obj.Estudiante.Telefono,
                aldia,
                pendientes,
                proxima
                );
                students++;
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
            List<Curso> cursos = CursoDAL.getCursosByIdSucursal(Inicio.CurrentSucursal.Id, Inicio.CurrentYear);
            if (cursos.Count > 0)
            {
                FrmMatricula frmmatricula = new FrmMatricula();
                frmmatricula.opc = "newObject";
                frmmatricula.ShowDialog();
                FillDgv(rdbParametros.Checked ? MatriculaDAL.searchMatriculasParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentYear.Id, cbxCursos.Items.Count == 0 ? 0 : (cbxCursos.SelectedItem as Curso).Id) : MatriculaDAL.searchMatriculasNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, 100));

            }
            else
            {
                MessageBox.Show("No hay cursos registrados en el año seleccionado, para matricular estudiantes primero debe registrar un curso.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (dgvMatriculas.CurrentRow != null)
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

        private void lknSync_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Esta seguro que desea sincronizar las cuotas para este curso seleccionado? Si lo hace se crearan o eliminaran cuotas a partir de la fecha de matricula de cada estudiante si llegase a faltar algun registro.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (cbxCursos.Items.Count > 0 && cbxYear.Items.Count > 0)
                    {
                        dgvMatriculas.Enabled = false;
                        Cursor = Cursors.WaitCursor;
                        if (CuotaDAL.syncCuotas((cbxCursos.SelectedItem as Curso).Id, Inicio.CurrentUser.Id))
                        {
                            MessageBox.Show("Las cuotas del curso seleccionado han sido sincronizadas exitosamente!!!.", "Operación realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillDgv(rdbParametros.Checked ? MatriculaDAL.searchMatriculasParametro(Validation.Validation.Val_Injection(txtBuscar.Text), cbxYear.Items.Count == 0 ? 0 : (Int64)cbxYear.SelectedValue, cbxCursos.Items.Count == 0 ? 0 : (Int64)cbxCursos.SelectedValue) : MatriculaDAL.searchMatriculasNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, 100));
                            tmrTaskDgv.Stop();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrrió un error inesperado al intentar sincronizar las cuotas del curso seleccionado.", "Operación erronea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        dgvMatriculas.Enabled = true;

                        Cursor = Cursors.Arrow;

                    }
                }
            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";
                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ocurrio un error inesperado al intentar registrar el egreso");
                MessageBox.Show("Ocurrio un error inesperado al intentar sincronizar las cuotas, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvMatriculas.Enabled = true;
                Cursor = Cursors.Arrow;
            }
        }

        private void btnVerMorosos_Click(object sender, EventArgs e)
        {

            Reports.Viewer viewer = new Reports.Viewer();
            viewer.TituloReporte = "Alumnos con mora";
            viewer.opcReporte = "Morosos";
            viewer.BringToFront();
            viewer.StartPosition = FormStartPosition.Manual;
            viewer.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblMatriculados_Click(object sender, EventArgs e)
        {

        }
    }
}
