using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.HashTable
{
    internal class OrderTable
    {
        /*有序表的简单介绍：
         *  1、有序表在使用层面上可以理解为一种集合结构
         *  2、如果只有 key，没有伴随数据 value，可以使用 TreeSet 结构（C++ 中叫 OrderedSet）
         *  3、如果既有 key，也有伴随数据 value，可以使用 TreeMap 结构（C++ 中叫 OrderMap）
         *      注意：C# 内一般使用 SortedList<key,value>
         *  4、有无伴随数据，是 TreeSet 和 TreeMap 唯一的区别，底层的实际结构是一回事
         *  5、有序表和哈希表的区别是，有序表把 key 按照顺序组织起来，而哈希表完全不组织
         *  6、红黑树、AVL 树、size-balance-tree 和跳表等都属于有序表结果，只是底层具体史记不同
         *  7、放入哈希表的东西，如果是基础类型，内部按值传递，内存占用就是这个东西的大小
         *  8、放入哈希表的东西，如果不是基础类型，必须提供比较器，内部按引用传递，内存占用是这个东西内存地址的大小
         *  9、不管是什么底层具体实现，只要是有序表，都有以下固定的基本功能和固定时间复杂度O(logN)
         */
    }
}
