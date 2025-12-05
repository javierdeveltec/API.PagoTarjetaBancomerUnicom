using System;

namespace API.PagoTarjetaBancomer.Models
{
    public class Respuesta
    {
        public string CodigoRespuesta { get; set; } = "";
        public string Autorizacion { get; set; } = "";
        public string Leyenda { get; set; } = "";
        public string NumeroTarjeta { get; set; } = "";
        public string Tarjetahabiente { get; set; } = "";
        public string Afiliacion { get; set; } = "";
        public string NumeroTerminal { get; set; } = "";
        public string FechaHora { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmss");
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public string Emisor { get; set; }
        public string ModoLectura { get; set; }
        public string ARQC { get; set; }
        public string AID { get; set; }
        public string Track1 { get; set; }
        public string Track2 { get; set; }
        public string CodigoError { get; set; }
        public object Datos { get; set; }      
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public string FolioHost { get; set; }
        public string VoucherComercio { get; set; }
        public string VoucherCliente { get; set; }
        public string JsonOriginal { get; set; }



    }
}
