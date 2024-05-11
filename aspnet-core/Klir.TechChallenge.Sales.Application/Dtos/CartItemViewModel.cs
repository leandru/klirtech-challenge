namespace Klir.TechChallenge.Sales.Application.Dtos
{
    public record CartItemViewModel(Guid cartId, int ProductId, string ProductName, decimal Price, int Quantity );
}
