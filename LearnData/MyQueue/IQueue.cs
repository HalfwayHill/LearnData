using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyQueue
{
    interface IQueue<T>
    {
        int Count { get; }
        bool IsEmpty { get; }
        /// <summary>
        /// 获取队首数据
        /// </summary>
        /// <returns></returns>
        T Peek();
        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        T Dequeue();
        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="t"></param>
        void Enqueue(T t);
    }
}
