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
    public class IndexModel : PageModel
    {
        private readonly Inspectral.Models.InspectralContext _context;

        public IndexModel(Inspectral.Models.InspectralContext context)
        {
            _context = context;
        }

        public IList<Seccion> Seccion { get;set; }

        public async Task OnGetAsync()
        {
            Seccion = await _context.Seccion.ToListAsync();
        }
    }
}
