using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.Tree
{
    internal class TreeSubject_PaperFolding
    {
        
        /// 折纸问题
        ///     请把一段纸条竖着放在桌子上，然后从纸条的下边向上方对折1次，压出折痕后展开。
        ///     此时折痕是凹下去的，即折痕突起的方向指向纸条的背面。
        ///     如果从纸条的下边向上方连续对折2次，压出折痕后展开，此时有三条折痕，从上到下依次是下折痕、下折痕和上折痕。
        ///     给定一个输入参数N，代表纸条都从下边向上方连续对折N次。请从上到下打印所有折痕的方向。
        ///     例如:N=1时，打印: down N = 2时，打印: down down up
        ///     
        /// 问题：如何从上到下打印折痕————
        ///     1、以第一次折痕作为头结点
        ///     2、第二次折痕作为头结点的左右子孩子
        ///     3、第三次折痕作为头结点的左右孩子的左右孩子
        ///     4、……
        ///     6、对这棵树中序遍历，得到的折痕就是纸从上到下的一个折痕

        /// N 表示折的次数
        public static void PrintAllFolds(int N)
        {
            PrintProcess(1, N, true);
        }

        /// 递归过程：
        ///     1、表示来到某个结点
        ///     2、i 是结点的层数，N 是一共的层数，
        ///     3、down = true 表示凹，down = false 表示 凸
        public static void PrintProcess(int i, int N, bool down)
        {
            if (i > N) return;

            PrintProcess(i + 1, N, true);

            Console.WriteLine(down ? "down" : "up");
            PrintProcess(i + 1, N, false);
        }



        /*public static void Main(string[] args)
        {
            int N = 3;
            PrintAllFolds(N);
        }*/



    }
}