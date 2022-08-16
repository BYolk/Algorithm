#region 技巧

#region 取中点：除以2，可以使用位运算右移 1 位，因为位运算比算术运算快很多
/*
 * 一般做法：(a + b) / 2，可能有问题，如果 a 和 b 都很大，a + b 可能溢出
 * 优化：a + (b - a) / 2,因为 b 大于 a，b不会内存溢出，中点就肯定不会溢出，数值不会超过 b
 * 进一步优化：a + ((b - a) >> 1),将数右移一位，相当于除以2，并且位运算比算术运算速度快很多
 */
#endregion



#endregion

#region 对数器:用来测算法的优劣
/*
 * 编写你的算法A
 * 编写最好想但是复杂度很高的算法B
 * 定义一个随机样本产生器，用来随机产生测试样本
 * 将测试样本在算法A和算法B上都跑一遍，对比结果
 */
#endregion
#region 比较器
/*比较器使用：
 *  1、比较器的实质是重载比较运算符
 *  2、比较器可以很好应用在特殊标准的排序上
 *  3、比较器可以很好应用在根据特殊标准排序的结构上
 */
#endregion


#region 抑或面试真题 --> 为什么要做位运算？————位运算是运算速度最快的，比算数运算快多了
#region 抑或的概念
/*
 * 1、异或运算：
 *  1、二进制对应数字不同为 1，相同为 0
 *  2、或者可以理解为“无进位相加”，比如 “0+0 = 0，0+1 = 1，1 + 1 = 0（二进制中 1+1 = 10，但是无进位，不进位得到 0）
 *  3、异或运算的性质：
 *      1、0 ^ N = N
 *      2、N ^ N = 0
 *      3、异或运算满足交换律和结合律————抑或的结果与抑或的顺序无关
 */

/*
 * 为什么抑或运算满足交换律和结合律？
 *  如果根据相同为 0，不同为 1，很难解释，但使用无进位相加就很容易解释：无论多少个数进行抑或，某一位上的那个数的抑或结果只跟 1 的个数相关，如果在该位置上 1 的个数为偶数个，根据“无进位相加”可知该位置抑或的结果为0，反之为1，即某一位置的抑或运算跟顺序无关，只跟 1 的个数有关
*/
#endregion

#region 抑或第一题（常见面试题）
/*
 * 1、在一个 int 数组内，有种个数出现了奇数次，其余数出现偶数次，怎么找到奇数次的数？
 *  1、要求：时间复杂度 O(N)，空间复杂度 O(1)，即只用有限的空间变量
 *  2、思路：定义 int eor = 0,让 eor 与数组内所有元素进行抑或，最终结果即为奇数次的元素
*/
/*int[] arr = new int[] { 1, 2, 3, 7, 3, 7, 7, 7, 3, 3, 2, 2, 1 };
int eor = 0;
for (int i = 0; i < arr.Length; i++)
{
    eor ^= arr[i];// 0 与 a 抑或为 a，a 与 a 抑或为 0，最后得到的肯定是出现奇数次的
}
Console.WriteLine(eor);*/
#endregion

#region 抑或第二题（常见面试题）
/*
 *2、在一个 int 数组内，有两种数出现了奇数次，其余数出现偶数次，怎么找到奇数次的两个数？
 *  1、要求：时间复杂度 O(N)，空间复杂度 O(1)，即只用有限的空间变量
 *  2、思路：
 *      1、假设出现奇数次的元素是 a，b，定义 int eor = 0,让 eor 与数组内所有元素进行抑或，最终结果即为 a ^ b，又因为是两种数，所以 a 不等于 b，所以 a ^ b 肯定不等于 0，即 eor 肯定不等于 0，所以 eor 在某一位上肯定是不为 0 的，肯定为 1，假设 eor 在第 8 位上位 1，说明 a 和 b 在第 8 位上一定是不一样的，肯定一个为 1，一个为 0.
 *      2、所以我们可以再定义一个 eor2，让它去抑或第 8 位上不是 1 的即第 8 位上为 0 的数组元素，那么，eor2 就能获得到 a 或者 b，因为 a 和 b 中肯定有一个在第八位上为 1，我们是遇不上它的
 *      3、得到 eor2 之后，再让它跟 eor 抑或，如果 eor2 是 a，那么结果就是 eor ^ eor2 = a ^ b ^ a = b
 *      
 *      
 * 
 * 0 与 每一个数都抑或，最后的结果是 a ^ b
 * 又因为 a != b，所以 eor != 0
 * 所以 eor 一定有一个位置上为 1
 * 
 * 解析：int rightOne = eor & (~eor + 1); 
 *  1、把某个不为 0 的数的最右侧的1给提取出来
 *  2、其中 ~eor 表示对 eor 取反，即 0 变为 1，1 变为 0
 *  3、对 ~eor 取反后加 1，即 ~eor + 1
 *  4、然后让 eor 跟 （~eor + 1）做与运算，得到的就是 eor 最右侧为 1 的一个数
 * 
 * 与运算：都为 1 时为 1，其余情况为 0
 * 
 * 示例：
 *  1、  eor = 10001110101 ——>   ~eor = 01110001010
 *  3、~eor+1= 01110001011
 *  4、eor & (~eor + 1)：00000000001
*/

