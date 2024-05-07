using Klir.TechChallenge.Core;
using System.Collections.Generic;

namespace Klir.TechChallenge.Cart.Domain
{
    public class ShopCart: Entity
    {
        private List<ShopCartItem> _itens;
        public IReadOnlyCollection<ShopCartItem> Itens => _itens;
        public ShopCart()
        {
            this._itens = new List<ShopCartItem>();
        }

        public void AddItem(ShopCartItem item)
        {
            var foundedItem = _itens.Find(i => i.ProductId == item.ProductId);

            if (foundedItem is null)
            {
                _itens.Add(item);
                return;
            }
            foundedItem.Quantity++;
        }

        public void RemoveItem(ShopCartItem item)
        {
            var foundedItem = _itens.Find(i => i.ProductId == item.ProductId);

            if (foundedItem != null)
            {
                _itens.Remove(foundedItem);
            }
        }
    }
}
