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
           

             

            // miGrafo.MuestraAdyacencia();
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
