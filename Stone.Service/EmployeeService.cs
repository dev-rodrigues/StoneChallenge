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

        /// <summary>
        /// Responsável por persistir um funcionário
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns>
        /// Funcionário persistido
        /// </returns>
        public Employee AddFuncionario(Employee funcionario)
        {
            return _servico.Criar(funcionario);
        }

        /// <summary>
        /// Responsável por buscar um funcionário por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Employee
        /// </returns>
        public Employee GetFuncionarioPorId(int id)
        {
            return _servico.Ler(id);
        }
    }
}
