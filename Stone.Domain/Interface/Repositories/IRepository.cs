using Stone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Domain.Interface.Repositories
{
    public interface IRepository<T, EntityId> where T : EntityBase<EntityId>
    {
        T Create(T entity);
        T Read(EntityId id);
    }
}
