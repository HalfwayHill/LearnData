using System;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 简单的int类型数组的冒泡排序

            /*

            int[] a = { 4, 3, 5, 2, 1, 0 };

            BubbleSort.Sort(a);

            for (int i = 0; i < a.Length; i++)
                Console.WriteLine(a[i]);

            */

            #endregion

            #region 泛型数组的冒泡排序

            /*

            int[] a = { 4, 3, 5, 2, 1, 0 };
            char[] a2 = { 'C', 'A', 'D', 'B', 'G', 'F', 'E' };
            float[] a3 = { 0.21f, 0.10f, 0.78f, 0.15f, 0.17f };

            Date[] dates =
            {
                new Date(2020,7,7,"七夕节"),
                new Date(2020,8,15,"中秋节"),
                new Date(2020,1,1,"元旦节"),
                new Date(2020,3,8,"妇女节"),
                new Date(2020,4,4,"清明节"),
                new Date(2020,5,1,"劳动节"),
                new Date(2020,9,10,"教师节"),
                new Date(2020,1,25,"春节"),
                new Date (2020,2,14,"情人节"),
                new Date(2020,10,1,"国庆节"),
                new Date(2020,12,25,"圣诞节"),
                new Date(2020,6,1,"儿童节")
            };

            BubbleSortGeneric.Sort(dates);

            for (int i = 0; i < dates.Length; i++)
                Console.WriteLine(dates[i]);

            */

            #endregion

            #region 简单的int类型数组的选择排序

            /*

            int[] a = { 4, 3, 5, 2, 1, 0 };

            SelectSort.Sort(a);

            for (int i = 0; i < a.Length; i++)
                Console.WriteLine(a[i]);

            */

            #endregion

            #region 简单的int类型数组的插入排序

            /*

            int[] a = { 4, 3, 5, 2, 1, 0 };

            InsertSort.Sort(a);

            for (int i = 0; i < a.Length; i++)
                Console.WriteLine(a[i]);

            */

            #endregion

            #region 简单的int类型数组的归并排序

            /*

            //当前a数组前后两段是有序的
            int[] a = { 2, 3, 6, 8, 1, 4, 5, 7 };

            MergeSort1.Sort(a);

            TestHelper.Show(a);

            //当前a数组前后两段是无序的 3和2颠倒
            int[] b = { 3, 2, 6, 8, 1, 4, 5, 7 };

            MergeSort1.Sort(b);

            TestHelper.Show(b);

            */

            #endregion

            #region 测试排序算法的性能

            /**/

            //数组规模大小
            int N = 1000000;

            //Console.WriteLine("测试随机数组： ");
            //int[] a = TestHelper.RandomArray(N, N);
            //int[] b = TestHelper.CopyArray(a);

            //Console.WriteLine("测试近乎有序数组： ");
            //int[] a = TestHelper.NearlyOrderedArray(N, 0);
            //int[] b = TestHelper.CopyArray(a);

            Console.WriteLine("测试重复随机数组： ");
            int[] a = TestHelper.RandomArray(N, 10);
            int[] b = TestHelper.CopyArray(a);



            //对同样的测试用例进行性能测试
            //提示：不要将类名打错否则将抛出异常
            //如果你的排序算法编写正确，排序成功，得到运行时间。
            //如果你的排序算法编写错误 IsSorted 将会检测排序失败。
            //TestHelper.TestSort("BubbleSort", a);
            //TestHelper.TestSort("SelectSort", a);
            //TestHelper.TestSort("InsertSort", a);
            //TestHelper.TestSort("MergeSort1", a);
            //TestHelper.TestSort("MergeSort2", a);
            //TestHelper.TestSort("QuickSort1", a);
            //TestHelper.TestSort("QuickSort2", a);
            TestHelper.TestSort("QuickSort3", b);

            //冒泡排序：34859ms 因为冒泡排序每次比较都可能交换数据 交换次数最多的排序算法
            //顺序排序：10558ms 顺序排序当得到最小的数据时，才开始交换数据 交换次数最少的排序算法 n次
            //插入排序：随机数组6932ms 近乎有序数组21ms 插入排序当获得相关条件时会提前中止 对于有序性强的数据集合，插入排序是方便快捷的
            //时间复杂度都为O(n^2) 所以对于大量数据的排序还是太慢
            //优化前归并排序：随机数组18ms 近乎有序数组11ms 时间复杂度O(NLogN) 趋紧于O(N)
            //优化后的归并排序和三向切分快速排序，时间效率上是差不多的，但归并排序的空间效率是差的，因为它要有个过渡数组



            #endregion

            Console.Read();
        }
    }
}
