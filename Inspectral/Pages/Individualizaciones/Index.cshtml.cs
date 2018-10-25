﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inspectral.Models;

namespace Inspectral.Pages.Individualizaciones
{
    public class IndexModel : PageModel
    {
        private readonly Inspectral.Models.InspectralContext _context;

        public IndexModel(Inspectral.Models.InspectralContext context)
        {
            _context = context;
        }

        public IList<Individualizacion> Individualizacion { get;set; }

        public async Task OnGetAsync()
        {
            Individualizacion = await _context.Individualizacion.ToListAsync();
        }
    }
}
