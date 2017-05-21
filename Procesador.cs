using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas_FIFO_Atencion_de_procesos
{
    class Procesador
    {
        private Proceso inicio, actual;

        public Procesador()
        {
            inicio = null;
        }

        //Agregar (PUSH).
        public void agregarPush(Proceso nuevoPro)
        {
            if(inicio == null)
            {
                inicio = nuevoPro;
                nuevoPro.siguiente = inicio;
            }
            else
            {
                Proceso temp = inicio;
                while (temp.siguiente != inicio)
                {
                    temp = temp.siguiente;
                }
                temp.siguiente = nuevoPro;
                nuevoPro.siguiente = inicio;
            }
        }

        //Eliminar (POP).
        public Proceso eliminarPorCiclos(Proceso proEliminado)
        {
            Proceso temp = inicio;
            Proceso temp2 = proEliminado;

            actual = proEliminado.siguiente;

            if (temp.ciclos == proEliminado.ciclos)//Se quiere eliminar el inicio logico.
            {
                if (temp.siguiente == inicio)//Esto indica que solo hay una base.
                {
                    temp = null;
                    inicio = temp;
                    actual = null;
                }
                else//Si se desea eliminar el inicio logico pero hay mas bases.
                {
                    while (temp.siguiente != inicio)
                    {
                        temp = temp.siguiente;
                    }
                    temp.siguiente = inicio.siguiente;
                    inicio = inicio.siguiente;
                }
            }
            else//Si se quiere eliminar una base que no es el inicio logico.
            {
                while (temp.siguiente != inicio && temp.siguiente.ciclos != proEliminado.ciclos)
                {
                    temp = temp.siguiente;
                }
                if (temp.siguiente.ciclos == proEliminado.ciclos)//Comprueva que que sea la base a eliminar.
                {
                    temp.siguiente = temp.siguiente.siguiente;
                }
            }

            return temp2;
        }

        //Regresar el actual.
        public Proceso regresarActual()
        {
            return actual;
        }
        //Aavanzar el actual y regresar el actual.
        public Proceso regresarActualAvanzar()
        {
            if(inicio.siguiente == inicio)//Solo hay uno.
            {
                actual = inicio;
                return actual;
            }
            else//Hay mas de uno.
            {
                actual = actual.siguiente;
                return actual;
            }
        }
        //Regresar inicio.
        public Proceso regresarInicio()
        {
            return inicio;
        }
        //Método para regresar el total de ciclos 
        //de los procesos en la cola.
        public int regresarTotalCiclos()
        {
            Proceso temp = inicio;
            int totalCiclos = 0;
            while (temp.siguiente != inicio)
            {
                totalCiclos += temp.ciclos;
                temp = temp.siguiente;
            }
            totalCiclos += temp.ciclos;
            return totalCiclos;
        }

        public override string ToString()
        {
            Proceso temp = inicio;
            string cadena = "";
            while (temp.siguiente != inicio)
            {
                cadena += temp.ToString();
                temp = temp.siguiente;
            }
            cadena += temp.ToString();
            return cadena;
        }
    }
}
