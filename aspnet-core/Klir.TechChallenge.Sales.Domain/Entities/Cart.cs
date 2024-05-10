using System;
using System.Collections.Generic;
using System.Linq;

namespace Klir.TechChallenge.Sales.Domain.Entities
{
    public class Cart
    {
        public Guid Id { get; private set; }

        private List<CartItem> _items;
        public IReadOnlyCollection<CartItem> Items => _items;
        public Cart(Guid id)
        {
            Id = id;
            _items = new List<CartItem>();
        }

        public void AddItem(CartItem item)
        {
            item.AssociateTo(Id);
            _items.Add(item);            
        }

        public bool RemoveItem(CartItem item)
        {
            return  _items.Remove(item);
        }

        public void SetQuantity(int productId, int quantity)
        {
            var foundedItem = _items.Find(i => i.ProductId == productId);

            if (foundedItem is not null)
                foundedItem.SetQuantity(quantity);
        }

        public bool Contains(int productId)
        {
            return _items.Any( it => it.ProductId == productId);
        }

        public decimal Total()
        {
            return _items.Sum(it => it.ItemTotalPriceWithDiscount());
        }
    }
}
