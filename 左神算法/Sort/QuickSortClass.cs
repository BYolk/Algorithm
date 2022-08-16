using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.Sort
{
    internal class QuickSortClass
    {
        /* 1、快速排序 1.0：时间复杂度为O(N^2)
         *  1、设最后一个数为 num
         *  2、遍历 0 到 arr.length - 2 区域，将比 num 小的数归在左边区域，将比 num 大的数归在右边区域
         *  3、把 num 和右边区域的第一个数字交换，保证 num 放在正中间
         *  4、然后对 num 左边区域和右边区域递归以上过程，直到将每一个数都排好序
         *  5、时间复杂度为O(N^2)（最差情况）
         */

        /* 2、快速排序 2.0：使用荷兰国旗思路，时间复杂度为O(N^2)
         *  1、设最后一个数为 num
         *  2、遍历 0 到 arr.length - 2 区域，将比 num 小的数归在左边区域，将比 num 大的数归在右边区域，把等于 num 的数放在中间
         *  3、把 num 和右边区域的第一个数字交换，保证 num 放在中间
         *  4、然后对 num 左边区域和右边区域递归以上过程，直到将每一个数都排好序
         *  5、时间复杂度为O(N^2)（最差情况）
         */

        /* 3、快速排序 3.0：
         *  1、快排 1.0 和 2.0 时间复杂度差的原因是 num 的取值太偏，如果 num 所取的值是恰好是最大值或最小值，那么时间复杂度为 O(N^2)
         *      ----如果 num 取到最大的值，那么每一个数都是比它小，划分出来的左边区域是 arr.Length - 1,右边区域是只有它自己，然后多左右区域再进行如上操作，如果取到的 num 是左边区域最大值，那么划分出来的区域又是最差的情况
         *  2、如果 num 值取得恰好，恰好取值是中间值，那么它的时间复杂度为 T(N) = 2 * T(N/2) + O(N)
         *  3、快排 3.0 思路：
         *      1、随机选取一个数，该数的好坏是一个随机事件（因为好坏是等概率事件，根据数学一桶计算可算出平均事件复杂度为 N*logN）
         *      2、将随机选取的数与最后一个数进行交换
         *      3、进行快排 2.0 操作
         */

        public static void QuickSort(int[] arr)
        {
            if (arr == null || arr.Length < 2)
                return;

            QuickSort(arr, 0, arr.Length - 1);
        }

        public static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)//下标合法
            {
                Random random = new Random();
                QuickSortSwap(arr, left + random.Next(right - left + 1), right);//将最后一个数和随机选中的数交换
                int[] partition = Partition(arr, left, right);
                QuickSort(arr, left, partition[0] - 1);//对小于区再做 Patition 分割
                QuickSort(arr, partition[1] + 1, right);//对大于区再做 Patition 分割
            }
        }

        /* 返回值 int[] 长度一定为二
         * 其中第一个数据保存的是 等于区域 的第一个元素下标
         * 第二个数据保存的是 等于区域 的最后一个元素的下标，依次来定位 小于区域 和 大于区域 的界限
         */
        public static int[] Partition(int[] arr, int left, int right)
        {
            int less = left - 1;//小于区域的下标位置
            int more = right;//大于区域的下标位置(不用加1，因为最后一个数是 num）
            while (left < more)//界限合法
            {
                if (arr[left] < arr[right])
                {
                    QuickSortSwap(arr, ++less, left++);
                }
                else if (arr[left] > arr[right])
                {
                    QuickSortSwap(arr, --more, left);
                }
                else
                {
                    left++;
                }
            }
            QuickSortSwap(arr, more, right);
            return new int[] { less + 1, more };
        }

        public static void QuickSortSwap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
