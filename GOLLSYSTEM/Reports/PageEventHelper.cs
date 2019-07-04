using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using iTextSharp.text;
namespace GOLLSYSTEM.Reports
{
    public class PageEventHelper : PdfPageEventHelper
    {
        PdfContentByte cb;
        PdfTemplate template;
        PdfContentByte cbsimarn;
        public int Reporte = 0;
        private List<PdfTemplate> templates = new List<PdfTemplate>();
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            cb = writer.DirectContent;
            cbsimarn = writer.DirectContent;
            template = cb.CreateTemplate(50, 50);
        }
        public override void OnStartPage(PdfWriter writer, Document doc)
        {
            base.OnStartPage(writer, doc);
            switch (Reporte)
            {
                case 1:
                    //iTextSharp.text.Font font1 = FontFactory.GetFont("Helvetica", 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                    ////tbl header
                    //PdfPTable headerTbl1 = new PdfPTable(1);
                    //headerTbl1.TotalWidth = doc.PageSize.Width - (doc.RightMargin + doc.LeftMargin);
                    ////encabezado
                    //Paragraph myheader1 = new Paragraph("MINISTERIO DE EDUCACION\n", font1);

                    //myheader1.Add(new Paragraph("\nCOMPLEJO EDUCATIVO CANTON ARRACAOS\n", font1));

                    //myheader1.Add(new Paragraph("\nREGISTRO DE NOTAS\n", font1));

                    //PdfPCell header1 = new PdfPCell(myheader1);
                    //header1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    //header1.HorizontalAlignment = Element.ALIGN_CENTER;
                    //headerTbl1.AddCell(header1);
                    //headerTbl1.WriteSelectedRows(0, -1, (doc.LeftMargin), doc.PageSize.Height - 28.1f, writer.DirectContent);
                    break;
                case 2:
                    //iTextSharp.text.Font font2 = FontFactory.GetFont("Helvetica", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                    //PdfPTable headerTbl2 = new PdfPTable(1);
                    //headerTbl2.TotalWidth = doc.PageSize.Width - (doc.RightMargin + doc.LeftMargin);
                    //Phrase myheader2 = new Phrase();
                    //PdfPCell header2 = new PdfPCell(myheader2);
                    //header2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    //if (writer.PageNumber == 1)
                    //{
                    //    myheader2 = new Phrase("ESPECIFICACIÓN DEL PROGRESO DE BULTOS", font2);
                    //    header2.HorizontalAlignment = Element.ALIGN_CENTER;
                    //}
                    //else
                    //{
                    //    myheader2 = new Phrase("PROGRESO DE BULTOS - ORDEN NO. ", font2);
                    //    header2.HorizontalAlignment = Element.ALIGN_LEFT;
                    //}
                    //header2.Phrase = myheader2;
                    //headerTbl2.AddCell(header2);
                    //headerTbl2.WriteSelectedRows(0, -1, (doc.LeftMargin), doc.PageSize.Height - 26.1f, writer.DirectContent);
                    break;
                case 3:

                    break;
                default:break;

            }
            
        }
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            if (Reporte == 1)
            {
                PdfTemplate templateM = cb.CreateTemplate(50, 50);
                templates.Add(templateM);
                int pageN = writer.CurrentPageNumber;
                string pageText = "Página " + pageN.ToString("00") + " de ";
                string pageSicorp = "Academia GOLL " + DateTime.Now.ToString("dd-MM-yyyy");
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                float len = bf.GetWidthPoint(pageText, 10);
                cb.BeginText();
                cb.SetFontAndSize(bf, 10);
                cb.SetTextMatrix((document.PageSize.Width - 120f), document.PageSize.GetBottom(document.BottomMargin - 5));
                cb.ShowText(pageText);
                cb.EndText();
                cb.AddTemplate(templateM, (document.PageSize.Width - 120f) + len, document.PageSize.GetBottom(document.BottomMargin - 5));
                cbsimarn.BeginText();
                cbsimarn.SetFontAndSize(bf, 10);
                cbsimarn.SetTextMatrix(document.LeftMargin, document.PageSize.GetBottom(document.BottomMargin - 5));
                cbsimarn.ShowText(pageSicorp);
                cbsimarn.EndText();
            }
            else if (Reporte == 3)
            {
                //PdfTemplate templateM = cb.CreateTemplate(50, 50);
                //string pageSicorp = "SICORP " + DateTime.Now.ToString("dd-MM-yyyy");
                //BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                //cbsimarn.BeginText();
                //cbsimarn.SetFontAndSize(bf, 10);
                //cbsimarn.SetTextMatrix(document.LeftMargin, document.PageSize.GetBottom(document.BottomMargin));
                //cbsimarn.ShowText(pageSicorp);
                //cbsimarn.EndText();
            }
        }
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
            if (Reporte == 1 || Reporte==2)
            {
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                foreach (PdfTemplate item in templates)
                {
                    item.BeginText();
                    item.SetFontAndSize(bf, 10);
                    item.SetTextMatrix(0, 0);
                    item.ShowText("" + writer.PageNumber.ToString("00"));
                    item.EndText();
                }
            }
        }
    }
}
