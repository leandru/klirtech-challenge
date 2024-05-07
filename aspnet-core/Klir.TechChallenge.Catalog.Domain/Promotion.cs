using Klir.TechChallenge.Core;

namespace Klir.TechChallenge.Catalog.Domain
{
    public class Promotion: Entity
    {
        public string Name { get; private set; }
        public string Description { get; set; }
    }
}
