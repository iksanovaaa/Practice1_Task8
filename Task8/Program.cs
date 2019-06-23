using System;

namespace Task8
{
    public class Program
    {
        static int vertex, edge;
        static int[,] graph;
        static void Main(string[] args)
        {
            bool end = false;
            do
            {
                PrintMes("Граф задан матрицей инциденций. Найти все его блоки.");
                int[,] graph = new int[6, 6] { { 0, 1, 2, 3, 4, 5 }, {1, 1, 1, 0, 0, 0 }, {2, 0, 1, 1, 1, 0 },
                    { 3, 0, 0, 0, 1, 1 }, { 4, 0, 0, 1, 0, 1 }, { 5, 1, 0, 0, 0, 0 } };
                Console.WriteLine("Пример нахождения блоков в графе (изображение составлено не программно и приведено для наглядности):");
                Console.WriteLine("Количество вершин: {0}. Количество рёбер: {1}", 5, 5);
                Graph g1 = new Graph(5, 5, graph);
                Graph.PrintGraph(g1);
                Console.WriteLine($@"
    A
1 /  \2
 /    \
E      B
     3/ \4
     /___\
    D  5  C");                
                g1.Block();

                Console.WriteLine("\nНахождение блоков в графе, сгенерированном с помощью ДСЧ:");
                Graph g2 = Graph.CreateGraph();
                Graph.PrintGraph(g2);
                g2.Block();
                end = CheckKey();
            } while (!end);
        }
        //печать сообщения
        public static void PrintMes(string s)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        //выход из программы или формирование новой последоватльности
        public static bool CheckKey()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            bool next, end = false;
            int keyNum;
            Console.WriteLine("Для выхода из программы нажмите Esc, для генерации другого графа нажмите Enter.");
            do
            {
                keyNum = Console.ReadKey().KeyChar;
                next = (keyNum == 27) || (keyNum == 13);
            } while (!next);
            if (keyNum == 27) end = true;
            Console.Clear();
            Console.ResetColor();
            return end;
        }
    }
}
