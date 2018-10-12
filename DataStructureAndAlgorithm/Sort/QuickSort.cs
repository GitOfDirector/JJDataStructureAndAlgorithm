using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    /// <summary>
    /// 快速排序
    /// </summary>
    class QuickSort
    {
        private static int SortUnit(int[] array, int low, int high)
        {
            int key = array[low];

            while (low < high)
            {
                /*从后向前搜索比key小的值*/
                while (array[high] >= key && high > low)
                    --high;

                /*比key小的放左边*/
                array[low] = array[high];

                /*从前向后搜索比key大的值，比key大的放右边*/
                while (array[low] <= key && high > low)
                    ++low;

                /*比key大的放右边*/
                array[high] = array[low];
            }

            /*左边都比key小，右边都比key大。//将key放在游标当前位置。//此时low等于high */
            array[low] = key;

            //foreach (int i in array)
            //{
            //    Console.Write("{0}\t", i);
            //}
            //Console.WriteLine();

            return high;
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="array"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        public static void Sort(int[] array, int low, int high)
        {
            if (low >= high)
                return;

            /*完成一次单元排序*/
            int index = SortUnit(array, low, high);

            /*对左边单元进行排序*/
            Sort(array, low, index - 1);

            /*对右边单元进行排序*/
            Sort(array, index + 1, high);

        }

    }
}
