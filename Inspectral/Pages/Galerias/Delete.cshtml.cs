using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inspectral.Models;

namespace Inspectral.Pages.Galerias
{
    public class DeleteModel : PageModel
    {
        private readonly Inspectral.Models.InspectralContext _context;

        public DeleteModel(Inspectral.Models.InspectralContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Informe Informe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Informe = await _context.Informe.FirstOrDefaultAsync(m => m.InformeID == id);

            if (Informe == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Informe = await _context.Informe.FindAsync(id);

            if (Informe != null)
            {
                _context.Informe.Remove(Informe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
