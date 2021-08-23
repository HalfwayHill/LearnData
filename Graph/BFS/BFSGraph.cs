using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.BFS
{
    /// <summary>
    /// 广度优先遍历
    /// </summary>
    class BFSGraph
    {
        //通过接口扩展Class，这样无论是邻接矩阵或邻接表都可直接对接
        private IGraph graph;
        //是否被遍历过
        private bool[] visited;
        //广度优先遍历中的存储顶点的队列
        private Queue<int> queue = new Queue<int>();
        //存储遍历的结果
        private MyList<int> list = new MyList<int>();

        public BFSGraph(IGraph graph)
        {
            this.graph = graph;
            visited = new bool[graph.V()];

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
            #region 自己的思考 自己还是想用递归

            /*

            //遍历v的邻接顶点，如果没遍历过，继续深度遍历
            foreach (var w in graph.Adj(v))
            {
                if (!visited[w])
                {
                    //将v加入队列中
                    queue.Enqueue(w);

                }
            }

            //判断当前队列中是否拥有顶点
            if (queue.Count != 0)
            {
                BFS(queue.Dequeue());
            }
            */
            #endregion
            //这样不用递归
            while (queue.Count != 0)
            {
                //先将第一个出队的顶点取出
                int curv = queue.Dequeue();
                list.Add(curv);
                //然后找寻它未被遍历的相邻顶点入队
                foreach (var w in graph.Adj(curv))
                {
                    if (!visited[w])
                    {
                        visited[w] = true;
                        //将v加入队列中
                        queue.Enqueue(w);

                    }
                }
            }

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
