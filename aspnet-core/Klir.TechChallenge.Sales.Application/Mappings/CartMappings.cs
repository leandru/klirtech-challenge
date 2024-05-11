using Klir.TechChallenge.Sales.Application.Dtos;
using Klir.TechChallenge.Sales.Domain.Entities;

namespace Klir.TechChallenge.Sales.Application.Mappings
{
    public static class CartMappings
    {
        public static CartItemViewModel ToDto( this CartItem item)
        {
            return new CartItemViewModel(item.CartId, item.ProductId, item.ProductName, item.Price, item.Quantity);
        }

        //public static CartViewModel ToDto(this Cart item)
        //{
        //    //var 
        //    //return new CartItemViewModel(item.CartId, item.ProductId, item.ProductName, item.Price, item.Quantity);
        //}
    }
}
