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


namespace GOLLSYSTEM.Configuraciones
{
    public partial class Permisos : Form
    {
        public AcsSucursal AcsSucursal { get; set; }
        public AcsSucursal AcsSucursalEditing { get; set; }
        public List<Permiso> DSPermisos = PermisoDAL.getPermisos();
        public string UserName { get; set; }
        public string UserRol { get; set; }

        public Permisos()
        {
            InitializeComponent();
        }

        private void Permisos_Load(object sender, EventArgs e)
        {
            lblUser.Text = UserName;
            lblRol.Text = UserRol;
            if (AcsSucursal == null)
            {
                if (AcsSucursalEditing.Permisos.Count==0)
                {
                    AcsSucursalEditing.Permisos = new List<LstPermiso>();
                    foreach (Permiso obj in DSPermisos)
                    {
                        AcsSucursalEditing.Permisos.Add(new LstPermiso(0, null, false, Convert.ToInt32(obj.Id), Convert.ToInt32(AcsSucursalEditing.Id), obj));
                    }
                }
                else
                {
                    foreach (Control ctrl in pnlPermisos.Controls)
                    {
                        foreach (Control checkbox in ctrl.Controls)
                        {
                            (checkbox as CheckBox).Checked = AcsSucursalEditing.Permisos.Where(a => "p" + a.Permiso.Id == checkbox.Name).FirstOrDefault().Otorgado;

                        }
                    }
                }
               // AcsSucursal = AcsSucursalEditing;
            }
            else
            {
                foreach (Control ctrl in pnlPermisos.Controls)
                {
                    foreach (Control checkbox in ctrl.Controls)
                    {
                        (checkbox as CheckBox).Checked = AcsSucursal.Permisos.Where(a => "p" + a.Permiso.Id == checkbox.Name).FirstOrDefault().Otorgado;
                    }
                }
            }
        }

        private void Permiso_Click(object sender, EventArgs e)
        {
            string PermisoName = (sender as CheckBox).Name;
            bool Otorgado = (sender as CheckBox).Checked;
            LstPermiso permiso = AcsSucursalEditing.Permisos.Where(a => "p" + a.Permiso.Id == PermisoName).FirstOrDefault();
            if (permiso.Permiso.Nombre == permiso.Permiso.Categoria)
            {

                foreach (LstPermiso obj in AcsSucursalEditing.Permisos.Where(a => a.Permiso.Categoria == AcsSucursalEditing.Permisos.Where(ae => "p" + ae.Permiso.Id == PermisoName).FirstOrDefault().Permiso.Categoria).ToList())
                {
                    obj.Otorgado = Otorgado;

                }
                foreach (Control ctrl in (sender as CheckBox).Parent.Controls)
                {
                    (ctrl as CheckBox).Checked = Otorgado;
                }
            }
            else
            {
                permiso.Otorgado = Otorgado;
                LstPermiso PermisoCategoria = AcsSucursalEditing.Permisos.Where(a => a.Permiso.Nombre == permiso.Permiso.Categoria).FirstOrDefault();

                foreach (Control ctrl in (sender as CheckBox).Parent.Controls)
                {
                    if (ctrl.Name == "p" + PermisoCategoria.Permiso.Id)
                    {
                        if (Otorgado)
                        {
                            (ctrl as CheckBox).Checked = Otorgado;
                            PermisoCategoria.Otorgado = Otorgado;
                        }
                        else
                        {
                            if (AcsSucursalEditing.Permisos.Where(a => a.Otorgado && a.Permiso.Categoria == PermisoCategoria.Permiso.Categoria&& a.Permiso.Nombre!=PermisoCategoria.Permiso.Categoria).ToList().Count == 0)
                            {
                                (ctrl as CheckBox).Checked = Otorgado;
                                PermisoCategoria.Otorgado = Otorgado;
                            }
                        }
                    }
                }
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            if (AcsSucursal == null)
            {
                foreach (Control ctrl in pnlPermisos.Controls)
                {
                    foreach (Control checkbox in ctrl.Controls)
                    {
                        (checkbox as CheckBox).Checked = false;
                        AcsSucursalEditing.Permisos.Where(a => "p" + a.Permiso.Id == checkbox.Name).FirstOrDefault().Otorgado = false;
                    }
                }
            }
            else
            {
                if (AcsSucursal.Id > 0)
                {
                    AcsSucursal = AcsSucursalDAL.getAcsSucursalById(AcsSucursal.Id);
                    AcsSucursalEditing = AcsSucursalDAL.getAcsSucursalById(AcsSucursal.Id);
                    foreach (Control ctrl in pnlPermisos.Controls)
                    {
                        foreach (Control checkbox in ctrl.Controls)
                        {
                            (checkbox as CheckBox).Checked = AcsSucursal.Permisos.Where(a => "p" + a.Permiso.Id == checkbox.Name).FirstOrDefault().Otorgado;

                        }
                    }

                }
                else
                {
                    foreach (Control ctrl in pnlPermisos.Controls)
                    {
                        foreach (Control checkbox in ctrl.Controls)
                        {
                            (checkbox as CheckBox).Checked = AcsSucursal.Permisos.Where(a => "p" + a.Permiso.Id == checkbox.Name).FirstOrDefault().Otorgado;

                        }
                    }
                    AcsSucursalEditing.Permisos = new List<LstPermiso>();
                    foreach (LstPermiso permiso in AcsSucursal.Permisos)
                    {
                        AcsSucursalEditing.Permisos.Add(new LstPermiso(0, null, permiso.Otorgado, permiso.IdPermiso, permiso.IdAscSucursal, permiso.Permiso));
                    }
                }
            }
            
        }
    }

}

