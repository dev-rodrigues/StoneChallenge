using Stone.Domain.Entities;
using Stone.Domain.Interface.Repositories;
using Stone.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Service
{
    public class PaycheckService
    {
        private Employee _employee { get; set; }
        private readonly IDiscount _inssRepository = EmployeeServiceLocator.GetInstance<InssRepository>();
        private readonly IDiscount _iprfRepository = EmployeeServiceLocator.GetInstance<InssRepository>();

        public PaycheckService(Employee employee)
        {
            _employee = employee;
        }

        public Paymentslip GetPaySlip()
        {
            List<Discount> discounts = new List<Discount>();

            discounts.Add(GetDiscountInss());
            discounts.Add(GetDiscountIrpf());
            discounts.Add(GetDiscountHealthPlan());
            discounts.Add(GetDiscountDentalPlan());

            return new Paymentslip()
            {
                Discounts = discounts,
                Employee = _employee
            };
        }

        public Discount GetDiscountInss()
        {
            return _inssRepository.GetDiscount(_employee.SalarioBruto);
        }

        public Discount GetDiscountIrpf()
        {
            return _iprfRepository.GetDiscount(_employee.SalarioBruto);
        }

        public Discount GetDiscountHealthPlan()
        {
            return new Discount()
            {
                TypeOfDiscount = "Plano de Saúde",
                Value = _employee.PlanoSaude ? _employee.SalarioBruto - 10 : 0
            };
        }

        public Discount GetDiscountDentalPlan()
        {
            return new Discount()
            {
                TypeOfDiscount = "Plano de Dental",
                Value = _employee.PlanoSaude ? _employee.SalarioBruto - 5 : 0
            };
        }

        public Task<Discount> GetDiscountTransport()
        {
            return null;
        }
    }
}
