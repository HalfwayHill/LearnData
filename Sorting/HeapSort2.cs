using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /// <summary>
    /// 原地堆排序 不实例化新的最大堆 就在数组中构建
    /// </summary>
    class HeapSort2
    {

        public static void Sort(int[] arr)
        {
            int n = arr.Length;

            //先将原数组整理成最大堆
            for (int i = (n - 1 - 1) / 2; i >= 0; i--)
            {
                Sink(arr, i, n - 1);
            }

            for (int i = n - 1; i > 0; i--)
            {
                Swap(arr, 0, i);
                Sink(arr, 0, i - 1);
            }
        }

        private static void Sink(int[] arr, int index,int n)
        {
            while (2 * index + 1 <= n)
            {
                int j = 2 * index + 1;

                if (j + 1 <= n && arr[j + 1].CompareTo(arr[j]) > 0) j++;

                if (arr[index].CompareTo(arr[j]) >= 0) break;

                Swap(arr, index, j);

                index = j;
            }

            //测试得出递归的方法，没有While的方式效率 可能是由于栈的运作
            //对于顺序存储结构 递归的使用效率反而较低

            //if (2 * index + 1 > n) return;

            //int j = 2 * index + 1;

            //if (j + 1 <= n && arr[j + 1].CompareTo(arr[j]) > 0)
            //    j++;

            ////index和左右中最大的比较
            //if (arr[index].CompareTo(arr[j]) > 0) return;

            //Swap(arr, index, j);

            //Sink(arr, j, n);
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }
    }
}
