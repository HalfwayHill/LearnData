using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyDictionary
{
    interface IDictionary<Key, Value>
    {
        int Count { get; }
        bool IsEmpty { get; }
        void Add(Key key, Value value);
        void Remove(Key key);
        bool Contains(Key key);
        Value Find(Key key);
        void Set(Key key, Value newValue);
    }
}
