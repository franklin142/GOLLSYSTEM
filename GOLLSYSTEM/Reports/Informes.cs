using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.DataAccess;
using GOLLSYSTEM.EntityLayer;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Globalization;

namespace GOLLSYSTEM.Reports
{
    public class Informes
    {
        string RutaArchivo { get; set; }
        Document DocActual { get; set; }
        public void GenerarRepMorosos(AxAcroPDFLib.AxAcroPDF VisorPDF,Int64 IdYear,Int64 IdCurso)
        {
            try
            {
                EliminarTemporal();
                VisorPDF.src = "";
                getDatos();

                Document pdf1 = new Document(PageSize.LETTER, 36.6929f, 36.6929f, 36.6929f, 36.6929f);

                string title = "Reporte de alumnos con mora" + "_" + DateTime.Now.ToString("yyyy_MM_dd_mm_hh_ss") + ".pdf";

                RutaArchivo = Path.GetTempPath() + "/" + title;

                PdfWriter wri = PdfWriter.GetInstance(pdf1, new FileStream(RutaArchivo, FileMode.Create));
                PageEventHelper eventHelper = new PageEventHelper();
                eventHelper.Reporte = 1;
                wri.PageEvent = eventHelper;

                iTextSharp.text.Font fontEncabezado = FontFactory.GetFont("Calibri", 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font fontCuerpoSmall = FontFactory.GetFont("Calibri", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                iTextSharp.text.Font fontHeaderTabla = FontFactory.GetFont("Calibri", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font fontHeaderTablaSmall = FontFactory.GetFont("Calibri", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font fontMotivo = FontFactory.GetFont("Calibri", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                pdf1.Open();
                pdf1.AddTitle(title);

                DocActual = pdf1;


                //encabezado
                float[] medCellsEncabezado = new float[] { 150.0394f, 400.0394f, 150.0394f };

                PdfPTable tblEcabezado = new PdfPTable(3);

                tblEcabezado.WidthPercentage = 100;
                tblEcabezado.SetWidths(medCellsEncabezado);
                iTextSharp.text.Image imagenLogo = iTextSharp.text.Image.GetInstance(Properties.Resources.goll_Logo_png, BaseColor.WHITE);
                imagenLogo.BorderWidth = 0;
                imagenLogo.Alignment = Element.ALIGN_LEFT;
                float percentage = 0.0f;
                percentage = 150 / imagenLogo.Width;
                imagenLogo.ScalePercent(percentage * 40);

                PdfPCell cImagenLogo = new PdfPCell(imagenLogo);
                cImagenLogo.BorderWidth = 0;
                tblEcabezado.AddCell(cImagenLogo);

                Paragraph myheader1 = new Paragraph("\n\nACADEMIA DE INGLES Y COMPUTACIÓN GOLL", fontEncabezado);
                Paragraph myheader2 = new Paragraph("\nREPORTE DE ALUMNOS CON PAGOS PENDIENTES", fontEncabezado);
                Paragraph myheader3 = new Paragraph("\n"+CursoDAL.getCursoById(IdCurso).Nombre.ToUpper()+" "+Convert.ToDateTime(YearDAL.getYearById(IdYear).Desde).ToString("yyyy")+"\n\n", fontEncabezado);

                myheader1.Alignment = Element.ALIGN_CENTER;
                myheader2.Alignment = Element.ALIGN_CENTER;
                myheader3.Alignment = Element.ALIGN_CENTER;

                myheader1.SetLeading(0, 0.8f);
                myheader2.SetLeading(0, 0.8f);
                myheader3.SetLeading(0, 0.8f);

                PdfPCell clEncabezado = new PdfPCell(myheader1);
                clEncabezado.AddElement(myheader1);
                clEncabezado.AddElement(myheader2);
                clEncabezado.AddElement(myheader3);

                clEncabezado.BorderWidth = 0;

                tblEcabezado.AddCell(clEncabezado);

                iTextSharp.text.Image imagenSV = iTextSharp.text.Image.GetInstance(Properties.Resources.Goll_Logo, BaseColor.WHITE);
                imagenSV.BorderWidth = 0;
                imagenSV.Alignment = Element.ALIGN_TOP;
                float percentageSV = 0.0f;
                percentageSV = 150 / imagenSV.Width;
                imagenSV.ScalePercent(percentageSV * 70);

                PdfPCell cImagenSV = new PdfPCell(imagenSV);
                cImagenSV.BorderWidth = 0;
                tblEcabezado.AddCell(cImagenSV);
                DocActual.Add(tblEcabezado);
                //header de tabla

                PdfPTable tabla = new PdfPTable(3);
                PdfPCell celda = new PdfPCell();
                celda.HorizontalAlignment = 1;
                celda.VerticalAlignment = 5;
                tabla.WidthPercentage = 100;

                celda.BackgroundColor = BaseColor.LIGHT_GRAY;
                
                List<Matricula> matriculas = MatriculaDAL.searchMatriculasParametro("",IdYear,IdCurso);
                DateTime serverDate = YearDAL.getServerDate();

                foreach (Matricula matricula in matriculas)
                {
                    float[] medColumnas = new float[] { 180f, 180f, 80f, 140f };

                    tabla = new PdfPTable(4);
                    tabla.WidthPercentage = 100;
                    tabla.SetWidths(medColumnas);

                    tabla.AddCell(GetCellHeaderTable("Alumno", 1, 1, fontHeaderTabla));
                    tabla.AddCell(GetCellHeaderTable("Dirección", 1, 1, fontHeaderTabla));
                    tabla.AddCell(GetCellHeaderTable("Teléfono", 1, 1, fontHeaderTabla));
                    tabla.AddCell(GetCellHeaderTable("Total Pendiente", 1, 1, fontHeaderTablaSmall));
                    List<Cuota> atrasadas = matricula.Cuotas.Where(a => (Convert.ToDateTime(a.FhRegistro) < serverDate.AddDays(Properties.Settings.Default.DaysMora)) && a.Total < a.Precio).ToList();
                    if (atrasadas.Count>0)
                    {

                        tabla.AddCell(GetCellBodyTable("" + matricula.Estudiante.Persona.Nombre.ToUpper(), fontCuerpoSmall));
                        tabla.AddCell(GetCellBodyTable("" + matricula.Estudiante.Persona.Direccion.ToUpper(), fontCuerpoSmall));
                        tabla.AddCell(GetCellBodyTable("" + matricula.Estudiante.Telefono.ToUpper(), fontCuerpoSmall));
                        string pendiente = "";
                        string totales = "";
                        decimal mensualiades = 0;
                        foreach (Cuota cuota in atrasadas)
                        {
                            pendiente += Convert.ToDateTime(cuota.FhRegistro).ToString("MMMM",new CultureInfo("ES-es"))+" $"+Decimal.Round((cuota.Precio-cuota.Total),2)+"\n";
                            mensualiades += Decimal.Round((cuota.Precio - cuota.Total));
                        }
                        totales += "TOTAL EN CUOTAS $" + mensualiades;
                        totales += "        TOTAL EN MORA $" + Decimal.Round(Properties.Settings.Default.Mora * atrasadas.Count,2);
                        totales += "        TOTAL A PAGAR $" + Decimal.Round((mensualiades+ Properties.Settings.Default.Mora * atrasadas.Count),2);

                        tabla.AddCell(GetCellBodyTable(pendiente.ToUpper(), fontMotivo));
                        tabla.AddCell(GetCellBodyTable(totales.ToUpper(),4,1, fontHeaderTabla));
                        DocActual.Add(tabla);
                        DocActual.Add(new Paragraph("\n", fontEncabezado));
                      //  DocActual.Add(new Chunk("\n"));
                    }

                }
                pdf1.Close();
                DocActual.Close();
                VisorPDF.src = RutaArchivo;
                VisorPDF.setZoom(95);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private PdfPCell GetCellBodyTable(string text, iTextSharp.text.Font font)
        {
            return GetCellBodyTable(text, 1, 1, font);
        }
        private PdfPCell GetCellBodyTable(string text, int colSpan, int rowSpan, iTextSharp.text.Font font)
        {
            Paragraph textCell = new Paragraph(text, font);

            PdfPCell cell = new PdfPCell(textCell);

            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.Padding = 10f;
            cell.Rowspan = rowSpan;
            cell.Colspan = colSpan;
            return cell;
        }

        private PdfPCell GetCellHeaderTable(string text, iTextSharp.text.Font font)
        {
            return GetCellHeaderTable(text, 1, 1, font);
        }
        private PdfPCell GetCellHeaderTable(string text, int colSpan, int rowSpan, iTextSharp.text.Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.FixedHeight = 28;
            cell.HorizontalAlignment = 1;
            cell.VerticalAlignment = 5;
            cell.Rowspan = rowSpan;
            cell.Colspan = colSpan;
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            return cell;
        }
        private PdfPCell GetCellMotivo(string text, int colSpan, int rowSpan, iTextSharp.text.Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cell.VerticalAlignment = 5;
            cell.Rowspan = rowSpan;
            cell.Colspan = colSpan;
            cell.PaddingLeft = 5f;
            cell.PaddingRight = 5f;
            cell.PaddingTop = 5f;
            cell.PaddingBottom = 5f;
            return cell;
        }

        private void getDatos()
        {

        }
        private void EliminarTemporal()
        {
            try
            {
                if (RutaArchivo != null && RutaArchivo != string.Empty)
                {
                    if (File.Exists(RutaArchivo))
                    {
                        File.Delete(RutaArchivo);
                    }
                    RutaArchivo = string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //MessageBox.Show("Error al eliminar el archivo temporal de reporte.\n" + ex.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }

}
