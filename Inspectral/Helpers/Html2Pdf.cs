using iText.Html2pdf;
using iText.Kernel.Events;
using iText.Kernel.Utils;

using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Collection;
using iText.Kernel.Font;
using iText.Kernel.Numbering;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Font;
using System;
using System.IO;
using iText.Kernel.Colors;
using iText.Html2pdf.Resolver.Font;

namespace Inspectral.Helpers
{
    public class Html2Pdf
    {
        public static void ExportarPDF(string html, string destFile = @"/Data/PdfOutput/pdfFile")
        {
            var gu = Guid.NewGuid();
            var fStream = new FileStream(destFile + gu.ToString() + ".pdf", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            PdfWriter writer = new PdfWriter(fStream);
            ConverterProperties converterProperties = new ConverterProperties();
            HtmlConverter.ConvertToPdf(html, fStream, converterProperties);
        }

        /*
         * // pdfHTML specific code
        ConverterProperties converterProperties = new ConverterProperties();
        HtmlConverter.convertToPdf(new FileInputStream(htmlSource), new FileOutputStream(pdfDest), converterProperties);
         * **/
        public static void ExportarPDF2(string html, string FileName) 
        {
            var destFile = FileName;
            var fStream = new FileStream(destFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            // var pdfTemp = new MemoryStream();
            // Stream dest = new Stream;
            //Initialize PDF writer
            PdfWriter writer = new PdfWriter(fStream);

            //Initialize PDF document
            PdfDocument pdf = new PdfDocument(writer);

            // Initialize document
            Document document = new Document(pdf);
            var elem = new Text(html);
            var area = new AreaBreak();
            // area.SetTextRenderingMode()
            // Add paragraph to the document
            // document.Add();

            //Close document
            document.Close();
        }
        protected internal class MyEventHandler : IEventHandler
        {
            public virtual void HandleEvent(Event @event)
            {
                PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
                PdfDocument pdfDoc = docEvent.GetDocument();
                PdfPage page = docEvent.GetPage();
                int pageNumber = pdfDoc.GetPageNumber(page);
                Rectangle pageSize = page.GetPageSize();
                PdfCanvas pdfCanvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);
                //Add watermark
                Canvas canvas = new Canvas(pdfCanvas, pdfDoc, page.GetPageSize());
                canvas.SetFontColor(ColorConstants.WHITE);
                canvas.SetProperty(Property.FONT_SIZE, 60);
                // canvas.SetProperty(Property.FONT, BaseFont.);
                ConverterProperties properties = new ConverterProperties();
                properties.SetFontProvider(new DefaultFontProvider(true, true, true));
                canvas.ShowTextAligned(new Paragraph("CONFIDENTIAL"),
                    298, 421, pdfDoc.GetPageNumber(page),
                    TextAlignment.CENTER, VerticalAlignment.MIDDLE, 45);
                pdfCanvas.Release();
            }
        }
    }
}
