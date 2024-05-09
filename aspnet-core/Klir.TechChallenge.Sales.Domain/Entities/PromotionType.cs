using System.Collections;
using System.Collections.Generic;

namespace Klir.TechChallenge.Sales.Domain.Entities
{
    public abstract class PromotionType
    {
        protected PromotionType(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }

        public abstract decimal CalculateFinalPrice(int quantity, decimal price, int requiredQuantity, int? freeQuantity, decimal? targetPrice);

        /* EF Relations */
        public virtual IEnumerable<Promotion> Promotions { get; set; }
    }
}
