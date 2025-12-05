using API.PagoTarjetaBancomer.Models;
using API.PagoTarjetaBancomer.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.PagoTarjetaBancomer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagosController : ControllerBase
    {
        private readonly IPagoService _pagoService;
        private readonly IConfiguracionService _cfgService;

        public PagosController(IPagoService pagoService,
                               IConfiguracionService cfgService)
        {
            _pagoService = pagoService;
            _cfgService = cfgService;
        }


        [HttpPost("venta")]
        public async Task<IActionResult> Venta([FromBody] VentaRequest request)

        {
            if (request == null)
                return BadRequest("El request está vacío.");

            var respuesta = await _pagoService.VentaAsync(request);

            return Ok(respuesta);
        }
        


        [HttpPost("devolucion")]
        public async Task<IActionResult> Devolucion([FromBody] DevolucionRequest request)
        {
            var respuesta = await _pagoService.DevolucionAsync(request);
            return Ok(respuesta);
        }

        [HttpPost("cancelacion-venta")]
        public async Task<IActionResult> CancelacionVenta([FromBody] CancelacionVentaRequest request)
        {
            var respuesta = await _pagoService.CancelacionVentaAsync(request);
            return Ok(respuesta);
        }

        [HttpPost("cancelacion-devolucion")]
        public async Task<IActionResult> CancelacionDevolucion([FromBody] CancelacionDevolucionRequest request)
        {
            var respuesta = await _pagoService.CancelacionDevolucionAsync(request);
            return Ok(respuesta);
        }


        [HttpPost("consulta-puntos")]
        public async Task<IActionResult> ConsultaPuntos([FromBody] ConsultaPuntosRequest request)
        {
            var respuesta = await _pagoService.ConsultaPuntosAsync(request);
            return Ok(respuesta);
        }

        [HttpPost("carga-llaves")]
        public async Task<IActionResult> CargaLlaves([FromBody] CargaLlavesRequest request)
        {
            var respuesta = await _pagoService.CargaLlavesAsync(request);
            return Ok(respuesta);
        }

        [HttpGet("reversos")]
        public async Task<IActionResult> Reversos()
        {
            var respuesta = await _pagoService.ReversosAsync();
            return Ok(respuesta);
        }
    }
}
