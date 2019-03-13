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
    public partial class FrmFactura : Form
    {
        public bool cancelacion = false;
        public bool mensualidad = false;
        public bool reservacion = false;

        public Factura NewObject;
        public Factura EditingObject;
        public FrmFactura()
        {
            InitializeComponent();
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            EditingObject = new Factura();
            EditingObject.DetsFactura = new List<Detfactura>();
            lblFHRegistro.Text = DateTime.Now.ToShortDateString();
            lblSucursal.Text = Inicio.CurrentSucursal.Nombre;
            lblNFactura.Text = "Automático";
        }

        private void btnMesualidad_Click(object sender, EventArgs e)
        {
            if (EditingObject.DetsFactura.Where(a => a.Tipo == "M").FirstOrDefault() == null)
            {
                frmBuscarProducto buscarproducto = new frmBuscarProducto();
                buscarproducto.opc = "Mensualidad";
                buscarproducto.ShowDialog();
                if (buscarproducto.currentDetFactura != null)
                {
                    EditingObject.DetsFactura.Add(buscarproducto.currentDetFactura);
                    dgvCursos.Rows.Add(0, "Pago de mensualidad", "Mensualidad",
                        buscarproducto.currentDetFactura.Producto.Precio,
                        buscarproducto.currentDetFactura.Descuento,
                        buscarproducto.currentDetFactura.Total,
                        buscarproducto.currentDetFactura.IdProducto);
                    CalucularTotales();

                }
            }
            else
            {
                MessageBox.Show("Ya ha agregado un pago de mensualidad al detalle de esta factura.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmBuscarPersona buscarPersona = new frmBuscarPersona();
            buscarPersona.ShowDialog();
            if (buscarPersona.currentObject != null)
            {
                EditingObject.IdPersona = buscarPersona.currentObject.Id;
                txtNombre.Text = buscarPersona.currentObject.Nombre;
                txtTelefono.Text = "No disponible";
                valNombre.BackColor = Color.FromArgb(0, 100, 182);
            }
        }

        private void btnRemoveDetalle_Click(object sender, EventArgs e)
        {
            if (dgvCursos.CurrentRow != null)
            {
                EditingObject.DetsFactura.Remove(EditingObject.DetsFactura.Where(a => a.IdProducto == (Int64)dgvCursos.CurrentRow.Cells["idproducto"].Value).FirstOrDefault());
                dgvCursos.Rows.Remove(dgvCursos.CurrentRow);
                CalucularTotales();
            }
        }
        private void CalucularTotales()
        {
            decimal total = 0;
            decimal descuento = 0;
            decimal subtotal = 0;
            foreach (Detfactura det in EditingObject.DetsFactura) subtotal += det.Total;
            foreach (Detfactura det in EditingObject.DetsFactura) descuento += det.Descuento;
            total = subtotal - descuento;
            lblTotal.Text = "$" + Decimal.Round(total, 2);
            lblSubtotal.Text = "$" + Decimal.Round(subtotal, 2);
            lblDescuento.Text = "$" + Decimal.Round(descuento, 2);

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (Val_NewObject())
            {
                frmConfirmarFactura confirmar = new frmConfirmarFactura();
                confirmar.currentFactura = NewObject;
                confirmar.ShowDialog();
                if (confirmar.DialogResult == DialogResult.Yes) this.Close();

            }

        }
        private bool Val_NewObject()
        {
            bool result = true;
            NewObject = new Factura();
            NewObject.DetsFactura = new List<Detfactura>();

            if (EditingObject.IdPersona == 0)
            {
                errNombre.SetError(txtNombre, "No ha seleccionado ningun cliente,\npor favor seleccione uno ya que este campo es obligatorio.");
                valNombre.BackColor = Color.Red;
                result = false;
            }
            else
            {
                valNombre.BackColor = Color.FromArgb(0, 100, 182);
                errNombre.Clear();
                NewObject.IdPersona = EditingObject.IdPersona;
            }
            if (EditingObject.DetsFactura.Count == 0)
            {

                errDetalles.SetError(dgvCursos, "No ha ingresado ningun pago o detalle de factura para este ingreso,\npor favor ingresar al menos un detalle para continuar.");
                valDetalles.BackColor = Color.Red;
                result = false;
            }
            else
            {
                valDetalles.BackColor = Color.FromArgb(0, 100, 182);

                errDetalles.Clear();
                NewObject.DetsFactura = EditingObject.DetsFactura;
            }
            NewObject.IdSucursal = Inicio.CurrentSucursal.Id;
            decimal total = 0;
            decimal descuento = 0;
            decimal subtotal = 0;
            foreach (Detfactura det in EditingObject.DetsFactura) subtotal += det.Total;
            foreach (Detfactura det in EditingObject.DetsFactura) descuento += det.Descuento;
            total = subtotal - descuento;

            NewObject.Total = subtotal;

            return result;
        }

        private void btnContado_Click(object sender, EventArgs e)
        {
            frmBuscarProducto buscarproducto = new frmBuscarProducto();
            buscarproducto.opc = "Contado";
            buscarproducto.ShowDialog();
            if (buscarproducto.currentDetFactura != null)
            {
                EditingObject.DetsFactura.Add(buscarproducto.currentDetFactura);
                dgvCursos.Rows.Add(0, buscarproducto.currentDetFactura.Producto.Nombre, "Contado",
                    buscarproducto.currentDetFactura.Producto.Precio,
                    buscarproducto.currentDetFactura.Descuento,
                    buscarproducto.currentDetFactura.Total,
                    buscarproducto.currentDetFactura.IdProducto);
                CalucularTotales();

            }
        }
    }
}
