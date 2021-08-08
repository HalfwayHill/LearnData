using LearnData.MyLinkedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyStack
{
    /// <summary>
    /// 链表栈
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedList1Stack<T> : IStack<T>
    {
        private LinkedList1<T> linkedList1;

        public LinkedList1Stack()
        {
            linkedList1 = new LinkedList1<T>();
        }


        public int Count { get { return linkedList1.Count; } }

        public bool IsEmpty { get { return linkedList1.IsEmpty; } }

        public T Peek()
        {
            //依靠链表组成栈，所以选择链表Head作为栈顶
            return linkedList1.FindFirst();
        }

        public T Pop()
        {
            return linkedList1.RemoveFirst();
        }

        public void Push(T t)
        {
            linkedList1.AddFirst(t);
        }

        public override string ToString()
        {
            return "Stack:Top" + linkedList1.ToString();
        }
    }
}
