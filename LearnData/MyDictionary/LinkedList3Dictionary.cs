using LearnData.MyLinkedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyDictionary
{
    class LinkedList3Dictionary<Key, Value> : IDictionary<Key, Value>
    {
        private LinkedList3<Key, Value> linkedList;

        public LinkedList3Dictionary()
        {
            linkedList = new LinkedList3<Key, Value>();
        }


        public int Count { get { return linkedList.Count; } }

        public bool IsEmpty { get { return linkedList.IsEmpty; } }

        public void Add(Key key, Value value)
        {
            linkedList.Add(key, value);
        }

        public bool Contains(Key key)
        {
            return linkedList.Contains(key);
        }

        public Value Find(Key key)
        {
            return linkedList.FindValue(key);
        }

        public void Remove(Key key)
        {
            linkedList.Remove(key);
        }

        public void Set(Key key, Value newValue)
        {
            linkedList.Set(key, newValue);
        }
    }
}
