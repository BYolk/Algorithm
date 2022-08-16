using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.GreedyAlgorithm
{
    internal class LowestLexicography
    {
        ///从头到尾展示最正统的贪心策略求解过程
        /// 1、例子：
        ///     1、给定一个字符串类型的数组strs，找到一种拼接方式，使得把所有字符串拼起来之后形成的字符串具有最小的字典序。
        ///     2、字典序：
        ///         1、查字典时的顺序，a 的字典序要小于 b，在查字典时，a 要最先出现
        ///         2、如果第一个字符串的个数少于第二个字符串，那么对第一个字符串末尾补 0，让其跟第二个字符串等长，然后计算其字典序
        ///         3、易错点：
        ///             1、两个字符串"ba"和"b"拼接
        ///             2、如果按字典序比较 "b" 是小于 "ba" ，字典序小的放前面，字典序大的放后面，那么拼接之后为"bba"
        ///             3、这样的凭借方式实际上是错误的。因为"bba"的字典序是大于"bab"的。
        ///         4、正确思路：拼接两个字符串 a 和 b ，应该比较 a+b 和 b+a 字符串的字典序，字典序小的为a和b拼接的结果。
        /// 2、证明贪心策略可能是件非常腌心的事情。平时当然推荐你搞清楚所有的来龙去脉，但是笔试时用对数器的方式！
        /// 
        public class MyComparator : IComparer<string>
        {

            public int Compare(string? x, string? y)
            {
                return (x + y).CompareTo(y + x);//比较 x+y 和 y+x 哪个字符串大
            }

            public static string LowestLexicographyAlgorithm(string[] strs)
            {
                if (strs == null || strs.Length == 0) return "";
                Array.Sort(strs, new MyComparator());//排序
                string res = "";
                for (int i = 0; i < strs.Length; i++)
                    res += strs[i];

                return res;
            }

            /*public static void Main(string[] args)
            {
                String[] strs1 = { "jibw", "ji", "jp", "bw", "jibw" };
                Console.WriteLine(LowestLexicographyAlgorithm(strs1));

                String[] strs2 = { "ba", "b" };
                Console.WriteLine(LowestLexicographyAlgorithm(strs2));
            }*/
        }

    }
}
