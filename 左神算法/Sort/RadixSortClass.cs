using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.Sort
{
    internal class RadixSortClass
    {
        /*桶排序：
         * 1、计数排序
         * 2、基数排序
         * 
         *桶排序分析：
         *  1、桶排序思想下的排序都是不基于比较的排序
         *  2、时间复杂度为 O(N),额外空间复杂度为O(M)
         *  3、应用范围有限，需要样本数据状况满足桶的划分
         */

        public static void RadixSort(int[] arr)
        {
            if (arr == null || arr.Length < 2)
                return;

            RadixSort(arr, 0, arr.Length - 1, Maxbits(arr));
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="digit">表示该数组最大的那位数的位数，如十位为2，百位为3，千位则4，</param>
        public static void RadixSort(int[] arr, int left, int right, int digit)
        {
            int radix = 10;//用于表示进制
            int i,j = 0;

            //数组多大就准备多大的辅助空间
            int[] bucket = new int[right - left + 1];
            for(int d = 1; d <= digit; d++)//有多少位就进出桶多少次
            {
                //定义 10 个空间
                //count[0] 当前位（d 位） 是 0 的数字有多少个
                //count[1] 当前位（d 位） 是 0 和 1的数字有多少个
                //count[2] 当前位（d 位） 是 0 和 1 和 2 的数字有多少个
                //count[i] 当前位（d 位） 是 0 和 …… 和 i 的数字有多少个

                int[] count = new int[radix];//count[0...9]
                for(i = left; i <= right; i++)
                {
                    j = GetDigit(arr[i], d);
                    count[j]++;
                }
                for(i = 1; i < radix; i++)
                {
                    count[i] = count[i] + count[i - 1];
                }
                for(i = right; i >= left; i--)
                {
                    j = GetDigit(arr[i], d);
                    bucket[count[j] - 1] = arr[i];
                    count[j]--;
                }
                for(i = left,j = 0; i <= right; i++, j++)
                {
                    arr[i] = bucket[j];
                }
            }

        }

        public static int Maxbits(int[] arr)
        {
            int max = int.MinValue;//先让 max 的值为 int 类型最小值，那么每一个 int 类型都不可能小于max
            for (int i = 0; i < arr.Length; i++)
                max = Math.Max(max, arr[i]);//记录数组中最大的那个数

            int digit = 0;//用于记录 max 有多少十进制位，10 有 2 位，100 有 3 位
            while(max != 0)
            {
                digit++;
                max /= 10;//只要 max / 10 不为 0，说明 max 的值大于 10
            }
            return digit;
        }

        public static int GetDigit(int x, int d)
        {
            return ((x / ((int)Math.Pow(10, d - 1))) % 10);
        }
    }
}
