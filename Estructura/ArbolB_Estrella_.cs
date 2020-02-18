using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab3.Estructura
{
    public class ArbolB_Estrella_
    {
        private static ArbolB_Estrella_ _instance = null;
        public static ArbolB_Estrella_ Instance
        {
            get
            {
                if (_instance == null) _instance = new ArbolB_Estrella_();
                return _instance;
            }
        }
        public static int grado = 7;
        public Nodo raiz = null;
        public int ID { get; set; }
        public int Proxima { get; set; }
        static int valor_raiz = ((4 * (grado - 1)) / 3);
        
        #region Extras
        #endregion
        public void Add(string N, string S, int V, double P, string C_P)
        {
            var dato = new Bebidas()
            {
                Nombre = N,
                Sabor = S,
                Volumen = V,
                Precio = P,
                Casa_Productora = C_P
            };
            ID = 1;
            if (raiz == null)
            {
                raiz = new Nodo();
                raiz.values.add(dato);
                raiz.id = ID;
            }
            else
            {
                int num = 0;
                foreach (var espacio in raiz.values)
                {
                    if (espacio == null && num < valor_raiz)
                    {
                    raiz.values.add(dato);
                    raiz.values.Sort();
                        break;
                    }
                    num++;
                }
                if (num == valor_raiz)//full
                {
                    raiz.values.add(dato);
                    int mitad = raiz.values.lenght;
                    for (int i = 0; i < mitad; i++)
                    {

                    }
                }
            }
        }
    }
}
