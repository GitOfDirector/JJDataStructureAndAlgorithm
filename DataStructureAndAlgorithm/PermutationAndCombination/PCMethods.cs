using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationAndCombination
{
    class PCMethods<T>
    {
        //参考： https://blog.csdn.net/cxdragoon/article/details/70229772
        //           https://www.cnblogs.com/kissdodog/p/5419981.html

        /// <summary>
        /// 求数组中n个元素的排列
        /// </summary>
        /// <param name="source">所求数组</param>
        /// <param name="n">元素个数</param>
        /// <returns>数组中n个元素的排列</returns>
        public static List<T[]> GetPermutation(T[] source, int n)
        {
            if (n > source.Length)
                return null;

            List<T[]> list = new List<T[]>();

            //首先得到n个不同元素的组合
            List<T[]> c= GetCombinationList2(source, n);
            
            for (int i = 0; i < c.Count; i++)
            {
                List<T[]> tl = new List<T[]>();
                
                //得到一个组合的所有排列
                GetPermutationList(ref tl, c[i], 0, n - 1);
                
                list.AddRange(tl);
            }

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="eles">需要排列的元素</param>
        /// <param name="startIndex">开始下标</param>
        /// <param name="endIndex">结束下标</param>
        private static void GetPermutationList(ref List<T[]> list, T[] eles, int startIndex, int endIndex)
        {
            if (startIndex == endIndex)
            {
                if (list == null)
                {
                    list = new List<T[]>();
                }

                T[] temp = new T[eles.Length];
                eles.CopyTo(temp, 0);
                list.Add(temp);
            }
            else
            {
                for (int i = startIndex; i <= endIndex; i++)
                {
                    //交换 起始位置 每一个位置 的值---一个新的排列
                    Swap(ref eles[startIndex], ref eles[i]);
                    
                    //进行下一个位置
                    GetPermutationList(ref list, eles, startIndex + 1, endIndex);
                    
                    //对于每一个新的排列，再次交换新的 下一个起始位置 每一个位置
                    Swap(ref eles[startIndex], ref eles[i]);
                }
            }
        }

        /// <summary>
        /// 交换两个变量
        /// </summary>
        /// <param name="a">变量1</param>
        /// <param name="b">变量2</param>
        public static void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// 从n个不同元素中任意选取m个元素的组合的所有组合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<List<T>> GetCombinationList(List<T> elements, int n)
        {
            List<List<T>> result = new List<List<T>>();

            int eleNum = elements.Count;
            
            //将传递进来的元素列表拷贝出来进行处理，防止后续步骤修改原始列表，造成递归返回后原始列表被修改；
            List<T> source = new List<T>(elements);

            //当只选取一个元素的时候，就是将集合中的每一个输出
            if (n == 1)
            {
                foreach (var item in source)
                {
                    List<T> itemGroup = new List<T>();
                    itemGroup.Add(item);
                    result.Add(itemGroup);
                }

                return result;
            }
           
            for (int i = 0; i < eleNum; i++)
            {
                //否则，等于选取 当前元素 + 选取n - 1个元素的组合
                T curEle = source[0];
                source.RemoveAt(0);
                List<List<T>> tempRes = GetCombinationList(source, n - 1);
                
                //给每一个当前组合添加上当前元素
                for (int j = 0; j < tempRes.Count; j++)
                {
                    List<T> itemGroup = new List<T>();
                    itemGroup.Add(curEle);
                    itemGroup.AddRange(tempRes[j]);

                    result.Add(itemGroup);
                }
            }

            return result;
        }

        public static List<T[]> GetCombinationList2(T[] arr, int n)
        {
            if (arr.Length < n)
                return null;

            List<T[]> list = new List<T[]>();
            int[] selectIndex = new int[n];
            GetCombination(ref list, arr, arr.Length, n, selectIndex, n);
            
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list">结果</param>
        /// <param name="eles">选取的元素集合</param>
        /// <param name="elesCount">选取元素的个数</param>
        /// <param name="needSelectCount">当前剩余选取的元素个数</param>
        /// <param name="indexes">下标数组</param>
        /// <param name="selectCount">选取的元素个数</param>
        private static void GetCombination(ref List<T[]> list, T[] eles, int elesCount, int needSelectCount, int[] indexes, int selectCount)
        {
            //问题转化为从0 --- eleCount - 1 的下标中选取 指定数量的下标

            //在元素个数大于需要数量时，缩小待选集合
            for (int i = elesCount; i >= needSelectCount; i--)
            {
                //当剩余选取元素个数大于1个时，接着选取
                //否则，表示一次选取完成
                indexes[needSelectCount - 1] = i - 1;

                //当剩余选取元素个数大于1个时，接着选取
                if (needSelectCount > 1)
                {
                    GetCombination(ref list, eles, i - 1, needSelectCount - 1, indexes, selectCount);
                }
                else
                {
                    if (list == null)
                    {
                        list = new List<T[]>();
                    }

                    T[] temp = new T[selectCount];
                    for (int j = 0; j < indexes.Length; j++)
                    {
                        //Console.Write(indexes[j] + "   ");
                        int curIndex = indexes[j];
                        temp[j] = eles[curIndex];
                    }
                    //Console.WriteLine();

                    list.Add(temp);
                }
            }
        }

    }
}
