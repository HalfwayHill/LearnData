using LearnData.MyHeap;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyQueue
{
    /// <summary>
    /// Min Priority Queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MinPQ<T> : IQueue<T> where T : IComparable<T>
    {
        private MinHeap<T> minHeap;

        public MinPQ(int capacity)
        {
            minHeap = new MinHeap<T>(capacity);
        }
        public MinPQ()
        {
            minHeap = new MinHeap<T>();
        }
        public int Count { get { return minHeap.Count; } }

        public bool IsEmpty { get { return minHeap.IsEmpty; } }

        public T Dequeue()
        {
            return minHeap.RemoveMin();
        }

        public void Enqueue(T t)
        {
            minHeap.Insert(t);
        }

        public T Peek()
        {
            return minHeap.FindMin();
        }

        public override string ToString()
        {
            return minHeap.ToString();
        }
    }
}
