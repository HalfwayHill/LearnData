using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.UF
{
    interface IUF
    {
        /// <summary>
        /// 当前并查集的大小
        /// </summary>
        /// <returns></returns>
        int GetSize();

        /// <summary>
        /// 合并操作，将两个数据合并到一个集合当中
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        void Union(int p, int q);

        /// <summary>
        /// 查询两顶点之间是否相连
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        bool IsConnected(int p, int q);

    }
}
