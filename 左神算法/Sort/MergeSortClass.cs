using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.Sort
{
    internal class MergeSortClass
    {
        /* 归并排序： ———— 时间复杂度为：NlogN，比以上三种都要好
         *  1、整体就是一个简单的排序，左边排好序、右边排好序，让其整体有序
         *  2、让其整体有序的过程里用了外排序的方法
         *  3、利用 master 公式求解时间复杂度：
         *      1、master 公式 T(N) = a * T(N/b) + O(N^d)
         *      2、其中 a = 2，b = 2，d = 1
         *      3、即 loa(b,a) = d,时间复杂度为 O(N * logN)
         *  4、归并排序的实质
         *  5、时间复杂度：O(N * logN),空间复杂度O(N)
         *      1、时间复杂度比 O(N^2）小
         *  6、归并排序比起选择排序、冒泡排序、插入排序好在哪？
         *      1、选择排序、冒泡排序、插入排序浪费了大量的比较行为
         *      2、归并排序是在 “归并” 两个有序的序列，得到一个有序的大序列，然后再跟另外一个有序的大序列 “归并”，最终 “归并” 得到一个完整的有序序列，不会浪费大量比较行为
         */
        public static void MergeSort(int[] arr)
        {
            if (arr == null || arr.Length < 2)
                return;
            MergeSortProcess(arr, 0, arr.Length - 1);
        }

        public static void MergeSortProcess(int[] arr, int left, int right)
        {
            if (left == right)
                return;

            int mid = left + (right - left >> 1);
            MergeSortProcess(arr, left, mid);
            MergeSortProcess(arr, mid + 1, right);
            MergeSortMerge(arr, left, mid, right);
        }

        public static void MergeSortMerge(int[] arr, int left, int mid, int right)
        {
            int[] help = new int[right - left + 1];//辅助空间
            int helpIndex = 0;
            int positionLeft = left;//左边的位置指针：定义一个下标指向左边排好序的最左边的位置 left
            int positionRight = mid + 1;//右边的位置指针：定义一个下标指向右边排好序的最左边的位置 mid + 1
            while (positionLeft <= mid && positionRight <= right)//当 p1 和 p2 没有越界时
            {
                help[helpIndex++] = arr[positionLeft] <= arr[positionRight] ? arr[positionLeft++] : arr[positionRight++];//比较左右区域的第 i 个位置的值，将小的那个放入辅助空间，然后，对已经放入的 左/右 区域的位置指针加 1
            }

            //代码走这里说明有一个越界了，即 左边/右边 其中一个已经没有元素了，此时再把剩下的另一个区域里面的值全部放入辅助空间
            while (positionLeft <= mid)
            {
                help[helpIndex++] = arr[positionLeft++];
            }
            while (positionRight <= right)
            {
                help[helpIndex++] = arr[positionRight++];
            }

            //把辅助空间的值再放回原数组
            for (helpIndex = 0; helpIndex < help.Length; helpIndex++)
            {
                arr[left + helpIndex] = help[helpIndex];
            }
        }
    }
}
