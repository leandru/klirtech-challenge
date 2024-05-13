using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Sales.Application.Dtos
{
    public record CartUpdatedItem(int ProductId, decimal Total, string AppliedPromotion);
}
