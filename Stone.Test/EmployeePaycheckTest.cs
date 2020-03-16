using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stone.Domain.Entities;
using Stone.Domain.Interface.Repositories;
using Stone.Domain.Validation;
using Stone.Infrastructure.Repositories;
using Stone.Service;

namespace Stone.Test
{
    [TestClass]
    public class EmployeePaycheckTest
    {
        private readonly IEmployee _service = EmployeeServiceLocator.GetInstance<EmployeeRepository>();

        [TestMethod]
        public void Deve_GerarContraCheque()
        {
            var funcionario = CriaEmployeeFake();
            var funcionario_salvo = _service.Create(funcionario);
            var _serviceSlip = new PaycheckService(funcionario_salvo);
            var paycheck = _serviceSlip.GetPaySlip();
            Assert.IsNotNull(paycheck);
        }

        [TestMethod]
        public void Deve_VerificarNomeFuncionario_QuandoGerar_ContraCheque()
        {
            var funcionario = CriaEmployeeFake();
            var funcionario_salvo = _service.Create(funcionario);

            var servicePayCheck = new PaycheckService(funcionario_salvo);
            var paycheck = servicePayCheck.GetPaySlip();

            Assert.AreEqual(paycheck.Employee.Nome, funcionario_salvo.Nome);
        }

        [TestMethod]
        public void Deve_VerificarSalarioFuncionario_QuandoGerar_ContraCheque()
        {
            var funcionario = CriaEmployeeFake();
            var funcionario_salvo = _service.Create(funcionario);

            var servicePayCheck = new PaycheckService(funcionario_salvo);
            var paycheck = servicePayCheck.GetPaySlip();
            Assert.AreEqual(paycheck.Employee.SalarioBruto, funcionario_salvo.SalarioBruto);
        }
           
        private Employee CriaEmployeeFake()
        {
            return new Employee()
            {
                Nome = "fake",
                SobreNome = "fake",
                Cpf = "275.925.310-46",
                Admissao = DateTime.Now,
                SalarioBruto = (decimal)9999.99,
                Setor = "TI",
            };
        }
    }
}
