using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Catalog.Domain
{
    public interface IPricingCalculatorService
    {
        decimal CalculateTotal(Product product, int quantity, IPromotion promotionStrategy = null);
    }
}
