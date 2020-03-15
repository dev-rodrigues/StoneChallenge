using Stone.Domain.Entities;
using Stone.Domain.Interface.Repositories;
using Stone.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            GetDiscounts(discounts);
            
            var paySlip = new Paymentslip()
            {
                Lancamentos = discounts,
                TotalDesconto = GetDiscount(discounts),

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

            paySlip.Referencia = MonthService.GetMonth(new DateTime().Month);
            paySlip.SalarioLiquido = GetNetPay(paySlip.Employee.SalarioBruto, paySlip.TotalDesconto);

            return paySlip;
        }

        public void GetDiscounts(List<Discount> discounts)
        {
            addDiscountInss(discounts);
            addDiscountIrpf(discounts);
            addDiscountHealthPlan(discounts);
            addDiscountDentalPlan(discounts);
            addDiscountTransport(discounts);
            addDiscountFgts(discounts);
        }

        public void addDiscountInss(List<Discount> discounts)
        {
            discounts.Add(_inssRepository.GetDiscount(_employee.SalarioBruto));
        }

        public void addDiscountIrpf(List<Discount> discounts)
        {
            discounts.Add(_iprfRepository.GetDiscount(_employee.SalarioBruto));
        }

        public void addDiscountHealthPlan(List<Discount> discounts)
        {
            var planoDeSaude = new Discount()
            {
                TypeOfDiscount = "Plano de Saúde",
                ValueOfDiscount = _employee.PlanoSaude ? 10 : 0
            };
            discounts.Add(planoDeSaude);
        }

        public void addDiscountDentalPlan(List<Discount> discounts)
        {
            var dental = new Discount()
            {
                TypeOfDiscount = "Plano de Dental",
                ValueOfDiscount = _employee.PlanoSaude ? 5 : 0,
            };
            discounts.Add(dental);
        }

        public void addDiscountTransport(List<Discount> discounts)
        {
            var transporte = new Discount()
            {
                TypeOfDiscount = "Transporte",
                ValueOfDiscount = _employee.ValeTransporte ?
                    CalculeteDiscountService.CacluleTransport(_employee.SalarioBruto) : 0
            };
            discounts.Add(transporte);
        }

        public void addDiscountFgts(List<Discount> discounts)
        {
            var fgts
                = new Discount()
                {
                    TypeOfDiscount = "FGTS",
                    ValueOfDiscount = CalculeteDiscountService.CacluleFGTS(_employee.SalarioBruto)

                };
            discounts.Add(fgts);
        }

        public decimal GetDiscount(List<Discount> discounts)
        {
            decimal sum = 0;
            foreach (var desconto in discounts)
            {
                sum += desconto.ValueOfDiscount;
            }
            return Decimal.Round((sum * -1), 2);
        }

        public decimal GetNetPay(decimal salary, decimal discount)
        {
            decimal netPay = salary + discount;

            return Decimal.Round(netPay, 2);
        }
    }
}
