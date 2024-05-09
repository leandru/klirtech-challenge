using Klir.TechChallenge.Catalog.Domain.Entities;

namespace Klir.TechChallenge.Sales.Domain.Entities
{
    public class CartItem
    {
        public int CartId { get; set; }

        public int ProductId { get; private set; }

        public decimal Price { get; private set; }

        public int Quantity { get; private set; }

        public decimal TotalItem()
        {
            return Quantity * Price;
        }

        public void SetQuantity( int amount )
        {
            Quantity = amount;
        } 

    public virtual ProductPromotion ProductPromotion { get; set; }

    }
}
