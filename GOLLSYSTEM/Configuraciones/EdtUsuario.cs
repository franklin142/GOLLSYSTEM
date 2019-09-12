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

namespace GOLLSYSTEM.Configuraciones
{
    public partial class EdtUsuario : Form
    {
        public Useremp user = Inicio.CurrentUser;
        public EdtUsuario()
        {
            InitializeComponent();
        }

        private void EdtUsuario_Load(object sender, EventArgs e)
        {
            txtEmpleado.Text = user.Contrato.Empleado.Persona.Nombre;
            txtLogin.Text = user.Login;
            txtRol.Text = "";
            checkActivo.Checked = user.Estado == "A";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Useremp NewObject = new Useremp(user.Id,null,txtPass.Text,null,0,new Contrato(),null);
                if (valUPDUsuario(NewObject))
                {
                    if (UserempDAL.UpdateUserEmp(NewObject,"pwd",Inicio.CurrentUser))
                    {
                        MessageBox.Show("Contraseña actualizada exitosamente.", "Actualizacion satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error inesperado al intentar actualizar la contraseña, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.", "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
        private bool valUPDUsuario(Useremp pUsuario)
        {
            bool result = true;

            if (result)
            {
                if (pUsuario.Pass != "")
                {

                    if (result)
                    {
                        if (txtPass.Text.Trim().ToUpper() != txtConfirmar.Text.Trim().ToUpper())
                        {
                            result = false;
                            MessageBox.Show("las contraseñas no coinsiden, por favor verifique los dos campos y vuelva a intentar.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    if (result)
                    {
                        if (txtPass.Text.Length < 5)
                        {
                            result = false;
                            MessageBox.Show("la contraseña es muy corta, por favor elija una contraseña con 5 caracteres o más.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("la contraseña esta vacia, por favor elija una contraseña con 5 caracteres o más.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }


            }

            return result;
        }

    }
}
