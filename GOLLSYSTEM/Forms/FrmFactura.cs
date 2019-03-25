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
            try
            {
                if (EditingObject != null)
                {
                    btnBuscarCliente.Enabled = false;
                    btnMesualidad.Enabled = false;
                    btnCancelacion.Enabled = false;
                    btnContado.Enabled = false;
                    btnGuardar.Text = "Imprimir";
                    btnRemoveDetalle.Enabled = false;
                    txtNombre.Text = PersonaDAL.getPersonaById(EditingObject.IdPersona).Nombre;
                    txtTelefono.Text = "No Disponible";
                    lblFHRegistro.Text = Convert.ToDateTime(EditingObject.FhRegistro).ToString("dd/MM/yyyy");
                    lblSucursal.Text = SucursalDAL.getSucursaloById(EditingObject.IdSucursal).Nombre;
                    lblNFactura.Text = EditingObject.NFactura;
                    foreach (Detfactura det in EditingObject.DetsFactura)
                        dgvCursos.Rows.Add(
                                    det.Id,
                                    det.Producto.Nombre,
                                    det.Tipo == "M" ? "Mensualidad" : det.Tipo == "R" ? "Reservación" : "Cancelación",
                                    det.Producto.Precio,
                                    det.Descuento,
                                    det.Total,
                                    det.IdProducto);

                    CalucularTotales();
                }
                else
                {
                    EditingObject = new Factura();
                    EditingObject.DetsFactura = new List<Detfactura>();
                    lblFHRegistro.Text = DateTime.Now.ToShortDateString();
                    lblSucursal.Text = Inicio.CurrentSucursal.Nombre;
                    lblNFactura.Text = "Automático";
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

        private void btnMesualidad_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ha ocurrido un error al intentar cargar la información de la cuota en este control");
                MessageBox.Show("Ha ocurrido un error al intentar cargar la información de la cuota en este control, por favor comuniquese con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ha ocurrido un error al intentar cargar la información del cliente en este control");
                MessageBox.Show("Ha ocurrido un error al intentar cargar la información del cliente en este control, por favor comuniquese con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                if (Val_NewObject())
                {
                    frmConfirmarFactura confirmar = new frmConfirmarFactura();
                    confirmar.currentFactura = EditingObject.Id == 0 ? NewObject : EditingObject;
                    confirmar.ShowDialog();
                    if (confirmar.DialogResult == DialogResult.Yes) this.Close();
                }
            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";
                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ocurrio un error inesperado al intentar registrar el ingreso e imprimir la factura");
                MessageBox.Show("Ocurrio un error inesperado al intentar registrar el ingreso e imprimir la factura, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                frmBuscarProducto buscarproducto = new frmBuscarProducto();
                buscarproducto.opc = "Contado";
                buscarproducto.ShowDialog();
                if (buscarproducto.currentDetFactura != null)
                {
                    EditingObject.DetsFactura.Add(buscarproducto.currentDetFactura);
                    dgvCursos.Rows.Add(0, buscarproducto.currentDetFactura.Producto.Nombre, buscarproducto.currentDetFactura.Total < buscarproducto.currentDetFactura.Producto.Precio ? "Reservacion" : "Contado",
                        buscarproducto.currentDetFactura.Producto.Precio,
                        buscarproducto.currentDetFactura.Descuento,
                        buscarproducto.currentDetFactura.Total,
                        buscarproducto.currentDetFactura.IdProducto);
                    CalucularTotales();

                }
            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ha ocurrido un error al intentar cargar la información del producto o servicio en este control");
                MessageBox.Show("Ha ocurrido un error al intentar cargar la información del producto o servicio en este control, por favor comuniquese con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancelacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (EditingObject.IdPersona > 0)
                {
                    frmBuscarProducto buscarproducto = new frmBuscarProducto();
                    buscarproducto.opc = "Cancelacion";
                    buscarproducto.IdPersona = EditingObject.IdPersona;
                    buscarproducto.ShowDialog();
                    if (buscarproducto.currentDetFactura != null)
                    {
                        if (EditingObject.DetsFactura.Where(a => a.RefNFactura == buscarproducto.currentDetFactura.RefNFactura).SingleOrDefault() != null)
                        {
                            if (MessageBox.Show("Ya existe una cancelación para este producto o servicio y no se puede duplicar el detalle. ¿Desea hacer un solo detalle fusionando los datos?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                decimal totaldebe = DetFacturaDAL.getTotalDebeReserva(buscarproducto.currentDetFactura.Id, EditingObject.IdPersona);

                                if (EditingObject.DetsFactura.Where(a => a.RefNFactura == buscarproducto.currentDetFactura.RefNFactura).SingleOrDefault().Total + buscarproducto.currentDetFactura.Total > totaldebe)
                                {
                                    EditingObject.DetsFactura.Where(a => a.RefNFactura == buscarproducto.currentDetFactura.RefNFactura).SingleOrDefault().Total = totaldebe;
                                }
                                else
                                {
                                    EditingObject.DetsFactura.Where(a => a.RefNFactura == buscarproducto.currentDetFactura.RefNFactura).SingleOrDefault().Total += buscarproducto.currentDetFactura.Total;

                                }
                                if (EditingObject.DetsFactura.Where(a => a.RefNFactura == buscarproducto.currentDetFactura.RefNFactura).SingleOrDefault().Descuento + buscarproducto.currentDetFactura.Descuento > totaldebe)
                                {
                                    EditingObject.DetsFactura.Where(a => a.RefNFactura == buscarproducto.currentDetFactura.RefNFactura).SingleOrDefault().Descuento = totaldebe;
                                }
                                else
                                {
                                    EditingObject.DetsFactura.Where(a => a.RefNFactura == buscarproducto.currentDetFactura.RefNFactura).SingleOrDefault().Descuento += buscarproducto.currentDetFactura.Descuento;

                                }
                                for (int i = 0; i < dgvCursos.Rows.Count; i++)
                                {
                                    dgvCursos.Rows[i].Cells["descuento"].Value = (Int64)dgvCursos.Rows[i].Cells[0].Value == EditingObject.DetsFactura.Where(a => a.RefNFactura == buscarproducto.currentDetFactura.RefNFactura).SingleOrDefault().Id ? EditingObject.DetsFactura.Where(a => a.RefNFactura == buscarproducto.currentDetFactura.RefNFactura).SingleOrDefault().Descuento.ToString() : dgvCursos.Rows[i].Cells["descuento"].Value.ToString();
                                    dgvCursos.Rows[i].Cells["subtotal"].Value = (Int64)dgvCursos.Rows[i].Cells[0].Value == EditingObject.DetsFactura.Where(a => a.RefNFactura == buscarproducto.currentDetFactura.RefNFactura).SingleOrDefault().Id ? EditingObject.DetsFactura.Where(a => a.RefNFactura == buscarproducto.currentDetFactura.RefNFactura).SingleOrDefault().Total.ToString() : dgvCursos.Rows[i].Cells["subtotal"].Value.ToString();

                                }
                                CalucularTotales();
                            }
                        }
                        else
                        {
                            EditingObject.DetsFactura.Add(buscarproducto.currentDetFactura);
                            dgvCursos.Rows.Add(
                                buscarproducto.currentDetFactura.Id,
                                buscarproducto.currentDetFactura.Producto.Nombre, "Cancelación",
                                buscarproducto.currentDetFactura.Producto.Precio,
                                buscarproducto.currentDetFactura.Descuento,
                                buscarproducto.currentDetFactura.Total,
                                buscarproducto.currentDetFactura.IdProducto);
                            CalucularTotales();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ha ocurrido un error al intentar cargar la información de la cuenta pendiente en este control");
                MessageBox.Show("Ha ocurrido un error al intentar cargar la información de la cuenta pendiente en este control, por favor comuniquese con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
