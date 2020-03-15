using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stone.Domain.Interface.Repositories;
using Stone.Infrastructure.Repositories;
using Stone.Service;

namespace Stone.API.Controllers.EmployeeController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePaycheckController : ControllerBase
    {

        private readonly EmployeeService employeeService = new EmployeeService();

        [HttpGet]
        public IActionResult Show(int employeeId)
        {
            var employee = employeeService.GetEmployeeById(employeeId);

            var teste = new PaycheckService(employee);
            var teste2 = teste.GetPaySlip();
            return Ok(teste2);
        }
    }
}