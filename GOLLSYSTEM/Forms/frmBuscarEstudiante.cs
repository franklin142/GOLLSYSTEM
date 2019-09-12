using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GOLLSYSTEM.DataAccess;
using GOLLSYSTEM.EntityLayer;
using System.Reflection;

namespace GOLLSYSTEM.Forms
{
    public partial class frmBuscarEstudiante : Form
    {
        public Matricula currentObject;
        private string lastParam;
        public string opc = "matricula";
        public frmBuscarEstudiante()
        {
            InitializeComponent();
        }

        private void frmBuscarEstudiante_Load(object sender, EventArgs e)
        {
            try
            {
                FillDgv(MatriculaDAL.searchMatriculas(txtBuscar.Text, Inicio.CurrentSucursal.Id,25,opc));

            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ha ocurrido un error al intentar cargar la información de este control");
                MessageBox.Show("Ha ocurrido un error al intentar cargar la información de este control, por favor comuniquese con el desarrollador al correo "+Properties.Settings.Default.developerEmail, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void icUpdate_Click(object sender, EventArgs e)
        {
            FillDgv(MatriculaDAL.searchMatriculas(txtBuscar.Text, Inicio.CurrentSucursal.Id, 50,opc));
        }
        private void FillDgv(List<Matricula> lista)
        {
            dgvBuscar.Rows.Clear();
            List<Curso> cursos = new List<Curso>();
            foreach (Matricula obj in lista)
            {
                if (cursos.Where(a=>a.Id==obj.IdCurso).ToList().Count==0)
                {
                    cursos.Add(CursoDAL.getCursoById(obj.IdCurso));
                }
                dgvBuscar.Rows.Add(
                    obj.Id,
                    obj.Estudiante.Persona.Nombre,
                    cursos.Where(a => a.Id == obj.IdCurso).FirstOrDefault().Nombre +
                    " " + cursos.Where(a => a.Id == obj.IdCurso).FirstOrDefault().Contrato.Empleado.Persona.Nombre,
                    obj.Estudiante.Telefono
                    );
            }
            lblNoResults.Visible = dgvBuscar.RowCount == 0;
            lastParam = txtBuscar.Text;

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBuscar.CurrentRow != null)
                {
                    currentObject = MatriculaDAL.getMatriculaById((Int64)dgvBuscar.CurrentRow.Cells[0].Value);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ha ocurrido un error al intentar seleccionar la información de este control");
                MessageBox.Show("Ha ocurrido un error al intentar seleccionar la información de este control, por favor comuniquese con el desarrollador al correo "+Properties.Settings.Default.developerEmail, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Down:
                    dgvBuscar.Focus();
                    break;

                default:

                    if (char.IsLetterOrDigit((char)keyData))
                    {
                        if (!txtBuscar.Focused)
                        {
                            txtBuscar.Text = txtBuscar.Text += (char)keyData;
                            txtBuscar.Focus();
                            txtBuscar.SelectionStart = txtBuscar.Text.Length;

                        }
                    }
                    if (keyData.ToString().ToUpper() == "BACK")
                    {
                        if (!txtBuscar.Focused)
                        {
                            txtBuscar.Text = txtBuscar.Text.Substring(0, txtBuscar.Text.Length > 0 ? txtBuscar.Text.Length - 1 : 0);
                            txtBuscar.Focus();
                            txtBuscar.SelectionStart = txtBuscar.Text.Length;
                        }

                    }
                    break;

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                if (txtBuscar.Text != lastParam)
                {
                    FillDgv(MatriculaDAL.searchMatriculas(txtBuscar.Text, Inicio.CurrentSucursal.Id, 50,opc));
                }
                else
                {
                    btnSeleccionar.PerformClick();
                }
            }
        }

        private void dgvBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                btnSeleccionar.PerformClick();
            }
        }
    }
}
