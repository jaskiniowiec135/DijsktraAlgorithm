using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijsktraAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] graph = new int[5,5] { {0,5,10,0,0},
                                          {0,0,3,9,2},
                                          {0,2,0,0,1},
                                          {0,0,0,0,4},
                                          {7,0,0,6,0}};
            int startIndex = 0;
            int[] result = findPath(startIndex, graph);

            Console.WriteLine("Odległość od wierzchołka {0} do danych wierzchołków wynosi: ", startIndex);
            for (int i = 1; i < result.Length; i++)
            {
                Console.WriteLine("{0}: {1}",i,result[i]);
            }

        }

        static int[] findPath(int startIndex, int[,] graph)
        {
            int[] result = new int[graph.GetLength(0)];
            List<int> knownVerticles = new List<int>();
            int currentVerticle = startIndex;

            List<int> verticles = new List<int>();
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                verticles.Add(i);
            }

            knownVerticles.Add(startIndex);
            verticles.Remove(startIndex);
            ratePathFromVerticle(graph, result, startIndex);

            while (verticles.Count > 0)
            {
                List<int> tmp = new List<int>();
                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if ((int)graph.GetValue(currentVerticle,i) > 0)
                    {
                        tmp.Add((int)graph.GetValue(currentVerticle, i));
                    }
                }

                for (int i = currentVerticle; i == currentVerticle; i--)
                {
                    for (int j = 0; j < graph.GetLength(0); j++)
                    {
                        if (graph[i, j] == tmp.Min())
                        {
                            knownVerticles.Add(j);
                            verticles.Remove(j);
                            currentVerticle = j;
                            break;
                        }
                    }
                }

                ratePathFromVerticle(graph, result, currentVerticle);
            }
            return result;
        }

        static void ratePathFromVerticle(int[,] graph, int[] pathRates, int currVert)
        {
            for (int i = currVert; i == currVert; i--)
            {
                for (int j = 1; j < graph.GetLength(0); j++)
                {
                    if(graph[i,j] > 0)
                    {
                        if(currVert != 0)
                        {
                            if(graph[i,j] + pathRates[currVert] < pathRates[j]||pathRates[j] == 0)
                            {
                                pathRates[j] = graph[i, j] + pathRates[currVert];
                            }
                        }
                        else
                        {
                            pathRates[j] = graph[i, j];
                        }
                    }
                }
            }
        }
    }
}
