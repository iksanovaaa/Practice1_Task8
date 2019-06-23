using System;
using System.Collections.Generic;

namespace Task8
{
    public class Graph
    {
        static Random rnd = new Random();
        public List<string> result = new List<string>(); //список блоков

        int vertex;              //вершины
        int edge;                //ребра
        int[,] graph;            //матрица инцидентности
        int blocks;              //блоки
        int checkedCount;        //проверенные вершины
        int[] Checked;           //номера вершин, которые обходим
        List<int> UsedEdges;     //ребра, записанные в блоки
        Stack<int> EdgesS;       //ребра, которые формирют блок

        // Конструктор графа
        public Graph(int rows, int cols, int[,] matrix)
        {
            this.edge = rows;
            this.vertex = cols;
            graph = matrix;
            blocks = 0;
            checkedCount = 0;
            EdgesS = new Stack<int>(rows);
            Checked = new int[cols];
            for (int i = 0; i < cols; i++)
            {
                Checked[i] = 0;
            }
            UsedEdges = new List<int>(cols);
        }
        // Создание матрицы инцидентности
        public static Graph CreateGraph()
        {
            int vertex = rnd.Next(4, 10);
            int maxEdges = vertex * (vertex - 1) / 2;
            int edge = rnd.Next(3, maxEdges);
            Console.WriteLine("Количество вершин: {0}. Количество рёбер: {1}", vertex, edge);
            int[,] graph = new int[vertex + 1, edge + 1];

            for (int i = 0; i <= vertex; i++)
            {
                if (i == 0)
                    for (int j = 0; j <= edge; j++) graph[i, j] = j;
                else graph[i, 0] = i;
            }
            for (int j = 1; j <= edge; j++)
            {
                int count1 = 0;
                for (int i = 1; i <= vertex; i++)
                {
                    if (count1 == 2) graph[i, j] = 0;
                    else if ((count1 == 0) && (i == vertex - 1))
                    {
                        graph[i, j] = 1;
                        graph[i + 1, j] = 1;
                        break;
                    }
                    else if (j == vertex) graph[i, j] = 1;
                    else graph[i, j] = rnd.Next(0, 2);
                    if (graph[i, j] == 1) count1++;
                }
            }


            return new Graph(edge, vertex, graph);
        }
        //печать графа
        public static void PrintGraph(Graph G)
        {
            for (int i = 0; i <= G.vertex; i++)
            {
                if (i == 0)
                {
                    Console.Write("  ");
                    for (int j = 1; j <= G.edge; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(G.graph[i, j] + " ");
                        Console.ResetColor();
                    }
                }
                else
                    for (int j = 0; j <= G.edge; j++)
                    {
                        if (j == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write((char)('A' + i - 1) + " ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(G.graph[i, j] + " ");
                            if (j >= 10) Console.Write(" ");
                        }
                    }
                Console.WriteLine();
            }
        }
        //Поиск в глубину
        int DFS(int pos, int parent)
        {
            Checked[pos - 1] = ++checkedCount;
            int minD = Checked[pos - 1];  //минимальное расстояние до вершины
            //перебор всех ребер, которые имеют отношение к текущей вершине pos
            for (int i = 1; i <= edge; i++)
            {
                if (graph[pos, i] == 1)
                {
                    int nextV = 1; // вершина, в которую ведет текущее ребро
                    while (nextV < vertex && graph[nextV, i] == 0 || nextV == pos)
                        nextV++;
                    {
                        if (nextV != parent)
                        {
                            int t, currSize = EdgesS.Count;
                            if (!UsedEdges.Contains(i)) //добавление ребра блока
                            {
                                UsedEdges.Add(i);
                                EdgesS.Push(i);
                            }
                            if (Checked[nextV - 1] == 0)
                            {
                                t = DFS(nextV, pos);
                                if (t >= Checked[pos - 1])
                                {

                                    string res = "Блок " + ++blocks + " с ребрами: ";
                                    while (EdgesS.Count != currSize)
                                    {
                                        res += (EdgesS.Pop() + "; ");
                                    }
                                    result.Add(res);
                                }
                            }
                            else
                                t = Checked[nextV - 1];
                            minD = Math.Min(minD, t);
                        }
                    }
                }
            }

            return minD;
        }
        // Нахождение блоков с помощью поиска в глубину
        public void Block()
        {
            checkedCount = 0;
            DFS(1, 0);
            if (result.Count == 0) Console.WriteLine("В графе нет блоков");
            else
                for (int i = 0; i < result.Count; i++)
                {
                    Console.WriteLine(result[i]);
                }
        }     
    }
}
