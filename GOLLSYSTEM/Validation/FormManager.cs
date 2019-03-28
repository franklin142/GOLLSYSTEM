using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using GOLLSYSTEM.DataAccess;
using GOLLSYSTEM.EntityLayer;
using SpreadsheetLight;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Globalization;

namespace GOLLSYSTEM.Validation
{
    public class FormManager
    {
        public void LoadForm(Panel pnl, Form FormOpening)
        {
            if (pnl.Controls.Count > 0)
                pnl.Controls.RemoveAt(0);
            Form fN = FormOpening as Form;
            fN.TopLevel = false;
            fN.Size = pnl.Size;
            pnl.Controls.Add(fN);
            pnl.Tag = fN;
            fN.Show();
        }
        public void writeException(string folderName, string fileName, Exception ex, string extra)
        {
            if (!Directory.Exists(folderName))
            {
                DirectoryInfo di = Directory.CreateDirectory(folderName);
                if (!System.IO.File.Exists(folderName + "\\" + fileName))
                {
                    using (StreamWriter mylogs = File.AppendText(folderName + "\\" + fileName))         //se crea el archivo
                    {
                        string strDate = Convert.ToDateTime(DateTime.Now).ToString("dd MMMM yyyy");
                        mylogs.WriteLine("///////////////////////////////////////////////////////////////");
                        mylogs.WriteLine("//\t\t\t" + strDate + "\t\t\t    //");
                        mylogs.WriteLine("/////////////////////////////////////////////////////////////");
                        mylogs.WriteLine(ex.ToString());
                        mylogs.WriteLine("Extra:");
                        mylogs.WriteLine(extra);
                        mylogs.WriteLine("");
                        mylogs.Close();
                    }
                }
                else
                {
                    using (StreamWriter file = new StreamWriter(folderName + "\\" + fileName, true))
                    {
                        string strDate = Convert.ToDateTime(DateTime.Now).ToString("dd MMMM yyyy");
                        file.WriteLine("///////////////////////////////////////////////////////////////");
                        file.WriteLine("//\t\t\t" + strDate + "\t\t\t    //");
                        file.WriteLine("/////////////////////////////////////////////////////////////");
                        file.WriteLine(ex.ToString());
                        file.WriteLine("Extra:");
                        file.WriteLine(extra);
                        file.WriteLine(""); file.Close();
                    }
                }
            }
            else
            {
                using (StreamWriter file = new StreamWriter(folderName + "\\" + fileName, true))
                {
                    string strDate = Convert.ToDateTime(DateTime.Now).ToString("dd MMMM yyyy");
                    file.WriteLine("///////////////////////////////////////////////////////////////");
                    file.WriteLine("//\t\t\t" + strDate + "\t\t\t    //");
                    file.WriteLine("/////////////////////////////////////////////////////////////");
                    file.WriteLine(ex.ToString());
                    file.WriteLine("Extra:");
                    file.WriteLine(extra);
                    file.WriteLine(""); file.Close();

                    file.Close();
                }
            }
        }
        public bool generateExcel(List<List<List<Factura>>> IngresoSemanas, List<List<List<Egreso>>> EgresoSemanas, string folderpath, string fileName, int pYear, int pMonth)
        {
            bool result = true;
            try
            {
                //decimal TotalIngresos = 0;
                //decimal TotalEgresos = 0;
                //decimal Total = 0;
                SLDocument sl = new SLDocument();
                List<Producto> productosTable = new List<Producto>();
                int dayMonthIngrsos = 1;
                int dayMonthEgresos = 1;

                decimal lastTotalIngresos = 0;
                decimal lastTotalEgresos = 0;

                for (int s = 0; s < IngresoSemanas.Count; s++)
                {
                    int dayWeek = 1;
                    decimal totalSemana = 0;
                    List<List<Factura>> SemanaIngresos = IngresoSemanas[s];
                    List<Detfactura> DetallesSemana = new List<Detfactura>();
                    List<List<Egreso>> SemanaEgresos = EgresoSemanas[s];
                    List<Egreso> ConceptosEgresos = new List<Egreso>();

                    productosTable.Clear();
                    //procesando ingresos
                    sl.AddWorksheet("Week " + (s + 1));
                    sl.MergeWorksheetCells(2, 2, 2, SemanaIngresos.Count + 3, BorderStyleValues.Thin);
                    sl.MergeWorksheetCells("C3", "C4");

                    //set height for each column
                    sl.SetRowHeight(1, 25);
                    sl.SetRowHeight(2, 25);
                    sl.SetRowHeight(3, 25);
                    sl.SetRowHeight(4, 25);

                    //set width for each header cell
                    sl.SetColumnWidth(2, 20);
                    sl.SetColumnWidth(3, 17);

                    sl.SetCellValue("B2", "INGRESOS");

                    SLStyle styleTitle = sl.CreateStyle();

                    styleTitle.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.LightGray, System.Drawing.Color.Black);
                    styleTitle.SetVerticalAlignment(VerticalAlignmentValues.Center);
                    styleTitle.SetHorizontalAlignment(HorizontalAlignmentValues.Center);
                    styleTitle.Font.Bold = true;
                    styleTitle.Font.FontSize = 11;
                    sl.SetCellStyle(2, 2, styleTitle);

                    SLStyle styleProducto = sl.CreateStyle();
                    styleProducto.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleProducto.SetTopBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleProducto.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleProducto.SetRightBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleProducto.SetVerticalAlignment(VerticalAlignmentValues.Center);
                    styleProducto.SetHorizontalAlignment(HorizontalAlignmentValues.Left);
                    styleProducto.Font.Bold = false;
                    styleProducto.Font.FontSize = 10;

                    SLStyle styleDiaIngreso = sl.CreateStyle();
                    styleDiaIngreso.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleDiaIngreso.SetTopBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleDiaIngreso.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleDiaIngreso.SetRightBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleDiaIngreso.SetVerticalAlignment(VerticalAlignmentValues.Center);
                    styleDiaIngreso.SetHorizontalAlignment(HorizontalAlignmentValues.Right);
                    styleDiaIngreso.Font.Bold = false;
                    styleDiaIngreso.Font.FontSize = 10;

                    SLStyle styleDates = sl.CreateStyle();
                    styleDates.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleDates.SetTopBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleDates.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleDates.SetRightBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleDates.SetVerticalAlignment(VerticalAlignmentValues.Center);
                    styleDates.SetHorizontalAlignment(HorizontalAlignmentValues.Center);
                    styleDates.Font.Bold = true;
                    styleDates.Font.FontSize = 10;
                    styleDates.SetWrapText(true);

                    SLStyle styleIndexes = sl.CreateStyle();
                    styleIndexes.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleIndexes.SetTopBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleIndexes.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleIndexes.SetRightBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleIndexes.SetVerticalAlignment(VerticalAlignmentValues.Center);
                    styleIndexes.SetHorizontalAlignment(HorizontalAlignmentValues.Left);
                    styleIndexes.Font.Bold = true;
                    styleIndexes.Font.FontSize = 10;

                    SLStyle styleTotalIngresos = sl.CreateStyle();

                    styleTotalIngresos.SetVerticalAlignment(VerticalAlignmentValues.Center);
                    styleTotalIngresos.SetHorizontalAlignment(HorizontalAlignmentValues.Center);
                    styleTotalIngresos.Font.FontSize = 10;
                    styleTotalIngresos.Font.FontColor = System.Drawing.Color.Green;

                    SLStyle styleSubTotalIngresos = sl.CreateStyle();
                    styleSubTotalIngresos.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleSubTotalIngresos.SetTopBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleSubTotalIngresos.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleSubTotalIngresos.SetRightBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);

                    styleSubTotalIngresos.SetVerticalAlignment(VerticalAlignmentValues.Center);
                    styleSubTotalIngresos.SetHorizontalAlignment(HorizontalAlignmentValues.Right);
                    styleSubTotalIngresos.Font.FontSize = 10;
                    styleSubTotalIngresos.Font.FontColor = System.Drawing.Color.Green;

                    SLStyle styleTotalEgresos = sl.CreateStyle();
                    styleTotalEgresos.SetVerticalAlignment(VerticalAlignmentValues.Center);
                    styleTotalEgresos.SetHorizontalAlignment(HorizontalAlignmentValues.Center);
                    styleTotalEgresos.Font.FontSize = 10;
                    styleTotalEgresos.Font.FontColor = System.Drawing.Color.Red;

                    SLStyle styleSubTotalEgresos = sl.CreateStyle();
                    styleSubTotalEgresos.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleSubTotalEgresos.SetTopBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleSubTotalEgresos.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
                    styleSubTotalEgresos.SetRightBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);