/*int[] arr = new int[] { 1, 2, 3, 7, 3, 7, 7, 7, 3, 3, 2, 2, 1, 1 ,1,8};
int eor = 0;
int onlyOne = 0;
for (int i = 0; i < arr.Length; i++)
    eor ^= arr[i]; 

int rightOne = eor & (~eor + 1);
foreach (int i in arr)
    if((i & rightOne) == 0)//如果这个数和 00000000001 做与运算为0，说明在最后一位上，这个数肯定不为0
        onlyOne ^= i;//只与最后一位上不为 0 的数进行抑或，最终结果为 a 或者 b
Console.WriteLine(onlyOne + " " + (onlyOne ^ eor));*/
#endregion

#endregion

#region 二分法面试题

#region 题目1
/*
 * 无序数组，相邻数一定不相等，求局部最小值。要求：时间复杂度小于 O(N  )
 */


#endregion







#endregion

#region 归并排序面试题



#region 小和问题
/*
 * 1、在一个数组中，每一个数左边比当前数小的数累加起来，叫做这个数数组的小和。
 * 2、求一个数组的小和：
 *  例子：[1,3,4,2,5] 
 *      1、1 左边没有比 1 小的数 (sum = 0)
 *      2、3 左边比 3 小的数为 1 (sum = 0 + 1)
 *      3、4 左边比 4 小的数为 1,3 (sum = 0 + 1 + 1 + 3)
 *      4、2 左边比 2 小的数为 1 (sum = 0 + 1 + 1 + 3 + 1)
 *      5、5 左边比 2 小的数为 1,3,4,2 (sum = 0 + 1 + 1 + 3 + 1 + 1 + 3 + 4 + 2)
 *  3、解法：
 *      1、暴力解法：遍历每一个数，跟它前面的数进行比较，如果小则累加，但效率差，时间复杂度为O(N^2)
 *      2、转换思路：
 *          1、将题目转换为，看第i个数，看后面有多少个数比第i个数大，那么第i个数就要做多少次小和进行累加
 *          2、比如 1，右边四个数都大于 1，那么 1 就要作为后面 4 个数的小和进行累加。再看3，后面有两个数比 3 大，那么 3 就要作为 4 和 5 的小和进行累加，以此类推
 *          3、以这种思路，可以使用归并排序快速排序
 *  4、小和问题与经典归并排序算法的区别在于：
 *      1、当左边区域指针所指位置的值等于右边区域指针所指位置的值时，先拷贝右边的区域，这样，我们才能保证当我们拷贝左边的值时，一下子就知道右边有多少个数比左边这个数大（合并操作时左右两边都已经排好序了）
 */

/*Console.WriteLine(SmallSum(new int[] { 1, 3, 4, 2, 5 }));
static int SmallSum(int[] arr)
{
    if (arr == null || arr.Length < 2)//如果只有一个数，那么这个数没有小和
        return 0;
    return Process(arr, 0, arr.Length - 1);
}

static int Process(int[] arr, int left, int right)
{
    if (left == right)//左右下标相等，表示同一个数
        return 0;
    int mid = left + ((right - left) >> 1);//得出中点，将数组划分为两部分
    return Process(arr, left, mid) + Process(arr, mid + 1, right) + Merge(arr, left, mid, right);//左边排好序后的小和 + 右边排好序后的小和 + 归并产生的小和
}

static int Merge(int[] arr,int left, int mid, int right)
{
    int[] help = new int[right - left + 1];//定义辅助空间
    int helpIndex = 0;//辅助空间下标
    int leftPosition = left;//左边区域最左边位置指针
    int rightPosition = mid + 1;//右边区域最左边指针
    int smallSum = 0;//小和
    while(leftPosition <= mid && rightPosition <= right)//不越界时
    {
        //因为右边已经排好序了，所以如果右边 rightPosition 位置的值大于 leftPosition，那么 rightPosition 之后的值都大于 leftPosition，需要加上 (right - rightPosition + 1) 个 arr[leftPosition] 的值
        smallSum += arr[leftPosition] < arr[rightPosition] ? (right - rightPosition + 1) * arr[leftPosition] : 0;

        //如果左边值小，将左边放入辅助空间，左边区域指针自增 1，反之对右边元素进行同理操作，注意，这里如果左边的数和右边的数相等，要拷贝右边的数，才能保证在左边小于右边的数时，拷贝左边的数的同时可以一次性知道右边有多少个数比左边的大，应该产生多少个小和
        help[helpIndex++] = arr[leftPosition] < arr[rightPosition] ? arr[leftPosition++] : arr[rightPosition++];
    }

    //代码走这里说明左边或者右边有一个越界了
    while(leftPosition <= mid)
    {
        help[helpIndex++] = arr[leftPosition++];
    }
    while(rightPosition <= right)
    {
        help[helpIndex++] = arr[rightPosition++];
    }

    for(helpIndex = 0; helpIndex < help.Length; helpIndex++)
        arr[left + helpIndex] = help[helpIndex];//从 left 位置开始操作，left 不一定为0

    return smallSum;
}*/

