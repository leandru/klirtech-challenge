using Klir.TechChallenge.Core;

namespace Klir.TechChallenge.Catalog.Domain
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

    }
}
