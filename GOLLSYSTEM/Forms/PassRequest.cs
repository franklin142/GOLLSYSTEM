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
    public partial class PassRequest : Form
    {
        public string usuario = "";
        public PassRequest()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (UserempDAL.getUseremp(usuario, txtPass.Text) != null)
            {
                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                MessageBox.Show("Clave incorrecta","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void PassRequest_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void PassRequest_Load(object sender, EventArgs e)
        {
            lblinstruccion.Text = "Escriba la clave de " + usuario + ".";
        }
    }
}
