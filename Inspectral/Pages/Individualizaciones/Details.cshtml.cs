using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inspectral.Models;

namespace Inspectral.Pages.Individualizaciones
{
    public class DetailsModel : PageModel
    {
        private readonly Inspectral.Models.InspectralContext _context;

        public DetailsModel(Inspectral.Models.InspectralContext context)
        {
            _context = context;
        }

        public Individualizacion Individualizacion { get; set; }

        public async Task<IActionResult> OnGetAsync(int? emid, int? sesid)
        {
            if (sesid == null)
            {
                return NotFound();
            }

            Individualizacion = await _context.Individualizacion.FirstOrDefaultAsync(m => m.IndividualizacionID == sesid);

            if (Individualizacion == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
