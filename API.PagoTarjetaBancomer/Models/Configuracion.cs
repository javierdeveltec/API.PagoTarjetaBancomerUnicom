namespace API.PagoTarjetaBancomer.Models
{
    public class Configuracion
    {
        public string ClaveBines { get; set; } = "";
        public string ClaveSecreta { get; set; } = "";
        public string ComercioAfiliacion { get; set; } = "";
        public string ComercioTerminal { get; set; } = "";
        public string ComercioMac { get; set; } = "";
        public string HostTimeOut { get; set; } = "";
        public string HostUrl { get; set; } = "";
        public string IdAplicacion { get; set; } = "";
        public bool FuncionalidadMoto { get; set; } = false;
        public bool PinpadCargaLlaves { get; set; } = false;
        public bool PinpadContactless { get; set; } = false;
        public string PinpadConexion { get; set; } = "";
        public string PinpadMensaje { get; set; } = "";
        public string PinpadPuerto { get; set; } = "";
        public string PinpadTeleCarga { get; set; } = "";
        public string PinpadTimeOut { get; set; } = "";
        public bool Logs { get; set; } = true;
        public bool TecladoLiberto { get; set; } = true;
    }
}
