using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inspectral.Models;

namespace Inspectral.Pages.Galerias
{
    public class EditModel : PageModel
    {
        private readonly Inspectral.Models.InspectralContext _context;

        public EditModel(Inspectral.Models.InspectralContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Informe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformeExists(Informe.InformeID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InformeExists(int id)
        {
            return _context.Informe.Any(e => e.InformeID == id);
        }
    }
}
