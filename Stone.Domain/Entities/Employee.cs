using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stone.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public string Cpf { get; set; }

        public string Setor { get; set; }

        public decimal SalarioBruto { get; set; }

        public DateTime Admissao { get; set; }

        public bool PlanoSaude { get; set; }

        public bool PlanoDental { get; set; }

        public bool ValeTransporte { get; set; }
        
        public Employee()
        {

        }    
    }
}
