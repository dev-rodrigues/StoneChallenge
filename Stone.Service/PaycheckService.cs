using Stone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Service
{
    public class PaycheckService
    {
        public Employee _employee { get; set; }

        public PaycheckService(Employee employee)
        {
            _employee = employee;
        }
        
        public Task<Paymentslip> GetPaySlip()
        {
            return null;
        }

        public Task<Discount> GetDiscountInss()
        {
            return null;
        }

        public Task<Discount> GetDiscountIrpf()
        {
            return null;
        }

        public Task<Discount> GetDiscountHealthPlan()
        {
            return null;
        }

        public Task<Discount> GetDiscountDentalPlan()
        {
            return null;
        }

        public Task<Discount> GetDiscountTransport()
        {
            return null;
        }
    }
}
