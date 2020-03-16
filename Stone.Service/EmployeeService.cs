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
        public readonly IEmployee _servico = EmployeeServiceLocator.GetInstance<EmployeeRepository>();

        public EmployeeService()
        {            
        }

        public Employee AddFuncionario(Employee funcionario)
        {
            return _servico.Criar(funcionario);
        }

        public Employee GetFuncionarioPorId(int id)
        {
            return _servico.Ler(id);
        }
    }
}
