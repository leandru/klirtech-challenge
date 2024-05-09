using Klir.TechChallenge.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Klir.TechChallenge.Catalog.Data
{
    public class SalesContext : DbContext
    {
        public DbSet<ProductPromotion> ProductsPromotions { get; set; }

        public SalesContext(DbContextOptions<SalesContext> options) : base(options)
        {      
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductPromotion>()
                .HasOne(pp => pp.Promotion)           
                .WithMany()                           
                .HasForeignKey(pp => pp.PromotionId); 
        }
    }
}
