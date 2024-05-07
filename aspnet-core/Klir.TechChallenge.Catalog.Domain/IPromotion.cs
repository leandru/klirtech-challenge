using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Catalog.Domain
{
    public interface IPromotion
    {
        decimal Apply(decimal price, int quantity);
    }
}
