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
    public partial class FrmLibro : Form
    {
        public Libro CurrentObject;
        public Libro EditingObject;
        public Libro NewObject;

        public FrmLibro()
        {
            InitializeComponent();
        }

        private void FrmLibro_Load(object sender, EventArgs e)
        {
            try
            {
                numActividades.Value = 8;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (val_NewObject())
            {
                try
                {
                    NewObject = new Libro(0,
                   "",
                   txtNombre.Text,
                   txtEdicion.Text,
                   (int)numActividades.Value,
                   (int)numNivel.Value);

                    if (LibroDAL.InsertLibro(NewObject, Inicio.CurrentUser))
                    {
                        MessageBox.Show("El Libro ha sido registrado exitosamente.", "Registro satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EditingObject = null;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error inesperado al intentar registrar el libro, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.", "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    string fileName = "Exeptions_" + Name + ".txt";
                    Validation.FormManager frmManager = new Validation.FormManager();
                    frmManager.writeException(folderName, fileName, ex, "Ocurrio un error inesperado al intentar registrar el libro");
                    MessageBox.Show("Ocurrio un error inesperado al intentar registrar el libro, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Hay algunos campos que necesitan ser verificados antes de poder guardar, por favor revise todos los campos antes de continuar.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool val_NewObject()
        {
            bool result = true;
            if (!Validation.Validation.Val_StringsLength(txtNombre.Text, 5))
            {
                errNombre.SetError(txtNombre, "El nombre ingresado debe tener al menos 5 caracteres.");
                valNombre.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errEdicion.Clear();
                valEdicion.BackColor = Color.FromArgb(0, 100, 182);
            }
            if (!Validation.Validation.Val_StringsLength(txtEdicion.Text, 1))
            {
                errEdicion.SetError(txtEdicion, "La edicion del libro es obligatoria para poder registrarlo.");
                valEdicion.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errNombre.Clear();
                valNombre.BackColor = Color.FromArgb(0, 100, 182);
            }
            return result;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void FrmLibro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (EditingObject != null)
            {
                if (MessageBox.Show("¿Seguro que desea salir? hay cambios sin guardar que se perderan.", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
