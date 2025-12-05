namespace API.PagoTarjetaBancomer.Models
{
    public class VentaRequest
    {
        public decimal Monto { get; set; }
        public string Moneda { get; set; }

        // Datos tarjeta
        public string NumeroTarjeta { get; set; }
        public string FechaVencimiento { get; set; }
        public string Cvv { get; set; }

        // Datos de lectura
        public string Track1 { get; set; }
        public string Track2 { get; set; }
        public string ModoLectura { get; set; }

        // EMV
        public string Aid { get; set; }
        public string Arqc { get; set; }
        public string Emv { get; set; }

        // Operación
        public string Referencia { get; set; }
        public string Operador { get; set; }
        public string Afiliacion { get; set; }
        public string Terminal { get; set; }
        public string FolioInterno { get; set; }
    }

    public class DevolucionRequest
    {
        public string IdDevolucion { get; set; }
        public string IdVentaOriginal { get; set; }
        public decimal Monto { get; set; }
        public string Motivo { get; set; }
        public string Referencia { get; set; }
        public string Afiliacion { get; set; }
        public string Terminal { get; set; }
        public string FolioInterno { get; set; }
        public string Operador { get; set; }
    }

    public class CancelacionVentaRequest
    {
        public string IdVenta { get; set; }
        public string Motivo { get; set; }
        public string Afiliacion { get; set; }
        public string Terminal { get; set; }
        public string FolioInterno { get; set; }
        public string Operador { get; set; }
        public string Autorizacion { get; set; } = "";
    }

    public class CancelacionDevolucionRequest
    {
        public string IdDevolucion { get; set; }
        public string Motivo { get; set; }
        public string Afiliacion { get; set; }
        public string Terminal { get; set; }
        public string Operador { get; set; }
        public string Autorizacion { get; set; } = "";
        public string FolioInterno { get; set; }
    }


    public class ConsultaPuntosRequest
    {
        public string Tarjeta { get; set; }
        public string Afiliacion { get; set; }
        public string Terminal { get; set; }
    }

    public class CargaLlavesRequest
    {
        public string Terminal { get; set; }
        public string LlavePublica { get; set; }
        public string Afiliacion { get; set; }
    }
}
