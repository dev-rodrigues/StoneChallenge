using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stone.Domain.Entities;
using Stone.Domain.Interface.Repositories;
using Stone.Infrastructure.Repositories;
using Stone.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Test
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        private readonly IEmployee _service = EmployeeServiceLocator.GetInstance<EmployeeRepository>();

        private Employee CriaEmployeeFake()
        {
            return new Employee()
            {
                Nome = "fake",
                SobreNome = "fake",
                Cpf = "275.925.310-46",
                Admissao = DateTime.Now,
                SalarioBruto = (decimal) 9999.99,
                Setor = "TI",
            };
        }

        [TestMethod]
        public void Deve_GerarId_Quando_SalvarEmployee()
        {
            var employee = CriaEmployeeFake();
            var employee_salvo = _service.Criar(employee);
            Assert.IsNotNull(employee_salvo.Id);
        }

        [TestMethod]
        public void Deve_RetornarNome_Quando_SalvarEmplyee()
        {
            var employee = CriaEmployeeFake();
            var employee_salvo = _service.Criar(employee);
            Assert.AreEqual("fake", employee_salvo.Nome);
        }

        [TestMethod]
        public void Deve_VerificarNome_Quando_BuscarEmployee()
        {
            var employee = CriaEmployeeFake();
            var employee_salvo = _service.Criar(employee);
            var employee_buscado = _service.Ler(employee_salvo.Id);
            Assert.IsNotNull(employee_buscado.Nome);
        }

        [TestMethod]
        public void Deve_VerificarDataAdmissao_QuandoCriado()
        {
            var employee = CriaEmployeeFake();
            var employee_salvo = _service.Criar(employee);
            var employee_buscado = _service.Ler(employee_salvo.Id);
            Assert.AreEqual(employee_salvo.Admissao, employee_buscado.Admissao);
        }

        [TestMethod]
        public void Deve_Testar_Service_Quando_ExecutarTeste()
        {
            Assert.IsNotNull(_service);
        }
    }
}
