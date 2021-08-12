using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class InsertSort
    {
        public static void Sort(int[] arr)
        {
            int n = arr.Length;

            for (int j = 1; j < n; j++)
            {
                int e = arr[j];
                int i;
                for (i = j - 1; i >= 0; i--)
                {
                    if (e < arr[i])
                        arr[i + 1] = arr[i];
                    else
                        break;
                }
                arr[i + 1] = e;


            }
        }

        /// <summary>
        /// 对arr[l...r]的范围使用插入排序
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        public static void Sort1(int[] arr, int l, int r)
        {

            for (int j = l + 1; j <= r; j++)
            {
                int e = arr[j];
                int i;
                for (i = j - 1; i >= l; i--)
                {
                    if (e < arr[i])
                        arr[i + 1] = arr[i];
                    else
                        break;
                }
                arr[i + 1] = e;


            }
        }
    }
}
