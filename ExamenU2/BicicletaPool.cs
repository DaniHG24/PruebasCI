using System;
using System.Collections.Generic;

namespace ExamenU2
{
   
    class BicicletaPool
    {
        private List<Bicicleta> disponibles = new List<Bicicleta>();
        private List<Bicicleta> rentadas = new List<Bicicleta>();

        public BicicletaPool()
        {
            ConfigurarBicicletas();
        }

        private void ConfigurarBicicletas()
        {
            Console.WriteLine("\nConfigura la cantidad de bicicletas disponibles:");

            foreach (TipoBicicleta tipo in Enum.GetValues(typeof(TipoBicicleta)))
            {
                int cantidad;
                do
                {
                    Console.Write($"¿Cuántas bicicletas de tipo {tipo} quieres crear?: ");
                } while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad < 0);
                
                if (cantidad > 0)
                {
                    Console.WriteLine("En caso de ingresar valores invalidos se repetira la pregunta");

                    for (int i = 0; i < cantidad; i++)
                    {
                        Console.WriteLine($"\nConfigurando bicicleta {i + 1} de tipo {tipo}:");
                        int tamanioRuedas;
                        do
                        {
                            Console.Write("Ingrese el tamaño de las ruedas (pulgadas): ");
                        } while (!int.TryParse(Console.ReadLine(), out tamanioRuedas) || tamanioRuedas <= 0);
                        Console.Write("Ingrese el color de la bicicleta: ");
                        string color = Console.ReadLine();
                        int asientos;
                        if (tipo == TipoBicicleta.Pareja)
                            asientos = 2;
                        else
                            asientos = 1;
                        Console.Write("Ingrese el material del cuadro: ");
                        string materialCuadro = Console.ReadLine();
                        Console.Write("Ingrese el tipo de frenos: ");
                        string tipoFrenos = Console.ReadLine();
                        int velocidades;
                        do { 
                            Console.Write("Ingrese el número de velocidades: ");}
                        while (!int.TryParse(Console.ReadLine(),out velocidades) || velocidades <= 0);
                        double precio;
                        do
                        {
                            Console.Write("Ingrese el precio: ");
                        }
                        while (!double.TryParse(Console.ReadLine(), out precio) || precio <= 0);
                        Console.Clear();
                        Bicicleta bicicleta1 = new BicicletaConstructor()
                            .SetTipo(tipo)
                            .SetTamanioRuedas(tamanioRuedas)
                            .SetColor(color)
                            .SetAsientos(asientos)
                            .SetMaterialCuadro(materialCuadro)
                            .SetTipoFrenos(tipoFrenos)
                            .SetVelocidades(velocidades)
                            .SetPrecio(precio)
                            .Build();

                        disponibles.Add(bicicleta1);
                    }
                }
            }
        }

        public void MostrarDisponibles()
        {
            Console.WriteLine("\nBicicletas Disponibles:");
            if (disponibles.Count == 0)
            {
                Console.WriteLine("No hay bicicletas disponibles.");
                return;
            }

            for(int i = 0; i < disponibles.Count; i++)
            {
                Console.WriteLine("No. " + (i+1));
                disponibles[i].MostrarDetalles();
            }
        }

        public Bicicleta RentarBicicleta()
        {
            MostrarDisponibles();
            Console.WriteLine("En caso de ingresar valores invalidos se repetira la pregunta");
            int indice;
            do
            {
                Console.Write("Seleccione el número de la bicicleta que desea rentar: ");
            } while (!int.TryParse(Console.ReadLine(), out indice) || indice <= 0 || indice > disponibles.Count);
            
            if (indice > 0 && indice <= disponibles.Count)
            {
                Bicicleta bici = disponibles[indice - 1];
                disponibles.RemoveAt(indice - 1);
                rentadas.Add(bici);
                int horas;
                do
                {
                    Console.Write("Ingrese la cantidad de horas que rentará la bicicleta: ");
                } while (!int.TryParse(Console.ReadLine(), out horas) || horas <= 0);

                double subtotal = bici.Precio * horas;
                Console.WriteLine($"Subtotal: ${subtotal}");
                Console.WriteLine("En caso de pagar con trajeta se le cobrara un 5% de comisión");
                string metodo;
                do
                {
                    Console.Write("Seleccione método de pago (Efectivo, PayPal, Tarjeta): ");
                    metodo = Console.ReadLine().ToLower();
                } while (metodo != "efectivo" && metodo != "paypal" && metodo != "tarjeta");
                    IPago pago = MetodoPagoFactory.ObtenerMetodoPago(metodo);
                    double total = pago.CalcularPago(subtotal);
                    Console.WriteLine($"Total: {total}");

                return bici;
            }
            else
            {
                Console.WriteLine("Selección no válida.");
                return null;
            }
        }

        public void MostrarRentadas()
        {
            if (rentadas.Count == 0)
            {
                Console.WriteLine("No tienes bicicletas rentadas.");
                return;
            }

            for (int i = 0; i < rentadas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {rentadas[i].Tipo} - {rentadas[i].Color}");
            }
        }

        public void DevolverBicicleta(int indice)
        {
            if (indice >= 0 && indice < rentadas.Count)
            {
                Bicicleta bici = rentadas[indice];
                rentadas.RemoveAt(indice);
                disponibles.Add(bici);
                Console.WriteLine("Bicicleta devuelta correctamente.");
            }
            else
            {
                Console.WriteLine("Índice no válido.");
            }
        }
    }
}
