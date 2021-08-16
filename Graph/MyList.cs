using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class MyList<T> : List<T>
    {
        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.Append('[');
            for (int i = 0; i < base.Count; i++)
            {
                res.Append(base[i]);
                if (i != base.Count - 1)
                    res.Append(", ");
            }
            res.Append(']');
            return res.ToString();
        }
    }
}
