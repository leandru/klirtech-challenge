using Klir.TechChallenge.Catalog.Domain;
using Microsoft.EntityFrameworkCore;

namespace Klir.TechChallenge.Catalog.Data
{
    public class CatalogContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {      
        }
   
    }
}
