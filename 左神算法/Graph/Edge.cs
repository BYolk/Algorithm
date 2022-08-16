using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 算法;

namespace 算法.Graph
{
    internal class Edge
    {
        public int weight;//权重：可以表达距离，也可以表示其它值
        public Node from;//边从哪来
        public Node to;//边到哪去
        public Edge(int weight, Node from, Node to)
        {
            this.weight = weight;
            this.from = from;
            this.to = to;
        }
    }
}
