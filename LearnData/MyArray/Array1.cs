using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyArray
{
    class Array1<T>
    {
        /*
         * 当前的Array1使用的是int类型，这也就以为着局限性
         * 扩展使用场景可以有两种方案
         * 第一种
         * 将int类型改为object类型，因为object是所有类型的父类
         * 在使用时，再将其强制转换
         * C#中就使用的这种方案
         * 但是这样又会出现装箱拆箱的问题，会增加运行效率
         * 第二种就是使用泛型
         * 这种就是C#中的List
         */



        //动态数组实际还是静态数组，不过加上了扩容的能力
        private T[] data;
        //数组个数
        private int N;
        //用户自己设定开始容量
        public Array1(int capacity)
        {
            data = new T[capacity];
            N = 0;
        }
        /*
         * 调用自己这个类的某个构造函数，
         * 因为有的类构造函数很多参数，
         * 而有的参数又不是必须填写，
         * 或者可以提供一些默认值，
         * 就跟重载是一样的道理。
         */
        public Array1() : this(10) { }

        //public Array1()
        //{
        //    data = new int[10];
        //    N = 0;
        //}
        /* 这里只允许用户访问，不允许用户修改 */
        //数组容量
        public int Capacity
        {
            get { return data.Length; }
        }
        //动态数组实际存储数据多少
        public int Count
        {
            get { return N; }
        }
        //数据是否为空
        public bool IsEmpty
        {
            get { return N == 0; }
        }

        /// <summary>
        /// 插入元素
        /// </summary>
        /// <param name="index">插入位置</param>
        /// <param name="n">要插入的元素</param>
        public void Insert(int index,T n)
        {
            if (index < 0 || index > N)
                throw new ArgumentException("数组索引越界");

            //扩容
            if (N == data.Length)
                ResetCapacity(2 * data.Length);

            for (int i = N; i > index; i--)
                data[i] = data[i - 1];

            data[index] = n;
            N++;
        }

        /// <summary>
        /// 添加数据到末尾
        /// </summary>
        /// <param name="n">要添加的数据</param>
        public void Add(T n)
        {
            this.Insert(N, n);
        }

        /// <summary>
        /// 添加数据到第一个
        /// </summary>
        /// <param name="n"></param>
        public void AddFirst(T n)
        {
            this.Insert(0, n);
        }

        /// <summary>
        /// 查询第index个数据
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Find(int index)
        {
            if (index < 0 || index >= N)
                throw new ArgumentException("数组索引越界");

            return data[index];
        }

        public T FindFirst()
        {
            return Find(0);
        }

        public T FindLast()
        {
            return Find(N - 1);
        }

        public void Set(int index,T newN)
        {
            if (index < 0 || index >= N)
                throw new ArgumentException("数组索引越界");

            data[index] = newN;
        }

        public bool Contains(T n)
        {
            for (int i = 0; i < N; i++)
            {
                if (data[i].Equals(n))
                    return true;
            }

            return false;
        }

        public int IndexOf(T n)
        {
            for (int i = 0; i < N; i++)
            {
                if (data[i].Equals(n))
                    return i;
            }

            return -1;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= N)
                throw new ArgumentException("数组索引越界");

            T del = data[index];

            for (int i = index + 1; i < N; i++)
                data[i - 1] = data[i];

            N--;

            //通知GC(C#中的垃圾回收机制)，回收数据
            data[N] = default(T);

            //还要进行缩容
            /* 如果判断条件是data.Length / 2时，
             * 当数组就在data.Length / 2的临界点频繁进行增加和删除时，
             * 会大量占用操作，影响效率，所以将条件再减一半
             */
            if (N == data.Length / 4)
                ResetCapacity(data.Length / 2);

            return del;
        }

        public T RemoveFirst()
        {
            return RemoveAt(0);
        }

        public T RemoveLast()
        {
            return RemoveAt(N - 1);
        }

        public void Remove(T n)
        {
            int index = IndexOf(n);
            if (index != -1)
                RemoveAt(index);
        }

        /// <summary>
        /// 扩容操作，也就是实现动态数组
        /// </summary>
        /// <param name="newCapacity"></param>
        private void ResetCapacity(int newCapacity)
        {
            T[] newData = new T[newCapacity];
            for (int i = 0; i < N; i++)
            {
                newData[i] = data[i];
            }

            data = newData;
        }

        /// <summary>
        /// 重写ToString方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            //res.Append(string.Format($"Array1 Capacity:{this.Capacity} Count:{this.Count}\n"));
            res.Append("[");
            for (int i = 0; i < N; i++)
            {
                res.Append(data[i]);
                if (i != N - 1)
                    res.Append(", ");
            }
            res.Append("]");
            return res.ToString();
        }
    }
}
