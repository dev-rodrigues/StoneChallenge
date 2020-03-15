using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stone.Domain.Entities
{
    public class EmployeeDTO
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string SobreNome { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public string Setor { get; set; }

        [Required]
        public decimal SalarioBruto { get; set; }

        [Required]
        public DateTime Admissao { get; set; }
    }
}
