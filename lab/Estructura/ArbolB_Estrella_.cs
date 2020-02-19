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

 
        public void Insertar(string N, string S, int V, double P, string C_P)
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
                raiz = new Nodo(7);
                raiz.values.Add(dato);
            }
            else
            {
                if (raiz.MaximoRaiz)//full
                {
                    // si esta lleno tira un true y se mete a este if para dividir la raiz 
                    // si ya esta lleno dividir la raiz
                    int mitad = raiz.values.Count / 2;
                    Subir_Elemento(mitad, raiz.values);
                }
                else
                { 
                    // sino esta al maximo tira un false que se mete al else para nada mas insertarlo
                    raiz.values.Add(dato);
                    raiz.values = raiz.values.OrderBy(x => x.Nombre).ToList();
                }
            }
        }
        public Bebidas Subir_Elemento(int mitad, List<Bebidas> nodo)
        {
            int num = 0;
            var nuevo_elemento = new Bebidas();
            foreach (var item in nodo)
            {
                if (num == mitad)
                {
                    nuevo_elemento = item;

                    break;
                }
                num++;
            }
            return nuevo_elemento;
        }

        // metodo para poder limpiar la raiz y asignarle el de en medio
        public void Limpiar()
        {
            raiz = new Nodo(grado);
        }

        public void InsertarElemento (Nodo NodoActual)
        {
            if (NodoActual.EsHoja)
            {
              
            }
        }







    }
}
