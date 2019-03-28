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
using System.Reflection;

namespace GOLLSYSTEM.Controles
{
    public partial class ControlEgresos : Form
    {
        public int pLimit = 25;
        public int currentPage = 1;
        public int numPages = 0;
        public List<List<Int64>> Pages = new List<List<Int64>>();
        public List<Int64> listCurrentPage = new List<Int64>();

        public ControlEgresos()
        {
            InitializeComponent();
        }

        private void ControlEgresos_Load(object sender, EventArgs e)
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

                //Pages = rdbMontYear.Checked ? EgresoDAL.getIdsEgresosByParametro(Convert.ToInt64((cbxYear.SelectedItem as Year).Desde), Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2010").ToString("MM"), Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit) : EgresoDAL.getIdsEgresosNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit);
                //numPages = Pages.Count;
                //SetCurrentPage();
                tmrTaskDgv.Start();

                cbxMonth.SelectedIndexChanged += cbxMonth_SelectedIndexChanged;
                cbxYear.SelectedIndexChanged += cbxMonth_SelectedIndexChanged;
                rdbMontYear.CheckedChanged += cbxMonth_SelectedIndexChanged;
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
        private void CalcularGanancias(decimal facturas, decimal egresos)
        {
            decimal tIngresos = facturas;
            decimal tEgresos = egresos;
            lblTotalGanancia.Text = "$" + Decimal.Round((tIngresos - tEgresos), 2).ToString();
            lblTotalEgresos.Text = "-$" + Decimal.Round(tEgresos, 2).ToString();
            lblTotalIngresos.Text = "$" + Decimal.Round(tIngresos, 2).ToString();
            lblTotalGanancia.ForeColor = Decimal.Round((tIngresos - tEgresos), 2) < 0 ? Color.OrangeRed : Color.DarkGreen;
        }

        private void btnNuevoEgreso_Click(object sender, EventArgs e)
        {
            FrmEgreso egreso = new FrmEgreso();
            egreso.ShowDialog();
            Pages = rdbMontYear.Checked ? EgresoDAL.getIdsEgresosByParametro(Convert.ToInt64((cbxYear.SelectedItem as Year).Desde), Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2010").ToString("MM"), Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit) : EgresoDAL.getIdsEgresosNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit);
            numPages = Pages.Count;
            SetCurrentPage();
            tmrTaskDgv.Start();

        }
        private void FillDgv(List<Egreso> lista)
        {
            dgvEgresos.Rows.Clear();
            foreach (Egreso obj in lista) dgvEgresos.Rows.Add(obj.Id,Convert.ToDateTime(obj.FhRegistro).ToString("dd/MM/yyyy"), obj.Tipo, obj.Nombre, obj.Total);
            CalcularGanancias(rdbMontYear.Checked ? FacturaDAL.getTotalFacturasByParametro(Convert.ToInt64((cbxYear.SelectedItem as Year).Desde), Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2010").ToString("MM"), Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit) : FacturaDAL.getTotalFacturasNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit),
            rdbMontYear.Checked ? EgresoDAL.getTotalEgresoByParametro(Convert.ToInt64((cbxYear.SelectedItem as Year).Desde), Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2010").ToString("MM"), Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit) : EgresoDAL.getTotalEgresoNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit));
            lblPages.Text = "Página " + currentPage + " de " + (numPages == 0 ? "1" : numPages.ToString());
        }

        private void tmrTask_Tick(object sender, EventArgs e)
        {
            Pages = rdbMontYear.Checked ? EgresoDAL.getIdsEgresosByParametro(Convert.ToInt64((cbxYear.SelectedItem as Year).Desde), Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2010").ToString("MM"), Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit) : EgresoDAL.getIdsEgresosNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit);
            numPages = Pages.Count;
            SetCurrentPage();
            FillDgv(GetListEgresos(listCurrentPage));
            tmrTaskDgv.Stop();
        }
        private List<Egreso> GetListEgresos(List<Int64> pLista)
        {
            List<Egreso> Egresos = new List<Egreso>();
            if (pLista != null)
            {
                Egresos = rdbMontYear.Checked ? EgresoDAL.getEgresosIndexerParametro(Convert.ToInt64((cbxYear.SelectedItem as Year).Desde), Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2010").ToString("MM"), Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, currentPage - 1, pLimit) : EgresoDAL.getEgresosIndexerNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, currentPage - 1, pLimit);
            }
            return Egresos;
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

        private void icUpdate_Click(object sender, EventArgs e)
        {
            Pages = rdbMontYear.Checked ? EgresoDAL.getIdsEgresosByParametro(Convert.ToInt64((cbxYear.SelectedItem as Year).Desde), Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2010").ToString("MM"), Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit) : EgresoDAL.getIdsEgresosNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit);
            numPages = Pages.Count;
            SetCurrentPage();
            tmrTaskDgv.Start();
        }
        private void cbxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCurrentIndex.Text = "1";
            Pages = rdbMontYear.Checked ? EgresoDAL.getIdsEgresosByParametro(Convert.ToInt64((cbxYear.SelectedItem as Year).Desde), Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2010").ToString("MM"), Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit) : EgresoDAL.getIdsEgresosNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit);
            numPages = Pages.Count;
            SetCurrentPage();
            tmrTaskDgv.Start();
        }

        private void dgvEgresos_DoubleClick(object sender, EventArgs e)
        {
            if (dgvEgresos.CurrentRow != null)
            {
                FrmEgreso egreso = new FrmEgreso();
                egreso.EditingObject = EgresoDAL.getEgresoById((Int64)dgvEgresos.CurrentRow.Cells[0].Value);
                egreso.ShowDialog();
                Pages = rdbMontYear.Checked ? EgresoDAL.getIdsEgresosByParametro(Convert.ToInt64((cbxYear.SelectedItem as Year).Desde), Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2010").ToString("MM"), Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit) : EgresoDAL.getIdsEgresosNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit);
                numPages = Pages.Count;
                SetCurrentPage();
                tmrTaskDgv.Start();
            }
        }

        private void btnAnularEgreso_Click(object sender, EventArgs e)
        {
            if (dgvEgresos.CurrentRow != null)

                if (MessageBox.Show("¿Esta seguro que desea anular este egreso? si lo hace, este egreso ya no aparecerá en los resgistros.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (EgresoDAL.anularEgreso((Int64)dgvEgresos.CurrentRow.Cells[0].Value, false, Inicio.CurrentUser))
                    {
                        MessageBox.Show("El egreso ha sido anulado correctamente, los calculos se reiniciarán automaticamente.", "Operación realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Pages = rdbMontYear.Checked ? EgresoDAL.getIdsEgresosByParametro(Convert.ToInt64((cbxYear.SelectedItem as Year).Desde), Convert.ToDateTime("20-" + cbxMonth.SelectedItem.ToString() + "-2010").ToString("MM"), Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit) : EgresoDAL.getIdsEgresosNoParametro(Validation.Validation.Val_Injection(txtBuscar.Text), Inicio.CurrentSucursal.Id, pLimit);
                        numPages = Pages.Count;
                        SetCurrentPage();
                        tmrTaskDgv.Start();
                    }
                }
        }
    }
}
