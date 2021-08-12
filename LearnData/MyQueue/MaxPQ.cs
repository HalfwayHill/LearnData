using LearnData.MyHeap;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyQueue
{
    /// <summary>
    /// Max Priority Queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MaxPQ<T> : IQueue<T> where T : IComparable<T>
    {
        private MaxHeap<T> maxHeap;

        public MaxPQ(int capacity)
        {
            maxHeap = new MaxHeap<T>(capacity);
        }
        public MaxPQ()
        {
            maxHeap = new MaxHeap<T>();
        }
        public int Count { get { return maxHeap.Count; } }

        public bool IsEmpty { get { return maxHeap.IsEmpty; } }

        public T Dequeue()
        {
            return maxHeap.RemoveMax();
        }

        public void Enqueue(T t)
        {
            maxHeap.Insert(t);
        }

        public T Peek()
        {
            return maxHeap.FindMax();
        }

        public override string ToString()
        {
            return maxHeap.ToString();
        }
    }
}
