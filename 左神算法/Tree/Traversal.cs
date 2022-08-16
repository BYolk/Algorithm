using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.Tree
{
    //遍历算法
    internal class Traversal
    {
        ///树结构：
        /// 
        public class TreeNode
        {
            public int value;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int value)
            {
                this.value = value;
            }
        }

        #region 递归遍历二叉树：

        ///递归序遍历：
        /// 1、每个结点都会被访问三次的递归方式称为递归序遍历
        /// 2、先序、中序、后序遍历都是在递归序的基础上加工出来的
        public static void RecursiveTraversal(TreeNode head)
        {
            //第一次来到 当前结点
            if (head == null) return;

            RecursiveTraversal(head.left);
            //第二次来到 当前结点

            RecursiveTraversal(head.right);
            //第三次来到 当前结点

            //结束当前方法
        }
        
        ///先序遍历：
        /// 1、对于每一个子树，都先打印头结点，然后打印左节点，最后打印右节点，这样的遍历叫先序遍历
        /// 2、和递归序有什么关系？
        ///     ————当我们第一次来到一个结点的时候，我们打印该结点，第二三次来到该结点的时候不管，这样的递归序就是先序遍历
        public static void PreorderRecur(TreeNode head)
        {
            if (head == null) return;

            Console.WriteLine(head.value);//在递归序中，第一次来到结点的时候打印该结点，其余不管
            PreorderRecur(head.left);
            PreorderRecur(head.right);
        }

        ///中序遍历：
        /// 1、对于每一个子树，都先打印左结点，然后打印头节点，最后打印右节点，这样的遍历叫中序遍历
        /// 2、和递归序有什么关系？
        ///     ————当我们第二次来到该结点的时候才打印该结点，第一次和第三次来到该节点的时候不管，这样的递归序就是中序遍历
        public static void InorderRecur(TreeNode head)
        {
            if (head == null) return;

            InorderRecur(head.left);
            Console.WriteLine(head);//在递归序中，第二次来到结点的时候打印该结点，其余不管
            InorderRecur(head.right);
        }

        ///后序遍历：
        /// 1、对于每一个子树，都先打印左结点，然后打印右节点，最后打印头节点，这样的遍历叫后序遍历
        /// 2、和递归序有什么关系？
        ///     ————当我们第三次来到该结点的时候才打印该结点，第一次和第二次来到该节点的时候不管，这样的递归序就是后序遍历
        public static void PostorderRecur(TreeNode head)
        {
            if (head == null) return;

            PostorderRecur(head.left);
            PostorderRecur(head.right);
            Console.WriteLine(head.value);//在递归序中，第三次来到结点的时候打印该结点，其余不管
        }
        #endregion

        #region 非递归遍历二叉树
        /// 原理：
        ///     1、任何递归都可以转换为非递归
        ///     2、递归无非就是不断地将方法压入内存栈中实现
        ///     3、既然不用递归，我们自己创建一个栈，自己压栈就行了
        
        ///非递归先序遍历：
        /// 1、准备一个栈，先压入头结点
        /// 2、将结点从栈中弹出，记弹出的结点为 cur
        /// 3、打印/处理 cur
        /// 4、如果有右孩子和左孩子，先将 cur 的右孩子压入栈中，再把 cur 左孩子压入栈中
        /// 5、循环 2、--> 4、
        /// 6、栈为空，先序遍历完成
        /// 7、为什么弹出头结点后，要先压入右孩子，再压入左孩子？
        ///     1、首先先序遍历是遍历头结点之后，先遍历左孩子、再遍历右孩子
        ///     2、而栈是先进后出，后进先出的结构，要先遍历左孩子，左孩子就不能先压栈
        public static void PreorderUnRecur(TreeNode head)
        {
            if (head == null) return;

            Console.WriteLine("非递归先序遍历：");
            Stack<TreeNode> stack = new();
            stack.Push(head);
            while(stack.Count > 0)
            {
                head = stack.Pop();
                Console.WriteLine(head.value);
                if (head.right != null)
                    stack.Push(head.right);
                if (head.left != null)
                    stack.Push(head.left);
            }
        }

        ///非递归中序遍历：
        /// 1、准备一个栈
        /// 2、每棵子树的整棵树的左边界进栈
        /// 3、弹出每个结点的过程中，打印/处理 该结点，然后对该结点的右树做 2、--> 3、操作
        /// 4、当栈为空时，即为中序遍历
        public static void InorderUnRecur(TreeNode head)
        {
            if (head == null) return;

            Console.WriteLine("非递归中序遍历：");
            Stack<TreeNode> stack = new();
            //stack.Push(head);//和先序后序不同，中序要一次性压入一整棵树的左树
            while(stack.Count > 0 || head != null)//栈为空或头结点为空时退出循环
            {
                if(head != null)
                {
                    stack.Push(head);
                    head = head.left;
                }
                else//代码走这里，说明左树的结点全部压入，此时 head 指向左叶节点的左孩子，为 null
                {
                    head = stack.Pop();//整棵左树压入后，弹出结点，然后对该结点的右数做以上同样操作
                    Console.Write(head.value + " ");
                    head = head.right;//对该结点的右数做以上同样操作，此时右数成了头节点
                }
            }
        }



        ///非递归后序遍历（一个栈的形式）：
        /// 
        public static void PostorderUnRecur1(TreeNode head)
        {
            if (head == null) return;

            Console.WriteLine("非递归后序遍历（一个栈的形式）：");
            Stack<TreeNode> stack = new();
            stack.Push(head);
            TreeNode cur = null;
            while(stack.Count > 0)
            {
                cur = stack.Peek();//获取栈顶的结点，但是不移动它
                if(cur.left != null && head != cur.left && head != cur.right)
                {
                    stack.Push(cur.left);
                }
                else if(cur.right != null && head != cur.right)
                {
                    stack.Push(cur.right);
                }
                else
                {
                    Console.Write(stack.Pop().value + " ");
                    head = cur;
                }
            }
        }

        ///非递归后序遍历（两个栈的形式）：
        /// 1、再准备一个栈，命名为收集栈
        /// 2、先把头结点压入栈中
        /// 3、弹出结点(将弹出的结点记为 cur)，把弹出的结点放入收集栈中
        /// 4、先压左孩子，再压右孩子
        /// 5、循环 3、--> 4、
        /// 6、将收集栈的结点全部弹出 遍历/处理，就是中序遍历
        /// 7、为什么要先压左孩子再压右孩子？
        ///     1、第一个栈先左再右,弹出后放入收集栈的时候就是先右后左
        ///     2、在收集栈弹出的时候就是先左再右
        ///     3、收集栈在压入孩子之前已经压入头结点，打印出来就是先左再有最后头，也就是后序遍历
        /// 8、关键点：
        ///     1、打印的方式是左右头
        ///     2、收集的方式就是头右左（确保进入收集栈的顺序是头右左）
        public static void PostorderUnRecur2(TreeNode head)
        {
            if (head == null) return;

            Console.WriteLine("非递归后序遍历（两个栈的形式）：");
            Stack<TreeNode> middleStack = new();
            Stack<TreeNode> collectStack = new();

            middleStack.Push(head);
            while(middleStack.Count > 0)
            {
                head = middleStack.Pop();
                collectStack.Push(head);
                if (head.left != null)
                    middleStack.Push(head.left);
                if (head.right != null)
                    middleStack.Push(head.right);
            }
            
            //代码走到这里，所有的树节点都压入收集栈中了
            while(collectStack.Count > 0)
            {
                Console.Write(collectStack.Pop().value + " ");
            }
        }

        #endregion

        #region 二叉树的宽度优先遍历————每一层从左到右遍历（经常考题：求算一棵树的宽度）
        ///宽度优先遍历思路：
        /// 1、二叉树的宽度优先遍历其实就是二叉树的先序遍历，先头、再左、再右
        /// 2、只是宽度优先遍历准备的不是栈，而是队列（先进先出）
        /// 3、先将头节点放入队列中
        /// 4、将结点弹出队列，然后该结点的左孩子先进队列，右孩子再进队列（如果右的话）
        /// 5、重复 3、--> 4、操作（先头、再左、再右，与先序遍历一样）
        /// 
        public static void WidthTraversal(TreeNode head)
        {
            if (head == null) return;
            Queue<TreeNode> queue = new();
            queue.Enqueue(head);
            while(queue.Count > 0)
            {
                TreeNode cur = queue.Dequeue();
                Console.Write(cur.value + " ");
                if(cur.left != null)
                    queue.Enqueue(cur.left);
                if (cur.right != null)
                    queue.Enqueue(cur.right);
            }
        }

        ///求一棵树的最大宽度思路：采用哈希表
        /// 1、定义三个变量：
        ///     1、maxWidth 表示最大宽度
        ///     2、curWidth 表示当前层的最大宽度
        ///     3、curLevel 表示当前所在层
        /// 2、准备一个哈希表（用于记录结点及其信息），key 用来存放树的每一个结点，value 用来存放每一个结点所在的层
        /// 3、先将头结点放入哈希表中
        /// 4、再准备一个队列（用于遍历树的每一个结点，遍历出来的结点的信息会放到哈希表中）
        /// 5、先将头结点放入队列中
        /// 6、再准备三个结点指针：
        ///     1、Node node = null;用来指向当前从队列中弹出的结点
        ///     2、Node left = null;用来指向当前从队列中弹出的结点的左孩子
        ///     3、Node right = null;用来指向当前从队列中弹出的结点的右孩子
        /// 7、（队列不为空）循环遍历每个结点：
        ///     1、将当前从队列中弹出的结点保存到 node 上
        ///     2、记录该结点的左孩子和右孩子到 left，right 中
        ///     3、如果左孩子不为空（保持先左再右）
        ///         1、将左孩子放入哈希表中，对应 value 是当前结点 node 所在层数 + 1
        ///         2、让左孩子进队
        ///     4、如果右孩子不为空
        ///         1、将右孩子放入哈希表中，对应 value 是当前结点 node 所在层数 + 1
        ///         2、让右孩子进队
        ///     5、如果当前结点所在层数没有大于 curLevel，说明还在处理当前层，并且已经为当前层遍历完一个结点，当前层宽度加1
        ///     6、如果当前结点所在层数大于 curLevel，说明上一层已经遍历完了，现在已经进入下一层了，整理信息
        ///         1、将当前层的宽度归零（还没有遍历当前层）
        ///         2、更新 curLevel（curLevel = levelMap.get(node);）
        ///     7、更新当前层的最大宽度
        /// 8、循环遍历结束，获得树的最大宽度，返回即可
        /// 
        public static int GetMaxWidth(TreeNode head)
        {
            if (head == null) return 0;

            int maxWidth = 0;//最大宽度
            int curWidth = 0;//当前层宽度
            int curLevel = 0;//当前所在层
            TreeNode curNode = null;//当前遍历的结点
            TreeNode left = null;//当前遍历的结点的左孩子
            TreeNode right = null;//当前遍历的结点的右孩子
            Queue<TreeNode> queue = new();//准备队列，用于遍历树的每个结点
            Dictionary<TreeNode, int> dic = new();//准备队列，用于储存该节点所在的层的信息
            queue.Enqueue(head);
            dic.Add(head, 1);

            while(queue.Count > 0)
            {
                curNode = queue.Dequeue();
                left = curNode.left;
                right = curNode.right;
                int level;//用于存放哈希表中当前结点所对应的层数
                if (left != null)
                {
                    queue.Enqueue(left);//左孩子入队
                    dic.TryGetValue(curNode,out level);
                    dic.Add(left, level++);//将左孩子信息保存到字典
                }
                if(right != null)
                {
                    queue.Enqueue(right);//右孩子入队
                    dic.TryGetValue(curNode, out level);
                    dic.Add(right, level++);
                }

                dic.TryGetValue(curNode, out level);
                if(level <= curLevel)//如果当前结点所在层小于等于当前层，说明当前层还未遍历完，当前层的宽度加 1
                {
                    curWidth++;
                }
                else//若当前结点所对应的层数大于当前层，说明当前层已经遍历结束，开始进入下一层的遍历了，在此要更新变量
                {
                    curWidth = 0;
                    dic.TryGetValue(curNode, out curLevel);
                }
                maxWidth = Math.Max(maxWidth, curWidth);//更新最大层
            }
            return maxWidth;
        }
        #endregion
    
    
    
        /*static void Main(string[] args)
        {
            Traversal.TreeNode head = new Traversal.TreeNode(5);
            head.left = new Traversal.TreeNode(3);
            head.right = new Traversal.TreeNode(8);
            head.left.left = new Traversal.TreeNode(2);
            head.left.right = new Traversal.TreeNode(4);
            head.left.left.left = new Traversal.TreeNode(1);
            head.right.left = new Traversal.TreeNode(7);
            head.right.left.left = new Traversal.TreeNode(6);
            head.right.right = new Traversal.TreeNode(10);
            head.right.right.left = new Traversal.TreeNode(9);
            head.right.right.right = new Traversal.TreeNode(11);

            // recursive
            Console.WriteLine("pre-order: ");
            Traversal.PreorderRecur(head);
            Console.WriteLine();
            Console.Write("in-order: ");
            Traversal.InorderRecur(head);
            Console.WriteLine();
            Console.Write("pos-order: ");
            Traversal.PostorderRecur(head);
            Console.WriteLine();

            // unrecursive
            Traversal.PreorderUnRecur(head);
            Traversal.InorderUnRecur(head);
            Traversal.PostorderUnRecur1(head);
            Traversal.PostorderUnRecur2(head);
        }*/
    }
}
