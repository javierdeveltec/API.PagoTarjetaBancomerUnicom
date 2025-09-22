using API.PagoTarjetaBancomer.Models;
using API.PagoTarjetaBancomer.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.PagoTarjetaBancomer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagosController : ControllerBase
    {
        private readonly IPagoService _pagoService;

        public PagosController(IPagoService pagoService)
        {
            _pagoService = pagoService;
        }

        [HttpPost("venta")]
        public async Task<IActionResult> Venta([FromBody] VentaRequest request)
        {
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

        [HttpPost("postpropina")]
        public async Task<IActionResult> PostPropina([FromBody] PostPropinaRequest request)
        {
            var respuesta = await _pagoService.PostPropinaAsync(request);
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
