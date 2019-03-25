using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GOLLSYSTEM.EntityLayer;
using GOLLSYSTEM.DataAccess;
using System.Reflection;

namespace GOLLSYSTEM.Forms
{
    public partial class frmPersona : Form
    {
        public Persona EditingObject;
        public Persona NewObject;

        public frmPersona()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Val_NewObject())
                {
                    if (PersonaDAL.insertPersona(NewObject, Inicio.CurrentUser))
                    {
                        MessageBox.Show("El cliente ha sido registrado exitosamente.", "Registro satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EditingObject = null;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error inesperado al intentar registrar el cliente, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.", "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";
                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ocurrio un error inesperado al intentar registrar el cliente");
                MessageBox.Show("Ocurrio un error inesperado al intentar registrar el cliente, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool Val_NewObject()
        {
            bool result = true;
            NewObject = new Persona();
            if (!Validation.Validation.Val_StringsLength(txtNombre.Text, 5))
            {
                errNombre.SetError(txtNombre, "El nombre del cliente esta vacio, este valor es obligatorio.");
                valNombre.BackColor = Color.Red;
                result = false;
            }
            else
            {
                valNombre.BackColor = Color.FromArgb(0, 100, 182);
                errNombre.Clear();

                if (!Validation.Validation.Val_NameFormat(txtNombre.Text))
                {
                    errNombre.SetError(txtNombre, "El nombre del cliente no tiene el formato correcto, \npor favor digite al menos un nombre y un apellido.");
                    valNombre.BackColor = Color.Red;
                    result = false;
                }
                else
                {
                    valNombre.BackColor = Color.FromArgb(0, 100, 182);
                    errNombre.Clear();

                    NewObject.Nombre = txtNombre.Text;


                }

            }
                return result;
        }

        private void frmPersona_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
