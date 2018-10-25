using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Inspectral.Models;

namespace Inspectral.Pages.Secciones
{
    public class CreateModel : PageModel
    {
        private readonly InspectralContext _context;

        public CreateModel(InspectralContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Seccion Seccion { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Seccion.Add(Seccion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}