namespace Klir.TechChallenge.Sales.Domain.Entities
{
    public class ProductPromotion
    {
        public int ProductId { get; set; }
        public int? PromotionId { get; set; }
        public virtual Promotion Promotion { get; set; }
    }
}
