using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.MyHeap
{
    /*
     * 使用递归会导致 栈溢出
     */
    class MaxHeap<T> where T : IComparable<T>
    {

        private T[] heap;

        //数组个数
        private int N;
        //用户自己设定开始容量
        public MaxHeap(int capacity)
        {
            heap = new T[capacity + 1];
            N = 0;
        }
        public MaxHeap() : this(10) { }

        //数组容量
        public int Capacity
        {
            get { return heap.Length; }
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

        // <summary>
        /// 插入元素
        /// </summary>
        /// <param name="index">插入位置</param>
        /// <param name="n">要插入的元素</param>
        public void Insert(T t)
        {
            //if (index < 0 || index > N)
            //    throw new ArgumentException("数组索引越界");

            //扩容
            if (N == heap.Length - 1)
                ResetCapacity(2 * heap.Length);

            heap[N + 1] = t;
            N++;
            Swim(N);
        }

        public T RemoveMax()
        {
            if (this.IsEmpty)
                throw new ArgumentException("堆为空！");

            T max = heap[1];
            Swap(heap, 1, N);
            heap[N] = default(T);
            N--;
            Sink(1);

            if (N == (heap.Length - 1) / 4)
                ResetCapacity(heap.Length / 2);

            return max;
        }

        public T FindMax()
        {
            if (this.IsEmpty)
                throw new ArgumentException("堆为空！");

            return heap[1];
        }

        private void Sink(int index)
        {
            //方法没错，但会导致栈溢出

            //if (2*index > N) return;

            //int j = 2 * index;

            //if (j + 1 <= N && heap[j + 1].CompareTo(heap[j]) > 0)
            //    j++;

            ////index和左右中最大的比较
            //if (heap[index].CompareTo(heap[j]) > 0) return;

            //Swap(heap, index, j);

            //Sink(j);

            while (2 * index <= N)
            {
                int j = 2 * index;

                if (j + 1 <= N && heap[j + 1].CompareTo(heap[j]) > 0) j++;

                if (heap[index].CompareTo(heap[j]) >= 0) break;

                Swap(heap, index, j);

                index = j;
            }
        }

        /// <summary>
        /// 元素上游
        /// </summary>
        /// <param name="index"></param>
        private void Swim(int index)
        {
            //方法没错，但会导致栈溢出
            //if (index == 1) return;

            //if (heap[index].CompareTo(heap[index / 2]) > 0)
            //{
            //    Swap(heap, index, index / 2);

            //    Swim(index / 2);

            //}

            while (index > 1 && heap[index].CompareTo(heap[index / 2]) > 0)
            {
                Swap(heap, index, index / 2);
                index = index / 2;
            }
        }

        private static void Swap(T[] arr, int i, int j)
        {
            T t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }

        /// <summary>
        /// 扩容操作，也就是实现动态数组
        /// </summary>
        /// <param name="newCapacity"></param>
        private void ResetCapacity(int newCapacity)
        {
            T[] newHeap = new T[newCapacity];
            for (int i = 0; i <= N; i++)
            {
                newHeap[i] = heap[i];
            }

            heap = newHeap;
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
            for (int i = 1; i <= N; i++)
            {
                res.Append(heap[i]);
                if (i != N)
                    res.Append(", ");
            }
            res.Append("]");
            return res.ToString();
        }
    }
}
