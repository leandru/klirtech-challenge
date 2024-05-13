using System;

namespace Klir.TechChallenge.Sales.Domain.Entities
{
    public class CartItem
    {
        public Guid CartId { get; set; }

        public int ProductId { get; private set; }

        public string ProductName { get; private set; }

        public decimal Price { get; private set; }

        public int Quantity { get; private set; }

        public int? ProductPromotionId { get; set; }

        public CartItem(int productId, string productName, decimal price, int quantity, int? productPromotionId)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            ProductPromotionId = productPromotionId;
        }

        public void AssociateTo(Guid cartId)
        {
            CartId = cartId;
        }

        public decimal Total()
        {
            return Quantity * Price;
        }

        public decimal TotalWithDiscount()
        {
            if ( ProductPromotion is ProductPromotion productPromotion)
            {
                return productPromotion.Promotion.GetPriceWithDiscount(Quantity, Price);
            }

            return Total();
        }

        public string PromotionName()
        {
            return ProductPromotion?.Promotion?.Name;
        }

        public void SetQuantity( int amount )
        {
            Quantity = amount;
        } 

        public virtual ProductPromotion ProductPromotion { get; set; }

    }
}
