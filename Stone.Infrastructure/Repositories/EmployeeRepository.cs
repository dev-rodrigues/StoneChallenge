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

        public EmployeeRepository()
        {
            _db = new EFDataContext();    
        }

        public bool Create(Employee entity)
        {
            var retorno = false;
            try
            {
                //_db.Add(entity);
                retorno = true;
            }
            catch (Exception e)
            {
                // faz alguma coisa
            }
            return retorno;
        }

        public Employee Read(int id)
        {
            return _db.Employees.Find(id);
        }
    }
}
