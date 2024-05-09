using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Sales.Application.ViewModels
{
    public record CartItemViewModel(int ProductId, decimal ProductPrice, int Quantity);
}
