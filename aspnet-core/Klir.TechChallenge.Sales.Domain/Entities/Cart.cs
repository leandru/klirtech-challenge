using System.Collections.Generic;

namespace Klir.TechChallenge.Sales.Domain.Entities
{
    public class Cart
    {
        public int Id { get; private set; }

        private List<CartItem> _itens;
        public IReadOnlyCollection<CartItem> Itens => _itens;
        public Cart(int id)
        {
            Id = id;
            _itens = new List<CartItem>();
        }

        public void AddItem(CartItem item)
        {
            var foundedItem = _itens.Find(i => i.ProductId == item.ProductId);

            if (foundedItem is null)
            {
                _itens.Add(item);
                return;
            }
            foundedItem.SetQuantity(item.Quantity+1);
        }

        public void RemoveItem(int ProductId)
        {
            var foundedItem = _itens.Find(i => i.ProductId == ProductId);

            if (foundedItem is not null)
                _itens.Remove(foundedItem);
        }

        public void SetQuantity(int productId, int quantity)
        {
            var foundedItem = _itens.Find(i => i.ProductId == productId);

            if (foundedItem is not null)
                foundedItem.SetQuantity(quantity);
        }

    }
}
