using Klir.TechChallenge.Core;

namespace Klir.TechChallenge.Catalog.Domain
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
       
        public IPromotion PromotionStrategy { get; }

        public Product(string name, decimal price, IPromotion promotionStrategy = null)
        {
            Name = name;
            Price = price;
            PromotionStrategy = promotionStrategy;
        }

        public decimal ApplyPromotion(int quantity)
        {
            if (PromotionStrategy != null)
            {
                return PromotionStrategy.Apply(Price, quantity);
            }
            return Price * quantity;
        }
    }
}
