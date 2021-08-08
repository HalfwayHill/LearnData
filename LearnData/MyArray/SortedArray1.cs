using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyArray
{
    //对于Key,我们要进行限定，必须限定可比较的值
    //限定的方式是 where Key : IComparable<Key>
    class SortedArray1<Key> where Key : IComparable<Key>
    {
        private Key[] keys;
        private int N;

        public SortedArray1(int capacity)
        {
            keys = new Key[capacity];
            N = 0;
        }

        public SortedArray1() : this(10) { }

        //数组容量
        public int Capacity
        {
            get { return keys.Length; }
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
        /// 使用二分查询方法找出小于指定键的数量
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Rank(Key key)
        {
            int l = 0;
            int r = N - 1;

            while (l <= r)
            {
                //int mid = (r + 1) / 2;
                //防止l和r接近溢出
                int mid = l + (r - l) / 2;

                //这里调用IComparable中的CompareTo()方法进行比较
                if (key.CompareTo(keys[mid]) < 0)
                    r = mid - 1;
                else if (key.CompareTo(keys[mid]) > 0)
                    l = mid + 1;
                else
                    return mid;

            }

            return l;
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="n">要添加的数据</param>
        public void Add(Key key)
        {
            int i = Rank(key);

            //扩容
            if (N == keys.Length)
                ResetCapacity(2 * keys.Length);

            //查找到位置 判断是否有此值
            if (i < N && keys[i].CompareTo(key) == 0)
                return;

            for (int j = N - 1; j >= i; j--)
                keys[j + 1] = keys[j];

            keys[i] = key;
            N++;
        }

        /// <summary>
        /// 移除数据
        /// </summary>
        /// <param name="n"></param>
        public void Remove(Key key)
        {
            if (this.IsEmpty)
                return;

            int i = Rank(key);
            //查找到位置 判断是否有此值
            if (i == N || keys[i].CompareTo(key) != 0)
                return;

            for (int j = i; j < N - 1; j++)
                keys[j] = keys[j + 1];

            keys[N - 1] = default(Key);
            N--;

            if (N == keys.Length / 4)
                ResetCapacity(keys.Length / 2);
        }

        public Key Min()
        {
            if (this.IsEmpty)
                throw new ArgumentException("数组为空");

            return keys[0];
        }

        public Key Max()
        {
            if (this.IsEmpty)
                throw new ArgumentException("数组为空");

            return keys[N - 1];
        }

        public Key Select(int n)
        {
            if (n < 0 || n >= N)
                throw new ArgumentException("越界索引");

            return keys[n];
        }

        /// <summary>
        /// 找出小于或等于key的最大数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Key Floor(Key key)
        {
            int i = Rank(key);
            //查找到位置 判断是否有此值
            if (i < N && keys[i].CompareTo(key) == 0)
                return keys[i];

            if (i == 0)
                throw new ArgumentException("没有找到小于或等于key的最大数据");
            else
                return keys[i - 1];

        }

        /// <summary>
        /// 找出大于于或等于key的最大数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Key Ceiling(Key key)
        {
            int i = Rank(key);

            if (i == N)
                throw new ArgumentException("没有找到大于或等于key的最大数据");
            else
                return keys[i];
     
        }

        public bool Contains(Key key)
        {
            int i = Rank(key);
            //查找到位置 判断是否有此值
            if (i < N && keys[i].CompareTo(key) == 0)
                return true;

            return false;
        }

        /// <summary>
        /// 扩容操作，也就是实现动态数组
        /// </summary>
        /// <param name="newCapacity"></param>
        private void ResetCapacity(int newCapacity)
        {
            Key[] newData = new Key[newCapacity];
            for (int i = 0; i < N; i++)
            {
                newData[i] = keys[i];
            }

            keys = newData;
        }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            //res.Append(string.Format($"Array1 Capacity:{this.Capacity} Count:{this.Count}\n"));
            res.Append("[");
            for (int i = 0; i < N; i++)
            {
                res.Append(keys[i]);
                if (i != N - 1)
                    res.Append(", ");
            }
            res.Append("]");
            return res.ToString();
        }
    }
}
