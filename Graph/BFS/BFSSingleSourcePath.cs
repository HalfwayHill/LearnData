using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.BFS
{
    /// <summary>
    /// 广度优先遍历
    /// </summary>
    class BFSSingleSourcePath
    {
        //通过接口扩展Class，这样无论是邻接矩阵或邻接表都可直接对接
        private IGraph graph;
        //是否被遍历过
        private bool[] visited;
        //广度优先遍历中的存储顶点的队列
        private Queue<int> queue = new Queue<int>();
        //单源路径存储上一节点的数组
        int[] pre;
        //源头Source
        int s;
        //单源路径距离
        int[] dis;

        public BFSSingleSourcePath(IGraph graph, int source)
        {
            this.graph = graph;
            this.s = source;
            visited = new bool[graph.V()];
            pre = new int[graph.V()];
            dis = new int[graph.V()];

            for (int v = 0; v < graph.V(); v++)
            {
                pre[v] = -1;
                dis[v] = -1;
            }

            dis[s] += 1;
            //就找到源头s的单源路径
            BFS(this.s);
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
                //然后找寻它未被遍历的相邻顶点入队
                foreach (var w in graph.Adj(curv))
                {
                    if (!visited[w])
                    {
                        visited[w] = true;
                        //将即将要遍历的顶点w的上一顶点放入数组中
                        pre[w] = curv;
                        dis[w] = dis[curv] + 1; 

                        //将v加入队列中
                        queue.Enqueue(w);

                    }
                }
            }

        }

        /// <summary>
        /// 获取当前单源路径是否链接到该顶点
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsConnectedTo(int t)
        {
            return visited[t];
        }

        /// <summary>
        /// 获取顶点的单源路径
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public MyList<int> Path(int t)
        {
            MyList<int> res = new MyList<int>();

            if (!IsConnectedTo(t))
            {
                return res;
            }

            int cur = t;
            while (cur != s)
            {
                res.Add(cur);
                cur = pre[cur];
            }

            res.Add(s);
            //反转顺序
            res.Reverse();

            return res;
        }

        /// <summary>
        /// 获取顶点V到源点的距离
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public int GetDis(int v)
        {
            return dis[v];
        }
    }

    
}
