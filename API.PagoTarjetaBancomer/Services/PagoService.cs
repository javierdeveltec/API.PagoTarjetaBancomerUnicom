using API.PagoTarjetaBancomer.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace API.PagoTarjetaBancomer.Services
{
    public class PagoService : IPagoService
    {
        private readonly IConfiguracionService _cfgService;
        private readonly HttpClient _http;

        public PagoService(IConfiguracionService cfgService)
        {
            _cfgService = cfgService;
            _http = new HttpClient();
        }

        // ================================================================
        // =====================   TOKEN   ================================
        // ================================================================
        private async Task<string> ObtenerTokenAsync(ConfiguracionPagoBBVA cfg)
        {
            var body = new
            {
                afiliacion = cfg.ComercioAfiliacion,
                terminal = cfg.ComercioTerminal,
                clave = cfg.ClaveSecreta
            };

            string json = JsonSerializer.Serialize(body);

            var http = new HttpRequestMessage(HttpMethod.Post, cfg.TokenUrl);
            http.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _http.SendAsync(http);
            string resultJson = await res.Content.ReadAsStringAsync();

            var parsed = JsonSerializer.Deserialize<JsonElement>(resultJson);

            return parsed.GetProperty("token").GetString() ?? "";
        }

        // ================================================================
        // ===============   MÉTODO GENÉRICO DE OPERACIÓN   ===============
        // ================================================================
        private async Task<Respuesta> EjecutarOperacion(string operacion, object payload)
        {
            var cfg = await _cfgService.ObtenerAsync();
            var token = await ObtenerTokenAsync(cfg);

            var json = JsonSerializer.Serialize(payload);

            var http = new HttpRequestMessage(HttpMethod.Post, cfg.HostUrl);
            http.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            http.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _http.SendAsync(http);
            var strResult = await res.Content.ReadAsStringAsync();

            var parsed = JsonSerializer.Deserialize<JsonElement>(strResult);

            // Mapeo genérico del SDK
            var respuesta = new Respuesta
            {
                Exito = parsed.TryGetProperty("resultado", out var pr) && pr.GetString() == "APROBADA",
                Autorizacion = parsed.GetProperty("codAutorizacion").GetString(),
                FolioHost = parsed.GetProperty("folioHost").GetString(),
                Mensaje = parsed.GetProperty("mensaje").GetString(),
                VoucherComercio = parsed.GetProperty("voucherComercio").GetString(),
                VoucherCliente = parsed.GetProperty("voucherCliente").GetString(),
                JsonOriginal = strResult
            };

            return respuesta;
        }

        // ================================================================
        // ======================  VENTA (NORMAL)  ========================
        // ================================================================
        public async Task<Respuesta> VentaAsync(VentaRequest req)
        {
            var payload = new
            {
                // OPERACIÓN
                operacion = "VENTA",
                importe = req.Monto.ToString("F2"),
                moneda = req.Moneda,
                referencia = req.Referencia,
                afiliacion = req.Afiliacion,
                terminal = req.Terminal,
                folioInterno = req.FolioInterno,
                operador = req.Operador,

                // DATOS TARJETA
                pan = req.NumeroTarjeta,
                fechaExp = req.FechaVencimiento,
                cvv = req.Cvv,

                // MODO LECTURA Y PISTAS
                modoLectura = req.ModoLectura,
                track1 = req.Track1,
                track2 = req.Track2,

                // EMV
                aid = req.Aid,
                arqc = req.Arqc,
                emvData = req.Emv
            };

            return await EjecutarOperacion("VENTA", payload);
        }




        // ================================================================
        // =======================  DEVOLUCIÓN  ============================
        // ================================================================
        public async Task<Respuesta> DevolucionAsync(DevolucionRequest req)
        {
            var payload = new
            {
                importe = req.Monto.ToString("F2"),
                referencia = req.Referencia,
                operacion = "DEVOLUCION",
                afiliacion = req.Afiliacion,
                terminal = req.Terminal,
                folioInterno = req.FolioInterno,
                operador = req.Operador
            };

            return await EjecutarOperacion("DEVOLUCION", payload);
        }

        // ================================================================
        // =================== CANCELACIÓN DE VENTA ========================
        // ================================================================
        public async Task<Respuesta> CancelacionVentaAsync(CancelacionVentaRequest req)
        {
            var payload = new
            {
                operacion = "CANCELACION_VENTA",
                afiliacion = req.Afiliacion,
                terminal = req.Terminal,
                folioInterno = req.FolioInterno,
                operador = req.Operador,
                autorizacion = req.Autorizacion
            };

            return await EjecutarOperacion("CANCELACION_VENTA", payload);
        }

        // ================================================================
        // ============= CANCELACIÓN DE DEVOLUCIÓN =========================
        // ================================================================
        public async Task<Respuesta> CancelacionDevolucionAsync(CancelacionDevolucionRequest req)
        {
            var payload = new
            {
                operacion = "CANCELACION_DEVOLUCION",
                afiliacion = req.Afiliacion,
                terminal = req.Terminal,
                folioInterno = req.FolioInterno,
                operador = req.Operador,
                autorizacion = req.Autorizacion
            };

            return await EjecutarOperacion("CANCELACION_DEVOLUCION", payload);
        }


        // ================================================================
        // ===================== CONSULTA PUNTOS ===========================
        // ================================================================
        public async Task<Respuesta> ConsultaPuntosAsync(ConsultaPuntosRequest req)
        {
            var payload = new
            {
                operacion = "CONSULTA_PUNTOS",
                afiliacion = req.Afiliacion,
                terminal = req.Terminal
            };

            return await EjecutarOperacion("CONSULTA_PUNTOS", payload);
        }

        // ================================================================
        // ===================== CARGA DE LLAVES ===========================
        // ================================================================
        public async Task<Respuesta> CargaLlavesAsync(CargaLlavesRequest req)
        {
            var payload = new
            {
                operacion = "CARGA_LLAVES",
                afiliacion = req.Afiliacion,
                terminal = req.Terminal
            };

            return await EjecutarOperacion("CARGA_LLAVES", payload);
        }

        // ================================================================
        // ======================== REVERSOS ===============================
        // ================================================================
        public async Task<Respuesta> ReversosAsync()
        {
            var payload = new
            {
                operacion = "REVERSO"
            };

            return await EjecutarOperacion("REVERSO", payload);
        }
    }
}
