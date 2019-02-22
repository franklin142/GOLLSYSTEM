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
    public partial class ControlEgresos : Form
    {
        public ControlEgresos()
        {
            InitializeComponent();
        }

        private void ControlEgresos_Load(object sender, EventArgs e)
        {
            dgvEgresos.Rows.Add(0,"03-02-2019","Consumibles", "Pago de gasolina", "20.30");
            dgvEgresos.Rows.Add(0, "01-02-2019", "Planilla", "Pago de empleados", "400");
            dgvEgresos.Rows.Add(0, "04-02-2019", "Consumibles", "3 resmas de papel bond tamaño carta", "11.50");
            dgvEgresos.Rows.Add(0, "02-02-2019", "Consumibles", "Pago de factura de energia electrica", "25.30");
        }
    }
}
