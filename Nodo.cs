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
        public list<int> hijos { get; set; }
        public list<Bebidas> values { get; set; }
        
    }
}
