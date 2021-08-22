using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.DFS
{
    /// <summary>
    /// 深度优先遍历图(Depth First Search Graph)
    /// </summary>
    class DFSBipartiteDetection
    {
        //通过接口扩展Class，这样无论是邻接矩阵或邻接表都可直接对接
        private IGraph graph;
        //是否被遍历过
        private bool[] visited;
        //顶点染色，用于分辨是否为二分图
        private bool[] colors;
        //是否为二分图
        private bool isBipartite = true;

        public DFSBipartiteDetection(IGraph graph)
        {
            this.graph = graph;
            visited = new bool[graph.V()];
            colors = new bool[graph.V()];

            //DFS(0);
            //这样改进的好处是当某个节点没有任何链接的时候，也能找到
            for (int v = 0; v < graph.V(); v++)
            {
                if (!visited[v])
                {
                    DFS(v);
                }
                    
            }
        }

        private void DFS(int v)
        {
            //将v标识为True
            visited[v] = true;
            //遍历v的邻接顶点，如果没遍历过，继续深度遍历
            foreach (var w in graph.Adj(v))
            {
                if (!visited[w])
                {
                    //当找到为遍历的顶点时，设置它的颜色和当前顶点的颜色相反
                    colors[w] = !colors[v];
                    DFS(w);

                }//当出现当前顶点连通的已遍历的顶点和当前顶点颜色相同，那么就不是二分图
                else if (colors[w] == colors[v])
                {
                    isBipartite = false;
                }   
            }
        }

        public bool IsBipartite()
        {

            return isBipartite;
        }
    }
}
