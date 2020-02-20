using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace lab3.Estructura
{
    public class ArbolB_Estrella_
    {
       
        int orden = 5;
        int datosMaximos;
        int idNodo = 2;
        int cantidadDatos = 0;
        bool raizLlena = false;
        public List<Nodo> listaTempArbol = new List<Nodo>();

        public Nodo raiz = null;
  
        public void Insertar(Bebidas nuevo)
        {
            cantidadDatos++;

            if (raiz == null)
            {

                raiz = new Nodo();
                raiz.id = 1;
                insertar(raiz, nuevo);
                return;
            }
            Nodo temporal = raiz;
            if (cantidadDatos > orden) raizLlena = true;
            if (raizLlena == false)
            {
                bool valorRepetido = false;
              
                if (valorRepetido == false)
                {
                    insertar(raiz, nuevo);
                }
                else { throw new ArgumentException(); }
            }
            if (raizLlena == true)
            {
                Nodo posicionLibre = new Nodo();
                posicionLibre = buscarPosicionLibre(temporal, nuevo);
                insertar(posicionLibre, nuevo);


            }

        }
        public Nodo buscarPosicionLibre(Nodo nodoPosicion, Bebidas nuevo)
        {
            if (nodoPosicion.hijos.Count != 0)
            {

                if (nodoPosicion.valores.Count() > 1)
                {
                    if (nodoPosicion.valores[0].CompareTo(nuevo) == 0 || nodoPosicion.valores[1].CompareTo(nuevo) == 0 || nodoPosicion.valores[nodoPosicion.valores.Count() - 1].CompareTo(nuevo) == 0 || nodoPosicion.valores[nodoPosicion.valores.Count() - 2].CompareTo(nuevo) == 0)
                    {
                        return null;
                    }
                    if (nodoPosicion.valores[0].CompareTo(nuevo) == 1 && nodoPosicion.valores[1].CompareTo(nuevo) == 1)
                    {
                        return buscarPosicionLibre(nodoPosicion.hijos[0], nuevo);
                    }
                    if (nodoPosicion.valores[0].CompareTo(nuevo) == -1 && nodoPosicion.valores[1].CompareTo(nuevo) == 1)
                    {
                        return buscarPosicionLibre(nodoPosicion.hijos[1], nuevo);
                    }
                    if (nodoPosicion.valores[1].CompareTo(nuevo) == 1 && nodoPosicion.valores[nodoPosicion.valores.Count() - 1].CompareTo(nuevo) == -1)
                    {
                        return buscarPosicionLibre(nodoPosicion.hijos[2], nuevo);
                    }
                    if (nodoPosicion.valores[nodoPosicion.valores.Count() - 2].CompareTo(nuevo) == -1 && nodoPosicion.valores[nodoPosicion.valores.Count() - 1].CompareTo(nuevo) == -1)
                    {
                        return buscarPosicionLibre(nodoPosicion.hijos[nodoPosicion.valores.Count()], nuevo);
                    }


                }
                else
                {
                    if (nodoPosicion.valores[0].CompareTo(nuevo) == +1)
                    {
                        return buscarPosicionLibre(nodoPosicion.hijos[0], nuevo);
                    }
                    if (nodoPosicion.valores[0].CompareTo(nuevo) == -1)
                    {
                        return buscarPosicionLibre(nodoPosicion.hijos[1], nuevo);
                    }
                    if (nodoPosicion.valores[0].CompareTo(nuevo) == 0 || nodoPosicion.valores[1].CompareTo(nuevo) == 0)
                    {
                        throw new ArgumentException();
                    }

                }
            }
            return nodoPosicion;
        }
        public void insertar(Nodo nodo, Bebidas nuevo)
        {
            if (nodo.hijos == null || nodo.valores.Count < datosMaximos)
            {
                nodo.valores.Add(nuevo);

                if (nodo.id == 0)
                {
                    nodo.id = idNodo++;
                }
                ordenarValores(nodo.valores);
                listaTempArbol.Add(nodo);
            }
            else
            {
                nodo.valores.Add(nuevo);
                ordenarValores(nodo.valores);
                separarNodos(nodo);
                listaTempArbol.Add(nodo);
            }
        }

        void ordenarValores(List<Bebidas> aOrdenar)
        {
            aOrdenar.Sort();
        }
        void ordenarHijos(List<Nodo> hijosOrdenar)
        {
            Nodo aux;
            for (int i = 0; i < hijosOrdenar.Count - 1; i++)
            {
                for (int j = i + 1; j < hijosOrdenar.Count; j++)
                {
                    if (hijosOrdenar[i].valores[0].CompareTo(hijosOrdenar[j].valores[0]) == 1)
                    {
                        aux = hijosOrdenar[i];
                        hijosOrdenar[i] = hijosOrdenar[j];
                        hijosOrdenar[j] = aux;
                    }
                }
            }

        }
        void ordenarLista(List<Nodo> listaOrdenar)
        {
            Nodo aux;
            for (int i = 0; i < listaOrdenar.Count - 1; i++)
            {
                for (int j = i + 1; j < listaOrdenar.Count; j++)
                {
                    if (listaOrdenar[i].id.CompareTo(listaOrdenar[j].id) == 1)
                    {
                        aux = listaOrdenar[i];
                        listaOrdenar[i] = listaOrdenar[j];
                        listaOrdenar[j] = aux;
                    }
                }
            }
        }
        void separarNodos(Nodo nodoSeparar)
        {
            int cantidadHijos = orden;
            if (orden % 2 != 0)//separar a la mitad
            {
                Nodo temporalIzquierdo = new Nodo();
                Nodo temporalDerecho = new Nodo();
                Nodo temporalRaiz = new Nodo();
                temporalDerecho.padre = nodoSeparar.padre;
                temporalIzquierdo.padre = nodoSeparar.padre;
                temporalRaiz.valores.Add(nodoSeparar.valores.ElementAt(datosMaximos / 2));
                if (nodoSeparar.hijos.Count != 0)
                {
                    for (int i = 0; i < nodoSeparar.hijos.Count / 2; i++)
                    {
                        temporalIzquierdo.hijos.Add(nodoSeparar.hijos[i]);
                    }
                    for (int i = (nodoSeparar.hijos.Count / 2); i < nodoSeparar.hijos.Count; i++)
                    {
                        temporalDerecho.hijos.Add(nodoSeparar.hijos[i]);
                    }
                }
                for (int i = 0; i < datosMaximos / 2; i++)
                {
                    temporalIzquierdo.valores.Add(nodoSeparar.valores.ElementAt(i));
                    ordenarValores(temporalIzquierdo.valores);
                }
                for (int i = datosMaximos; i > (datosMaximos / 2); i--)
                {
                    temporalDerecho.valores.Add(nodoSeparar.valores.ElementAt(i));
                    ordenarValores(temporalDerecho.valores);
                }
                if (nodoSeparar != raiz)
                {
                    List<Nodo> temporal = new List<Nodo>();
                    foreach (var temp in nodoSeparar.padre.hijos)
                    {
                        temporal.Add(temp);
                    }
                    temporal.Remove(nodoSeparar);
                    nodoSeparar.padre.hijos.Clear();
                    nodoSeparar.padre.hijos.Add(temporalIzquierdo);
                    nodoSeparar.padre.hijos.Add(temporalDerecho);
                    foreach (var temp in temporal)
                    {
                        nodoSeparar.padre.hijos.Add(temp);
                    }
                    ordenarHijos(nodoSeparar.padre.hijos);
                    nodoSeparar.padre.valores.Add(temporalRaiz.valores[0]);
                    ordenarValores(nodoSeparar.padre.valores);
                    ordenarHijos(nodoSeparar.padre.hijos);
                    temporalIzquierdo.id = nodoSeparar.id;
                    temporalDerecho.id = idNodo++;
                    if (nodoSeparar.padre.valores.Count > datosMaximos)
                    {
                        separarNodos(nodoSeparar.padre);
                    }
                }
                if (nodoSeparar == raiz)
                {
                    raiz.valores.Clear();
                    temporalRaiz.id = nodoSeparar.id;
                    raiz = temporalRaiz;
                    temporalDerecho.padre = raiz;
                    temporalIzquierdo.padre = raiz;
                    temporalIzquierdo.id = idNodo++;
                    temporalDerecho.id = idNodo++;
                    if (temporalIzquierdo.hijos.Count != 0)
                    {
                        foreach (var hijos in temporalIzquierdo.hijos)
                        {
                            hijos.padre = temporalRaiz;
                        }
                    }
                    if (temporalDerecho.hijos.Count != 0)
                    {
                        foreach (var hijos in temporalDerecho.hijos)
                        {
                            hijos.padre = temporalRaiz;
                        }
                    }
                    raiz.hijos.Add(temporalIzquierdo);
                    raiz.hijos.Add(temporalDerecho);
                }

            }


        }
       
      
      
        public void buscar(Bebidas datoBuscado)
        {
            Nodo nodoBuscado = buscarValor(datoBuscado, raiz);
            int indiceValor = 0;
            foreach (var datos in nodoBuscado.valores)
            {
                if (datoBuscado.CompareTo(datos) == 0)
                {
                    return;
                }
                else { indiceValor++; }
            }

        }
        
        public void listaTemp()
        {
            if (listaTempArbol.Count == 0)
            {
                listaTempArbol.Add(raiz);
            }
            foreach (var nodo in raiz.hijos)
            {
                listaTempArbol.Add(nodo);
                //while (nodo.hijos.Count != 0)
                {
                    for (int i = 0; i < nodo.hijos.Count; i++)
                    {
                        if (listaTempArbol.Contains(nodo.hijos[i]) == false)
                        {
                            listaTempArbol.Add(nodo.hijos[i]);
                        }

                    }
                }
            }
        }
        public void recorrido(Nodo nodito)
        {
            if (!ArbolVacio(nodito))
            {
                if (nodito.hijos.Count != 0)

                {
                    recorrido(nodito.hijos[0]);
                    for (int i = 0; i < nodito.hijos.Count; i++)
                    {
                        listaTempArbol.Add(nodito.hijos[i]);
                        recorrido(nodito.hijos[i]);
                    }

                }
                else
                {
                    if (listaTempArbol.Contains(nodito) == false)
                    {
                        listaTempArbol.Add(nodito);
                    }
                }
            }
        }
        public static bool ArbolVacio(Nodo nodito) => nodito == null;
        public void archivoTexto(string nombreArchivo)
        {
            using (StreamWriter writer = new StreamWriter("C:/microSQL/" + nombreArchivo + "B.txt"))
            {
                writer.WriteLine("Orden " + orden);
                writer.WriteLine("Raiz " + raiz.id);
                writer.WriteLine("Posicion " + idNodo);
                listaTemp();
                ordenarLista(listaTempArbol);
                foreach (var nodo in listaTempArbol)
                {
                    if (nodo.padre == null)
                    {
                        writer.Write(nodo.id + "|0|");
                    }
                    else
                    {
                        writer.Write(nodo.id + "|" + nodo.padre.id + "|");
                    }
                    foreach (var nodosHijos in nodo.hijos)
                    {
                        writer.Write(nodosHijos.id + "|");
                    }
                    foreach (var valores in nodo.valores)
                    {
                        writer.Write(valores + "|");
                    }
                }

            }
        }







    }
}
