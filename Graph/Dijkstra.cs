using Graph.Adjacency;
using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class Dijkstra
    {
        private IGraph g;
        // 起始点
        private int source;
        // 根据起始点的路径数组
        private int[] dis;
        // 顶点是否查看过
        private bool[] visited;

        public Dijkstra(IGraph g,int s)
        {
            this.g = g;
            this.source = s;

            dis = new int[g.V()];
            visited = new bool[g.V()];

            // 将各个顶点的带权路径默认设置为无穷(int的最大值)，认为到达不了
            for (int i = 0; i < dis.Length; i++)
            {
                dis[i] = int.MaxValue;
            }

            //将源头设为0
            dis[source] = 0;

            while (true)
            {
                // 1.找到当前最短的带权路径的顶点
                int curv = -1;
                int curdis = int.MaxValue;

                for (int v = 0; v < g.V(); v++)
                {
                    // 检测是否访问过且小于前面的带权路径的顶点
                    if (!visited[v] && dis[v] < curdis)
                    {
                        curdis = dis[v];
                        curv = v;
                    }
                }

                // 根据条件没有找到相关顶点，退出算法
                if (curv == -1) break;

                // 2.确认这个顶点
                visited[curv] = true;

                // 3.更新带权路径数组dis
                foreach (int w in g.Adj(curv))
                {
                    if (!visited[w])
                    {
                        if (dis[curv] + ((AdjDictionary)g).GetWeight(curv,w) < dis[w])
                        {
                            dis[w] = dis[curv] + ((AdjDictionary)g).GetWeight(curv, w);
                        }
                    }
                }
            }
        }

        public int DisTo(int v)
        {
            //可能非法
            return dis[v];
        }

        public bool IsConnected(int v)
        {
            return visited[v];
        }
    }
}
