namespace Klir.TechChallenge.Sales.Application.Dtos
{
    public record CartCheckoutItem(int ProductId, string ProductName, int Quantity, decimal Price, decimal Total, string PromotionApplied);
}
