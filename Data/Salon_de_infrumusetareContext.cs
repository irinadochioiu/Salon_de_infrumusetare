#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Salon_de_infrumusetare.Models;

namespace Salon_de_infrumusetare.Data
{
    public class Salon_de_infrumusetareContext : DbContext
    {
        public Salon_de_infrumusetareContext (DbContextOptions<Salon_de_infrumusetareContext> options)
            : base(options)
        {
        }

        public DbSet<Salon_de_infrumusetare.Models.serviciu> serviciu { get; set; }

        public DbSet<Salon_de_infrumusetare.Models.Publisher> Publisher { get; set; }

        public DbSet<Salon_de_infrumusetare.Models.Category> Category { get; set; }
    }
}
