using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GOLLSYSTEM.EntityLayer;
using GOLLSYSTEM.DataAccess;

namespace GOLLSYSTEM.Configuraciones
{
    public partial class Configuraciones : Form
    {
        public Configuraciones()
        {
            InitializeComponent();
        }
        public Useremp user;
        public Form currentForm;

        private void ControlConfiguraciones_Load(object sender, EventArgs e)
        {
            if (user != null)
            {
                if (Inicio.CurrentUser.Login=="Administrador")
                {
                    opcUsuarios.Enabled = true;
                    opcUsuarios.Visible = true;
                }
                opcMisDatos.Enabled = true;
                opcMisDatos.Visible = true;
                foreach (LstPermiso obj in Inicio.CurrentUser.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Permisos)
                {
                    switch (obj.Permiso.Nombre)
                    {
                        case "Configurar Conexión de base de datos":
                            if (obj.Otorgado)
                            {
                                opcDataBase.Enabled = true;
                                opcDataBase.Visible = true;
                            }
                            break;
                        case "Importar base de datos":
                            if (obj.Otorgado)
                            {
                                opcRestaurar.Enabled = true;
                                opcRestaurar.Visible = true;
                            }
                            break;
                        case "Exportar base de datos":
                            if (obj.Otorgado)
                            {
                                opcRespaldo.Enabled = true;
                                opcRespaldo.Visible = true;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                AbrirForm(currentForm);
                switch (currentForm.GetType().Name)
                {
                    case "frmRestore":
                        lblTitle.Text = "Restaurar base de datos con respaldo existente";
                        opcRestaurar.Enabled = true;
                        opcRestaurar.Visible = true;
                        break;
                    case "frmBackup":
                        lblTitle.Text = "Respaldo de datos del sistema";

                        opcRespaldo.Enabled = true;
                        opcRespaldo.Visible = true;
                        break;
                    case "frmDataBase":
                        lblTitle.Text = "Conexión a base de datos";
                        opcDataBase.Enabled = true;
                        opcDataBase.Visible = true;
                        opcRestaurar.Enabled = true;
                        opcRestaurar.Visible = true;
                        break;
                    default: break;
                }
            }
        }
        public void AbrirForm(object FormOpening)
        {
            currentForm = FormOpening as Form;
            Validation.FormManager frmManager = new Validation.FormManager();
            frmManager.LoadForm(pnlContent, currentForm);
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBaseDatos_Click(object sender, EventArgs e)
        {
            AbrirForm(new DataBase());
            lblTitle.Text = "Conexión a base de datos";
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirForm(new Usuarios());
            lblTitle.Text = "Usuarios del sistema";
        }

        private void btnMisDatos_Click(object sender, EventArgs e)
        {
            AbrirForm(new EdtUsuario());
            lblTitle.Text = "Actualización de datos de usuario";
        }

        private void btnRespaldo_Click(object sender, EventArgs e)
        {
            AbrirForm(new Backup());
            lblTitle.Text = "Respaldo de datos del sistema";
        }

        private void btnRestauracion_Click(object sender, EventArgs e)
        {
            AbrirForm(new Restore());
            lblTitle.Text = "Restaurar base de datos con respaldo existente";
        }
    }
}
