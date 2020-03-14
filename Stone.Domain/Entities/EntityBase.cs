using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Domain.Entities
{
    public abstract class EntityBase<EntityId>
    {
        public EntityId Id { get; set; }
    }
}
