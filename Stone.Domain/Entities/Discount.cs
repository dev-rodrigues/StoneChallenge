using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Domain.Entities
{
    public class Discount
    {
        public string TypeOfDiscount { get; set; }
        public decimal Value { get; set; }

        public Discount()
        {
        }
    }
}
