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

namespace GOLLSYSTEM
{
    public partial class Login : Form
    {
        public static Inicio inicio;
        public static ProcessStartInfo startInfo = new ProcessStartInfo("C:\\xampp\\mysql_start.bat");
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(startInfo);
            }
            catch (Exception)
            {

            }

            if (UserempDAL.testConexion())
            {
                if (!UserempDAL.verificarUseremp())
                {
                    Forms.frmWelcome welcome = new Forms.frmWelcome();
                    welcome.ShowDialog();
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
            if (UserempDAL.getUseremp(txtLogin.Text, txtPass.Text) != null)
            {
                Inicio inicio = new Inicio();
                Inicio.CurrentUser = UserempDAL.getUseremp(txtLogin.Text, txtPass.Text);
                Inicio.CurrentSucursal = SucursalDAL.getSucursaloById(Inicio.CurrentUser.IdSucursal);
                Inicio.CurrentYear = YearDAL.getCurrentYear();
                Inicio.CurrentYear = YearDAL.getCurrentYear();
                inicio.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("El usuario o la contraseña es incorrecto", "Datos de usuario incorrectos",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            foreach (Process proceso in Process.GetProcesses())
            {
                if (proceso.ProcessName == "Visual Studio 2015 Remote Debugger")
                {
                    proceso.Kill();
                }
            }
        }

        private void linkConexiones_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Configuraciones.Configuraciones configs = new Configuraciones.Configuraciones();
            configs.currentForm = new Configuraciones.DataBase();
            configs.ShowDialog();
        }
    }
}
