using Graph.Adjacency;
using Graph.BFS;
using Graph.UF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class Kruskal
    {
        private IGraph g;
        private MyList<Edge> list = new MyList<Edge>();

        public Kruskal(IGraph g)
        {
            this.g = g;

            //判断图是否为一个连通图，若不是连通图，则无法生成最小树
            BFSCC cc = new BFSCC(g);
            if (cc.Component() > 1) return;

            //将边选择出来排序
            MyList<Edge> edges = new MyList<Edge>();
            for (int a = 0; a < g.V(); a++)
            {
                foreach (int b in g.Adj(a))
                {
                    //避免重复边
                    if (a < b)
                    {
                        edges.Add(new Edge(a, b, ((AdjDictionary)g).GetWeight(a, b)));
                    }
                }
            }

            edges.Sort();

            //选边且通过并查集进行环检测

            IUF uf = new UnionFind2(g.V());

            foreach (Edge edge in edges)
            {
                int a = edge.GetA();
                int b = edge.GetB();
                //通过并查集进行环检测
                if (!uf.IsConnected(a,b))
                {
                    list.Add(edge);
                    uf.Union(a, b);
                }
            }
        }

        public MyList<Edge> GetList()
        {


            return list;
        }
    }
}
