using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class BubbleSort
    {
        public static void Sort(int[] arr)
        {
            int n = arr.Length;

            for (int j = 0; j < n; j++)
            {
                //不需要对已经排序完成的元素再次进行比较
                for (int i = 0; i < n - j - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                        Swap(arr, i, i + 1);
                }
            }

            
        }

        private static void Swap(int[] arr,int i,int j)
        {
            int t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }
    }
}
