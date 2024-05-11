using Klir.TechChallenge.Sales.Application.Dtos;
using Klir.TechChallenge.Sales.Domain.Entities;

namespace Klir.TechChallenge.Sales.Application
{
    public interface ICartAppService
    {
        Task<Cart> GetAsync(Guid cartId);

        Task<bool> Exists(Guid cartId);

        Task AddItem( CartAddItemViewModel item);

        Task RemoveItem(CartItem item);

        Task UpdateItem(CartItem item);

        Task<CartCheckoutResult> CalculateTotal(Guid cartId);
    }
}
