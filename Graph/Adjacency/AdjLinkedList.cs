using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Graph.Adjacency
{
    class AdjLinkedList : IGraph
    {
        private int v;
        private int e;
        private LinkedList<int>[] graph;

        public AdjLinkedList(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string line = sr.ReadLine();
            string[] str = line.Split(' ');

            //判断第一行的顶点数和边数
            v = int.Parse(str[0]);
            e = int.Parse(str[1]);

            //空间复杂度 O（V*V）
            graph = new LinkedList<int>[v];
            for (int i = 0; i < v; i++)
            {
                graph[i] = new LinkedList<int>();
            }

            //建图时间复杂度 O（E）
            for (int i = 0; i < e; i++)
            {
                line = sr.ReadLine();
                str = line.Split(' ');
                int a = int.Parse(str[0]);
                int b = int.Parse(str[1]);
                graph[a].AddLast(b);
                graph[b].AddLast(a);
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
            return graph[a].Contains(b);
        }

        /// <summary>
        /// 求一个点的相邻顶点 O（V）
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public IEnumerable<int> Adj(int a)
        {
            return graph[a];
        }

        /// <summary>
        /// 求一个点的相邻顶点数 O（V）
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int Degree(int a)
        {
            return ((LinkedList<int>)Adj(a)).Count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("V = {0}, E={1}\n", v, e));
            for (int a = 0; a < v; a++)
            {
                sb.Append(a + " : ");
                foreach (var b in graph[a])
                {
                    sb.Append(b + " ");
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }
    }
}
