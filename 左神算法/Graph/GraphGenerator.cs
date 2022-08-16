using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.Graph
{
    /// <summary>
    /// 图形结构生成器
    /// </summary>
    internal class GraphGenerator
    {
        /// <summary>
        /// 将矩阵的图形结构转化为我熟知的“点集+边集”图形结构
        ///     1、创建一张空图
        ///     2、遍历矩阵图形结构，每一行的第一个数表示边从哪个节点来，第二个数表示边到哪个节点去，第三个数表示边的权重
        ///     3、将二维数组（矩阵）对应数据保存到图中的点集和边集中
        ///     4、
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Graph CreateGraph(int[][] matrix)
        {
            Graph graph = new Graph();
            for(int i = 0; i < matrix.Length; i++)
            {
                //收集数据
                int from = matrix[i][0];//节点编号
                int to = matrix[i][1];//节点编号
                int weight = matrix[i][2];

                //将某一条边对应的起点节点和目标节点都放入图的点集中，如果该点已经存在，就不用放了
                if (!graph.nodes.ContainsKey(from))
                    graph.nodes.Add(from, new Node(from));
                if(!graph.nodes.ContainsKey(to))
                    graph.nodes.Add(to, new Node(to));

                //为 from 和 node 创建节点
                Node fromNode;
                graph.nodes.TryGetValue(from, out fromNode);
                Node toNode;
                graph.nodes.TryGetValue(to, out toNode);

                
                Edge newEdge = new Edge(weight, fromNode, toNode);//实例化边
                fromNode.nexts.Add(toNode);//为 fromNode 结点的边添加邻居，邻居就是它指向的 toNode 结点
                fromNode.outCount++;//fromNode 出度加 1
                toNode.inCount++;//toNode 入度加 1
                fromNode.edges.Add(newEdge);//将边添加到 fromNode 的边集中
                graph.edges.Add(newEdge);//将边添加到图的边集中
            }
            return graph;
        }
    }
}
