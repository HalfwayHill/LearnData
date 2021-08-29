using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.UF
{
    class UnionFind2 : IUF
    {
        private int[] parent;

        public UnionFind2(int size)
        {
            parent = new int[size];

            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
            }
        }

        public int GetSize()
        {
            return parent.Length;
        }

        /// <summary>
        /// 不断的向根节点查询
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private int Find(int p)
        {
            while (p != parent[p])
            {
                p = parent[p];
            }

            return p;
        }

        public bool IsConnected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public void Union(int p, int q)
        {
            int pRoot = Find(p);
            int qRoot = Find(q);

            if (pRoot == qRoot) return;

            parent[pRoot] = qRoot;
        }
    }
}
