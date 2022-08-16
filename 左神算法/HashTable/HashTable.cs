using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.HashTable
{
    internal class HashTable
    {
        /*哈希表简单介绍：
         *  1、哈希表在使用层面上可以理解为一种集合结构
         *  2、如果只有 key，没有伴随数据 value，可以使用 HashSet 结构（C++ 中叫 UnOrderedSet，C# 是HashSet）
         *  3、如果既有 key，也有伴随数据 value，可以使用 HashMap 结构（C++ 中叫 UnOrderMap，C# 没有 HashMap）
         *  4、有伴随数据，是 HashMap 和 HaseSet 的唯一区别，底层的实际结构是一样的
         *  5、使用哈希表增删改查的操作可以认为时间复杂度为O(1)，但是常数时间比较大
         *  6、放入哈希表的东西如果是基础类型，内部按值传递，内存占用是这个东西的大小
         *  7、放入哈希表的东西如果不是基础类型，内部按引用传递，内存占用是这个东西内存地址的大小
         *  注意：C# 内一般使用 Dictionary<key,value>
         */
    }
}
