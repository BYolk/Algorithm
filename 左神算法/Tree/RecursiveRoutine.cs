using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.Tree
{


    /// 使用递归套路判断树的类型————递归套路可以解决一切树形 DP 问题（树形动态规划问题，二叉树最难题目）
    ///     注意递归套路必须是通过左右子树要信息后能解出当前树的一个问题 ，不是所有树的问题都可以用递归套路来解
    ///     
    
    internal class RecursiveRoutine
    {
        #region 树结构
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

        #region 使用递归套路判断一棵树是平衡二叉树
        ///使用递归套路判断一棵树是否是平衡二叉树：
        /// 1、平衡二叉树需要满足条件：对于每一棵(子)树
        ///     1、满足左子树是平衡二叉树
        ///     2、满足右子树是平衡二叉树
        ///     3、满足左右高度差不超过 1
        /// 2、怎么做？
        ///     1、向左子树收集信息：左子树是否是平衡二叉树？左子树的高度是？
        ///     2、向右子树收集信息：右子树是否是平衡二叉树？右子树的高度是？
        ///     3、递归收集每一棵子树的上述信息
        ///     4、判断：
        ///         1、左右子树都是平衡二叉树
        ///         2、左右子树高度差不超过 1
        ///     5、因为要收集的信息有两个，可以使用一个类或者结构体来构造这两个变量
        public static bool IsBBT(TreeNode head)
        {
            if (head == null) return true;//认为空树是平衡二叉树
            return BBTRecursiveProcess(head).isBalanced;
        }

        /// 平衡二叉树需要向子树收集两个信息，所以遍历子树需要返回两个信息，用类或结构体来封装这两个信息
        /// 因为只要保存一个布尔变量和一个整型变量，使用结构体更好：
        ///     结构体存放在栈中，栈空间小访问速度快，所以结构体一般存放比较轻量级的数据
        ///     于此相反，类存放在堆中，堆空间大访问速度比栈慢
        ///         访问堆的数据需要先访问栈再取访问堆
        ///         且栈有专门的寄存器，而堆是随机内存的
        ///     所以类一般都是用来存放一下逻辑结构复杂或者比较重量级的数据
        ///     对于轻量级数据，使用结构体保存，优点在于访问速度快，且不占内存空间（栈的空间自动释放，而堆的空间需要等待GC释放）
        ///
        /*public class BBTReturnType
        {
            public bool isBalanced;
            public int height;
            public BBTReturnType(bool isBalanced, int height)
            {
                this.isBalanced = isBalanced;
                this.height = height;
            }
        }*/
        public struct BBTRecursiveReturnData
        {
            public bool isBalanced;
            public int height;

            public BBTRecursiveReturnData(bool isBalanced, int height)
            {
                this.isBalanced = isBalanced;
                this.height = height;
            }
        }

        public static BBTRecursiveReturnData BBTRecursiveProcess(TreeNode head)
        {
            if (head == null) return new BBTRecursiveReturnData(true, 0);//如果树为空，认为是平衡二叉树

            //收集左右子树信息
            BBTRecursiveReturnData leftData = BBTRecursiveProcess(head.left);
            BBTRecursiveReturnData rightData = BBTRecursiveProcess(head.right);


            ///整理左右子树信息
            ///获取当前树的最大高度（左右子树的最大高度 + 自身，即 “左右子树较大的高度 + 1”
            ///判断左右子树是否都是平衡二叉树且高度差不超过1（如果这个条件不满足，说明这棵树不是平衡二叉树）
            int height = Math.Max(leftData.height, rightData.height) + 1;
            bool isBalanced = leftData.isBalanced &&
                                rightData.isBalanced &&
                                Math.Abs(leftData.height - rightData.height) < 2;

            //返回左右子树信息
            return new BBTRecursiveReturnData(isBalanced, height);//将左右子树最大高度和是否为平衡二叉树信息返回
        }
        #endregion


        #region 使用递归套路判断一棵树是搜索二叉树
        /// 1、使用递归套路判断一棵树是搜索二叉树思路：
        ///     1、左树是搜索二叉树
        ///     2、右树是搜索二叉树
        ///     3、左树的最大值要小于当前结点数
        ///     4、右树的最小值要大于当前节点数
        /// 2、所以每一棵树的遍历都需要返回三个信息：
        ///     1、子树是不是搜索二叉树
        ///     2、子树最小值
        ///     3、子树最大值

        ///搜索二叉树(二叉搜索树)返回信息结构体
        ///
        public class BSTRecursiveReturnData
        {
            public bool isSearch;
            public int max;
            public int min;
            public BSTRecursiveReturnData(bool isSearch, int max, int min)
            {
                this.isSearch = isSearch;
                this.max = max;
                this.min = min;
            }
        }

        public static BSTRecursiveReturnData BSTRecursiveProcess(TreeNode head)
        {
            if (head == null) return null;//如果 BSTReturnData 为结构体，结构体不能为 null


            ///收集二叉搜索树的左右子树信息
            ///
            BSTRecursiveReturnData leftData = BSTRecursiveProcess(head.left);
            BSTRecursiveReturnData rightData = BSTRecursiveProcess(head.right);

            ///整理二叉搜索树的左右子树信息
            ///

            int min = head.value;
            int max = head.value;
            if (leftData != null)
            {
                min = Math.Min(min, leftData.min);//当前结点值和子树中的最小值做比较,取更小的值放入 min 中,得到当前树的最小值
                max = Math.Max(max, leftData.max);
            }
            if(rightData != null)
            {
                min = Math.Min(min, rightData.min);
                max = Math.Max(max, rightData.max);
            }

            ///代码解释：
            /// 1、先认为是二叉搜索树，然后看其是否违规
            /// 2、如果左树不是搜索二叉树（要先判断左树有信息，不然空指针异常），或者左树最大值大于当前结点，不是搜索二叉树
            /// 3、如果右树不是搜索二叉树（要先判断左树有信息，不然空指针异常），或者右树最小值小于当前结点，不是搜索二叉树
            /// 4、如果左树和右树为空，对当前结点没有影响，当前结点的最大值和最小值是当前结点本身
            bool isBST = true;
            if(leftData != null && (!leftData.isSearch || leftData.max > head.value))
                isBST = false;
            if(rightData != null && (!rightData.isSearch || rightData.min < head.value))
                isBST = false;

            ///代码走到这里，当前树是搜索二叉树，返回当前数的信息
            return new BSTRecursiveReturnData(isBST, min, max);
        }
        
        public static bool IsBST(TreeNode head)
        {
            if (head == null) return true;
            return BSTRecursiveProcess(head).isSearch;
        }
        #endregion


        #region 使用递归套路判断一棵树是满二叉树
        public class FBTRecursiveReturnData
        {
            public int height;
            public int nodeCount;
            public FBTRecursiveReturnData(int height,int nodeCount)
            {
                this.height = height;
                this.nodeCount = nodeCount;
            }
        }

        public static bool IsFBT(TreeNode head)
        {
            if (head == null) return true;
            FBTRecursiveReturnData data = FBTRecursiveProcess(head);
            return data.nodeCount == 1 << data.height - 1;//N = 2^L -1(N 表示总结点,L 表示最大高度,若满足表达式是满二叉树)
        }

        public static FBTRecursiveReturnData FBTRecursiveProcess(TreeNode head)
        {
            if (head == null) return new FBTRecursiveReturnData(0, 0);//当前结点为空，则该结点高度和总结点数为 0

            ///收集子树信息
            ///
            FBTRecursiveReturnData leftData = FBTRecursiveProcess(head.left);
            FBTRecursiveReturnData rightData = FBTRecursiveProcess(head.right);

            ///整理子树信息
            ///
            int height = Math.Max(leftData.height, rightData.height) + 1;//左右子树更高的树的高度 + 自身高度
            int nodeCount = leftData.nodeCount + rightData.nodeCount + 1;//左树结点 + 右树结点 + 自身

            return new FBTRecursiveReturnData(height, nodeCount);
        }
        #endregion  
    }
}
