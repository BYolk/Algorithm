 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.Sort
{
    internal class SelectionSortClass
    {

        /// <summary>
        /// 1、选择排序：时间复杂度为——N的平方
        /// 将第一个下标位置当作最小的元素的下标位置，遍历每一个元素
        /// 将该元素与之后的每一个元素都进行判断，如果后面的元素值比当前元素值小，交换两个位置的值
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectionSort(int[] arr)
        {
            if (arr == null || arr.Length < 2)//数组为空或数组数量小于2，不用排序
                return;

            for (int i = 0; i < arr.Length - 1; i++)//i 会和 i+1 进行比较，所以只需要遍历到 arr.Length - 1
            {
                int minIndex = i;//从下标为 0 开始
                for (int j = i + 1; j < arr.Length; j++)
                    minIndex = arr[j] < arr[minIndex] ? j : minIndex;
                Swap(arr, i, minIndex);
            }
        }

        public static void Swap(int[] arr, int index, int minIndex)
        {
            int temp = arr[index];
            arr[index] = arr[minIndex];
            arr[minIndex] = temp;
        }

    }
}
