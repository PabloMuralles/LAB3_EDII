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

        public bool EsHoja => hijos == null;

        public bool Minimo => values.Count == ((2 * grado) - 1) / 3;

        public bool Maximo => values.Count == grado - 1;

       
        public bool MaximoRaiz => values.Count == MAX();


        #region Busqueda_nodo


        private static Bebidas BebidaBuscada = new Bebidas();

        public Bebidas Busqueda(string nombre)
        {

            for (int i = 0; i < grado - 1; i++)
            {
                if (values[i] != null)
                {
                    if (String.Compare(nombre, values[i].Nombre) == -1)
                    {
                        if (hijos[0] != null)
                        {
                            hijos[i].Busqueda(nombre);
                        }

                    }

                    if (String.Compare(nombre, values[i].Nombre) == 1)
                    {
                        if (hijos[0] != null)
                        {
                            if (values[i + 1] == null)
                            {
                                hijos[i + 1].Busqueda(nombre);
                            }
                            else
                            {
                                if (String.Compare(nombre, values[i + 1].Nombre) == -1)
                                {
                                    hijos[i].Busqueda(nombre);
                                }
                            }
                        }

                    }


                    if (String.Compare(nombre, values[i].Nombre) == 0)
                    {
                        BebidaBuscada.Nombre = values[i].Nombre;
                        BebidaBuscada.Sabor = values[i].Sabor;
                        BebidaBuscada.Volumen = values[i].Volumen;
                        BebidaBuscada.Precio = values[i].Precio;
                        BebidaBuscada.Casa_Productora = values[i].Casa_Productora;

                        break;
                    }
                }
            }
            return BebidaBuscada;
        }

        #endregion



    }
}
