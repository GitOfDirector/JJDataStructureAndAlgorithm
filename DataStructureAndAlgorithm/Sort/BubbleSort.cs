using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    /// <summary>
    /// 冒泡排序
    /// </summary>
    class BubbleSort
    {
        public static void Sort(int[] array) 
        {
            int temp = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j + 1];
                        array[j+ 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

    }
}
