using API.PagoTarjetaBancomer.Models;

public interface IConfiguracionRepository
{
    Task<ConfiguracionPagoBBVA> GetAsync();
    Task<ConfiguracionPagoBBVA> UpdateAsync(ConfiguracionPagoBBVA config);
}
