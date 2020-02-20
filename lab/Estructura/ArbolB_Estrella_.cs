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
        public static int grado = 5;
        public Nodo raiz = null;
        public int ID { get; set; }
        public int Proxima { get; set; }
        static int valor_raiz = ((4 * (grado - 1)) / 3);

        public void Creacion(string N, string S, int V, double P, string C_P)
        {
            var dato = new Bebidas()
            {
                Nombre = N,
                Sabor = S,
                Volumen = V,
                Precio = P,
                Casa_Productora = C_P
            };

            Insertar(dato);

        }

      
        public void Insertar(Bebidas DatosInsertar)
        {
           
            ID = 1;
            if (raiz == null)
            {
                raiz = new Nodo();
                raiz.values.Add(DatosInsertar);
            }
            else
            {
                if (raiz.MaximoRaiz)//full
                {
                    // si esta lleno tira un true y se mete a este if para dividir la raiz 
                    // si ya esta lleno dividir la raiz
                    Primeradivision(raiz);
                    //DividirNodo(raiz);
                     //var NuevoElmento =Subir_Elemento(mitad, raiz.values);
                }
                else
                { 
                    // sino esta al maximo tira un false que se mete al else para nada mas insertarlo
                    raiz.values.Add(DatosInsertar);
                    raiz.values = Ordenar(raiz.values);
                }
            }
        }
        public void Primeradivision(Nodo PrimerNodo)
        {
            int mitad = PrimerNodo.values.Count / 2;
            for (int i = 0; i < grado + 1; i++)
            {
              
                for (int j = 0; j < mitad; j++)
                {
                     PrimerNodo.hijos[i].values[i] = new Bebidas();
                    PrimerNodo.hijos[i].values.Add(PrimerNodo.values[j]);
                }
                for (int k = PrimerNodo.hijos[i].values.Count -1 ; i < mitad ; k--)
                {
                    PrimerNodo.hijos[i + 1].values.Add(PrimerNodo.values[k]);
                }               
            }            
        }
        public void DividirNodo(Nodo NodoSeparar)
        {
            int mitad = NodoSeparar.values.Count / 2;
            int DatosMaximos = grado - 1;
            int CantidadHijos = grado;

            Nodo TempIzquierdo = new Nodo();
            Nodo TempDerecho = new Nodo();
            Nodo TempPadre = new Nodo();

            TempDerecho.padre = NodoSeparar.padre;
            TempIzquierdo.padre = NodoSeparar.padre;
            TempPadre.values.Add(Subir_Elemento(mitad,NodoSeparar.values));

            if (NodoSeparar.hijos.Count!=0)
            {
                for (int i = 0; i < NodoSeparar.hijos.Count/2; i++)
                {
                    TempIzquierdo.hijos.Add(NodoSeparar.hijos[i]);

                }
                for (int i = NodoSeparar.hijos.Count / 2; i < NodoSeparar.hijos.Count; i++)
                {
                    TempDerecho.hijos.Add(NodoSeparar.hijos[i]);

                }
            }
            for (int i = 0; i < mitad; i++)
            {
                TempIzquierdo.values.Add(NodoSeparar.values[i]);
                TempIzquierdo.values = Ordenar(TempIzquierdo.values);
            }
            for (int i = NodoSeparar.values.Count-1; i < mitad; i--)
            {
                TempDerecho.values.Add(NodoSeparar.values[i]);
                TempDerecho.values = Ordenar(TempDerecho.values);
            }



        }
        public List<Bebidas> Ordenar(List<Bebidas> NodoOrdenar)
        {
            var ListaOrdenada=NodoOrdenar.OrderBy(x => x.Nombre).ToList();
            return ListaOrdenada;
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
            raiz = new Nodo();
        }

        public void InsertarElemento (Nodo NodoActual)
        {
            if (NodoActual.EsHoja)
            {
              
            }
        }







    }
}
