using LearnData.MyTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MySet
{
    class RBT1Set<T> : ISet<T> where T : IComparable<T>
    {
        private RBT1<T> rbt;

        public RBT1Set()
        {
            rbt = new RBT1<T>();
        }

        public int Count { get { return rbt.Count; } }

        public bool IsEmpty { get { return rbt.IsEmpty; } }

        public void Add(T t)
        {
            rbt.Add(t);
        }

        public bool Contains(T t)
        {
            return rbt.Contains(t);
        }

        public void Remove(T t)
        {
            Console.WriteLine("待实现");
        }

        public int MaxHeight()
        {
            return rbt.MaxHeight();
        }
    }
}
