using API.PagoTarjetaBancomer.Models;
using System;
using System.Collections.Generic;
using API.PagoTarjetaBancomer.Models;

namespace API.PagoTarjetaBancomer.Services
{
    public class Peticion
    {
        public string Afiliacion { get; private set; } = "";
        public string NumeroTerminal { get; private set; } = "";
        public Operacion OperacionActual { get; private set; }
        public Dictionary<ParametroOperacion, string> Parametros { get; private set; } = new();
        public Tarjeta Tarjeta { get; private set; }

        public void SetAfiliacion(string afiliacion, Moneda moneda) => Afiliacion = afiliacion;

        public void SetTerminal(string terminal, string mac) => NumeroTerminal = terminal;

        public void SetOperacion(Operacion operacion, Dictionary<ParametroOperacion, string> parametros)
        {
            OperacionActual = operacion;
            Parametros = parametros;
        }

        public Tarjeta LeerTarjeta()
        {
            Tarjeta = new Tarjeta
            {
                Pan = "4111111111111111",
                Tarjetahabiente = "CLIENTE DEMO",
                Emisor = "VISA",
                Nip = true
            };
            return Tarjeta;
        }

        public Respuesta Autorizar()
        {
            if (Tarjeta == null) LeerTarjeta();

            return new Respuesta
            {
                CodigoRespuesta = "00",
                Autorizacion = new Random().Next(100000, 999999).ToString(),
                Leyenda = "APROBADA",
                NumeroTarjeta = Tarjeta.Pan,
                Tarjetahabiente = Tarjeta.Tarjetahabiente,
                Afiliacion = Afiliacion,
                NumeroTerminal = NumeroTerminal
            };
        }
    }
}
