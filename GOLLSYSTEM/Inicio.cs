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
        public bool holded = false;
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
                usuarioToolStripMenuItem.Text = Inicio.CurrentUser.Contrato.Empleado.Persona.Nombre;
                rolToolStripMenuItem.Text = Inicio.CurrentUser.Sucursales.Where(a => a.IdSucursal == CurrentSucursal.Id).FirstOrDefault().Rol.Nombre;
                foreach (LstPermiso obj in Inicio.CurrentUser.Sucursales.Where(a => a.IdSucursal == CurrentSucursal.Id).FirstOrDefault().Permisos)
                {
                    switch (obj.Permiso.Nombre)
                    {
                        case "Gestionar Matriculas":
                            if (obj.Otorgado)
                            {
                                opc1.Visible = true;
                                opc1.Enabled = true;
                            }
                            break;
                        case "Gestionar Empleados":
                            if (obj.Otorgado)
                            {
                                opc2.Visible = true;
                                opc2.Enabled = true;
                            }
                            break;
                        case "Gestionar Notas":
                            if (obj.Otorgado)
                            {
                                opc3.Visible = true;
                                opc3.Enabled = true;
                            }
                            break;
                        case "Gestionar Cursos":
                            if (obj.Otorgado)
                            {
                                opc4.Visible = true;
                                opc4.Enabled = true;
                            }
                            break;
                        case "Gestionar Ingresos":
                            if (obj.Otorgado)
                            {
                                opc5.Visible = true;
                                opc5.Enabled = true;
                                ingresosDelMesToolStripMenuItem.Enabled = true;
                            }
                            break;
                        case "Gestionar Egresos":
                            if (obj.Otorgado)
                            {
                                egresosDelMesToolStripMenuItem.Enabled = true;
                                opc6.Visible = true;
                                opc6.Enabled = true;
                            }
                            break;
                        case "Exportar Ingresos y Egresos del mes":
                            if (obj.Otorgado)
                            {
                                exportarEgresosIngresosToolStripMenuItem.Enabled = true;
                            }
                            break;
                        case "Gestionar Ajustes del Sistema":
                            if (obj.Otorgado)
                            {
                                configuracionesToolStripMenuItem.Enabled = true;
                            }
                            break;
                           
                        case "Exportar base de datos":
                            if (obj.Otorgado)
                            {
                                backupToolStripMenuItem.Enabled = true;
                            }
                            break;
                        default:
                            break;
                    }
                }
                if (Inicio.CurrentUser.Login=="Administrador")
                {
                    gestionarUsuariosDelSistemaToolStripMenuItem.Enabled = true;
                    recuperacionToolStripMenuItem.Enabled = true;
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
            MessageBox.Show("Función no disponible", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            Configuraciones.Configuraciones configs = new Configuraciones.Configuraciones();
            configs.currentForm = new Configuraciones.Backup();
            configs.ShowDialog();
            configs.Dispose();
        }

        private void gestionarUsuariosDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función no disponible", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void manualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función no disponible", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void rutaDeCarpetaDeContabilidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ChosePath choose = new Forms.ChosePath();
            choose.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void recuperacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuraciones.RecuperarCursos recuperacion = new Configuraciones.RecuperarCursos();
            recuperacion.ShowDialog();

        }

        private void estudiantesPendientesDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.Viewer viewer = new Reports.Viewer();
            viewer.TituloReporte = "Alumnos con mora";
            viewer.opcReporte = "Morosos";
            viewer.BringToFront();
            viewer.StartPosition = FormStartPosition.Manual;
            viewer.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (holded)
            {
                Forms.PassRequest pass = new Forms.PassRequest();
                pass.usuario = CurrentUser.Login;
                pass.ShowDialog();
                if (pass.DialogResult == DialogResult.Yes)
                {
                    pnlContent.Enabled = true;
                    flpMenu.Enabled = true;
                    toolStripDropDownArchivo.Enabled = true;
                    toolStripDropDownButton2.Enabled = true;
                    toolStripDropDownButton1.Enabled = true;
                    toolStripDropDownButton3.Enabled = true;
                    toolStripDropDownButton5.Enabled = true;
                    toolStripDropDownButton4.Enabled = true;
                    holded = false;

                }
            }
            else
            {
                holded = true;
                pnlContent.Enabled = false;
                flpMenu.Enabled = false;
                toolStripDropDownArchivo.Enabled = false;
                toolStripDropDownButton2.Enabled = false;
                toolStripDropDownButton1.Enabled = false;
                toolStripDropDownButton3.Enabled = false;
                toolStripDropDownButton5.Enabled = false;
                toolStripDropDownButton4.Enabled = false;
            }
        }
    }
}
