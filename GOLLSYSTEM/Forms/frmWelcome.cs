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

namespace GOLLSYSTEM.Forms
{
    public partial class frmWelcome : Form
    {
        bool Exit = true;
        public frmWelcome()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmWelcome_Load(object sender, EventArgs e)
        {
            dtpFechaNac.MaxDate = DateTime.Now.AddYears(-18);
        }

        private void btnSiguiente1_Click(object sender, EventArgs e)
        {
            lblSucursal.BackColor = Color.LightSlateGray;

            pnlSteep1.Visible = false;
            pnlSteep2.Visible = true;
            pnlSteep3.Visible = false;
            pnlSteep4.Visible = false;

            pnlSteep1.Enabled = false;
            pnlSteep2.Enabled = true;
            pnlSteep3.Enabled = false;
            pnlSteep4.Enabled = false;

        }

        private void btnAtras2_Click(object sender, EventArgs e)
        {

            lblSucursal.BackColor = Color.SlateGray;

            pnlSteep1.Visible = true;
            pnlSteep2.Visible = false;
            pnlSteep3.Visible = false;
            pnlSteep4.Visible = false;

            pnlSteep1.Enabled = true;
            pnlSteep2.Enabled = false;
            pnlSteep3.Enabled = false;
            pnlSteep4.Enabled = false;
        }

        private void btnSiguiente2_Click(object sender, EventArgs e)
        {
            if (Val_Sucursal())
            {
                lblUsuarioAdministrador.BackColor = Color.LightSlateGray;
                pnlSteep1.Visible = false;
                pnlSteep2.Visible = false;
                pnlSteep3.Visible = true;
                pnlSteep4.Visible = false;

                pnlSteep1.Enabled = false;
                pnlSteep2.Enabled = false;
                pnlSteep3.Enabled = true;
                pnlSteep4.Enabled = false;
            }
        }

        private void btnAtras3_Click(object sender, EventArgs e)
        {
            lblUsuarioAdministrador.BackColor = Color.SlateGray;
            pnlSteep1.Visible = false;
            pnlSteep2.Visible = true;
            pnlSteep3.Visible = false;
            pnlSteep4.Visible = false;

            pnlSteep1.Enabled = false;
            pnlSteep2.Enabled = true;
            pnlSteep3.Enabled = false;
            pnlSteep4.Enabled = false;
        }

        private void btnSiguiente3_Click(object sender, EventArgs e)
        {
            if (Val_Usuario())
            {
                lblFinalizar.BackColor = Color.LightSlateGray;
                pnlSteep1.Visible = false;
                pnlSteep2.Visible = false;
                pnlSteep3.Visible = false;
                pnlSteep4.Visible = true;

                pnlSteep1.Enabled = false;
                pnlSteep2.Enabled = false;
                pnlSteep3.Enabled = false;
                pnlSteep4.Enabled = true;
            }
        }

        private void btnAtras4_Click(object sender, EventArgs e)
        {
            lblFinalizar.BackColor = Color.SlateGray;
            pnlSteep1.Visible = false;
            pnlSteep2.Visible = false;
            pnlSteep3.Visible = true;
            pnlSteep4.Visible = false;

            pnlSteep1.Enabled = false;
            pnlSteep2.Enabled = false;
            pnlSteep3.Enabled = true;
            pnlSteep4.Enabled = false;

        }

