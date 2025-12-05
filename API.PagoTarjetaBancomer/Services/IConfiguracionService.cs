using API.PagoTarjetaBancomer.Models;

namespace API.PagoTarjetaBancomer.Services
{
    public interface IConfiguracionService
    {
        Task<ConfiguracionPagoBBVA> ObtenerAsync();
        Task<ConfiguracionPagoBBVA> ActualizarAsync(ConfiguracionPagoBBVA config);
    }
}
