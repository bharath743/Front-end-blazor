using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;
using System.IO;
using Microsoft.JSInterop;
using FrontEnd.BlazorWasm.Services.Interfaces;

namespace FrontEnd.BlazorWasm.Services
{
    public class PdfExportationService : IPdfExportationService
    {
        IJSRuntime js;

        public PdfExportationService(IJSRuntime jSuntime)
        {
            this.js = jSuntime;
        }

        public async void ExportPdf<T>(IEnumerable<T> data, string docTitle, string comments,string mTitle)
        {
            int paragraphAfterSpacing = 8;
            int cellMargin = 8;
            PdfDocument pdfDocument = new PdfDocument();
            //Add Page to the PDF document.
            PdfPage page = pdfDocument.Pages.Add();

            //Create a new font.
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);

            //Create a text element to draw a text in PDF page.
            PdfTextElement title = new PdfTextElement(mTitle, font, PdfBrushes.Black);
            PdfLayoutResult result = title.Draw(page, new PointF(0, 0));


            PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
            PdfTextElement content = new PdfTextElement(comments, contentFont, PdfBrushes.Black);
            PdfLayoutFormat format = new PdfLayoutFormat();
            format.Layout = PdfLayoutType.Paginate;

            //Draw a text to the PDF document.
            result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();
            pdfGrid.Style.CellPadding.Left = cellMargin;
            pdfGrid.Style.CellPadding.Right = cellMargin;

            //Applying built-in style to the PDF grid
            pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent1);

            //Assign data source.
            pdfGrid.DataSource = data;

            pdfGrid.Style.Font = contentFont;

            //Draw PDF grid into the PDF page.
            pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

            MemoryStream memoryStream = new MemoryStream();

            // Save the PDF document.
            pdfDocument.Save(memoryStream);

            // Download the PDF document
            await SaveAs(docTitle, memoryStream.ToArray());

        }

        private async ValueTask<object> SaveAs(string filename, byte[] data)
        {
            var result = await js.InvokeAsync<object>(
            "saveAsFile",
            filename,
            Convert.ToBase64String(data));

            return result;
        }
    }

}
