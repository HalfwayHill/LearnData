using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Graph
{
    class Edge : IComparable<Edge>
    {
        //边的一个顶点
        int a;
        //边的另一个顶点
        int b;
        //边的权重
        int w;

        public Edge(int a,int b,int w)
        {
            this.a = a;
            this.b = b;
            this.w = w;
        }

        public int CompareTo(Edge other)
        {
            return this.w - other.w;
        }

        public int GetA()
        {
            return a;
        }

        public int GetB()
        {
            return b;
        }

        public override string ToString()
        {
            return string.Format($"{a}-{b} : {w}");
        }
    }
}
