using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///题目
///
namespace 算法.Tree
{
    internal class TreeSubject_LowestCommonAncestor
    {
        #region 树的结构
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
        #endregion




        #region 给定两个二叉树的结点 node1 和 node2，找到他们的最低公共祖先节点
        /// 使用哈希表和哈希集的解题思路：
        ///     1、先准备一个哈希表，以 <当前结点，当前结点的父节点> 的形式将整棵树的结点及其对应的父节点放入哈希表中
        ///         1、先将根节点放入哈希表，根节点对应的头结点是它自己
        ///         2、再使用递归的方式遍历根节点之下的两个子结点，将两个子节点都放入哈希表中，父节点是根节点
        ///         3、再对根节点之下的每一个子节点做同样的递归操作，将整棵树的结点及其对应的子节点都放入哈希表
        ///         
        ///     2、再准备一个哈希集 HashSet，用来存放 node1 结点及其父节点
        ///         1、用一个结点指针 cur 指向 node1，然后在哈希表中查找 cur 的父节点，只要 cur 不等于它的父节点，往上遍历
        ///         2、解释 1、————只有根节点才会等于它的父节点，当cur 指向根节点时，cur = cur父节点，不能再往上遍历了
        ///         3、最后单独把根节点放入表中
        ///     
        ///     3、对 node2
        ///         1、同理遍历 node2 其父节点
        ///         2、如果 node2 及其父节点中有一个在哈希集中已经存在，则该结点就是他们的 最低公共祖先
        ///         3、将该结点返回
        public static TreeNode NormalLowestCommonAncestor(TreeNode head, TreeNode node1,TreeNode node2)
        {
            //head 一定不为空,因为 node1 和 node2 必须是 head 的子节点

            Dictionary<TreeNode, TreeNode> fatherDic = new();//创建一个哈希表，用来存放当前节点的父节点
            fatherDic.Add(head, head);//根节点的父节点是自己


            NormalProcess(head, fatherDic);//遍历每一个结点，把该节点的父节点保存到哈希表内


            ///代码解释：
            /// 1、准备一个哈希集，用来存放 node1 的所有父、爷……根结点
            /// 2、用一个结点指针 cur 指向 node1
            /// 3、只要 cur 不等于自己的头结点,即只要 cur 没有遍历到根节点，就继续网上遍历自己的父节点
            /// 4、cur 等于 根节点，不能继续往上遍历了，结束循环，单独将根节点添加到表中
            HashSet<TreeNode> set = new();
            TreeNode cur = node1;
            TreeNode father;
            fatherDic.TryGetValue(cur, out father);
            while (cur != father)
            {
                set.Add(cur);
                fatherDic.TryGetValue(cur, out cur);//让 cur 指向它的父节点
                fatherDic.TryGetValue(cur, out father);//让 father 指向 cur 的父节点
            }
            //代码走到这里，cur 和 father 都指向根结点，再把根结点加入 HashSet 中
            set.Add(head);

            cur = node2;
            while(cur != head)
            {
                if (set.Contains(cur))
                    return cur;
                fatherDic.TryGetValue(cur, out cur);//将 cur 指向它的父节点
            }

            //如果代码走到这里，说明根结点才是他们的最低公共祖先
            return head;
        }

        public static void NormalProcess(TreeNode head, Dictionary<TreeNode,TreeNode> fatherDic)
        {
            if (head == null) return;//如果当前结点为空，不用往哈希表添加结点

            if(head.left != null)
                fatherDic.Add(head.left, head);
            if(head.right != null)
                fatherDic.Add(head.right, head);

            //遍历每一个子节点
            NormalProcess(head.left, fatherDic);
            NormalProcess(head.right, fatherDic);
        }






