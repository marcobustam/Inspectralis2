using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inspectral.Models;

namespace Inspectral.Models
{
    public class InspectralContext : DbContext
    {
        public InspectralContext (DbContextOptions<InspectralContext> options)
            : base(options)
        {
        }

        public DbSet<Inspectral.Models.Informe> Informe { get; set; }

        public DbSet<Inspectral.Models.Seccion> Seccion { get; set; }

        public DbSet<Inspectral.Models.Individualizacion> Individualizacion { get; set; }
    }
}
