namespace Klir.TechChallenge.Sales.Application.ViewModels
{
    public record CartCheckoutItem(int ProductId, string ProductName, int Quantity, decimal Price, decimal TotalItem, string PromotionApplied);
}
