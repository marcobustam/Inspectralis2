using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Inspectral.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Inspectral.Pages.Informes
{
    public class ViewPdfModel : PageModel
    {
        private readonly Inspectral.Models.InspectralContext _context;
        private readonly IHostingEnvironment _environment;

        public ViewPdfModel(Inspectral.Models.InspectralContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> OnGetAsync(int? emid, int? inid)
        {
            HttpClient hc = new HttpClient();
            var url = $"http://localhost:52169/Pdfs/HtmlReport?emid=" + (int) emid + "&inid=" + (int) inid;
            var htmlContent = await hc.GetStringAsync(url);
            var file = Html2Pdf.ExportarPDF(htmlContent);
            string FilePath = "";
            try
            {
                FilePath = Path.Combine(_environment.ContentRootPath, "Data", "Uploads");
                var filepath = Path.Combine(FilePath, file);
                if (System.IO.File.Exists(filepath))
                {
                    byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
                    return File(fileBytes, "application/x-msdownload", "Informe.pdf");
                }
                else
                {
                    return Redirect("/Informes/Details?emid=" + emid + "&inid=" + inid);
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}