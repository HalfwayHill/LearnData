using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.DFS
{
    /// <summary>
    /// 非递归深度优先遍历(即使用栈来代替递归栈)
    /// </summary>
    class DFSGraphNR
    {
        //通过接口扩展Class，这样无论是邻接矩阵或邻接表都可直接对接
        private IGraph graph;
        //是否被遍历过
        private bool[] visited;
        //非递归深度优先遍历中的存储顶点的栈
        private Stack<int> stack = new Stack<int>();
        //存储遍历的结果
        private MyList<int> list = new MyList<int>();

        public DFSGraphNR(IGraph graph)
        {
            this.graph = graph;
            visited = new bool[graph.V()];

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
            stack.Push(v);
            //这样不用递归
            while (stack.Count != 0)
            {
                //先将第一个出栈的顶点取出
                int curv = stack.Pop();
                list.Add(curv);
                //然后找寻它未被遍历的相邻顶点入队
                foreach (var w in graph.Adj(curv))
                {
                    if (!visited[w])
                    {
                        visited[w] = true;
                        //将v加入栈中
                        stack.Push(w);

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
