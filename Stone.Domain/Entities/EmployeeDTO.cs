using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Domain.Entities
{
    public class EmployeeDTO
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string CPF { get; set; }
        public string Setor { get; set; }
        public decimal SalarioBruto { get; set; }
        public string Admissao { get; set; }
        public bool PlanoDental { get; set; }
        public bool PlanoDeSaude { get; set; }
        public bool ValeTransporte { get; set; }

        public EmployeeDTO()
        {

        }
    }
}
