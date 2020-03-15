using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stone.Domain.Entities;
using Stone.Domain.Validation;

namespace Stone.Test
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void Deve_RetornarEmployee_QuandoCriado()
        {
            var employee = CriaEmployee();
            Assert.IsNotNull(employee);
        }

        [TestMethod]
        public void Deve_VerificarSeExisteNome_Quando_Criado()
        {
            var employee = CriaEmployee();
            employee.Nome = "Stone";
            Assert.AreEqual("Stone", employee.Nome);
        }

        [TestMethod]
        public void Deve_VerificarSeExisteSobreNome_Quando_Criado()
        {
            var employee = CriaEmployee();
            employee.SobreNome = "Stone";
            Assert.AreEqual("Stone", employee.SobreNome);
        }

        [TestMethod]
        public void Deve_VerificarSeExisteCpf_Quando_Criado()
        {
            var employee = CriaEmployee();
            employee.Cpf = "000.000.000-00";
            Assert.AreEqual("000.000.000-00", employee.Cpf);
        }

        [TestMethod]
        public void Deve_VerificarSeCpfEhValido_Quando_Criado()
        {
            var employee = CriaEmployee();
            employee.Cpf = "275.925.310-46";
            var valid = new ValidateCpf().IsValid(employee.Cpf);
            Assert.IsTrue(valid);
        }

        public void Deve_VerificarSeExisteSetor_Quando_Criado()
        {
            var employee = CriaEmployee();
            employee.Setor = "TI";
            Assert.AreEqual("TI", employee.Setor);
        }
        

        private Employee CriaEmployee()
        {
            return new Employee();
        }
    }
}
