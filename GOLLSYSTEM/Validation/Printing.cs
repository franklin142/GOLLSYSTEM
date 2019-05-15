using GOLLSYSTEM.DataAccess;
using GOLLSYSTEM.EntityLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOLLSYSTEM.Validation
{
    public class Printing
    {
        public Factura currentFactura;
        private void imprimirFactura(PrintPreviewDialog printPreviewDialog1,Factura factura)
        {
            currentFactura = factura;

            PrintDocument pdoc = new PrintDocument();

            printPreviewDialog1.Document = pdoc;

            pdoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            pdoc.DefaultPageSettings.PrinterSettings.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            pdoc.DefaultPageSettings.PaperSize = new PaperSize("Letter", 840, 1102);
            pdoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

            printPreviewDialog1.Document.DefaultPageSettings.Landscape = false;
            (printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;

            pdoc.Print(); //sirve para imprimir la factura sin mostrarla.
            //printPreviewDialog1.ShowDialog();// sirve para mostrar la factura.

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
                Font font = new Font("Arial", 9, FontStyle.Regular);
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
                e.Graphics.DrawImage(GOLLSYSTEM.Properties.Resources.Goll_Logo_Black, row1Cell1PosX, row1PosY, 60, 18);
                e.Graphics.DrawString("TEL.: " + GOLLSYSTEM.Properties.Settings.Default.Tel, font, brocha, row1Cell1PosX + 18, row1PosY + 20);
                e.Graphics.DrawImage(GOLLSYSTEM.Properties.Resources.box_bill, row1Cell2PosX, row1PosY - 5, 38, 16);

                //   e.Graphics.DrawRectangle(new Pen(Brushes.Black, 1f), Rectangle.FromLTRB(row1Cell2PosX, row1PosY, 205, 25));
                e.Graphics.DrawString(currentFactura.NFactura, fontBold, brocha, row1Cell2PosX + 10, row1PosY + 1);

                ////////////////////////////////////////////////////////////////
                ////                  row2 total                              //
                ////////////////////////////////////////////////////////////////

                int row2PosY = 36, row2Cell0PosX = 8, row2Cell1PosX = 147;
                e.Graphics.DrawString("RECIBO DE INGRESO", font, brocha, row2Cell0PosX, row2PosY);
                decimal total = 0;
                foreach (Detfactura det in currentFactura.DetsFactura) total += det.Total - det.Descuento;
                e.Graphics.DrawString("POR$ " + Decimal.Round(total, 2), font, brocha, row2Cell1PosX, row2PosY);
                point1 = new Point(row2Cell1PosX + 10, row2PosY + 4);
                point2 = new Point(190, row2PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                ////////////////////////////////////////////////////////////////
                ////                  row3 cliente                              //
                ////////////////////////////////////////////////////////////////

                int row3PosY = 48, row3Cell0PosX = 10;
                e.Graphics.DrawString("RECIBI DEL SR(ES):  " + PersonaDAL.getPersonaById(currentFactura.IdPersona).Nombre.ToUpper(), font, brocha, row3Cell0PosX, row3PosY);
                point1 = new Point(row3Cell0PosX + 32, row3PosY + 4);
                point2 = new Point(190, row3PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                ////////////////////////////////////////////////////////////////
                ////                  row4 datos del cliente                  //
                ////////////////////////////////////////////////////////////////

                int row4PosY = 56, row4Cell0PosX = 10, row4Cell1PosX = 64, row4Cell2PosX = 121;
                e.Graphics.DrawString("TEL.:", font, brocha, row4Cell0PosX, row4PosY);

                point1 = new Point(row4Cell0PosX + 9, row4PosY + 4);
                point2 = new Point(60, row4PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                e.Graphics.DrawString("CEL.:", font, brocha, row4Cell1PosX, row4PosY);
                point1 = new Point(row4Cell1PosX + 10, row4PosY + 4);
                point2 = new Point(118, row4PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                e.Graphics.DrawString("E-MAIL.:", font, brocha, row4Cell2PosX, row4PosY);
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

                e.Graphics.DrawString("LA CANTIDAD DE:    " + moneda.Convertir(Dolares, true, "DOLARES").Substring(0, moneda.Convertir(Dolares, true, "DOLARES").Length - 6) + (Centavos == "00" ? "" : " CON " + moneda.Convertir(Centavos, true, "CENTAVOS").Substring(0, moneda.Convertir(Centavos, true, "CENTAVOS").Length - 6)), font, brocha, row5Cell0PosX, row5PosY);
                point1 = new Point(row5Cell0PosX + 32, row5PosY + 4);
                point2 = new Point(190, row5PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                ////////////////////////////////////////////////////////////////
                ////                  row6 concepto de                        //
                ////////////////////////////////////////////////////////////////

                int row6PosY = 72, row6Cell0PosX = 10;
                string concepto = "";
                foreach (Detfactura det in currentFactura.DetsFactura) concepto = concepto+(det.Producto.Nombre + (det.Tipo=="M"?Convert.ToDateTime(CuotaDAL.getCuotaById(det.Matricdetfac.IdCuota).FhRegistro).ToString("MMMM", new CultureInfo("es-ES")):"") + (currentFactura.DetsFactura.Count > 1 ? currentFactura.DetsFactura.Last().Id == det.Id ? "." : ", " : ".")+"");
                e.Graphics.DrawString("EN CONCEPTO DE:  " + concepto.ToUpper(), font, brocha, row6Cell0PosX, row6PosY);
                point1 = new Point(row6Cell0PosX + 32, row6PosY + 4);
                point2 = new Point(190, row6PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                ////////////////////////////////////////////////////////////////
                ////                  row7 total                              //
                ////////////////////////////////////////////////////////////////

                int row7PosY = 80, row7Cell0PosX = 10, row7Cell1PosX = 64, row7Cell2PosX = 121;

                e.Graphics.DrawString("RESERVACION", font, brocha, row7Cell0PosX, row7PosY);
                e.Graphics.DrawRectangle(new Pen(Brushes.Black, 0.5f), Rectangle.FromLTRB(row7Cell0PosX + 30, row7PosY, row7Cell0PosX + 40, row7PosY + 5));
                foreach (Detfactura det in currentFactura.DetsFactura)
                    if (det.Tipo == "R")
                        e.Graphics.DrawImage(GOLLSYSTEM.Properties.Resources.marca_de_verificacion, row7Cell0PosX + 33, row7PosY, 5, 5);


                e.Graphics.DrawString("MENSUALIDAD", font, brocha, row7Cell1PosX, row7PosY);
                e.Graphics.DrawRectangle(new Pen(Brushes.Black, 0.5f), Rectangle.FromLTRB(row7Cell1PosX + 30, row7PosY, row7Cell1PosX + 40, row7PosY + 5));
                foreach (Detfactura det in currentFactura.DetsFactura)
                    if (det.Tipo == "M")
                        e.Graphics.DrawImage(GOLLSYSTEM.Properties.Resources.marca_de_verificacion, row7Cell1PosX + 33, row7PosY, 5, 5);


                e.Graphics.DrawString("CANCELACION", font, brocha, row7Cell2PosX, row7PosY);
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
                e.Graphics.DrawString("OBSERVACION ", font, brocha, row8Cell0PosX, row8PosY);
                point1 = new Point(row8Cell0PosX + 28, row8PosY + 4);
                point2 = new Point(190, row8PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);
                e.Graphics.DrawString(Obs1.ToUpper(), font, brocha, row8Cell0PosX + 28, row8PosY);

                point1 = new Point(row8Cell0PosX, row8PosY + 4 + 7);
                point2 = new Point(190, row8PosY + 4 + 7);
                e.Graphics.DrawLine(blackPen, point1, point2);
                e.Graphics.DrawString(Obs2.ToUpper(), font, brocha, row8Cell0PosX, row8PosY + 7);

                point1 = new Point(row8Cell0PosX, row8PosY + 4 + 7 + 7);
                point2 = new Point(190, row8PosY + 4 + 7 + 7);
                e.Graphics.DrawLine(blackPen, point1, point2);
                e.Graphics.DrawString(Obs3.ToUpper(), font, brocha, row8Cell0PosX, row8PosY + 7 + 7);

                ////////////////////////////////////////////////////////////////
                ////                  row9 mora                               //
                ////////////////////////////////////////////////////////////////

                int row9PosY = 110, row9Cell0PosX = 57;

                e.Graphics.DrawString("NOTA: DESPUES DE 8 DIAS SE COBRARA EL " + Properties.Settings.Default.Mora + "% POR MORA", font, brocha, row9Cell0PosX, row9PosY);

                ////////////////////////////////////////////////////////////////
                ////                  row10 recibo, fwcha                     //
                ////////////////////////////////////////////////////////////////

                int row10PosY = 128, row10Cell0PosX = 14, row10Cell1PosX = 149;

                point1 = new Point(row10Cell0PosX, row10PosY);
                point2 = new Point(54, row10PosY);
                e.Graphics.DrawLine(blackPen, point1, point2);

                e.Graphics.DrawString(currentFactura.NFactura, fontBold, brocha, row10Cell0PosX + 10, row10PosY - 4);
                e.Graphics.DrawString("RECIBO", font, brocha, row10Cell0PosX + 13, row10PosY + 1);

                point1 = new Point(row10Cell1PosX, row10PosY);
                point2 = new Point(190, row10PosY);
                e.Graphics.DrawLine(blackPen, point1, point2);

                e.Graphics.DrawString(YearDAL.getServerDate().ToString("dd/MM/yyyy"), fontBold, brocha, row10Cell1PosX + 11, row10PosY - 4);
                e.Graphics.DrawString("FECHA", font, brocha, row10Cell1PosX + 14, row10PosY + 1);

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
                e.Graphics.DrawImage(GOLLSYSTEM.Properties.Resources.Goll_Logo_Black, row1Cell1PosX, row1PosY, 60, 18);
                e.Graphics.DrawString("TEL.: " + GOLLSYSTEM.Properties.Settings.Default.Tel, font, brocha, row1Cell1PosX + 18, row1PosY + 20);
                e.Graphics.DrawImage(GOLLSYSTEM.Properties.Resources.box_bill, row1Cell2PosX, row1PosY - 5, 38, 16);

                //   e.Graphics.DrawRectangle(new Pen(Brushes.Black, 1f), Rectangle.FromLTRB(row1Cell2PosX, row1PosY, 205, 25));
                e.Graphics.DrawString(currentFactura.NFactura, fontBold, brocha, row1Cell2PosX + 10, row1PosY + 1);

                ////////////////////////////////////////////////////////////////
                ////                  row2 total                              //
                ////////////////////////////////////////////////////////////////

                row2PosY = 36 + duplicatedTop;
                e.Graphics.DrawString("RECIBO DE INGRESO", font, brocha, row2Cell0PosX, row2PosY);
                e.Graphics.DrawString("POR$ " + Decimal.Round(total, 2), font, brocha, row2Cell1PosX, row2PosY);
                point1 = new Point(row2Cell1PosX + 10, row2PosY + 4);
                point2 = new Point(190, row2PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                ////////////////////////////////////////////////////////////////
                ////                  row3 cliente                              //
                ////////////////////////////////////////////////////////////////

                row3PosY = 48 + duplicatedTop;
                e.Graphics.DrawString("RECIBI DEL SR(ES):  " + PersonaDAL.getPersonaById(currentFactura.IdPersona).Nombre.ToUpper(), font, brocha, row3Cell0PosX, row3PosY);
                point1 = new Point(row3Cell0PosX + 32, row3PosY + 4);
                point2 = new Point(190, row3PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                ////////////////////////////////////////////////////////////////
                ////                  row4 datos del cliente                  //
                ////////////////////////////////////////////////////////////////

                row4PosY = 56 + duplicatedTop;
                e.Graphics.DrawString("TEL.:", font, brocha, row4Cell0PosX, row4PosY);

                point1 = new Point(row4Cell0PosX + 9, row4PosY + 4);
                point2 = new Point(60, row4PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                e.Graphics.DrawString("CEL.:", font, brocha, row4Cell1PosX, row4PosY);
                point1 = new Point(row4Cell1PosX + 10, row4PosY + 4);
                point2 = new Point(118, row4PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                e.Graphics.DrawString("E-MAIL.:", font, brocha, row4Cell2PosX, row4PosY);
                point1 = new Point(row4Cell2PosX + 14, row4PosY + 4);
                point2 = new Point(190, row4PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                ////////////////////////////////////////////////////////////////
                ////                  row5 cantidad de                        //
                ////////////////////////////////////////////////////////////////

                row5PosY = 64 + duplicatedTop;
                e.Graphics.DrawString("LA CANTIDAD DE:    " + moneda.Convertir(Dolares, true, "DOLARES").Substring(0, moneda.Convertir(Dolares, true, "DOLARES").Length - 6) + (Centavos == "00" ? "" : " CON " + moneda.Convertir(Centavos, true, "CENTAVOS").Substring(0, moneda.Convertir(Centavos, true, "CENTAVOS").Length - 6)), font, brocha, row5Cell0PosX, row5PosY);
                point1 = new Point(row5Cell0PosX + 32, row5PosY + 4);
                point2 = new Point(190, row5PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                ////////////////////////////////////////////////////////////////
                ////                  row6 concepto de                        //
                ////////////////////////////////////////////////////////////////

                row6PosY = 72 + duplicatedTop;
                e.Graphics.DrawString("EN CONCEPTO DE:  " + concepto.ToUpper(), font, brocha, row6Cell0PosX, row6PosY);
                point1 = new Point(row6Cell0PosX + 32, row6PosY + 4);
                point2 = new Point(190, row6PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);

                ////////////////////////////////////////////////////////////////
                ////                  row7 total                              //
                ////////////////////////////////////////////////////////////////

                row7PosY = 80 + duplicatedTop;

                e.Graphics.DrawString("RESERVACION", font, brocha, row7Cell0PosX, row7PosY);
                e.Graphics.DrawRectangle(new Pen(Brushes.Black, 0.5f), Rectangle.FromLTRB(row7Cell0PosX + 30, row7PosY, row7Cell0PosX + 40, row7PosY + 5));
                foreach (Detfactura det in currentFactura.DetsFactura)
                    if (det.Tipo == "R")
                        e.Graphics.DrawImage(GOLLSYSTEM.Properties.Resources.marca_de_verificacion, row7Cell0PosX + 33, row7PosY, 5, 5);


                e.Graphics.DrawString("MENSUALIDAD", font, brocha, row7Cell1PosX, row7PosY);
                e.Graphics.DrawRectangle(new Pen(Brushes.Black, 0.5f), Rectangle.FromLTRB(row7Cell1PosX + 30, row7PosY, row7Cell1PosX + 40, row7PosY + 5));
                foreach (Detfactura det in currentFactura.DetsFactura)
                    if (det.Tipo == "M")
                        e.Graphics.DrawImage(GOLLSYSTEM.Properties.Resources.marca_de_verificacion, row7Cell1PosX + 33, row7PosY, 5, 5);


                e.Graphics.DrawString("CANCELACION", font, brocha, row7Cell2PosX, row7PosY);
                e.Graphics.DrawRectangle(new Pen(Brushes.Black, 0.5f), Rectangle.FromLTRB(row7Cell2PosX + 30, row7PosY, row7Cell2PosX + 40, row7PosY + 5));
                foreach (Detfactura det in currentFactura.DetsFactura)
                    if (det.Tipo == "C" || det.Tipo == "F")
                        e.Graphics.DrawImage(GOLLSYSTEM.Properties.Resources.marca_de_verificacion, row7Cell2PosX + 33, row7PosY, 5, 5);


                ////////////////////////////////////////////////////////////////
                ////                  row8 Observacion                        //
                ////////////////////////////////////////////////////////////////

                row8PosY = 89 + duplicatedTop;

                e.Graphics.DrawString("OBSERVACION ", font, brocha, row8Cell0PosX, row8PosY);
                point1 = new Point(row8Cell0PosX + 28, row8PosY + 4);
                point2 = new Point(190, row8PosY + 4);
                e.Graphics.DrawLine(blackPen, point1, point2);
                e.Graphics.DrawString(Obs1.ToUpper(), font, brocha, row8Cell0PosX + 28, row8PosY);

                point1 = new Point(row8Cell0PosX, row8PosY + 4 + 7);
                point2 = new Point(190, row8PosY + 4 + 7);
                e.Graphics.DrawLine(blackPen, point1, point2);
                e.Graphics.DrawString(Obs2.ToUpper(), font, brocha, row8Cell0PosX, row8PosY + 7);

                point1 = new Point(row8Cell0PosX, row8PosY + 4 + 7 + 7);
                point2 = new Point(190, row8PosY + 4 + 7 + 7);
                e.Graphics.DrawLine(blackPen, point1, point2);
                e.Graphics.DrawString(Obs3.ToUpper(), font, brocha, row8Cell0PosX, row8PosY + 7 + 7);

                ////////////////////////////////////////////////////////////////
                ////                  row9 mora                               //
                ////////////////////////////////////////////////////////////////

                row9PosY = 110 + duplicatedTop;

                e.Graphics.DrawString("NOTA: DESPUES DE 8 DIAS SE COBRARA EL " + Properties.Settings.Default.Mora + "% POR MORA", font, brocha, row9Cell0PosX, row9PosY);

                ////////////////////////////////////////////////////////////////
                ////                  row10 recibo, fwcha                     //
                ////////////////////////////////////////////////////////////////

                row10PosY = 128 + duplicatedTop;

                point1 = new Point(row10Cell0PosX, row10PosY);
                point2 = new Point(54, row10PosY);
                e.Graphics.DrawLine(blackPen, point1, point2);

                e.Graphics.DrawString(currentFactura.NFactura, fontBold, brocha, row10Cell0PosX + 10, row10PosY - 4);
                e.Graphics.DrawString("RECIBO", font, brocha, row10Cell0PosX + 13, row10PosY + 1);

                point1 = new Point(row10Cell1PosX, row10PosY);
                point2 = new Point(190, row10PosY);
                e.Graphics.DrawLine(blackPen, point1, point2);

                e.Graphics.DrawString(YearDAL.getServerDate().ToString("dd/MM/yyyy"), fontBold, brocha, row10Cell1PosX + 11, row10PosY - 4);
                e.Graphics.DrawString("FECHA", font, brocha, row10Cell1PosX + 14, row10PosY + 1);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
    }
}
