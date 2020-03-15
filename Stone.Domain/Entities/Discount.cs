using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Domain.Entities
{
    public class Discount
    {
        public string TypeOfDiscount { get; set; }
        public decimal Aliquot { get; set; }
        public decimal Dedution { get; set; }

        public Discount()
        {
        }
    }
}
