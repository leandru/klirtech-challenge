using Klir.TechChallenge.Core;

namespace Klir.TechChallenge.Cart.Domain
{
    public class ShopCartItem : Entity
    {
        public int ProductId { get; set; }  

        public int Quantity { get; set; }   

    }
}