        /// 不使用额外空间的解题思路：
        ///     1、情况分明：
        ///         1、node1 是 node2 的最低公共祖先，返回 node1
        ///         2、node2 是 node1 的最低公共祖先，返回 node2
        ///         3、node1 和 node2 不互为最低公共祖先，通过往上遍历的方式找到最低公共祖先
        ///     2、关键点：
        ///         1、如果一颗子树上既没有 node1，也没有 node2 ，那它一定返回 null
        ///         2、如果左子树既没有 node1 和 node2，那么 node1 和 node2 一定在右子树
        ///         3、如果右子树既没有 node1 和 node2，那么 node1 和 node2 一定在左子树
        ///         4、如果一个树的左节点是 node1，而右节点没有 node2，那么node2 一定在 node1 底下，node1是最低公共祖先
        ///         
        /// 
        public static TreeNode BetterLowestCommonAncestor(TreeNode head, TreeNode node1,TreeNode node2)
        {
            ///代码解释：
            /// 1、如果一个结点为空，那么返回空
            /// 2、如果一个结点是 node1 直接返回 node1
            /// 3、如果一个结点是 node2 直接返回 node2
            /// 4、用这条代码取遍历一棵树，会有三种返回情况：
            ///     1、遍历到叶节点都没有找到 node1 和 node2 ，返回 null
            ///     2、遇到 node1，把 node1 返回
            ///     3、遇到 node2，把 node2 返回
            /// 5、第一次调用该函数：
            ///     1、该题目的隐含条件就是根结点一定不为 null，因为存在 node1 和 node2
            ///     2、如果根结点为 node1 ，那么 node1 就是最低公共祖先
            ///     3、如果根结点为 node2 ，那么 node2 就是最低公共祖先
            ///     4、如果根结点既不为空，也不是 node1，也不是 node2，那么对它的左孩子和右孩子做递归操作
            /// 6、对于互为公共最低祖先的情况：
            ///     1、如果 node1 是 node2 的最低公共祖先（反过来 node2 是 node1的最低公共祖先也一样）
            ///     2、那么对于 node1 的父节点，它在调用递归遍历的时候，left 一定返回 node1，右孩子一定返回 null
            ///     3、因为 node2 在 node1 下，node1 的兄弟结点是不可能存在 node2的，对node1 的兄弟结点左递归操作一定返回null
            ///     4、也就是说，对于一个结点，如果它的左孩子返回 node，而右孩子返回 null，那么 node 就是最低公共祖先
            /// 7、对于 node1 和 node2 不互为公共最低祖先的情况：
            ///     1、对于 node1 和 node2 的公共最低祖先 node
            ///     2、对 node 做递归遍历，node 的左孩子返回值一定不为空，因为其中一个结点在 node 的左孩子下
            ///     3、对 node 做递归遍历，node 的右孩子返回值一定不为空，因为其中一个结点在 node 的右孩子下
            ///     4、总结：
            ///         1、如果对于一个结点
            ///         2、它的左孩子做递归遍历返回值不为空
            ///         3、它的右孩子做递归遍历返回值也不为空
            ///         4、那么它就是 node1 和 node2 的最低公共祖先
            if (head == null || head == node1 || head == node2) return head;

            TreeNode left = BetterLowestCommonAncestor(head.left, node1, node2);
            TreeNode right = BetterLowestCommonAncestor(head.right, node1, node2);

            if (left != null && right != null) return head;

            ///代码解释：
            ///  1、代码走到这里说明 left 和 right 有一个为空或都为空
            ///  2、如果左孩子为 null，返回右孩子，否则返回左孩子（返回不空的那个）
            ///  3、如果左右孩子都为空，那就返回空
            return left != null ? left : right;
        }
        #endregion



        /*public static void Main(string[] args)
        {
            TreeNode head = new TreeNode(1);
            head.left = new TreeNode(2);
            head.right = new TreeNode(3);
            head.left.left = new TreeNode(4);
            head.left.right = new TreeNode(5);
            head.right.left = new TreeNode(6);
            head.right.right = new TreeNode(7);
            head.right.right.left = new TreeNode(8);
            Console.Write(head);
            Console.WriteLine("===============");

            TreeNode o1 = head.left.right;
            TreeNode o2 = head.right.left;
            //TreeNode o1 = head.right.right.left;
            //TreeNode o2 = head.right.left;

            Console.WriteLine("o1 : " + o1.value);
            Console.WriteLine("o2 : " + o2.value);


            //测试
            //Console.WriteLine("ancestor : " + NormalLowestCommonAncestor(head, o1, o2).value);
            Console.WriteLine("ancestor : " + BetterLowestCommonAncestor(head, o1, o2).value);
            Console.WriteLine("===============");
        }*/
    }
}
