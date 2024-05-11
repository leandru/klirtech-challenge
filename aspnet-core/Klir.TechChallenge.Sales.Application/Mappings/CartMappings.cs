using Klir.TechChallenge.Sales.Application.Dtos;
using Klir.TechChallenge.Sales.Domain.Entities;

namespace Klir.TechChallenge.Sales.Application.Mappings
{
    public static class CartMappings
    {
        public static CartItemViewModelResult ToDto( this CartItem item)
        {
            return new CartItemViewModelResult(item.ProductId, item.ProductName, item.Price, item.Quantity, item.Total());
        }

        public static CartViewModel ToDto(this Cart cart)
        {
            return new CartViewModel(cart.Id, cart.Items.Select(it => it.ToDto()), cart.Total());
        }
    }
}
