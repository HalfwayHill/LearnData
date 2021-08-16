using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    interface IGraph
    {
        int V();
        int E();

        /// <summary>
        /// 判断两点是否相邻(有边相连)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        bool HasEdge(int a, int b);

        /// <summary>
        /// 求一个点的相邻顶点数
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        int Degree(int a);

        /*
         * 使用IEnumerable<T>接口 返回数据结构
         */

        /// <summary>
        /// 求一个点的相邻顶点
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        IEnumerable<int> Adj(int a);
    }
}
