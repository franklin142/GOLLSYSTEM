using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOLLSYSTEM.Forms
{
    public partial class ChosePath : Form
    {
        public ChosePath()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if (txtRuta.Text=="")
            {
                MessageBox.Show("No puede guardar el campo vacío", "Alerta de validación", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Properties.Settings.Default.DocumentsPath = txtRuta.Text;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Ruta de archivos actualizada exitosamente.", "Actualización satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    string fileName = "Exeptions_" + Name + ".txt";
                    Validation.FormManager frmManager = new Validation.FormManager();
                    frmManager.writeException(folderName, fileName, ex, "Ocurrio un error inesperado al intentar actualizar el curso");
                    MessageBox.Show("Ocurrio un error inesperado al intentar actualizar el curso, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                txtRuta.Text = string.Empty;
                FolderBrowserDialog objOpenFileDialog = new FolderBrowserDialog();
                
                if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtRuta.Text = objOpenFileDialog.SelectedPath;
                }
            }
            catch (Exception)
            {

            }
        }

        private void ChosePath_Load(object sender, EventArgs e)
        {
           txtRuta.Text = Properties.Settings.Default.DocumentsPath;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
