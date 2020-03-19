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

        /// <summary>
        /// Calcular os descontos do usuário
        /// </summary>
        /// <returns>
        /// Objeto PaySlip
        /// </returns>
        public Paymentslip GetContraCheque()
        {
            var descontos = new List<Discount>();
            GetDescontos(descontos);
            
            var paySlip = new Paymentslip()
            {
                Lancamentos = descontos,
                TotalDesconto = GetDesconto(descontos),

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

            paySlip.Referencia = MonthService.GetMes(new DateTime().Month);
            paySlip.SalarioLiquido = GetSalarioLiquido(paySlip.Employee.SalarioBruto, paySlip.TotalDesconto);

            return paySlip;
        }

        /// <summary>
        /// Chama os métodos responsáveis por calcular os descontos do usuário
        /// </summary>
        /// <param name="descontos"></param>
        public void GetDescontos(List<Discount> descontos)
        {
            if(_funcionario != null)
            {
                addDescontoInss(descontos);
                addDescontoIrpf(descontos);
                addDescontoPlanoDeSaude(descontos);
                addDescontoPlanoDental(descontos);
                addDescontoTransporte(descontos);
                addDescontoFgts(descontos);
            }
        }

        /// <summary>
        /// Calcular os descontos de inss
        /// </summary>
        /// <param name="descontos"></param>
        public void addDescontoInss(List<Discount> descontos)
        {
            descontos.Add(_inssRepository.GetDesconto(_funcionario.SalarioBruto));
        }

        /// <summary>
        /// Calcular o desconto de irpf
        /// </summary>
        /// <param name="desconto"></param>
        public void addDescontoIrpf(List<Discount> desconto)
        {
            desconto.Add(_iprfRepository.GetDesconto(_funcionario.SalarioBruto));
        }

        /// <summary>
        /// Calcular o desconto de plano de saude
        /// </summary>
        /// <param name="descontos"></param>
        public void addDescontoPlanoDeSaude(List<Discount> descontos)
        {
            var planoDeSaude = new Discount()
            {
                TipoDeDesconto = "Plano de Saúde",
                ValorDesconto = _funcionario.PlanoSaude ? 10 : 0
            };
            descontos.Add(planoDeSaude);
        }

        /// <summary>
        /// Calcular o desconto de plano dental
        /// </summary>
        /// <param name="descontos"></param>
        public void addDescontoPlanoDental(List<Discount> descontos)
        {
            var dental = new Discount()
            {
                TipoDeDesconto = "Plano de Dental",
                ValorDesconto = _funcionario.PlanoSaude ? 5 : 0,
            };
            descontos.Add(dental);
        }

        /// <summary>
        /// Calcular o desconto de transporte
        /// </summary>
        /// <param name="descontos"></param>
        public void addDescontoTransporte(List<Discount> descontos)
        {
            var transporte = new Discount()
            {
                TipoDeDesconto = "Transporte",
                ValorDesconto = _funcionario.ValeTransporte ?
                    CalculeteDiscountService.CalcularTransporte(_funcionario.SalarioBruto) : 0
            };
            descontos.Add(transporte);
        }

        /// <summary>
        /// Calcular o desconto de fgts
        /// </summary>
        /// <param name="discounts"></param>
        public void addDescontoFgts(List<Discount> discounts)
        {
            var fgts
                = new Discount()
                {
                    TipoDeDesconto = "FGTS",
                    ValorDesconto = CalculeteDiscountService.CalcularFgts(_funcionario.SalarioBruto)

                };
            discounts.Add(fgts);
        }

        /// <summary>
        /// Calcular todos os descontos do usuário
        /// </summary>
        /// <param name="descontos"></param>
        /// <returns></returns>
        public decimal GetDesconto(List<Discount> descontos)
        {
            decimal sum = 0;
            foreach (var desconto in descontos)
            {
                sum += desconto.ValorDesconto;
            }
            return Decimal.Round((sum * -1), 2);
        }

        /// <summary>
        /// Calcular o salário liquido
        /// </summary>
        /// <param name="salario"></param>
        /// <param name="desconto"></param>
        /// <returns></returns>
        public decimal GetSalarioLiquido(decimal salario, decimal desconto)
        {
            decimal netPay = salario + desconto;

            return Decimal.Round(netPay, 2);
        }
    }
}
