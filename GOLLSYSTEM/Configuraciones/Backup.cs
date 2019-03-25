using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOLLSYSTEM.Configuraciones
{
    public partial class Backup : Form
    {
        public Backup()
        {
            InitializeComponent();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            txtRuta.Text = string.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Location for BackUp File";
            saveFileDialog1.Filter = "Backup File|*.sql";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.RestoreDirectory = true;

            string fileName = "GOLLSYSTEM_Backup" + "_" + System.DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".sql";
            saveFileDialog1.FileName = fileName;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = saveFileDialog1.FileName;

                btnGenerar.Enabled = true;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                listMessage.Items.Clear();
                listMessage.Items.Add("Iniciando Proceso de conexión.");
                if (GOLLSYSTEM.DataAccess.Conexion.MakeBackup(txtRuta.Text))
                {
                    listMessage.Items.Add("Generando copia de seguridad.");
                    listMessage.Items.Add("Copia de seguridad creada exitosamente y almacenada en la ruta");
                    listMessage.Items.Add("\"" + txtRuta.Text + "\" exitosamente.");
                    MessageBox.Show("Copia de seguridad creada exitosamente en la ruta " + txtRuta.Text, "Operación realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                listMessage.Items.Add("Error: Ocurrio un error inesperado al intentar conectar con el servidor y generar la copia de seguridad.");
                listMessage.Items.Add(ex.Message);
            }

        }

        private void Backup_Load(object sender, EventArgs e)
        {
            txtRuta.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\GOLLSYSTEM_Backup" + "_" + System.DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".sql";
        }
    }
}
