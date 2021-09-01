using Graph.Adjacency;
using Graph.BFS;
using Graph.DFS;
using Graph.UF;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Graph
{
    /* 二分图
     * 二分图又称作二部图，是图论中的一种特殊模型。 
     * 设G=(V,E)是一个无向图，如果顶点V可分割为两个互不相交的子集(A,B)，
     * 并且图中的每条边（i，j）所关联的两个顶点i和j
     * 分别属于这两个不同的顶点集(i in A,j in B)，
     * 则称图G为一个二分图。
     * 
     * 简而言之，就是顶点集V可分割为两个互不相交的子集，
     * 并且图中每条边依附的两个顶点都分属于这两个互不相交的子集，
     * 两个子集内的顶点不相邻。
     */

    class Program
    {
        /// <summary>
        /// 测试并查集效率方法
        /// </summary>
        /// <param name="uf"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        private static long TestUF(IUF uf, int m)
        {
            int size = uf.GetSize();
            Random r = new Random();
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < m; i++)
            {
                int a = r.Next(size);
                int b = r.Next(size);
                uf.Union(a, b);
            }

            for (int i = 0; i < m; i++)
            {
                int a = r.Next(size);
                int b = r.Next(size);
                uf.IsConnected(a, b);
            }

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        static void Main(string[] args)
        {
            #region 多维数组

            /*

            //一维数组
            int[] arr1 = new int[3];
            // 0 1 2
            // 0 0 0

            for (int i = 0; i < 3; i++)
                Console.Write(arr1[i]);

            */

            /*

            //二维数组
            int[,] arr2 = new int[4, 3];//4row 3column
            //    0  1  2
            // 0  0  0  0
            // 1  0  0  1
            // 2  0  0  0
            // 3  0  0  0

            arr2[1, 2] = 1;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(arr2[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine($"arr2.Length:{arr2.Length}");

            */

            /*

            //交错数组
            int[][] arr3 = new int[4][];
            arr3[0] = new int[3];
            arr3[1] = new int[2];
            arr3[2] = new int[3];
            arr3[3] = new int[3];

            //    0  1  2
            // 0  0  0  0
            // 1  0  1
            // 2  0  0  0
            // 3  0  0  0

            arr3[1][1] = 1;

            for (int i = 0; i < arr3.Length; i++)
            {
                for (int j = 0; j < arr3[i].Length; j++)
                {
                    Console.Write(arr3[i][j]);
                }
                Console.WriteLine();
            }

            */

            #endregion

            #region 邻接矩阵

            /*
             * 邻接矩阵（Adjacency Matrix）是表示顶点之间相邻关系的矩阵。
             * 设G=(V,E)是一个图，其中V={v1,v2,…,vn} [1]  。
             * G的邻接矩阵是一个具有下列性质的n阶方阵：
             * ①对无向图而言，邻接矩阵一定是对称的，
             * 而且主对角线一定为零（在此仅讨论无向简单图），
             * 副对角线不一定为0，有向图则不一定如此。
             * ②在无向图中，任一顶点i的度为第i列（或第i行）所有非零元素的个数，
             * 在有向图中顶点i的出度为第i行所有非零元素的个数，
             * 而入度为第i列所有非零元素的个数。
             * ③用邻接矩阵法表示图共需要n^2个空间，
             * 由于无向图的邻接矩阵一定具有对称关系，所以扣除对角线为零外，
             * 仅需要存储上三角形或下三角形的数据即可，因此仅需要n（n-1）/2个空间。
             */

            /*

            IGraph adjMatrix = new AdjMatrix(@"./TestFile/FirstGraph.txt");
            Console.WriteLine(adjMatrix);

            Console.WriteLine(adjMatrix.V());
            Console.WriteLine(adjMatrix.E());
            Console.WriteLine(adjMatrix.HasEdge(0, 1));

            List<int> res = (List<int>)adjMatrix.Adj(0);
            for (int i = 0; i < res.Count; i++)
                Console.Write(res[i] + " ");

            Console.WriteLine();

            Console.WriteLine(adjMatrix.Degree(0));

            */

            #endregion

            #region 邻接表

            /*

            //使用IGraph adjLinked = new AdjLinkedList来扩展
            IGraph adjLinked = new AdjLinkedList(@"./TestFile/FirstGraph.txt");
            Console.WriteLine(adjLinked);

            Console.WriteLine(adjLinked.V());
            Console.WriteLine(adjLinked.E());
            Console.WriteLine(adjLinked.HasEdge(0, 1));

            LinkedList<int> res = (LinkedList<int>)adjLinked.Adj(0);
            foreach (var item in res)
                Console.Write(item + " ");

            Console.WriteLine();

            Console.WriteLine(adjLinked.Degree(0));

            */

            #endregion

            #region 深度优先遍历

            /*

            IGraph graph = new AdjLinkedList(@"./TestFile/图的深度优先遍历/g2.txt");
            DFSGraph dfs = new DFSGraph(graph);
            IGraph graph3 = new AdjLinkedList(@"./TestFile/图的环检测/g3.txt");
            DFSGraph dfs3 = new DFSGraph(graph3);
            Console.Write(dfs.GetList());
            Console.WriteLine($" Graph联通分量:{dfs.Component()}");

            //单源路径
            //DFSGraph dfsSingleSourcePath = new DFSGraph(graph, 0);
            //Console.WriteLine($" 0 -> 6:{dfsSingleSourcePath.Path(6)}");
            //Console.WriteLine($" 0 -> 5:{dfsSingleSourcePath.Path(5)}");
            //Console.WriteLine($" 0 -> 4:{dfsSingleSourcePath.Path(4)}");

            Console.WriteLine($"图2是否存在环:{dfs.HasCycle()}");
            Console.WriteLine($"图3是否存在环:{dfs3.HasCycle()}");

            Console.WriteLine($"测试二分图");
            IGraph graph4 = new AdjLinkedList(@"./TestFile/图的二分检测/g4.txt");
            DFSBipartiteDetection dfs41 = new DFSBipartiteDetection(graph);
            DFSBipartiteDetection dfs42 = new DFSBipartiteDetection(graph4);


            Console.WriteLine($"图2二分图检测:{dfs41.IsBipartite()}");
            Console.WriteLine($"图4二分图检测:{dfs42.IsBipartite()}");

            */

            #endregion

            #region 广度优先遍历

            /*

            //使用队列的出队入队的方式
            //不是从一条路径走到低(深度)
            //而是将当前顶点的未遍历相邻顶点入队
            //然后再将出队的顶点设为当前顶点

            //深度优先遍历所取得的单源路径可能时随机的一条路径
            //而广度优先遍历所取得的单源路径一定是最短路径

            //IGraph graph = new AdjLinkedList(@"./TestFile/图的广度优先遍历/g.txt");
            //BFSGraph dfs = new BFSGraph(graph);
            //Console.Write(dfs.GetList());

            //联通分量
            IGraph graph = new AdjLinkedList(@"./TestFile/图的广度优先遍历/g.txt");
            BFSCC bFSCC = new BFSCC(graph);
            IGraph graph2 = new AdjLinkedList(@"./TestFile/图的深度优先遍历/g2.txt");
            BFSCC bFSCC2 = new BFSCC(graph2);
            Console.WriteLine($" Graph联通分量:{bFSCC.Component()}");
            Console.WriteLine($" Graph联通分量:{bFSCC2.Component()}");

            //单源路径
            BFSSingleSourcePath bfsSingleSourcePath = new BFSSingleSourcePath(graph2, 0);
            Console.WriteLine($" 0 -> 6:{bfsSingleSourcePath.Path(6)} 距离:{bfsSingleSourcePath.GetDis(6)}");
            Console.WriteLine($" 0 -> 5:{bfsSingleSourcePath.Path(5)} 距离:{bfsSingleSourcePath.GetDis(5)}");
            Console.WriteLine($" 0 -> 4:{bfsSingleSourcePath.Path(4)} 距离:{bfsSingleSourcePath.GetDis(4)}");

            Console.WriteLine($"测试二分图");
            IGraph graph4 = new AdjLinkedList(@"./TestFile/图的二分检测/g4.txt");
            BFSBipartiteDetection dfs41 = new BFSBipartiteDetection(graph);
            BFSBipartiteDetection dfs42 = new BFSBipartiteDetection(graph4);


            Console.WriteLine($"图2二分图检测:{dfs41.IsBipartite()}");
            Console.WriteLine($"图4二分图检测:{dfs42.IsBipartite()}");

            Console.WriteLine($"环检测");

            IGraph graph3 = new AdjLinkedList(@"./TestFile/图的环检测/g3.txt");

            BFSCycleDetection dfsCycle1 = new BFSCycleDetection(graph);
            BFSCycleDetection dfsCycle2 = new BFSCycleDetection(graph3);

            Console.WriteLine($"图2是否存在环:{dfsCycle1.HasCycle()}");
            Console.WriteLine($"图3是否存在环:{dfsCycle2.HasCycle()}");

            Console.WriteLine($"非递归深度优先遍历");
            IGraph dfsgraph = new AdjLinkedList(@"./TestFile/图的深度优先遍历/g2.txt");
            DFSGraphS dfs = new DFSGraphS(dfsgraph);
            DFSGraphNRS dfsNR = new DFSGraphNRS(dfsgraph);
            Console.Write($"递归深度优先遍历{dfs.GetList()}");
            Console.Write($"非递归深度优先遍历{dfsNR.GetList()}");

            //递归深度优先遍历所得到的遍历数组其实为图的原始顶点从左开始
            //非递归深度优先遍历由于栈的机制，导致为图的原始顶点的右边开始

            */
            #endregion

            #region 并查集

            /* 并查集
             * 并查集可以高效地解决联通问题
             * 可以快速查询两顶点(尤其解决大量顶点的图，两个很远的顶点)是否联通
             * 我们也可以通过优先遍历查找两顶点是否联通，但这样太过低效
             */

            /*

            int size = 100000;
            int m = 10000;

            UnionFind1 unionFind1 = new UnionFind1(size);
            Console.WriteLine($"UnionFind1的时间: {TestUF(unionFind1, m)}ms");

            UnionFind2 unionFind2 = new UnionFind2(size);
            Console.WriteLine($"UnionFind1的时间: {TestUF(unionFind2, m)}ms");

            */

            /*
             * size越大，UnionFind2优势约明显，
             * 因为它使用的是树的形式，我们只需要考虑树的高度就行
             * 而UnionFind1是全部遍历，对于数量越大效率越低
             */

            #endregion

            #region 带权图

            /*

            IGraph adjDictionary = new AdjDictionary(@"./TestFile/带权图/g.txt");
            Console.WriteLine(adjDictionary);

            Console.WriteLine(adjDictionary.V());
            Console.WriteLine(adjDictionary.E());
            Console.WriteLine(adjDictionary.HasEdge(0, 1));
            */

            #endregion

            #region Kruskal算法 -- 最小生成树
            /*

            AdjDictionary adjDictionary = new AdjDictionary(@"./TestFile/带权图/g.txt");
            Kruskal kruskal = new Kruskal(adjDictionary);

            Console.WriteLine(kruskal.GetList());

            */
            #endregion

            /* 切分定理
             * 定义一：把图的结点分为两部分，称为一个切分(Cut)
             * 定义二：如果一个边的两个端点，属于切分不同的两边，这个边称为横切边(Crossing Edge)
             * 切分定理：给定任意切分，横切边中权值最小的边必然属于最小生成树
             * 证明: 假如一条横切边他不是最短的，那么必然存在一条最短的边，连接两部分，否则这两部分不连通，无法构成生成树。
             */

            #region Prim算法 -- 最小生成树

            /*

            AdjDictionary adjDictionaryP = new AdjDictionary(@"./TestFile/带权图/g.txt");
            Prim prim = new Prim(adjDictionaryP);

            Console.WriteLine(prim.GetList());

            */
            #endregion

            // 广度优先遍历只适用于无权图的最短路径求解

            #region Dijkstra算法 -- 带权图的最短路径

            /**/

            AdjDictionary adjDictionaryD = new AdjDictionary(@"./TestFile/带权图最短路径/g.txt");
            Dijkstra dijkstra = new Dijkstra(adjDictionaryD, 0);

            for (int i = 0; i < adjDictionaryD.V(); i++)
            {
                Console.WriteLine($"顶点0与顶点{i}的带权最短路径:{dijkstra.DisTo(i)}");
            }

            Console.WriteLine($"顶点2与顶点0是否相连:{dijkstra.IsConnected(2)}");

            #endregion

            Console.Read();
        }
    }
}
