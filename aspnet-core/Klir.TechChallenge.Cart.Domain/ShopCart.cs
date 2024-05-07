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

        }

        public void RemoveItem(ShopCartItem item)
        { 

        }
    }
}
