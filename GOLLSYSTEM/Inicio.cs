using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GOLLSYSTEM.EntityLayer;

namespace GOLLSYSTEM
{
    public partial class Inicio : Form
    {
        public Form CurrentForm;
        public static Useremp CurrentUser;
        public static Sucursal CurrentSucursal;
        public static Year CurrentYear;
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            OpenForm(new Controles.ControlMatriculas());
            selectOpc(opc1);
        }
        private void restoreMenuBar()
        {
            foreach (Control ctrl in flpMenu.Controls)
            {
                    ctrl.BackColor = Color.Transparent;
            }

        }
        private void selectOpc(Panel opc)
        {
            restoreMenuBar();
            opc.BackColor = Color.FromArgb(39, 57, 80);
        }
        public void OpenForm(Form pFormulario)
        {
            if (CurrentForm!=null)
            {
                CurrentForm.Dispose();
            }
            CurrentForm = pFormulario;
            pnlContent.Visible = false;
            if (this.pnlContent.Controls.Count > 0)
                this.pnlContent.Controls.RemoveAt(0);

            pFormulario.TopLevel = false;

            pFormulario.FormBorderStyle = FormBorderStyle.None;
            pFormulario.Dock = DockStyle.Fill;
            this.pnlContent.Controls.Add(pFormulario);
            this.pnlContent.Tag = pFormulario;

            pFormulario.Show();

            pnlContent.Visible = true;
        }

        private void Inicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblOpc1_Click(object sender, EventArgs e)
        {
            OpenForm(new Controles.ControlMatriculas());
            selectOpc(opc1);


        }

        private void lblOpc2_Click(object sender, EventArgs e)
        {
            OpenForm(new Controles.ControlEmpleados());
            selectOpc(opc2);
        }

        private void lblOpc4_Click(object sender, EventArgs e)
        {
            OpenForm(new Controles.ControlCursos());
            selectOpc(opc4);
        }

        private void lblOpc5_Click(object sender, EventArgs e)
        {
            OpenForm(new Controles.ControlIngresos());
            selectOpc(opc5);
        }

        private void lblOpc6_Click(object sender, EventArgs e)
        {
            OpenForm(new Controles.ControlEgresos());
            selectOpc(opc6);
        }

        private void tmrGcCollector_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }

        private void configuracionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuraciones.Configuraciones configs= new Configuraciones.Configuraciones();
            configs.user = Inicio.CurrentUser;
            configs.ShowDialog();
        }
    }
}
