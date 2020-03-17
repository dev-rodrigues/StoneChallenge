using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Domain.Entities
{
    public class Irpf : EntityBase<int>
    {
        public decimal Minimo { get; set; }
        public decimal Maximo { get; set; }
        public decimal Aliquota { get; set; }
        public decimal Deduzir { get; set; }
    }
}
