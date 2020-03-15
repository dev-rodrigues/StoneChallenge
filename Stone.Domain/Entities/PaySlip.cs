using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Stone.Domain.Entities
{
    public class Paymentslip
    {
        public string Referencia { get; set; }
        public EmployeeDTO Employee { get; set; }
        public decimal TotalDesconto { get; set; }
        public decimal SalarioLiquido { get; set; }
        public List<Discount> Lancamentos { get; set; }
        
        public Paymentslip()
        {
            Lancamentos = new List<Discount>();
        }
    }
}
