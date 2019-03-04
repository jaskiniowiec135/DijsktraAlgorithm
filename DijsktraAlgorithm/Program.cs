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
                                          {0,2,0,1,0},
                                          {0,0,0,0,4},
                                          {7,0,0,6,0}};

            int[,] graphToo = new int[9, 9] { {0,4,9,0,7,0,0,10,0},
                                              {0,0,4,5,0,4,0,0,0},
                                              {0,0,0,0,0,8,0,0,0},
                                              {3,0,0,0,2,0,4,0,0},
                                              {0,0,0,0,0,7,4,5,0},
                                              {0,0,6,0,0,0,0,0,8},
                                              {0,0,0,0,0,0,0,2,0},
                                              {0,0,0,0,0,3,5,0,6},
                                              {0,0,12,0,0,0,0,0,0} };
            int startIndex = 1;
            int[] result = findPath(startIndex, graphToo);

            Console.WriteLine("Odległość od wierzchołka {0} do danych wierzchołków wynosi: ", startIndex);
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("{0}: {1}",i,result[i]);
            }

            Console.ReadKey();

        }

        static int[] findPath(int startIndex, int[,] graph)
        {
            int[] result = new int[graph.GetLength(0)];
            int[] lastVertex = new int[graph.GetLength(0)];
            List<int> knownVerticles = new List<int>();
            int currentVertex = startIndex, nextVertex = 0;

            List<int> verticles = new List<int>();
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                verticles.Add(i);
            }

            while (verticles.Count > 0)
            {
                int min = int.MaxValue;

                for (int i = currentVertex; i == currentVertex; i--)
                {
                    nextVertex = -1;
                    for (int j = 0; j < graph.GetLength(0); j++)
                    {
                        if (graph[i, j] > 0 && j != startIndex)
                        {
                            if (result[j] == 0)
                            {
                                result[j] = result[currentVertex] + graph[i, j];
                            }
                            else if (result[currentVertex] + graph[i, j] < result[j])
                            {
                                result[j] = result[currentVertex] + graph[i, j];
                                nextVertex = j;
                                lastVertex[j] = currentVertex;
                            }


                            //TODO rozbić na mniejsze ify + warunek z b do e do a
                            if (result[j] < min && j != lastVertex[currentVertex] && verticles.IndexOf(j) != -1)
                            {
                                min = graph[i, j] + result[currentVertex];
                                if (min <= result[j])
                                {
                                    nextVertex = j;
                                    lastVertex[j] = currentVertex;
                                }
                            }
                        }
                    }

                    if (nextVertex == -1)
                    {
                        nextVertex = lastVertex[i];
                        knownVerticles.Add(currentVertex);
                        verticles.Remove(currentVertex);
                    }
                }
                currentVertex = nextVertex;
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
