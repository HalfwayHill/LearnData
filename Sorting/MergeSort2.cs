using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /*
     * 归并排序是让两个有序的数组合并为一个有序的数组
     * 优化的方向为
     * 1.递归的时候，小数据的数组使用插入排序更加有效
     * 2.测试有序性，不需要归并
     */

    class MergeSort2
    {
        public static void Sort(int[] arr)
        {
            int n = arr.Length;
            int[] temp = new int[n];
            Sort(arr, temp, 0, n - 1);
        }

        private static void Sort(int[] arr, int[] temp, int l, int r)
        {
            if (r - l + 1 <= 15)
            {
                InsertSort.Sort1(arr, l, r);
                return;
            }

            //int mid = (r + l)/2; 若r和l都是很大的整数，会造成溢出
            int mid = l + (r - l) / 2;
            Sort(arr, temp, l, mid);
            Sort(arr, temp, mid + 1, r);
            //再开始合并排序前，左右半边必须是有序的

            //进行有序性判断
            if (arr[mid] > arr[mid + 1])
                Merge(arr, temp, l, mid, r);

        }

        private static void Merge(int[] arr, int[] temp, int l, int mid, int r)
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
                    temp[k++] = arr[j++];
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