        private void txtNombreSucursal_Leave(object sender, EventArgs e)
        {

        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {

        }
        private bool Val_Sucursal()
        {
            bool result = true;
            if (!Validation.Validation.Val_StringsLength(txtNombreSucursal.Text, 5))
            {
                errNombreSucursal.SetError(txtNombreSucursal, "El nombre de la sucursal debe tener al menos 5 caracteres, \neste valor es obligatorio.");
                valNombreSucursal.BackColor = Color.Red;
                result = false;
            }
            else
            {
                valNombreSucursal.BackColor = Color.FromArgb(0, 100, 182);
                errNombreSucursal.Clear();
            }

            if (!Validation.Validation.Val_StringsLength(txtDireccionSucursal.Text, 20))
            {
                errDireccionSucursal.SetError(txtDireccionSucursal, "La direccion debe tener al menos 20 caracteres, \neste valor es obligatorio.");
                valDireccionSucursal.BackColor = Color.Red;
                result = false;
            }
            else
            {
                valDireccionSucursal.BackColor = Color.FromArgb(0, 100, 182);
                errDireccionSucursal.Clear();
            }
            return result;
        }
        private bool Val_Usuario()
        {
            bool result = true;
            if (!Validation.Validation.Val_NameFormat(txtNombre.Text))
            {
                errNombre.SetError(txtNombre, "El nombre ingresado no tiene el formato correcto.\nPor favor ingrese el nombre completo utilizando\n solo caracteres válidos del alfabeto.");
                valNombreUsuario.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errNombre.Clear();
                valNombreUsuario.BackColor = Color.FromArgb(0, 100, 182);
            }
            if (!Validation.Validation.Val_CellphoneFormat(txtTelefono.Text))
            {
                errTelefono.SetError(txtTelefono, "El telefono ingresado no tiene el formato correcto.\nPor favor ingrese un número telefónico válido en uno de\n los siguientes formatos: 22222222,+5037777777 o (+503)77777777.");
                valTelefono.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errTelefono.Clear();
                valTelefono.BackColor = Color.FromArgb(0, 100, 182);
            }
            if (!Validation.Validation.Val_DuiFormat(txtDui.Text))
            {
                errDui.SetError(txtDui, "El dui ingresado no tiene el formato correcto.\nPor favor ingrese un úumero de dui válido.\nEjemplo: 12345678-9");
                valDui.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errDui.Clear();
                valDui.BackColor = Color.FromArgb(0, 100, 182);
            }
            if (!Validation.Validation.Val_NitFormat(txtNit.Text))
            {
                errNit.SetError(txtNit, "El nit ingresado no tiene el formato correcto.\nPor favor ingrese un número de nit válido.\nEjemplo: 0000-000000-000-0");
                valNit.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errNit.Clear();
                valNit.BackColor = Color.FromArgb(0, 100, 182);
            }

            if (!Validation.Validation.Val_PasswordFormat(txtPass.Text)||txtPass.Text.Length<5)
            {
                errPass.SetError(txtPass, "La contraseña debe tener entre 5 y 30 caracteres\n contando numeros y letras mayusculas o minusculas.");
                valPass.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errPass.Clear();
                valPass.BackColor = Color.FromArgb(0, 100, 182);
                if (txtPass.Text != txtConfirmar.Text)
                {
                    errPass.SetError(txtPass, "Las contraseñas no coinciden.");
                    valPass.BackColor = Color.Red;
                    errConfirmar.SetError(txtConfirmar, "Las contraseñas no coinciden.");
                    valConfirmarPass.BackColor = Color.Red;
                    result = false;
                }
                else
                {
                    errPass.Clear();
                    valPass.BackColor = Color.FromArgb(0, 100, 182);
                    errConfirmar.Clear();
                    valConfirmarPass.BackColor = Color.FromArgb(0, 100, 182);
                }
            }
            
            return result;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
           
            try
            {
                Useremp usuario = new Useremp(0,
                  "Administrador",
                   txtPass.Text,
                  "Administrador",
                  "A",
                  0,
                  0,
                  new Contrato(
                      0,
                      "", DateTime.Now.ToString("yyyy/MM/dd"),
                      "",
                      "A",
                      1,
                      0,
                      new Cargo(
                          0,
                          "",
                          "Administración"
                          ),
                      new Empleado(
                          0,
                          "",
                          txtTelefono.Text,
                          "",
                          null,
                          0, new Persona(
                              0,
                              txtNombre.Text,
                              txtDui.Text,
                              txtNit.Text,
                              "",
                              dtpFechaNac.Value.ToString("yyyy/MM/dd")
                              ))
                      )
                 );

                if (UserempDAL.InsertUserEmpConf(usuario, new Sucursal(0,"",txtNombreSucursal.Text,txtDireccionSucursal.Text,null)))
                {
                    MessageBox.Show("¡Felicidades ya puede comenzar a utilizar el sistema! Las configuariones han sido guardadas exitosamente.", "Registro satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Exit = false;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error inesperado al intentar registrar las conficguraciones, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.", "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error inesperado al intentar registrar las configuraciones, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.\nInfo adicional:\n\n\n " + ex.ToString(), "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmWelcome_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmWelcome_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Exit)
            {
                Application.Exit();

            }
        }
    }
}
