using Klir.TechChallenge.Sales.Application.ViewModels;

namespace Klir.TechChallenge.Sales.Application
{
    public interface ICartService
    {
        Task AddItem(CartItemViewModel item);

        Task RemoveItem(CartItemViewModel item);

       // Task<CartCheckoutResult> CalculateTotal(Guid cartId);
    }
}
