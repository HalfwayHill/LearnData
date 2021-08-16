using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Graph.Adjacency
{
    class AdjMatrix : IGraph
    {
        private int v;
        private int e;
        private int[,] graph;

        public AdjMatrix(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string line = sr.ReadLine();
            string[] str = line.Split(' ');

            //判断第一行的顶点数和边数
            v = int.Parse(str[0]);
            e = int.Parse(str[1]);

            //空间复杂度 O（V*V）
            graph = new int[v, v];

            //建图时间复杂度 O（E） 再读其他行获取图数据
            for (int i = 0; i < e; i++)
            {
                line = sr.ReadLine();
                str = line.Split(' ');
                int a = int.Parse(str[0]);
                int b = int.Parse(str[1]);
                //通过二维数组建立邻接矩阵，横纵表示顶点，
                //两个顶点交叉有边链接为1，无边链接为0
                graph[a, b] = 1;
                graph[b, a] = 1;
            }
            fs.Close();
            sr.Close();
        }

        public int V() { return v; }

        public int E() { return e; }

        /// <summary>
        /// 判断两点是否相邻(有边相连) O（1）
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool HasEdge(int a, int b)
        {
            return graph[a, b] == 1;
        }

        /// <summary>
        /// 求一个点的相邻顶点 O（V）
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public IEnumerable<int> Adj(int a)
        {
            List<int> res = new List<int>();
            for (int b = 0; b < v; b++)
            {
                if (graph[a, b] == 1)
                    res.Add(b);
            }
            return res;
        }

        /// <summary>
        /// 求一个点的相邻顶点数 O（V）
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int Degree(int a)
        {
            return ((List<int>)Adj(a)).Count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("V = {0}, E={1}\n", v, e));
            for (int a = 0; a < v; a++)
            {
                for (int b = 0; b < v; b++)
                {
                    sb.Append(graph[a, b] + " ");
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }
    }
}
