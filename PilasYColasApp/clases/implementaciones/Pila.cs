using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PilasYColasApp.clases.interfaces;

namespace PilasYColasApp.clases.implementaciones
{

    public class Pila : IColleccion
    {
        public object[] oPila;
        int contador = -1;

        public Pila(int max)
        {
            oPila = new object[max];
        }

        public bool pilaLlena()
        {
            if (contador == oPila.Length - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool estaVacia()
        {
            if (contador == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool añadir(object obj)
        {
            if (pilaLlena() == false)
            {
                contador++;
                oPila[contador] = obj;
                return true;
            }
            else
            {
                return false;
            }
        }

        public object extraer()
        {
            object obj = null;
            if (estaVacia() == false)
            {
                obj = oPila[0];
                for(int i = 0; i<oPila.Length ; i++)
                {
                    if (i != oPila.Length-1 && oPila[i]!=null)
                    {
                        oPila[i] = oPila[i + 1];
                    }
                    else
                    {
                        oPila[i] = null;
                    }
                }
                contador--;

            }
            return obj;
        }

        public object primero()
        {
            object obj = null;
            if (estaVacia() == false)
            {
                obj = oPila[0];

            }
            return obj;
        }
    }
}
