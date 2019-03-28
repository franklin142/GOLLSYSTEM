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
    public partial class Restore : Form
    {
        public Restore()
        {
            InitializeComponent();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                txtRuta.Text = string.Empty;
                OpenFileDialog objOpenFileDialog = new OpenFileDialog();
                objOpenFileDialog.Title = "Seleccionar una copia de seguridad";
                objOpenFileDialog.Filter = "archivos sql|*.sql";
                objOpenFileDialog.RestoreDirectory = true;
                if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtRuta.Text = objOpenFileDialog.FileName;
                    btnRealizar.Enabled = true;
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnRealizar_Click(object sender, EventArgs e)
        {
            try
            {
                listMessage.Items.Clear();
                listMessage.Items.Add("Iniciando Proceso de conexión.");
                if (GOLLSYSTEM.DataAccess.Conexion.RestoreBackup(txtRuta.Text))
                {
                    listMessage.Items.Add("Enviando copia de seguridad.");
                    listMessage.Items.Add("Base de datos restaurada exitosamente.");
                    MessageBox.Show("La base de datos ha sido restaurada exitosamente con 0 errores, el sistema se reiniciará automaticamente al cerrar este mensaje.", "Operación realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                }
            }
            catch (Exception ex)
            {
                listMessage.Items.Add("Error: Ocurrio un error inesperado al intentar conectar");
                listMessage.Items.Add(" con el servidor y restaurar la copia de seguridad seleccionada.");
                listMessage.Items.Add(ex.Message);
                MessageBox.Show("Ocurrio un error inesperado al intentar restaurar la copia de seguridad seleccionada, por favor verifique que sea una copia de seguridad de la base de datos del sistema GOLL SYSTEM e intentelo de nuevo.", "Error de servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Restore_Load(object sender, EventArgs e)
        {

        }
    }
}
