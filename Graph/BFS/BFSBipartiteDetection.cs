using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.BFS
{
    /// <summary>
    /// 广度优先遍历
    /// </summary>
    class BFSBipartiteDetection
    {
        //通过接口扩展Class，这样无论是邻接矩阵或邻接表都可直接对接
        private IGraph graph;
        //是否被遍历过
        private bool[] visited;
        //广度优先遍历中的存储顶点的队列
        private Queue<int> queue = new Queue<int>();
        //是否为二分图
        private bool isBipartite = true;
        //顶点颜色数组
        private bool[] colors;

        public BFSBipartiteDetection(IGraph graph)
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
                    BFS(v);
                }

            }
        }

        private void BFS(int v)
        {
            //将v标识为True
            visited[v] = true;
            queue.Enqueue(v);
            //这样不用递归
            while (queue.Count != 0)
            {
                //先将第一个出队的顶点取出
                int curv = queue.Dequeue();
                //然后找寻它未被遍历的相邻顶点入队
                foreach (var w in graph.Adj(curv))
                {
                    if (!visited[w])
                    {
                        visited[w] = true;
                        //若未访问则将下一顶点的颜色改为当前顶点的相反值
                        colors[w] = !colors[curv];
                        //将v加入队列中
                        queue.Enqueue(w);

                    }
                    else if (colors[w] == colors[curv])
                    {
                        isBipartite = false;
                    }
                }
            }

        }

        public bool IsBipartite()
        {

            return isBipartite;
        }
    }

    
}
