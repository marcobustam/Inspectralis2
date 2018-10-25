using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inspectral.Models;

namespace Inspectral.Pages.Secciones
{
    public class DeleteModel : PageModel
    {
        private readonly Inspectral.Models.InspectralContext _context;

        public DeleteModel(Inspectral.Models.InspectralContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Seccion Seccion { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Seccion = await _context.Seccion.FirstOrDefaultAsync(m => m.SeccionID == id);

            if (Seccion == null)
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

            Seccion = await _context.Seccion.FindAsync(id);

            if (Seccion != null)
            {
                _context.Seccion.Remove(Seccion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
