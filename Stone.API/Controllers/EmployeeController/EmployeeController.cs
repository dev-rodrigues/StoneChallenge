using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Index()
        {            
            return Ok(employeeService.GetEmployeeById(1));
        }

        [HttpPost]
        public IActionResult Store(Employee employee)
        {
            return Ok(employee);
        }

    }
}