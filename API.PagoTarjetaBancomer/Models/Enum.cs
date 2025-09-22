namespace API.PagoTarjetaBancomer.Models
{
    public enum Moneda { Pesos, Dolares }

    public enum Firma { SinFirma = 0, Autografa = 1, Electronica = 2 }

    public enum Operacion
    {
        Venta,
        Devolucion,
        CancelacionVenta,
        CancelacionDevolucion
    }
}
