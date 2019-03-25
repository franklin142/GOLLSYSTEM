using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GOLLSYSTEM.DataAccess;
using GOLLSYSTEM.EntityLayer;

namespace GOLLSYSTEM.Forms
{
    public partial class frmDesercion : Form
    {
        public Matricula CurrentMatricula;
        public Desersion CurrentObject;
        public Desersion EditingObject;
        public Desersion NewObject;

        public frmDesercion()
        {
            InitializeComponent();
        }

        private void frmDesercion_Load(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ha ocurrido un error al intentar cargar la información de este control");
                MessageBox.Show("Ha ocurrido un error al intentar cargar la información de este control, por favor comuniquese con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Val_NewObject()
        {
            bool result = true;
            NewObject = new Desersion();
            if (!Validation.Validation.Val_StringsLength(txtNota.Text, 1))
            {
                errNota.SetError(txtNota, "La descripcion de la dersesion esta vacia, este valor es obligatorio.");
                valNota.BackColor = Color.Red;
                result = false;
            }
            else
            {
                if (!Validation.Validation.Val_StringsLength(txtNota.Text, 20))
                {
                    errNota.SetError(txtNota, "La descripcion de la dersesion debe tener al menos 20 caracteres, este valor es obligatorio.");
                    valNota.BackColor = Color.Red;
                    result = false;
                }
                else
                {
                    valNota.BackColor = Color.FromArgb(0, 100, 182);
                    errNota.Clear();
                    NewObject.Nota = txtNota.Text;

                }

            }
            Curso curso = CursoDAL.getCursoById(CurrentMatricula.IdCurso);
            if (dtpFhRegistro.Value < Convert.ToDateTime(curso.FhRegistro))
            {
                errFhRegistro.SetError(dtpFhRegistro, "La fecha de la dersesion especificada debe ser mayor a la fecha de inicio del curso, este valor es obligatorio.");
                valFhRegistro.BackColor = Color.Red;
                result = false;
            }
            else
            {
                valFhRegistro.BackColor = Color.FromArgb(0, 100, 182);
                errFhRegistro.Clear();
                NewObject.Nota = txtNota.Text;

            }
            NewObject.IdMatricula = CurrentMatricula.Id;
            return result;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Val_NewObject())
                {
                    if (DesersionDAL.insertDesersion(NewObject, Inicio.CurrentUser))
                    {
                        MessageBox.Show("La desersión ha sido registrada exitosamente.", "Registro satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EditingObject = null;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error inesperado al intentar registrar la desersión, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.", "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";
                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ocurrio un error inesperado al intentar registrar la desersión");
                MessageBox.Show("Ocurrio un error inesperado al intentar registrar la desersión, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
