using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GOLLSYSTEM.Skin;
using GOLLSYSTEM.DataAccess;
using GOLLSYSTEM.EntityLayer;
using System.Diagnostics;
using System.Reflection;

namespace GOLLSYSTEM
{
    public partial class Login : Form
    {
        public static Inicio inicio;
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            if (UserempDAL.testConexion())
            {
                if (!UserempDAL.verificarUseremp())
                {
                    Forms.frmWelcome welcome = new Forms.frmWelcome();
                    welcome.ShowDialog();
                }
                else
                {
                    txtLogin.Text = Properties.Settings.Default.LastUser;
                }
            }
            else
            {
                Configuraciones.Configuraciones configs = new Configuraciones.Configuraciones();
                configs.currentForm = new Configuraciones.DataBase();
                configs.ShowDialog();
            }
        }
        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            MoveForm.moverForm(this.Handle, this);
        }
        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            getLogin();
        }
        private void getLogin()
        {
            try
            {
                Useremp user = UserempDAL.getUseremp(txtLogin.Text, txtPass.Text);
                if (user != null)
                {
                    if (user.Estado == "A")
                    {


                        Inicio inicio = new Inicio();
                        Inicio.CurrentUser = UserempDAL.getUseremp(txtLogin.Text, txtPass.Text);
                        Inicio.CurrentSucursal = Inicio.CurrentUser.Sucursales.Where(a => a.IdSucursal == Properties.Settings.Default.Sucursal).FirstOrDefault().Sucursal;
                        Inicio.CurrentYear = YearDAL.getCurrentYear();
                        Inicio.CurrentYear = YearDAL.getCurrentYear();
                        Properties.Settings.Default.LastUser = txtLogin.Text;
                        Properties.Settings.Default.Save();

                        inicio.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Su cuenta de usuario ha expirado o se encuentra desactivada, si desea acceder al sistema comuniquese con el administrador para reactivar su cuenta de usuario. Sentimos el inconveniente", "Usuario Inhabilitado", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("El usuario o la contraseña es incorrecto", "Datos de usuario incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    picLook.Visible = true;
                    picLook.Enabled = true;
                }
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
        private void picHelp_MouseHover(object sender, EventArgs e)
        {
            picHelp.Size = new Size(28, 28);
        }
        private void picHelp_MouseLeave(object sender, EventArgs e)
        {
            picHelp.Size = new Size(25, 25);
        }
        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
        private void linkConexiones_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Configuraciones.Configuraciones configs = new Configuraciones.Configuraciones();
            configs.currentForm = new Configuraciones.DataBase();
            configs.ShowDialog();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Application.Exit();
                    break;
                case Keys.Enter:

                    if (txtLogin.Text.Length == 0)
                    {
                        txtLogin.Focus();
                    }
                    else
                    {
                        txtPass.Focus();
                        if (txtPass.Text.Length != 0)
                        {
                            getLogin();
                        }
                    }
                    break;
                default:
                    break;

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;

            }
        }

        private void picLook_Click(object sender, EventArgs e)
        {
            
            string text = txtPass.Text;
            if (txtPass.UseSystemPasswordChar)
            {
                txtPass.UseSystemPasswordChar = false;
                txtPass.Text= text;
                picLook.Image = Properties.Resources.ocultar_black;

            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
                txtPass.Text = text;
                picLook.Image = Properties.Resources.ojo;

            }
        }
    }
}
