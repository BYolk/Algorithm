using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.LinkList
{
    //自定义双链表结点
    internal class DoublyLinkedNode<V>
    {
        //结点中保存的值
        V v;
        public V Value { get { return v; } set { v = value; } }

        
        //下个结点
        DoublyLinkedNode<V> next;
        public DoublyLinkedNode<V> Next { get { return next; } set { next = value; } }

        //上个结点
        DoublyLinkedNode<V> prev;

        public DoublyLinkedNode<V> Prev { get { return prev; } set { prev = value; } }


        public DoublyLinkedNode() { }
        public DoublyLinkedNode(V value, DoublyLinkedNode<V> next,  DoublyLinkedNode<V> prev)
        {
            this.v = value;
            this.next = next;
            this.prev = prev;
        }
    }
}
