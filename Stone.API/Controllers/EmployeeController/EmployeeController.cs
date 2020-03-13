using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stone.Domain.Entities;

namespace Stone.API.Controllers.EmployeeController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        [HttpGet]
        public IActionResult Index()
        {
            var retorno = new Employee() {
                Id = 1,
                Nome = "Carlos Henrique",
                SobreNome = "Junior",
                Cpf = "148.974.627-70",
                Setor = "TI",
                SalarioBruto = 946,
                Admissao = new DateTime(),
                PlanoDental = false,
                PlanoSaude = false,
                ValeTransporte = false                
            };
            return Ok(retorno);
        }

        [HttpPost]
        public IActionResult Store(Employee employee)
        {
            return Ok(employee);
        }

    }
}