#endregion



#region 逆序对问题
/*
 * 逆序对问题：
 *  在一个数组中，左边的数如果比右边的大，那么这两个数构成一个逆序对
 *  打印一个数组的逆序对：
 *  
 *  与小和问题等效，只要判断左边比右边大的数有多少个即可
 */
#endregion







#endregion

#region 快速排序







#region 荷兰国旗问题 1：
/*
 * 给定数组 arr 和数 num，把小于等于 num 的数放在数组左边，大于 num 的数放在数组右边，要求空间复杂度 O(1)，时间复杂度 O(N)
 *  1、解题思路：
 *      1、定义 i 为 0，从 0 依次往后遍历
 *      2、定义 小于等于 5 的一个区域
 *      3、当 arr[i] ≤ 5 时，将 arr[i] 与小于等于 5 的区域的下一个位置的数字交换，然后小于等于 5 的区域往右扩 1，i++
 *      4、如果 arr[i] ＞ 5，直接 i++
 *      5、遍历完 arr 数组，完成所需
 */

#endregion





#region 荷兰国旗问题 2：
/*
 * 给定数组 arr 和数 num，把小于 num 的数放在数组左边，等于 num 的数放在中间，大于 num 的数放在数组右边，要求空间复杂度 O(1)，时间复杂度 O(N)
 *  1、解题思路：
 *      1、定义 i 为 0，从 0 依次往后遍历
 *      2、在左边定义小于 5 的一个区域和在右边定义大于 5 的一个区域
 *      3、当 arr[i] < 5 时，将 arr[i] 与小于 5 的区域的下一个位置的数字交换，然后小于 5 的区域往右扩 1，i++
 *      4、当 arr[i] > 5 时，将 arr[i] 与大于 5 的区域的上一个位置的数字交换，然后大于 5 的区域往左扩 1，i不变
 *      5、如果 arr[i] = 5，直接 i++
 *      6、当大于区域 和 i 相等时，停止遍历，完成划分
 * 
 */

#endregion


#endregion

#region 堆——手写堆很重要，很多需求必须自己手写堆结构

#region 
/*题目一：
 * 已知一个几乎有序的数组，几乎有序指如果把数组排好顺序，每个元素移动距离可以不超过 k，并且 k 相对于数组来说较小
 * 请选择一个合适的排序算法针对这个数据进行排序
 *  解题思路：从 0 到 k 位置做小根堆排序，然后将最小值弹出，放到第一个位置，然后从 1 到 k + 1 位置做小根堆排序，依次循环反复
 */
#endregion

/* //C# 中优先队列用法
 * PriorityQueue<string,int> pq = new PriorityQueue<string,int>();//第一个表示元素，第二个表示优先级
for(int i = 0; i < 20; i++)
{
    int num = new Random().Next(0, 100);
    pq.Enqueue(num.ToString(), num);
}
for(int i = 0; i < pq.Count; i++)
{
    Console.WriteLine(pq.Dequeue());
}*/

/*int[] arr = new int[] { 5, 3, 2, 6, 8, 3, 7, 3,1,1 };
Sort(arr, 9);
foreach (int i in arr)
    Console.WriteLine(i);
static void Sort(int[] arr, int k)
{
    PriorityQueue<int, int> heap = new PriorityQueue<int, int>();
    int index = 0;
    for (; index <= Math.Min(Array.MaxLength, k); index++)
        heap.Enqueue(arr[index], arr[index]);

    int i = 0;
    for(; index < arr.Length; i++, index++)
    {
        heap.Enqueue(arr[index], arr[index]);
        arr[i] = heap.Dequeue();
    }

    while(heap.Count != 0)
    {
        arr[i++] = heap.Dequeue();
    }
}*/


#endregion

