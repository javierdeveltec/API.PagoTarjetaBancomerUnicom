using API.PagoTarjetaBancomer.Models;
using API.PagoTarjetaBancomer.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/configuracion")]
public class ConfiguracionController : ControllerBase
{
    private readonly IConfiguracionService _service;

    public ConfiguracionController(IConfiguracionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var config = await _service.ObtenerAsync();
        return Ok(config);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ConfiguracionPagoBBVA model)
    {
        var config = await _service.ActualizarAsync(model);
        return Ok(config);
    }
}