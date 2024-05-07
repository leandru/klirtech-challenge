using System;

namespace Klir.TechChallenge.Core
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

    }
}
