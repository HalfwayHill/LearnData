using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /*
     * 随机快速排序
     * 
     * 优化方法是，在数组中选择的标定数据应该随机选择
     * 
     * 问题 当重复数据过多时，会造成栈溢出
     */
    class QuickSort2
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

            //j实际上就是标定位置，扎到当前v所在的位置，比它小的在它左边，比它大的在它右边
            int j = l;

            for (int i = l + 1; i <= r; i++)
            {
                //只要比v小，j++,这样v的标定位置右移，然后将比V小的数据集中在j的左边
                if (arr[i] < v)
                {
                    j++;
                    Swap(arr, i, j);
                }
            }
            //然后将现在j上的数据和v调换，自然j的左边都比j小，j的右边都比j大
            Swap(arr, l, j);


            Sort(arr, l, j - 1);
            Sort(arr, j + 1, r);
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }
    }
}
