using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.Tree
{
    internal class SerializationAndDeserialization
    {
        #region 树结构
        public class Node
        {
            public int value;
            public Node left;
            public Node right;
            public Node(int value)
            {
                this.value = value;
            }
        }

        #endregion


        /// 二叉树的序列化与反序列化————一颗二叉树的结构和值对应成唯一的字符串
        ///     1、什么是序列化？什么是反序列化？
        ///     ————简单理解：由内存到字符串叫序列化，由字符串还原处原来的内存结构叫反序列化
        ///     2、序列化方式：通过遍历树进行树的序列化：
        ///         1、先序方式序列化一棵树：
        ///             1、用数字来记录结点的值
        ///             2、用 # 来记录 null
        ///             3、用下划线_来记录一个结点的结束
        ///         2、然后再按照先序方式反序列化出树


        #region 先序遍历的序列化与反序列化
        public static string SerialByPre(Node head)
        {
            if (head == null)
                return "#!";
            string res = head.value + "!";
            res += SerialByPre(head.left);
            res += SerialByPre(head.right);
            return res;
        }

        public static Node ReconByPreString(String preStr)
        {
            string[] values = preStr.Split("!");
            Queue<string> queue = new();
            for (int i = 0; i != values.Length; i++)
                queue.Enqueue(values[i]);
            return ReconPreOrder(queue);
        }

        public static Node ReconPreOrder(Queue<String> queue)
        {
            string value = queue.Dequeue();
            if (value.Equals("#"))
                return null;

            Node head = new Node(Convert.ToInt32(value));
            head.left = ReconPreOrder(queue);
            head.right = ReconPreOrder(queue);
            return head;
        }
        #endregion
    }
}
