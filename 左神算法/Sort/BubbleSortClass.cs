using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.Sort
{
    internal class BubbleSortClass
    {

        /*2、冒泡排序：时间复杂度为——N的平方
        对比第一个和第二个位置数据，将大的后移，然后对比第二个和第三个位置数据，将大的后移，然后对比第三个和第四个位置数据，将大的后移……最后对比 n-1 和 n 位置数据，将大的往后移，最后在 n 位置得到最大的数
        对比第二个和第三个位置数据，将大的后移，然后对比第三个和第四个位置数据，将大的后移，然后对比第四个和第五个位置数据，将大的后移……最后对比 n-2 和 n-1 位置数据，将大的往后移，最后在 n-1 位置得到第二大的数
        ……
        直到排完序*/
        public static void BubbleSort(int[] arr)
        {
            if (arr == null || arr.Length < 2)//数组为空或数组元素个数小于2时不用排序
                return;

            for (int i = arr.Length - 1; i > 0; i--)//排n-1次序之后，最后剩下的一个肯定是最小的，所以不用i = 0
                for (int j = 0; j < i; j++)//因为第 n 个数和第 n+1 个数比较，所以不用 j = i
                    if (arr[j] > arr[j + 1])//如果前面数大于后面的数
                        Swap(arr, j, j + 1);
        }

        /// <summary>
        /// 交换两个位置的数据
        ///     1、异或运算：
        ///         1、二进制对应数字不同为 1，相同为 0
        ///         2、或者可以理解为“无进位相加”，比如 “0+0 = 0，0+1 = 1，1 + 1 = 0（二进制中 1+1 = 10，但是无进位，不进位得到 0）
        ///         3、异或运算的性质：
        ///             1、0 ^ N = N
        ///             2、N ^ N = 0
        ///             3、异或运算满足交换律和结合律————抑或的结果与抑或的顺序无关
        ///             
        ///     2、优点：无需开闭额外的空间，通过两个数做异或运算即可完成值的交换
        ///     3、前提：两个数在内存里必须是两个独立的区域，而不是同一个内存空间里的同一个数，如果两个数是同一个内存空间里的数，会把该内存空间的数置为0（自己跟自己抑或，结果为0）。比如传递的两个数相等，并同时作为数组下标引用数组内的元素，那么获得的两个数据就是同一内存空间的数据（获取了同一下标位置的数据）
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public static void Swap(int[] arr, int i, int j)
        {
            arr[i] = arr[i] ^ arr[j];
            arr[j] = arr[i] ^ arr[j];//= arr[i] ^ arr[j] ^ arr[j] = arr[i] ^ (arr[j] ^ arr[j]) = arr[i]
            arr[i] = arr[i] ^ arr[j];//arr[i] ^ arr[j] ^ arr[i] = (arr[i] ^ arr[i]) ^ arr[j] = arr[j]
        }

    }
}
