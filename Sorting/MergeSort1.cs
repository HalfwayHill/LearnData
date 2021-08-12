 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /*
     * 归并排序是让两个有序的数组合并为一个有序的数组
     * 如何让数组左右有序，分割，分割为最小的2个元素的数组即可
     */

    class MergeSort1
    {
        public static void Sort(int[] arr)
        {
            int n = arr.Length;
            int[] temp = new int[n];
            Sort(arr, temp, 0, n - 1);
        }

        private static void Sort(int[] arr, int[] temp, int l, int r)
        {
            //这是递归的条件
            if (l >= r) return;

            //int mid = (r + l)/2; 若r和l都是很大的整数，会造成溢出
            int mid = l + (r - l) / 2;
            Sort(arr, temp, l, mid);
            Sort(arr, temp, mid + 1, r);
            //再开始合并排序前，左右半边必须是有序的
            Merge(arr, temp, l, mid, r);
        }

        private static void Merge(int[] arr,int[] temp,int l,int mid,int r)
        {
            int i = l;
            int j = mid + 1;
            int k = l;

            //左右半边都有元素
            while (i <= mid && j <= r)
            {
                if (arr[i] < arr[j])
                {
                    //temp[k] = arr[i];
                    //k++;
                    //i++;
                    temp[k++] = arr[i++];
                }
                else
                {
                    temp[k++] = arr[j++];
                }
            }

            //左半边还有元素，右半边用尽（取左半边元素放入temp）
            while (i <= mid)
                temp[k++] = arr[i++];

            //右半边还有元素，左半边用尽（取右半边元素放入temp）
            while (j <= r)
                temp[k++] = arr[j++];

            for (int z = l; z <= r; z++)
                arr[z] = temp[z];

        }
    }
}
