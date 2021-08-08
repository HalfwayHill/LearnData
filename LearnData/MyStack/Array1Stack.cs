using LearnData.MyArray;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyStack
{
    /*
     * 通过复用动态数组快速组建栈
     * 受限的线性数据结构
     */

    /// <summary>
    /// 数组栈
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Array1Stack<T> : IStack<T>
    {
        private Array1<T> arr;

        public Array1Stack(int capacity)
        {
            arr = new Array1<T>(capacity);
        }

        public Array1Stack()
        {
            arr = new Array1<T>();
        }

        public int Count { get { return arr.Count; } }

        public bool IsEmpty { get{ return arr.IsEmpty; } }

        public T Peek()
        {
            //因为向数组尾部操作为O(1),效率更好，所以我们选择尾部为栈顶
            return arr.FindLast();
        }

        public T Pop()
        {
            return arr.RemoveLast();
        }

        public void Push(T t)
        {
            arr.Add(t);
        }

        public override string ToString()
        {
            return "Stack:" + arr.ToString() + "Top";
        }
    }
}
