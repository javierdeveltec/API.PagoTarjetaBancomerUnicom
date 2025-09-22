namespace API.PagoTarjetaBancomer.Models
{
    public class Tarjeta
    {
        public string Pan { get; set; } = "";
        public string Tarjetahabiente { get; set; } = "";
        public string Emisor { get; set; } = "";
        public bool Nip { get; set; } = false;
    }
}