                    styleSubTotalEgresos.SetVerticalAlignment(VerticalAlignmentValues.Center);
                    styleSubTotalEgresos.SetHorizontalAlignment(HorizontalAlignmentValues.Right);
                    styleSubTotalEgresos.Font.FontSize = 10;
                    styleSubTotalEgresos.Font.FontColor = System.Drawing.Color.Red;

                    sl.SetCellValue("B4", "DETALLES");
                    sl.SetCellStyle(3, 2, styleIndexes);
                    sl.SetCellStyle(4, 2, styleIndexes);

                    sl.SetCellValue("C3", "INGRESOS DE LA SEMANA PASADA");
                    sl.SetCellStyle(3, 3, styleDates);
                    foreach (List<Factura> Dia in SemanaIngresos)
                    {
                        foreach (Factura ingreso in Dia)
                        {
                            foreach (Detfactura det in ingreso.DetsFactura)
                            {

                                if (productosTable.Where(a => a.Id == det.IdProducto).FirstOrDefault() == null)
                                {
                                    productosTable.Add(det.Producto);

                                    sl.SetCellValue(4 + productosTable.Count, dayWeek + 3, "DETALLES");

                                }
                            }
                        }
                    }

                    for (int d = 0; d < SemanaIngresos.Count; d++)
                    {
                        sl.SetCellValue("B3", new DateTime(pYear, pMonth, 1).ToString("MMMM", new CultureInfo("es-ES")).ToUpper());
                        List<Factura> Dia = SemanaIngresos[d];
                        sl.SetColumnWidth(dayWeek + 3, 12);

                        sl.SetCellValue(3, dayWeek + 3, new DateTime(pYear, pMonth, dayMonthIngrsos).ToShortDateString());
                        sl.SetCellStyle(3, dayWeek + 3, styleDates);

                        sl.SetCellValue(4, dayWeek + 3, new DateTime(pYear, pMonth, dayMonthIngrsos).DayOfWeek.ToString());
                        sl.SetCellStyle(4, dayWeek + 3, styleDates);

                        foreach (Factura ingreso in Dia)
                        {
                            foreach (Detfactura det in ingreso.DetsFactura)
                            {
                                DetallesSemana.Add(det);
                            }
                        }


                        for (int prod = 0; prod < productosTable.Count; prod++)
                        {
                            Producto producto = productosTable[prod];
                            decimal ingresoDiaProducto = 0;
                            List<Factura> ingresoInDia = new List<Factura>();
                            if (Dia.Where(a => Convert.ToDateTime(a.FhRegistro).Day == dayMonthIngrsos && a.DetsFactura.Where(dt => dt.IdProducto == producto.Id).Count() > 0).Count() > 0)
                            {
                                ingresoInDia = Dia.Where(a => Convert.ToDateTime(a.FhRegistro).Day == dayMonthIngrsos && a.DetsFactura.Where(dt => dt.IdProducto == producto.Id).Count() > 0).ToList();
                            }

                            foreach (Factura fact in ingresoInDia)
                            {
                                foreach (Detfactura det in fact.DetsFactura.Where(a => a.IdProducto == productosTable[prod].Id))
                                {
                                    ingresoDiaProducto += (det.Total - det.Descuento);
                                    totalSemana += (det.Total - det.Descuento);
                                }
                            }
                            sl.SetCellValue(5 + prod, dayWeek + 3, ingresoDiaProducto == 0 ? "" : "$" + Decimal.Round(ingresoDiaProducto, 2).ToString());
                            sl.SetCellStyle(5 + prod, dayWeek + 3, styleDiaIngreso);
                            sl.SetCellStyle(5 + prod, 3, styleProducto);

                        }
                        //MessageBox.Show(new DateTime(2019,3,1).DayOfWeek.ToString());
                        decimal ingresoDia = 0;
                        List<Factura> ingresoInDiaSub = new List<Factura>();
                        if (Dia.Where(a => Convert.ToDateTime(a.FhRegistro).Day == dayMonthIngrsos).Count() > 0)
                        {
                            ingresoInDiaSub = Dia.Where(a => Convert.ToDateTime(a.FhRegistro).Day == dayMonthIngrsos).ToList();
                        }

                        foreach (Factura fact in ingresoInDiaSub)
                        {
                            foreach (Detfactura det in fact.DetsFactura)
                            {
                                ingresoDia += (det.Total - det.Descuento);
                            }
                        }
                        sl.SetCellValue("B" + (productosTable.Count + 5), "SUBTOTAL DE INGRESOS");
                        sl.SetCellStyle((productosTable.Count + 5), 2, styleIndexes);
                        sl.SetRowHeight(productosTable.Count + 5, 30);

                        sl.SetCellStyle((productosTable.Count + 5), dayWeek + 3, styleSubTotalIngresos);
                        sl.SetCellValue((productosTable.Count + 5), dayWeek + 3, "$" + Decimal.Round(ingresoDia, 2).ToString());

                        dayWeek++;
                        dayMonthIngrsos++;
                    }
                    for (int p = 0; p < productosTable.Count; p++)
                    {
                        sl.SetCellValue("B" + (p + 5), productosTable[p].Nombre);
                        sl.SetCellStyle(p + 5, 2, styleProducto);
                        sl.SetRowHeight(p + 5, 30);
                    }
                    sl.MergeWorksheetCells(5, 3, productosTable.Count + 5, 3, BorderStyleValues.Thin);
                    sl.MergeWorksheetCells(productosTable.Count + 6, 3, productosTable.Count + 6, SemanaIngresos.Count + 3, BorderStyleValues.Thin);
                    sl.SetCellValue("B" + (productosTable.Count + 6), "TOTAL SEMANA");
                    sl.SetCellStyle((productosTable.Count + 6), 2, styleIndexes);
                    sl.SetRowHeight(productosTable.Count + 6, 30);
                    sl.SetCellStyle((productosTable.Count + 6), 3, styleTotalIngresos);
                    sl.SetCellValue("C" + 5, "$" + Decimal.Round(lastTotalIngresos, 2));
                    sl.SetCellStyle(5, 3, styleDates);
                    sl.SetCellStyle((productosTable.Count + 5), 3, styleDates);

