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
    public partial class FrmProducto : Form
    {
        public Producto NewObject;
        public Producto EditingObject;

        public FrmProducto()
        {
            InitializeComponent();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                if (Val_NewObject())
                {
                    if (ProductoDAL.insertProducto(NewObject, Inicio.CurrentUser))
                    {
                        MessageBox.Show("El producto ha sido registrado exitosamente.", "Registro satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EditingObject = null;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error inesperado al intentar registrar el producto, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.", "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";
                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ocurrio un error inesperado al intentar registrar el producto o servicio");
                MessageBox.Show("Ocurrio un error inesperado al intentar registrar el producto o servicio, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool Val_NewObject()
        {
            bool result = true;
            NewObject = new Producto();
            if (!Validation.Validation.Val_StringsLength(txtNombre.Text, 4))
            {
                errNombre.SetError(txtNombre, "El nombre del producto esta vacio o tiene menos de 4 caracteres, este valor es obligatorio.");
                valNombre.BackColor = Color.Red;
                result = false;
            }
            else
            {
                valNombre.BackColor = Color.FromArgb(0, 100, 182);
                errNombre.Clear();
                NewObject.Nombre = txtNombre.Text;

            }

            if (!Validation.Validation.Val_StringsLength(txtPrecio.Text, 1))
            {
                errPrecio.SetError(txtPrecio, "El precio del producto esta vacio, este valor es obligatorio.");
                valPrecio.BackColor = Color.Red;
                result = false;

            }
            else
            {
                valPrecio.BackColor = Color.FromArgb(0, 100, 182);
                errPrecio.Clear();

                if (!Validation.Validation.Val_DecimalFormat(txtPrecio.Text))
                {
                    errPrecio.SetError(txtPrecio, "El precio del producto no tiene un formato correcto, este valor debe ser de tipo decimal o numerico.");
                    valPrecio.BackColor = Color.Red;
                    result = false;
                }
                else
                {
                    valPrecio.BackColor = Color.FromArgb(0, 100, 182);
                    errPrecio.Clear();
                    NewObject.Precio = Convert.ToDecimal(txtPrecio.Text);
                }
            }

            return result;
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            txtPrecio.Text = txtPrecio.Text == "" || txtPrecio.Text == "." || txtPrecio.Text == "-0" ? "0.00" : txtPrecio.Text;

            if (!Validation.Validation.Val_DecimalFormat(txtPrecio.Text))
            {
                errPrecio.SetError(txtPrecio, "El precio del producto no tiene un formato correcto, este valor debe ser de tipo decimal o numerico.");
                valPrecio.BackColor = Color.Red;
            }
            else
            {
                valPrecio.BackColor = Color.FromArgb(0, 100, 182);
                errPrecio.Clear();
                txtPrecio.Text = Convert.ToDecimal(txtPrecio.Text) < 0 ? "0.00" : txtPrecio.Text;
            }
        }

        private void txtPrecio_Enter(object sender, EventArgs e)
        {
            if (txtPrecio.Text == "0.00")
            {
                txtPrecio.Text = "";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
