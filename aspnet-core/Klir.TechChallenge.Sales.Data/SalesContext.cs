using Klir.TechChallenge.Sales.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Klir.TechChallenge.Catalog.Data
{
    public class SalesContext : DbContext
    {
        public DbSet<ProductPromotion> ProductsPromotions { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public SalesContext(DbContextOptions<SalesContext> options) : base(options)
        {      
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductPromotion>()
                .HasOne(pp => pp.Promotion)           
                .WithMany()                           
                .HasForeignKey(pp => pp.PromotionId);

            modelBuilder.Entity<Cart>()
                .HasMany(it => it.Items)
                .WithOne().HasForeignKey(it => it.CartId);

            modelBuilder.Entity<CartItem>()
                .HasOne(p => p.ProductPromotion)
                .WithMany()
                .HasForeignKey(p => p.ProductId);
        }
    }
}
