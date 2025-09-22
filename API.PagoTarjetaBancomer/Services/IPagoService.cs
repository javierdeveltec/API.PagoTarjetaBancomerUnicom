using API.PagoTarjetaBancomer.Models;


namespace API.PagoTarjetaBancomer.Services
{
    public interface IPagoService
    {
        Task<Respuesta> VentaAsync(VentaRequest request);
        Task<Respuesta> DevolucionAsync(DevolucionRequest request);
        Task<Respuesta> CancelacionVentaAsync(CancelacionVentaRequest request);
        Task<Respuesta> CancelacionDevolucionAsync(CancelacionDevolucionRequest request);
        Task<Respuesta> PostPropinaAsync(PostPropinaRequest request);
        Task<Respuesta> ConsultaPuntosAsync(ConsultaPuntosRequest request);
        Task<Respuesta> CargaLlavesAsync(CargaLlavesRequest request);
        Task<Respuesta> ReversosAsync();
    }
}
