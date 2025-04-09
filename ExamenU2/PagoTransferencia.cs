using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenU2
{
    public class PagoTransferencia : IPago
    {
        public double CalcularPago(double total)
        {
            return total * 1.05;
        }
    }
}
