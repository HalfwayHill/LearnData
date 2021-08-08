using LearnData.MyLinkedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyQueue
{
    /// <summary>
    /// 使用具有尾部指针的链表的链表队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedList2Queue<T> : IQueue<T>
    {
        private LinkedList2<T> linkedList2;

        public LinkedList2Queue()
        {
            linkedList2 = new LinkedList2<T>();
        }


        public int Count { get { return linkedList2.Count; } }

        public bool IsEmpty { get { return linkedList2.IsEmpty; } }

        public T Dequeue()
        {
            return linkedList2.RemoveFirst();
        }

        public void Enqueue(T t)
        {
            linkedList2.Add(t);
        }

        public T Peek()
        {
            return linkedList2.FindFirst();
        }

        public override string ToString()
        {
            return "Queue:Front" + linkedList2.ToString() + "Tail";
        }
    }
}
