using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    /// <summary>
    /// 创建
    /// </summary>
    class BSTreeCreate
    {
        static int defaultValueWhenNull = -1;

        /// <summary>
        /// 使用集合创建二叉树
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static TreeNode CreateTreeUseList(List<int> list, int index)
        {

            if (list[index] == defaultValueWhenNull)
            {
                return null;
            }

            TreeNode root = new TreeNode((int)list[index]);

            int lNode = 2 * index + 1;
            int rNode = 2 * index + 2;

            if (lNode > list.Count - 1)
            {
                root.left = null;
            }
            else
            {
                root.left = CreateTreeUseList(list, lNode);
            }

            if (rNode > list.Count - 1)
            {
                root.right = null;
            }
            else
            {
                root.right = CreateTreeUseList(list, rNode);
            }

            return root;

        }

        /// <summary>
        /// 先序遍历创建二叉树
        /// </summary>
        /// <returns></returns>
        public static TreeNode CreateBinaryTree(int[] values, int index)
        {
            //你对於递归的理解也太傻逼了

            return null;

        }

    }
}
