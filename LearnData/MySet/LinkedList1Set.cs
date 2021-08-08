using LearnData.MyLinkedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MySet
{
    class LinkedList1Set<T> : ISet<T>
    {
        private LinkedList1<T> linkedList;

        public LinkedList1Set()
        {
            linkedList = new LinkedList1<T>();
        }

        public int Count { get { return linkedList.Count; } }

        public bool IsEmpty { get { return linkedList.IsEmpty; } }

        public void Add(T t)
        {
            if (!linkedList.Contains(t))
            {
                linkedList.AddFirst(t);
            }
            
        }

        public bool Contains(T t)
        {
            return linkedList.Contains(t);
        }

        public void Remove(T t)
        {
            linkedList.Remove(t);
        }
    }
}
