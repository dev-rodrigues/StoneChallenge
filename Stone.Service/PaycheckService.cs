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
        private Employee _funcionario { get; set; }
        private readonly IDiscount _inssRepository = EmployeeServiceLocator.GetInstance<InssRepository>();
        private readonly IDiscount _iprfRepository = EmployeeServiceLocator.GetInstance<IrpfRepository>();

        public PaycheckService(Employee funcionario)
        {
            _funcionario = funcionario;
        }

        public Paymentslip GetContraCheque()
        {
            var descontos = new List<Discount>();
            GetDescontos(descontos);
            
            var paySlip = new Paymentslip()
            {
                Lancamentos = descontos,
                TotalDesconto = GetDiscount(descontos),

                Employee = new EmployeeDTO()
                {
                    Nome = _funcionario.Nome,
                    SobreNome = _funcionario.SobreNome,
                    Cpf = _funcionario.Cpf,
                    Setor = _funcionario.Setor,
                    SalarioBruto = _funcionario.SalarioBruto,
                    Admissao = _funcionario.Admissao
                }
            };

            paySlip.Referencia = MonthService.GetMonth(new DateTime().Month);
            paySlip.SalarioLiquido = GetNetPay(paySlip.Employee.SalarioBruto, paySlip.TotalDesconto);

            return paySlip;
        }

        public void GetDescontos(List<Discount> descontos)
        {
            addDescontosInss(descontos);
            addDiscountIrpf(descontos);
            addDiscountHealthPlan(descontos);
            addDiscountDentalPlan(descontos);
            addDiscountTransport(descontos);
            addDiscountFgts(descontos);
        }

        public void addDescontosInss(List<Discount> descontos)
        {
            descontos.Add(_inssRepository.GetDesconto(_funcionario.SalarioBruto));
        }

        public void addDiscountIrpf(List<Discount> discounts)
        {
            discounts.Add(_iprfRepository.GetDesconto(_funcionario.SalarioBruto));
        }

        public void addDiscountHealthPlan(List<Discount> discounts)
        {
            var planoDeSaude = new Discount()
            {
                TipoDeDesconto = "Plano de Saúde",
                ValorDesconto = _funcionario.PlanoSaude ? 10 : 0
            };
            discounts.Add(planoDeSaude);
        }

        public void addDiscountDentalPlan(List<Discount> discounts)
        {
            var dental = new Discount()
            {
                TipoDeDesconto = "Plano de Dental",
                ValorDesconto = _funcionario.PlanoSaude ? 5 : 0,
            };
            discounts.Add(dental);
        }

        public void addDiscountTransport(List<Discount> discounts)
        {
            var transporte = new Discount()
            {
                TipoDeDesconto = "Transporte",
                ValorDesconto = _funcionario.ValeTransporte ?
                    CalculeteDiscountService.CacluleTransport(_funcionario.SalarioBruto) : 0
            };
            discounts.Add(transporte);
        }

        public void addDiscountFgts(List<Discount> discounts)
        {
            var fgts
                = new Discount()
                {
                    TipoDeDesconto = "FGTS",
                    ValorDesconto = CalculeteDiscountService.CacluleFGTS(_funcionario.SalarioBruto)

                };
            discounts.Add(fgts);
        }

        public decimal GetDiscount(List<Discount> discounts)
        {
            decimal sum = 0;
            foreach (var desconto in discounts)
            {
                sum += desconto.ValorDesconto;
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
