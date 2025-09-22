using API.PagoTarjetaBancomer.Models;
using API.PagoTarjetaBancomer.Services;


namespace API.PagoTarjetaBancomer.Services
{
    public class PagoService : IPagoService
    {
        private Random _rnd = new Random();

        private string GenerarARQC() => $"ARQC{_rnd.Next(100000, 999999)}";
        private string GenerarAID() => "A0000000041010";
        private string GenerarTrack1(string tarjeta) => $"B{tarjeta}^CARDHOLDER/TEST^23051200000000000000";
        private string GenerarTrack2(string tarjeta) => $"{tarjeta}=23051200000000000000";

        public async Task<Respuesta> VentaAsync(VentaRequest request)
        {
            return new Respuesta
            {
                Exito = true,
                Mensaje = "Venta procesada correctamente",
                Emisor = "POS",
                ModoLectura = "Chip",
                ARQC = GenerarARQC(),
                AID = GenerarAID(),
                Track1 = GenerarTrack1(request.Tarjeta),
                Track2 = GenerarTrack2(request.Tarjeta),
                Datos = request
            };
        }

        public async Task<Respuesta> DevolucionAsync(DevolucionRequest request)
        {
            return new Respuesta
            {
                Exito = true,
                Mensaje = "Devolución procesada",
                Emisor = "POS",
                ModoLectura = "Chip",
                ARQC = GenerarARQC(),
                AID = GenerarAID(),
                Track1 = GenerarTrack1("4111111111111111"),
                Track2 = GenerarTrack2("4111111111111111"),
                Datos = request
            };
        }

        public async Task<Respuesta> CancelacionVentaAsync(CancelacionVentaRequest request)
        {
            return new Respuesta
            {
                Exito = true,
                Mensaje = $"Venta {request.IdVenta} cancelada",
                Emisor = "POS",
                ModoLectura = "Chip",
                Datos = request
            };
        }

        public async Task<Respuesta> CancelacionDevolucionAsync(CancelacionDevolucionRequest request)
        {
            return new Respuesta
            {
                Exito = true,
                Mensaje = $"Devolución {request.IdDevolucion} cancelada",
                Emisor = "POS",
                ModoLectura = "Chip",
                Datos = request
            };
        }

        public async Task<Respuesta> PostPropinaAsync(PostPropinaRequest request)
        {
            return new Respuesta
            {
                Exito = true,
                Mensaje = $"Propina de {request.MontoPropina:C} agregada a venta {request.IdVenta}",
                Emisor = "POS",
                ModoLectura = "Chip",
                Datos = request
            };
        }

        public async Task<Respuesta> ConsultaPuntosAsync(ConsultaPuntosRequest request)
        {
            int puntos = _rnd.Next(0, 5000);
            return new Respuesta
            {
                Exito = true,
                Mensaje = "Consulta de puntos exitosa",
                Emisor = "POS",
                ModoLectura = "Manual",
                Datos = new { PuntosDisponibles = puntos, Tarjeta = request.Tarjeta }
            };
        }

        public async Task<Respuesta> CargaLlavesAsync(CargaLlavesRequest request)
        {
            return new Respuesta
            {
                Exito = true,
                Mensaje = "Llaves cargadas correctamente",
                Emisor = "POS",
                ModoLectura = "Automático",
                Datos = request
            };
        }

        public async Task<Respuesta> ReversosAsync()
        {
            var reversos = Enumerable.Range(1, 5).Select(i => new
            {
                Id = $"REV{i:000}",
                Monto = _rnd.Next(50, 500),
                Fecha = DateTime.UtcNow.AddMinutes(-_rnd.Next(1, 1440)),
                Estado = i % 2 == 0 ? "Pendiente" : "Procesado"
            });

            return new Respuesta
            {
                Exito = true,
                Mensaje = "Listado de reversos simulados",
                Emisor = "POS",
                ModoLectura = "Automático",
                Datos = reversos
            };
        }
    }
}
