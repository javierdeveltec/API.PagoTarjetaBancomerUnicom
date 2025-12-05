using Microsoft.AspNetCore.Mvc;

namespace API.PagoTarjetaBancomer.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        private readonly IConfiguracionRepository _repo;

        public TestController(IConfiguracionRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("configuracion")]
        public async Task<IActionResult> Get()
        {
            var cfg = await _repo.GetAsync();
            return Ok(cfg);
        }
    }
}
