using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.Graph
{
    internal class Traversal
    {
        ///1、图的宽度优先遍历：
        /// 1、利用队列实现
        /// 2、从源结点开始依次按照宽度进队列，然后弹出
        /// 3、每弹出一个点，把该结点所有没有进过队列的邻接点放入队列
        /// 4、直到队列为空
        /// 5、可以使用数组替代哈希表，加快速度
        public static void BFS(Node node)
        {
            if (node == null) return;

            //准备队列和哈希表
            Queue<Node> queue = new Queue<Node> ();
            HashSet<Node> map = new HashSet<Node> ();

            //将结点放入队列和哈希表中
            queue.Enqueue(node);
            map.Add(node);

            //只要队列不为空，一直处理下去
            while(queue.Count > 0)
            {
                Node cur = queue.Dequeue();
                Console.WriteLine(cur.value);//输出当前结点的值
                foreach(Node next in cur.nexts)//遍历该结点的所有的下一个结点（判断下一个结点是否已经在哈希表中（是否已经遍历过））
                {
                    if (!map.Contains(next))//一定要有这个判断机制，否则遇到无向图会进入死循环一直跑下去
                    {
                        map.Add (next);
                        queue.Enqueue(next);
                    }
                }
            }
        }

        ///2、图的广度优先遍历：
        /// 1、利用栈实现
        /// 2、从源结点开始把结点按深度放入栈，然后弹出
        /// 3、每弹出一个点，把该结点的下一个没有进过栈的邻接点放入栈
        /// 4、直到栈变空
        /// 
        public static void DFS(Node node)
        {
            if (node == null) return;

            //准备栈和哈希集
            Stack<Node> stack = new Stack<Node> ();
            HashSet<Node> set = new HashSet<Node> ();

            //将第一个结点入栈，也保存到哈希集中
            stack.Push(node);
            set.Add(node);

            Console.WriteLine(node.value);
            while(stack.Count > 0)//如果栈不为空
            {
                Node cur = stack.Pop();
                foreach(Node next in cur.nexts)
                {
                    if (!set.Contains(next))
                    {
                        stack.Push(cur);//把弹出的结点重新压回去
                        stack.Push(next);//再压入该结点的下一个结点————意思是如果这条路我走过，那我就顺着这条路走到死
                        set.Add(next);
                        Console.WriteLine(next.value);
                        break;
                    }
                }
            }
        }
    }
}
