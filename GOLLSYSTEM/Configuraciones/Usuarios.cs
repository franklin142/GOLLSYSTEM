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
    public partial class Usuarios : Form
    {
        bool ready = false;
        public List<Useremp> users { get; set; }
        public Useremp currentUserEmp { get; set; }
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            try
            {
                cmbRol.DataSource = RolDAL.getRoles().Where(a => a.Nombre != "Administrador").ToList();
                cmbRol.DisplayMember = "Nombre";
                cmbRol.ValueMember = "Id";

                users = UserempDAL.getUsersemp();
                foreach (Useremp user in users)
                {
                    dgvUsuarios.Rows.Add(user.Id, user.Login, user.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Rol.Nombre);
                }
                if (dgvUsuarios.Rows.Count > 0)
                {
                    currentUserEmp = users.Where(a => a.Id == (Int64)dgvUsuarios.CurrentRow.Cells[0].Value).FirstOrDefault();
                    txtEmpleado.Text = currentUserEmp.Contrato.Empleado.Persona.Nombre;
                    txtLogin.Text = currentUserEmp.Login;
                    string nombreRol = currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Rol.Nombre;
                    for (int i = 0; i < cmbRol.Items.Count; i++) cmbRol.SelectedIndex = (cmbRol.GetItemText(cmbRol.Items[i]) == nombreRol) ? i : cmbRol.SelectedIndex;
                    checkEstado.Checked = currentUserEmp.Estado == "A";

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ready = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ready = false;
            btnCancelar.Visible = true;
            btnRegistrar.Text = "Registrar";

            cmbRol.DataSource = RolDAL.getRoles().Where(a => a.Nombre != "Main User" && a.Nombre != "Administrador").ToList();
            cmbRol.DisplayMember = "Nombre";
            cmbRol.ValueMember = "Id";
            cmbRol.Enabled = true;

            txtLogin.Enabled = true;
            txtPass.Enabled = true;
            txtRepetir.Enabled = true;
            checkEstado.Enabled = true;
            btnEditarPermisos.Enabled = true;
            btnBuscarEmpleado.Enabled = true;
            txtEmpleado.Text = "";
            txtLogin.Text = "";
            txtPass.Text = "";
            txtRepetir.Text = "";
            btnNuevo.Enabled = false;
            dgvUsuarios.Enabled = false;
            btnRegistrar.Text = "Registrar";
            currentUserEmp = new Useremp();
            currentUserEmp.Sucursales = currentUserEmp.Sucursales == null ? new List<AcsSucursal>() : currentUserEmp.Sucursales;
            if (currentUserEmp.Sucursales.Count == 0)
            {
                Rol rol = cmbRol.SelectedItem as Rol;
                currentUserEmp.Sucursales.Add(new AcsSucursal(0, null, 0, rol.Id, Inicio.CurrentSucursal.Id, rol, null, new List<LstPermiso>()));
            }
            ready = true;
        }

        private void dgvUsuarios_CurrentCellChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                currentUserEmp = users.Where(a => a.Id == (Int64)dgvUsuarios.CurrentRow.Cells[0].Value).FirstOrDefault();
                txtEmpleado.Text = currentUserEmp.Contrato.Empleado.Persona.Nombre;
                txtLogin.Text = currentUserEmp.Login;
                string nombreRol = currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Rol.Nombre;
                for (int i = 0; i < cmbRol.Items.Count; i++) cmbRol.SelectedIndex = (cmbRol.GetItemText(cmbRol.Items[i]) == nombreRol) ? i : cmbRol.SelectedIndex;
                checkEstado.Checked = currentUserEmp.Estado == "A";
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (btnRegistrar.Text == "Editar")
            {
                if (dgvUsuarios.RowCount > 0)
                {
                    if (dgvUsuarios.CurrentRow.Cells[1].Value.ToString() != "Administrador")
                    {
                        cmbRol.DataSource = RolDAL.getRoles().Where(a => a.Nombre != "Main User" && a.Nombre != "Administrador").ToList();
                        cmbRol.DisplayMember = "Nombre";
                        cmbRol.ValueMember = "Id";
                        cmbRol.Enabled = true;
                        btnEditarPermisos.Enabled = true;
                        txtLogin.Enabled = true;
                        checkEstado.Enabled = true;
                    }
                    else
                    {
                        txtLogin.Enabled = false;
                    }
                    btnBuscarEmpleado.Enabled = true;
                    txtPass.Enabled = true;
                    txtRepetir.Enabled = true;
                    dgvUsuarios.Enabled = false;
                    btnNuevo.Enabled = false;
                    btnCancelar.Visible = true;
                    btnRegistrar.Text = "Guardar";

                }
            }
            else if (btnRegistrar.Text == "Guardar")
            {
                bool result = true;
                if (txtLogin.Text.Length < 5 || txtLogin.Text.Length > 30)
                {
                    MessageBox.Show("El nombre de usuario debe contener entre 5 y 30 caracteres.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    result = false;
                }
                if (txtPass.Text.Length > 0 || txtRepetir.Text.Length > 0)
                {
                    if (result)
                    {
                        if (txtPass.Text.Length < 5)
                        {
                            MessageBox.Show("Las contraseña debe contener al menos 5 caracteres.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            result = false;
                        }
                    }
                    if (result)
                    {
                        if (!Validation.Validation.Val_PasswordFormat(txtPass.Text))
                        {
                            MessageBox.Show("La contraseña tiene caracteres raros, por favor utilice solo letras del alfabeto y numeros para formar su contraseña.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            result = false;
                        }
                    }
                    if (result)
                    {
                        if (txtPass.Text.ToUpper() == txtLogin.Text.ToUpper())
                        {
                            MessageBox.Show("La contraseña no puede ser igual al nombre de usuario por motivos de seguridad.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            result = false;
                        }
                    }
                    if (result)
                    {
                        if (txtPass.Text != txtRepetir.Text)
                        {
                            MessageBox.Show("Las contraseñas deben ser iguales, para continuar con el registro debe verificar estos campos.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            result = false;
                        }
                    }
                }
                if (txtLogin.Text!=currentUserEmp.Login)
                {
                    if (result)
                    {
                        if (UserempDAL.getUseremp(txtLogin.Text.ToUpper()) != null)
                        {
                            MessageBox.Show("El nombre de usuario seleccionado ya existe, por favor elija otro nombre para continuar con el registro.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            result = false;
                        }
                    }
                }
                if (result)
                {
                    if (MessageBox.Show("Datos validados correctamente, desea continuar con la actualización?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        currentUserEmp.Login = txtLogin.Text;
                        currentUserEmp.Pass = txtPass.Text;

                        currentUserEmp.Estado = checkEstado.Checked ? "A" : "I";

                        if (UserempDAL.UpdateUserEmp(currentUserEmp,"all",Inicio.CurrentUser))
                        {
                            MessageBox.Show("El usuario ha sido actualizado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnCancelar.PerformClick();
                        }
                    }
                }
            }
            else
            {
                bool result = true;
                if (txtLogin.Text.Length < 5 || txtLogin.Text.Length > 30)
                {
                    MessageBox.Show("El nombre de usuario debe contener entre 5 y 30 caracteres.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    result = false;
                }
                if (result)
                {
                    if (txtPass.Text.Length <5)
                    {
                        MessageBox.Show("Las contraseña debe contener al menos 5 caracteres.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        result = false;
                    }
                }
                if (result)
                {
                    if (!Validation.Validation.Val_PasswordFormat(txtPass.Text))
                    {
                        MessageBox.Show("La contraseña tiene caracteres raros, por favor utilice solo letras del alfabeto y numeros para formar su contraseña.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        result = false;
                    }
                }
                if (result)
                {
                    if (txtPass.Text.ToUpper()==txtLogin.Text.ToUpper())
                    {
                        MessageBox.Show("La contraseña no puede ser igual al nombre de usuario por motivos de seguridad.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        result = false;
                    }
                }
                if (result)
                {
                    if (txtPass.Text != txtRepetir.Text)
                    {
                        MessageBox.Show("Las contraseñas deben ser iguales, para continuar con el registro debe verificar estos campos.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        result = false;
                    }
                }
                
                if (result)
                {
                    if (UserempDAL.getUseremp(txtLogin.Text.ToUpper()) != null)
                    {
                        MessageBox.Show("El nombre de usuario seleccionado ya existe, por favor elija otro nombre para continuar con el registro.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        result = false;
                    }
                }
                if (result)
                {
                    if (currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Permisos.Count == 0)
                    {
                        MessageBox.Show("No ha gestionado los permisos para este usuario, por favor hacer clic en \"Editar Permisos\" y seleccionar los permisos asociados para el usuario.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        result = false;
                    }
                }
                if (result)
                {
                    if(MessageBox.Show("Datos validados correctamente, desea continuar con el registro?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes){
                        currentUserEmp.Login = txtLogin.Text;
                        currentUserEmp.Pass = txtPass.Text;
                        currentUserEmp.Estado = checkEstado.Checked?"A":"I";
                        if (UserempDAL.InsertUserEmp(currentUserEmp,Inicio.CurrentUser))
                        {
                            MessageBox.Show("El usuario ha sido registrado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnCancelar.PerformClick();
                        }
                    }
                }


            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ready = false;
            btnNuevo.Enabled = true;
            btnEditarPermisos.Enabled = false;
            btnRegistrar.Text = "Editar";
            btnCancelar.Visible = false;
            dgvUsuarios.Enabled = true;
            txtLogin.Enabled = false;
            txtPass.Enabled = false;
            txtRepetir.Enabled = false;
            cmbRol.Enabled = false;
            btnBuscarEmpleado.Enabled = false;
            checkEstado.Enabled = false;
            users = UserempDAL.getUsersemp();
            dgvUsuarios.Rows.Clear();
            foreach (Useremp user in users)
            {
                dgvUsuarios.Rows.Add(user.Id, user.Login, user.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Rol.Nombre);
            }

            currentUserEmp = null;
            if (dgvUsuarios.Rows.Count > 0)
            {
                currentUserEmp = users.Where(a => a.Id == (Int64)dgvUsuarios.CurrentRow.Cells[0].Value).FirstOrDefault();
                txtEmpleado.Text = currentUserEmp.Contrato.Empleado.Persona.Nombre;
                txtLogin.Text = currentUserEmp.Login;
                string nombreRol = currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Rol.Nombre;
                for (int i = 0; i < cmbRol.Items.Count; i++) cmbRol.SelectedIndex = (cmbRol.GetItemText(cmbRol.Items[i]) == nombreRol) ? i : cmbRol.SelectedIndex;
                checkEstado.Checked = currentUserEmp.Estado == "A";

            }
            ready = true;
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ready)
            {
                if (btnRegistrar.Text == "Registrar")
                {
                    currentUserEmp.Sucursales = currentUserEmp.Sucursales == null ? new List<AcsSucursal>() : currentUserEmp.Sucursales;
                    Rol rol = cmbRol.SelectedItem as Rol;

                    if (currentUserEmp.Sucursales.Count == 0)
                    {
                        currentUserEmp.Sucursales.Add(new AcsSucursal(0, null, 0, rol.Id, Inicio.CurrentSucursal.Id, rol, null, new List<LstPermiso>()));
                    }
                    else
                    {

                        currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Rol = rol;
                        currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().IdRol = rol.Id;
                        currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Permisos = new List<LstPermiso>();

                    }
                }
                else if (btnRegistrar.Text == "Guardar")
                {

                }
            }
        }

        private void btnEditarPermisos_Click(object sender, EventArgs e)
        {
            Permisos frmpermisos = new Permisos();
            frmpermisos.UserName = currentUserEmp.Login;
            frmpermisos.UserRol = currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Rol.Nombre;
            if (btnRegistrar.Text == "Registrar")
            {
                frmpermisos.AcsSucursal = null;
                frmpermisos.AcsSucursalEditing = currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault();
                frmpermisos.UserName = txtLogin.Text;

                if (frmpermisos.AcsSucursalEditing.Permisos.Count > 0)
                {
                    frmpermisos.AcsSucursal = new AcsSucursal();
                    frmpermisos.AcsSucursalEditing = new AcsSucursal();
                    frmpermisos.AcsSucursal.Id = currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Id;
                    frmpermisos.AcsSucursal.IdRol = currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().IdRol;
                    frmpermisos.AcsSucursal.IdSucursal = currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().IdSucursal;
                    frmpermisos.AcsSucursal.IdUserEmp = currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().IdUserEmp;
                    frmpermisos.AcsSucursal.FhRegistro = currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().FhRegistro;
                    frmpermisos.AcsSucursal.Sucursal = currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Sucursal;
                    frmpermisos.AcsSucursal.Permisos = new List<LstPermiso>();
                    foreach (LstPermiso permiso in currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Permisos)
                    {
                        frmpermisos.AcsSucursal.Permisos.Add(new LstPermiso(0, null, permiso.Otorgado, permiso.IdPermiso, permiso.IdAscSucursal, permiso.Permiso));
                    }
                    frmpermisos.AcsSucursalEditing.Permisos = new List<LstPermiso>();

                    foreach (LstPermiso permiso in currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Permisos)
                    {
                        frmpermisos.AcsSucursalEditing.Permisos.Add(new LstPermiso(0, null, permiso.Otorgado, permiso.IdPermiso, permiso.IdAscSucursal, permiso.Permiso));
                    }
                }
                else
                {
                    frmpermisos.AcsSucursalEditing = currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault();
                }
                frmpermisos.ShowDialog();

                if (frmpermisos.DialogResult == DialogResult.Yes)
                {
                    currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Permisos = frmpermisos.AcsSucursalEditing.Permisos;
                }
            }
            else
            {
                frmpermisos.AcsSucursal = new AcsSucursal();
                frmpermisos.AcsSucursalEditing = new AcsSucursal();
                frmpermisos.AcsSucursal.Id = currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Id;
                frmpermisos.AcsSucursal.IdRol = currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().IdRol;
                frmpermisos.AcsSucursal.IdSucursal = currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().IdSucursal;
                frmpermisos.AcsSucursal.IdUserEmp = currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().IdUserEmp;
                frmpermisos.AcsSucursal.FhRegistro = currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().FhRegistro;
                frmpermisos.AcsSucursal.Sucursal = currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Sucursal;

                frmpermisos.AcsSucursal.Permisos = new List<LstPermiso>();

                foreach (LstPermiso permiso in currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Permisos)
                {
                    frmpermisos.AcsSucursal.Permisos.Add(new LstPermiso(permiso.Id, null, permiso.Otorgado, permiso.IdPermiso, permiso.IdAscSucursal, permiso.Permiso));
                }
                frmpermisos.AcsSucursalEditing.Permisos = new List<LstPermiso>();

                foreach (LstPermiso permiso in currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Permisos)
                {
                    frmpermisos.AcsSucursalEditing.Permisos.Add(new LstPermiso(permiso.Id, null, permiso.Otorgado, permiso.IdPermiso, permiso.IdAscSucursal, permiso.Permiso));
                }
                frmpermisos.ShowDialog();
                if (frmpermisos.DialogResult == DialogResult.Yes)
                {
                    currentUserEmp.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Permisos = frmpermisos.AcsSucursalEditing.Permisos;
                }
            }

        }

        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            Forms.frmBuscarEmpleado buscarEmp = new Forms.frmBuscarEmpleado();
            buscarEmp.ShowDialog();
            if (buscarEmp.CurrentObject != null)
            {
                currentUserEmp.Contrato = buscarEmp.CurrentObject;
                currentUserEmp.IdContrato= buscarEmp.CurrentObject.Id;
                txtEmpleado.Text = currentUserEmp.Contrato.Empleado.Persona.Nombre + " " + currentUserEmp.Contrato.Cargo.Nombre;
            }
        }
    }
}
