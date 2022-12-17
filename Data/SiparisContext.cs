using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using enoca.Models;

namespace enoca.Data
{
    public class SiparisContext : DbContext
    {
        public SiparisContext (DbContextOptions<SiparisContext> options)
            : base(options)
        {
        }

        public DbSet<enoca.Models.Siparis> Siparis { get; set; } = default!;
    }
}
