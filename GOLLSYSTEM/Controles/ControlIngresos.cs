using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GOLLSYSTEM.Forms;
using GOLLSYSTEM.EntityLayer;
using GOLLSYSTEM.DataAccess;
using System.Threading;
using System.Reflection;
using System.Globalization;

namespace GOLLSYSTEM.Controles
{
    public partial class ControlIngresos : Form
    {
        public int pLimit = 25;
        public int ingresoMes = 0;
        public int currentPage = 1;
        public int numPages = 0;
        public List<List<Int64>> Pages = new List<List<Int64>>();
        public List<Int64> listCurrentPage = new List<Int64>();


        public ControlIngresos()
        {
            InitializeComponent();
        }

        private void ControlIngresos_Load(object sender, EventArgs e)
        {
            try
            {
                cbxYear.DataSource = YearDAL.getYears(10000);
                cbxYear.DisplayMember = "Desde";
                cbxYear.ValueMember = "Id";
                DateTime date = DateTime.Today.AddMonths(-(DateTime.Today.Month - 1));
                for (int i = 0; i < 12; i++)
                {
                    cbxMonth.Items.Add(date.AddMonths(i).ToString("MMMM"));
                }


                cbxMonth.SelectedIndex = DateTime.Now.Month - 1;
                cbxYear.SelectedIndex = 0;
                Pages = rdbMontYear.Checked ? FacturaDAL.getIdsFacturasByParametro(Convert.ToInt64((cbxYear.SelectedItem as Year).Desde), Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2010").ToString("MM"), Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit) : FacturaDAL.getIdsFacturasNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit);
                numPages = Pages.Count;
                SetCurrentPage();
                tmrTaskDgv.Start();

                cbxMonth.SelectedIndexChanged += cbxMonth_SelectedIndexChanged;
                cbxYear.SelectedIndexChanged += cbxMonth_SelectedIndexChanged;
                rdbMontYear.CheckedChanged += cbxMonth_SelectedIndexChanged;
                if (ingresoMes == 1)
                {
                    pnlParametro.Enabled = false;
                    pnlParametro.Visible = false;
                    cbxMonth.Enabled = false;
                    cbxYear.Enabled = false;
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    lblTiltulo.Text = "Ingresos del mes de " + DateTime.Now.ToString("MMMM",new CultureInfo("es-ES"));
                }
            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ha ocurrido un error al intentar cargar la información de este control");
                MessageBox.Show("Ha ocurrido un error al intentar cargar la información de este control, por favor comuniquese con el desarrollador al correo franklingranados2@yahoo.com", "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void FillDgv(List<Factura> lista)
        {
            dgvIngresos.Rows.Clear();
            numPages = Pages.Count;
            SetCurrentPage();

            foreach (Factura obj in lista)
            {
                string concepto = "";
                foreach (Detfactura det in obj.DetsFactura) concepto += det.Concepto + (obj.DetsFactura.Count > 1 ? obj.DetsFactura.Last().Id == det.Id ? "." : ", " : ".");
                decimal total = 0;
                decimal descuento = 0;
                decimal subtotal = 0;
                foreach (Detfactura det in obj.DetsFactura) subtotal += det.Total;
                foreach (Detfactura det in obj.DetsFactura) descuento += det.Descuento;
                total = subtotal - descuento;

                dgvIngresos.Rows.Add(obj.Id,
                    obj.NFactura,
                    Convert.ToDateTime(obj.FhRegistro).ToString("dd-MM-yyyy"),
                    PersonaDAL.getPersonaById(obj.IdPersona).Nombre,
                    concepto,
                    Decimal.Round(subtotal, 2).ToString(),
                    Decimal.Round(descuento, 2).ToString(),
                    "$" + Decimal.Round(total, 2).ToString()
                    );
            }

            CalcularGanancias(rdbMontYear.Checked ? FacturaDAL.getTotalFacturasByParametro(Convert.ToInt64((cbxYear.SelectedItem as Year).Desde), Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2010").ToString("MM"), Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit) : FacturaDAL.getTotalFacturasNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit),
            rdbMontYear.Checked ? EgresoDAL.getTotalEgresoByParametro(Convert.ToInt64((cbxYear.SelectedItem as Year).Desde), Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2010").ToString("MM"), Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit) : EgresoDAL.getTotalEgresoNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit));
            lblPages.Text = "Página " + currentPage + " de " + (numPages == 0 ? "1" : numPages.ToString());

            return;
        }

        private void btnNuevoEgreso_Click(object sender, EventArgs e)
        {
            FrmFactura factura = new FrmFactura();
            factura.ShowDialog();
            Pages = rdbMontYear.Checked ? FacturaDAL.getIdsFacturasByParametro(Convert.ToInt64((cbxYear.SelectedItem as Year).Desde), Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2010").ToString("MM"), Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit) : FacturaDAL.getIdsFacturasNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit);
            numPages = Pages.Count;
            SetCurrentPage();

            tmrTaskDgv.Start();
        }
        private void CalcularGanancias(decimal facturas, decimal egresos)
        {
            decimal tIngresos = facturas;
            decimal tEgresos = egresos;



            lblTotalGanancia.Text = "$" + Decimal.Round((tIngresos - tEgresos), 2).ToString();
            lblTotalEgresos.Text = "-$" + Decimal.Round(tEgresos, 2).ToString();
            lblTotalIngresos.Text = "$" + Decimal.Round(tIngresos, 2).ToString();
            lblTotalGanancia.ForeColor = Decimal.Round((tIngresos - tEgresos), 2) < 0 ? Color.OrangeRed : Color.DarkGreen;
        }

        private void icUpdate_Click(object sender, EventArgs e)
        {
            Pages = rdbMontYear.Checked ? FacturaDAL.getIdsFacturasByParametro(Convert.ToInt64((cbxYear.SelectedItem as Year).Desde), Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2010").ToString("MM"), Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit) : FacturaDAL.getIdsFacturasNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit);
            numPages = Pages.Count;
            SetCurrentPage();
            tmrTaskDgv.Start();
        }
        private void cbxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtCurrentIndex.Text = "1";
                Pages = rdbMontYear.Checked ? FacturaDAL.getIdsFacturasByParametro(Convert.ToInt64((cbxYear.SelectedItem as Year).Desde), Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2010").ToString("MM"), Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit) : FacturaDAL.getIdsFacturasNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit);
                numPages = Pages.Count;
                SetCurrentPage();
                tmrTaskDgv.Start();
            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ha ocurrido un error al intentar cargar la información de ingresos sin parametros");
                MessageBox.Show("Ha ocurrido un error al intentar cargar la información de ingresos sin parametros, por favor comuniquese con el desarrollador al correo franklingranados2@yahoo.com", "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tmrTask_Tick(object sender, EventArgs e)
        {

            FillDgv(GetListFacturas(listCurrentPage));
            tmrTaskDgv.Stop();
        }
        private List<Factura> GetListFacturas(List<Int64> pLista)
        {
            List<Factura> facturas = new List<Factura>();
            if (pLista != null)
            {
                facturas = rdbMontYear.Checked ? FacturaDAL.getFacturasIndexerParametro(Convert.ToInt64((cbxYear.SelectedItem as Year).Desde), Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2010").ToString("MM"), Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, currentPage - 1, pLimit) : FacturaDAL.getFacturasIndexerNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, currentPage - 1, pLimit);
            }
            return facturas;
        }
        private void SelectPage(int pNum)
        {
            currentPage = pNum;
            SetCurrentPage();
        }
        private void SetCurrentPage()
        {
            listCurrentPage = Pages.Count == 0 ? null : Pages[currentPage - 1];
        }
        private void txtCurrentIndex_TextChanged(object sender, EventArgs e)
        {
            if (Pages.Count != 0)
            {
                int index = Convert.ToInt32(txtCurrentIndex.Text);

                SelectPage(index);
                tmrTaskDgv.Start();
            }
        }
        private void lknNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int index = Convert.ToInt32(txtCurrentIndex.Text) + 1;

            if (index <= Pages.Count)
            {
                txtCurrentIndex.Text = index.ToString();
            }
        }

        private void lknBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int index = Convert.ToInt32(txtCurrentIndex.Text) - 1;

            if (index >= 1)
            {
                txtCurrentIndex.Text = index.ToString();
            }
        }

        private void lknInicio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtCurrentIndex.Text = 1.ToString();

        }

        private void lknFin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtCurrentIndex.Text = Pages.Count == 0 ? "1" : Pages.Count.ToString();

        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvIngresos.CurrentRow != null)
                if (FacturaDAL.getIsParentReservas((Int64)dgvIngresos.CurrentRow.Cells[0].Value))
                {
                    if (MessageBox.Show("¿Esta seguro que desea anular esta factura? si lo hace, tambien se anularan los pagos que se le allan cobrado al cliente. Este ingreso ya no aparecerá en los resgistros.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (FacturaDAL.anularFactura((Int64)dgvIngresos.CurrentRow.Cells[0].Value, true, Inicio.CurrentUser))
                        {
                            MessageBox.Show("La factura ha sido anulada correctamente, los calculos se reiniciarán automaticamente.", "Operación realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Pages = rdbMontYear.Checked ? FacturaDAL.getIdsFacturasByParametro(Convert.ToInt64((cbxYear.SelectedItem as Year).Desde), Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2010").ToString("MM"), Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit) : FacturaDAL.getIdsFacturasNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit);
                            numPages = Pages.Count;
                            SetCurrentPage();
                            tmrTaskDgv.Start();
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("¿Esta seguro que desea anular esta factura? si lo hace, este ingreso ya no aparecerá en los resgistros.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (FacturaDAL.anularFactura((Int64)dgvIngresos.CurrentRow.Cells[0].Value, false, Inicio.CurrentUser))
                        {
                            MessageBox.Show("La factura ha sido anulada correctamente, los calculos se reiniciarán automaticamente.", "Operación realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Pages = rdbMontYear.Checked ? FacturaDAL.getIdsFacturasByParametro(Convert.ToInt64((cbxYear.SelectedItem as Year).Desde), Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2010").ToString("MM"), Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit) : FacturaDAL.getIdsFacturasNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit);
                            numPages = Pages.Count;
                            SetCurrentPage();
                            tmrTaskDgv.Start();
                        }
                    }
                }

        }

        private void dgvIngresos_DoubleClick(object sender, EventArgs e)
        {
            if (dgvIngresos.CurrentRow != null)
            {
                FrmFactura factura = new FrmFactura();
                factura.EditingObject = FacturaDAL.getFacturaById((Int64)dgvIngresos.CurrentRow.Cells[0].Value);
                factura.ShowDialog();
            }
        }

        private void picExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Contabilidad_" + Convert.ToInt32((cbxYear.SelectedItem as Year).Desde) + "_Goll";
                string fileName = (cbxYear.SelectedItem as Year).Desde + "_" + cbxMonth.SelectedItem.ToString() + ".xlsx";

                Validation.FormManager frmManager = new Validation.FormManager();
                if (frmManager.generateExcel(FacturaDAL.getFacturasSemanas(Convert.ToInt64((cbxYear.SelectedItem as Year).Desde), Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2010").ToString("MM"), Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id)
                    , EgresoDAL.getEgresosSemanas(Convert.ToInt64((cbxYear.SelectedItem as Year).Desde), Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2010").ToString("MM"), Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id),
                    folderName, fileName,
                    Convert.ToInt32((cbxYear.SelectedItem as Year).Desde),
                    Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2019").Month))
                {
                    MessageBox.Show("La hoja de calculo ha sido generada en la carpeta " + "\"Contabilidad_" + Convert.ToInt32((cbxYear.SelectedItem as Year).Desde) + "_Goll\"" + " en Documentos.", "Operación realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "El archivo de excel del mes de " + Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2019").ToString("MMMM", new CultureInfo("es-ES")) + " esta siendo usado por otro programa.");
                MessageBox.Show("El archivo de excel del mes de " + Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2019").ToString("MMMM", new CultureInfo("es-ES")) + " esta siendo usado por otro programa.", "Error al generar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Arrow;

            }

        }
    }
}
