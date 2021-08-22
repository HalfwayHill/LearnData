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
        //联通分量 指图中不相连的部分数
        private int ccount = 0;
        //源顶点 即开始顶点
        private int soucePath;
        //记录各个顶点的上个顶点
        private int[] pre;
        //图中是否存在环
        private bool hasCycle;
        //顶点染色，用于分辨是否为二分图
        private bool[] colors;
        //是否为二分图
        private bool isBipartite = false;

        public DFSGraph(IGraph graph)
        {
            this.graph = graph;
            visited = new bool[graph.V()];
            pre = new int[graph.V()];
            colors = new bool[graph.V()];

            for (int i = 0; i < pre.Length; i++)
            {
                pre[i] = -1;
            }

            //DFS(0);
            //这样改进的好处是当某个节点没有任何链接的时候，也能找到
            for (int v = 0; v < graph.V(); v++)
            {
                if (!visited[v])
                {
                    DFS(v);
                    ccount++;
                }
                    
            }
        }

        /// <summary>
        /// 传入源顶点获取当前顶点的单源路径
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="s"></param>
        public DFSGraph(IGraph graph, int s)
        {
            this.graph = graph;
            this.soucePath = s;
            visited = new bool[graph.V()];
            pre = new int[graph.V()];

            for (int i = 0; i < pre.Length; i++)
            {
                pre[i] = -1;
            }

            DFS(s);
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
                {
                    //当找到为遍历的顶点时，设置它的颜色和当前顶点的颜色相反
                    colors[w] = !colors[v];
                    RecordPre(w, v);
                    DFS(w);

                }//环检测，如果当前顶点的已遍历的联通节点不是它的上一个顶点，那么它是一个环
                else if (w != pre[v])
                {
                    hasCycle = true;
                }
                    
            }

            //这样就会获取到所有的遍历结果
        }

        /// <summary>
        /// 记录上个顶点 用于单源路径
        /// </summary>
        /// <param name="w"></param>
        /// <param name="v"></param>
        private void RecordPre(int w, int v)
        {
            if (pre != null && pre.Length == graph.V())
            {
                pre[w] = v;
            }
        }

        /// <summary>
        /// 获取当前单源路径是否链接到该顶点
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsConnectedTo(int t)
        {
            if (pre.Length != graph.V())
            {
                return false;
            }

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
            while (cur != soucePath)
            {
                res.Add(cur);
                cur = pre[cur];
            }

            res.Add(soucePath);
            //反转顺序
            res.Reverse();

            return res;
        }

        /// <summary>
        /// 获取遍历结果
        /// </summary>
        /// <returns></returns>
        public MyList<int> GetList()
        {
            return list;
        }

        /// <summary>
        /// 获取联通分量
        /// </summary>
        /// <returns></returns>
        public int Component()
        {
            return ccount;
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
