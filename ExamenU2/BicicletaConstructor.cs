using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenU2
{
    public class BicicletaConstructor
    {
        private Bicicleta _bicicleta = new Bicicleta();

        public BicicletaConstructor SetTipo(TipoBicicleta tipo) { _bicicleta.Tipo = tipo; return this; }
        public BicicletaConstructor SetTamanioRuedas(int tamanio) { _bicicleta.TamanioRuedas = tamanio; return this; }
        public BicicletaConstructor SetColor(string color) { _bicicleta.Color = color; return this; }
        public BicicletaConstructor SetAsientos(int asientos) { _bicicleta.Asientos = asientos; return this; }
        public BicicletaConstructor SetMaterialCuadro(string material) { _bicicleta.MaterialCuadro = material; return this; }
        public BicicletaConstructor SetTipoFrenos(string frenos) { _bicicleta.TipoFrenos = frenos; return this; }
        public BicicletaConstructor SetVelocidades(int velocidades) { _bicicleta.Velocidades = velocidades; return this; } 
            
        public Bicicleta Build() => _bicicleta;
    }
}
