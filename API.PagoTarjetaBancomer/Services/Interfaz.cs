using System;
using API.PagoTarjetaBancomer.Models;

namespace API.PagoTarjetaBancomer.Services
{
    public class Interfaz
    {
        private static readonly Lazy<Interfaz> _instance = new Lazy<Interfaz>(() => new Interfaz());
        public static Interfaz Instance => _instance.Value;

        public Configuracion Configuracion { get; set; } = new Configuracion();

        public void Inicializar()
        {
            if (Configuracion.Logs)
                Console.WriteLine("[Interfaz] Inicializado");
        }
    }
}
