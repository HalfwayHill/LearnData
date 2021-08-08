using LearnData.MyTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyDictionary
{
    class BST2Dictionary<Key, Value> : IDictionary<Key, Value> where Key : IComparable<Key>
    {
        private BST2<Key, Value> bst;

        public BST2Dictionary()
        {
            bst = new BST2<Key, Value>();
        }

        public int Count { get { return bst.Count; } }

        public bool IsEmpty { get { return bst.IsEmpty; } }

        public void Add(Key key, Value value)
        {
            bst.Add(key, value);
        }

        public bool Contains(Key key)
        {
            return bst.Contains(key);
        }

        public Value Find(Key key)
        {
            return bst.FindValue(key);
        }

        public void Remove(Key key)
        {
            bst.Remove(key);
        }

        public void Set(Key key, Value newValue)
        {
            bst.SetValue(key, newValue);
        }
    }
}
