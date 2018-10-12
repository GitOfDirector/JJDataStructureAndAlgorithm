using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, -10, -222, -79, 200, 100, 57, 49, 72, 63, 34, 55};

            //QuickSort.Sort(arr, 0, arr.Length - 1);
            BubbleSort.Sort(arr);


            Console.WriteLine("===结果：");
            foreach (var item in arr)
            {
                Console.Write("\t" + item);
            }

            Console.ReadKey();

        }
    }
}
