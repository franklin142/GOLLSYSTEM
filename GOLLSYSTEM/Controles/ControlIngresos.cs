using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GOLLSYSTEM.Forms;
using GOLLSYSTEM.EntityLayer;
using GOLLSYSTEM.DataAccess;

namespace GOLLSYSTEM.Controles
{
    public partial class ControlIngresos : Form
    {
        public ControlIngresos()
        {
            InitializeComponent();
        }

        private void ControlIngresos_Load(object sender, EventArgs e)
        {
            dgvIngresos.Rows.Add(0,"asdasdasd","sadsasd");
            dgvIngresos.Rows.Add(0, "asdasdasd", "sadsasd");
            dgvIngresos.Rows.Add(0, "asdasdasd", "sadsasd");
            dgvIngresos.Rows.Add(0, "asdasdasd", "sadsasd");


        }
    }
}
