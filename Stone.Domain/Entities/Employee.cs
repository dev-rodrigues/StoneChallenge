using System;
using System.Collections.Generic;
using System.Text;

namespace Stone.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Cpf { get; set; }
        public string Setor { get; set; }
        public long SalarioBruto { get; set; }
        public DateTime Admissao { get; set; }
        public bool PlanoSaude { get; set; }
        public bool PlanoDental { get; set; }
        public bool ValeTransporte { get; set; }
    }
}
