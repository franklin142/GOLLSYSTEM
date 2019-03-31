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
using System.Reflection;
using GOLLSYSTEM.DataAccess;
using System.Globalization;

namespace GOLLSYSTEM
{
    public partial class Inicio : Form
    {
        public Form CurrentForm;
        public static Useremp CurrentUser;
        public static Sucursal CurrentSucursal;
        public static Year CurrentYear;
        public int processId;

        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            try
            {
                OpenForm(new Controles.ControlMatriculas());
                selectOpc(opc1);
                usuarioToolStripMenuItem.Text = Inicio.CurrentUser.Contrato.Empleado.Persona.Nombre;
                usuarioToolStripMenuItem.Text = Inicio.CurrentUser.Rol;
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
            if (CurrentForm != null)
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
            Configuraciones.Configuraciones configs = new Configuraciones.Configuraciones();
            configs.user = Inicio.CurrentUser;
            configs.ShowDialog();
        }

        private void exportarEgresosIngresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                DateTime date = YearDAL.getServerDate();
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Contabilidad_" + Convert.ToInt32(date.ToString("yyyy")) + "_Goll";
                string fileName = date.ToString("yyyy") + "_" + date.ToString("MMMM", new CultureInfo("es-ES")) + ".xlsx";

                Validation.FormManager frmManager = new Validation.FormManager();
                if (frmManager.generateExcel(FacturaDAL.getFacturasSemanas(Convert.ToInt64(date.ToString("yyyy")), date.ToString("MM"), Validation.Validation.Val_Injection(""), Inicio.CurrentSucursal.Id)
                    , EgresoDAL.getEgresosSemanas(Convert.ToInt64(date.ToString("yyyy")),date.ToString("MM"), Validation.Validation.Val_Injection(""), Inicio.CurrentSucursal.Id),
                    folderName, fileName,
                    Convert.ToInt32(date.ToString("yyyy")),
                    date.Month))
                {
                    MessageBox.Show("La hoja de calculo ha sido generada en la carpeta " + "\"Contabilidad_" + (date.ToString("yyyy")) + "_Goll\"" + " en Documentos.", "Operación realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Error al generar la salida de datos o el archivo excel esta siendo usado por otro programa.");
                MessageBox.Show("Error al generar la salida de datos o el archivo excel esta siendo usado por otro programa.", "Error al generar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Arrow;

            }
        }

        private void maximizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void minimizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ingresosDelMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controles.ControlIngresos ingresos = new Controles.ControlIngresos();
            ingresos.ingresoMes = 1;
            ingresos.ShowDialog();
        }

        private void egresosDelMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controles.ControlEgresos egresos = new Controles.ControlEgresos();
            egresos.egresoMes = 1;
            egresos.ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuraciones.Configuraciones configs= new Configuraciones.Configuraciones();
            configs.currentForm = new Configuraciones.Backup();
            configs.ShowDialog();
            configs.Dispose();
        }
    }
}
