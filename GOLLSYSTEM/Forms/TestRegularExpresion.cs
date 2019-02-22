using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GOLLSYSTEM.Validation;
namespace GOLLSYSTEM.Forms
{
    public partial class TestRegularExpresion : Form
    {
        public TestRegularExpresion()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (Validation.Validation.Val_NameFormat(txtTest.Text))
            {
                lblResult.Text = "Correcto";
                lblResult.ForeColor = Color.Green;

            }
            else
            {
                lblResult.ForeColor = Color.Red;
                lblResult.Text = "Error";
            }
        }
    }
}
