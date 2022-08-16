using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.GreedyAlgorithm
{
    internal class LessMoneySplitGold
    {
        ///题目：
        /// 一块金条切成两半，是需要花费和长度数值一样的铜板的。比如长度为20的金条，不管切成长度多大的两半，都要花费20个铜板。
        ///     1、问现有一群人想整分整块金条，怎么分最省铜板?
        ///     2、例如：
        ///         1、给定数组{10,20,30}，代表一共三个人，整块金条长度为10+20+30=60。金条要分成10,20,30三个部分
        ///         2、如果先把长度60的金条分成10和50，花费60；
        ///         3、再把长度50的金条分成20和30，花费50；一共花费110铜板。
        ///         4、但是如果先把长度60的金条分成30和30，花费60；再把长度30金条分成10和20，花费30；一共花费90铜板。
        ///         5、输入一个数组，返回分割的最小代价。
        ///         
        public static int LessMoneySplitGoldAlgorithm(int[] arr)
        {
            int sum = 0;
            return sum;
        }
    }
}
