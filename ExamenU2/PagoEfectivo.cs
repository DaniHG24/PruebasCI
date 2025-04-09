
using System.Xml.Schema;

namespace ExamenU2
{
    public class PagoEfectivo : IPago
    {
        public double CalcularPago(double total)
        {
            return total * 0.95;
        }
    }
}
