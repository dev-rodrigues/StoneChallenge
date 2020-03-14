using Stone.Domain.Entities;
using Stone.Domain.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Service
{
    public class EmployeeService
    {
        private readonly IEmployee _employeeRepository;

        public EmployeeService(IEmployee employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void AddEmployee(Employee employee)
        {
            _employeeRepository.Create(employee);
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeRepository.Read(id);
        }
    }
}
