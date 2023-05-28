using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusquedaGrafo
{
    class Grafo
    {
        private int[,] mAdyacencia;
        private int nodos;

        public Grafo(int pNodos)
        {
            nodos = pNodos;
            // Instanciamos la matriz de adyacencia como una matriz cuadrada simétrica
            mAdyacencia = new int[nodos, nodos];
        }

        public void AdicionarArista(int pNodo1, int pNodo2)
        {
            mAdyacencia[pNodo1, pNodo2] = 1;
            mAdyacencia[pNodo2, pNodo1] = 1; // Adicionamos la adyacencia en ambas direcciones
        }

        public void MuestraAdyacencia()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\t");
            for (int n = 0; n < nodos; n++)
                Console.Write("{0}\t", n);
            Console.WriteLine();

            for (int n = 0; n < nodos; n++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(n);
                for (int m = 0; m < nodos; m++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\t{0}", mAdyacencia[n, m]);
                }
                Console.WriteLine();
            }
        }

        public int ObtenerAdyacencia(int pNodo1, int pNodo2)
        {
            return mAdyacencia[pNodo1, pNodo2];
        }
    }
}