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
    public class WebTreeViewController : ControllerBase
    {
        private readonly IWebTreeViewService _webTreeViewService;
        public WebTreeViewController(IWebTreeViewService webTreeViewService)
        {
            _webTreeViewService = webTreeViewService;
        }
        [HttpGet("GetListado")]
        public async Task<IActionResult> GetListado()
        {
            try
            {
                var res = await _webTreeViewService.GetListado();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
