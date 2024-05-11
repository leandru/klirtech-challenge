namespace Klir.TechChallenge.Sales.Application.Dtos
{
    public record CartAddItemViewModel(Guid cartId, int ProductId, string ProductName, decimal Price, int Quantity );

    public record CartItemViewModelResult(int ProductId, string ProductName, decimal Price, int Quantity, decimal Total);
}
