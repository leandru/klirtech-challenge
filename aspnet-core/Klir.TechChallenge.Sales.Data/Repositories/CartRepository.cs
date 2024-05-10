using Klir.TechChallenge.Catalog.Data;
using Klir.TechChallenge.Sales.Domain.Entities;
using Klir.TechChallenge.Sales.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Klir.TechChallenge.Sales.Data.Repositories
{
    public class CartRepository:ICartRepository
    {
        private readonly SalesContext _salesContext;

        public CartRepository(SalesContext salexContext)
        {
            _salesContext = salexContext;
        }

        public async Task<Cart> CreateAsync(Cart cart)
        {
            var result = await _salesContext.Carts.AddAsync(cart);

            return result.Entity;
        }

        public async Task AddItemAsync(CartItem item)
        {
            await _salesContext.CartItems.AddAsync(item);
        }

        public async Task<Cart?> GetAsync(Guid cartId)
        {
            return await _salesContext.Carts
                .Include( c => c.Items)
                .ThenInclude( it => it.ProductPromotion)
                .FirstOrDefaultAsync( c => c.Id == cartId);
        }

        public void RemoveItem(CartItem item)
        {
            _salesContext.CartItems.Remove(item);
        }

        public void UpdateItem(CartItem item)
        {
            _salesContext.CartItems.Update(item);
        }

        public async Task CommitAsync()
        {
            await _salesContext.SaveChangesAsync();
        }

        public void Update(Cart cart)
        {
            _salesContext.Carts.Update(cart);
        }

    }
}
