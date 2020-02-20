using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab3
{
    public class Nodo
    {

        public Nodo padre;
        public int id;
        public List<Bebidas> valores = new List<Bebidas>();
        public List<Nodo> hijos = new List<Nodo>();


    }
}
