using LearnData.MyArray;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MySet
{
    class SortedArray1Set<T> : ISet<T> where T : IComparable<T>
    {
        private SortedArray1<T> sortedArray;

        public SortedArray1Set()
        {
            sortedArray = new SortedArray1<T>();
        }

        public int Count { get { return sortedArray.Count; } }

        public bool IsEmpty { get { return sortedArray.IsEmpty; } }

        public void Add(T t)
        {
            sortedArray.Add(t);
        }

        public bool Contains(T t)
        {
            return sortedArray.Contains(t);
        }

        public void Remove(T t)
        {
            sortedArray.Remove(t);
        }
    }
}
