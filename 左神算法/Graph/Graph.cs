using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 算法;

namespace 算法.Graph
{
    internal class Graph
    {
        ///图：
        /// 1、图的存储方式：
        ///     1、邻接表
        ///     2、邻接矩阵
        /// 2、如何表达图？如何生成图？
        /// 

        public Dictionary<int, Node> nodes;//点集
        public HashSet<Edge> edges;//边集

        public Graph()//用点集和边集构成图
        {
            nodes = new Dictionary<int, Node>();
            edges = new HashSet<Edge>();
        }
    }
}
