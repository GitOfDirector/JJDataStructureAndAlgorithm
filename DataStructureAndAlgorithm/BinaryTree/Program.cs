using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {


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

            Console.WriteLine("-----------------------------");

            //int[] array = { 1, 2, 3, '*', '*', 4, '*', '*', 5, 6, '*', '*', 7 };

            #region 手动创建
            TreeNode root = new TreeNode(1);
            TreeNode node11 = new TreeNode(2);
            TreeNode node12 = new TreeNode(3);
            TreeNode node111 = new TreeNode(4);
            TreeNode node112 = new TreeNode(5);
            TreeNode node1111 = new TreeNode(7);
            TreeNode node1112 = new TreeNode(8);
            TreeNode node1122 = new TreeNode(9);
            TreeNode node121 = new TreeNode(6);
            root.left = node11;
            root.right = node12;
            node11.left = node111;
            node11.right = node112;
            node12.left = node121;
            node111.left = node1111;
            node111.right = node1112;
            node112.right = node1122;
            #endregion

            Console.Write("层序：");
            BSTreeErgodic.ErgodicTreeLayer(root);
            Console.WriteLine("\n-----------------------------");
            Console.Write("中序：");
            BSTreeErgodic.InorderTraversal_Iteration(root);
            Console.WriteLine("\n-----------------------------");
            Console.Write("后序：");
            BSTreeErgodic.PostorderTraversal_Iteration(root);
            Console.WriteLine("\n-----------------------------");
            Console.Write("后序：");
            BSTreeErgodic.PostorderTraversal2_Iteration(root);

            Console.ReadKey();
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