                    sl.SetCellValue("C" + (productosTable.Count + 6), "$" + Decimal.Round(totalSemana, 2));

                    lastTotalIngresos = totalSemana;
                    //procesando egresos

                    sl.MergeWorksheetCells(3 + productosTable.Count + 5, 2, 3 + productosTable.Count + 5, SemanaIngresos.Count + 3, BorderStyleValues.Thin);
                    sl.MergeWorksheetCells("C" + (3 + productosTable.Count + 6), "C" + (3 + productosTable.Count + 7));

                    sl.SetCellValue("B" + (3 + productosTable.Count + 5), "EGRESOS");
                    sl.SetCellStyle((3 + productosTable.Count + 5), 2, styleTitle);

                    sl.SetRowHeight(3 + productosTable.Count + 2, 25);
                    sl.SetRowHeight(3 + productosTable.Count + 2 + 1, 25);
                    sl.SetRowHeight(3 + productosTable.Count + 2 + 2, 25);
                    sl.SetRowHeight(3 + productosTable.Count + 2 + 3, 25);
                    sl.SetRowHeight(3 + productosTable.Count + 2 + 4, 25);
                    sl.SetRowHeight(3 + productosTable.Count + 2 + 5, 25);

                    sl.SetCellValue("B" + (3 + productosTable.Count + 6), new DateTime(pYear, pMonth, 1).ToString("MMMM", new CultureInfo("es-ES")).ToUpper());
                    sl.SetCellValue("B" + (3 + productosTable.Count + 7), "DETALLES");
                    sl.SetCellStyle((3 + productosTable.Count + 6), 2, styleDates);
                    sl.SetCellStyle((3 + productosTable.Count + 7), 2, styleIndexes);

