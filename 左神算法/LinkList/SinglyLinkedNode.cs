using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.LinkList
{
    //自定义单链表结点
    internal class SinglyLinkedNode<V>
    {
        V v;
        public V Value{get { return v; } set { v = value; }}

        SinglyLinkedNode<V> next;

        public SinglyLinkedNode()
        {

        }
        public SinglyLinkedNode<V> Next { get { return next; } set { next = value; } }

        public SinglyLinkedNode(V v)
        {
            this.v = v;
        }
        public SinglyLinkedNode(V v, SinglyLinkedNode<V> next)
        {
            this.v = v;
            this.next = next;
        }
    }
}
