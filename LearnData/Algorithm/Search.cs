using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LearnData.Algorithm
{
    class Search
    {
        /*
         * 顺序查找的时间复杂度为O(n)
         * 二分查找的时间复杂度为O(logn)
         */

        //读取名为filename的文件并将数据存储到数组中返回
        public static int[] ReadFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            List<int> list = new List<int>();

            while (!sr.EndOfStream)
            {
                int num = int.Parse(sr.ReadLine());
                list.Add(num);
            }

            fs.Close();
            sr.Close();

            return list.ToArray();
        }

        /// <summary>
        /// 顺序查找法
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int OrderSearch(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == target)
                    return i;

            return -1;
        }

        /// <summary>
        /// 简易二分查找
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int BinarySearch(int[] arr,int target)
        {
            int l = 0;
            int r = arr.Length - 1;

            while (l <= r)
            {
                //int mid = (r + 1) / 2;
                //防止l和r接近溢出
                int mid = l + (r - l) / 2;

                if (target < arr[mid])
                    r = mid - 1;
                else if (target > arr[mid])
                    l = mid + 1;
                else
                    return mid;

            }

            return -1;
        }
    }
}
