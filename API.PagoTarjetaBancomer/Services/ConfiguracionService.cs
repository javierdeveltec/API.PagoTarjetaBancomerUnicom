using API.PagoTarjetaBancomer.Models;
using Microsoft.Extensions.Logging;


namespace API.PagoTarjetaBancomer.Services
{

    public class ConfiguracionService : IConfiguracionService
    {
        private readonly IConfiguracionRepository _repo;
        private readonly ILogger<ConfiguracionService> _logger;

        public ConfiguracionService(
            IConfiguracionRepository repo,
            ILogger<ConfiguracionService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<ConfiguracionPagoBBVA> ObtenerAsync()
        {
            var config = await _repo.GetAsync();

            if (config == null)
            {
                _logger.LogError("No existe registro de configuración BBVA en la base de datos.");
                throw new Exception("La configuración BBVA no está inicializada.");
            }

            Validar(config);

            return config;
        }

        public async Task<ConfiguracionPagoBBVA> ActualizarAsync(ConfiguracionPagoBBVA config)
        {
            Validar(config);
            return await _repo.UpdateAsync(config);
        }

        private void Validar(ConfiguracionPagoBBVA c)
        {
            if (string.IsNullOrWhiteSpace(c.HostUrl))
                throw new Exception("HostUrl no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(c.ClaveSecreta))
                throw new Exception("ClaveSecreta no puede estar vacía.");

            if (string.IsNullOrWhiteSpace(c.ClaveBines))
                throw new Exception("ClaveBines no puede estar vacía.");

            if (string.IsNullOrWhiteSpace(c.TokenUrl))
                throw new Exception("TokenUrl no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(c.ComercioAfiliacion))
                throw new Exception("ComercioAfiliacion no puede estar vacía.");

            if (string.IsNullOrWhiteSpace(c.ComercioTerminal))
                throw new Exception("ComercioTerminal no puede estar vacía.");
        }
    }

}
