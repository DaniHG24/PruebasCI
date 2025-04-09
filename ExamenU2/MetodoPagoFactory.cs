using System;

namespace ExamenU2
{
    public class MetodoPagoFactory
    {
        public static IPago ObtenerMetodoPago(string metodo)
        {
            switch (metodo.ToLower())
            {
                case "efectivo":
                    return new PagoEfectivo();
                case "paypal":
                    return new PagoPayPal();
                case "tarjeta":
                    return new PagoTarjeta();
                default:
                    throw new ArgumentException("Método de pago no válido");
            }
        }
    }
}
