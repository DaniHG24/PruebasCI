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
                Console.Write($"¿Cuántas bicicletas de tipo {tipo} quieres crear?: ");
                if (int.TryParse(Console.ReadLine(), out int cantidad) && cantidad > 0)
                {

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
                        do
                        {
                            Console.Write("Ingrese el número de asientos: ");
                        }
                        while (!int.TryParse(Console.ReadLine(), out asientos) || asientos > 0);
                        Console.Write("Ingrese el material del cuadro: ");
                        string materialCuadro = Console.ReadLine();
                        Console.Write("Ingrese el tipo de frenos: ");
                        string tipoFrenos = Console.ReadLine();
                        Console.Write("Ingrese el número de velocidades: ");
                        int.TryParse(Console.ReadLine(), out int velocidades);
                        Bicicleta bicicleta1 = new BicicletaConstructor()
                            .SetTipo(tipo)
                            .SetTamanioRuedas(tamanioRuedas)
                            .SetColor(color)
                            .SetAsientos(asientos)
                            .SetMaterialCuadro(materialCuadro)
                            .SetTipoFrenos(tipoFrenos)
                            .SetVelocidades(velocidades)
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

            foreach (var bici in disponibles)
            {
                bici.MostrarDetalles();
            }
        }

        public Bicicleta RentarBicicleta()
        {
            MostrarDisponibles();
            Console.Write("Seleccione el número de la bicicleta que desea rentar: ");
            if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= disponibles.Count)
            {
                Bicicleta bici = disponibles[indice - 1];
                disponibles.RemoveAt(indice - 1);
                rentadas.Add(bici);
                Console.WriteLine("Has rentado la siguiente bicicleta:");
                bici.MostrarDetalles();
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
