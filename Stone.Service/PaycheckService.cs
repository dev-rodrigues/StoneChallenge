using Stone.Domain.Entities;
using Stone.Domain.Interface.Repositories;
using Stone.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stone.Service
{
    public class PaycheckService
    {
        private Employee _employee { get; set; }
        private readonly IDiscount _inssRepository = EmployeeServiceLocator.GetInstance<InssRepository>();
        private readonly IDiscount _iprfRepository = EmployeeServiceLocator.GetInstance<IrpfRepository>();

        public PaycheckService(Employee employee)
        {
            _employee = employee;
        }

        public Paymentslip GetPaySlip()
        {
            var discounts = new List<Discount>();

            GetDiscountInss(discounts);
            GetDiscountIrpf(discounts);
            GetDiscountHealthPlan(discounts);
            GetDiscountDentalPlan(discounts);
            GetDiscountTransport(discounts);
            GetDiscountFgts(discounts);

            return new Paymentslip()
            {
                Discounts = discounts,
                Employee = new EmployeeDTO()
                {
                    Nome = _employee.Nome,
                    SobreNome = _employee.SobreNome,
                    Cpf = _employee.Cpf,
                    Setor = _employee.Setor,
                    SalarioBruto = _employee.SalarioBruto,
                    Admissao = _employee.Admissao
                }
            };
        }

        public void GetDiscountInss(List<Discount> discounts)
        {
            discounts.Add(_inssRepository.GetDiscount(_employee.SalarioBruto));
        }

        public void GetDiscountIrpf(List<Discount> discounts)
        {
            discounts.Add(_iprfRepository.GetDiscount(_employee.SalarioBruto));
        }

        public void GetDiscountHealthPlan(List<Discount> discounts)
        {
            var planoDeSaude = new Discount()
            {
                TypeOfDiscount = "Plano de Saúde",
                ValueOfDiscount = _employee.PlanoSaude ? 10 : 0
            };
            discounts.Add(planoDeSaude);
        }

        public void GetDiscountDentalPlan(List<Discount> discounts)
        {
            var dental = new Discount()
            {
                TypeOfDiscount = "Plano de Dental",
                ValueOfDiscount = _employee.PlanoSaude ? 5 : 0,
            };
            discounts.Add(dental);
        }

        public void GetDiscountTransport(List<Discount> discounts)
        {
            var transporte = new Discount()
            {
                TypeOfDiscount = "Transporte",
                ValueOfDiscount = _employee.ValeTransporte ?
                    CalculeteDiscountService.CacluleTransport(_employee.SalarioBruto) : 0
            };
            discounts.Add(transporte);
        }

        public void GetDiscountFgts(List<Discount> discounts)
        {
            var fgts
                = new Discount()
                {
                    TypeOfDiscount = "FGTS",
                    ValueOfDiscount = CalculeteDiscountService.CacluleFGTS(_employee.SalarioBruto)

                };
            discounts.Add(fgts);
        }
    }
}
