using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Inspectral.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Inspectral.Pages.Informes
{
    public class ViewPdfModel : PageModel
    {
        private readonly Inspectral.Models.InspectralContext _context;

        public ViewPdfModel(Inspectral.Models.InspectralContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            HttpClient hc = new HttpClient();
            var htmlContent = await hc.GetStringAsync($"http://localhost:52169/Pdfs/HtmlReport?emid=0&inid=2");
            Html2Pdf.ExportarPDF(htmlContent);
            return Page();
        }
    }
}