using Stone.Domain.Entities;
using Stone.Domain.Interface.Repositories;
using Stone.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Service
{
    public class EmployeeService
    {
        private readonly IEmployee _service = EmployeeServiceLocator.GetInstance<EmployeeRepository>();

        public EmployeeService()
        {            
        }

        public Employee AddEmployee(Employee employee)
        {
            Console.WriteLine("---");
            return _service.Create(employee);
        }

        public Employee GetEmployeeById(int id)
        {
            Console.WriteLine("---");
            return _service.Read(id);
        }
    }
}
