namespace API.PagoTarjetaBancomer.Models
{
    public class VentaRequest
    {
        public string IdVenta { get; set; }
        public decimal Monto { get; set; }
        public string Moneda { get; set; }
        public string Tarjeta { get; set; }
    }

    public class DevolucionRequest
    {
        public string IdDevolucion { get; set; }
        public string IdVentaOriginal { get; set; }
        public decimal Monto { get; set; }
        public string Motivo { get; set; }
    }

    public class CancelacionVentaRequest
    {
        public string IdVenta { get; set; }
        public string Motivo { get; set; }
    }

    public class CancelacionDevolucionRequest
    {
        public string IdDevolucion { get; set; }
        public string Motivo { get; set; }
    }

    public class PostPropinaRequest
    {
        public string IdVenta { get; set; }
        public decimal MontoPropina { get; set; }
    }

    public class ConsultaPuntosRequest
    {
        public string Tarjeta { get; set; }
    }

    public class CargaLlavesRequest
    {
        public string Terminal { get; set; }
        public string LlavePublica { get; set; }
    }
}
