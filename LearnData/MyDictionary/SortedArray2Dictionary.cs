using LearnData.MyArray;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyDictionary
{
    class SortedArray2Dictionary<Key, Value> : IDictionary<Key, Value> where Key : IComparable<Key>
    {
        private SortedArray2<Key, Value> sortedArray;

        public SortedArray2Dictionary()
        {
            sortedArray = new SortedArray2< Key, Value > ();
        }

        public int Count { get { return sortedArray.Count; } }

        public bool IsEmpty { get { return sortedArray.IsEmpty; } }

        public void Add(Key key, Value value)
        {
            sortedArray.Add(key, value);
        }

        public bool Contains(Key key)
        {
            return sortedArray.Contains(key);
        }

        public Value Find(Key key)
        {
            return sortedArray.FindValue(key);
        }

        public void Remove(Key key)
        {
            sortedArray.Remove(key);
        }

        public void Set(Key key, Value newValue)
        {
            if (sortedArray.Contains(key))
            {
                sortedArray.Add(key, newValue);
            }
            
        }
    }
}
