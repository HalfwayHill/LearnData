using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.BFS
{
    /// <summary>
    /// 广度优先遍历
    /// </summary>
    class BFSCycleDetection
    {
        //通过接口扩展Class，这样无论是邻接矩阵或邻接表都可直接对接
        private IGraph graph;
        //是否被遍历过
        private bool[] visited;
        //广度优先遍历中的存储顶点的队列
        private Queue<int> queue = new Queue<int>();
        //记录顶点数组
        int[] pre;
        //是否存在环
        bool hasCycle = false;

        public BFSCycleDetection(IGraph graph)
        {
            this.graph = graph;
            visited = new bool[graph.V()];
            pre = new int[graph.V()];

            for (int v = 0; v < graph.V(); v++)
            {
                pre[v] = -1;
            }

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
                        pre[w] = curv;
                        //将v加入队列中
                        queue.Enqueue(w);

                    }//当前顶点的上一顶点是否为现在遍历的顶点
                    else if (w != pre[curv])
                    {
                        hasCycle = true;
                    }
                }
            }


        }

        /// <summary>
        /// 判断图中是否存在环
        /// </summary>
        /// <returns></returns>
        public bool HasCycle()
        {
            return hasCycle;
        }
    }

    
}
