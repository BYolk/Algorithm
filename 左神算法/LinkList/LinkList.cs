using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.LinkList
{
    //链表相关算法
    internal class LinkList
    {
        /*链表：
         *  1、单链表：Class Node<V>{V value; Node next}
         *  2、双链表：Class Node<V>{V value; Node next; Node last}
         *  3、单链表和双链表只需要给定头节点 head，就可以找到剩下的所有结点
         *  
         *  4、面试时链表解题的方法论：
         *      1、对于笔试，不用太在乎空间复杂度，一切为了时间复杂度
         *      2、对于面试，时间复杂度依然放在第一位，但是一定要找到空间最省的方法
         *      3、重要技巧：
         *          1、额外数据结构记录（哈希表等）
         *          2、快慢指针：定义两个指针，一个快一个慢，慢指针一次只走 1，快指针一次走 2，当快指针走完的时候，慢指针刚好走了一半
         */

        #region 反转链表
        //
        // 新建两个结点指针 next 和 pre，pre指向上一个结点，next指向下一个结点
        //  1、第一次循环：
        //      1、next 结点指向 head 结点的下一个结点
        //          ————当头部不为空时，将 head 的下一个结点地址赋值给新建的 next 结点
        //      2、断开 head 结点所指向的下一个结点之间的链接
        //          ————然后将 新建的空结点 pre 的地址赋值给 head 的 Next 属性，那么 
        //      3、再将 pre 结点指向当前 head 所指向的结点（头节点）
        //          ————再将 head 的地址赋值给 pre 结点
        //      4、将 head 指向下一个结点
        //
        //  2、来到此处，pre 指向链表第一个结点，第一个结点的 next 结点为空，head 和 next 都指向第二个结点，此时头节点与链表断开，第二个结点称为新链表的头节点
        //  
        //  3、开始第二轮相同操作
        //      1、next 结点指向 head 结点的下一个结点
        //          ————当头部不为空时，将 head 的下一个结点地址赋值给新建的 next 结点
        //      2、让第二个结点指向第一个结点（反向）
        //          ————让 head 所指向的结点（第二个结点）指向 pre 所指向的结点（第一个结点）
        //      3、再将 pre 结点指向当前 head 所指向的结点（头节点）
        //          ————将 head 的地址赋值给 pre 结点
        //      4、将 head 指向下一个结点
        //
        //  4、依次反复，实现链表的反转
        //
        //  5、总结思路：
        //      1、先定义两个自定义的指针 next 和 pre 分别指向当前操作的下一个结点和上一个结点
        //      2、先用自定义的 next 指针标记当前操作结点 head 的下一个结点
        //      3、再把当前结点的 Next 指针指向上一个结点（头结点的时候上一个结点为空）
        //      4、再把当前结点的 Pre 指针指向下一个结点（第一步中 next 提前标记下一个结点的原因）
        //      5、将当前结点的 Next 指针和 Pre 指针都更换完成以后，当前结点就变成了上一个结点，当前结点的下一个结点就变成了“当前结点”————让pre 指向 当前结点，然后让 head 指向下一个结点
        public static SinglyLinkedNode<T> ReverseList<T>(SinglyLinkedNode<T> head)
        {
            SinglyLinkedNode<T> pre = new();
            SinglyLinkedNode<T> next;
            while(head != null)
            {
                next = head.Next;
                head.Next = pre;
                pre = head;
                head = next;
                //上面两行代码，在进行最后一个结点转换的时候，pre 会指向 最后一个结点，head 会指向空，因为最后一个结点的下一个结点 head.Next 为空
            }
            //代码走到这里反转完成
            return pre;
        }
        public static DoublyLinkedNode<T> ReverseList<T>(DoublyLinkedNode<T> head)
        {
            DoublyLinkedNode<T> pre = new();
            DoublyLinkedNode<T> next;
            while (head != null)
            {
                next = head.Next;
                head.Next = pre;
                head.Prev = next;
                pre = head;
                head = next;
                //上面两行代码，在进行最后一个结点转换的时候，pre 会指向 最后一个结点，head 会指向空，因为最后一个结点的下一个结点 head.Next 为空  
            }
            //代码走到这里反转完成
            return pre;
        }

        #endregion

        #region 打印单链表
        //
        // 打印单链表结点
        public static void PrintLinkedNode<T>(SinglyLinkedNode<T> head)
        {
            Console.WriteLine("打印单链表：");
            while (head != null)
            {
                Console.WriteLine(head.Value);
                head = head.Next;
            }
        }

        //
        // 打印双链表结点
        public static void PrintLinkedNode<T>(DoublyLinkedNode<T> head)
        {
            DoublyLinkedNode<T> end = null;
            Console.WriteLine("从左往右打印双链表");
            while (head != null)
            {
                
                Console.WriteLine(head.Value);
                end = head;//用 end 记录当前已经打印的结点，跟这 head 走
                head = head.Next;
            }
            Console.WriteLine("从右往左打印双链表");
            while(end != null)
            {
                Console.WriteLine(end.Value);
                end = end.Prev;
            }
        }
        #endregion

        #region 打印两个升序链表的公共部分（相同位置下值相等的部分）
        public static void PrintCommonPart(SinglyLinkedNode<int> head1, SinglyLinkedNode<int> head2)
        {
            Console.WriteLine("打印两个链表的公共部分");
            while(head1 != null && head2 != null)
            {
                if (head1.Value < head2.Value)
                    head1 = head1.Next;
                else if (head1.Value > head2.Value)
                    head2 = head2.Next;
                else
                {
                    Console.WriteLine(head1.Value);
                    head1 = head1.Next;
                    head2 = head2.Next;
                }
            }
            //代码走这里说明有一个链表为空了，打印结束
        }
        #endregion

        #region 判断链表是否回文（注意 1 20 4 5 4 20 1 也算回文，20是一个整体，不能拆成02）

        //
        // 空间复杂度为 O(n)，n 为结点个数
        public static bool NormalPalindrome(SinglyLinkedNode<int> head)
        {
            if (head == null) return false;
            if (head.Next == null) return true;

            Stack<SinglyLinkedNode<int>> stack = new Stack<SinglyLinkedNode<int>>();
            SinglyLinkedNode<int> curNode = head;
            while(curNode != null)//使用 curNode 指针将链表的值压入栈
            {
                stack.Push(curNode);
                curNode = curNode.Next;
            }
            while(head != null)//使用 head 指针判断链表的值和栈内的值是否相等
            {
                if (head.Value != stack.Pop().Value)//head 从表头开始，弹出的结点是从表尾开始弹出
                    return false;
                head = head.Next;
            }
            return true;
        }

        //
        // 空间复杂度为 O(n / 2)，n 为结点个数
        // 思路：快慢指针————定义两个指针，快指针一步走两个单位，慢指针一步走一个单位，当快指针到终点时，慢指针恰好到达中点
        public static bool BetterPalidrome(SinglyLinkedNode<int> head)
        {
            if(head == null) return false;
            if (head.Next == null) return true;

            SinglyLinkedNode<int> slow = head.Next;
            SinglyLinkedNode<int> fast = head;
            while(fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            Stack<SinglyLinkedNode<int>> stack = new();
            while(slow != null)
            {
                stack.Push(slow);
                slow = slow.Next;
            }
            while(stack.Count > 0)
            {
                if (head.Value != stack.Pop().Value)
                    return false;
                head = head.Next;
            }
            return true;
        }

        //
        // 空间复杂度为 O(1)
        // 解题思路：
        // 1、先使用快慢指针，让慢指针定位到中点位置
        // 2、再让快指针定位到中点位置的下一位置，即慢指针下一位置（回文右边部分的起点，应该对应左边部分的终点）
        // 3、将慢指针置所在结点的 Next 属性断开，即从中点处和右边的回文部分断开（注意，在此处中间节点指向null，链表被分成两个链表，一个慢指针在作为头结点的左边链表和一个快指针左右头结点的右边链表，将右边链表反转过来，让中间节点作为左边和右边链表的公共尾结点，中间结点指向空）
        // 4、新建一个空指针 n（做中间变量）
        // 5、只要快指针不为空，做一下循环：
        //      1、将指针 n 指向快指针的下一个指针
        //      2、再让快指针所指节点的下一指针指向慢指针所指结点
        //      3、然后让慢指针指向快指针所指结点
        //      4、最后把快指针指向 n 指针
        //  6、做完以上循环，中间节点的下一个结点会反转过来（右部分反转，指向中间节点），此时慢指针指向最后一个几点，快指针在最后一个结点 next 所指位置，即 null
        //  7、用 n 来保存最后一个结点的位置，再把快指针指回头结点（慢指针 和 n 在右边部分的头结点）
        //  8、定义一个布尔变量 res 用来记录回文对比结果
        //  9、只要 快慢指针 都不为空，做以下循环
        //      1、只要快慢指针的值不相等，就让 res 为 false ，跳出循环，表示不是回文
        //      2、否则让 快慢指针 顺着链表走（快指针在左边部分往右边走，慢指针在右边部分往左边走）
        //      3、因为中间节点指向 null，所以只要 快慢指针都为 null，说明快慢指针所指的值都匹配，res 保持为 true
        //  10、判断完链表之后，将右部分的链表还原：
        //      1、让 慢指针 指向 n 指针的下一个结点（倒数第二个结点，也是右边部分头结点的下一个结点）
        //      2、再让 n 的 next 指针置为空（断开最后一个结点和倒数第二个结点的链接，让最后一个结点指向空
        //      3、只要慢指针不为空，做以下循环
        //          1、让 快指针 指向慢指针的下一结点（让快指针走在慢指针的前面，方向是中间节点方向）
        //          2、让 慢指针 所指的结点指向 n 指针所指结点，即让倒数第二个结点指向最后一个结点，即让左边结点指向右边结点
        //          3、再让 n 指针指向 慢指针 所指结点（n指针左移）
        //          4、再让 慢指针 指向 快指针 所指结点 （慢指针左移）
        public static bool BestPalidrome(SinglyLinkedNode<int> head)
        {
            if(head == null) return false;
            if(head.Next == null) return true;

            SinglyLinkedNode<int> slow = head;
            SinglyLinkedNode<int> fast = head;

            //slow走一步,fast走两步,fast到终点时,slow到中点
            while (fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            //慢指针到达中点，让快指针指向中点的下一个结点，并让中间结点指向空
            fast = slow.Next;
            slow.Next = null;

            //新建一个结点指针，作为中间变量，用于反转右边链表
            SinglyLinkedNode<int> n = new();
            while(fast != null)
            {
                n = fast.Next;
                fast.Next = slow;
                slow = fast;
                fast = n;
            }

            ///
            ///  将右边链表反转完后，slow 指向右边链表的头结点（原链表的尾结点），让 n 也指向右边链表的头结点（原链表的尾结点）保持不变（做还原操作要用到），快指针指向左边链表（原链表）的头结点
            ///  此时快指针在最左，慢指针在最右，同时向中间移动，判断对应值是否相等
            n = slow;
            fast = head;
            bool res = true;//默认表示链表是回文
            while(slow != null && fast != null)
            {
                if(slow.Value != fast.Value)
                {
                    res = false;
                    break;
                }
                slow = slow.Next;
                fast = fast.Next;
            }

            //代码走这里已经得到结果了，结果就保存在 res 中，但是在返回 res 之前要把链表还原
            slow = n.Next;
            n.Next = null;
            while(slow != null)
            {
                fast = slow.Next;
                slow.Next = n;
                n = slow;
                slow = fast;
            }

            //代码走到这里已经恢复完毕，返回结果
            return res;
        }
        #endregion

        #region 给定一个数 pivot，调整链表为左边小于、中间相等、右边大于 pivot 的形式
        /// 
        /// 进阶：
        ///     1、调整后所有小于 pivot 的结点之间的相对顺序和调整前一样
        ///     2、调整后所有等于 pivot 的结点之间的相对顺序和调整前一样
        ///     3、调整后所有大于 pivot 的结点之间的相对顺序和调整前一样
        ///     4、时间复杂度 O(N)，额外空间复杂度 O(1)
        ///     

        //
        // 1、给定一个数 pivot，调整链表为左边小于、中间相等、右边大于 pivot 的形式
        // 2、笔试解题思路：将链表的每一个结点都放到数组里面，然后对数组左 partition 操作，最后再把数组内的结点元素链接成链表
        public static SinglyLinkedNode<int> NormalListPartition(SinglyLinkedNode<int> head, int pivot)
        {
            if (head == null) return head;

            //将链表保存到数组中（需要先计算处链表的长度）
            SinglyLinkedNode<int> cur = head;
            int i = 0;
            while(cur != null)
            {
                i++;
                cur = cur.Next;
            }

            //代码走到这里，i 里面保存着链表的元素个数,创建相同大小的数组
            SinglyLinkedNode<int>[] nodeArr = new SinglyLinkedNode<int>[i];

            //将链表内的元素放入数组中
            cur = head;
            i = 0;
            for(i = 0; i != nodeArr.Length; i++)
            {
                nodeArr[i] = cur;
                cur = cur.Next;
            }

            //代码走到这里，链表中的结点就全部存放到数组中了，现在对数组做 partition 操作
            ArrPartition(nodeArr, pivot);


            ///代码走到这里，数组中已经根据 小于等于大于 pivot 的顺序从左往右排好，现在要把他们创成链表
            ///注意这里说的顺序是小于 pivot 的放左边就行，小于 pivot 的值是不用进行排序的，在进阶部分要对其排序

            ///注意，以上处理过程只是按照值将他们排序到数组中，但是他们的链接情况并没有发生任何改变
            ///
            for (i = 1; i != nodeArr.Length; i++)
                nodeArr[i - 1].Next = nodeArr[i];//让数组中上一个元素结点的 next 指向下一个元素即可

            
            //代码走到这里，数组中最后一个元素的 next 还没有设置（它可能是尾结点，也可能不是尾结点，要将其next 置为 null）
            nodeArr[i - 1].Next = null;
            return nodeArr[0];//返回头结点即可
        }

        //
        // 对数组中的链表结点做 partition 操作
        // 思路：
        //  1、定义小于 pivot 的下标边界，从数组最左边 -1 开始
        //  2、定义大于 pivot 的下标边界，从数组最右边 nodeArr.Length 开始
        public static void ArrPartition(SinglyLinkedNode<int>[] nodeArr,int pivot)
        {
            //定义小于和大于 pivot 的边界
            int lessBoundary = -1;
            int greaterBoundary = nodeArr.Length;

            //遍历数组，只要 index 没跟 大于边界 相遇，就一直循环遍历
            int index = 0;
            while(index != greaterBoundary)
            {
                if (nodeArr[index].Value < pivot)
                    Swap(nodeArr, ++lessBoundary, index++);//交换时边界先自增，然后边界所在位置的元素和 index 所在元素交换，index 再 自增
                else if (nodeArr[index].Value == pivot)
                    index++;//如果所在结点等于 pivot，不做任何操作，让 index 子增即可
                else
                    Swap(nodeArr, --greaterBoundary, index);//和右边的大于区域做交换后，index 不能自增，因为从右边交换过来的元素还没有检查
            }

            //代码走到这里，循环结束，数组中的链表结点已经按照值 小于等于和大于 pivot 的顺序从左往右排序
        }

        //
        // 交换链表数组中的两个元素（交换的是结点，不是节点的值）
        public static void Swap(SinglyLinkedNode<int>[] nodeArr,int i,int j)
        {
            SinglyLinkedNode<int> temp = nodeArr[i];
            nodeArr[i] = nodeArr[j];
            nodeArr[j] = temp;
        }


        //
        // 1、给定一个数 pivot，调整链表为左边小于、中间相等、右边大于 pivot 的形式
        // 2、面试解题思路：准备六个变量，分别是用于存放小于 pivot 的结点的头指针和尾指针、等于 pivot 的结点的头指针和尾指针、大于 pivot 的结点的头指针和尾指针、最后把小于的尾指针连向等于的头指针，等于的尾指针连向大于的头指针即可。但是要注意一点：一定要讨论清楚指针为空的情况
        public static SinglyLinkedNode<int> BetterListPartition(SinglyLinkedNode<int> head, int pivot)
        {
            //准备好结点指针
            SinglyLinkedNode<int> lessHead = null;//小于链表头指针：指向值小于 pivot 的链表的头结点
            SinglyLinkedNode<int> lessTail = null;//小于链表尾指针：指向值小于 pivot 的链表的尾结点
            SinglyLinkedNode<int> equalHead = null;//等于链表头指针：指向值等于 pivot 的链表的头结点
            SinglyLinkedNode<int> equalTail = null;//等于链表尾指针：指向值等于 pivot 的链表的尾结点
            SinglyLinkedNode<int> greaterHead = null;//大于链表头指针：指向值大于 pivot 的链表的头结点
            SinglyLinkedNode<int> greaterTail = null;//大于链表尾指针：指向值大于 pivot 的链表的尾结点
            SinglyLinkedNode<int> next = null;//用于记录下一个结点的指针，因为头结点的指针会从原链表中断开链接到上述结点中

            //循环遍历每一个链表结点，根据于 pivot 的大小情况将每一个结点链接到对应的上述结点中
            while(head != null)
            {
                next = head.Next;
                head.Next = null;//断开头结点，判断与 pivot 的大小，将其链接到对应的上述指针中

                if (head.Value < pivot)
                {
                    if(lessHead == null)//如果小于链表的头指针为空，尾指针也必定为空
                    {
                        lessHead = head;
                        lessTail = head;
                    }
                    else//如果小于链表头指针不为空，尾指针也肯定不为空，将结点链接到尾结点，更该尾结点的指针
                    {
                        lessTail.Next = head;//链接到尾结点后面
                        lessTail = head;//移动尾指针
                    }
                }
                else if(head.Value == pivot)//同理操作
                {
                    if(equalHead == null)
                    {
                        equalHead = head;
                        equalTail = head;
                    }
                    else
                    {
                        equalTail.Next = head;
                        equalTail = head;
                    }
                }
                else//对大于链表也做同样的操作
                {
                    if(greaterHead == null)
                    {
                        greaterHead = head;
                        greaterTail = head;
                    }
                    else
                    {
                        greaterTail.Next = head;
                        greaterTail = head;
                    }
                }

                head = next;//移动原链表的头指针
            }

            ///代码走到这里，原链表的结点就分别被链接到表示 小于等于大于 pivot 的三个链表中了
            ///接下来要做的就是要把三个链表链接到一起整合成一个链表
            ///但是链接之前需要判断头尾指针是否为空，否则会发生空指针异常等错误
            if(lessTail != null)//如果小于链表的尾结点不为空，链接小于链表与等于链表
            {
                ///解释代码：
                ///lessTail.Next = equalHead; 如果头结点为空，也不会造成影响
                ///equalTail = equalTail == null ? lessTail : equalTail; ——————>判断 等于链表 的尾结点是否为空，为空则 等于 链表的头结点也肯定为空，此时将 小于链表的尾指针作为等于链表的尾指针即可，此时小于链表和等于链表的尾指针都指向小于链表的尾结点。
                lessTail.Next = equalHead;
                equalTail = equalTail == null ? lessTail : equalTail;
            }

            //代码走到这里，小于链表和等于链表已经链接完毕，接着链接大于链表即可
            if(equalTail != null)//如果等于链表的尾指针为空，说明小于链表也为空，只有大于链表
            {
                equalTail.Next = greaterHead;
            }

            //代码走到这里，链表已经链接完毕
            
            ///解释代码：
            /// 如果小于链表头指针不为空，返回，如果为空，判断等于链表的头指针是否为空，不为空返回，为空返回大于链表的头指针
            return lessHead != null ? lessHead : equalHead != null ? equalHead : greaterHead;
        }
        #endregion

        #region 赋值含有随机指针结点的链表
        /// 题目：
        /// 一种特殊的单链表结点描述如下
        /// class Node{
        ///     int value;
        ///     Node next;
        ///     node random;
        ///     Node(int val){
        ///         value = val;
        ///     }
        /// }
        /// random 指针是单链表结点结构中新增的指针，rand可能指向链表中的任意一个结点，也可能指向 null，给定一个由 node 结点类型组成的无环单链表的头结点 head，请实现一个函数完成这个链表的赋值，并返回复制的新链表头结点
        /// 要求：时间复杂度O(N),额外空间复杂度O(1)
        /// 

        public class Node
        {
            public int value;
            public Node next;
            public Node random;
            public Node(int data)
            {
                this.value = data;
            }
        }

        //
        // 1、如果使用额外空间，会非常简单，使用哈希表即可
        // 2、思路：
        //  1、创建一个哈希表，用于存放单链表和拷贝出来的单链表
        //  2、把链表的所有结点都放入哈希表的 key 中
        //  3、先拷贝单链表的头结点的值，创建一个新的结点，把值放入其中，再把结点放入 key 对应的 value 中
        //  4、然后顺着头结点对整个单链表做同样的操作
        //  5、到这里，单链表所有的值就都拷贝到 key 所对应的 value 中的新节点中了，还需要做的操作是拷贝结点的指针
        //  6、通过当前的结点的下一个结点获取到下一个结点对应的拷贝结点，将它的地址赋值给当前结点的拷贝结点，那么，当前结点和下一个结点的拷贝结点就链接起来了
        //  7、同理，通过当前结点的随即指针获取到随机结点所对应的拷贝结点，将它的地址赋值给当前界的的拷贝结点的随机指针，那么当前节点和它的随机结点的拷贝结点就链接起来了
        //  8、最后，将哈希表 value全部返回，即为拷贝后的新链表
        public static Node NormalCopyListWithRandom(Node head)
        {
            Dictionary<Node, Node> dic = new();

            //把原链表存入哈希表的 key 中，把拷贝链表存到哈希表的 value 中（只存放值，目前还无法存放指针）
            Node cur = head;//用于遍历的指针
            while(cur != null)
            {
                dic.Add(cur, new Node(cur.value));
                cur = cur.next;
            }

            //代码走到这里，key 中的原链表的值都拷贝到对应的 value 中的新节点里面了，现在还需要拷贝原链表的指针
            cur = head;
            while(cur != null)
            {
                Node copyNode;//当前结点对应的拷贝结点
                dic.TryGetValue(cur, out copyNode);//当前结点对应的拷贝结点
                dic.TryGetValue(cur.next, out copyNode.next);//当前结点的下一个结点对应的拷贝结点
                dic.TryGetValue(cur.random, out copyNode.random);//当前结点的随机指向结点对应的拷贝结点
                cur = cur.next;
            }


            //代码走到这里，就全部拷贝好了，此时 cur 为 null
            dic.TryGetValue(head, out cur);
            return cur;
;
        }

        //
        // 题目要求额外空间复杂度为 O(1)，所以不能用哈希表
        // 解题思路：
        //      1、遍历第一个结点 1，将其值拷贝放入一个新结点 1'，然后让 1 链接 1'，1' 链接 2
        //      2、遍历第二个结点 2，将其值拷贝放入一个新结点 2'，然后让 2 链接 2'，2' 链接 3
        //      3、依次类推，对整个链表做如上操作
        //      4、遍历第一个结点 1，找到 1 的随机结点 x，x 的下一个结点即 x.next 就是 1' 的随机结点
        //      5、链接1' 和 x' ：1.next.random = 1.random.next
        //      6、对链表所有结点做如上操作，找到所有的拷贝结点的 random 结点
        //      7、分离原链表和拷贝链表
        //      8、将拷贝链表的头结点返回
        public static Node BetterCopyListWithRandom(Node head)
        {
            if(head == null) return null;

            Node cur = head;
            Node next = null;

            //拷贝当前结点，并链接到当前结点下
            while(cur != null)
            {
                next = cur.next;
                cur.next = new Node(cur.value);//让当前结点链接向新建的结点
                cur.next.next = next;//让拷贝的结点链接原链表的下一个结点
                cur = next;//移动 cur 到原链表下一个结点，对该结点做同样操作
            }

            //代码走到这里，得到链表如下：1->1'->2->2'->3->3'……（注意：1'2'3'...结点只拷贝了值，还需要拷贝随机指针）
            cur = head;//指向原链表的指针
            Node curCopy = null;//指向拷贝链表的指针
            while(cur != null)
            {
                next = cur.next.next;//next 指向原链表的第二个结点
                curCopy = cur.next;//curCopy 指向拷贝链表的第一个结点
                curCopy.random = cur.random != null ? cur.random.next : null;//判断 cur.random 是否指向空，以免空指针异常
                cur = next;
            }


            //代码走到这里，拷贝链表的值和随机指针就都拷贝好了，还需要做的是将链表分离出来
            Node res = head.next;//指向拷贝链表的头结点
            cur = head;//指向原链表的头结点
            while(cur != null)
            {
                next = cur.next.next;
                curCopy = cur.next;
                cur.next = next;
                curCopy.next = next != null ? next.next : null;//判断 next 是否为null，避免空指针异常
                cur = next;
            }

            return res;
        }
        #endregion

        #region 找到链表交点
        /// 题目：
        /// 给定两个可能有环可能无环的单链表,头结点为 head1 和 head2,实现函数,若两链表相交,返回第一个交点,反之返回null
        /// 要求：如果两链表长度之和为 N，时间复杂度为O(N)，额外空间复杂度为 O(1)
        public static Node GetIntersectNode(Node head1, Node head2)
        {
            if (head1 == null || head2 == null) return null;

            ///代码解释：
            /// 先各自获取环节点，判断是否有环，有环调用有环处理方法，无环调用无环处理方法
            /// 注意：一个有环一个无环一定不存在交点
            Node loop1 = GetLoopNode(head1);
            Node loop2 = GetLoopNode(head2);

            if (loop1 == null && loop2 == null)
                return NoLoop(head1, head2);
            if (loop1 != null && loop2 != null)
                return BothLoop(head1, loop1, head2, loop2);
            return null;
        }




        // 因为链表可能有环可能无环，所以需要先判断两条链表是否有环
        /// 链表有无环问题知识点：
        ///     1、如果链表由换，那一定是个死循环，不可能再有另外一个分支出来，因为链表的只有一个或两个指向上一个结点和下一个结点的指针
        ///     2、如何判断链表有无环：
        ///         1、用一个指针变量遍历链表
        ///         2、如果指针变量为 null，说明无环
        ///         3、将每一个遍历的结点放入哈希表，放之前检查一下是否已经存在该结点，不存在放入，存在则该结点为环结点
        ///     4、额外空间为 O(1) 方式寻找换节点：
        ///         1、定义快慢指针，快指针一次走两步，慢指针一次走一步
        ///         2、如果快指针走到 null，说明链表无环，否则快指针和慢指针一定会在环上相遇
        ///             ——绕着操场跑，速度快的一定会追上速度慢的，而且一定是在慢的走完两圈之前追上
        ///         3、快慢指针相遇之后，快指针回到开头，慢指针不懂
        ///         4、然后快慢指针每次各种一步
        ///         5、最后，快慢指针一定会在环结点上再次相遇（数学范畴的问题）
        public static Node GetLoopNode(Node head)
        {
            if (head == null || head.next == null || head.next.next == null) return null;//要构成环至少要三个结点

            /// 代码解释
            ///要判断有无环，首先链表前三个结点一定要存在
            ///快慢指针可以同时指向头结点，快慢指针各走一步之后慢指针一定来到 head.next,快指针一定到head.next.next
            ///又因为前三个结点一定存在，所以可以直接将慢指针指向 head.next，快指针指向 head.next.next，可以少走一步
            Node slow = head.next;
            Node fast = head.next.next;

            while(slow != fast)
            {
                if (fast.next == null || fast.next.next == null)//如果快指针走到下一个或下下个结点为null，说明链表无环
                    return null;
                fast = fast.next.next;
                slow = slow.next;
            }

            /// 代码解释：
            ///代码走到这里说明链表有环而且快指针和慢指针已经相遇了
            ///让快指针回到开头，慢指针不动
            ///让快慢指针每次各走一步，当他们再次相遇，所在结点即为环结点
            fast = head;
            while(slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }

            //代码走到这里，快慢指针再次相遇，他们所指的结点即为换节点
            return slow;
        }





        // 链表相交问题：
        //     1、两个链表都为无环链表
        //     2、其中一个链表为有环一个为无环：
        //     3、两个都是有环链表：
        /// 
        //两个链表都为无环链表的相交问题：
        // 1、不相交：各自两条线
        // 2、相交：一定是 V 型或 Y 型，不可能是 X 型，交点之后的部分一定是两条链表的公共部分
        // 3、解题思路：
        //     1、遍历两链表 l1 和 l2 到尾结点，记录 end1，end2，并记录长度 len1，len2
        //     2、如果 end1 不等于 end2，一定不相交
        //     3、如果 end1 = end2，说明存在交点
        //         1、假设 len1 大 len2 20 个单位，先让 len1 走 20 个单位（前面多出来的20个单位不可能存在交点）
        //         2、从第 21 个结点开始，比较 l1 和 l2 对应的结点，如果相同，说明该结点是两链表交点
        public static Node NoLoop(Node head1, Node head2)
        {
            if (head1 == null || head2 == null) return null;
            Node cur1 = head1;
            Node cur2 = head2;


            int differ = 0;//两链表长度差异（以一个长度差异变量优化需要两个变量来记录两个链表的长度）
            while(cur1.next != null)
            {
                differ++;
                cur1 = cur1.next;
            }

            //代码走这里，cur1 指向第一条链表尾结点，differ 为第一条链表的长度
            while(cur2.next != null)
            {
                differ--;
                cur2 = cur2.next;
            }

            ///代码解释：
            ///代码走到这里，cur2 指向第二条链表尾结点，differ 为第一条链表和第二条链表之间的差值
            ///如果尾结点不同，说明不相交
            if (cur1 != cur2) return null;


            //代码走这里说明一定存在交点

            /// 代码解释
            ///如果 differ 大于 0，说明第一条链表长，反之第二条长
            ///让 cur1 指向更长的链表，cur2 指向短链表
            cur1 = differ > 0 ? head1 : head2;
            cur2 = cur1 == head1 ? head2 : head1;

            ///代码解释：
            ///长链表比短链表长 differ，那么，从长链表头结点开始的 differ 个结点都不可能与锻炼表有交点
            ///先让长链表走 differ 个单位，使 cur1 到尾结点的长度与短链表的长度相同，在这个范畴内，两个链表才有可能有交点
            differ = Math.Abs(differ);//取 differ 的绝对值
            while (differ != 0)
            {
                differ--;
                cur1 = cur1.next;
            }

            ///代码解释：
            /// 代码走到这里，cur1 到尾结点的长度和锻炼表长度相同
            /// 让 cur1 和 cur2 一起前进，如果所指结点相同，则一定是交点
            while(cur1.next != cur2.next)
            {
                cur1 = cur1.next;
                cur2 = cur2.next;
            }

            return cur1;
        }

        // 一个链表为有环一个无环的相交问题：
        //  1、如果一个链表有环，一个链表无环，那它们一定不相交
        ///
        // 两个链表都是有环链表的相交问题：
        //  1、各自成环，不相交，没有交点
        //  2、公用环且入环结点为 1 个（V 或 Y 后面借一个环）
        //      ————解题思路：
        //          1、就是无环链表的相交问题，唯一的区别在于判断是否有交点上有区别
        //          2、无环链表在判断是否有交点时是对比两条链表的最后一个结点
        //          3、公用环且环节点为 1 个的根据环节点是否相同来判断有无交点（判断两链表有环后直接对比环节点就行了）
        //          4、如果有交点，则交点求法和 无环链表的交点求法就完全相同了
        //  3、公用环且入环结点有两个（类似一个猫头🐱，入环节点是两个猫耳朵，此时交点为整个环上的点）
        //      ————如果 环节点 不同，可能两条链表没有交点，可能两条链表有公用环但入环节点有两个，判断思路如下：
        //          1、让 cur 指针从环节点 loopNode1 开始往下走，如果遇到 loopNode2，说明公用环且入环节点有两个
        //          2、如果 cur 回到 loopNode1 ，中途没有遇到 loopNode2，说明两链表各自成环，没有交点
        //  4、总体解题思路：
        //      1、先判断是否为公共环且入环节点为 1 个
        //      2、如果不是，让其中一个环节点继续往下走，如果能遇到第二个环节点则为公共环且入环结点为两个
        //      3、如果遇不到第二个环节点，说明各自成环，返回null
        public static Node BothLoop(Node head1, Node loop1, Node head2, Node loop2)
        {
            Node cur1 = null;
            Node cur2 = null;
            if(loop1 == loop2)//如果环节点相同，说明一定存在交点
            {
                //既然有环，就一定不为 null，且链表长度一定大于等于3
                cur1 = head1;
                cur2 = head2;
                int differ = 0;//两链表到各自环节点的长度差异
                while(cur1 != null)
                {
                    differ++;
                    cur1 = cur1.next;
                }
                while(cur2 != null)
                {
                    differ--;
                    cur2 = cur2.next;
                }

                ///代码解释：
                /// 代码走到这里，cur1 和 cur2 各自指向各自单链表的环节点
                /// differ 表示两条链表从头结点到各自会节点的长度差异
                /// 如果 differ 大于 0，说明 head1 链表长度大于 head2 链表长度，反之小于
                /// 让 cur1 指向更长的链表，cur2 指向短的链表
                cur1 = differ > 0 ? head1 : head2;
                cur2 = cur1 == head1 ? head2 : head1;

                ///代码解释：
                /// 对于公共公共环且只有一个入环结点的情况
                /// 长链表从头结点开始算起第 differ 个结点之前的结点都不可能存在与短结点相交
                /// 两条链表相交，交点之后一定是公共部分，所以从环节点开始往上直到短链表的头结点之间才可能存在第一个交点
                differ = Math.Abs(differ);
                while(differ != 0)
                {
                    differ--;
                    cur1 = cur1.next;
                }

                ///代码解释：
                /// 代码走到这里，两条链表的环节点到 cur1 和 cur2 的距离是相等的，在这个范畴内才可能存在交点
                /// 让 cur1 和 cur2 齐头并进，若指向结点相同，则该点是交点
                while(cur1 != cur2)
                {
                    cur1 = cur1.next;
                    cur2 = cur2.next;
                }
                return cur1;
            }
            else
            {
                ///代码解释：
                /// 代码走这里，说明不是一个入环节点，可能有两个入环节点，也可能各自成环
                /// 判断方法是让 cur1 从 loop1 继续往下走，如果遇到 loop2 说明有两个入环结点，任何一个入环节点都是交点
                /// 如果 cur1 没遇到 loop2 回到 loop1，说明各自成环，不存在交点
                /// loop2 一定不等于 loop1，从loop1 下一个结点开始判断
                cur1 = loop1.next;
                while(cur1 != loop1)
                {
                    if (cur1 == loop2)
                        return loop1;
                    cur1 = cur1.next;
                }
                return null;
            }
        }
        #endregion
    }
}
