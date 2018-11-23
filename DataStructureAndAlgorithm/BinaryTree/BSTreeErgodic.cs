using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    /// <summary>
    /// 遍历
    /// </summary>
    class BSTreeErgodic
    {

        //参考：https://www.cnblogs.com/SHERO-Vae/p/5800363.html

        /// <summary>
        /// 前序遍历
        /// </summary>
        /// <param name="tree"></param>
        public static void ErgodicTreePreOrder_Recursive(TreeNode tree)
        {
            if (tree == null)
            {
                Console.Write(" Null ");
                return;
            }
            else
            {
                //对于叶子节点不再向下遍历
                if (tree.left == null && tree.right == null)
                {
                    Console.Write(" " + tree.val + " ");
                }
                else
                {
                    Console.Write(" " + tree.val + " ");
                    ErgodicTreePreOrder_Recursive(tree.left);
                    ErgodicTreePreOrder_Recursive(tree.right);
                }
            }

        }

        /// <summary>
        /// 层序遍历
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="isOutNullLeafNode">是否输出空节点</param>
        public static void ErgodicTreeLayer(TreeNode tree, bool isOutNullLeafNode = false)
        {
            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(tree);

            while (que.Count != 0)
            {
                TreeNode curNode = que.Dequeue();
                if (curNode != null)
                {
                    Console.Write(curNode.val + "   ");
                }
                else if (isOutNullLeafNode)
                {
                    Console.Write(" Null ");
                    continue;
                }

                //是否输出空叶子节点
                if (isOutNullLeafNode)
                {
                    if (curNode.left != null && curNode.right == null)
                    {
                        que.Enqueue(curNode.left);
                        que.Enqueue(null);
                    }
                    else if (curNode.left == null && curNode.right != null)
                    {
                        que.Enqueue(null);
                        que.Enqueue(curNode.right);
                    }
                    else
                    {
                        if (curNode.left != null)
                        {
                            que.Enqueue(curNode.left);
                        }

                        if (curNode.right != null)
                        {
                            que.Enqueue(curNode.right);
                        }
                    }
                }
                else
                {
                    if (curNode.left != null)
                    {
                        que.Enqueue(curNode.left);
                    }

                    if (curNode.right != null)
                    {
                        que.Enqueue(curNode.right);
                    }
                }
            }

        }

        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="tree"></param>
        public static void InorderTraversal_Iteration(TreeNode tree)
        {
            if (tree == null)
                return;

            Stack<TreeNode> stk = new Stack<TreeNode>();
            TreeNode cur = tree;//防止改变原树结构

            //直到节点为null 并且 栈为空则遍历结束
            while (cur != null || stk.Count != 0) 
            {
                while (cur != null)
                {
                    //若其左孩子不为空，则将结点入栈并将结点的左孩子置为当前的结点，然后对当前结点再进行相同的处理
                    stk.Push(cur);
                    cur = cur.left;
                }

                if (stk.Count != 0)
                {
                    //若其左孩子为空，则取栈顶元素并进行出栈操作，访问该栈顶结点，然后将当前结点置为栈顶结点的右孩子
                    cur = stk.Pop();
                    Console.Write(cur.val + "   ");
                    cur = cur.right;
                }
            }
        }

        /// <summary>
        /// 后序遍历
        /// </summary>
        /// <param name="tree"></param>
        public static void PostorderTraversal_Iteration(TreeNode tree)
        {
            if (tree == null)
                return;

            Stack<TreeNode> stk = new Stack<TreeNode>();

            TreeNode cur = null;//当前节点
            TreeNode pre = null;//上一次访问的节点

            stk.Push(tree);

            while (stk.Count != 0)
            {
                cur = stk.Peek();

                //如果当前节点没有子节点
                //或者当前节点的左孩子和右孩子已经被访问问过了
                if ((cur.left == null && cur.right == null) ||
                    (pre != null && (pre == cur.left || pre == cur.right)))
                {
                    Console.Write(cur.val + "   ");
                    stk.Pop();
                    pre = cur;
                }
                else
                {   
                    //先压入右孩子，再压入左孩子，保证左孩子在右孩子前面被访问

                    if (cur.right != null)
                        stk.Push(cur.right);

                    if (cur.left != null)
                        stk.Push(cur.left);         
                }

            }



        }

        /// <summary>
        /// 后序遍历
        /// 使用标志位的方式
        /// </summary>
        /// <param name="tree"></param>
        public static void PostorderTraversal2_Iteration(TreeNode tree) 
        {
            /*
             * 对于任一结点P，将其入栈，然后沿其左子树一直往下搜索，直到搜索到没有左孩子的结点，此时该结点出现在栈顶，但是此时不能将其出栈并访问， 因此其右孩子还为被访问。
             * 所以接下来按照相同的规则对其右子树进行相同的处理，当访问完其右孩子时，该结点又出现在栈顶，此时可以将其出栈并访问。
             * 这样就 保证了正确的访问顺序。可以看出，在这个过程中，每个结点都两次出现在栈顶，只有在第二次出现在栈顶时，才能访问它。因此需要多设置一个变量标识该结点是 否是第一次出现在栈顶。
             */

            Stack<TreeNodeFlag> stk = new Stack<TreeNodeFlag>();

            TreeNode pt = tree;
            TreeNodeFlag temp = null;

            while (pt != null || stk.Count != 0)
            {
                //沿左子树一直往下搜索，直至出现没有左子树的结点
                while (pt != null)
                {
                    TreeNodeFlag nf = new TreeNodeFlag();
                    nf.node = pt;
                    nf.isFirstTime = true;
                    stk.Push(nf);
                    pt = pt.left;
                }

                if (stk.Count != 0)
                {
                    temp = stk.Pop();
                    //如果是第一次出现在栈顶
                    if (temp.isFirstTime == true)
                    {
                        temp.isFirstTime = false;
                        stk.Push(temp);
                        //访问其右孩子
                        pt = temp.node.right;
                    }
                    else
                    {
                        Console.Write(temp.node.val + "   ");
                        pt = null;
                    }
                }

            }



        }
    }

    public class TreeNodeFlag 
    {
       public TreeNode node;
       public bool isFirstTime = false;//是否是第一次访问该节点
    }
}
