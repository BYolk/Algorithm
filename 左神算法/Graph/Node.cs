using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 算法.Graph;

namespace 算法.Graph
{
    internal class Node
    {
        public int value;//数据项，即点上的值
        public int inCount;//入度：进入本结点的边数
        public int outCount;//出度：从本节点出去的边数
        public List<Node> nexts;//指向的节点集合（邻居结点）
        public List<Edge> edges;//从本结点出去的边集合
        public Node(int value)
        {
            this.value = value;
            inCount = 0;
            outCount = 0;
            nexts = new List<Node>();
            edges = new List<Edge>();
        }
    }
}
