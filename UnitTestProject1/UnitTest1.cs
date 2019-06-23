using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task8;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int v = 5;
            int e = 5;
            int[,] graph = new int[6, 6] { { 0, 1, 2, 3, 4, 5 }, {1, 1, 1, 0, 0, 0 }, {2, 0, 1, 1, 1, 0 },
                    { 3, 0, 0, 0, 1, 1 }, { 4, 0, 0, 1, 0, 1 }, { 5, 1, 0, 0, 0, 0 } };            
            Graph g1 = new Graph(v, e, graph);
            Graph.PrintGraph(g1);
            Program.PrintMes("Graph1: ");
            g1.Block();
            Assert.AreEqual(g1.result.Count, 3);
            Graph g2 = Graph.CreateGraph();
            g2.Block();
            Assert.AreNotEqual(g2.result.Count, 0);
            int v3 = 2;
            int e3 = 2;
            int[,] graph3 = new int[3, 3] { { 0, 1, 2 }, { 1, 1, 1 }, { 2, 1, 1} };
            Graph g3 = new Graph(v3, e3, graph3);
            g3.Block();
            Assert.AreEqual(g3.result.Count, 1);
        }
    }
}
