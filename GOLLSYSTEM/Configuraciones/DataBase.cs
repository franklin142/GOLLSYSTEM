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
    public partial class DataBase : Form
    {
        public DataBase()
        {
            InitializeComponent();
        }

       
        private void DataBase_Load(object sender, EventArgs e)
        {
            txtDBIp.Text = Properties.Settings.Default.DBIp;
            txtDBName.Text = Properties.Settings.Default.DBName;
            txtDBPuerto.Text = Properties.Settings.Default.DBPort;
            txtDBUsuario.Text = Properties.Settings.Default.DBUser;
        }


        private void linkConexiones_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (DataAccess.Conexion.checkDB("server=" + txtDBIp.Text +
                ";port=" + txtDBPuerto.Text +
                ";user id=" + txtDBUsuario.Text +
                ";password=" + txtDBPass.Text +
                ";database=" + txtDBName.Text))

                MessageBox.Show("Los datos ingresados consiguen conectarse correctamente.", "Conexión exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Uno o varios datos no consiguen conectarse con la base de datos, por favor verificar todos los datos de conexión.", "Error al conectar", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataAccess.Conexion.checkDB("server=" + txtDBIp.Text +
                ";port=" + txtDBPuerto.Text +
                ";user id=" + txtDBUsuario.Text +
                ";password=" + txtDBPass.Text +
                ";database=" + txtDBName.Text))
                {
                     Properties.Settings.Default.DBIp= txtDBIp.Text ;
                     Properties.Settings.Default.DBName=txtDBName.Text ;
                     Properties.Settings.Default.DBPort= txtDBPuerto.Text;
                     Properties.Settings.Default.DBUser= txtDBUsuario.Text;
                    
                    if (txtDBPass.Text == "")
                    {
                        if (Properties.Settings.Default.DBPassword != "")
                        {
                            if (MessageBox.Show("El campo de contraseña esta vacio, ¿desea almacenar una contraseña vacia? si selecciona la opción NO se omitira este campo.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Properties.Settings.Default.DBPassword = "";
                            }
                        }
                    }
                    else
                    {
                        Properties.Settings.Default.DBPassword = txtDBPass.Text;
                    }
                    MessageBox.Show("Los datos ingresados han sido guardados exitosamente.", "Conexión y actualización satisfactorios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Uno o varios datos no consiguen conectarse con la base de datos, por favor verificar todos los datos de conexión.", "Error al conectar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al intentar guardar las configuraciones de conexión a la base de datos.", "Error en la operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDBIp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.Keypress.KeyPress_IP(sender, e);
        }

        private void txtDBPuerto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.Keypress.KeyPress_Numeros(sender, e);
        }

        private void txtDBUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.Keypress.KeyPress_UsuarioName(sender, e);
        }

        private void txtDBName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.Keypress.KeyPress_Num_Letras(sender, e);

        }

    }
}