                    sl.SetCellValue("C" + (3 + productosTable.Count + 6), "EGRESOS DE LA SEMANA PASADA");
                    sl.SetCellStyle((3 + productosTable.Count + 6), 3, styleDates);
                    dayWeek = 1;

                    decimal totalSemanaEgr = 0;
                    ConceptosEgresos.Clear();

                    for (int d = 0; d < SemanaEgresos.Count; d++)
                    {
                        foreach (Egreso egreso in SemanaEgresos[d])
                        {
                            if (ConceptosEgresos.Where(a => a.Nombre.ToUpper().Trim() == egreso.Nombre.ToUpper().Trim()).FirstOrDefault() == null)
                            {
                                ConceptosEgresos.Add(egreso);
                            }
                        }


                    }
                    sl.SetCellStyle((3 + productosTable.Count + ConceptosEgresos.Count + 8), 2, styleIndexes);

                    for (int d = 0; d < SemanaEgresos.Count; d++)
                    {
                        List<Egreso> Dia = SemanaEgresos[d];
                        decimal TotalEgresoDia = 0;

                        sl.SetCellValue("B" + (3 + productosTable.Count + 6), new DateTime(pYear, pMonth, 1).ToString("MMMM", new CultureInfo("es-ES")).ToUpper());
                        sl.SetCellValue((3 + productosTable.Count + 6), dayWeek + 3, new DateTime(pYear, pMonth, dayMonthEgresos).ToShortDateString());
                        sl.SetCellStyle((3 + productosTable.Count + 6), dayWeek + 3, styleDates);

                        sl.SetCellValue((3 + productosTable.Count + 7), dayWeek + 3, new DateTime(pYear, pMonth, dayMonthEgresos).DayOfWeek.ToString());
                        sl.SetCellStyle((3 + productosTable.Count + 7), dayWeek + 3, styleDates);

                        for (int egr = 0; egr < ConceptosEgresos.Count; egr++)
                        {
                            decimal EgresoDia = 0;
                            Egreso egreso = ConceptosEgresos[egr];
                            List<Egreso> egresoInDia = new List<Egreso>();
                            if (Dia.Where(a => Convert.ToDateTime(a.FhRegistro).Day == dayMonthEgresos).Count() > 0)
                            {
                                egresoInDia = Dia.Where(a => Convert.ToDateTime(a.FhRegistro).Day == dayMonthEgresos && a.Nombre.ToUpper().Trim() == egreso.Nombre.ToUpper().Trim()).ToList();
                            }

                            foreach (Egreso fact in egresoInDia)
                            {
                                EgresoDia += (fact.Total);
                                TotalEgresoDia += EgresoDia;
                                totalSemanaEgr += (fact.Total);
                            }
                            sl.SetCellValue((3 + productosTable.Count + 8) + egr, dayWeek + 3, EgresoDia == 0 ? "" : "$" + Decimal.Round(EgresoDia, 2).ToString());
                            sl.SetCellStyle((3 + productosTable.Count + 8) + egr, 3, styleDiaIngreso);
                            sl.SetCellStyle((3 + productosTable.Count + 8) + egr, dayWeek + 3, styleDiaIngreso);


                        }
                        for (int p = 0; p < ConceptosEgresos.Count; p++)
                        {
                            sl.SetCellValue("B" + ((3 + productosTable.Count + 8) + p), ConceptosEgresos[p].Nombre);
                            sl.SetCellStyle(((3 + productosTable.Count + 8) + p), 2, styleProducto);

                            sl.SetRowHeight(((3 + productosTable.Count + 8) + p), 30);
                        }

                        sl.SetCellStyle((3 + productosTable.Count + ConceptosEgresos.Count + 8), dayWeek + 3, styleSubTotalEgresos);
                        sl.SetCellValue((3 + productosTable.Count + ConceptosEgresos.Count + 8), dayWeek + 3, "$" + Decimal.Round(TotalEgresoDia, 2).ToString());

                        dayMonthEgresos++;
                        dayWeek++;

                    }
                    sl.MergeWorksheetCells((3 + productosTable.Count + 8), 3, (3 + productosTable.Count +ConceptosEgresos.Count+ 8), 3, BorderStyleValues.Thin);

