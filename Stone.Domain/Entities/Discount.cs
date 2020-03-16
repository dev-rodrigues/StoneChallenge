using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Domain.Entities
{
    public class Discount
    {
        public string TipoDeDesconto { get; set; }
        public decimal Aliquota { get; set; }
        public decimal Deducao { get; set; }
        public decimal ValorDesconto { get; set; }

        public Discount()
        {
        }
    }
}
