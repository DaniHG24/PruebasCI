using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenU2
{
    class Program
    {
        static void Main(string[] args)
        {
            BicicletaPool pool = new BicicletaPool(); 

            while (true)
            {
                Console.WriteLine("\nMenú:");
                Console.WriteLine("1. Ver bicicletas disponibles");
                Console.WriteLine("2. Rentar bicicleta");
                Console.WriteLine("3. Devolver bicicleta");
                Console.WriteLine("4. Salir");
                Console.Write("Selecciona una opción: ");

                string opcion = Console.ReadLine();
                Console.Clear();

                switch (opcion)
                {
                    case "1":
                        pool.MostrarDisponibles();
                        break;
                    case "2":
                         pool.RentarBicicleta();
                        break;
                    case "3":
                        Console.WriteLine("\nBicicletas rentadas:");
                        pool.MostrarRentadas();

                        Console.Write("Ingresa el número de la bicicleta que deseas devolver (0 para cancelar): ");
                        if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0)
                        {
                            pool.DevolverBicicleta(indice - 1);
                        }
                        else
                        {
                            Console.WriteLine("Operación cancelada.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("¡Gracias por usar el sistema de renta de bicicletas!");
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}