#region 单链表面试题
/*判断一个单链表是否为回文结构
 * 题目：给定单链表头节点 head，判断是否为回文结构，如 1->2->2->1,就是一个回文结构
 * 要求：若链表长度为 N，时间复杂度 O(N),额外空间复杂度 O(1)
 */
//需要额外 n 空间：
/*static bool IsPalindrome1(ListNode<int> head)
{
    Stack<ListNode<int>> stack = new Stack<ListNode<int>>();
    ListNode<int> current = head;
    while(current != null)//将链表元素全部入栈
    {
        stack.Push(current);
        current = current.next;
    }
    while(head != null)//将栈内元素逐个出栈，并出栈的值和链表的值进行对比不一样，说明不是回文
    {
        if (head.t != stack.Pop().t)
            return false;
        head = head.next;
    }
    return true;
}*/



/*// need n/2 extra space
public static boolean isPalindrome2(Node head)
{
    if (head == null || head.next == null)
    {
        return true;
    }
    Node right = head.next;
    Node cur = head;
    while (cur.next != null && cur.next.next != null)
    {
        right = right.next;
        cur = cur.next.next;
    }
    Stack<Node> stack = new Stack<Node>();
    while (right != null)
    {
        stack.push(right);
        right = right.next;
    }
    while (!stack.isEmpty())
    {
        if (head.value != stack.pop().value)
        {
            return false;
        }
        head = head.next;
    }
    return true;
}*/

/*// need O(1) extra space
public static boolean isPalindrome3(Node head)
{
    if (head == null || head.next == null)
    {
        return true;
    }
    Node n1 = head;
    Node n2 = head;
    while (n2.next != null && n2.next.next != null)
    { // find mid node
        n1 = n1.next; // n1 -> mid
        n2 = n2.next.next; // n2 -> end
    }
    n2 = n1.next; // n2 -> right part first node
    n1.next = null; // mid.next -> null
    Node n3 = null;
    while (n2 != null)
    { // right part convert
        n3 = n2.next; // n3 -> save next node
        n2.next = n1; // next of right node convert
        n1 = n2; // n1 move
        n2 = n3; // n2 move
    }
    n3 = n1; // n3 -> save last node
    n2 = head;// n2 -> left first node
    boolean res = true;
    while (n1 != null && n2 != null)
    { // check palindrome
        if (n1.value != n2.value)
        {
            res = false;
            break;
        }
        n1 = n1.next; // left to mid
        n2 = n2.next; // right to mid
    }
    n1 = n3.next;
    n3.next = null;
    while (n1 != null)
    { // recover list
        n2 = n1.next;
        n1.next = n3;
        n3 = n1;
        n1 = n2;
    }
    return res;
}

public static void printLinkedList(Node node)
{
    System.out.print("Linked List: ");
    while (node != null)
    {
        System.out.print(node.value + " ");
        node = node.next;
    }
    System.out.println();
}*/


/*class ListNode<T>
{
    public T t;
    public ListNode<T> next;
    public ListNode(T t,ListNode<T> next)
    {
        this.t = t;
        this.next = next;
    }
}*/
/*将单链表按某值划分成左边小、中间相等、右边大的形式
 * 题目：给定一个单链表的头节点head，节点的值类型是整型，再给定一个整数pivot。实现一个调整链表的函数，将链表调整为左部分都是值小于pivot的节点，中间部分都是值等于pivot的节点，右部分都是值大于pivot的节点。
    
    【进阶】在实现原问题功能的基础上增加如下的要求
    【要求】调整后所有小于pivot的节点之间的相对顺序和调整前一样
    【要求】调整后所有等于pivot的节点之间的相对顺序和调整前一样
    【要求】调整后所有大于pivot的节点之间的相对顺序和调整前一样
    【要求】时间复杂度请达到O(N)，额外空间复杂度请达到O(1)。
 */

#endregion















#region 

#endregion





/*//如果传入的是空字符串，应当返回 0——可作为面试题
 * string a = "dfad";
int i = a.IndexOf("");
Console.WriteLine(i);*/

StrStr("Hello", "ll");
int StrStr(string haystack, string needle)
{
    if (haystack == null)
        return -1;
    if (needle == null)//如果 needle 为 null， 应当返回 0，这与 java 中的 indexOf 相符
        return 0;

    //将 haystack 值放入栈
    Stack<char> stack = new Stack<char>();
    foreach (char c in haystack)
    {
        stack.Push(c);
    }

    int index = 0;
    while (stack.Count != 0)
    {
        //判断 index 是否已经到达 neelde 长度 -1，若到达表示当前字符串全部匹配成功
        if (index == needle.Length - 1)
        {
            if (needle[index] == stack.Pop())
            {
                return stack.Count;
            }
            else
                index = 0;
        }
        else
            index++;
    }
    return -1;
}