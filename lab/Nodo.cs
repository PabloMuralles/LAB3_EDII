using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace lab3
{
    public class Nodo
    {
        public int id { get; set; }
        public int padre { get; set; }
        public List<int> hijos { get; set; }
        public List<Bebidas> Values { get; set; }



        public void EscribirNodo()
        {
            var InformacionNodo = string.Empty;

            InformacionNodo += ($"{id}| {padre} |");

            foreach (var item in hijos)
            {
                InformacionNodo += ($"{item}|");

            }

            foreach (var item in Values)
            {
                InformacionNodo += ($"{item}|");
            }

            
        }


    }
}
