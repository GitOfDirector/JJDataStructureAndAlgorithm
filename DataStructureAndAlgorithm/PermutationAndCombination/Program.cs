using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationAndCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> res = LetterCasePermutation_BFS("a1b2");
            //List<string> res = LetterCasePermutation_DFS("a1b2");

            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            //List<int> eles = new List<int>() { 1, 2, 3 };
            //List<List<int>> combinations = PCMethods<int>.GetCombinationList(eles, 2);           

            //int[] arr = { 1, 2, 3, 4, 5 };
            //List<int[]> combinations = PCMethods<int>.GetCombinationList2(arr, 3);

            int[] arr = { 1, 2, 3, 4 };
            List<int[]> res = PCMethods<int>.GetPermutation(arr, 4);
            ConsoleReult(res);

            Console.ReadKey();

        }


        public static void ConsoleReult(List<int[]> result) 
        {
            for (int i = 0; i < result.Count; i++)
            {
                //Console.Write($"{i}:  ");
                Console.Write("{0, 4} :  ", i);
                for (int j = 0; j < result[i].Length; j++)
                {
                    Console.Write(result[i][j] + "  ");
                }
                Console.WriteLine();
            }
        }

        /*
         * 有一字符串，我们可以将其中的字母转换成大写或者小写，则变换后可以拥有多少字符串？
         * 例如：a1b2 ===》a1b2, A1b2, a1B2, A1B2
         * 
         * 我们可以看做一个拥有虚拟根的树，左侧是小写字母，右侧是大写字母
         *                          a                                           A
         *             ab                  aB                   Ab                  AB
         *      abc     abC     aBc     aBC      Abc       AbC    ABc      ABC 
         *      
         * 
         * 该问题也属于abc下标组合问题
         * 即三个不同下标选出任意个下标转换成大写的组合方式有多少种
         *          3选0 ：abc
         *          3选1 ：Abc,   aBc,    abC --- {0, 1, 2}下标选1个
         *          3选2 ：ABc,   AbC,   aBC --- {0, 1, 2}下标选2个
         *          3选3 ：ABC -- {0, 1, 2}下标选3个
         */

        public static List<string> LetterCasePermutation_BFS(String S)
        {
            if (string.IsNullOrEmpty(S))
            {
                return new List<string>();
            }

            Queue<string> que = new Queue<string>();
            que.Enqueue(S);

            for (int i = 0; i < S.Length; i++)
            {
                if (char.IsDigit(S[i]))
                    continue;

                int size = que.Count;
                for (int j = 0; j < size; j++)
                {
                    string cur = que.Dequeue();
                    char[] chars = cur.ToCharArray();

                    chars[i] = char.ToUpper(chars[i]);
                    que.Enqueue(new string(chars));

                    chars[i] = char.ToLower(chars[i]);
                    que.Enqueue(new string(chars));
                }
            }

            return new List<string>(que);
        }

        public static List<string> LetterCasePermutation_DFS(String S)
        {
            if (string.IsNullOrEmpty(S))
            {
                return new List<string>();
            }

            List<string> res = new List<string>();
            DfsString(S.ToCharArray(), 0, res);

            return res;
        }

        public static void DfsString(char[] chars, int index, List<string> res)
        {
            if (index == chars.Length)
            {
                res.Add(new string(chars));
                return;
            }

            if (char.IsDigit(chars[index]))
            {
                DfsString(chars, index + 1, res);
            }
            else
            {
                chars[index] = char.ToUpper(chars[index]);
                DfsString(chars, index + 1, res);

                chars[index] = char.ToLower(chars[index]);
                DfsString(chars, index + 1, res);
            }

        }

    }
}
