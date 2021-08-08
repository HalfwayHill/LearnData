using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyArray
{
    /// <summary>
    /// 动态循环数组
    /// </summary>
    class Array2<T>
    {
        private T[] data;
        private int first;
        private int last;
        private int n;

        public Array2(int capacity)
        {
            data = new T[capacity];

            last = 0;
            first = 0;
            n = 0;
        }

        public Array2() : this(10) { }

        public int Count { get { return n; } }

        public bool IsEmpty { get { return n == 0; } }

        /// <summary>
        /// 添加数据到末尾
        /// </summary>
        /// <param name="t">要添加的数据</param>
        public void Add(T t)
        {
            //扩容
            if (n == data.Length)
                ResetCapacity(2 * data.Length);

            data[last] = t;
            //不能单纯的last++，应该使其循环起来
            last = (last + 1) % data.Length;
            n++;
        }

        public T RemoveFirst()
        {
            if (this.IsEmpty)
                throw new InvalidOperationException("数组为空");

            T del = data[first];
            data[first] = default(T);

            first = (first + 1) % data.Length;
            n--;

            if (n == data.Length / 4)
                ResetCapacity(data.Length / 2);

            return del;
        }

        public T FindFirst()
        {
            if (this.IsEmpty)
                throw new InvalidOperationException("数组为空");

            return data[first];
        }

        /*
         * 循环动态数组的扩容策略
         * 是将以first为开头作为新数组的第0个位置
         * 通过(first + 1) % data.Length操作移动first找到相应的元素
         * 从而复制到新的数组中
         * 再更新first和last指针，first变为0 而last则是上个数组的容量
         */

        /// <summary>
        /// 循环动态数组的扩容策略
        /// </summary>
        /// <param name="newCapacity"></param>
        private void ResetCapacity(int newCapacity)
        {
            T[] newData = new T[newCapacity];
            for (int i = 0; i < n; i++)
            {
                newData[i] = data[(first + i) % data.Length];
            }

            first = 0;
            last = data.Length;

            data = newData;
        }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.Append("[");
            for (int i = 0; i < n; i++)
            {
                res.Append(data[(first + i) % data.Length]);
                if ((first + i + 1) % data.Length != last)
                    res.Append(", ");
            }
            res.Append("]");
            return res.ToString();
        }
    }
}
