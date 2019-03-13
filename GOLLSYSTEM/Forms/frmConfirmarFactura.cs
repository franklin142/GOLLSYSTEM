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
namespace GOLLSYSTEM.Forms
{
    public partial class frmConfirmarFactura : Form
    {
        public Factura currentFactura;
        public frmConfirmarFactura()
        {
            InitializeComponent();
        }
        private void frmConfirmarFactura_Load(object sender, EventArgs e)
        {
            decimal total = 0;
            decimal descuento = 0;
            decimal subtotal = 0;
            foreach (Detfactura det in currentFactura.DetsFactura) subtotal += det.Total;
            foreach (Detfactura det in currentFactura.DetsFactura) descuento += det.Descuento;
            total = subtotal - descuento;
            lblTotal.Text = Decimal.Round(total, 2).ToString();
            lblDescuento.Text = Decimal.Round(descuento, 2).ToString();
            lblSubtotal.Text = Decimal.Round(subtotal, 2).ToString();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                currentFactura.Observacion = txtObservacion.Text;

                if (FacturaDAL.insertFactura(currentFactura, Inicio.CurrentUser))
                {
                    MessageBox.Show("El ingreso ha sido registrado exitosamente.", "Registro satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    currentFactura = null;
                    this.DialogResult=DialogResult.Yes;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error inesperado al intentar registrar el ingreso, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.", "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error inesperado al intentar registrar el ingreso, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.\nInfo adicional del problema:\n\n\n " + ex.ToString(), "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            if (txtCash.Text!=""&&Validation.Validation.Val_DecimalFormat(txtCash.Text))
            {
                decimal total = 0;
                decimal descuento = 0;
                decimal subtotal = 0;
                foreach (Detfactura det in currentFactura.DetsFactura) subtotal += det.Total;
                foreach (Detfactura det in currentFactura.DetsFactura) descuento += det.Descuento;
                total = subtotal - descuento;
                lblCambio.Text = (Decimal.Round(Convert.ToDecimal(txtCash.Text) - total, 2)).ToString();
            }
            else
            {
                lblCambio.Text = "0.00";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
