using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab3
{
    public class Nodo
    {

        public int id { get; set; }
        public Nodo padre { get; set; }
        public Nodo[] hijos { get; set; }
        public List<Bebidas> values { get; set; }
        public static int grado = 5;
        public Nodo()
        {
            hijos = new Nodo[grado];
            values = new List<Bebidas>();
                              
        }

       
        public int MAX()
        {
            int max = (4*(grado-1)/3);
            if (max%2!=0)
            {
                max = max + 1;
            }
            return max;
        }

        public bool EsHoja => hijos.Length == 0;

        public bool Minimo => values.Count == ((2 * grado) - 1) / 3;

        public bool Maximo => values.Count == grado - 1;

       
        public bool MaximoRaiz => values.Count == MAX();





    }
}
