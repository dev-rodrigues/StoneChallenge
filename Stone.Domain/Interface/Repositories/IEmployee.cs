using Stone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Domain.Interface.Repositories
{
    public interface IEmployee : IRepository<Employee, int>
    {
    }
}
