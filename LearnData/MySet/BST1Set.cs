using LearnData.MyTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MySet
{
    class BST1Set<T> : ISet<T> where T : IComparable<T>
    {
        private BST1<T> bst;

        public BST1Set()
        {
            bst = new BST1<T>();
        }

        public int Count { get { return bst.Count; } }

        public bool IsEmpty { get { return bst.IsEmpty; } }

        public void Add(T t)
        {
            bst.Add(t);
        }

        public bool Contains(T t)
        {
            return bst.Contains(t);
        }

        public void Remove(T t)
        {
            bst.Remove(t);
        }

        public int MaxHeight()
        {
            return bst.MaxHeight();
        }
    }
}
