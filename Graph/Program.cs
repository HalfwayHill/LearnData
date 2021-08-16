using Graph.Adjacency;
using Graph.DFS;
using System;
using System.Collections.Generic;

namespace Graph
{
    class Program
    {
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

            IGraph graph = new AdjLinkedList(@"./TestFile/图的深度优先遍历/g.txt");
            DFSGraph dfs = new DFSGraph(graph);
            Console.Write(dfs.GetList());



            #endregion


            Console.Read();
        }
    }
}
