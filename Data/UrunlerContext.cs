using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using enoca.Models;

namespace enoca.Data
{
    public class UrunlerContext : DbContext
    {
        public UrunlerContext (DbContextOptions<UrunlerContext> options)
            : base(options)
        {
        }

        public DbSet<enoca.Models.Urunler> Urunler { get; set; } = default!;
    }
}
