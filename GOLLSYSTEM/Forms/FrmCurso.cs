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
    public partial class FrmCurso : Form
    {
        public Curso CurrentObject;
        public Curso EditingObject;
        public Curso NewObject;

        public string opc;
        public FrmCurso()
        {
            InitializeComponent();
        }

        private void FrmCurso_Load(object sender, EventArgs e)
        {
            try
            {
                cmbDias.Items.Add("Lunes");
                cmbDias.Items.Add("Martes");
                cmbDias.Items.Add("Miércoles");
                cmbDias.Items.Add("Jueves");
                cmbDias.Items.Add("Viernes");
                cmbDias.Items.Add("Sábado");
                cmbDias.Items.Add("Domingo");
                cmbDias.SelectedIndex = 0;

                cmbPublico.Items.Add("Niños");
                cmbPublico.Items.Add("Adolecentes");
                cmbPublico.Items.Add("Adultos");
                cmbPublico.Items.Add("Niños y Adolecentes");
                cmbPublico.Items.Add("Adolecentes y Adultos");
                cmbPublico.Items.Add("Todos");
                cmbPublico.SelectedIndex = 0;

                if (opc == "updObject")
                {
                    LstPermiso permiso = Inicio.CurrentUser.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Permisos.Where(a => a.Permiso.Nombre == "Editar Cursos").FirstOrDefault();
                    btnGuardar.Enabled = !(permiso == null || permiso.Otorgado == false);
                    
                    txtNombre.Text = CurrentObject.Nombre;
                    btnAddLibro.Enabled = false;
                    btnRemoveLibro.Enabled = false;

                    switch (CurrentObject.Publico)
                    {
                        case "Niños":
                            cmbPublico.SelectedIndex = 0;
                            break;
                        case "Adolecentes":
                            cmbPublico.SelectedIndex = 1;
                            break;
                        case "Adultos":
                            cmbPublico.SelectedIndex = 2;
                            break;
                        case "Niños y Adolecentes":
                            cmbPublico.SelectedIndex = 3;
                            break;
                        case "Adolecentes y Adultos":
                            cmbPublico.SelectedIndex = 4;
                            break;
                        case "Todos":
                            cmbPublico.SelectedIndex = 5;
                            break;
                        default: break;

                    }
                    dtpDesde.Value = Convert.ToDateTime(CurrentObject.Desde);
                    dtpHasta.Value = Convert.ToDateTime(CurrentObject.Hasta);
                    txtSeccion.Text = CurrentObject.Seccion;
                    chkEstado.Checked = CurrentObject.Estado == "A";
                    txtEncargado.Text = CurrentObject.Contrato.Empleado.Persona.Nombre;

                    foreach (Dia dia in CurrentObject.Horario) dgvHorario.Rows.Add(dia.Id, dia.Nombre, dia.HEntrada, dia.HSalida);
                    foreach (Detcurso libro in CurrentObject.Libros) dgvDeCurso.Rows.Add(libro.Id, libro.Libro.Nombre, libro.Libro.Edicion, libro.Libro.Nivel, libro.Libro.NActividades, libro.Libro.Id);


                }
                else
                {
                    LstPermiso permiso2 = Inicio.CurrentUser.Sucursales.Where(a => a.IdSucursal == Inicio.CurrentSucursal.Id).FirstOrDefault().Permisos.Where(a => a.Permiso.Nombre == "Crear Cursos").FirstOrDefault();
                    btnGuardar.Enabled = !(permiso2 == null || permiso2.Otorgado == false);
                }
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
        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarEmpleado buscarEmpleado = new frmBuscarEmpleado();
                buscarEmpleado.ShowDialog();
                if (buscarEmpleado.CurrentObject != null)
                {
                    EditingObject = EditingObject != null ? EditingObject : new Curso();
                    EditingObject.Contrato = null;
                    EditingObject.Contrato = EditingObject.Contrato != null ? null : buscarEmpleado.CurrentObject;

                    txtEncargado.Text = buscarEmpleado.CurrentObject.Empleado.Persona.Nombre;
                    errEncargado.Clear();
                    valEncargado.BackColor = Color.FromArgb(0, 100, 182);
                }
            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ha ocurrido un error al intentar cargar el docente en este control");
                MessageBox.Show("Ha ocurrido un error al intentar cargar el docente en este control, por favor comuniquese con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAddLibro_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarLibro buscarLibro = new frmBuscarLibro();
                buscarLibro.ShowDialog();
                if (buscarLibro.CurrentObject != null)
                {

                    EditingObject = EditingObject != null ? EditingObject : new Curso();
                    EditingObject.Libros = EditingObject.Libros != null ? EditingObject.Libros : new List<Detcurso>();
                    if (EditingObject.Libros.Where(a => a.Id == buscarLibro.CurrentObject.Id).FirstOrDefault() == null)
                    {
                        EditingObject.Libros.Add(new Detcurso(
                            0,
                            "",
                            "",
                            buscarLibro.CurrentObject.Id,
                            0,
                            buscarLibro.CurrentObject));
                        dgvDeCurso.Rows.Add(0,
                            buscarLibro.CurrentObject.Nombre,
                            buscarLibro.CurrentObject.Edicion,
                            buscarLibro.CurrentObject.Nivel,
                            buscarLibro.CurrentObject.NActividades,
                            buscarLibro.CurrentObject.Id
                            );
                    }
                    errDetCurso.Clear();
                    valDetCurso.BackColor = Color.FromArgb(0, 100, 182);
                }
            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ha ocurrido un error al intentar cargar el libro en este control");
                MessageBox.Show("Ha ocurrido un error al intentar cargar el libro en este control, por favor comuniquese con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveLibro_Click(object sender, EventArgs e)
        {
            EditingObject = EditingObject != null ? EditingObject : new Curso();
            EditingObject.Libros = EditingObject.Libros != null ? EditingObject.Libros : new List<Detcurso>();
            if (dgvDeCurso.CurrentRow != null && EditingObject.Libros.Where(a => a.IdLibro == (Int64)dgvDeCurso.CurrentRow.Cells["idlibro"].Value).FirstOrDefault() != null)
            {
                EditingObject.Libros.Remove(EditingObject.Libros.Where(a => a.IdLibro == (Int64)dgvDeCurso.CurrentRow.Cells["idlibro"].Value).FirstOrDefault());
                dgvDeCurso.Rows.Remove(dgvDeCurso.CurrentRow);

            }
            if (dgvDeCurso.Rows.Count == 0)
            {
                valDetCurso.BackColor = Color.Gray;
            }

        }

        private void btnAddDia_Click(object sender, EventArgs e)
        {
            gbxDia.Enabled = true;
            btnAddDia.Enabled = false;
            btnRemoveDia.Enabled = false;

        }
        private void clear_Dia()
        {
            cmbDias.SelectedIndex = 0;
            btnAddDia.Enabled = true;
            btnRemoveDia.Enabled = true;
            gbxDia.Enabled = false;
        }

        private void btnRemoveDia_Click(object sender, EventArgs e)
        {

            EditingObject = EditingObject != null ? EditingObject : new Curso();
            EditingObject.Horario = EditingObject.Horario != null ? EditingObject.Horario : new List<Dia>();

            if (dgvHorario.CurrentRow != null && EditingObject.Horario.Where(a => a.Nombre == (string)dgvHorario.CurrentRow.Cells[1].Value).FirstOrDefault() != null)
            {
                EditingObject.Horario.Remove(EditingObject.Horario.Where(a => a.Nombre == (string)dgvHorario.CurrentRow.Cells[1].Value).FirstOrDefault());
                dgvHorario.Rows.Remove(dgvHorario.CurrentRow);
            }
            if (dgvHorario.Rows.Count == 0)
            {
                valHorario.BackColor = Color.Gray;
            }
        }

        private void btnCancelarDia_Click(object sender, EventArgs e)
        {
            clear_Dia();
        }

        private void btnAceptarDia_Click(object sender, EventArgs e)
        {
            if (val_newDia())
            {
                valEntrada.BackColor = Color.Gray;
                EditingObject = EditingObject != null ? EditingObject : new Curso();
                EditingObject.Horario = EditingObject.Horario != null ? EditingObject.Horario : new List<Dia>();
                if (EditingObject.Horario.Where(a => a.Nombre == cmbDias.SelectedItem.ToString()).FirstOrDefault() == null)
                {
                    EditingObject.Horario.Add(new Dia(0, cmbDias.SelectedItem.ToString(), dtpHEntrada.Value.ToString("hh:mm") + ":00", dtpHSalida.Value.ToString("hh:mm") + ":00", 0));
                    dgvHorario.Rows.Add(0, cmbDias.SelectedItem.ToString(), dtpHEntrada.Value.ToString("hh:mm") + ":00", dtpHSalida.Value.ToString("hh:mm") + ":00");
                    errHorario.Clear();
                    valHorario.BackColor = Color.FromArgb(0, 100, 182);
                }
                else
                {
                    errHorario.SetError(dgvHorario, "Ya existe dia " + cmbDias.SelectedItem.ToString() + " en el horario para este curso.");

                    valHorario.BackColor = Color.Red;
                }
                clear_Dia();
            }
        }
        private bool val_newDia()
        {
            bool result = true;
            if (dtpHEntrada.Value.TimeOfDay > dtpHSalida.Value.TimeOfDay)
            {
                errEntrada.SetError(dtpHEntrada, "La hora de entrada no puede ser mayor a la hora de salida.");
                valEntrada.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errEntrada.Clear();
                valEntrada.BackColor = Color.FromArgb(0, 100, 182);
            }
            return result;
        }
        private void btnRemoveEncargado_Click(object sender, EventArgs e)
        {
            EditingObject = EditingObject != null ? EditingObject : new Curso();
            EditingObject.Contrato = EditingObject.Contrato != null ? EditingObject.Contrato : null;
            txtEncargado.Text = "";
            valEncargado.BackColor = Color.FromArgb(0, 100, 182);
            errEncargado.Clear();

        }
        private void dtpFechaNac_Leave(object sender, EventArgs e)
        {
            switch ((sender as Control).Name)
            {
                case "txtNombre":
                    if (txtNombre.Text.Length == 0)
                    {
                        valNombre.BackColor = Color.Gray;
                        if (valNombre.BackColor == Color.Gray &&
                            valDesde.BackColor == Color.Gray &&
                            valHasta.BackColor == Color.Gray &&
                            valSeccion.BackColor == Color.Gray &&
                            valEncargado.BackColor == Color.Gray)
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
                            EditingObject = EditingObject != null ? EditingObject : new Curso();
                            EditingObject.Nombre = txtNombre.Text;
                            errNombre.Clear();
                            valNombre.BackColor = Color.Gray;
                        }
                    }
                    else
                    {
                        if (!Validation.Validation.Val_StringsLength(txtNombre.Text, 5))
                        {
                            errNombre.SetError(txtNombre, "El nombre del curso debe tener al menos 5 caracteres.");
                            valNombre.BackColor = Color.Red;
                        }
                        else
                        {
                            errNombre.Clear();
                            valNombre.BackColor = Color.FromArgb(0, 100, 182);
                            EditingObject = EditingObject != null ? EditingObject : new Curso();
                            EditingObject.Nombre = txtNombre.Text;
                        }
                    }
                    break;
                case "dtpDesde":
                    if (dtpDesde.Value == null)
                    {
                        valDesde.BackColor = Color.Gray;
                        if (valNombre.BackColor == Color.Gray &&
                            valDesde.BackColor == Color.Gray &&
                            valHasta.BackColor == Color.Gray &&
                            valSeccion.BackColor == Color.Gray &&
                            valEncargado.BackColor == Color.Gray)
                        {
                            errDesde.Clear();
                            valDesde.BackColor = Color.Gray;
                            if (EditingObject != null)
                            {
                                EditingObject = null;
                            }
                        }
                        else
                        {
                            EditingObject = EditingObject != null ? EditingObject : new Curso();
                            EditingObject.Desde = "";
                            errDesde.Clear();
                            valDesde.BackColor = Color.Gray;
                        }
                    }
                    else
                    {
                        errDesde.Clear();
                        valDesde.BackColor = Color.FromArgb(0, 100, 182);
                        EditingObject = EditingObject != null ? EditingObject : new Curso();
                        EditingObject.Desde = dtpDesde.Value.ToString("yyyy/MM/dd");

                    }
                    break;
                case "dtpHasta":
                    if (dtpHasta.Value == null)
                    {
                        valHasta.BackColor = Color.Gray;
                        if (valNombre.BackColor == Color.Gray &&
                            valDesde.BackColor == Color.Gray &&
                            valHasta.BackColor == Color.Gray &&
                            valSeccion.BackColor == Color.Gray &&
                            valEncargado.BackColor == Color.Gray)
                        {
                            errHasta.Clear();
                            valHasta.BackColor = Color.Gray;
                            if (EditingObject != null)
                            {
                                EditingObject = null;
                            }
                        }
                        else
                        {
                            EditingObject = EditingObject != null ? EditingObject : new Curso();
                            EditingObject.Hasta = "";
                            errHasta.Clear();
                            valHasta.BackColor = Color.Gray;
                        }
                    }
                    else
                    {
                        errHasta.Clear();
                        valHasta.BackColor = Color.FromArgb(0, 100, 182);
                        EditingObject = EditingObject != null ? EditingObject : new Curso();
                        EditingObject.Hasta = dtpHasta.Value.ToString("yyyy/MM/dd");

                    }
                    break;
                case "txtSeccion":
                    if (txtSeccion.Text.Length == 0)
                    {
                        valSeccion.BackColor = Color.Gray;
                        if (valNombre.BackColor == Color.Gray &&
                            valDesde.BackColor == Color.Gray &&
                            valHasta.BackColor == Color.Gray &&
                            valSeccion.BackColor == Color.Gray &&
                            valEncargado.BackColor == Color.Gray)
                        {
                            errSeccion.Clear();
                            valSeccion.BackColor = Color.Gray;
                            if (EditingObject != null)
                            {
                                EditingObject = null;
                            }
                        }
                        else
                        {
                            EditingObject = EditingObject != null ? EditingObject : new Curso();
                            EditingObject.Seccion = txtSeccion.Text;
                            errSeccion.Clear();
                            valSeccion.BackColor = Color.Gray;
                        }
                    }
                    else
                    {
                        if (!Validation.Validation.Val_StringsLength(txtSeccion.Text.Trim(), 1))
                        {
                            errSeccion.SetError(txtNombre, "El nombre de la sección debe tener al menos 1 caracter.");
                            valSeccion.BackColor = Color.Red;
                        }
                        else
                        {
                            errSeccion.Clear();
                            valSeccion.BackColor = Color.FromArgb(0, 100, 182);
                            EditingObject = EditingObject != null ? EditingObject : new Curso();
                            EditingObject.Seccion = txtSeccion.Text;
                        }
                    }
                    break;
                case "cmbPublico":
                    if (cmbPublico.SelectedItem.ToString() == "")
                    {
                        valPublico.BackColor = Color.Gray;
                        if (valNombre.BackColor == Color.Gray &&
                            valDesde.BackColor == Color.Gray &&
                            valHasta.BackColor == Color.Gray &&
                            valSeccion.BackColor == Color.Gray &&
                            valEncargado.BackColor == Color.Gray)
                        {
                            errPublico.Clear();
                            valPublico.BackColor = Color.Gray;
                            if (EditingObject != null)
                            {
                                EditingObject = null;
                            }
                        }
                        else
                        {
                            EditingObject = EditingObject != null ? EditingObject : new Curso();
                            EditingObject.Publico = cmbPublico.Text;
                            errPublico.Clear();
                            valPublico.BackColor = Color.Gray;
                        }
                    }
                    else
                    {
                        if (!Validation.Validation.Val_StringsLength(cmbPublico.SelectedItem.ToString().Trim(), 4))
                        {
                            errPublico.SetError(cmbPublico, "Debe seleccionar un publico para este curso.");
                            valPublico.BackColor = Color.Red;
                        }
                        else
                        {
                            errPublico.Clear();
                            valPublico.BackColor = Color.FromArgb(0, 100, 182);
                            EditingObject = EditingObject != null ? EditingObject : new Curso();
                            EditingObject.Publico = cmbPublico.SelectedItem.ToString();
                        }
                    }
                    break;
                default: break;
            }
        }
        private void FrmCurso_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (opc)
            {
                case "newObject":
                    if (EditingObject != null)
                    {
                        if (MessageBox.Show("¿Seguro que desea salir? hay cambios sin guardar que se perderan.", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            e.Cancel = true;
                        }
                    }
                    break;
                case "updObject":
                    break;
                default: break;
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
                case "newObject":
                    if (val_NewObject())
                    {
                        try
                        {

                            if (CursoDAL.insertCurso(NewObject, Inicio.CurrentUser))
                            {
                                MessageBox.Show("El curso ha sido registrado exitosamente.", "Registro satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                EditingObject = null;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Ocurrio un error inesperado al intentar registrar el curso, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.", "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        catch (Exception ex)
                        {
                            string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                            string fileName = "Exeptions_" + Name + ".txt";
                            Validation.FormManager frmManager = new Validation.FormManager();
                            frmManager.writeException(folderName, fileName, ex, "Ocurrio un error inesperado al intentar registrar el curso");
                            MessageBox.Show("Ocurrio un error inesperado al intentar registrar el curso, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hay algunos campos que necesitan ser verificados antes de poder guardar, por favor revise todos los campos antes de continuar.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                case "updObject":

                    if (val_UpdObject())
                    {
                        try
                        {

                            if (CursoDAL.updateCurso(NewObject, Inicio.CurrentUser))
                            {
                                MessageBox.Show("El curso ha sido actualizado exitosamente.", "Acualización satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                EditingObject = null;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Ocurrio un error inesperado al intentar actualizar el curso, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.", "Acualización interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

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

            if (!Validation.Validation.Val_StringsLength(txtNombre.Text, 5))
            {
                errNombre.SetError(txtNombre, "El nombre debe tener al menos 5 caracteres.");
                valNombre.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errNombre.Clear();
                valNombre.BackColor = Color.FromArgb(0, 100, 182);
                NewObject = NewObject != null ? NewObject : new Curso();
                NewObject.Nombre = txtNombre.Text;
            }

            if (dtpDesde.Value > dtpHasta.Value)
            {
                errDesde.SetError(dtpHasta, "La fecha de inicio del curso no puede ser mayor a la fecha de finalización.");
                valDesde.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errDesde.Clear();
                valDesde.BackColor = Color.FromArgb(0, 100, 182);
                NewObject = NewObject != null ? NewObject : new Curso();
                NewObject.Desde = dtpDesde.Value.ToString("yyyy/MM/dd");
            }

            if (!Validation.Validation.Val_StringsLength(txtSeccion.Text, 1))
            {
                errSeccion.SetError(txtSeccion, "La secció debe tener al menos 1 caracter para poder registrarse.");
                valSeccion.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errSeccion.Clear();
                valSeccion.BackColor = Color.FromArgb(0, 100, 182);
                NewObject = NewObject != null ? NewObject : new Curso();
                NewObject.Seccion = txtSeccion.Text;
            }

            if (EditingObject == null || (EditingObject != null && EditingObject.Contrato == null))
            {
                errEncargado.SetError(txtEncargado, "No ha seleccionado a ningun docente encargado para este curso.");
                valEncargado.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errEncargado.Clear();
                valEncargado.BackColor = Color.FromArgb(0, 100, 182);
                NewObject = NewObject != null ? NewObject : new Curso();
                NewObject.Contrato = EditingObject.Contrato;
            }

            if (EditingObject == null || (EditingObject != null && EditingObject.Libros == null || (EditingObject.Libros != null && EditingObject.Libros.Count == 0)))
            {
                errDetCurso.SetError(dgvDeCurso, "No ha seleccionado a ningun libro para este curso.");
                valDetCurso.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errDetCurso.Clear();
                valDetCurso.BackColor = Color.FromArgb(0, 100, 182);
                NewObject = NewObject != null ? NewObject : new Curso();
                NewObject.Libros = EditingObject.Libros;
            }

            if (EditingObject == null || (EditingObject != null && EditingObject.Horario == null || (EditingObject.Horario != null && EditingObject.Horario.Count == 0)))
            {
                errHorario.SetError(dgvHorario, "No ha agregado ningun bloque al horario para este curso.");
                valHorario.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errHorario.Clear();
                valHorario.BackColor = Color.FromArgb(0, 100, 182);
                NewObject = NewObject != null ? NewObject : new Curso();
                NewObject.Horario = EditingObject.Horario;
            }
            NewObject = NewObject != null ? NewObject : new Curso();
            NewObject.Publico = cmbPublico.SelectedItem.ToString();
            NewObject.Hasta = dtpHasta.Value.ToString("yyyy/MM/dd");
            NewObject.Estado = chkEstado.Checked ? "A" : "I";
            NewObject.IdSucursal = Inicio.CurrentSucursal.Id;
            NewObject.IdYear = Inicio.CurrentYear.Id;
            NewObject.Year = Inicio.CurrentYear;

            NewObject = result ? NewObject : null;
            return result;
        }
        private bool val_UpdObject()
        {
            bool result = true;

            if (!Validation.Validation.Val_StringsLength(txtNombre.Text, 5))
            {
                errNombre.SetError(txtNombre, "El nombre debe tener al menos 5 caracteres.");
                valNombre.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errNombre.Clear();
                valNombre.BackColor = Color.FromArgb(0, 100, 182);
                NewObject = NewObject != null ? NewObject : new Curso();
                NewObject.Nombre = txtNombre.Text;
            }

            if (dtpDesde.Value > dtpHasta.Value)
            {
                errDesde.SetError(dtpHasta, "La fecha de inicio del curso no puede ser mayor a la fecha de finalización.");
                valDesde.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errDesde.Clear();
                valDesde.BackColor = Color.FromArgb(0, 100, 182);
                NewObject = NewObject != null ? NewObject : new Curso();
                NewObject.Desde = dtpDesde.Value.ToString("yyyy/MM/dd");
            }

            if (!Validation.Validation.Val_StringsLength(txtSeccion.Text, 1))
            {
                errSeccion.SetError(txtSeccion, "La secció debe tener al menos 1 caracter para poder registrarse.");
                valSeccion.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errSeccion.Clear();
                valSeccion.BackColor = Color.FromArgb(0, 100, 182);
                NewObject = NewObject != null ? NewObject : new Curso();
                NewObject.Seccion = txtSeccion.Text;
            }

            if (EditingObject == null || (EditingObject != null && EditingObject.Contrato == null))
            {
                errEncargado.SetError(txtEncargado, "No ha seleccionado a ningun docente encargado para este curso.");
                valEncargado.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errEncargado.Clear();
                valEncargado.BackColor = Color.FromArgb(0, 100, 182);
                NewObject = NewObject != null ? NewObject : new Curso();
                NewObject.Contrato = EditingObject.Contrato;
            }

            if (EditingObject == null || (EditingObject != null && EditingObject.Libros == null || (EditingObject.Libros != null && EditingObject.Libros.Count == 0)))
            {
                errDetCurso.SetError(dgvDeCurso, "No ha seleccionado a ningun libro para este curso.");
                valDetCurso.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errDetCurso.Clear();
                valDetCurso.BackColor = Color.FromArgb(0, 100, 182);
                NewObject = NewObject != null ? NewObject : new Curso();
                NewObject.Libros = EditingObject.Libros;
            }

            if (EditingObject == null || (EditingObject != null && EditingObject.Horario == null || (EditingObject.Horario != null && EditingObject.Horario.Count == 0)))
            {
                errHorario.SetError(dgvHorario, "No ha agregado ningun bloque al horario para este curso.");
                valHorario.BackColor = Color.Red;
                result = false;
            }
            else
            {
                errHorario.Clear();
                valHorario.BackColor = Color.FromArgb(0, 100, 182);
                NewObject = NewObject != null ? NewObject : new Curso();
                NewObject.Horario = EditingObject.Horario;
            }
            NewObject = NewObject != null ? NewObject : new Curso();
            NewObject.Id = CurrentObject.Id;
            NewObject.Publico = cmbPublico.SelectedItem.ToString();
            NewObject.Hasta = dtpHasta.Value.ToString("yyyy/MM/dd");
            NewObject.Estado = chkEstado.Checked ? "A" : "I";
            NewObject.IdSucursal = CurrentObject.IdSucursal;
            NewObject.IdYear = CurrentObject.IdYear;
            NewObject.Year = CurrentObject.Year;
            if (result && CurrentObject.Nombre != txtNombre.Text)
            {
                if (CursoDAL.existeCurso(NewObject))
                {
                    errNombre.SetError(txtNombre, "Ya existe un curso con este nombre registrado este año\npor favor elija un nombre diferente.");
                    valNombre.BackColor = Color.Red;
                    result = false;
                }
                else
                {
                    errNombre.Clear();
                    valNombre.BackColor = Color.FromArgb(0, 100, 182);
                }
            }
            NewObject = result ? NewObject : null;
            return result;
        }

    }
}
