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
    public class DeleteModel : PageModel
    {
        private readonly Inspectral.Models.InspectralContext _context;

        public DeleteModel(Inspectral.Models.InspectralContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Individualizacion Individualizacion { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Individualizacion = await _context.Individualizacion.FirstOrDefaultAsync(m => m.IndividualizacionID == id);

            if (Individualizacion == null)
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

            Individualizacion = await _context.Individualizacion.FindAsync(id);

            if (Individualizacion != null)
            {
                _context.Individualizacion.Remove(Individualizacion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
