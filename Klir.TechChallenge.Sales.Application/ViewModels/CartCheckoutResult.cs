namespace Klir.TechChallenge.Sales.Application.ViewModels
{
    public record CartCheckoutResult( IEnumerable<CartCheckoutItem> Items, decimal Total);

}
