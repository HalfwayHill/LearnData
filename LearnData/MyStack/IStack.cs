using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyStack
{
    interface IStack<T>
    {
        int Count { get; }
        bool IsEmpty { get; }
        /// <summary>
        /// 将数据压入栈顶
        /// </summary>
        /// <param name="t"></param>
        void Push(T t);
        /// <summary>
        /// 将数据从栈顶取出
        /// </summary>
        /// <returns></returns>
        T Pop();
        /// <summary>
        /// 获取栈顶数据
        /// </summary>
        /// <returns></returns>
        T Peek();

    }
}
