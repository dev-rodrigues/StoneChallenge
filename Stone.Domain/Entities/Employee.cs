using Stone.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stone.Domain.Entities
{
    public class Employee : EntityBase<int>
    {

        [Required]
        public string Nome { get; set; }

        [Required]
        public string SobreNome { get; set; }

        [Required]
        [ValidateCpf]
        public string Cpf { get; set; }

        [Required]
        public string Setor { get; set; }

        [Required]
        public decimal SalarioBruto { get; set; }

        [Required]
        public DateTime Admissao { get; set; }

        [Required]
        public bool PlanoSaude { get; set; }

        [Required]
        public bool PlanoDental { get; set; }

        [Required]
        public bool ValeTransporte { get; set; }

        public Employee()
        {

        }
    }
}
