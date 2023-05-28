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
        private int[] indegree;
        private int nodos;
        public Grafo(int pNodos)
        {
            nodos = pNodos;
            //instanciamos la matriz de adayacencia
            mAdyacencia = new int[nodos, nodos];
            // Instanciamos arrglo de indegree
            indegree = new int[nodos];
        }
        public void AdicionarArista(int pNodoInicio, int pNodoFinal)
        {
            mAdyacencia[pNodoInicio, pNodoFinal] = 1;
        }
        public void MuestraAdyacencia()
        {
            int n = 0;
            int m = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (n = 0; n < nodos; n++)
                Console.Write("\t{0}",n);
            Console.WriteLine();
            for (n=0; n<nodos; n++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(n);
                for (m = 0; m < nodos; m++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\t{0}", mAdyacencia[n,m]);
                }
                Console.WriteLine();
            }
        }
        public int ObtenerAdyacencia(int pFila, int pColumna)
        {
            return mAdyacencia[pFila, pColumna];
        }
        public void CalcularIndegree()
        {
            int n = 0;
            int m = 0;
            for (n = 0; n < nodos; n++)
            {
                for (m = 0; m < nodos; m++)
                {
                    if (mAdyacencia[m,n] == 1)
                        indegree[n]++;
                }
            }
        }

        public int EncuentraI0()
        {
            bool encontrado = false;
            int n = 0;
            for (n = 0; n < nodos; n++)
            {
                if (indegree[n]==0)
                {
                    encontrado = true;
                    break;
                }
            }
            if (encontrado)
                return n;
            else
                return -1; //Codigo que indica que no se ha encontrado
        }
        public void DecrementoIndegree(int pNodo)
        {
            indegree[pNodo] = -1;
            int n = 0;
            for (n = 0; n < nodos; n++)
            {
                if (mAdyacencia[pNodo, n] == 1)
                    indegree[n]--;
            }
        }
    }
}
