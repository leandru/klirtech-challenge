using Klir.TechChallenge.Sales.Application.ViewModels;

namespace Klir.TechChallenge.Sales.Application
{
    public interface ICheckoutService
    {
        CartCheckoutResult CalculateTotal();
    }
}
