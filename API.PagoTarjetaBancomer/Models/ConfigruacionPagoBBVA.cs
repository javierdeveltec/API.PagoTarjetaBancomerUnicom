namespace API.PagoTarjetaBancomer.Models
{
    public class ConfiguracionPagoBBVA
    {
        public int Id { get; set; }

        // Generales
        public string HostUrl { get; set; }
        public string ClaveBines { get; set; }
        public string ClaveSecreta { get; set; }
        public bool EntornoPruebas { get; set; }
        public string TokenUrl { get; set; }
        public int HostTimeoutSecs { get; set; }

        // PinPad
        public int PinpadTimeoutSeg { get; set; }
        public string PinpadConexion { get; set; }
        public string PinpadPuertoCom { get; set; }
        public int? PinpadBaudRate { get; set; }
        public string PinpadModelo { get; set; }
        public bool PinpadBuscadorUsb { get; set; }

        // Comercio
        public string ComercioAfiliacion { get; set; }
        public string ComercioTerminal { get; set; }
        public string ComercioMac { get; set; }
        public string ComercioDireccion { get; set; }

        // Opciones funcionales
        public bool Moto { get; set; }
        public bool PagoContactLess { get; set; }
        public bool PagoConTarjeta { get; set; }
        public bool VentaForzada { get; set; }
        public bool MiniAfiliaciones { get; set; }
        public bool ProcesamientoPuntos { get; set; }
        public bool ProcesamientoCupones { get; set; }
        public bool ProcesamientoCreditos { get; set; }
        public bool CompensacionTms { get; set; }
        public bool PermitirMultiplesHilos { get; set; }
    }

}
