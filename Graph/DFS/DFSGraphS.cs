using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.DFS
{
    class DFSGraphS
    {
        private IGraph G;
        private bool[] visited;
        private MyList<int> list = new MyList<int>();

        public DFSGraphS(IGraph G)
        {
            this.G = G;
            visited = new bool[G.V()];

            for (int v = 0; v < G.V(); v++)
                if (!visited[v])
                    DFS(v);

        }

        private void DFS(int v)
        {
            visited[v] = true;
            list.Add(v);
            foreach (int w in G.Adj(v))
            {
                if (!visited[w])
                    DFS(w);
            }
        }

        public MyList<int> GetList()
        {
            return list;
        }
    }
}
