using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Stone.Domain.Entities;
using Stone.Domain.Interface.Repositories;
using Stone.Infrastructure.Repositories;
using Stone.Service;

namespace Stone.API.Controllers.EmployeeController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePaycheckController : ControllerBase
    {

        private readonly EmployeeService funcionarioService = new EmployeeService();
        private readonly IDistributedCache _cacheDistribuido;

        public EmployeePaycheckController(IDistributedCache cacheDistribuido)
        {
            _cacheDistribuido = cacheDistribuido;
        }

        [HttpGet]
        public async Task<IActionResult> Show(int funcionario)
        {
            var chave = funcionario.ToString();
            string existeChave = String.Empty;
            try
            {
                existeChave = await _cacheDistribuido.GetStringAsync(chave);
            }
            catch
            {
                existeChave = String.Empty;
            }

            Paymentslip slip;

            if (!string.IsNullOrEmpty(existeChave))
            {
                return Ok(existeChave);
            }
            else
            {
                // busca o usuario
                var employee = funcionarioService.GetFuncionarioPorId(funcionario);

                // cria servico pro usuario
                var service = new PaycheckService(employee);

                // gera contracheque
                slip = service.GetContraCheque();

                // adiciona obj serializado ao redis
                try
                {
                    var cacheSettings = new DistributedCacheEntryOptions();
                    cacheSettings.SetAbsoluteExpiration(TimeSpan.FromHours(1));
                    await _cacheDistribuido.SetStringAsync(chave, JsonConvert.SerializeObject(slip));
                }
                catch
                {
                    Console.WriteLine("nao faz nada");
                }

            }
            return Ok(slip);
        }
    }
}