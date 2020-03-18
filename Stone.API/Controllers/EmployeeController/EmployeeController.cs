using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stone.Domain.Entities;
using Stone.Domain.Interface.Repositories;
using Stone.Service;

namespace Stone.API.Controllers.EmployeeController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly EmployeeService funcionarioService = new EmployeeService();
        
        [HttpGet]
        public IActionResult Show(int id)
        {
            Employee _funcionario = funcionarioService.GetFuncionarioPorId(id);

            if (_funcionario == null)
            {
                return NotFound("Funcionario não localizado");
            }
            return Ok(JsonConvert.SerializeObject(_funcionario));
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Store(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var funcionario_salvo = funcionarioService.AddFuncionario(employee);
            return CreatedAtAction(nameof(Show)
                    , new { employeeId = funcionario_salvo.Id }
                    , funcionario_salvo);
        }

    }
}