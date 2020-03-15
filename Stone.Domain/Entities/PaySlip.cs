using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Domain.Entities
{
    public class Paymentslip
    {
        public Employee Employee { get; set; }
        public List<Discount> Discounts { get; set; }

        public Paymentslip()
        {
            Discounts = new List<Discount>();
        }
    }
}
