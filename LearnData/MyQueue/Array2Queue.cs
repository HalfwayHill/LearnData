using LearnData.MyArray;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyQueue
{
    /// <summary>
    /// 循环队列(使用循环动态数组)
    /// </summary>
    class Array2Queue<T> : IQueue<T>
    {
        private Array2<T> arr;

        public Array2Queue(int capacity)
        {
            arr = new Array2<T>(capacity);
        }
        public Array2Queue()
        {
            arr = new Array2<T>();
        }
        public int Count { get { return arr.Count; } }

        public bool IsEmpty { get { return arr.IsEmpty; } }

        public T Dequeue()
        {
            //循环动态数组 此操作是O(1)
            //O(1)
            return arr.RemoveFirst();
        }

        public void Enqueue(T t)
        {
            //O(1)
            arr.Add(t);
        }

        public T Peek()
        {
            //数组查询 O(1)
            return arr.FindFirst();
        }

        public override string ToString()
        {
            return "Queue:Front" + arr.ToString() + "Tail";
        }
    }
}
