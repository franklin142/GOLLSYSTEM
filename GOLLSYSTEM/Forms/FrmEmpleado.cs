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
    public partial class FrmEmpleado : Form
    {
        public Contrato CurrentObject;
        public Contrato EditingObject;
        public Contrato NewObject;
        public string opc = "newEmpleado";
        public FrmEmpleado()
        {
            InitializeComponent();
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                dtpFechaNac.MaxDate = DateTime.Now.AddYears(-17);
                cmbCargo.DataSource = CargoDAL.getCargos(100);
                cmbCargo.ValueMember = "Id";
                cmbCargo.DisplayMember = "Nombre";

                switch (opc)
                {
                    case "newContrato":
                        LstPermiso permiso1 = Inicio.CurrentUser.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Permisos.Where(a => a.Permiso.Nombre == "Crear Contratos").FirstOrDefault();
                        btnGuardar.Enabled = !(permiso1 == null || permiso1.Otorgado == false);

                        txtNombre.Text = CurrentObject.Empleado.Persona.Nombre;
                        txtTelefono.Text = CurrentObject.Empleado.Telefono;
                        txtDui.Text = CurrentObject.Empleado.Persona.Dui;
                        txtNit.Text = CurrentObject.Empleado.Persona.Nit;
                        txtCorreo.Text = CurrentObject.Empleado.Correo;
                        dtpFechaNac.Value = Convert.ToDateTime(CurrentObject.Empleado.Persona.FechaNac);
                        txtDireccion.Text = CurrentObject.Empleado.Persona.Direccion;
                        txtNombre.Enabled = false;
                        txtTelefono.Enabled = false;
                        txtDui.Enabled = false;
                        txtNit.Enabled = false;
                        txtCorreo.Enabled = false;
                        dtpFechaNac.Enabled = false;
                        txtDireccion.Enabled = false;
                        break;
                    case "updContrato":
                        LstPermiso permiso2 = Inicio.CurrentUser.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Permisos.Where(a => a.Permiso.Nombre == "Editar Contratos").FirstOrDefault();
                        btnGuardar.Enabled = !(permiso2 == null || permiso2.Otorgado == false);
                        txtNombre.Text = CurrentObject.Empleado.Persona.Nombre;
                        txtTelefono.Text = CurrentObject.Empleado.Telefono;
                        txtDui.Text = CurrentObject.Empleado.Persona.Dui;
                        txtNit.Text = CurrentObject.Empleado.Persona.Nit;
                        txtCorreo.Text = CurrentObject.Empleado.Correo;
                        dtpFechaNac.Value = Convert.ToDateTime(CurrentObject.Empleado.Persona.FechaNac);
                        txtDireccion.Text = CurrentObject.Empleado.Persona.Direccion;
                        for (int i = 0; i < cmbCargo.Items.Count; i++) cmbCargo.SelectedIndex = (cmbCargo.GetItemText(cmbCargo.Items[i]) == CurrentObject.Cargo.Nombre) ? i : cmbCargo.SelectedIndex;
                        txtNombre.Enabled = false;
                        txtTelefono.Enabled = false;
                        txtDui.Enabled = false;
                        txtNit.Enabled = false;
                        txtCorreo.Enabled = false;
                        dtpFechaNac.Enabled = false;
                        txtDireccion.Enabled = false;
                        break;
                    case "updEmpleado":
                        LstPermiso permiso3 = Inicio.CurrentUser.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Permisos.Where(a => a.Permiso.Nombre == "Editar Empleados").FirstOrDefault();
                        btnGuardar.Enabled = !(permiso3 == null || permiso3.Otorgado == false);
                        txtNombre.Text = CurrentObject.Empleado.Persona.Nombre;
                        txtTelefono.Text = CurrentObject.Empleado.Telefono;
                        txtDui.Text = CurrentObject.Empleado.Persona.Dui;
                        txtNit.Text = CurrentObject.Empleado.Persona.Nit;
                        txtCorreo.Text = CurrentObject.Empleado.Correo;
                        dtpFechaNac.Value = Convert.ToDateTime(CurrentObject.Empleado.Persona.FechaNac);
                        txtDireccion.Text = CurrentObject.Empleado.Persona.Direccion;
                        cmbCargo.Enabled = false;
                        break;
                    case "newEmpleado":
                        LstPermiso permiso = Inicio.CurrentUser.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Permisos.Where(a => a.Permiso.Nombre == "Crear Empleados").FirstOrDefault();
                        btnGuardar.Enabled = !(permiso == null || permiso.Otorgado == false);
                        break;
                    default: break;

                }
            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex,"Ha ocurrido un error al intentar cargar la información de este control");
                MessageBox.Show("Ha ocurrido un error al intentar cargar la información de este control, por favor comuniquese con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (opc)
            {
                case "newEmpleado":
                    if (val_NewObject())
                    {
                        try
                        {
                            NewObject = new Contrato(
                          0,
                          DateTime.Now.ToString(),
                          DateTime.Now.ToString(),
                          null,
                          "A",
                          (cmbCargo.SelectedValue == null) ? 0 : Convert.ToInt32(cmbCargo.SelectedValue),
                          EditingObject != null ? EditingObject.IdEmpleado : 0,
                          Inicio.CurrentSucursal.Id,
                          new Cargo(
                              (cmbCargo.SelectedValue == null) ? 0 : Convert.ToInt32(cmbCargo.SelectedValue),
                              null,
                              null),
                          new Empleado(
                              EditingObject != null && EditingObject.Empleado != null ? EditingObject.Empleado.Id : 0,
                              DateTime.Now.ToString(),
                              txtTelefono.Text,
                              txtCorreo.Text,
                              null,
                              EditingObject != null && EditingObject.Empleado != null && EditingObject.Empleado.Persona != null ? EditingObject.Empleado.Persona.Id : 0,
                              new Persona(
                                  EditingObject != null && EditingObject.Empleado != null && EditingObject.Empleado.Persona != null ? EditingObject.Empleado.Persona.Id : 0,
                                  txtNombre.Text,
                                  txtDui.Text,
                                  txtNit.Text,
                                  txtDireccion.Text,
                                  dtpFechaNac.Value.ToString("yyyy-MM-dd")

                                  )
                              )

                          );
                            if (ContratoDAL.InsertFullContrato(NewObject, Inicio.CurrentUser))
                            {
                                MessageBox.Show("El Empleado ha sido registrado exitosamente.", "Registro satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                EditingObject = null;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Ocurrio un error inesperado al intentar registrar el empleado, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.", "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        catch (Exception ex)
                        {
                            string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                            string fileName = "Exeptions_" + Name + ".txt";
                            Validation.FormManager frmManager = new Validation.FormManager();
                            frmManager.writeException(folderName, fileName, ex, "Ocurrio un error inesperado al intentar registrar el empleado");
                            MessageBox.Show("Ocurrio un error inesperado al intentar registrar el empleado, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hay algunos campos que necesitan ser verificados antes de poder guardar, por favor revise todos los campos antes de continuar.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                case "newContrato":
                    try
                    {
                        EditingObject.IdCargo = (cmbCargo.SelectedValue == null) ? 0 : Convert.ToInt32(cmbCargo.SelectedValue);
                        EditingObject.Cargo.Id = (cmbCargo.SelectedValue == null) ? 0 : Convert.ToInt32(cmbCargo.SelectedValue);
                        EditingObject.FhInicio = DateTime.Now.ToString("yyyy/MM/dd");
                        if (val_NewObjectContrato())
                        {
                            if (ContratoDAL.InsertContrato(EditingObject, Inicio.CurrentUser))
                            {
                                MessageBox.Show("El contrato ha sido registrado exitosamente.", "Registro satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                EditingObject = null;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Ocurrio un error inesperado al intentar registrar el contrato, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.", "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrio un error inesperado al intentar registrar el contrato, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.\nInfo adicional del problema:\n\n\n " + ex.ToString(), "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "updContrato":
                    try
                    {
                        EditingObject.IdCargo = (cmbCargo.SelectedValue == null) ? 0 : Convert.ToInt32(cmbCargo.SelectedValue);
                        EditingObject.Cargo.Id = (cmbCargo.SelectedValue == null) ? 0 : Convert.ToInt32(cmbCargo.SelectedValue);
                        if (val_UPDObjectContrato())
                        {
                            if (ContratoDAL.updateContrato(EditingObject, Inicio.CurrentUser))
                            {
                                MessageBox.Show("El contrato ha sido actualizado exitosamente.", "Atualización satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                EditingObject = null;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Ocurrio un error inesperado al intentar actualizae el contrato, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.", "Actualización interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrio un error inesperado al intentar actualizar el contrato, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.\nInfo adicional del problema:\n\n\n " + ex.ToString(), "Acutalización interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "updEmpleado":
                    if (val_UPDObject())
                    {
                        try
                        {
                            if (ContratoDAL.updateContrato(EditingObject, Inicio.CurrentUser))
                            {
                                MessageBox.Show("El Empleado ha sido actualizado exitosamente.", "Atualización satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                EditingObject = null;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Ocurrio un error inesperado al intentar actualizae el empleado, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.", "Actualización interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio un error inesperado al intentar actualizar el empleado, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.\nInfo adicional del problema:\n\n\n " + ex.ToString(), "Acutalización interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hay algunos campos que necesitan ser verificados antes de poder guardar, por favor revise todos los campos antes de continuar.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                default: break;

            }
        }

        private bool val_NewObject()
        {
            bool result = true;
            if (!Validation.Validation.Val_NameFormat(txtNombre.Text))
            {
                errNombre.SetError(txtNombre, "El nombre ingresado no tiene el formato correcto.\nPor favor ingrese el nombre completo utilizando\n solo caracteres válidos del alfabeto.");
                valNombre.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errNombre.Clear();
                valNombre.BackColor = Color.FromArgb(0, 100, 182);
            }
            if (!Validation.Validation.Val_CellphoneFormat(txtTelefono.Text))
            {
                errTelefono.SetError(txtTelefono, "El telefono ingresado no tiene el formato correcto.\nPor favor ingrese un número telefónico válido en uno de\n los siguientes formatos: 22222222,+5037777777 o (+503)77777777.");
                valTelefono.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errTelefono.Clear();
                valTelefono.BackColor = Color.FromArgb(0, 100, 182);
            }
            if (!Validation.Validation.Val_DuiFormat(txtDui.Text))
            {
                errDui.SetError(txtDui, "El dui ingresado no tiene el formato correcto.\nPor favor ingrese un úumero de dui válido.\nEjemplo: 12345678-9");
                valDui.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errDui.Clear();
                valDui.BackColor = Color.FromArgb(0, 100, 182);
            }
            if (!Validation.Validation.Val_NitFormat(txtNit.Text))
            {
                errNit.SetError(txtNit, "El nit ingresado no tiene el formato correcto.\nPor favor ingrese un número de nit válido.\nEjemplo: 0000-000000-000-0");
                valNit.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errNit.Clear();
                valNit.BackColor = Color.FromArgb(0, 100, 182);
            }

            if (!Validation.Validation.Val_EmailFormat(txtCorreo.Text))
            {
                errCorreo.SetError(txtCorreo, "El correo ingresado no tiene el formato correcto.\nPor favor ingrese una dirección de correo válida.\nEjemplo: micorreo@diminio.com");
                valCorreo.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errCorreo.Clear();
                valCorreo.BackColor = Color.FromArgb(0, 100, 182);
            }
            if (!Validation.Validation.Val_StringsLength(txtDireccion.Text, 20))
            {
                errDireccion.SetError(txtDireccion, "La dirección ingresada no tiene la longitud correcta.\nPor favor ingrese una dirección válida con un minimo de\n20 caracteres.");
                valDireccion.BackColor = Color.Red;
            }
            else
            {
                errDireccion.Clear();
                valDireccion.BackColor = Color.FromArgb(0, 100, 182);
            }
            valFechaNac.BackColor = Color.FromArgb(0, 100, 182);
            if (cmbCargo.Enabled)
            {
                if ((cmbCargo.SelectedValue == null))
                {
                    errCargo.SetError(txtDireccion, "No ha seleccionado ningun cargo para el\nempleado en proceso de registro.");
                    valCargo.BackColor = Color.Red;
                    result = false;
                }
                else
                {
                    errCargo.Clear();
                    valCargo.BackColor = Color.FromArgb(0, 100, 182);
                }
            }

            if (!Validation.Validation.Val_StringsLength(txtDireccion.Text, 20))
            {
                errDireccion.SetError(txtDireccion, "La dirección ingresada no tiene la longitud correcta.\nPor favor ingrese una dirección válida con un minimo de\n20 caracteres.");
                valDireccion.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errDireccion.Clear();
                valDireccion.BackColor = Color.FromArgb(0, 100, 182);
            }
            return result;
        }
        private bool val_UPDObject()
        {
            bool result = true;
            if (!Validation.Validation.Val_NameFormat(txtNombre.Text))
            {
                errNombre.SetError(txtNombre, "El nombre ingresado no tiene el formato correcto.\nPor favor ingrese el nombre completo utilizando\n solo caracteres válidos del alfabeto.");
                valNombre.BackColor = Color.Red;
                result = false;
            }
            else
            {
                EditingObject.Empleado.Persona.Nombre = txtNombre.Text;
                errNombre.Clear();
                valNombre.BackColor = Color.FromArgb(0, 100, 182);
            }
            if (!Validation.Validation.Val_CellphoneFormat(txtTelefono.Text))
            {
                errTelefono.SetError(txtTelefono, "El telefono ingresado no tiene el formato correcto.\nPor favor ingrese un número telefónico válido en uno de\n los siguientes formatos: 22222222,+5037777777 o (+503)77777777.");
                valTelefono.BackColor = Color.Red;
                result = false;
            }
            else
            {
                EditingObject.Empleado.Telefono = txtTelefono.Text;
                errTelefono.Clear();
                valTelefono.BackColor = Color.FromArgb(0, 100, 182);
            }
            if (txtDui.Text != CurrentObject.Empleado.Persona.Dui)
            {
                if (!Validation.Validation.Val_DuiFormat(txtDui.Text))
                {
                    errDui.SetError(txtDui, "El dui ingresado no tiene el formato correcto.\nPor favor ingrese un úumero de dui válido.\nEjemplo: 12345678-9");
                    valDui.BackColor = Color.Red;
                    result = false;
                }
                else
                {
                    EditingObject.Empleado.Persona.Dui = txtDui.Text;
                    errDui.Clear();
                    valDui.BackColor = Color.FromArgb(0, 100, 182);
                }
                if (EmpleadoDAL.getEmpleadoByDuiNit(txtDui.Text, "") != null)
                {
                    errDui.SetError(txtCorreo, "Ya existe un empleado con este numero de dui registrado en el sistema");
                    valDui.BackColor = Color.Red;
                    result = false;

                }
                else
                {
                    EditingObject.Empleado.Persona.Dui = txtDui.Text;
                    errDui.Clear();
                    valDui.BackColor = Color.FromArgb(0, 100, 182);
                }
            }
            if (txtNit.Text != CurrentObject.Empleado.Persona.Nit)
            {
                if (!Validation.Validation.Val_NitFormat(txtNit.Text))
                {
                    errNit.SetError(txtNit, "El nit ingresado no tiene el formato correcto.\nPor favor ingrese un número de nit válido.\nEjemplo: 0000-000000-000-0");
                    valNit.BackColor = Color.Red;
                    result = false;
                }
                else
                {
                    EditingObject.Empleado.Persona.Nit = txtNit.Text;
                    errNit.Clear();
                    valNit.BackColor = Color.FromArgb(0, 100, 182);
                }
                if (EmpleadoDAL.getEmpleadoByDuiNit(txtNit.Text, "") != null)
                {
                    errNit.SetError(txtCorreo, "Ya existe un empleado con este numero de nit registrado en el sistema");
                    valNit.BackColor = Color.Red;
                    result = false;
                }
                else
                {
                    EditingObject.Empleado.Persona.Nit = txtNit.Text;
                    errNit.Clear();
                    valNit.BackColor = Color.FromArgb(0, 100, 182);
                }

            }
            if (!Validation.Validation.Val_EmailFormat(txtCorreo.Text))
            {
                errCorreo.SetError(txtCorreo, "El correo ingresado no tiene el formato correcto.\nPor favor ingrese una dirección de correo válida.\nEjemplo: micorreo@diminio.com");
                valCorreo.BackColor = Color.Red;
                result = false;
            }
            else
            {
                EditingObject.Empleado.Correo = txtCorreo.Text;

                errCorreo.Clear();
                valCorreo.BackColor = Color.FromArgb(0, 100, 182);
            }
            if (!Validation.Validation.Val_StringsLength(txtDireccion.Text, 20))
            {
                errDireccion.SetError(txtDireccion, "La dirección ingresada no tiene la longitud correcta.\nPor favor ingrese una dirección válida con un minimo de\n20 caracteres.");
                valDireccion.BackColor = Color.Red;
            }
            else
            {
                EditingObject.Empleado.Correo = txtCorreo.Text;
                errDireccion.Clear();
                valDireccion.BackColor = Color.FromArgb(0, 100, 182);
            }
            valFechaNac.BackColor = Color.FromArgb(0, 100, 182);
            if (!Validation.Validation.Val_StringsLength(txtDireccion.Text, 20))
            {
                errDireccion.SetError(txtDireccion, "La dirección ingresada no tiene la longitud correcta.\nPor favor ingrese una dirección válida con un minimo de\n20 caracteres.");
                valDireccion.BackColor = Color.Red;
                result = false;
            }
            else
            {
                EditingObject.Empleado.Persona.Direccion = txtDireccion.Text;
                errDireccion.Clear();
                valDireccion.BackColor = Color.FromArgb(0, 100, 182);
            }
            return result;
        }
        private bool val_NewObjectContrato()
        {
            bool result = true;

            if (ContratoDAL.getContratosAByIdEmpleado(CurrentObject.IdEmpleado).Where(a => a.IdCargo == EditingObject.IdCargo).ToList().Count > 0)
            {
                errCargo.SetError(cmbCargo, "Ya posee un contrato activo con el cargo seleccionado.");
                valCargo.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errCargo.Clear();
                valCargo.BackColor = Color.FromArgb(0, 100, 182);
            }
            return result;
        }
        private bool val_UPDObjectContrato()
        {
            bool result = true;
            if (EditingObject.IdCargo != CurrentObject.IdCargo)
            {

                if (ContratoDAL.getContratosAByIdEmpleado(CurrentObject.IdEmpleado).Where(a => a.IdCargo == EditingObject.IdCargo).ToList().Count > 0)
                {
                    errCargo.SetError(cmbCargo, "Ya posee otro contrato activo con el cargo seleccionado.");
                    valCargo.BackColor = Color.Red;
                    result = false;
                }
                else
                {
                    errCargo.Clear();
                    valCargo.BackColor = Color.FromArgb(0, 100, 182);
                }
            }
            return result;
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            switch ((sender as Control).Name)
            {
                case "txtNombre":
                    if (txtNombre.Text.Length == 0)
                    {
                        valNombre.BackColor = Color.Gray;
                        if (valNombre.BackColor == Color.Gray &&
                            valTelefono.BackColor == Color.Gray &&
                            valDui.BackColor == Color.Gray &&
                            valNit.BackColor == Color.Gray &&
                            valCorreo.BackColor == Color.Gray &&
                            valDireccion.BackColor == Color.Gray &&
                            valCargo.BackColor == Color.Gray)
                        {
                            errNombre.Clear();
                            valNombre.BackColor = Color.Gray;
                            if (EditingObject != null)
                            {
                                EditingObject = null;
                            }
                        }
                        else
                        {
                            EditingObject = EditingObject != null ? EditingObject : new Contrato();
                            EditingObject.Empleado = EditingObject.Empleado != null ? EditingObject.Empleado : new Empleado();
                            EditingObject.Empleado.Persona = EditingObject.Empleado.Persona != null ? EditingObject.Empleado.Persona : new Persona();
                            EditingObject.Empleado.Persona.Nombre = txtNombre.Text;
                            errNombre.Clear();
                            valNombre.BackColor = Color.Gray;
                        }
                    }
                    else
                    {
                        if (!Validation.Validation.Val_NameFormat(txtNombre.Text))
                        {
                            errNombre.SetError(txtNombre, "El nombre ingresado no tiene el formato correcto.\nPor favor ingrese el nombre completo utilizando\n solo caracteres válidos del alfabeto.");
                            valNombre.BackColor = Color.Red;
                        }
                        else
                        {
                            errNombre.Clear();
                            valNombre.BackColor = Color.FromArgb(0, 100, 182);
                            EditingObject = EditingObject != null ? EditingObject : new Contrato();
                            EditingObject.Empleado = EditingObject.Empleado != null ? EditingObject.Empleado : new Empleado();
                            EditingObject.Empleado.Persona = EditingObject.Empleado.Persona != null ? EditingObject.Empleado.Persona : new Persona();
                            EditingObject.Empleado.Persona.Nombre = txtNombre.Text;
                        }
                    }
                    break;
                case "txtTelefono":
                    if (txtTelefono.Text.Length == 0)
                    {
                        valTelefono.BackColor = Color.Gray;
                        if (valNombre.BackColor == Color.Gray &&
                            valTelefono.BackColor == Color.Gray &&
                            valDui.BackColor == Color.Gray &&
                            valNit.BackColor == Color.Gray &&
                            valCorreo.BackColor == Color.Gray &&
                            valDireccion.BackColor == Color.Gray &&
                            valCargo.BackColor == Color.Gray)
                        {
                            errTelefono.Clear();
                            valTelefono.BackColor = Color.Gray;
                            if (EditingObject != null)
                            {
                                EditingObject = null;
                            }
                        }
                        else
                        {
                            EditingObject = EditingObject != null ? EditingObject : new Contrato();
                            EditingObject.Empleado = EditingObject.Empleado != null ? EditingObject.Empleado : new Empleado();
                            EditingObject.Empleado.Telefono = txtTelefono.Text;
                            errTelefono.Clear();
                            valTelefono.BackColor = Color.Gray;
                        }
                    }
                    else
                    {
                        if (!Validation.Validation.Val_CellphoneFormat(txtTelefono.Text))
                        {
                            errTelefono.SetError(txtTelefono, "El telefono ingresado no tiene el formato correcto.\nPor favor ingrese un numero telefónico valido en uno de\n los siguientes formatos: 22222222,+5037777777 o (+503)77777777.");
                            valTelefono.BackColor = Color.Red;

                        }
                        else
                        {
                            errTelefono.Clear();
                            valTelefono.BackColor = Color.FromArgb(0, 100, 182);
                            EditingObject = EditingObject != null ? EditingObject : new Contrato();
                            EditingObject.Empleado = EditingObject.Empleado != null ? EditingObject.Empleado : new Empleado();
                            EditingObject.Empleado.Telefono = txtTelefono.Text;
                        }

                    }
                    break;
                case "txtDui":
                    if (txtDui.Text.Length == 0)
                    {
                        valDui.BackColor = Color.Gray;
                        if (valDui.BackColor == Color.Gray &&
                            valTelefono.BackColor == Color.Gray &&
                            valDui.BackColor == Color.Gray &&
                            valNit.BackColor == Color.Gray &&
                            valCorreo.BackColor == Color.Gray &&
                            valDireccion.BackColor == Color.Gray &&
                            valCargo.BackColor == Color.Gray)
                        {
                            errDui.Clear();
                            valDui.BackColor = Color.Gray;
                            if (EditingObject != null)
                            {
                                EditingObject = null;
                            }
                        }
                        else
                        {
                            EditingObject = EditingObject != null ? EditingObject : new Contrato();
                            EditingObject.Empleado = EditingObject.Empleado != null ? EditingObject.Empleado : new Empleado();
                            EditingObject.Empleado.Persona = EditingObject.Empleado.Persona != null ? EditingObject.Empleado.Persona : new Persona();
                            EditingObject.Empleado.Persona.Dui = txtDui.Text;

                            errDui.Clear();
                            valDui.BackColor = Color.Gray;
                        }
                    }
                    else
                    {
                        if (!Validation.Validation.Val_DuiFormat(txtDui.Text))
                        {
                            errDui.SetError(txtDui, "El dui ingresado no tiene el formato correcto.\nPor favor ingrese un úumero de dui válido.\nEjemplo: 12345678-9");
                            valDui.BackColor = Color.Red;

                        }
                        else
                        {
                            errDui.Clear();
                            valDui.BackColor = Color.FromArgb(0, 100, 182);
                            EditingObject = EditingObject != null ? EditingObject : new Contrato();
                            EditingObject.Empleado = EditingObject.Empleado != null ? EditingObject.Empleado : new Empleado();
                            EditingObject.Empleado.Persona = EditingObject.Empleado.Persona != null ? EditingObject.Empleado.Persona : new Persona();
                            EditingObject.Empleado.Persona.Dui = txtDui.Text;
                        }

                    }
                    break;
                case "txtNit":
                    if (txtNit.Text.Length == 0)
                    {
                        valDui.BackColor = Color.Gray;
                        if (valDui.BackColor == Color.Gray &&
                            valTelefono.BackColor == Color.Gray &&
                            valDui.BackColor == Color.Gray &&
                            valNit.BackColor == Color.Gray &&
                            valCorreo.BackColor == Color.Gray &&
                            valDireccion.BackColor == Color.Gray &&
                            valCargo.BackColor == Color.Gray)
                        {
                            errNit.Clear();
                            valNit.BackColor = Color.Gray;
                            if (EditingObject != null)
                            {
                                EditingObject = null;
                            }
                        }
                        else
                        {
                            EditingObject = EditingObject != null ? EditingObject : new Contrato();
                            EditingObject.Empleado = EditingObject.Empleado != null ? EditingObject.Empleado : new Empleado();
                            EditingObject.Empleado.Persona = EditingObject.Empleado.Persona != null ? EditingObject.Empleado.Persona : new Persona();
                            EditingObject.Empleado.Persona.Nit = txtNit.Text;

                            errNit.Clear();
                            valNit.BackColor = Color.Gray;
                        }
                    }
                    else
                    {
                        if (!Validation.Validation.Val_NitFormat(txtNit.Text))
                        {
                            errNit.SetError(txtNit, "El nit ingresado no tiene el formato correcto.\nPor favor ingrese un número de nit válido.\nEjemplo: 0000-000000-000-0");
                            valNit.BackColor = Color.Red;

                        }
                        else
                        {
                            errNit.Clear();
                            valNit.BackColor = Color.FromArgb(0, 100, 182);
                            EditingObject = EditingObject != null ? EditingObject : new Contrato();
                            EditingObject.Empleado = EditingObject.Empleado != null ? EditingObject.Empleado : new Empleado();
                            EditingObject.Empleado.Persona.Nit = txtNit.Text;
                        }

                    }
                    break;
                case "txtCorreo":
                    if (txtCorreo.Text.Length == 0)
                    {
                        valCorreo.BackColor = Color.Gray;
                        if (valNombre.BackColor == Color.Gray &&
                            valTelefono.BackColor == Color.Gray &&
                            valDui.BackColor == Color.Gray &&
                            valNit.BackColor == Color.Gray &&
                            valCorreo.BackColor == Color.Gray &&
                            valDireccion.BackColor == Color.Gray &&
                            valCargo.BackColor == Color.Gray)
                        {
                            errCorreo.Clear();
                            valCorreo.BackColor = Color.Gray;
                            if (EditingObject != null)
                            {
                                EditingObject = null;
                            }
                        }
                        else
                        {
                            EditingObject = EditingObject != null ? EditingObject : new Contrato();
                            EditingObject.Empleado = EditingObject.Empleado != null ? EditingObject.Empleado : new Empleado();
                            EditingObject.Empleado.Correo = txtCorreo.Text;
                            errCorreo.Clear();
                            valCorreo.BackColor = Color.Gray;
                        }
                    }
                    else
                    {
                        if (!Validation.Validation.Val_EmailFormat(txtCorreo.Text))
                        {
                            errCorreo.SetError(txtCorreo, "El correo ingresado no tiene el formato correcto.\nPor favor ingrese una dirección de correo válida.\nEjemplo: micorreo@diminio.com");
                            valCorreo.BackColor = Color.Red;

                        }
                        else
                        {
                            errCorreo.Clear();
                            valCorreo.BackColor = Color.FromArgb(0, 100, 182);
                            EditingObject = EditingObject != null ? EditingObject : new Contrato();
                            EditingObject.Empleado = EditingObject.Empleado != null ? EditingObject.Empleado : new Empleado();
                            EditingObject.Empleado.Correo = txtCorreo.Text;
                        }

                    }
                    break;
                case "dtpFechaNac":

                    EditingObject = EditingObject != null ? EditingObject : new Contrato();
                    EditingObject.Empleado = EditingObject.Empleado != null ? EditingObject.Empleado : new Empleado();
                    EditingObject.Empleado.Persona = EditingObject.Empleado.Persona != null ? EditingObject.Empleado.Persona : new Persona();
                    EditingObject.Empleado.Persona.FechaNac = dtpFechaNac.Value.ToString("yyyy/MM/dd");
                    errFechaNac.Clear();
                    valFechaNac.BackColor = Color.FromArgb(0, 100, 182);
                    break;
                case "cmbCargo":

                    EditingObject = EditingObject != null ? EditingObject : new Contrato();
                    EditingObject.Cargo = EditingObject.Cargo != null ? EditingObject.Cargo : new Cargo();
                    EditingObject.IdCargo = (cmbCargo.SelectedValue == null) ? 0 : Convert.ToInt32(cmbCargo.SelectedValue);
                    errCargo.Clear();
                    valCargo.BackColor = Color.FromArgb(0, 100, 182);
                    break;
                case "txtDireccion":
                    if (txtDireccion.Text.Length == 0)
                    {
                        valDui.BackColor = Color.Gray;
                        if (valDui.BackColor == Color.Gray &&
                            valTelefono.BackColor == Color.Gray &&
                            valDui.BackColor == Color.Gray &&
                            valNit.BackColor == Color.Gray &&
                            valCorreo.BackColor == Color.Gray &&
                            valDireccion.BackColor == Color.Gray &&
                            valCargo.BackColor == Color.Gray)
                        {
                            errDireccion.Clear();
                            valDireccion.BackColor = Color.Gray;
                            if (EditingObject != null)
                            {
                                EditingObject = null;
                            }
                        }
                        else
                        {
                            EditingObject = EditingObject != null ? EditingObject : new Contrato();
                            EditingObject.Empleado = EditingObject.Empleado != null ? EditingObject.Empleado : new Empleado();
                            EditingObject.Empleado.Persona = EditingObject.Empleado.Persona != null ? EditingObject.Empleado.Persona : new Persona();
                            EditingObject.Empleado.Persona.Direccion = txtDireccion.Text;

                            errDireccion.Clear();
                            valDireccion.BackColor = Color.Gray;
                        }
                    }
                    else
                    {
                        if (!Validation.Validation.Val_StringsLength(txtDireccion.Text, 20))
                        {
                            errDireccion.SetError(txtDireccion, "La dirección ingresada no tiene la longitud correcta.\nPor favor ingrese una dirección válida con un minimo de\n20 caracteres.");
                            valDireccion.BackColor = Color.Red;

                        }
                        else
                        {
                            errDireccion.Clear();
                            valDireccion.BackColor = Color.FromArgb(0, 100, 182);
                            EditingObject = EditingObject != null ? EditingObject : new Contrato();
                            EditingObject.Empleado = EditingObject.Empleado != null ? EditingObject.Empleado : new Empleado();
                            EditingObject.Empleado.Persona = EditingObject.Empleado.Persona != null ? EditingObject.Empleado.Persona : new Persona();
                            EditingObject.Empleado.Persona.Direccion = txtDireccion.Text;
                        }

                    }
                    break;
                default: break;
            }
        }

        private void txtDui_KeyUp(object sender, KeyEventArgs e)
        {
            switch (opc)
            {
                case "newEmpleado":
                    if (Validation.Validation.Val_DuiFormat(txtDui.Text))
                    {
                        Empleado emp = EmpleadoDAL.getEmpleadoByDuiNit(txtDui.Text, "");
                        if (emp != null)
                        {
                            if (MessageBox.Show("Ya existe un empleado con este número de dui.\n¿Desea utilizar los datos previamente registrados en el sistema?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                txtNombre.Text = emp.Persona.Nombre;
                                txtTelefono.Text = emp.Telefono;
                                txtNit.Text = emp.Persona.Nit;
                                txtCorreo.Text = emp.Correo;
                                dtpFechaNac.Value = Convert.ToDateTime(emp.Persona.FechaNac);
                                txtDireccion.Text = emp.Persona.Direccion;

                                EditingObject = EditingObject != null ? EditingObject : new Contrato();
                                EditingObject.Empleado = EditingObject.Empleado != null ? EditingObject.Empleado : emp;
                                val_NewObject();

                            }
                            else
                            {
                                EditingObject = EditingObject != null ? EditingObject : new Contrato();
                                EditingObject.Empleado = EditingObject.Empleado != null ? EditingObject.Empleado : new Empleado();
                                EditingObject.Empleado.Persona = EditingObject.Empleado.Persona != null ? EditingObject.Empleado.Persona : new Persona();
                                txtDui.Text = EditingObject.Empleado.Persona != null && EditingObject.Empleado.Persona.Id != 0 ? EditingObject.Empleado.Persona.Dui : "";
                            }
                        }
                    }
                    break;
                case "newContrato":

                    break;
                case "updContrato":

                    break;
                case "updEmpleado":
                    if (txtDui.Text != CurrentObject.Empleado.Persona.Dui && Validation.Validation.Val_DuiFormat(txtDui.Text))
                    {
                        Empleado emp = EmpleadoDAL.getEmpleadoByDuiNit(txtDui.Text, "");
                        if (emp != null)
                        {
                            errDui.SetError(txtCorreo, "Ya existe un empleado con este numero de dui registrado en el sistema");
                            valDui.BackColor = Color.Red;
                            EditingObject = EditingObject != null ? EditingObject : new Contrato();
                            EditingObject.Empleado = EditingObject.Empleado != null ? EditingObject.Empleado : new Empleado();
                            EditingObject.Empleado.Persona = EditingObject.Empleado.Persona != null ? EditingObject.Empleado.Persona : new Persona();
                            EditingObject.Empleado.Persona.Dui = txtDui.Text;

                        }
                    }
                    break;
                default: break;
            }
        }

        private void txtNit_KeyUp(object sender, KeyEventArgs e)
        {
            switch (opc)
            {
                case "newEmpleado":
                    if (Validation.Validation.Val_NitFormat(txtNit.Text))
                    {
                        Empleado emp = EmpleadoDAL.getEmpleadoByDuiNit(txtNit.Text, "");
                        if (emp != null)
                        {
                            if (MessageBox.Show("Ya existe un empleado con este número de nit.\n¿Desea utilizar los datos previamente registrados en el sistema?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                txtNombre.Text = emp.Persona.Nombre;
                                txtTelefono.Text = emp.Telefono;
                                txtDui.Text = emp.Persona.Dui;
                                txtCorreo.Text = emp.Correo;
                                dtpFechaNac.Value = Convert.ToDateTime(emp.Persona.FechaNac);
                                txtDireccion.Text = emp.Persona.Direccion;
                                EditingObject = EditingObject != null ? EditingObject : new Contrato();
                                EditingObject.Empleado = EditingObject.Empleado != null ? EditingObject.Empleado : emp;
                                val_NewObject();
                            }
                            else
                            {
                                EditingObject = EditingObject != null ? EditingObject : new Contrato();
                                EditingObject.Empleado = EditingObject.Empleado != null ? EditingObject.Empleado : new Empleado();
                                EditingObject.Empleado.Persona = EditingObject.Empleado.Persona != null ? EditingObject.Empleado.Persona : new Persona();
                                txtNit.Text = EditingObject.Empleado.Persona != null && EditingObject.Empleado.Persona.Id != 0 ? EditingObject.Empleado.Persona.Nit : "";
                            }
                        }
                    }
                    break;
                case "newContrato":

                    break;
                case "updContrato":

                    break;
                case "updEmpleado":
                    if (txtNit.Text != CurrentObject.Empleado.Persona.Nit && Validation.Validation.Val_NitFormat(txtNit.Text))
                    {
                        Empleado emp = EmpleadoDAL.getEmpleadoByDuiNit(txtNit.Text, "");
                        if (emp != null)
                        {
                            errNit.SetError(txtCorreo, "Ya existe un empleado con este numero de nit registrado en el sistema");
                            valNit.BackColor = Color.Red;
                            EditingObject = EditingObject != null ? EditingObject : new Contrato();
                            EditingObject.Empleado = EditingObject.Empleado != null ? EditingObject.Empleado : new Empleado();
                            EditingObject.Empleado.Persona = EditingObject.Empleado.Persona != null ? EditingObject.Empleado.Persona : new Persona();
                            EditingObject.Empleado.Persona.Nit = txtNit.Text;
                        }
                    }

                    break;
                default: break;
            }

        }

        private void FrmEmpleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (opc)
            {
                case "newEmpleado":
                    if (EditingObject != null)
                    {
                        if (MessageBox.Show("¿Seguro que desea salir? hay cambios sin guardar que se perderan.", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            e.Cancel = true;
                        }
                    }
                    break;
                case "newContrato":
                    break;
                case "updContrato":
                    break;
                case "updEmpleado":
                    break;
                default: break;
            }
        }
    }
}
