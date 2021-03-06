using LearnData.MyHeap;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnData.Algorithm
{
    class HeapSort1
    {
        //时间复杂度：建堆O（NlogN）+ 出堆（NlogN）=O（2NlogN）
        //空间复杂度：O（N）
        public static void Sort(int[] arr)
        {
            int n = arr.Length;

            MaxHeap<int> maxHeap = new MaxHeap<int>();

            for (int i = 0; i < arr.Length; i++)
                maxHeap.Insert(arr[i]);

            for (int i = n - 1; i >= 0; i--)
                arr[i] = maxHeap.RemoveMax();
        }
    }
}
