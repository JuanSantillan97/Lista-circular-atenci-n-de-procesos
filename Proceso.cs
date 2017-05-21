using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas_FIFO_Atencion_de_procesos
{
    class Proceso
    {
        public Proceso siguiente;
        static Random numAle = new Random();

        private int _ciclos;
        public int ciclos
        {
            get { return _ciclos; }
            set { _ciclos = ciclos; }
        }

        public Proceso()
        {
            _ciclos = numAle.Next(4, 12);
        }

        public void disminuir()
        {
            _ciclos--;
        }

        public override string ToString()
        {
            return "Ciclos: " + _ciclos + "\r\n";
        }

    }
}
