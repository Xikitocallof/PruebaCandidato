using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebasCandidatos.Interfaces;
using PruebasCandidatos.Modelos;
using PruebasCandidatos.Services;
using System.Text.Json;

namespace PruebasCandidatos.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;
        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }
        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var res = await _customersService.GetCustomers();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
