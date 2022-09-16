using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilasYColasApp.clases.interfaces;

namespace PilasYColasApp.clases.implementaciones
{
    internal class Cola : IColleccion
    {
        public List<object> oCola;

        public Cola()
        {
            oCola = new List<object>();
        }

        public bool estaVacia()
        {
            if (oCola.Count <= 0)
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
            oCola.Add(obj);
            return true;
        }

        public object extraer()
        {
            object obj = null;
            if (estaVacia() == false)
            {
                obj = oCola[0];
                oCola.RemoveAt(0);
            }
            return obj;
        }

        public object primero()
        {
            object obj = null;
            if (estaVacia() == false)
            {
                obj = oCola[0];
            }
            return obj;
        }
    }
}
