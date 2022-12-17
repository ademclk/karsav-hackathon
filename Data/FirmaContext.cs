using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using enoca.Models;

namespace enoca.Data
{
    public class FirmaContext : DbContext
    {
        public FirmaContext (DbContextOptions<FirmaContext> options)
            : base(options)
        {
        }

        public DbSet<enoca.Models.Firma> Firma { get; set; } = default!;
    }
}
