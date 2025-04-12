
using System;

namespace ExamenU2
{
    public enum TipoBicicleta
    {
        Montaña,
        Deportiva,
        Pareja,
        Urbana
    }
    public class Bicicleta
    {
        public TipoBicicleta Tipo { get;  set; }
        public int TamanioRuedas { get;  set; }
        public string Color { get; set; }
        public int Asientos { get; set; }
        public string MaterialCuadro { get; set; }
        public string TipoFrenos { get; set; }
        public int Velocidades { get; set; }

        public Bicicleta() { }

        public void MostrarDetalles()
        {
            Console.WriteLine($"Tipo: {Tipo}, Tamaño Ruedas: {TamanioRuedas}\"");
            Console.WriteLine($"Color: {Color}, Asientos: {Asientos}");
            Console.WriteLine($"Material del Cuadro: {MaterialCuadro}");
            Console.WriteLine($"Tipo de Frenos: {TipoFrenos}");
            Console.WriteLine($"Velocidades: {Velocidades}");
            Console.WriteLine("-------------------------------------------------");
        }
    }
}
