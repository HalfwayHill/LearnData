using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class SelectSort
    {
        public static void Sort(int[] arr)
        {
            int n = arr.Length;

            for (int j = 0; j < n; j++)
            {
                int min = j;
                //int i = j + 1 不需要对已经排序完成的元素再次进行比较
                for (int i = j + 1; i < n; i++)
                {
                    if (arr[i] < arr[min])
                        min = i;
                }

                Swap(arr, min, j);
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