                    sl.MergeWorksheetCells((3 + productosTable.Count + ConceptosEgresos.Count + 9), 3, (3 + productosTable.Count + ConceptosEgresos.Count + 9), 3 + SemanaEgresos.Count, BorderStyleValues.Thin);


                    sl.SetCellValue("B" + (3 + productosTable.Count + ConceptosEgresos.Count + 8), "SUBTOTAL EGRESOS SEMANA");
                    sl.SetCellValue("B" + (3 + productosTable.Count + ConceptosEgresos.Count + 9), "TOTAL SEMANA");
                    sl.SetRowHeight((3 + productosTable.Count + ConceptosEgresos.Count + 8), 30);
                    sl.SetCellValue("C" + (3 + productosTable.Count + 8), "$" + Decimal.Round(lastTotalEgresos, 2));
                    sl.SetCellStyle((3 + productosTable.Count + 8), 3, styleDates);

                    sl.SetCellStyle((3 + productosTable.Count + ConceptosEgresos.Count + 9), 2, styleIndexes);
                    sl.SetCellStyle((3 + productosTable.Count + ConceptosEgresos.Count + 9), 3, styleTotalEgresos);
                    sl.SetRowHeight((3 + productosTable.Count + ConceptosEgresos.Count + 9), 30);
                    sl.SetCellValue("C" + (3 + productosTable.Count + ConceptosEgresos.Count + 9), "$" + Decimal.Round(totalSemanaEgr, 2));
                    lastTotalEgresos = totalSemanaEgr;
                    //resumen 
                    sl.MergeWorksheetCells((3 + productosTable.Count + ConceptosEgresos.Count + 11), 2, (3 + productosTable.Count + ConceptosEgresos.Count + 11), 3 + SemanaEgresos.Count, BorderStyleValues.Thin);
                    sl.MergeWorksheetCells((3 + productosTable.Count + ConceptosEgresos.Count + 12), 3, (3 + productosTable.Count + ConceptosEgresos.Count + 12), 3 + SemanaEgresos.Count, BorderStyleValues.Thin);
                    sl.MergeWorksheetCells((3 + productosTable.Count + ConceptosEgresos.Count + 13), 3, (3 + productosTable.Count + ConceptosEgresos.Count + 13), 3 + SemanaEgresos.Count, BorderStyleValues.Thin);
                    sl.MergeWorksheetCells((3 + productosTable.Count + ConceptosEgresos.Count + 14), 3, (3 + productosTable.Count + ConceptosEgresos.Count + 14), 3 + SemanaEgresos.Count, BorderStyleValues.Thin);

