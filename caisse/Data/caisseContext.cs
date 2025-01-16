using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using caisse.Models;

namespace caisse.Data
{
    public class caisseContext : DbContext
    {
        public caisseContext (DbContextOptions<caisseContext> options)
            : base(options)
        {
        }

        public DbSet<caisse.Models.CategorieModel> CategorieModel { get; set; } = default!;
        public DbSet<caisse.Models.ProduitModel> ProduitModel { get; set; } = default!;
    }
}
