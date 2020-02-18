using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab3
{
    public class Nodo
    {
        public int id { get; set; }
        public int padre { get; set; }
        public List<int> hijos { get; set; }
        public List<Bebidas> values { get; set; }

        public int grado { get; set; }

        public bool EsHoja => hijos.Count == 0;

        public bool Minimo => values.Count == ((2*grado)-1)/3;

        public bool Maximo => values.Count == grado - 1;

        public bool MaximoRaiz => values.Count == ((4 / 3) * (grado - 1));

        
        }
    }
}
