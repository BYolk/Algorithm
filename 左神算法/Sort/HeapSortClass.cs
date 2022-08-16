using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.Sort
{
    /// <summary>
    /// 堆排序
    /// </summary>
    internal class HeapSortClass
    {
        /*1、堆结构：时间复杂度为 N * logN,额外空间复杂度为 O(1)
         * 1、堆结构就是完全用数组实现的完全二叉树结构
         * 2、完全二叉树中如果每棵子树最大值都在顶部就是大根堆
         * 3、完全二叉树中如果每棵子树最小值都在顶部就是小根堆
         * 4、堆结构的 heapInsert 与 heapify 操作（往上操作和往下操作）
         * 5、堆结构的增大和减少
         * 6、优先级队列结构就是堆结构（优先级队列不是队列，是堆） 
         * 
         * 2、堆结构下标关系：
         *  1、根堆中知道某个结点在数组中的下标位置为 i，则它的左子节点、右子节点和父节点在数组中的下标位置为：
         *      1、左子节点：2 * i + 1
         *      2、右子节点：2 * i + 2
         *      3、父节点：(i - 1) / 2
         *      
         * 3、注意：
         *  1、如果用户一个一个数字给我们，当我们把数组中的数排序成大根堆时需要从上往下做 HeapInsert 调整
         *  2、如果用户一次性把所有数字跟我们，那我们认为这个数组已经是个大根堆，然后从大根堆最后一个元素进行 Heapify 向上调整，效果会比 HeapInsert 更好，时间复杂度为O(N)（树的最后一层结点最多，为 N / 2，如果从最后一层做Hepify，那么一半的结点只需要做一个操作，判断用不用做 Hepify）
         *  3、注意，以上的复杂度变小，主要是将数组排序成大根堆的时间复杂度，而不是堆排序的复杂度，堆排序复杂度不变，但是上述做法可以加快“将数组排序成堆”的速度
         *  
         * 4、注意：堆排序的地位远远没有堆结构重要
         *  1、
         */
        /// <summary>
        /// 大根堆排序
        /// </summary>
        /// <param name="arr"></param>
        public static void HeapSort(int[] arr)
        {
            if(arr == null || arr.Length < 2)//边界条件
                return;

            /*for (int i = 0; i < arr.Length; i++)//将数组排序成大根堆的形式
                HeapInsert(arr, i);*/

            //优化上面代码
            for (int i = arr.Length - 1; i >= 0; i--)
                Heapify(arr, i, arr.Length);

            int heapSize = arr.Length;//定义大根堆
            Swap(arr, 0, --heapSize);//交换大根堆头节点和最后一个结点（数组最后一个位置），将最大值放到数组最后面
            while(heapSize > 0)
            {
                Heapify(arr, 0, heapSize);//再重新排序成大根堆
                Swap(arr, 0, --heapSize);//再交换头节点和最后一个位置子节点，将当前大根堆最大值放到当前大根堆最后面
            }
        }

        /// <summary>
        /// 大根堆插入操作，确保插入后还是一个大根堆
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="index"></param>
        public static void HeapInsert(int[] arr,int index)
        {
            //注意，(index - 1) / 2 = -0.5，但因为是整数操作会保持整数型，直接去掉小数部分，得 -0，即 0
            while (arr[index] > arr[(index - 1) / 2])//若自己点大于父节点
            {
                Swap(arr, index, (index - 1) / 2);//交换子父结点
                index = (index - 1) / 2;//交换子父结点下标
            }
        }

        /// <summary>
        /// 某个数在index位置，能否往下移动
        /// heapSize 用于判断根堆是否越界
        /// </summary>
        public static void Heapify(int[] arr, int index, int heapSize)
        {
            int left = index * 2 + 1;//左孩子的下标
            while(left < heapSize)//左孩子还有孩子的时候
            {
                ///判断两个孩子谁大，把下标给 largest
                ///left + 1 是右孩子的下标
                int largest = left + 1 < heapSize && arr[left + 1] > arr[left] ? left + 1 : left;
                //判断父节点和最大的子节点谁大，把下标给 largest
                largest = arr[largest] > arr[index] ? largest : index;

                //代码走到这里，得到 index 下标和两个孩子中那个最大的值，并把那个值的下标赋值给 largest
                if (largest == index)//如果两个孩子都没有比父亲大，不用做操作
                    break;

                Swap(arr, largest, index);//代码走这里说明子孩子比父节点大，交换结点
                index = largest;
                left = index * 2 + 1;
            }
        }

        public static void Swap(int[] arr,int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
