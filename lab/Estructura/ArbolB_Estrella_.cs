using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab3.Estructura
{
    public class ArbolB_Estrella_
    {
        #region ARBOL
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
        public int numero = 0;
        public int ID { get; set; }
        public int Proxima { get; set; }
        static int valor_raiz = ((4 * (grado - 1)) / 3);
        public bool LiberarHoja = true;
        public int validar = 0;

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
                       
            Insertar(dato, numero);                       
        }      
        public void Insertar(Bebidas DatosInsertar, int num)
        {
            if (raiz == null)
            {
                raiz = new Nodo();
                raiz.values.Add(DatosInsertar);
            }
            else
            { 
                if (raiz.MaximoRaiz)//full
                {
                    int mitad = raiz.values.Count / 2;
                    var NuevoElmento =Subir_Elemento(mitad, raiz.values);
                    raiz.values.Add(DatosInsertar);
                    Primeradivision(raiz, num, NuevoElmento);                     
                }
                if (LiberarHoja)
                {
                    raiz.values.Add(DatosInsertar);
                    raiz.values = Ordenar(raiz.values);
                }
                if (validar == 1) // hijos de la raiz
                {
                    if (raiz.values[raiz.values.Count - 1].Nombre.CompareTo(DatosInsertar.Nombre) < 0) // -1 porque es menor a la raiz
                    {
                        if (raiz.hijos[num +1].values.Count < grado -1)
                        {
                        raiz.hijos[num+1].values.Add(DatosInsertar);
                        }
                        else
                        {                            
                           if (raiz.hijos[num].values.Count <  grado -1 ) /// && raiz.hijos[2] == null
                            {
                                raiz.hijos[num + 1].values.Add(DatosInsertar);
                            var salida = raiz.values[0];
                            raiz.values.RemoveAt(num);
                            raiz.hijos[num].values.Add(salida);
                            raiz.values.Add(raiz.hijos[num + 1].values[0]);
                            raiz.hijos[num + 1].values.RemoveAt(0);                                   
                          }
                            else
                            {
                                raiz.hijos[num + 1].values.Add(DatosInsertar);
                                int mitad = (raiz.hijos[num + 1].values.Count) / 2;
                                var nuevo_elemento = Subir_Elemento(mitad , raiz.hijos[num+1].values);
                                raiz.values.Add(nuevo_elemento);
                                raiz.hijos[num + 2] = new Nodo();
                                raiz.hijos[num + 2].id = 4;
                                raiz.hijos[num + 2].padre = raiz;
                                var derecho = Der(mitad, raiz.hijos[num +1].values);
                                Ordenar(derecho);
                                var Izquierdo = Izq(mitad, raiz.hijos[num + 1].values);
                                Ordenar(Izquierdo);
                                raiz.hijos[num + 2].values = derecho;
                                raiz.hijos[num+1].values = Izquierdo;
                                numero++;
                            }                                                                                 
                        }
                    }
                    else
                    {                        
                        //if (raiz.hijos[num].values.Count < grado -1)
                        //{
                        // raiz.hijos[num].values.Add(DatosInsertar);
                        //}
                        //else
                        //{
                        //    int busqueda = 0;
                        //    foreach (var item in raiz.hijos)
                        //    {
                        //        if (raiz.hijos[busqueda].values.Count < grado - 1)
                        //        {
                        //            raiz.hijos[num].values.Add(DatosInsertar);
                        //            var salida = raiz.values[0];
                        //            raiz.values.RemoveAt(0);
                        //            raiz.hijos[num + 1].values.Add(salida);
                        //            raiz.values.Add(raiz.hijos[num].values[0]);
                        //            raiz.hijos[num ].values.RemoveAt(0);
                        //            break;
                        //        }
                        //        busqueda++;
                        //    }
                        //}
                        
                    }                   
                }
                if (LiberarHoja == false)
                {
                    validar =  1;
                }
            }
        }
        public void Primeradivision(Nodo PrimerNodo, int num, Bebidas elementoRaiz)
        {
            int mitad = PrimerNodo.values.Count / 2;
            PrimerNodo.hijos[num] = new Nodo();
            var Izquierdo = Izq(mitad, PrimerNodo.values);
            PrimerNodo.hijos[num].values = Izquierdo;
            PrimerNodo.hijos[num].id = 2;
            PrimerNodo.hijos[num].padre = PrimerNodo;
            PrimerNodo.hijos[num + 1] = new Nodo();
            PrimerNodo.hijos[num + 1].id = 3;
            PrimerNodo.hijos[num + 1].padre = PrimerNodo;
            var Derecho = Der(mitad, PrimerNodo.values);
            PrimerNodo.hijos[num + 1].values = Derecho;
            PrimerNodo.values.Clear();
            PrimerNodo.values.Add(elementoRaiz);
            LiberarHoja = false;
        }
        public List<Bebidas> Der(int mitad, List<Bebidas> nodo)
        {
            int num = nodo.Count;
            var nuevo_elemento = new List<Bebidas>();
            foreach (var item in nodo)
            {
                if (num < mitad+1)
                {
                    nuevo_elemento.Add(item);
                }
                num--;
            }
            return nuevo_elemento;
        }
        public List<Bebidas> Izq(int mitad, List<Bebidas> nodo)
        {
            int num = 0;
            var nuevo_elemento = new List<Bebidas>();

            foreach (var item in nodo)
            {
                if (num < mitad )
                {
                    nuevo_elemento.Add(item);
                }
                num++;
            }       
            return nuevo_elemento;
        }
        //public void DividirNodo(Nodo NodoSeparar)
        //{
        //    int mitad = NodoSeparar.values.Count / 2;
        //    int DatosMaximos = grado - 1;
        //    int CantidadHijos = grado;

        //    Nodo TempIzquierdo = new Nodo();
        //    Nodo TempDerecho = new Nodo();
        //    Nodo TempPadre = new Nodo();

        //    TempDerecho.padre = NodoSeparar.padre;
        //    TempIzquierdo.padre = NodoSeparar.padre;
        //    TempPadre.values.Add(Subir_Elemento(mitad,NodoSeparar.values));

        //    if (NodoSeparar.hijos.Length!=0)
        //    {
        //        for (int i = 0; i < NodoSeparar.hijos.Length/2; i++)
        //        {
        //            TempIzquierdo.hijos[i] = (NodoSeparar.hijos[i]);

        //        }
        //        for (int i = NodoSeparar.hijos.Length / 2; i < NodoSeparar.hijos.Length; i++)
        //        {
        //            TempDerecho.hijos[i] = (NodoSeparar.hijos[i]);

        //        }
        //    }
        //    for (int i = 0; i < mitad; i++)
        //    {
        //        TempIzquierdo.values.Add(NodoSeparar.values[i]);
        //        TempIzquierdo.values = Ordenar(TempIzquierdo.values);
        //    }
        //    for (int i = NodoSeparar.values.Count-1; i < mitad; i--)
        //    {
        //        TempDerecho.values.Add(NodoSeparar.values[i]);
        //        TempDerecho.values = Ordenar(TempDerecho.values);
        //    }



        //}
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
        #endregion


        #region Recorido

        public List<Bebidas> Registros = new List<Bebidas>();
        public void RetornoInformacion(Nodo RaizResgistro)
        {
            if (RaizResgistro!=null)
            {


                if (RaizResgistro.hijos[0] == null)
                {
                    foreach (var item in RaizResgistro.values)
                    {
                        if (item != null)
                        {
                            Registros.Add(item);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grado; i++)
                    {


                        if (RaizResgistro.hijos[i] != null)
                        {
                            RetornoInformacion(RaizResgistro.hijos[i]);

                            if (i != (grado - 1))
                            {
                                if (RaizResgistro.values[i] != null)
                                {

                                    Registros.Add(RaizResgistro.values[i]);

                                }
                            }



                        }
                        else
                        {


                            break;
                        }

                    }
                }

            }
            else
            {
                throw new Exception("el arbol no tiene datos");
            }
        }

        public List<Bebidas> IngresarRetorno()
        {
            Registros.Clear();

            RetornoInformacion(raiz);

            return Registros;





        }
        #endregion

        #region Busqueda
        public Bebidas Buscar(string _nombre)
        {
            Bebidas bebida = raiz.Busqueda(_nombre);
            return bebida;
        }
        #endregion

    }
}
