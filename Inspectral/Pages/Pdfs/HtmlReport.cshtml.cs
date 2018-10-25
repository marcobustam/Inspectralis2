using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inspectral.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Inspectral.Pages.Pdfs
{
    public class HtmlReportModel : PageModel
    {
        private readonly Inspectral.Models.InspectralContext _context;
        public HtmlReportModel(Inspectral.Models.InspectralContext context)
        {
            _context = context;
        }
        public Informe HtmlInforme { get; set; }
        public async Task<IActionResult> OnGetAsync(int? emid, int? inid )
        {
            HtmlInforme = await _context.Informe.Include(info=> info.Individualizacion).Include(infi=>infi.Secciones).Where(inf=>inf.InformeID == inid).FirstOrDefaultAsync();
            return Page();
        }
    }
}