                    sl.SetRowHeight((3 + productosTable.Count + ConceptosEgresos.Count + 10), 25);
                    sl.SetRowHeight((3 + productosTable.Count + ConceptosEgresos.Count + 11), 25);
                    sl.SetRowHeight((3 + productosTable.Count + ConceptosEgresos.Count + 12), 25);
                    sl.SetRowHeight((3 + productosTable.Count + ConceptosEgresos.Count + 13), 25);
                    sl.SetRowHeight((3 + productosTable.Count + ConceptosEgresos.Count + 14), 25);

                    sl.SetCellStyle((3 + productosTable.Count + ConceptosEgresos.Count + 11), 2, styleTitle);
                    sl.SetCellStyle((3 + productosTable.Count + ConceptosEgresos.Count + 12), 2, styleDates);
                    sl.SetCellStyle((3 + productosTable.Count + ConceptosEgresos.Count + 13), 2, styleDates);
                    sl.SetCellStyle((3 + productosTable.Count + ConceptosEgresos.Count + 14), 2, styleDates);

                    sl.SetCellStyle((3 + productosTable.Count + ConceptosEgresos.Count + 12), 3, styleTotalIngresos);
                    sl.SetCellStyle((3 + productosTable.Count + ConceptosEgresos.Count + 13), 3, styleTotalEgresos);
                    sl.SetCellStyle((3 + productosTable.Count + ConceptosEgresos.Count + 14), 3, (totalSemana - totalSemanaEgr) == 0 ? styleDates : (totalSemana - totalSemanaEgr) < 0 ? styleTotalEgresos : styleTotalIngresos);

                    sl.SetCellValue("B" + (3 + productosTable.Count + ConceptosEgresos.Count + 11), "RESUMEN FINAL DE SEMANA ENTREGADO AL ADMINISTRADOR");
                    sl.SetCellValue("B" + (3 + productosTable.Count + ConceptosEgresos.Count + 12), "GASTOS");
                    sl.SetCellValue("B" + (3 + productosTable.Count + ConceptosEgresos.Count + 13), "INGRESOS");
                    sl.SetCellValue("B" + (3 + productosTable.Count + ConceptosEgresos.Count + 14), "TOTAL");

                    sl.SetCellValue("C" + (3 + productosTable.Count + ConceptosEgresos.Count + 12), "$" + Decimal.Round(totalSemana, 2));
                    sl.SetCellValue("C" + (3 + productosTable.Count + ConceptosEgresos.Count + 13), "$" + Decimal.Round(totalSemanaEgr, 2));
                    sl.SetCellValue("C" + (3 + productosTable.Count + ConceptosEgresos.Count + 14), "$" + Decimal.Round(totalSemana - totalSemanaEgr, 2));

                }

                sl.DeleteWorksheet("Sheet1");
                if (!Directory.Exists(folderpath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(folderpath);
                    sl.SaveAs(folderpath + "\\" + fileName);
                }
                else
                {
                    sl.SaveAs(folderpath + "\\" + fileName);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return result;
        }
    }
}
