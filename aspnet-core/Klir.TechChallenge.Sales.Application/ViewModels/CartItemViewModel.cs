namespace Klir.TechChallenge.Sales.Application.ViewModels
{
    public record CartItemViewModel(Guid cartId, int ProductId, string ProductName, decimal Price, int Quantity );
}
