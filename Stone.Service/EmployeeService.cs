using Stone.Domain.Entities;
using Stone.Domain.Interface.Repositories;
using Stone.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Service
{
    public class EmployeeService
    {
        private readonly IEmployee _service = EmployeeServiceLocator.GetInstance<EmployeeRepository>();

        public EmployeeService()
        {            
        }

        public void AddEmployee(Employee employee)
        {
            //_employeeRepository.Create(employee);
        }

        public Employee GetEmployeeById(int id)
        {
            return _service.Read(id);
        }
    }
}
