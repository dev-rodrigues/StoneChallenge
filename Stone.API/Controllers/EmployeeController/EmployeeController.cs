using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stone.Domain.Entities;
using Stone.Domain.Interface.Repositories;
using Stone.Service;

namespace Stone.API.Controllers.EmployeeController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly EmployeeService employeeService = new EmployeeService();
        
        [HttpGet]
        public IActionResult Show(int employeeId)
        {            
            return Ok(employeeService.GetEmployeeById(employeeId));
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Store(Employee employee)
        {
            var saved_employee = employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(Show), new { employeeId = saved_employee.Id }, saved_employee);
        }

    }
}