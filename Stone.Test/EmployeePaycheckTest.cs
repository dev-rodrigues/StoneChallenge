using System;
using System.Collections.Generic;
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
            var paycheck = GeraContraChequeFuncionarioPobre();
            Assert.IsNotNull(paycheck);
        }

        [TestMethod]
        public void Deve_VerificarNomeFuncionario_QuandoGerar_ContraCheque()
        {
            var funcionario = CriaEmployeeFakePobre();
            var funcionario_salvo = _service.Criar(funcionario);

            var servicePayCheck = new PaycheckService(funcionario_salvo);
            var paycheck = servicePayCheck.GetContraCheque();

            Assert.AreEqual(paycheck.Employee.Nome, funcionario_salvo.Nome);
        }

        [TestMethod]
        public void Deve_VerificarSalarioFuncionario_QuandoGerar_ContraCheque()
        {
            var funcionario = CriaEmployeeFakePobre();
            var funcionario_salvo = _service.Criar(funcionario);

            var servicePayCheck = new PaycheckService(funcionario_salvo);
            var paycheck = servicePayCheck.GetContraCheque();

            Assert.AreEqual(paycheck.Employee.SalarioBruto, funcionario_salvo.SalarioBruto);
        }

        [TestMethod]
        public void Deve_VerificarIRPF_ZeradoDoFuncionario_QuandoGerar_ContraCheque()
        {
            var paycheck = GeraContraChequeFuncionarioPobre();
            var irpf = paycheck.Lancamentos.Find(x => x.TipoDeDesconto.Equals("IRPF"));
            Assert.AreEqual(irpf.ValorDesconto, 0);
        }

        [TestMethod]
        public void Deve_Verificar_Se_ExisteDesconto_Transporte_ContraCheque()
        {
            var contraCheque = GeraContraChequeFuncionarioRico();
            var DescontoTransporte = contraCheque.Lancamentos.Find(x => x.TipoDeDesconto.Equals("Transporte"));
            Assert.IsNotNull(DescontoTransporte);
        }

        [TestMethod]
        public void Deve_Verificar_Se_ExisteDesconto_PlanoDental_ContraCheque()
        {
            var contraCheque = GeraContraChequeFuncionarioRico();
            var DescontoDental = contraCheque.Lancamentos.Find(x => x.TipoDeDesconto.Equals("Plano de Dental"));
            Assert.IsNotNull(DescontoDental);
        }

        [TestMethod]
        public void Deve_Verificar_Se_ExisteDesconto_PlanoSaude_ContraCheque()
        {
            var contraCheque = GeraContraChequeFuncionarioRico();
            var DescontoSaude = contraCheque.Lancamentos.Find(x => x.TipoDeDesconto.Equals("Plano de Saúde"));
            Assert.IsNotNull(DescontoSaude);
        }

        [TestMethod]
        public void Deve_VerificarAlicotaMaxima_QuandoGerar_ContraCheque()
        {
            var funcionario = CriaEmployeeFakePobre();
            var funcionario_salvo = _service.Criar(funcionario);

            var servicePayCheck = new PaycheckService(funcionario_salvo);
            var paycheck = servicePayCheck.GetContraCheque();
        }

        private Paymentslip GeraContraChequeFuncionarioPobre()
        {
            var funcionario = CriaEmployeeFakePobre();
            var funcionario_salvo = _service.Criar(funcionario);
            var servicePayCheck = new PaycheckService(funcionario_salvo);
            return servicePayCheck.GetContraCheque();
        }

        private Paymentslip GeraContraChequeFuncionarioRico()
        {
            var funcionario = CriaEmployeeFakePobre();
            var funcionario_salvo = _service.Criar(funcionario);
            var servicePayCheck = new PaycheckService(funcionario_salvo);
            return servicePayCheck.GetContraCheque();
        }

        private Employee CriaEmployeeFakePobre()
        {
            return new Employee()
            {
                Nome = "fake",
                SobreNome = "fake",
                Cpf = "275.925.310-46",
                Admissao = DateTime.Now,
                SalarioBruto = (decimal)1045.00,
                Setor = "TI",
            };
        }

        private Employee CriaEmployeeFakeRico()
        {
            return new Employee()
            {
                Nome = "fake",
                SobreNome = "fake",
                Cpf = "275.925.310-46",
                Admissao = DateTime.Now,
                SalarioBruto = (decimal)999999.99,
                Setor = "TI",
                PlanoDental = true,
                PlanoSaude = true,
                ValeTransporte = true
            };
        }
    }
}
