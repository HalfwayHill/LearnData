using LearnData.MyArray;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyQueue
{
    /// <summary>
    /// 数组队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Array1Queue<T> : IQueue<T>
    {
        private Array1<T> arr;

        public Array1Queue(int capacity)
        {
            arr = new Array1<T>(capacity);
        }
        public Array1Queue()
        {
            arr = new Array1<T>();
        }
        public int Count { get { return arr.Count; } }

        public bool IsEmpty { get { return arr.IsEmpty; } }

        public T Dequeue()
        {
            //O(n)
            return arr.RemoveFirst();
        }

        public void Enqueue(T t)
        {
            //选择数组的尾部作为队尾 为什么？
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
