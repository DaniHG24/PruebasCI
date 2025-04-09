
namespace ExamenU2
{
    public class PagoTarjeta : IPago
    {
        public double CalcularPago(double total)
        {
            return total * 1.05;
        }
    }
}
