using LearnData.MyLinkedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyQueue
{
    /// <summary>
    /// 链表队列
    /// </summary>
    class LinkedList1Queue<T> : IQueue<T>
    {
        private LinkedList1<T> linkedList1;

        public LinkedList1Queue()
        {
            linkedList1 = new LinkedList1<T>();
        }


        public int Count { get { return linkedList1.Count; } }

        public bool IsEmpty { get { return linkedList1.IsEmpty; } }

        public T Dequeue()
        {
            return linkedList1.RemoveFirst();
        }

        public void Enqueue(T t)
        {
            linkedList1.Add(t);
        }

        public T Peek()
        {
            return linkedList1.FindFirst();
        }

        public override string ToString()
        {
            return "Queue:Front" + linkedList1.ToString() + "Tail";
        }
    }
}
