using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inspectral.Models;

namespace Inspectral.Pages.Informes
{
    public class DetailsModel : PageModel
    {
        private readonly InspectralContext _context;

        public DetailsModel(InspectralContext context)
        {
            _context = context;
        }

        public Informe EsteInforme { get; set; }
        [BindProperty]
        public Seccion NuevaSeccion { get; set; }

        public IList<Seccion> Secciones { get; set; }
        public async Task<IActionResult> OnGetAsync(int? emid, int? inid)
        {
            if (inid == null)
            {
                return NotFound();
            }
            else
            {
                //EsteInforme = await _context.Informe.FirstOrDefaultAsync(m => m.InformeID == id);

                EsteInforme = await _context.Informe.Include(inf=>inf.Secciones).FirstOrDefaultAsync(m => m.InformeID == inid);
                if (EsteInforme == null)
                {
                    return NotFound();
                }
                NuevaSeccion = new Seccion((int)inid);
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Seccion.Add(NuevaSeccion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Details", new { emid=0, inid = NuevaSeccion.InformeID });
        }
    }
}
