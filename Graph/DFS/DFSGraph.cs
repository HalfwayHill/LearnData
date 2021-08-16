using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.DFS
{
    /// <summary>
    /// 深度优先遍历图(Depth First Search Graph)
    /// </summary>
    class DFSGraph
    {
        //通过接口扩展Class，这样无论是邻接矩阵或邻接表都可直接对接
        private IGraph graph;
        //是否被遍历过
        private bool[] visited;
        private MyList<int> list = new MyList<int>();

        public DFSGraph(IGraph graph)
        {
            this.graph = graph;
            visited = new bool[graph.V()];

            DFS(0);
        }

        private void DFS(int v)
        {
            //将v标识为True
            visited[v] = true;
            //将v加入遍历结果中
            list.Add(v);
            //遍历v的邻接顶点，如果没遍历过，继续深度遍历
            foreach (var w in graph.Adj(v))
            {
                if (!visited[w])
                    DFS(w);
            }

            //这样就会获取到所有的遍历结果
        }

        /// <summary>
        /// 获取遍历结果
        /// </summary>
        /// <returns></returns>
        public MyList<int> GetList()
        {
            return list;
        }
    }
}
