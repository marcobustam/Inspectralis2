﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Inspectral.Models;

namespace Inspectral.Pages.Informes
{
    public class CreateModel : PageModel
    {
        private readonly Inspectral.Models.InspectralContext _context;

        public CreateModel(Inspectral.Models.InspectralContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Informe NuevoInforme { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Informe.Add(NuevoInforme);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}