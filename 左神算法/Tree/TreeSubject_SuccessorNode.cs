using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.Tree
{
    internal class TreeSubject_SuccessorNode
    {
        #region 树结构
        public class Node
        {
            public int value;
            public Node left;
            public Node right;
            public Node parent;
            public Node(int value)
            {
                this.value = value;
            }
        }

        #endregion

        #region 在二叉树中找到一个结点的后继节点
        ///后继结点相关概念：
        /// 1、在中序遍历中，一个结点的下一个结点是后继结点
        /// 2、前驱结点：中序遍历中，一个结点的上一个结点是前驱结点
        
        ///解题思路：
        /// 1、正常做法：先中序遍历，再找后继结点，时间复杂度为 O(N)——————>可优化
        /// 2、优化做法：
        ///     1、如果当前结点 cur 有右树，那么它的后继结点是右树的最左的结点
        ///     2、如果当前结点 cur 无右树，往上走，找到其中一个父节点是某个结点的左孩子的时候，那个结点就是 cur 的后继结点
        ///     3、如果当前节点 cur 无右树，往上走，每一个父节点都不是某个结点的左孩子
        ///         ————说明 cur 是一整棵树里面最右边的一个叶节点，它的后继结点为 null
        public static Node GetSuccessorNode(Node node)
        {
            if (node == null) return node;

            if (node.right != null)
                return GetLeftMost(node.right);//获取右孩子这棵树里面最左的一个结点，就是它的后继结点
            else
            {
                Node parent = node.parent;
                while(parent != null && parent.left != node)
                {
                    node = parent;
                    parent = node.parent;
                }
                return parent;
            }
        }

        /// <summary>
        /// 获取一个结点最左的一个孩子结点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static Node GetLeftMost(Node node)
        {
            if (node == null) return node;
            while (node.left != null)
                node = node.left;
            return node;
        }
        #endregion


        ///
        /*static void Main(string[] args)
        {
            Node head = new Node(6);
            head.parent = null;
            head.left = new Node(3);
            head.left.parent = head;
            head.left.left = new Node(1);
            head.left.left.parent = head.left;
            head.left.left.right = new Node(2);
            head.left.left.right.parent = head.left.left;
            head.left.right = new Node(4);
            head.left.right.parent = head.left;
            head.left.right.right = new Node(5);
            head.left.right.right.parent = head.left.right;
            head.right = new Node(9);
            head.right.parent = head;
            head.right.left = new Node(8);
            head.right.left.parent = head.right;
            head.right.left.left = new Node(7);
            head.right.left.left.parent = head.right.left;
            head.right.right = new Node(10);
            head.right.right.parent = head.right;

            Node test = head.left.left;
            Console.WriteLine(test.value + " next: " + GetSuccessorNode(test).value);
            test = head.left.left.right;
            Console.WriteLine(test.value + " next: " + GetSuccessorNode(test).value);
            test = head.left;
            Console.WriteLine(test.value + " next: " + GetSuccessorNode(test).value);
            test = head.left.right;
            Console.WriteLine(test.value + " next: " + GetSuccessorNode(test).value);
            test = head.left.right.right;
            Console.WriteLine(test.value + " next: " + GetSuccessorNode(test).value);
            test = head;
            Console.WriteLine(test.value + " next: " + GetSuccessorNode(test).value);
            test = head.right.left.left;
            Console.WriteLine(test.value + " next: " + GetSuccessorNode(test).value);
            test = head.right.left;
            Console.WriteLine(test.value + " next: " + GetSuccessorNode(test).value);
            test = head.right;
            Console.WriteLine(test.value + " next: " + GetSuccessorNode(test).value);
            test = head.right.right; // 10's next is null
            Console.WriteLine(test.value + " next: " + GetSuccessorNode(test));
        }*/
    }
}
