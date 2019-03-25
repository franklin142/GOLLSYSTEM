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
using System.Reflection;

namespace GOLLSYSTEM.Forms
{
    public partial class frmBuscarEncargado : Form
    {
        public Encargado CurrentObject;
        private string lastParam;

        public frmBuscarEncargado()
        {
            InitializeComponent();
        }

        private void frmBuscarEncargado_Load(object sender, EventArgs e)
        {
            try
            {
                FillDgv(EncargadoDAL.searchEncargados(txtBuscar.Text, 30));

            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ha ocurrido un error al intentar cargar la información de este control");
                MessageBox.Show("Ha ocurrido un error al intentar cargar la información de este control, por favor comuniquese con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void icUpdate_Click(object sender, EventArgs e)
        {
            FillDgv(EncargadoDAL.searchEncargados(Validation.Validation.Val_Injection(txtBuscar.Text), 30));
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBuscar.CurrentRow != null) { CurrentObject = EncargadoDAL.getEncargadoById((Int64)dgvBuscar.CurrentRow.Cells[0].Value); this.Close(); }

            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ha ocurrido un error al intentar seleccionar la información de este control");
                MessageBox.Show("Ha ocurrido un error al intentar seleccionar la información de este control, por favor comuniquese con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void FillDgv(List<Encargado> lista)
        {
            dgvBuscar.Rows.Clear();
            foreach (Encargado obj in lista) dgvBuscar.Rows.Add(obj.Id, obj.Persona.Nombre, obj.Telefono, obj.Trabajo, obj.Persona.Direccion);
            lblNoResults.Visible = dgvBuscar.RowCount == 0;
            lastParam = txtBuscar.Text;

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    this.Close(); break;
                case Keys.Down:
                    dgvBuscar.Focus();
                    break;

                default:

                    if (char.IsLetterOrDigit((char)keyData))
                    {
                        if (!txtBuscar.Focused)
                        {
                            txtBuscar.Text = txtBuscar.Text += (char)keyData;
                            txtBuscar.Focus();
                            txtBuscar.SelectionStart = txtBuscar.Text.Length;

                        }
                    }
                    if (keyData.ToString().ToUpper() == "BACK")
                    {
                        if (!txtBuscar.Focused)
                        {
                            txtBuscar.Text = txtBuscar.Text.Substring(0, txtBuscar.Text.Length > 0 ? txtBuscar.Text.Length - 1 : 0);
                            txtBuscar.Focus();
                            txtBuscar.SelectionStart = txtBuscar.Text.Length;
                        }

                    }
                    break;

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                if (txtBuscar.Text != lastParam)
                {
                    FillDgv(EncargadoDAL.searchEncargados(Validation.Validation.Val_Injection(txtBuscar.Text), 30));
                }
                else
                {
                    btnSeleccionar.PerformClick();
                }
            }
        }

        private void dgvBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                btnSeleccionar.PerformClick();
            }
        }
    }
}
