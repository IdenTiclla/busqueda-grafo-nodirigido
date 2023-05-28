using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaGrafo
{
    class Program
    {
        static void Main(string[] args)
        {

            int inicio = 0;
            int final = 19;
            int distancia = 0;
            int n = 0;
            int m = 0;
            int cantNodos = 20;
            string dato = " ";
            Grafo miGrafo = new Grafo(cantNodos);
            miGrafo.AdicionarArista(0, 1);
            miGrafo.AdicionarArista(0, 2);
            miGrafo.AdicionarArista(0, 5);
            miGrafo.AdicionarArista(1, 3);
            miGrafo.AdicionarArista(2, 4);
            miGrafo.AdicionarArista(3, 5);
            miGrafo.AdicionarArista(4, 6);
            miGrafo.AdicionarArista(5, 7);
            miGrafo.AdicionarArista(5, 8);
            miGrafo.AdicionarArista(6, 9);
            miGrafo.AdicionarArista(7, 10);
            miGrafo.AdicionarArista(7, 11);
            miGrafo.AdicionarArista(8, 12);
            miGrafo.AdicionarArista(9, 10);
            miGrafo.AdicionarArista(10, 11);
            miGrafo.AdicionarArista(11, 12);
            miGrafo.AdicionarArista(12, 13);
            miGrafo.AdicionarArista(12, 14);
            miGrafo.AdicionarArista(14, 15);
            miGrafo.AdicionarArista(14, 16);
            miGrafo.AdicionarArista(15, 17);
            miGrafo.AdicionarArista(16, 18);
            miGrafo.AdicionarArista(17, 19);


            miGrafo.MuestraAdyacencia();
            Console.WriteLine("Dame el indice del nodo inicio");
            dato = Console.ReadLine();
            inicio = Convert.ToInt32(dato);

            Console.WriteLine("Dame el indice del nodo final");
            dato = Console.ReadLine();
            final = Convert.ToInt32(dato);

            // Creamos tabla
            // 0: Visitado
            // 1: Distancia
            // 2: Previo
            int[,] tabla = new int[cantNodos, 3];
            //Inicializamos la tabla
            for (n = 0; n < cantNodos; n++)
            {
                tabla[n, 0] = 0;
                tabla[n, 1] = int.MaxValue;
                tabla[n, 2] = 0; 
            }
            tabla[inicio, 1] = 0;
          //  MostrarTabla(tabla);

            for (distancia = 0; distancia < cantNodos; distancia++)
            {
                for (n=0;n<cantNodos;n++)
                {
                    if ((tabla[n, 0] == 0) && (tabla[n, 1] == distancia))
                    {
                        tabla[n, 0] = 1;
                        for (m = 0; m < cantNodos; m++)
                        {  //verificamos que el nodo sea adyacente
                            if (miGrafo.ObtenerAdyacencia(n,m)==1)
                            {
                                if (tabla[m, 1] == int.MaxValue)
                                {
                                    tabla[m,1] = distancia + 1;
                                    tabla[m, 2] = n;
                                }
                            }
                        }
                    }  
                }
            }
           // MostrarTabla(tabla);
            //Obtenemos la ruta
            List<int> ruta = new List<int>();
            int nodo = final;
            while (nodo!=inicio)
            {
                ruta.Add(nodo);
                nodo = tabla[nodo, 2];
            }
            
            ruta.Add(inicio);
            ruta.Reverse();
            Console.WriteLine("Camino Solución:");
            foreach (int posicion in ruta)
                Console.Write("{0}->", posicion);
            Console.WriteLine();
            Console.ReadLine();

        }
        public static void MostrarTabla(int[,] pTabla)
        {
            int n = 0;
            for (n = 0; n < pTabla.GetLength(0); n++)
            {
                Console.WriteLine("{0}-> {1}\t{2}\t{3}",n,pTabla[n,0], pTabla[n, 1], pTabla[n, 2]);
            }
            Console.WriteLine("---------");
        }
    }
}
