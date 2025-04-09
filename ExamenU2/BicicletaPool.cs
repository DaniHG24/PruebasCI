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
        int cantidad = SolicitarCantidadBicicletas(tipo);
        for (int i = 0; i < cantidad; i++)
        {
            Console.WriteLine($"\nConfigurando bicicleta {i + 1} de tipo {tipo}:");
            Bicicleta bicicleta = ConfigurarBicicleta(tipo);
            disponibles.Add(bicicleta);
        }
    }
}

private int SolicitarCantidadBicicletas(TipoBicicleta tipo)
{
    int cantidad;
    do
    {
        Console.Write($"¿Cuántas bicicletas de tipo {tipo} quieres crear?: ");
    } while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0);
    return cantidad;
}

private Bicicleta ConfigurarBicicleta(TipoBicicleta tipo)
{
    int tamanioRuedas = SolicitarEntero("Ingrese el tamaño de las ruedas (pulgadas): ", 1);
    Console.Write("Ingrese el color de la bicicleta: ");
    string color = Console.ReadLine();
    int asientos = SolicitarEntero("Ingrese el número de asientos: ", 1);
    Console.Write("Ingrese el material del cuadro: ");
    string materialCuadro = Console.ReadLine();
    Console.Write("Ingrese el tipo de frenos: ");
    string tipoFrenos = Console.ReadLine();
    Console.Write("Ingrese el número de velocidades: ");
    int.TryParse(Console.ReadLine(), out int velocidades);

    return new BicicletaConstructor()
        .SetTipo(tipo)
        .SetTamanioRuedas(tamanioRuedas)
        .SetColor(color)
        .SetAsientos(asientos)
        .SetMaterialCuadro(materialCuadro)
        .SetTipoFrenos(tipoFrenos)
        .SetVelocidades(velocidades)
        .Build();
}

private int SolicitarEntero(string mensaje, int minimo)
{
    int valor;
    do
    {
        Console.Write(mensaje);
    } while (!int.TryParse(Console.ReadLine(), out valor) || valor < minimo);
    return valor;
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
