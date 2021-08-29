using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.UF
{
    /// <summary>
    /// 该并查集为查询快O(1) 合并慢O(n)
    /// </summary>
    class UnionFind1 : IUF
    {
        private int[] id;

        public UnionFind1(int size)
        {
            id = new int[size];

            for (int i = 0; i < id.Length; i++)
            {
                id[i] = i;
            }
        }

        public int GetSize()
        {
            return id.Length;
        }

        private int Find(int p)
        {
            //可能会非法
            return id[p];
        }

        public bool IsConnected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public void Union(int p, int q)
        {
            int pId = Find(p);
            int qId = Find(q);

            if (pId == qId) return;

            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] == pId)
                {
                    id[i] = qId;
                }
            }
        }
    }
}
