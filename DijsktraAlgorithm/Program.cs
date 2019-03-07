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
                                              {0,0,0,0,2,8,0,0,0},
                                              {3,0,0,0,2,0,4,0,0},
                                              {0,6,0,0,0,7,4,5,0},
                                              {0,0,6,0,0,0,0,0,8},
                                              {0,0,0,6,0,0,0,2,0},
                                              {0,0,0,0,0,3,5,0,6},
                                              {0,0,12,0,0,0,0,0,0}};
            int startIndex = 2, endIndex = 4;
            int[] result = findPath(startIndex, endIndex, graphToo);

            //for (int i = 0; i < graphToo.GetLength(0); i++)
            //{
            //    bool ok = true;
            //    startIndex = i;
            //    endIndex = i;
            //    result = findPath(startIndex, endIndex, graphToo);

            //    for (int j = 0; j < graphToo.GetLength(0); j++)
            //    {
            //        if (j != i)
            //        {
            //            if (result[j] == 0)
            //            {
            //                ok = false;
            //            }
            //        }
            //    }

            //    if (ok == true)
            //    {
            //        Console.WriteLine("Z indeksu {0} można dotrzeć do każdego wierzchołka.", i);
            //    }
            //    else
            //    {
            //        Console.WriteLine("Coś nie działa z indeksem {0}", i);
            //    }
            //}

            Console.WriteLine("\nOdległość od wierzchołka {0} do danych wierzchołków wynosi: ", startIndex);
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("{0}: {1}", i, result[i]);
            }


            Console.WriteLine("Done.");
            Console.ReadKey();
        }

        static int[] findPath(int startIndex, int endIndex, int[,] graph)
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

            while (verticles.Count > 1)
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


                            if (result[j] < min && result[j] >= graph[i,j] + result[currentVertex] && j != lastVertex[currentVertex] && verticles.IndexOf(j) != -1)
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

            printPath(startIndex, endIndex, lastVertex);

            return result;
        }

        static void printPath(int startIndex, int endIndex, int[] lastVertex)
        {
            List<int> path = new List<int>();
            int tmp = endIndex;
            while (tmp != startIndex)
            {
                path.Add(tmp);
                tmp = lastVertex[tmp];
            }

            path.Add(startIndex);
            path.Reverse();

            Console.WriteLine("Najlepsza trasa między wierzchołkami {0} i {1} przechodzi przez wierzchołki: ", startIndex, endIndex);

            for (int i = 0; i < path.Count; i++)
            {
                Console.WriteLine(path[i].ToString());
            }
        }
    }
}
