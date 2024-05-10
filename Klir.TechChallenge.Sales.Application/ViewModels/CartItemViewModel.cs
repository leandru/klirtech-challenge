namespace Klir.TechChallenge.Sales.Application.ViewModels
{
    public record CartItemViewModel(Guid CartId, int ProductId, string ProductName, decimal Price, int Quantity );
}
