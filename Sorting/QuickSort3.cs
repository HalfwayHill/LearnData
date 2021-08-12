using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /*
     * 三向切分随机快速排序
     * 分为三部分 < > = 
     * 
     * 优化方法是，忽略重复数据
     */
    class QuickSort3
    {

        //随机类全局变量，不能写在方法内作为局部变量。
        private static Random rd = new Random();

        public static void Sort(int[] arr)
        {
            int n = arr.Length;

            Sort(arr, 0, n - 1);
        }

        private static void Sort(int[] arr, int l, int r)
        {
            if (r - l + 1 <= 15)
            {
                InsertSort.Sort1(arr, l, r);
                return;
            }

            //在[l...r]的范围随机一个位置
            int p = l + rd.Next(r - l + 1);

            //和第一个元素交换作为标定元素，这一步对有序性很强的数组排序有很好的优化。
            Swap(arr, l, p);

            int v = arr[l];

            //lt实际上就是标定位置，扎到当前v所在的位置，比它小的在它左边，比它大的在它右边
            int lt = l;        // arr[l+1...lt] < v
            int gt = r + 1;    // arr[gt...r] > v
            int i = l + 1;     // arr[lt+1...i-1] == v

            while (i < gt)
            {
                if (arr[i] < v)
                {
                    lt++;
                    Swap(arr, i, lt);
                    i++;
                }
                else if(arr[i] > v)
                {
                    gt--;
                    Swap(arr, i, gt);
                }
                else
                {
                    i++;
                }
            }
            //然后将现在lt上的数据和v调换，自然lt的左边都比lt小
            Swap(arr, l, lt);


            Sort(arr, l, lt - 1);
            Sort(arr, gt, r);
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }

    }
}
