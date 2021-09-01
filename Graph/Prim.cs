using Graph.Adjacency;
using Graph.BFS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class Prim
    {
        private IGraph g;
        private MyList<Edge> list = new MyList<Edge>();
        // 使用切分定理时，需要通过该数组分辨不同的两个部分
        private bool[] colors;

        public Prim(IGraph g)
        {
            this.g = g;

            //判断图是否为一个连通图，若不是连通图，则无法生成最小树
            BFSCC cc = new BFSCC(g);
            if (cc.Component() > 1) return;

            colors = new bool[g.V()];
            // 从第一个顶点开始
            colors[0] = true;

            for (int i = 1; i < g.V(); i++)
            {
                Edge minEdge = new Edge(-1, -1, int.MaxValue);
                for (int a = 0; a < g.V(); a++)
                {
                    //如果当前遍历的顶点为红
                    if (colors[a])
                    {
                        foreach (var b in g.Adj(a))
                        {
                            // 判断是否相连的顶点为另一切分(即找到横切边) 然后比较现在选出的最小的横切边
                            if (!colors[b] && ((AdjDictionary)g).GetWeight(a,b) < minEdge.GetWeight())
                            {
                                minEdge = new Edge(a, b, ((AdjDictionary)g).GetWeight(a, b));
                            }
                        }
                    }
                }

                list.Add(minEdge);
                colors[minEdge.GetA()] = true;
                colors[minEdge.GetB()] = true;

            }
        }

        public MyList<Edge> GetList()
        {
            return list;
        }
    }
}
