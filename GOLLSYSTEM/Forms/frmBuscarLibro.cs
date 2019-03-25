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
    public partial class frmBuscarLibro : Form
    {
        public frmBuscarLibro()
        {
            InitializeComponent();
        }
        public Libro CurrentObject;
        private string lastParam;

        private void frmBuscarLibro_Load(object sender, EventArgs e)
        {
            try
            {
                FillDgv(LibroDAL.searchLibros(txtBuscar.Text, 50));

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
            FillDgv(LibroDAL.searchLibros(Validation.Validation.Val_Injection(txtBuscar.Text), 50));
        }
        private void FillDgv(List<Libro> lista)
        {
            dgvBuscar.Rows.Clear();
            foreach (Libro obj in lista)
            {
                dgvBuscar.Rows.Add(obj.Id, obj.Nombre, obj.Edicion, obj.Nivel, obj.NActividades);
            }
            lblNoResults.Visible = dgvBuscar.RowCount == 0;
            lastParam = txtBuscar.Text;

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBuscar.CurrentRow != null)
                {
                    CurrentObject = LibroDAL.getLibroById((Int64)dgvBuscar.CurrentRow.Cells[0].Value);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex,"Ha ocurrido un error al intentar seleccionar la información de este control");
                MessageBox.Show("Ha ocurrido un error al intentar seleccionar la información de este control, por favor comuniquese con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            FrmLibro frmLibro = new FrmLibro();
            frmLibro.ShowDialog();
            txtBuscar.Text = "";
            FillDgv(LibroDAL.searchLibros(txtBuscar.Text, 50));

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    this.Close();
                    break;
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
                    FillDgv(LibroDAL.searchLibros(Validation.Validation.Val_Injection(txtBuscar.Text), 50));
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
