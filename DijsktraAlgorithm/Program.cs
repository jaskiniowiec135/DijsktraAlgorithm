using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijsktraAlgorithm
{
    class Program
    {
        static int[] lastVertex;
        static Random r = new Random();

        static void Main(string[] args)
        {
            int[,] firstGraph = new int[5, 5] { {0,7,12,0,0},
                                          {0,0,5,11,4},
                                          {0,4,0,3,0},
                                          {0,0,0,0,6},
                                          {9,0,0,8,0}};
                                          

            int[] firstTerrain = { 2, 1, 1, 0, 0};

            int[,] secondGraph = new int[9, 9] { {0,4,9,0,7,0,0,10,0},
                                              {0,0,4,5,0,4,0,0,0},
                                              {0,0,0,0,2,8,0,0,0},
                                              {3,0,0,0,2,0,4,0,0},
                                              {0,6,0,0,0,7,4,5,0},
                                              {0,0,6,0,0,0,0,0,8},
                                              {0,0,0,6,0,0,0,2,0},
                                              {0,0,0,0,0,3,5,0,6},
                                              {0,0,12,0,0,0,0,0,0}};

            int[] secondTerrain = { 0, 1, 2, 0, 1, 1, 0, 0, 0 };

            int[,] thirdGraph = new int[29, 29] { {0,14,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                  {14,0,10,14,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                  {10,10,8,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                  {0,0,8,0,0,0,0,0,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                  {0,14,0,0,0,12,0,0,0,11,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                  {0,0,0,0,12,0,8,0,0,0,0,0,13,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                  {0,0,0,0,0,8,0,0,0,0,0,0,0,0,10,0,12,0,0,0,0,0,0,0,0,0,0,0,0},
                                                  {0,0,10,0,0,0,0,0,9,0,0,0,0,0,0,0,10,0,0,0,0,0,0,0,0,0,0,0,0},
                                                  {0,0,0,9,0,0,0,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                  {0,0,0,0,11,0,0,0,0,0,12,12,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                  {0,0,0,0,10,0,0,0,0,12,0,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                  {0,0,0,0,0,0,0,0,0,12,10,0,0,8,0,0,0,0,0,0,0,0,0,0,0,19,0,0,0},
                                                  {0,0,0,0,0,13,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                  {0,0,0,0,0,0,0,0,0,0,0,8,8,0,0,9,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                                  {0,0,0,0,0,10,0,0,0,0,0,0,0,0,13,0,0,8,0,0,0,0,0,0,0,0,0,0,0},
                                                  {0,0,0,0,0,0,0,0,0,0,0,0,0,9,13,0,0,0,14,0,0,0,0,0,13,13,0,0,0},
                                                  {0,0,0,0,0,0,12,10,0,0,0,0,0,0,0,0,0,11,11,0,0,0,0,0,0,0,0,0,0},
                                                  {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,0,10,13,0,0,0,0,0,0,0,0},
                                                  {0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,14,11,0,0,12,0,0,0,0,0,0,0,0,0},
                                                  {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,10,12,0,0,16,9,0,0,0,0,0,0},
                                                  {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13,0,0,0,9,0,0,0,0,0,0,0,0},
                                                  {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,9,0,0,0,0,0,0,0,16},
                                                  {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,9,0,0,0,16,0,0,0,0,8},
                                                  {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,0,8,0,0,0,17},
                                                  {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13,0,0,0,0,0,0,0,8,0,0,10,10,0},
                                                  {0,0,0,0,0,0,0,0,0,0,0,19,0,0,0,13,0,0,0,0,0,0,0,0,0,0,13,0,0},
                                                  {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,10,13,0,11,0},
                                                  {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,10,0,11,0,15},
                                                  {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,8,17,0,0,0,15,0}};

            int[] thirdTerrain = new int[29] { 0,0,0,0,0,0,0,0,0,5,5,5,5,5,5,5,5,5,5,5,5,5,5,10,10,10,10,10,10};

            int startIndex = 0, endIndex = 13;
            int [,] currentGraph = thirdGraph;
            int[] currentTerrain = thirdTerrain;
            List<int[]> paths = new List<int[]>();
            List<int[]> vertexes = new List<int[]>();
            List<int> endIndexes = new List<int>();
            int sumOfPaths = 0, selectedPath = 0;

            double skipPropability = currentGraph.GetLength(0) / 10d;
            skipPropability =  Math.Round(skipPropability, MidpointRounding.AwayFromZero);

            currentGraph = prepareTerrain(currentGraph, currentTerrain);
            int originEndIndex = endIndex;
            
            for (int i = 0; i < currentTerrain.Count(); i++)
            {
                endIndex = originEndIndex;
                int[,] tmpGraph = currentGraph;
                int[] tmpTerrain = currentTerrain;
                bool samePath = true;
                int[] path;

                tmpGraph = randomizeGraph(tmpGraph, skipPropability, startIndex, ref endIndex);
                path = findPath(startIndex, endIndex, tmpGraph);

                if(paths.Count < 1)
                {
                    samePath = false;
                }

                for(int j = 0; j < paths.Count; j++)
                {
                    for (int k = 0; k < path.Length; k++)
                    {
                        if (paths[j][k] == path[k])
                        {
                            samePath = true;
                        }
                        else
                        {
                            samePath = false;
                            break;
                        }
                    }
                    if(samePath == true)
                    {
                        break;
                    }
                }

                if (samePath == false)
                {
                    paths.Add(path);
                    vertexes.Add(lastVertex);
                    sumOfPaths += path[endIndex];
                    endIndexes.Add(endIndex);
                }

                lastVertex = new int[currentGraph.GetLength(0)];
            }

            selectedPath = r.Next(sumOfPaths);

            Console.WriteLine($"Znaleziono {paths.Count} ścieżek");

            for (int i = 0; i < paths.Count; i++)
            {
                if(paths[i][endIndex] >= selectedPath)
                {
                    selectedPath = i;
                    Console.WriteLine($"Wybrano ścieżkę numer {i}");
                    break;
                }
                else
                {
                    selectedPath -= paths[i][endIndex];
                }
            }

            lastVertex = vertexes[selectedPath];

            Console.WriteLine("Odległość od wierzchołka {0} do danych wierzchołków wynosi: ", startIndex);

            for (int i = 0; i < paths[selectedPath].Length; i++)
            {   
                    Console.WriteLine("{0}: {1}", i, paths[selectedPath][i]);   
            }

            printPath(startIndex, endIndexes[selectedPath], paths[selectedPath]);

            Console.WriteLine($"Usunięto {29 - paths[selectedPath].Length} wierzchołków");
           
            Console.WriteLine("Done.");
            Console.ReadKey();
        }

        static int[,] prepareTerrain(int[,] graph, int[] terrain)
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(0); j++)
                {
                    if(graph[i,j] != 0)
                    {
                        if(terrain[i] != terrain[j])
                        {
                            if(terrain[i] > terrain[j])
                            {
                                graph[i, j] -= terrain[i] - terrain[j];
                            }
                            else
                            {
                                graph[i, j] += terrain[j] - terrain[i];
                            }
                        }
                        else
                        {
                            graph[i, j] += terrain[i];
                        }
                    }
                }
            }

            return graph;
        }

        static int[,] randomizeGraph(int[,] graph, double skip, int start,ref int end)
        {
            int vertex = 0, counter = 0;
            int[,] newGraph = new int[graph.GetLength(0) - 1, graph.GetLength(0) - 1];

            if (end > graph.GetLength(0))
            {
                end = graph.GetLength(0) - 1;
            }

            while(skip > 0 && counter < 20)
            {
                vertex = r.Next(newGraph.GetLength(0));

                while(graph.GetLength(0) > 2 && (vertex == start || vertex == end))
                {
                    vertex = r.Next(newGraph.GetLength(0));
                }

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    for(int j = 0; j < graph.GetLength(0); j++)
                    {
                        if(i != vertex && j != vertex)
                        {
                            if(vertex < i)
                            {
                                if (vertex < j)
                                {
                                    newGraph[i - 1, j - 1] = graph[i, j];
                                }
                                else
                                {
                                    newGraph[i - 1, j] = graph[i, j];
                                }
                            }
                            else if(vertex < j)
                            {
                                newGraph[i, j - 1] = graph[i, j];
                            }
                            else
                            {
                                newGraph[i, j] = graph[i, j];
                            }
                        }
                    }
                }


                if (isGraphOk(newGraph))
                {
                    skip--;
                    counter = 0;

                    if (end > vertex)
                    {
                        end--;
                    }

                    graph = newGraph;
                    newGraph = new int[newGraph.GetLength(0) - 1, newGraph.GetLength(0) - 1];
                }
                else
                {
                    counter++;
                }
            }

            return graph;
        }

        static int[] findPath(int startIndex, int endIndex, int[,] graph)
        {
            int[] result = new int[graph.GetLength(0)];
            lastVertex = new int[graph.GetLength(0)];
            lastVertex[startIndex] = -1;
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
                        if (graph[i, j] > 0 && j != startIndex) // TODO OutOfRangeEx - when verticle 0 is removed - to solve
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


                            if (result[j] < min && result[j] >= graph[i, j] + result[currentVertex] && j != lastVertex[currentVertex] && verticles.IndexOf(j) != -1)
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

                        if (nextVertex == -1 && lastVertex[currentVertex] != startIndex)
                        {
                            verticles.Clear();
                        }
                    }
                }
                currentVertex = nextVertex;
            }

            lastVertex[Array.IndexOf(lastVertex, -1)] = 0;

            return result;
        }

        static void printPath(int startIndex, int endIndex, int[] distances)
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

            Console.WriteLine($"Najlepsza trasa między wierzchołkami {startIndex} i {endIndex} ma wagę {distances[endIndex]} i przechodzi przez wierzchołki: ");

            for (int i = 0; i < path.Count; i++)
            {
                Console.WriteLine(path[i].ToString());
            }
        }

        static bool isGraphOk(int[,] graph)
        {
            bool ok = true;

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                int startIndex = i;
                int endIndex = i;
                int[] result = findPath(startIndex, endIndex,graph);

                for (int j = 0; j < graph.GetLength(0); j++)
                {
                    if (j != i)
                    {
                        if (result[j] == 0)
                        {
                            ok = false;
                        }
                    }
                }
            }

            return ok;
        }
    }
}
