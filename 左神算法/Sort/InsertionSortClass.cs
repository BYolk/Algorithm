using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.Sort
{
    internal class InsertionSortClass
    {
        #region 插入排序————时间复杂度为：N的平方，但平均复杂度比选择和冒泡小
        public static void InsertionSort(int[] arr)
        {
            if (arr == null || arr.Length < 2)
                return;

            for (int i = 1; i < arr.Length; i++)
                for (int j = i - 1; j >= 0 && arr[j] > arr[j + 1]; j--)
                    Swap(arr, j, j + 1);
        }

        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        #endregion
    }
}
