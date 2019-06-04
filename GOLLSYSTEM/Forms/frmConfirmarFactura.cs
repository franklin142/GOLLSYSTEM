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
using System.Drawing.Printing;
using GOLLSYSTEM.Validation;
using System.Reflection;
using System.Globalization;

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
            try
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
                if (currentFactura.Id != 0)
                {
                    btnRegistrar.Text = "Imprimir";
                    txtObservacion.Enabled = false; txtCash.Enabled = false;

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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            try
            {
                if (currentFactura.Id == 0)
                {
                    foreach (Detfactura det in currentFactura.DetsFactura) currentFactura.Observacion += det.Descuento > 0 ? "DESCUENTO DE $" + Decimal.Round(det.Descuento, 2) + " EN " + det.Producto.Nombre + ". " : "";
                    currentFactura.Observacion += txtObservacion.Text;

                    Factura facturaInserted = FacturaDAL.insertFactura(currentFactura, Inicio.CurrentUser);
                    if (facturaInserted.Id != 0)
                    {
                        currentFactura = facturaInserted;
                        imprimirFactura();
                        MessageBox.Show("El ingreso ha sido registrado exitosamente.", "Registro satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        currentFactura = null;
                        this.DialogResult = DialogResult.Yes;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error inesperado al intentar registrar el ingreso, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo franklingranados2@yahoo.com.", "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    imprimirFactura();
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";
                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ocurrio un error inesperado al intentar registrar el ingreso");
                MessageBox.Show("Ocurrio un error inesperado al intentar registrar el ingreso, por favor cierre el formulario y vuelva a intentarlo. Si el problema persiste contacte con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Registro interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.No;
                this.Close();
            }

        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCash.Text != "" && Validation.Validation.Val_DecimalFormat(txtCash.Text))
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
            catch (Exception ex)
            {
                string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Errores_" + Assembly.GetExecutingAssembly().GetName().Name + "_V_" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string fileName = "Exeptions_" + Name + ".txt";

                Validation.FormManager frmManager = new Validation.FormManager();
                frmManager.writeException(folderName, fileName, ex, "Ha ocurrido un error en el proceso de calcular el cambio en efectivo de este control");
                MessageBox.Show("Ha ocurrido un error en el proceso de calcular el cambio en efectivo de este control, por favor comuniquese con el desarrollador al correo " + Properties.Settings.Default.developerEmail, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void imprimirFactura()
        {

            PrintDocument pdoc = new PrintDocument();

            printPreviewDialog1.Document = pdoc;

            pdoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            pdoc.DefaultPageSettings.PrinterSettings.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            pdoc.DefaultPageSettings.PaperSize = new PaperSize("Letter", 840, 1102);
            pdoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

            printPreviewDialog1.Document.DefaultPageSettings.Landscape = false;
            (printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;

            // pdoc.Print(); //sirve para imprimir la factura sin mostrarla.
            printPreviewDialog1.ShowDialog();// sirve para mostrar la factura.

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                StringFormat formato = new StringFormat();
                formato.Alignment = StringAlignment.Near;
                formato.LineAlignment = StringAlignment.Near;

                e.Graphics.PageUnit = GraphicsUnit.Millimeter;
                e.PageSettings.Margins = new Margins(0, 0, 0, 0);

                Pen blackPen = new Pen(Color.Black, (float)0.2);
                Font fontNormal = new Font("Arial", 9, FontStyle.Regular);
                Font fontSmall = new Font("Arial", 8, FontStyle.Regular);

                Font fontBold = new Font("Arial", 9, FontStyle.Bold);

                Brush brocha = Brushes.Black;

                Point point1 = new Point(5, 5);
                Point point2 = new Point(205, 5);
                //  e.Graphics.DrawLine(blackPen, point1, point2);

                point1 = new Point(5, 5);
                point2 = new Point(5, 274);
                // e.Graphics.DrawLine(blackPen, point1, point2);

                point1 = new Point(5, 274);
                point2 = new Point(205, 274);
                //  e.Graphics.DrawLine(blackPen, point1, point2);

                point1 = new Point(205, 274);
                point2 = new Point(205, 5);
                // e.Graphics.DrawLine(blackPen, point1, point2);

                ////////////////////////////////////////////////////////////////
                ////                  row1 pictures, Tel, NFact               //
                ////////////////////////////////////////////////////////////////

                int row1PosY = 12, row1Cell0PosX = 10, row1Cell1PosX = 79, row1Cell2PosX = 167;
                e.Graphics.DrawImage(GOLLSYSTEM.Properties.Resources.Goll_Logo_Black, row1Cell0PosX, row1PosY, 60, 24);
                e.Graphics.DrawImage(GOLLSYSTEM.Properties.Resources.Logo_goll_center, row1Cell1PosX, row1PosY, 60, 18);
                e.Graphics.DrawString("TEL.: " + GOLLSYSTEM.Properties.Settings.Default.Tel, fontSmall, brocha, row1Cell1PosX + 18, row1PosY + 15);
                e.Graphics.DrawImage(GOLLSYSTEM.Properties.Resources.box_bill, row1Cell2PosX, row1PosY - 5, 38, 16);

                //   e.Graphics.DrawRectangle(new Pen(Brushes.Black, 1f), Rectangle.FromLTRB(row1Cell2PosX, row1PosY, 205, 25));
                e.Graphics.DrawString(currentFactura.NFactura, fontBold, brocha, row1Cell2PosX + 10, row1PosY + 1);

                ////////////////////////////////////////////////////////////////
                ////                  row2 total                              //
                ////////////////////////////////////////////////////////////////

                int row2PosY = 36, row2Cell0PosX = 8, row2Cell1PosX = 147;
                e.Graphics.DrawString("RECIBO DE INGRESO", fontNormal, brocha, row2Cell0PosX, row2PosY);
                decimal total = 0;
                foreach (Detfactura det in currentFactura.DetsFactura) total += det.Total - det.Descuento;
                e.Graphics.DrawString("POR$ " + Decimal.Round(total, 2), fontNormal, brocha, row2Cell1PosX, row2PosY);
                point1 = new Point(row2Cell1PosX + 10, row2PosY + 4);
                point2 = new Point(190, row2PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                ////////////////////////////////////////////////////////////////
                ////                  row3 cliente                              //
                ////////////////////////////////////////////////////////////////

                int row3PosY = 48, row3Cell0PosX = 10;
                e.Graphics.DrawString("RECIBI DEL SR(ES):  " + PersonaDAL.getPersonaById(currentFactura.IdPersona).Nombre.ToUpper(), fontNormal, brocha, row3Cell0PosX, row3PosY);
                point1 = new Point(row3Cell0PosX + 32, row3PosY + 4);
                point2 = new Point(190, row3PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                ////////////////////////////////////////////////////////////////
                ////                  row4 datos del cliente                  //
                ////////////////////////////////////////////////////////////////

                int row4PosY = 56, row4Cell0PosX = 10, row4Cell1PosX = 64, row4Cell2PosX = 121;
                e.Graphics.DrawString("TEL.:", fontNormal, brocha, row4Cell0PosX, row4PosY);

                point1 = new Point(row4Cell0PosX + 9, row4PosY + 4);
                point2 = new Point(60, row4PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                e.Graphics.DrawString("CEL.:", fontNormal, brocha, row4Cell1PosX, row4PosY);
                point1 = new Point(row4Cell1PosX + 10, row4PosY + 4);
                point2 = new Point(118, row4PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                e.Graphics.DrawString("E-MAIL.:", fontNormal, brocha, row4Cell2PosX, row4PosY);
                point1 = new Point(row4Cell2PosX + 14, row4PosY + 4);
                point2 = new Point(190, row4PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                ////////////////////////////////////////////////////////////////
                ////                  row5 cantidad de                        //
                ////////////////////////////////////////////////////////////////

                int row5PosY = 64, row5Cell0PosX = 10;
                Moneda moneda = new Moneda();
                string Dolares = Decimal.Round(total, 2).ToString().Substring(0, Decimal.Round(total, 2).ToString().Length - 3);
                string Centavos = Decimal.Round(total, 2).ToString().Substring(Decimal.Round(total, 2).ToString().Length - 2, 2);

                e.Graphics.DrawString("LA CANTIDAD DE:    " + moneda.Convertir(Dolares, true, "DOLARES").Substring(0, moneda.Convertir(Dolares, true, "DOLARES").Length - 6) + (Centavos == "00" ? "" : " CON " + moneda.Convertir(Centavos, true, "CENTAVOS").Substring(0, moneda.Convertir(Centavos, true, "CENTAVOS").Length - 6)), fontNormal, brocha, row5Cell0PosX, row5PosY);
                point1 = new Point(row5Cell0PosX + 32, row5PosY + 4);
                point2 = new Point(190, row5PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                ////////////////////////////////////////////////////////////////
                ////                  row6 concepto de                        //
                ////////////////////////////////////////////////////////////////

                int row6PosY = 72, row6Cell0PosX = 10;
                string concepto = "";
                foreach (Detfactura det in currentFactura.DetsFactura) concepto = concepto + (det.Producto.Nombre + (det.Tipo == "M" ? " \""+Convert.ToDateTime(CuotaDAL.getCuotaById(det.Matricdetfac.IdCuota).FhRegistro).ToString("MMMM", new CultureInfo("es-ES"))+"\"" : "") + (currentFactura.DetsFactura.Count > 1 ? currentFactura.DetsFactura.Last().Id == det.Id ? "." : ", " : ".") + "");

                e.Graphics.DrawString("EN CONCEPTO DE:  " + concepto.ToUpper(), fontNormal, brocha, row6Cell0PosX, row6PosY);
                point1 = new Point(row6Cell0PosX + 32, row6PosY + 4);
                point2 = new Point(190, row6PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                ////////////////////////////////////////////////////////////////
                ////                  row7 total                              //
                ////////////////////////////////////////////////////////////////

                int row7PosY = 80, row7Cell0PosX = 10, row7Cell1PosX = 64, row7Cell2PosX = 121;

                e.Graphics.DrawString("RESERVACION", fontNormal, brocha, row7Cell0PosX, row7PosY);
                e.Graphics.DrawRectangle(new Pen(Brushes.Black, 0.5f), Rectangle.FromLTRB(row7Cell0PosX + 30, row7PosY, row7Cell0PosX + 40, row7PosY + 5));
                foreach (Detfactura det in currentFactura.DetsFactura)
                    if (det.Tipo == "R")
                        e.Graphics.DrawImage(GOLLSYSTEM.Properties.Resources.marca_de_verificacion, row7Cell0PosX + 33, row7PosY, 5, 5);


                e.Graphics.DrawString("MENSUALIDAD", fontNormal, brocha, row7Cell1PosX, row7PosY);
                e.Graphics.DrawRectangle(new Pen(Brushes.Black, 0.5f), Rectangle.FromLTRB(row7Cell1PosX + 30, row7PosY, row7Cell1PosX + 40, row7PosY + 5));
                foreach (Detfactura det in currentFactura.DetsFactura)
                    if (det.Tipo == "M")
                        e.Graphics.DrawImage(GOLLSYSTEM.Properties.Resources.marca_de_verificacion, row7Cell1PosX + 33, row7PosY, 5, 5);


                e.Graphics.DrawString("CANCELACION", fontNormal, brocha, row7Cell2PosX, row7PosY);
                e.Graphics.DrawRectangle(new Pen(Brushes.Black, 0.5f), Rectangle.FromLTRB(row7Cell2PosX + 30, row7PosY, row7Cell2PosX + 40, row7PosY + 5));
                foreach (Detfactura det in currentFactura.DetsFactura)
                    if (det.Tipo == "C" || det.Tipo == "F")
                        e.Graphics.DrawImage(GOLLSYSTEM.Properties.Resources.marca_de_verificacion, row7Cell2PosX + 33, row7PosY, 5, 5);


                ////////////////////////////////////////////////////////////////
                ////                  row8 Observacion                        //
                ////////////////////////////////////////////////////////////////

                int row8PosY = 89, row8Cell0PosX = 10;
                string Obs1 = "";
                string Obs2 = "";
                string Obs3 = "";
                char[] letras = currentFactura.Observacion.ToArray();
                foreach (char letra in letras)
                {
                    if (Obs1.Length < 81)
                        Obs1 += letra;
                    else
                        if (Obs2.Length < 91)
                        Obs2 += letra;
                    else
                        if (Obs3.Length < 91)
                        Obs3 += letra;
                }
                e.Graphics.DrawString("OBSERVACION ", fontNormal, brocha, row8Cell0PosX, row8PosY);
                point1 = new Point(row8Cell0PosX + 28, row8PosY + 4);
                point2 = new Point(190, row8PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);
                e.Graphics.DrawString(Obs1.ToUpper(), fontSmall, brocha, row8Cell0PosX + 28, row8PosY);

                point1 = new Point(row8Cell0PosX, row8PosY + 4 + 7);
                point2 = new Point(190, row8PosY + 4 + 7);
                e.Graphics.DrawLine(blackPen, point1, point2);
                e.Graphics.DrawString(Obs2.ToUpper(), fontSmall, brocha, row8Cell0PosX, row8PosY + 7);

                point1 = new Point(row8Cell0PosX, row8PosY + 4 + 7 + 7);
                point2 = new Point(190, row8PosY + 4 + 7 + 7);
                e.Graphics.DrawLine(blackPen, point1, point2);
                e.Graphics.DrawString(Obs3.ToUpper(), fontSmall, brocha, row8Cell0PosX, row8PosY + 7 + 7);

                ////////////////////////////////////////////////////////////////
                ////                  row9 mora                               //
                ////////////////////////////////////////////////////////////////

                int row9PosY = 110, row9Cell0PosX = 57;

                e.Graphics.DrawString("NOTA: DESPUES DE 8 DIAS SE COBRARA EL " + Properties.Settings.Default.Mora + "% POR MORA", fontNormal, brocha, row9Cell0PosX, row9PosY);

                ////////////////////////////////////////////////////////////////
                ////                  row10 recibo, fwcha                     //
                ////////////////////////////////////////////////////////////////

                int row10PosY = 128, row10Cell0PosX = 14, row10Cell1PosX = 149;

                point1 = new Point(row10Cell0PosX, row10PosY);
                point2 = new Point(54, row10PosY);
                e.Graphics.DrawLine(blackPen, point1, point2);

                e.Graphics.DrawString("RECIBO", fontNormal, brocha, row10Cell0PosX + 13, row10PosY + 1);

                point1 = new Point(row10Cell1PosX, row10PosY);
                point2 = new Point(190, row10PosY);
                e.Graphics.DrawLine(blackPen, point1, point2);

                e.Graphics.DrawString(YearDAL.getServerDate().ToString("dd/MM/yyyy"), fontBold, brocha, row10Cell1PosX + 11, row10PosY - 4);
                e.Graphics.DrawString("FECHA", fontNormal, brocha, row10Cell1PosX + 14, row10PosY + 1);

                ////////////////////////////////////////////////////////////////
                ////                  Duplicado                               //
                ////////////////////////////////////////////////////////////////
                point1 = new Point(5, 137);
                point2 = new Point(205, 137);
                e.Graphics.DrawLine(blackPen, point1, point2);
                int duplicatedTop = 137;
                ////////////////////////////////////////////////////////////////
                ////                  row1 pictures, Tel, NFact               //
                ////////////////////////////////////////////////////////////////

                row1PosY = 12 + duplicatedTop;
                e.Graphics.DrawImage(GOLLSYSTEM.Properties.Resources.Goll_Logo_Black, row1Cell0PosX, row1PosY, 60, 24);
                e.Graphics.DrawImage(GOLLSYSTEM.Properties.Resources.Logo_goll_center, row1Cell1PosX, row1PosY, 60, 18);
                e.Graphics.DrawString("TEL.: " + GOLLSYSTEM.Properties.Settings.Default.Tel, fontNormal, brocha, row1Cell1PosX + 18, row1PosY + 15);
                e.Graphics.DrawImage(GOLLSYSTEM.Properties.Resources.box_bill, row1Cell2PosX, row1PosY - 5, 38, 16);

                //   e.Graphics.DrawRectangle(new Pen(Brushes.Black, 1f), Rectangle.FromLTRB(row1Cell2PosX, row1PosY, 205, 25));
                e.Graphics.DrawString(currentFactura.NFactura, fontBold, brocha, row1Cell2PosX + 10, row1PosY + 1);

                ////////////////////////////////////////////////////////////////
                ////                  row2 total                              //
                ////////////////////////////////////////////////////////////////

                row2PosY = 36 + duplicatedTop;
                e.Graphics.DrawString("RECIBO DE INGRESO", fontNormal, brocha, row2Cell0PosX, row2PosY);
                e.Graphics.DrawString("POR$ " + Decimal.Round(total, 2), fontNormal, brocha, row2Cell1PosX, row2PosY);
                point1 = new Point(row2Cell1PosX + 10, row2PosY + 4);
                point2 = new Point(190, row2PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                ////////////////////////////////////////////////////////////////
                ////                  row3 cliente                              //
                ////////////////////////////////////////////////////////////////

                row3PosY = 48 + duplicatedTop;
                e.Graphics.DrawString("RECIBI DEL SR(ES):  " + PersonaDAL.getPersonaById(currentFactura.IdPersona).Nombre.ToUpper(), fontNormal, brocha, row3Cell0PosX, row3PosY);
                point1 = new Point(row3Cell0PosX + 32, row3PosY + 4);
                point2 = new Point(190, row3PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                ////////////////////////////////////////////////////////////////
                ////                  row4 datos del cliente                  //
                ////////////////////////////////////////////////////////////////

                row4PosY = 56 + duplicatedTop;
                e.Graphics.DrawString("TEL.:", fontNormal, brocha, row4Cell0PosX, row4PosY);

                point1 = new Point(row4Cell0PosX + 9, row4PosY + 4);
                point2 = new Point(60, row4PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                e.Graphics.DrawString("CEL.:", fontNormal, brocha, row4Cell1PosX, row4PosY);
                point1 = new Point(row4Cell1PosX + 10, row4PosY + 4);
                point2 = new Point(118, row4PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                e.Graphics.DrawString("E-MAIL.:", fontNormal, brocha, row4Cell2PosX, row4PosY);
                point1 = new Point(row4Cell2PosX + 14, row4PosY + 4);
                point2 = new Point(190, row4PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                ////////////////////////////////////////////////////////////////
                ////                  row5 cantidad de                        //
                ////////////////////////////////////////////////////////////////

                row5PosY = 64 + duplicatedTop;
                e.Graphics.DrawString("LA CANTIDAD DE:    " + moneda.Convertir(Dolares, true, "DOLARES").Substring(0, moneda.Convertir(Dolares, true, "DOLARES").Length - 6) + (Centavos == "00" ? "" : " CON " + moneda.Convertir(Centavos, true, "CENTAVOS").Substring(0, moneda.Convertir(Centavos, true, "CENTAVOS").Length - 6)), fontNormal, brocha, row5Cell0PosX, row5PosY);
                point1 = new Point(row5Cell0PosX + 32, row5PosY + 4);
                point2 = new Point(190, row5PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                ////////////////////////////////////////////////////////////////
                ////                  row6 concepto de                        //
                ////////////////////////////////////////////////////////////////

                row6PosY = 72 + duplicatedTop;
                e.Graphics.DrawString("EN CONCEPTO DE:  " + concepto.ToUpper(), fontNormal, brocha, row6Cell0PosX, row6PosY);
                point1 = new Point(row6Cell0PosX + 32, row6PosY + 4);
                point2 = new Point(190, row6PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                ////////////////////////////////////////////////////////////////
                ////                  row7 total                              //
                ////////////////////////////////////////////////////////////////

                row7PosY = 80 + duplicatedTop;

                e.Graphics.DrawString("RESERVACION", fontNormal, brocha, row7Cell0PosX, row7PosY);
                e.Graphics.DrawRectangle(new Pen(Brushes.Black, 0.5f), Rectangle.FromLTRB(row7Cell0PosX + 30, row7PosY, row7Cell0PosX + 40, row7PosY + 5));
                foreach (Detfactura det in currentFactura.DetsFactura)
                    if (det.Tipo == "R")
                        e.Graphics.DrawImage(GOLLSYSTEM.Properties.Resources.marca_de_verificacion, row7Cell0PosX + 33, row7PosY, 5, 5);


                e.Graphics.DrawString("MENSUALIDAD", fontNormal, brocha, row7Cell1PosX, row7PosY);
                e.Graphics.DrawRectangle(new Pen(Brushes.Black, 0.5f), Rectangle.FromLTRB(row7Cell1PosX + 30, row7PosY, row7Cell1PosX + 40, row7PosY + 5));
                foreach (Detfactura det in currentFactura.DetsFactura)
                    if (det.Tipo == "M")
                        e.Graphics.DrawImage(GOLLSYSTEM.Properties.Resources.marca_de_verificacion, row7Cell1PosX + 33, row7PosY, 5, 5);


                e.Graphics.DrawString("CANCELACION", fontNormal, brocha, row7Cell2PosX, row7PosY);
                e.Graphics.DrawRectangle(new Pen(Brushes.Black, 0.5f), Rectangle.FromLTRB(row7Cell2PosX + 30, row7PosY, row7Cell2PosX + 40, row7PosY + 5));
                foreach (Detfactura det in currentFactura.DetsFactura)
                    if (det.Tipo == "C" || det.Tipo == "F")
                        e.Graphics.DrawImage(GOLLSYSTEM.Properties.Resources.marca_de_verificacion, row7Cell2PosX + 33, row7PosY, 5, 5);


                ////////////////////////////////////////////////////////////////
                ////                  row8 Observacion                        //
                ////////////////////////////////////////////////////////////////

                row8PosY = 89 + duplicatedTop;

                e.Graphics.DrawString("OBSERVACION ", fontNormal, brocha, row8Cell0PosX, row8PosY);
                point1 = new Point(row8Cell0PosX + 28, row8PosY + 4);
                point2 = new Point(190, row8PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);
                e.Graphics.DrawString(Obs1.ToUpper(), fontSmall, brocha, row8Cell0PosX + 28, row8PosY);

                point1 = new Point(row8Cell0PosX, row8PosY + 4 + 7);
                point2 = new Point(190, row8PosY + 4 + 7);
                e.Graphics.DrawLine(blackPen, point1, point2);
                e.Graphics.DrawString(Obs2.ToUpper(), fontSmall, brocha, row8Cell0PosX, row8PosY + 7);

                point1 = new Point(row8Cell0PosX, row8PosY + 4 + 7 + 7);
                point2 = new Point(190, row8PosY + 4 + 7 + 7);
                e.Graphics.DrawLine(blackPen, point1, point2);
                e.Graphics.DrawString(Obs3.ToUpper(), fontSmall, brocha, row8Cell0PosX, row8PosY + 7 + 7);

                ////////////////////////////////////////////////////////////////
                ////                  row9 mora                               //
                ////////////////////////////////////////////////////////////////

                row9PosY = 110 + duplicatedTop;

                e.Graphics.DrawString("NOTA: DESPUES DE 8 DIAS SE COBRARA EL " + Properties.Settings.Default.Mora + "% POR MORA", fontNormal, brocha, row9Cell0PosX, row9PosY);

                ////////////////////////////////////////////////////////////////
                ////                  row10 recibo, fwcha                     //
                ////////////////////////////////////////////////////////////////

                row10PosY = 128 + duplicatedTop;

                point1 = new Point(row10Cell0PosX, row10PosY);
                point2 = new Point(54, row10PosY);
                e.Graphics.DrawLine(blackPen, point1, point2);

                e.Graphics.DrawString("RECIBO", fontNormal, brocha, row10Cell0PosX + 13, row10PosY + 1);

                point1 = new Point(row10Cell1PosX, row10PosY);
                point2 = new Point(190, row10PosY);
                e.Graphics.DrawLine(blackPen, point1, point2);

                e.Graphics.DrawString(YearDAL.getServerDate().ToString("dd/MM/yyyy"), fontBold, brocha, row10Cell1PosX + 11, row10PosY - 4);
                e.Graphics.DrawString("FECHA", fontNormal, brocha, row10Cell1PosX + 14, row10PosY + 1);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
    }
}
