using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inspectral.Models;

namespace Inspectral.Pages.Secciones
{
    public class EditModel : PageModel
    {
        private readonly Inspectral.Models.InspectralContext _context;

        public EditModel(Inspectral.Models.InspectralContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Seccion EstaSeccion { get; set; }
        /*
                public async Task<IActionResult> OnGetAsync(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    EstaSeccion = await _context.EstaSeccion.FirstOrDefaultAsync(m => m.SeccionID == id);

                    if (EstaSeccion == null)
                    {
                        return NotFound();
                    }
                    return Page();
                }
                */
        public async Task<IActionResult> OnGetAsync(int? emid, int? inid, int? seid)
        {
            if (seid == null)
            {
                return NotFound();
            }

            EstaSeccion = await _context.Seccion.FirstOrDefaultAsync(m => m.SeccionID == seid);

            if (EstaSeccion == null)
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

            _context.Attach(EstaSeccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeccionExists(EstaSeccion.SeccionID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/informes/Details", new { emid=0, inid=EstaSeccion.InformeID });
        }

        private bool SeccionExists(int id)
        {
            return _context.Seccion.Any(e => e.SeccionID == id);
        }
    }
}
