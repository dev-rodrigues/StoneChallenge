using Stone.Domain.Entities;
using Stone.Domain.Interface.Repositories;
using Stone.Infrastructure.DataContextLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployee
    {

        private readonly EFDataContext _db;

        public EmployeeRepository(EFDataContext db)
        {
            _db = db;
        }

        public void Create(Employee entity)
        {
            _db.Add(entity);
        }

        public Employee Read(int id)
        {
            return _db.Employees.Find(id);
        }
    }
}
