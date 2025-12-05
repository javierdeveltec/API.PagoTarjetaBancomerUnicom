using API.PagoTarjetaBancomer.Models;
using Microsoft.EntityFrameworkCore;

public class ConfiguracionRepository : IConfiguracionRepository
{
    private readonly PagoBbvaDbContext _db;

    public ConfiguracionRepository(PagoBbvaDbContext db)
    {
        _db = db;
    }

    public async Task<ConfiguracionPagoBBVA> GetAsync()
    {
        return await _db.ConfiguracionPagoBBVA.FirstOrDefaultAsync();
    }

    public async Task<ConfiguracionPagoBBVA> UpdateAsync(ConfiguracionPagoBBVA config)
    {
        _db.ConfiguracionPagoBBVA.Update(config);
        await _db.SaveChangesAsync();
        return config;
    }
}
