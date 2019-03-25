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
    public partial class FrmEgreso : Form
    {
        public Egreso EditingObject;
        public Egreso NewObject;

        public FrmEgreso()
        {
            InitializeComponent();
        }

        private void FrmEgreso_Load(object sender, EventArgs e)
        {
            try
            {
                if (EditingObject != null)
                {
                    txtNombre.Text = EditingObject.Nombre;
                    txtTipo.Text = EditingObject.Tipo;
                    txtTotal.Text = EditingObject.Total.ToString();
                    dtpFHRegistro.Value = Convert.ToDateTime(EditingObject.FhRegistro);
                    lblTitulo.Text = "Editar Egreso";
                }
                else
                {
                    EditingObject = new Egreso();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Val_NewObject())
                {
                    if (EgresoDAL.insertEgreso(NewObject, Inicio.CurrentUser))
                    {
                        MessageBox.Show("El egreso ha sido " + (EditingObject.Id == 0 ? "registrado" : "actualizado") + " exitosamente.", "Registro satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EditingObject = null;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error inesperado al intentar " + (EditingObject.Id == 0 ? "registrar" : "actualizar") + " el egreso, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.", "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";
                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ocurrio un error inesperado al intentar registrar el egreso");
                MessageBox.Show("Ocurrio un error inesperado al intentar registrar el egreso, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool Val_NewObject()
        {
            bool result = true;
            NewObject = new Egreso();
            txtTotal.Text = txtTotal.Text == "" || txtTotal.Text == "." || txtTotal.Text == "-0" ? "0.00" : txtTotal.Text;
            if (!Validation.Validation.Val_StringsLength(txtNombre.Text, 5))
            {
                errNombre.SetError(txtNombre, "El nombre del egreso no tiene un formato adecuado,\npor favor ingrese un nombre con un minimo de 5 caracteres.");
                valNombre.BackColor = Color.Red;
                result = false;
            }
            else
            {
                valNombre.BackColor = Color.FromArgb(0, 100, 182);
                errNombre.Clear();
                NewObject.Nombre = txtNombre.Text;

            }

            if (!Validation.Validation.Val_StringsLength(txtTipo.Text, 5))
            {
                errTipo.SetError(txtTipo, "El tipo de egreso no tiene un formato adecuado,\npor favor ingrese una descripción con un minimo de 5 caracteres.");
                valTipo.BackColor = Color.Red;
                result = false;
            }
            else
            {
                valTipo.BackColor = Color.FromArgb(0, 100, 182);
                errTipo.Clear();
                NewObject.Tipo = txtTipo.Text;

            }
            if (Validation.Validation.Val_DecimalFormat(txtTotal.Text))
            {

                if (Convert.ToDecimal(txtTotal.Text) > 9999999)
                {
                    errTotal.SetError(txtTotal, "El total del egreso no tiene un formato adecuado,\npor favor ingrese un numero entero o decimal inferior a 9,999,999.");
                    valTotal.BackColor = Color.Red;
                    result = false;
                }

                if (Convert.ToDecimal(txtTotal.Text) < 0)
                {
                    errTotal.SetError(txtTotal, "El total del egreso no puede ser una cifra negativa,\npor favor ingrese un numero entero o decimal positivo.");
                    valTotal.BackColor = Color.Red;
                    result = false;
                }
                if (result)
                {
                    valTotal.BackColor = Color.FromArgb(0, 100, 182);
                    errTotal.Clear();
                    NewObject.Total = Decimal.Round(Convert.ToDecimal((txtTotal.Text)), 2);
                }
            }
            else
            {
                errTotal.SetError(txtTotal, "El total del egreso no tiene un formato adecuado,\npor favor ingrese un numero entero o decimal.");
                valTotal.BackColor = Color.Red;
                result = false;
            }
            NewObject.FhRegistro = dtpFHRegistro.Value.ToString("yyyy-MM-dd:hh:mm:ss");
            NewObject.IdSucursal = Inicio.CurrentSucursal.Id;
            NewObject.Id = EditingObject.Id;
            return result;
        }

        private void txtTotal_Leave(object sender, EventArgs e)
        {
            txtTotal.Text = txtTotal.Text == "" || txtTotal.Text == "." || txtTotal.Text == "-0" ? "0.00" : txtTotal.Text;

            if (Validation.Validation.Val_DecimalFormat(txtTotal.Text))
            {

                if (Convert.ToDecimal(txtTotal.Text) > 9999999)
                {
                    txtTotal.Text = "9999999";
                }
                if (Convert.ToDecimal(txtTotal.Text) < 0)
                {
                    txtTotal.Text = "0.00";
                }

                valTotal.BackColor = Color.FromArgb(0, 100, 182);
                errTotal.Clear();

            }
            else
            {
                errTotal.SetError(txtTotal, "El total del egreso no tiene un formato adecuado,\npor favor ingrese un numero entero o decimal.");
                valTotal.BackColor = Color.Red;
            }
        }
    }
}
