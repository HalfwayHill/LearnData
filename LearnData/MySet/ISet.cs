using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MySet
{
    interface ISet<T>
    {
        int Count { get; }
        bool IsEmpty { get; }

        void Add(T t);
        void Remove(T t);
        bool Contains(T t);
    }
}
