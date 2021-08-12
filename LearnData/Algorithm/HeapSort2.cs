using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.Algorithm
{
    /// <summary>
    /// 原地堆排序 不实例化新的最大堆 就在数组中构建
    /// </summary>
    class HeapSort2
    {

        public static void Sort(int[] arr)
        {
            int n = arr.Length;

            for (int i = (n - 1 - 1) / 2; i >= 0; i++)
            {
                Sink(arr, i, n);
            }

            for (int i = n - 1; i > 0; i++)
            {
                Swap(arr, 0, i);
                Sink(arr, 0, i - 1);
            }
        }

        private static void Sink(int[] arr, int index, int n)
        {
            while (2 * index <= n)
            {
                int j = 2 * index;

                if (j + 1 <= n && arr[j + 1].CompareTo(arr[j]) > 0) j++;

                if (arr[index].CompareTo(arr[j]) >= 0) break;

                Swap(arr, index, j);

                index = j;
            }
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }
    }
}
