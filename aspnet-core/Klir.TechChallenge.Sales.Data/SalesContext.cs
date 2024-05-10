using Klir.TechChallenge.Sales.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Klir.TechChallenge.Sales.Data
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
            modelBuilder.Entity<PromotionType>()
             .HasDiscriminator<string>( "promotion_type" )
             .HasValue<BuyXGetYFreePromotionType>( nameof(BuyXGetYFreePromotionType))
             .HasValue<BuyXGetYPricePromotionType>( nameof(BuyXGetYPricePromotionType));
            modelBuilder.Entity<PromotionType>().HasKey( p => p.Id );

            modelBuilder.Entity<Promotion>().HasKey(p => p.Id);
            modelBuilder.Entity<Promotion>()
                .HasOne(pp => pp.PromotionType)
                .WithMany()
                .HasForeignKey(pp => pp.PromotionTypeId);

            modelBuilder.Entity<ProductPromotion>().HasKey(p => p.ProductId);
            modelBuilder.Entity<ProductPromotion>()
                .HasOne(pp => pp.Promotion)           
                .WithMany()                           
                .HasForeignKey(pp => pp.PromotionId);

            modelBuilder.Entity<Cart>().HasKey(c => c.Id);
            modelBuilder.Entity<Cart>()
                .HasMany(it => it.Items)
                .WithOne().HasForeignKey(it => it.CartId);

            modelBuilder.Entity<CartItem>().HasKey(it => it.ProductId);
            modelBuilder.Entity<CartItem>()
                .HasOne(p => p.ProductPromotion)
                .WithMany()
                .HasForeignKey(p => p.ProductId);
        }
    }
}
