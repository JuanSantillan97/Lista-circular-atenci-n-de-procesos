using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colas_FIFO_Atencion_de_procesos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static Random numAle = new Random();

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            //Clase procesador.
            Procesador procesadorIntel = new Procesador();

            //Componentes del Formulario.
            txtProcesosAtendidos.Clear();
            txtProcesosEspera.Clear();
            lblResultado.Text = "Resultados: ";

            //Variable para el número aleatorio.
            int probaNuevoProceso = 0;
            //Contadores.
            int cuantosAgregados = 0;
            int cuantosAtendidos = 0;
            int cuantosVacio = 0;

            //Variables para controlar el valor inicial del ciclo de un proceso.
            //Se usa con fines esteticos.
            //bool mantenerValor = true;
            //int valorCiclos = 0;

            for (int i = 1; i <= 200; i++)
            {
                //Agregar a la cola.
                probaNuevoProceso = numAle.Next(1, 100);
                if (probaNuevoProceso <= 25)
                {
                    Proceso procesoGamer = new Proceso();
                    procesadorIntel.agregarPush(procesoGamer);
                    cuantosAgregados++;
                }

                //Saber valor inicial del ciclo de un proceso. EXTRA
                //if (mantenerValor == true)
                //{
                //    if (procesadorIntel.regresarInicio() != null)
                //    {
                //        valorCiclos = procesadorIntel.regresarInicio().ciclos;
                //        mantenerValor = false;
                //    }
                //}

                //Nuevo método Eliminar.
                if (procesadorIntel.regresarInicio() != null)
                {
                    procesadorIntel.regresarActualAvanzar().disminuir();

                    if (procesadorIntel.regresarActual().ciclos == 0)
                    {
                        txtProcesosAtendidos.Text += "Vuelta: " + i + "   "  + procesadorIntel.eliminarPorCiclos(procesadorIntel.regresarActual()).ToString();
                        cuantosAtendidos++;
                        cuantosAgregados--;
                        //mantenerValor = true;
                    }
                }
                //Si inicio es null, quiere decir que la cola esta vacia.
                else
                {
                    cuantosVacio++;
                }
            }
            txtProcesosEspera.Text = procesadorIntel.ToString();

            lblResultado.Text += "\r\n" + "Total Espera: " + cuantosAgregados + "\r\n" +
                "Total Atendidos: " + cuantosAtendidos + "\r\n" +
                "Total Ciclos Vacios: " + cuantosVacio + "\r\n" +
                "Suma de Ciclos en espera: " + procesadorIntel.regresarTotalCiclos();
        }
    }
}
