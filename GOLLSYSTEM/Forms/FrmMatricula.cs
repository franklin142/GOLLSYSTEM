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

namespace GOLLSYSTEM.Forms
{
    public partial class FrmMatricula : Form
    {
        public Matricula CurrentObject;
        public Matricula EditingObject;
        public Matricula NewObject;
        public string opc;
        public FrmMatricula()
        {
            InitializeComponent();
        }

        private void FrmMatricula_Load(object sender, EventArgs e)
        {
            cmbCurso.DataSource = CursoDAL.getCursosByIdSucursal(Inicio.CurrentSucursal.Id, Inicio.CurrentYear);
            cmbCurso.DisplayMember = "Nombre";
            cmbCurso.ValueMember = "Id";
            cmbCurso.SelectedIndex = 0;
            numDiaPago.Maximum = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            numDiaPago.Value = DateTime.Now.Day;

            switch (opc)
            {
                case "updObject":
                    txtNombreEst.Text = EditingObject.Estudiante.Persona.Nombre;
                    txtApPaternoEst.Text = EditingObject.Estudiante.ApPaterno;
                    txtApMaternoEst.Text = EditingObject.Estudiante.ApMaterno;
                    txtEnfermedadEst.Text = EditingObject.Estudiante.Enfermedad;
                    dtpFechaNacEst.Value = Convert.ToDateTime(EditingObject.Estudiante.Persona.FechaNac);
                    txtDireccionEst.Text = EditingObject.Estudiante.Persona.Direccion;
                    txtCorreoEst.Text = EditingObject.Estudiante.Correo;
                    txtTelEstudiante.Text = EditingObject.Estudiante.Telefono;
                    txtTelEmergencia.Text = EditingObject.Estudiante.TelEmergencia;
                    txtParentescoEmergencia.Text = EditingObject.Estudiante.ParentEmergencia;

                    Detmatricula padre = EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault();
                    txtNombrePadre.Text = padre == null ? "" : padre.encargado.Persona.Nombre;
                    txtLugarTrabajoPadre.Text = padre == null ? "" : padre.encargado.LugarTrabajo;
                    txtTelefonoPadre.Text = padre == null ? "" : padre.encargado.Telefono;
                    txtDireccionPadre.Text = padre == null ? "" : padre.encargado.Persona.Direccion;
                    txtTrabajoPadre.Text = padre == null ? "" : padre.encargado.Trabajo;

                    Detmatricula madre = EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault();
                    txtNombreMadre.Text = madre == null ? "" : madre.encargado.Persona.Nombre;
                    txtLugarTrabajoMadre.Text = madre == null ? "" : madre.encargado.LugarTrabajo;
                    txtTelefonoMadre.Text = madre == null ? "" : madre.encargado.Telefono;
                    txtDireccionMadre.Text = madre == null ? "" : madre.encargado.Persona.Direccion;
                    txtLugarTrabajoMadre.Text = madre == null ? "" : madre.encargado.Trabajo;

                    for (int i = 0; i < cmbCurso.Items.Count; i++) cmbCurso.SelectedIndex = (cmbCurso.Items[i] as Curso).Id == EditingObject.IdCurso ? i : cmbCurso.SelectedIndex;
                    numDiaPago.Value = Convert.ToInt32(EditingObject.DiaLimite);
                    checkBecado.Checked = EditingObject.Becado == 1;

                    btnBuscarAlumno.Enabled = false;
                    btnClearAlumno.Enabled = false;
                    break;

                default: break;
            }
        }
        private void btnBuscarPadre_Click(object sender, EventArgs e)
        {
            frmBuscarEncargado encargado = new frmBuscarEncargado();
            encargado.ShowDialog();
            if (encargado.CurrentObject != null)
            {
                clearPadre(false);

                EditingObject = EditingObject == null ? new Matricula() : EditingObject;
                EditingObject.Padres = EditingObject.Padres == null ? new List<Detmatricula>() : EditingObject.Padres;
                EditingObject.Padres.Remove(EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault());
                EditingObject.Padres.Add(new Detmatricula(0, "Padre", EditingObject.Id, encargado.CurrentObject.Id, encargado.CurrentObject));

                txtNombrePadre.Text = encargado.CurrentObject.Persona.Nombre;
                txtLugarTrabajoPadre.Text = encargado.CurrentObject.LugarTrabajo;
                txtTelefonoPadre.Text = encargado.CurrentObject.Telefono;
                txtDireccionPadre.Text = encargado.CurrentObject.Persona.Direccion;
                txtTrabajoPadre.Text = encargado.CurrentObject.Trabajo;
            }
        }
        private void txtBuscarMadre_Click(object sender, EventArgs e)
        {
            frmBuscarEncargado encargado = new frmBuscarEncargado();
            encargado.ShowDialog();
            if (encargado.CurrentObject != null)
            {
                clearMadre(false);

                EditingObject = EditingObject == null ? new Matricula() : EditingObject;
                EditingObject.Padres = EditingObject.Padres == null ? new List<Detmatricula>() : EditingObject.Padres;
                EditingObject.Padres.Remove(EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault());
                EditingObject.Padres.Add(new Detmatricula(0, "Madre", EditingObject.Id, encargado.CurrentObject.Id, encargado.CurrentObject));

                txtNombreMadre.Text = encargado.CurrentObject.Persona.Nombre;
                txtLugarTrabajoMadre.Text = encargado.CurrentObject.LugarTrabajo;
                txtTelefonoMadre.Text = encargado.CurrentObject.Telefono;
                txtDireccionMadre.Text = encargado.CurrentObject.Persona.Direccion;
                txtTrabajoMadre.Text = encargado.CurrentObject.Trabajo;
            }
        }
        private void btnBuscarAlumno_Click(object sender, EventArgs e)
        {
            frmBuscarEstudiante estudiante = new frmBuscarEstudiante();
            estudiante.ShowDialog();
            if (estudiante.currentObject != null)
            {
                clearPadre(true);
                clearMadre(true);
                btnClearAlumno.Enabled = true;

                EditingObject = EditingObject != null ? EditingObject : new Matricula();
                EditingObject.Estudiante =  estudiante.currentObject.Estudiante;
                EditingObject.Padres = estudiante.currentObject.Padres;

                txtNombreEst.Text = EditingObject.Estudiante.Persona.Nombre;
                txtApPaternoEst.Text = EditingObject.Estudiante.ApPaterno;
                txtApMaternoEst.Text = EditingObject.Estudiante.ApMaterno;
                txtEnfermedadEst.Text = EditingObject.Estudiante.Enfermedad;
                dtpFechaNacEst.Value = Convert.ToDateTime(EditingObject.Estudiante.Persona.FechaNac);
                txtDireccionEst.Text = EditingObject.Estudiante.Persona.Direccion;
                txtCorreoEst.Text = EditingObject.Estudiante.Correo;
                txtTelEstudiante.Text = EditingObject.Estudiante.Telefono;
                txtTelEmergencia.Text = EditingObject.Estudiante.TelEmergencia;
                txtParentescoEmergencia.Text = EditingObject.Estudiante.ParentEmergencia;

                Detmatricula padre = EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault();
                txtNombrePadre.Text = padre == null ? "" : padre.encargado.Persona.Nombre;
                txtLugarTrabajoPadre.Text = padre == null ? "" : padre.encargado.LugarTrabajo;
                txtTelefonoPadre.Text = padre == null ? "" : padre.encargado.Telefono;
                txtDireccionPadre.Text = padre == null ? "" : padre.encargado.Persona.Direccion;
                txtTrabajoPadre.Text = padre == null ? "" : padre.encargado.Trabajo;

                Detmatricula madre = EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault();
                txtNombreMadre.Text = madre == null ? "" : madre.encargado.Persona.Nombre;
                txtLugarTrabajoMadre.Text = madre == null ? "" : madre.encargado.LugarTrabajo;
                txtTelefonoMadre.Text = madre == null ? "" : madre.encargado.Telefono;
                txtDireccionMadre.Text = madre == null ? "" : madre.encargado.Persona.Direccion;
                txtLugarTrabajoMadre.Text = madre == null ? "" : madre.encargado.Trabajo;

            }
        }
        private void clearPadre(bool opcChange)
        {
            txtNombrePadre.Text = "";
            txtLugarTrabajoPadre.Text = "";
            txtTelefonoPadre.Text = "";
            txtDireccionPadre.Text = "";
            txtTrabajoPadre.Text = "";

            txtNombrePadre.Enabled = opcChange;
            txtLugarTrabajoPadre.Enabled = opcChange;
            txtTelefonoPadre.Enabled = opcChange;
            txtDireccionPadre.Enabled = opcChange;
            txtTrabajoPadre.Enabled = opcChange;
            btnClearPadre.Enabled = !opcChange;

            EditingObject = EditingObject != null ? EditingObject : new Matricula();
            EditingObject.Padres = EditingObject.Padres != null ? EditingObject.Padres : new List<Detmatricula>();
            EditingObject.Padres.Remove(EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault());

        }
        private void clearMadre(bool opcChange)
        {
            txtNombreMadre.Text = "";
            txtLugarTrabajoMadre.Text = "";
            txtTelefonoMadre.Text = "";
            txtDireccionMadre.Text = "";
            txtTrabajoMadre.Text = "";

            txtNombreMadre.Enabled = opcChange;
            txtLugarTrabajoMadre.Enabled = opcChange;
            txtTelefonoMadre.Enabled = opcChange;
            txtDireccionMadre.Enabled = opcChange;
            txtTrabajoMadre.Enabled = opcChange;
            btnClearMadre.Enabled = !opcChange;

            EditingObject = EditingObject != null ? EditingObject : new Matricula();
            EditingObject.Padres = EditingObject.Padres != null ? EditingObject.Padres : new List<Detmatricula>();
            EditingObject.Padres.Remove(EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault());
        }
        private void clearEstudiante(bool opcChange)
        {
            txtNombreEst.Text = "";
            txtApPaternoEst.Text = "";
            txtApMaternoEst.Text = "";
            txtEnfermedadEst.Text = "";
            dtpFechaNacEst.Value = DateTime.Now;
            txtDireccionEst.Text = "";
            txtCorreoEst.Text = "";
            txtTelEstudiante.Text = "";
            txtTelEmergencia.Text = "";
            txtParentescoEmergencia.Text = "";

            EditingObject = null;
        }
        private bool Val_NewObject()
        {
            EditingObject = EditingObject != null ? EditingObject : new Matricula();
            EditingObject.Estudiante = EditingObject.Estudiante != null ? EditingObject.Estudiante : new Estudiante();
            EditingObject.Estudiante.Persona = EditingObject.Estudiante.Persona != null ? EditingObject.Estudiante.Persona : new Persona();

            EditingObject.Padres = EditingObject.Padres != null ? EditingObject.Padres : new List<Detmatricula>();
            if (EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault() == null)
                EditingObject.Padres.Add(new Detmatricula(0, "Padre", EditingObject.Id, 0, new Encargado(0, "", "", "", 0, new Persona())));
            if (EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault() == null)
                EditingObject.Padres.Add(new Detmatricula(0, "Madre", EditingObject.Id, 0, new Encargado(0, "", "", "", 0, new Persona())));

            NewObject = NewObject != null ? NewObject : new Matricula();
            NewObject.Estudiante = EditingObject.Estudiante != null ? EditingObject.Estudiante : new Estudiante();
            NewObject.Estudiante.Persona = NewObject.Estudiante.Persona != null ? NewObject.Estudiante.Persona : new Persona();
            NewObject.Padres = NewObject.Padres != null ? NewObject.Padres : new List<Detmatricula>();

            if (NewObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault() == null)
                NewObject.Padres.Add(new Detmatricula(0, "Padre", NewObject.Id, 0, new Encargado(0, "", "", "", 0, new Persona())));
            if (NewObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault() == null)
                NewObject.Padres.Add(new Detmatricula(0, "Madre", NewObject.Id, 0, new Encargado(0, "", "", "", 0, new Persona())));

            bool result = true;
            bool validation = true;

            validation = txtNombreEst.Text.Length == 0 || !Validation.Validation.Val_NameFormat(txtNombreEst.Text) ?
                setErrorMessage("El nombre del estudiante no tiene un formato valido, por favor digite el nombre completo", errNombreEst, txtNombreEst, valNombreEst, Color.Red) :
                setErrorMessage(null, errNombreEst, txtNombreEst, valNombreEst, Color.FromArgb(0, 100, 182));
            NewObject.Estudiante.Persona.Nombre = txtNombreEst.Text;
            result = validation == false ? false : result;
            validation = txtApPaternoEst.Text.Length > 0 && (!Validation.Validation.Val_StringsLength(txtApPaternoEst.Text, 4) || !Validation.Validation.Val_LetterFormat(txtApPaternoEst.Text)) ?
                setErrorMessage("El apellido paterno del estudiante no tiene un formato valido, por favor digite un \napellido valido con un minimo de 4 caracteres", errApPaternoEst, txtApPaternoEst, valApPaternoEst, Color.Red) :
                setErrorMessage(null, errApPaternoEst, txtApPaternoEst, valApPaternoEst, Color.FromArgb(0, 100, 182));
            NewObject.Estudiante.ApPaterno = txtApPaternoEst.Text;
            result = validation == false ? false : result;

            validation = txtApMaternoEst.Text.Length > 0 && (!Validation.Validation.Val_StringsLength(txtApMaternoEst.Text, 4) || !Validation.Validation.Val_LetterFormat(txtApPaternoEst.Text)) ?
                setErrorMessage("El apellido materno del estudiante no tiene un formato valido, por favor digite un \napellido valido con un minimo de 4 caracteres", errApMaternoEst, txtApMaternoEst, valApMaternoEst, Color.Red) :
                setErrorMessage(null, errApMaternoEst, txtApMaternoEst, valApMaternoEst, Color.FromArgb(0, 100, 182));
            NewObject.Estudiante.ApMaterno = txtApMaternoEst.Text;
            result = validation == false ? false : result;

            validation = txtEnfermedadEst.Text.Length > 0 && !Validation.Validation.Val_StringsLength(txtEnfermedadEst.Text, 5) ?
                setErrorMessage("El nombre de la enfermedad del estudiante no tiene un formato valido, por favor digite un \napellido valido con un minimo de 5 caracteres", errEnfermedadEst, txtEnfermedadEst, valEnfermedadEst, Color.Red) :
                setErrorMessage(null, errEnfermedadEst, txtEnfermedadEst, valEnfermedadEst, Color.FromArgb(0, 100, 182));
            NewObject.Estudiante.Enfermedad = txtEnfermedadEst.Text;
            result = validation == false ? false : result;

            validation = txtDireccionEst.Text.Length == 0 || !Validation.Validation.Val_StringsLength(txtDireccionEst.Text, 20) ?
                setErrorMessage("La direccion del estudiante no cumple la longitud de 20 caracetes, por favor digite una \ndireccion valida con un minimo de 20 caracteres", errDireccionEst, txtDireccionEst, valDireccionEst, Color.Red) :
                setErrorMessage(null, errDireccionEst, txtDireccionEst, valDireccionEst, Color.FromArgb(0, 100, 182));
            NewObject.Estudiante.Persona.Direccion = txtDireccionEst.Text;
            result = validation == false ? false : result;

            validation = txtCorreoEst.Text.Length > 0 && !Validation.Validation.Val_EmailFormat(txtCorreoEst.Text) ?
               setErrorMessage("La direccion de correo electronico no tiene un formato valido, por favor digite una \ndireccion valida \"micorreo@dominio.com\"", errCorreoEst, txtCorreoEst, valCorreoEst, Color.Red) :
               setErrorMessage(null, errCorreoEst, txtCorreoEst, valCorreoEst, Color.FromArgb(0, 100, 182));
            NewObject.Estudiante.Correo = txtCorreoEst.Text;
            result = validation == false ? false : result;

            validation = txtTelEstudiante.Text.Length > 0 && !Validation.Validation.Val_CellphoneFormat(txtTelEstudiante.Text) ?
               setErrorMessage("El telefono del estudiante no cumple ningun formato valido, por favor digite un \ntelefono valido 22222222,+5037777777 o (+503)77777777", errTelefonoEst, txtTelEstudiante, valTelefonoEst, Color.Red) :
               setErrorMessage(null, errTelefonoEst, txtTelEstudiante, valTelefonoEst, Color.FromArgb(0, 100, 182));
            NewObject.Estudiante.Telefono = txtTelEstudiante.Text;
            result = validation == false ? false : result;

            validation = txtParentescoEmergencia.Text.Length > 0 && !Validation.Validation.Val_StringsLength(txtParentescoEmergencia.Text, 3) ?
               setErrorMessage("El parentesco o nombre tiene menos de 3 caracteres, por favor digite un parentesco con un minimo de 3 caracteres.", errParienteEmergencia, txtParentescoEmergencia, valParentesco, Color.Red) :
               setErrorMessage(null, errParienteEmergencia, txtParentescoEmergencia, valParentesco, Color.FromArgb(0, 100, 182));
            NewObject.Estudiante.ParentEmergencia = txtParentescoEmergencia.Text;
            result = validation == false ? false : result;

            validation = txtTelEmergencia.Text.Length > 0 && !Validation.Validation.Val_CellphoneFormat(txtTelEmergencia.Text) ?
               setErrorMessage("El telefono de emergencia del estudiante no cumple ningun formato valido, por favor digite un \ntelefono valido 22222222, +5037777777 o (+503)77777777", errTelEmergencia, txtTelEmergencia, valTelEmergencia, Color.Red) :
               setErrorMessage(null, errTelEmergencia, txtTelEmergencia, valTelEmergencia, Color.FromArgb(0, 100, 182));
            NewObject.Estudiante.TelEmergencia = txtTelEmergencia.Text;
            result = validation == false ? false : result;

            validation = cmbCurso.SelectedItem != null && MatriculaDAL.countMatriculasByCurso((Int64)cmbCurso.SelectedValue) == Properties.Settings.Default.MaxEstudentsIn ?
               setErrorMessage("Este curso ya tiene el limite de " + Properties.Settings.Default.MaxEstudentsIn + " de estudiantes inscritos\nSeleccione otro curso para poder continuar con la inscripcion.", errCurso, cmbCurso, valCurso, Color.Red) :
               setErrorMessage(null, errCurso, cmbCurso, valCurso, Color.FromArgb(0, 100, 182));
            NewObject.IdCurso = (Int64)cmbCurso.SelectedValue;
            result = validation == false ? false : result;

            validation = numDiaPago.Value == 0 ?
              setErrorMessage("el dia maximo de pago no puede ser cero.", errDiaLimite, numDiaPago, valDiaPago, Color.Red) :
              setErrorMessage(null, errDiaLimite, numDiaPago, valDiaPago, Color.FromArgb(0, 100, 182));
            NewObject.DiaLimite = numDiaPago.Value.ToString();
            result = validation == false ? false : result;

            NewObject.Becado = checkBecado.Checked ? 1 : 0;
            NewObject.Estudiante.Persona.FechaNac = dtpFechaNacEst.Value.ToString("yyyy/MM/dd");

            if (EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().Id == 0)
            {
                if (txtNombrePadre.Text.Trim() == "" && txtTelefonoPadre.Text.Trim() == "" && txtLugarTrabajoPadre.Text.Trim() == "" && txtTrabajoPadre.Text.Trim() == "" && txtDireccionPadre.Text.Trim() == "")
                {
                    setErrorMessage(null, errDireccionPadre, txtDireccionPadre, valDireccionPadre, Color.Gray);
                    setErrorMessage(null, errTrabajoPadre, txtTrabajoPadre, valTrabajoPadre, Color.Gray);
                    setErrorMessage(null, errTelefonoPadre, txtTelefonoPadre, valTelefonoPadre, Color.Gray);
                    setErrorMessage(null, errLugarTrabajaPadre, txtLugarTrabajoPadre, valLugarTrabajaPadre, Color.Gray);
                    setErrorMessage(null, errNombrePadre, txtNombrePadre, ValNombrePadre, Color.Gray);
                    NewObject.Padres.Remove(NewObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault());

                }
                else
                {
                    validation = txtNombrePadre.Text.Length == 0 && !Validation.Validation.Val_NameFormat(txtNombrePadre.Text) ?
                        setErrorMessage("El nombre del padre del estudiante no tiene un formato valido, por favor digite el nombre completo", errNombrePadre, txtNombrePadre, ValNombrePadre, Color.Red) :
                        setErrorMessage(null, errNombrePadre, txtNombrePadre, ValNombrePadre, Color.FromArgb(0, 100, 182));
                    NewObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.Persona.Nombre = txtNombrePadre.Text;
                    result = validation == false ? false : result;

                    validation = txtLugarTrabajoPadre.Text.Length > 0 && !Validation.Validation.Val_StringsLength(txtLugarTrabajoPadre.Text, 10) ?
                        setErrorMessage("El lugar donde trabaja del padre del estudiante no tiene un \nformato valido, por favor especifique el lugar en un minimo de 10 caracteres", errLugarTrabajaPadre, txtLugarTrabajoPadre, valLugarTrabajaPadre, Color.Red) :
                        setErrorMessage(null, errLugarTrabajaPadre, txtLugarTrabajoPadre, valLugarTrabajaPadre, Color.FromArgb(0, 100, 182));
                    NewObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.LugarTrabajo = txtLugarTrabajoPadre.Text;
                    result = validation == false ? false : result;

                    validation = txtTelefonoPadre.Text.Length > 0 && !Validation.Validation.Val_CellphoneFormat(txtTelefonoPadre.Text) ?
                       setErrorMessage("El telefono del padre del estudiante no cumple ningun formato valido, por favor digite un \ntelefono valido 22222222,+5037777777 o (+503)77777777", errTelefonoPadre, txtTelefonoPadre, valTelefonoPadre, Color.Red) :
                       setErrorMessage(null, errTelefonoPadre, txtTelefonoPadre, valTelefonoPadre, Color.FromArgb(0, 100, 182));
                    NewObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.Telefono = txtTelefonoPadre.Text;
                    result = validation == false ? false : result;

                    validation = txtTrabajoPadre.Text.Length > 0 && !Validation.Validation.Val_StringsLength(txtTrabajoPadre.Text, 10) ?
                        setErrorMessage("El trabaja u oficio del padre del estudiante no tiene un \nformato valido, por favor especifique el lugar en un minimo de 5 caracteres", errTrabajoPadre, txtTrabajoPadre, valTrabajoPadre, Color.Red) :
                        setErrorMessage(null, errTrabajoPadre, txtTrabajoPadre, valTrabajoPadre, Color.FromArgb(0, 100, 182));
                    NewObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.Trabajo = txtTrabajoPadre.Text;
                    result = validation == false ? false : result;

                    validation = txtDireccionPadre.Text.Length == 0 || !Validation.Validation.Val_StringsLength(txtDireccionPadre.Text, 20) ?
                        setErrorMessage("La direccion del padre del estudiante no cumple la longitud de 20 caracetes, por favor digite una \ndireccion valida con un minimo de 20 caracteres", errDireccionPadre, txtDireccionPadre, valDireccionPadre, Color.Red) :
                        setErrorMessage(null, errDireccionPadre, txtDireccionPadre, valDireccionPadre, Color.FromArgb(0, 100, 182));
                    NewObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.Persona.Direccion = txtDireccionPadre.Text;
                    result = validation == false ? false : result;
                }
            }
            else
            {
                NewObject.Padres.Add(EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault());
            }

            if (EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().Id == 0)
            {
                if (txtNombreMadre.Text.Trim() == "" && txtTelefonoMadre.Text.Trim() == "" && txtLugarTrabajoMadre.Text.Trim() == "" && txtTrabajoMadre.Text.Trim() == "" && txtDireccionMadre.Text.Trim() == "")
                {
                    setErrorMessage(null, errDireccionMadre, txtDireccionMadre, valDireccionMadre, Color.Gray);
                    setErrorMessage(null, errTrabajoMadre, txtTrabajoMadre, valTrabajoMadre, Color.Gray);
                    setErrorMessage(null, errTelefonoMadre, txtTelefonoMadre, valTelefonoMadre, Color.Gray);
                    setErrorMessage(null, errLugarTrabajaMadre, txtLugarTrabajoMadre, valLugarTrabajaMadre, Color.Gray);
                    setErrorMessage(null, errNombreMadre, txtNombreMadre, valNombreMadre, Color.Gray);
                    NewObject.Padres.Remove(NewObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault());
                }
                else
                {
                    validation = txtNombreMadre.Text.Length == 0 || !Validation.Validation.Val_NameFormat(txtNombreMadre.Text) ?
                        setErrorMessage("El nombre de la madre del estudiante no tiene un formato valido, por favor digite el nombre completo", errNombreMadre, txtNombreMadre, valNombreMadre, Color.Red) :
                        setErrorMessage(null, errNombreMadre, txtNombreMadre, valNombreMadre, Color.FromArgb(0, 100, 182));
                    NewObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.Persona.Nombre = txtNombreMadre.Text;
                    result = validation == false ? false : result;

                    validation = txtLugarTrabajoMadre.Text.Length > 0 && !Validation.Validation.Val_StringsLength(txtLugarTrabajoMadre.Text, 10) ?
                        setErrorMessage("El lugar donde trabaja la madre del estudiante no tiene un \nformato valido, por favor especifique el lugar en un minimo de 10 caracteres", errLugarTrabajaMadre, txtLugarTrabajoMadre, valLugarTrabajaMadre, Color.Red) :
                        setErrorMessage(null, errLugarTrabajaMadre, txtLugarTrabajoMadre, valLugarTrabajaMadre, Color.FromArgb(0, 100, 182));
                    NewObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.LugarTrabajo = txtLugarTrabajoMadre.Text;
                    result = validation == false ? false : result;

                    validation = txtTelefonoMadre.Text.Length > 0 && !Validation.Validation.Val_CellphoneFormat(txtTelefonoMadre.Text) ?
                       setErrorMessage("El telefono de la madre del estudiante no cumple ningun formato valido, por favor digite un \ntelefono valido 22222222,+5037777777 o (+503)77777777", errTelefonoMadre, txtTelefonoMadre, valTelefonoMadre, Color.Red) :
                       setErrorMessage(null, errTelefonoMadre, txtTelefonoMadre, valTelefonoMadre, Color.FromArgb(0, 100, 182));
                    NewObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.Telefono = txtTelefonoMadre.Text;
                    result = validation == false ? false : result;

                    validation = txtTrabajoMadre.Text.Length > 0 && !Validation.Validation.Val_StringsLength(txtTrabajoMadre.Text, 10) ?
                        setErrorMessage("El trabaja u oficio de la madre del estudiante no tiene un \nformato valido, por favor especifique el lugar en un minimo de 5 caracteres", errTrabajoMadre, txtTrabajoMadre, valTrabajoMadre, Color.Red) :
                        setErrorMessage(null, errTrabajoMadre, txtTrabajoMadre, valTrabajoMadre, Color.FromArgb(0, 100, 182));
                    NewObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.Trabajo = txtTrabajoMadre.Text;
                    result = validation == false ? false : result;

                    validation = txtDireccionMadre.Text.Length == 0 || !Validation.Validation.Val_StringsLength(txtDireccionMadre.Text, 20) ?
                        setErrorMessage("La direccion de la madre del estudiante no cumple la longitud de 20 caracetes, por favor digite una \ndireccion valida con un minimo de 20 caracteres", errDireccionMadre, txtDireccionMadre, valDireccionMadre, Color.Red) :
                        setErrorMessage(null, errDireccionMadre, txtDireccionMadre, valDireccionMadre, Color.FromArgb(0, 100, 182));
                    NewObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.Persona.Direccion = txtDireccionMadre.Text;
                    result = validation == false ? false : result;
                }
            }
            else
            {
                NewObject.Padres.Add(EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault());
            }



            if (!result)
            {
                NewObject = null;
            }
            return result;
        }
        private bool Val_UpdObject()
        {
            bool result = true;
            EditingObject = EditingObject != null ? EditingObject : new Matricula();
            EditingObject.Estudiante = EditingObject.Estudiante != null ? EditingObject.Estudiante : new Estudiante();
            EditingObject.Estudiante.Persona = EditingObject.Estudiante.Persona != null ? EditingObject.Estudiante.Persona : new Persona();
            EditingObject.Padres = EditingObject.Padres != null ? EditingObject.Padres : new List<Detmatricula>();

            if (EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault() == null)
                EditingObject.Padres.Add(new Detmatricula(0, "Padre", EditingObject.Id, 0, new Encargado(0, "", "", "", 0, new Persona())));
            if (EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault() == null)
                EditingObject.Padres.Add(new Detmatricula(0, "Madre", EditingObject.Id, 0, new Encargado(0, "", "", "", 0, new Persona())));

            NewObject = new Matricula();
            NewObject.Estudiante = NewObject.Estudiante != null ? EditingObject.Estudiante : new Estudiante();
            NewObject.Estudiante.Persona = NewObject.Estudiante.Persona != null ? EditingObject.Estudiante.Persona : new Persona();
            NewObject.Padres = new List<Detmatricula>();



            bool validation = true;
            NewObject.Id = EditingObject.Id;
            NewObject.Cuotas = EditingObject.Cuotas;
            if (EditingObject.Estudiante.Id == 0)
            {
                validation = txtNombreEst.Text.Length == 0 || !Validation.Validation.Val_NameFormat(txtNombreEst.Text) ?
                    setErrorMessage("El nombre del estudiante no tiene un formato valido, por favor digite el nombre completo", errNombreEst, txtNombreEst, valNombreEst, Color.Red) :
                    setErrorMessage(null, errNombreEst, txtNombreEst, valNombreEst, Color.FromArgb(0, 100, 182));
                NewObject.Estudiante.Persona.Nombre = txtNombreEst.Text;
                result = validation == false ? false : result;
                validation = txtApPaternoEst.Text.Length > 0 && (!Validation.Validation.Val_StringsLength(txtApPaternoEst.Text, 4) || !Validation.Validation.Val_LetterFormat(txtApPaternoEst.Text)) ?
                    setErrorMessage("El apellido paterno del estudiante no tiene un formato valido, por favor digite un \napellido valido con un minimo de 4 caracteres", errApPaternoEst, txtApPaternoEst, valApPaternoEst, Color.Red) :
                    setErrorMessage(null, errApPaternoEst, txtApPaternoEst, valApPaternoEst, Color.FromArgb(0, 100, 182));
                NewObject.Estudiante.ApPaterno = txtApPaternoEst.Text;
                result = validation == false ? false : result;

                validation = txtApMaternoEst.Text.Length > 0 && (!Validation.Validation.Val_StringsLength(txtApMaternoEst.Text, 4) || !Validation.Validation.Val_LetterFormat(txtApPaternoEst.Text)) ?
                    setErrorMessage("El apellido materno del estudiante no tiene un formato valido, por favor digite un \napellido valido con un minimo de 4 caracteres", errApMaternoEst, txtApMaternoEst, valApMaternoEst, Color.Red) :
                    setErrorMessage(null, errApMaternoEst, txtApMaternoEst, valApMaternoEst, Color.FromArgb(0, 100, 182));
                NewObject.Estudiante.ApMaterno = txtApMaternoEst.Text;
                result = validation == false ? false : result;

                validation = txtEnfermedadEst.Text.Length > 0 && !Validation.Validation.Val_StringsLength(txtEnfermedadEst.Text, 5) ?
                    setErrorMessage("El nombre de la enfermedad del estudiante no tiene un formato valido, por favor digite un \napellido valido con un minimo de 5 caracteres", errEnfermedadEst, txtEnfermedadEst, valEnfermedadEst, Color.Red) :
                    setErrorMessage(null, errEnfermedadEst, txtEnfermedadEst, valEnfermedadEst, Color.FromArgb(0, 100, 182));
                NewObject.Estudiante.Enfermedad = txtEnfermedadEst.Text;
                result = validation == false ? false : result;

                validation = txtDireccionEst.Text.Length == 0 || !Validation.Validation.Val_StringsLength(txtDireccionEst.Text, 20) ?
                    setErrorMessage("La direccion del estudiante no cumple la longitud de 20 caracetes, por favor digite una \ndireccion valida con un minimo de 20 caracteres", errDireccionEst, txtDireccionEst, valDireccionEst, Color.Red) :
                    setErrorMessage(null, errDireccionEst, txtDireccionEst, valDireccionEst, Color.FromArgb(0, 100, 182));
                NewObject.Estudiante.Persona.Direccion = txtDireccionEst.Text;
                result = validation == false ? false : result;

                validation = txtCorreoEst.Text.Length > 0 && !Validation.Validation.Val_EmailFormat(txtCorreoEst.Text) ?
                   setErrorMessage("La direccion de correo electronico no tiene un formato valido, por favor digite una \ndireccion valida \"micorreo@dominio.com\"", errCorreoEst, txtCorreoEst, valCorreoEst, Color.Red) :
                   setErrorMessage(null, errCorreoEst, txtCorreoEst, valCorreoEst, Color.FromArgb(0, 100, 182));
                NewObject.Estudiante.Correo = txtCorreoEst.Text;
                result = validation == false ? false : result;

                validation = txtTelEstudiante.Text.Length > 0 && !Validation.Validation.Val_CellphoneFormat(txtTelEstudiante.Text) ?
                   setErrorMessage("El telefono del estudiante no cumple ningun formato valido, por favor digite un \ntelefono valido 22222222,+5037777777 o (+503)77777777", errTelefonoEst, txtTelEstudiante, valTelefonoEst, Color.Red) :
                   setErrorMessage(null, errTelefonoEst, txtTelEstudiante, valTelefonoEst, Color.FromArgb(0, 100, 182));
                NewObject.Estudiante.Telefono = txtTelEstudiante.Text;
                result = validation == false ? false : result;

                validation = txtParentescoEmergencia.Text.Length > 0 && !Validation.Validation.Val_StringsLength(txtParentescoEmergencia.Text, 3) ?
                   setErrorMessage("El parentesco o nombre tiene menos de 3 caracteres, por favor digite un parentesco con un minimo de 3 caracteres.", errParienteEmergencia, txtParentescoEmergencia, valParentesco, Color.Red) :
                   setErrorMessage(null, errParienteEmergencia, txtParentescoEmergencia, valParentesco, Color.FromArgb(0, 100, 182));
                NewObject.Estudiante.ParentEmergencia = txtParentescoEmergencia.Text;
                result = validation == false ? false : result;

                validation = txtTelEmergencia.Text.Length > 0 && !Validation.Validation.Val_CellphoneFormat(txtTelEmergencia.Text) ?
                   setErrorMessage("El telefono de emergencia del estudiante no cumple ningun formato valido, por favor digite un \ntelefono valido 22222222, +5037777777 o (+503)77777777", errTelEmergencia, txtTelEmergencia, valTelEmergencia, Color.Red) :
                   setErrorMessage(null, errTelEmergencia, txtTelEmergencia, valTelEmergencia, Color.FromArgb(0, 100, 182));
                NewObject.Estudiante.TelEmergencia = txtTelEmergencia.Text;
                result = validation == false ? false : result;
            }
            else
            {
                NewObject.Estudiante = EditingObject.Estudiante;
                NewObject.IdEstudiante = EditingObject.Estudiante.Id;

            }
            validation = cmbCurso.SelectedItem != null && MatriculaDAL.countMatriculasByCurso((Int64)cmbCurso.SelectedValue) == Properties.Settings.Default.MaxEstudentsIn ?
               setErrorMessage("Este curso ya tiene el limite de " + Properties.Settings.Default.MaxEstudentsIn + " de estudiantes inscritos\nSeleccione otro curso para poder continuar con la inscripcion.", errCurso, cmbCurso, valCurso, Color.Red) :
               setErrorMessage(null, errCurso, cmbCurso, valCurso, Color.FromArgb(0, 100, 182));
            NewObject.IdCurso = (Int64)cmbCurso.SelectedValue;
            result = validation == false ? false : result;

            validation = numDiaPago.Value == 0 ?
              setErrorMessage("el dia maximo de pago no puede ser cero.", errDiaLimite, numDiaPago, valDiaPago, Color.Red) :
              setErrorMessage(null, errDiaLimite, numDiaPago, valDiaPago, Color.FromArgb(0, 100, 182));
            NewObject.DiaLimite = numDiaPago.Value.ToString();
            result = validation == false ? false : result;

            NewObject.Becado = checkBecado.Checked ? 1 : 0;
            NewObject.Estudiante.Persona.FechaNac = dtpFechaNacEst.Value.ToString("yyyy/MM/dd");

            if (EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().Id == 0)
            {
                if (txtNombrePadre.Text.Trim() == "" && txtTelefonoPadre.Text.Trim() == "" && txtLugarTrabajoPadre.Text.Trim() == "" && txtTrabajoPadre.Text.Trim() == "" && txtDireccionPadre.Text.Trim() == "")
                {
                    setErrorMessage(null, errDireccionPadre, txtDireccionPadre, valDireccionPadre, Color.Gray);
                    setErrorMessage(null, errTrabajoPadre, txtTrabajoPadre, valTrabajoPadre, Color.Gray);
                    setErrorMessage(null, errTelefonoPadre, txtTelefonoPadre, valTelefonoPadre, Color.Gray);
                    setErrorMessage(null, errLugarTrabajaPadre, txtLugarTrabajoPadre, valLugarTrabajaPadre, Color.Gray);
                    setErrorMessage(null, errNombrePadre, txtNombrePadre, ValNombrePadre, Color.Gray);
                    NewObject.Padres.Remove(NewObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault());
                    EditingObject.Padres.Remove(EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault());

                }
                else
                {
                    if (NewObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault() == null)
                        NewObject.Padres.Add(EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault());

                    validation = txtNombrePadre.Text.Length == 0 && !Validation.Validation.Val_NameFormat(txtNombrePadre.Text) ?
                        setErrorMessage("El nombre del padre del estudiante no tiene un formato valido, por favor digite el nombre completo", errNombrePadre, txtNombrePadre, ValNombrePadre, Color.Red) :
                        setErrorMessage(null, errNombrePadre, txtNombrePadre, ValNombrePadre, Color.FromArgb(0, 100, 182));

                    NewObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.Persona.Nombre = txtNombrePadre.Text;

                    result = validation == false ? false : result;

                    validation = txtLugarTrabajoPadre.Text.Length > 0 && !Validation.Validation.Val_StringsLength(txtLugarTrabajoPadre.Text, 10) ?
                        setErrorMessage("El lugar donde trabaja del padre del estudiante no tiene un \nformato valido, por favor especifique el lugar en un minimo de 10 caracteres", errLugarTrabajaPadre, txtLugarTrabajoPadre, valLugarTrabajaPadre, Color.Red) :
                        setErrorMessage(null, errLugarTrabajaPadre, txtLugarTrabajoPadre, valLugarTrabajaPadre, Color.FromArgb(0, 100, 182));
                    NewObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.LugarTrabajo = txtLugarTrabajoPadre.Text;
                    result = validation == false ? false : result;

                    validation = txtTelefonoPadre.Text.Length > 0 && !Validation.Validation.Val_CellphoneFormat(txtTelefonoPadre.Text) ?
                       setErrorMessage("El telefono del padre del estudiante no cumple ningun formato valido, por favor digite un \ntelefono valido 22222222,+5037777777 o (+503)77777777", errTelefonoPadre, txtTelefonoPadre, valTelefonoPadre, Color.Red) :
                       setErrorMessage(null, errTelefonoPadre, txtTelefonoPadre, valTelefonoPadre, Color.FromArgb(0, 100, 182));
                    NewObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.Telefono = txtTelefonoPadre.Text;
                    result = validation == false ? false : result;

                    validation = txtTrabajoPadre.Text.Length > 0 && !Validation.Validation.Val_StringsLength(txtTrabajoPadre.Text, 10) ?
                        setErrorMessage("El trabaja u oficio del padre del estudiante no tiene un \nformato valido, por favor especifique el lugar en un minimo de 5 caracteres", errTrabajoPadre, txtTrabajoPadre, valTrabajoPadre, Color.Red) :
                        setErrorMessage(null, errTrabajoPadre, txtTrabajoPadre, valTrabajoPadre, Color.FromArgb(0, 100, 182));
                    NewObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.Trabajo = txtTrabajoPadre.Text;
                    result = validation == false ? false : result;

                    validation = txtDireccionPadre.Text.Length == 0 || !Validation.Validation.Val_StringsLength(txtDireccionPadre.Text, 20) ?
                        setErrorMessage("La direccion del padre del estudiante no cumple la longitud de 20 caracetes, por favor digite una \ndireccion valida con un minimo de 20 caracteres", errDireccionPadre, txtDireccionPadre, valDireccionPadre, Color.Red) :
                        setErrorMessage(null, errDireccionPadre, txtDireccionPadre, valDireccionPadre, Color.FromArgb(0, 100, 182));
                    NewObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.Persona.Direccion = txtDireccionPadre.Text;
                    result = validation == false ? false : result;
                }
            }
            else
            {
                NewObject.Padres.Add(EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault());
            }

            if (EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().Id == 0)
            {
                if (txtNombreMadre.Text.Trim() == "" && txtTelefonoMadre.Text.Trim() == "" && txtLugarTrabajoMadre.Text.Trim() == "" && txtTrabajoMadre.Text.Trim() == "" && txtDireccionMadre.Text.Trim() == "")
                {
                    setErrorMessage(null, errDireccionMadre, txtDireccionMadre, valDireccionMadre, Color.Gray);
                    setErrorMessage(null, errTrabajoMadre, txtTrabajoMadre, valTrabajoMadre, Color.Gray);
                    setErrorMessage(null, errTelefonoMadre, txtTelefonoMadre, valTelefonoMadre, Color.Gray);
                    setErrorMessage(null, errLugarTrabajaMadre, txtLugarTrabajoMadre, valLugarTrabajaMadre, Color.Gray);
                    setErrorMessage(null, errNombreMadre, txtNombreMadre, valNombreMadre, Color.Gray);
                    NewObject.Padres.Remove(NewObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault());
                    EditingObject.Padres.Remove(EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault());

                }
                else
                {
                    if (NewObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault() == null)
                        NewObject.Padres.Add(EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault());

                    validation = txtNombreMadre.Text.Length == 0 || !Validation.Validation.Val_NameFormat(txtNombreMadre.Text) ?
                        setErrorMessage("El nombre de la madre del estudiante no tiene un formato valido, por favor digite el nombre completo", errNombreMadre, txtNombreMadre, valNombreMadre, Color.Red) :
                        setErrorMessage(null, errNombreMadre, txtNombreMadre, valNombreMadre, Color.FromArgb(0, 100, 182));
                    NewObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.Persona.Nombre = txtNombreMadre.Text;
                    result = validation == false ? false : result;

                    validation = txtLugarTrabajoMadre.Text.Length > 0 && !Validation.Validation.Val_StringsLength(txtLugarTrabajoMadre.Text, 10) ?
                        setErrorMessage("El lugar donde trabaja la madre del estudiante no tiene un \nformato valido, por favor especifique el lugar en un minimo de 10 caracteres", errLugarTrabajaMadre, txtLugarTrabajoMadre, valLugarTrabajaMadre, Color.Red) :
                        setErrorMessage(null, errLugarTrabajaMadre, txtLugarTrabajoMadre, valLugarTrabajaMadre, Color.FromArgb(0, 100, 182));
                    NewObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.LugarTrabajo = txtLugarTrabajoMadre.Text;
                    result = validation == false ? false : result;

                    validation = txtTelefonoMadre.Text.Length > 0 && !Validation.Validation.Val_CellphoneFormat(txtTelefonoMadre.Text) ?
                       setErrorMessage("El telefono de la madre del estudiante no cumple ningun formato valido, por favor digite un \ntelefono valido 22222222,+5037777777 o (+503)77777777", errTelefonoMadre, txtTelefonoMadre, valTelefonoMadre, Color.Red) :
                       setErrorMessage(null, errTelefonoMadre, txtTelefonoMadre, valTelefonoMadre, Color.FromArgb(0, 100, 182));
                    NewObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.Telefono = txtTelefonoMadre.Text;
                    result = validation == false ? false : result;

                    validation = txtTrabajoMadre.Text.Length > 0 && !Validation.Validation.Val_StringsLength(txtTrabajoMadre.Text, 10) ?
                        setErrorMessage("El trabaja u oficio de la madre del estudiante no tiene un \nformato valido, por favor especifique el lugar en un minimo de 5 caracteres", errTrabajoMadre, txtTrabajoMadre, valTrabajoMadre, Color.Red) :
                        setErrorMessage(null, errTrabajoMadre, txtTrabajoMadre, valTrabajoMadre, Color.FromArgb(0, 100, 182));
                    NewObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.Trabajo = txtTrabajoMadre.Text;
                    result = validation == false ? false : result;

                    validation = txtDireccionMadre.Text.Length == 0 || !Validation.Validation.Val_StringsLength(txtDireccionMadre.Text, 20) ?
                        setErrorMessage("La direccion de la madre del estudiante no cumple la longitud de 20 caracetes, por favor digite una \ndireccion valida con un minimo de 20 caracteres", errDireccionMadre, txtDireccionMadre, valDireccionMadre, Color.Red) :
                        setErrorMessage(null, errDireccionMadre, txtDireccionMadre, valDireccionMadre, Color.FromArgb(0, 100, 182));
                    NewObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.Persona.Direccion = txtDireccionMadre.Text;
                    result = validation == false ? false : result;
                }
            }
            else
            {
                NewObject.Padres.Add(EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault());
            }



            if (!result)
            {
                NewObject = null;
            }
            return result;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (opc)
            {
                case "newObject":
                    if (Val_NewObject())
                    {
                        if (MessageBox.Show("Lo datos de inscripción fueron validados exitosamente\n¿Desea continuar con el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {

                                if (MatriculaDAL.insertMatricula(NewObject, Inicio.CurrentUser))
                                {
                                    MessageBox.Show("El estudiante ha sido inscrito exitosamente.", "Registro satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    EditingObject = null;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Ocurrio un error inesperado al intentar inscribir el estudiante, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.", "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ocurrio un error inesperado al intentar inscribir el estudiante, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.\nInfo adicional:\n\n\n " + ex.ToString(), "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hay algunos campos que necesitan ser verificados antes de poder guardar, por favor revise todos los campos antes de continuar.", "Alerta de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                case "updObject":
                    if (Val_UpdObject())
                    {
                        try
                        {

                            if (MatriculaDAL.updateMatricula(NewObject, Inicio.CurrentUser))
                            {
                                MessageBox.Show("la inscripcion del estudiante ha sido actualizada exitosamente.", "Acualización satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                EditingObject = null;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Ocurrio un error inesperado al intentar actualizar la inscripcion del estudiante, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.", "Acualización interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio un error inesperado al intentar actualizar la inscripcion del estudiante, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.\nInfo adicional:\n\n\n " + ex.ToString(), "Acualización interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private bool setErrorMessage(string pText, ErrorProvider err, Control ctrlToAdd, Panel pnlVal, Color valColor)
        {
            if (pText == null)
            {
                err.Clear();
                pnlVal.BackColor = valColor;
                return true;

            }
            else
            {
                err.SetError(ctrlToAdd, pText);
                pnlVal.BackColor = valColor;
                return false;

            }
        }
        private void txtNombreEst_Leave(object sender, EventArgs e)
        {
            EditingObject = EditingObject != null ? EditingObject : new Matricula();
            EditingObject.Estudiante = EditingObject.Estudiante != null ? EditingObject.Estudiante : new Estudiante();
            EditingObject.Estudiante.Persona = EditingObject.Estudiante.Persona != null ? EditingObject.Estudiante.Persona : new Persona();

            EditingObject.Padres = EditingObject.Padres != null ? EditingObject.Padres : new List<Detmatricula>();

            string name = (sender as Control).Name;
            bool validation = true;

            validation = name == "txtNombreEst" ? txtNombreEst.Text.Length > 0 && !Validation.Validation.Val_NameFormat(txtNombreEst.Text) ?
                setErrorMessage("El nombre del estudiante no tiene un formato valido, por favor digite el nombre completo", errNombreEst, txtNombreEst, valNombreEst, Color.Red) :
                setErrorMessage(null, errNombreEst, txtNombreEst, valNombreEst, txtNombreEst.Text.Length > 0 ? Color.FromArgb(0, 100, 182) : Color.Gray) : true;
            EditingObject.Estudiante.Persona.Nombre = validation && name == "txtNombreEst" ? txtNombreEst.Text : EditingObject.Estudiante.Persona.Nombre;

            validation = name == "txtApPaternoEst" ? txtApPaternoEst.Text.Length > 0 && (!Validation.Validation.Val_StringsLength(txtApPaternoEst.Text, 4) || !Validation.Validation.Val_LetterFormat(txtApPaternoEst.Text)) ?
                setErrorMessage("El apellido paterno del estudiante no tiene un formato valido, por favor digite un \napellido valido con un minimo de 4 caracteres", errApPaternoEst, txtApPaternoEst, valApPaternoEst, Color.Red) :
                setErrorMessage(null, errApPaternoEst, txtApPaternoEst, valApPaternoEst, txtApPaternoEst.Text.Length > 0 ? Color.FromArgb(0, 100, 182) : Color.Gray) : true;
            EditingObject.Estudiante.ApPaterno = validation && name == "txtApPaternoEst" ? txtApPaternoEst.Text : EditingObject.Estudiante.ApPaterno;

            validation = name == "txtApMaternoEst" ? txtApMaternoEst.Text.Length > 0 && (!Validation.Validation.Val_StringsLength(txtApMaternoEst.Text, 4) || !Validation.Validation.Val_LetterFormat(txtApPaternoEst.Text)) ?
                setErrorMessage("El apellido materno del estudiante no tiene un formato valido, por favor digite un \napellido valido con un minimo de 4 caracteres", errApMaternoEst, txtApMaternoEst, valApMaternoEst, Color.Red) :
                setErrorMessage(null, errApMaternoEst, txtApMaternoEst, valApMaternoEst, txtApMaternoEst.Text.Length > 0 ? Color.FromArgb(0, 100, 182) : Color.Gray) : true;
            EditingObject.Estudiante.ApMaterno = validation && name == "txtApMaternoEst" ? txtApMaternoEst.Text : EditingObject.Estudiante.ApMaterno;

            validation = name == "txtEnfermedadEst" ? txtEnfermedadEst.Text.Length > 0 && !Validation.Validation.Val_StringsLength(txtEnfermedadEst.Text, 5) ?
                setErrorMessage("El nombre de la enfermedad del estudiante no tiene un formato valido, por favor digite un \napellido valido con un minimo de 5 caracteres", errEnfermedadEst, txtEnfermedadEst, valEnfermedadEst, Color.Red) :
                setErrorMessage(null, errEnfermedadEst, txtEnfermedadEst, valEnfermedadEst, txtEnfermedadEst.Text.Length > 0 ? Color.FromArgb(0, 100, 182) : Color.Gray) : true;
            EditingObject.Estudiante.Enfermedad = validation && name == "txtEnfermedadEst" ? txtEnfermedadEst.Text : EditingObject.Estudiante.Enfermedad;

            validation = name == "txtDireccionEst" ? txtDireccionEst.Text.Length > 0 && !Validation.Validation.Val_StringsLength(txtDireccionEst.Text, 20) ?
                setErrorMessage("La direccion del estudiante no cumple la longitud de 20 caracetes, por favor digite una \ndireccion valida con un minimo de 20 caracteres", errDireccionEst, txtDireccionEst, valDireccionEst, Color.Red) :
                setErrorMessage(null, errDireccionEst, txtDireccionEst, valDireccionEst, txtDireccionEst.Text.Length > 0 ? Color.FromArgb(0, 100, 182) : Color.Gray) : true;
            EditingObject.Estudiante.Persona.Direccion = validation && name == "txtDireccionEst" ? txtDireccionEst.Text : EditingObject.Estudiante.Persona.Direccion;

            validation = name == "txtCorreoEst" ? txtCorreoEst.Text.Length > 0 && !Validation.Validation.Val_EmailFormat(txtCorreoEst.Text) ?
               setErrorMessage("La direccion de correo electronico no tiene un formato valido, por favor digite una \ndireccion valida \"micorreo@dominio.com\"", errCorreoEst, txtCorreoEst, valCorreoEst, Color.Red) :
               setErrorMessage(null, errCorreoEst, txtCorreoEst, valCorreoEst, txtCorreoEst.Text.Length > 0 ? Color.FromArgb(0, 100, 182) : Color.Gray) : true;
            EditingObject.Estudiante.Correo = validation && name == "txtCorreoEst" ? txtCorreoEst.Text : EditingObject.Estudiante.Correo;

            validation = name == "txtTelEstudiante" ? txtTelEstudiante.Text.Length > 0 && !Validation.Validation.Val_CellphoneFormat(txtTelEstudiante.Text) ?
               setErrorMessage("El telefono del estudiante no cumple ningun formato valido, por favor digite un \ntelefono valido 22222222,+5037777777 o (+503)77777777", errTelefonoEst, txtTelEstudiante, valTelefonoEst, Color.Red) :
               setErrorMessage(null, errTelefonoEst, txtTelEstudiante, valTelefonoEst, txtTelEstudiante.Text.Length > 0 ? Color.FromArgb(0, 100, 182) : Color.Gray) : true;
            EditingObject.Estudiante.Telefono = validation && name == "txtTelEstudiante" ? txtTelEstudiante.Text : EditingObject.Estudiante.Telefono;

            validation = name == "txtParentescoEmergencia" ? txtParentescoEmergencia.Text.Length > 0 && !Validation.Validation.Val_StringsLength(txtParentescoEmergencia.Text, 3) ?
               setErrorMessage("El parentesco o nombre tiene menos de 3 caracteres, por favor digite un parentesco con un minimo de 3 caracteres.", errParienteEmergencia, txtParentescoEmergencia, valParentesco, Color.Red) :
               setErrorMessage(null, errParienteEmergencia, txtParentescoEmergencia, valParentesco, txtParentescoEmergencia.Text.Length > 0 ? Color.FromArgb(0, 100, 182) : Color.Gray) : true;
            EditingObject.Estudiante.ParentEmergencia = validation && name == "txtParentescoEmergencia" ? txtParentescoEmergencia.Text : EditingObject.Estudiante.ParentEmergencia;

            validation = name == "txtTelEmergencia" ? txtTelEmergencia.Text.Length > 0 && !Validation.Validation.Val_CellphoneFormat(txtTelEmergencia.Text) ?
               setErrorMessage("El telefono de emergencia del estudiante no cumple ningun formato valido, por favor digite un \ntelefono valido 22222222, +5037777777 o (+503)77777777", errTelEmergencia, txtTelEmergencia, valTelEmergencia, Color.Red) :
               setErrorMessage(null, errTelEmergencia, txtTelEmergencia, valTelEmergencia, txtTelEmergencia.Text.Length > 0 ? Color.FromArgb(0, 100, 182) : Color.Gray) : true;
            EditingObject.Estudiante.TelEmergencia = validation && name == "txtTelEmergencia" ? txtTelEmergencia.Text : EditingObject.Estudiante.TelEmergencia;

            validation = name == "cmbCurso" ? cmbCurso.SelectedItem != null && MatriculaDAL.countMatriculasByCurso((Int64)cmbCurso.SelectedValue) == Properties.Settings.Default.MaxEstudentsIn ?
               setErrorMessage("Este curso ya tiene el limite de " + Properties.Settings.Default.MaxEstudentsIn + " de estudiantes inscritos\nSeleccione otro curso para poder continuar con la inscripcion.", errCurso, cmbCurso, valCurso, Color.Red) :
               setErrorMessage(null, errCurso, cmbCurso, valCurso, cmbCurso.SelectedValue != null ? Color.FromArgb(0, 100, 182) : Color.Gray) : true;
            EditingObject.IdCurso = validation && name == "cmbCurso" ? (Int64)cmbCurso.SelectedValue : EditingObject.Id;

            validation = name == "numDiaPago" ? numDiaPago.Value == 0 ?
              setErrorMessage("el dia maximo de pago no puede ser cero.", errDiaLimite, numDiaPago, valDiaPago, Color.Red) :
              setErrorMessage(null, errDiaLimite, numDiaPago, valDiaPago, numDiaPago.Value > 0 ? Color.FromArgb(0, 100, 182) : Color.Gray) : true;
            EditingObject.DiaLimite = validation && name == "numDiaPago" ? numDiaPago.Value.ToString() : EditingObject.DiaLimite;
            EditingObject.Becado = name == "checkBecado" ? checkBecado.Checked ? 1 : 0 : EditingObject.Becado;

            if (EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault() == null)
                EditingObject.Padres.Add(new Detmatricula(0, "Padre", EditingObject.Id, 0, new Encargado(0, "", "", "", 0, new Persona())));

            validation = name == "txtNombrePadre" ? txtNombrePadre.Text.Length > 0 && !Validation.Validation.Val_NameFormat(txtNombrePadre.Text) ?
                setErrorMessage("El nombre del padre del estudiante no tiene un formato valido, por favor digite el nombre completo", errNombrePadre, txtNombrePadre, ValNombrePadre, Color.Red) :
                setErrorMessage(null, errNombrePadre, txtNombrePadre, ValNombrePadre, txtNombrePadre.Text.Length > 0 ? Color.FromArgb(0, 100, 182) : Color.Gray) : true;
            EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.Persona.Nombre = validation && name == "txtNombrePadre" ? txtNombrePadre.Text : EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.Persona.Nombre;

            validation = name == "txtLugarTrabajoPadre" ? txtLugarTrabajoPadre.Text.Length > 0 && !Validation.Validation.Val_StringsLength(txtLugarTrabajoPadre.Text, 10) ?
            setErrorMessage("El lugar donde trabaja del padre del estudiante no tiene un \nformato valido, por favor especifique el lugar en un minimo de 10 caracteres", errLugarTrabajaPadre, txtLugarTrabajoPadre, valLugarTrabajaPadre, Color.Red) :
            setErrorMessage(null, errLugarTrabajaPadre, txtLugarTrabajoPadre, valLugarTrabajaPadre, txtLugarTrabajoPadre.Text.Length > 0 ? Color.FromArgb(0, 100, 182) : Color.Gray) : true;
            EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.LugarTrabajo = validation && name == "txtLugarTrabajoPadre" ? txtLugarTrabajoPadre.Text : EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.LugarTrabajo;

            validation = name == "txtTelefonoPadre" ? txtTelefonoPadre.Text.Length > 0 && !Validation.Validation.Val_CellphoneFormat(txtTelefonoPadre.Text) ?
               setErrorMessage("El telefono del padre del estudiante no cumple ningun formato valido, por favor digite un \ntelefono valido 22222222,+5037777777 o (+503)77777777", errTelefonoPadre, txtTelefonoPadre, valTelefonoPadre, Color.Red) :
               setErrorMessage(null, errTelefonoPadre, txtTelefonoPadre, valTelefonoPadre, txtTelefonoPadre.Text.Length > 0 ? Color.FromArgb(0, 100, 182) : Color.Gray) : true;
            EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.Telefono = validation && name == "txtTelefonoPadre" ? txtTelefonoPadre.Text : EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.Telefono;

            validation = name == "txtTrabajoPadre" ? txtTrabajoPadre.Text.Length > 0 && !Validation.Validation.Val_StringsLength(txtTrabajoPadre.Text, 10) ?
                setErrorMessage("El trabaja u oficio del padre del estudiante no tiene un \nformato valido, por favor especifique el lugar en un minimo de 5 caracteres", errTrabajoPadre, txtTrabajoPadre, valTrabajoPadre, Color.Red) :
                setErrorMessage(null, errTrabajoPadre, txtTrabajoPadre, valTrabajoPadre, txtLugarTrabajoPadre.Text.Length > 0 ? Color.FromArgb(0, 100, 182) : Color.Gray) : true;
            EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.Trabajo = validation && name == "txtTrabajoPadre" ? txtTrabajoPadre.Text : EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.Trabajo;

            validation = name == "txtDireccionPadre" ? txtDireccionPadre.Text.Length > 0 && !Validation.Validation.Val_StringsLength(txtDireccionPadre.Text, 20) ?
                setErrorMessage("La direccion del padre del estudiante no cumple la longitud de 20 caracetes, por favor digite una \ndireccion valida con un minimo de 20 caracteres", errDireccionPadre, txtDireccionPadre, valDireccionPadre, Color.Red) :
                setErrorMessage(null, errDireccionPadre, txtDireccionPadre, valDireccionPadre, txtDireccionPadre.Text.Length > 0 ? Color.FromArgb(0, 100, 182) : Color.Gray) : true;
            EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.Persona.Direccion = validation && name == "txtDireccionPadre" ? txtDireccionPadre.Text : EditingObject.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.Persona.Direccion;

            if (EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault() == null)
                EditingObject.Padres.Add(new Detmatricula(0, "Madre", EditingObject.Id, 0, new Encargado(0, "", "", "", 0, new Persona())));

            validation = name == "txtNombreMadre" ? txtNombreMadre.Text.Length > 0 && !Validation.Validation.Val_NameFormat(txtNombreMadre.Text) ?
                setErrorMessage("El nombre de la madre del estudiante no tiene un formato valido, por favor digite el nombre completo", errNombreMadre, txtNombreMadre, valNombreMadre, Color.Red) :
                setErrorMessage(null, errNombreMadre, txtNombreMadre, valNombreMadre, txtNombreMadre.Text.Length > 0 ? Color.FromArgb(0, 100, 182) : Color.Gray) : true;
            EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.Persona.Nombre = validation && name == "txtNombreMadre" ? txtNombreMadre.Text : EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.Persona.Nombre;

            validation = name == "txtLugarTrabajoMadre" ? txtLugarTrabajoMadre.Text.Length > 0 && !Validation.Validation.Val_StringsLength(txtLugarTrabajoMadre.Text, 10) ?
                setErrorMessage("El lugar donde trabaja la madre del estudiante no tiene un \nformato valido, por favor especifique el lugar en un minimo de 10 caracteres", errLugarTrabajaMadre, txtLugarTrabajoMadre, valLugarTrabajaMadre, Color.Red) :
                setErrorMessage(null, errLugarTrabajaMadre, txtLugarTrabajoMadre, valLugarTrabajaMadre, txtLugarTrabajoMadre.Text.Length > 0 ? Color.FromArgb(0, 100, 182) : Color.Gray) : true;
            EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.LugarTrabajo = validation && name == "txtLugarTrabajoMadre" ? txtLugarTrabajoMadre.Text : EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.LugarTrabajo;

            validation = name == "txtTelefonoMadre" ? txtTelefonoMadre.Text.Length > 0 && !Validation.Validation.Val_CellphoneFormat(txtTelefonoMadre.Text) ?
               setErrorMessage("El telefono de la madre del estudiante no cumple ningun formato valido, por favor digite un \ntelefono valido 22222222,+5037777777 o (+503)77777777", errTelefonoMadre, txtTelefonoMadre, valTelefonoMadre, Color.Red) :
               setErrorMessage(null, errTelefonoMadre, txtTelefonoMadre, valTelefonoMadre, txtTelefonoMadre.Text.Length > 0 ? Color.FromArgb(0, 100, 182) : Color.Gray) : true;
            EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.Telefono = validation && name == "txtTelefonoMadre" ? txtTelefonoMadre.Text : EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.Telefono;

            validation = name == "txtTrabajoMadre" ? txtTrabajoMadre.Text.Length > 0 && !Validation.Validation.Val_StringsLength(txtTrabajoMadre.Text, 10) ?
                setErrorMessage("El trabaja u oficio de la madre del estudiante no tiene un \nformato valido, por favor especifique el lugar en un minimo de 5 caracteres", errTrabajoMadre, txtTrabajoMadre, valTrabajoMadre, Color.Red) :
                setErrorMessage(null, errTrabajoMadre, txtTrabajoMadre, valTrabajoMadre, txtTrabajoMadre.Text.Length > 0 ? Color.FromArgb(0, 100, 182) : Color.Gray) : true;
            EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.Trabajo = validation && name == "txtTrabajoMadre" ? txtTrabajoMadre.Text : EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.Trabajo;

            validation = name == "txtDireccionMadre" ? txtDireccionMadre.Text.Length > 0 && !Validation.Validation.Val_StringsLength(txtDireccionMadre.Text, 20) ?
                setErrorMessage("La direccion de la madre del estudiante no cumple la longitud de 20 caracetes, por favor digite una \ndireccion valida con un minimo de 20 caracteres", errDireccionMadre, txtDireccionMadre, valDireccionMadre, Color.Red) :
                setErrorMessage(null, errDireccionMadre, txtDireccionMadre, valDireccionMadre, txtDireccionMadre.Text.Length > 0 ? Color.FromArgb(0, 100, 182) : Color.Gray) : true;
            EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.Persona.Direccion = validation && name == "txtDireccionMadre" ? txtDireccionMadre.Text : EditingObject.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.Persona.Direccion;

        }

        private void btnClearPadre_Click(object sender, EventArgs e)
        {
            clearPadre(true);
        }

        private void btnClearMadre_Click(object sender, EventArgs e)
        {
            clearMadre(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMatricula_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (opc== "updObject")
            {
                if (!CurrentObject.Equals(EditingObject))
                {

                }
            }
        }
    }
}
