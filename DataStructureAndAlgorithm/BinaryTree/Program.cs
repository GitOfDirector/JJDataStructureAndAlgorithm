using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static int defaultValueWhenNull = -23333;

        static void Main(string[] args)
        {
            TreeNode t1 = new TreeNode(1);
            t1.left = new TreeNode(2);
            t1.right = null;
            t1.left.left = new TreeNode(3);

            TreeNode t2 = new TreeNode(1);
            t2.left = null;
            t2.right = new TreeNode(2);
            t2.right.left = null;
            t2.right.right = new TreeNode(3);

            TreeNode i = MergeTreeIterative(t1, t2);
            //TreeNode r = MergeTreeRecursive(t1, t2);

            Console.WriteLine();

            int[] array = { 1, 2, 3, '*', '*', 4, '*', '*', 5, 6, '*', '*', 7 };
            TreeNode tree = CreateBinaryTree(array, 0);
            Console.WriteLine();


            Console.ReadKey();
        }

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


        /// <summary>
        /// 前序遍历
        /// </summary>
        /// <param name="tree"></param>
        public static void ErgodicTreePreOrder(TreeNode tree)
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
                    ErgodicTreePreOrder(tree.left);
                    ErgodicTreePreOrder(tree.right);
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
                    Console.Write(" " + curNode.val + " ");
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
        /// 合并两个二叉树
        /// 迭代
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static TreeNode MergeTreeIterative(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
                return t2;

            Stack<TreeNode[]> stack = new Stack<TreeNode[]>();
            stack.Push(new TreeNode[] { t1, t2 });

            while (stack.Count != 0)
            {
                TreeNode[] t = stack.Pop();

                if (t[0] == null || t[1] == null)
                    continue;

                t[0].val += t[1].val;

                if (t[0].left == null)
                {
                    t[0].left = t[1].left;
                }
                else
                {
                    stack.Push(new TreeNode[] { t[0].left, t[1].left });
                }

                if (t[0].right == null)
                {
                    t[0].right = t[1].right;
                }
                else
                {
                    stack.Push(new TreeNode[] { t[0].right, t[1].right });
                }
            }

            return t1;

        }

        /*
         * C++
        TreeNode* mergeTrees(TreeNode* t1, TreeNode* t2) 
        {
            if(t2==NULL) return t1;
            if(t1==NULL) return t2;
         
            TreeNode* res=t1;
            stack<TreeNode*> s1, s2;
            s1.push(t1), s2.push(t2);
            while(!s1.empty()) {
                TreeNode* c1=s1.top();
                TreeNode* c2=s2.top();
                s1.pop(), s2.pop();
                c1->val+=c2->val;
                if(c1->right==NULL&&c2->right!=NULL) 
                    c1->right=c2->right;
                else if(c1->right!=NULL&&c2->right!=NULL) 
                    s1.push(c1->right), s2.push(c2->right);
                if(c1->left==NULL&&c2->left!=NULL) 
                    c1->left=c2->left;
                else if(c1->left!=NULL&&c2->left!=NULL) 
                    s1.push(c1->left), s2.push(c2->left);
            }
            return res;
        }
        */

        public static TreeNode MergeTreeRecursive(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
                return t2;

            if (t2 == null)
                return t1;

            t1.val = t1.val + t2.val;
            t1.left = MergeTreeRecursive(t1.left, t2.left);
            t1.right = MergeTreeRecursive(t1.right, t2.right);

            return t1;
        }

    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

}
