using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.Graph
{
    internal class Dijkstra
    {
        ///Dijkstra 算法：
        /// 1、适用范围：可以有权值为负数的边，但不能有累加和为负数的环（循环一次路径都会变得更小）
        /// 2、思想：
        ///     1、假设五个点 A, B, C, D, E
        ///     2、随便选择一个点，假设是 A
        ///     3、然后对 A 建立表，表示 A 到 A 距离为0，到其他点距离为正无穷
        ///     4、在表中找到距离最短的点（第一次找是 A），看一看点 A 所在的边，能不能让表中的记录变少
        ///     5、如果存在能让表距离变短的边，将表中距离改写成更小的值
        ///     6、用完一个点之后，该点不会再使用（第一次用的是 A 点，用完之后 A 就不会再用了），进入路径最短的下一个点
        ///     7、如此循环反复，直到 A 到每个点的距离都是最短的
    
        public static Dictionary<Node,int> Dijkstra1(Node head)
        {
            ///代码解释：
            /// distanceDic 表示从 head 结点出发到所有结点的最小距离，包括自身结点
            /// key: 表示从 head 出发可以到达的结点
            /// value：表示从 head 出发到达下一个结点的最小距离
            /// 如果在表中，没有某个结点的记录，表示从 head 出发到该结点的距离为正无穷
            /// 
            Dictionary<Node, int> distanceDic = new();
            distanceDic.Add(head, 0);//从 head 结点到 head 结点的距离为 0；

            //对于已经求过距离的点，存入 selectedNode 哈希集中，以后再也不碰
            HashSet<Node> selectedNodes = new();
            Node minNode = GetMinDistanceAndUnselectedNode(distanceDic, selectedNodes);//在 distanceDic 选择最小距离的那一条记录来处理，但这条记录不能是我们处理过的
            while (minNode != null)//如果存在更小距离的点
            {
                int distance;   
                distanceDic.TryGetValue(minNode, out distance);//获取集合中保存的 head 到该结点的最小距离
                foreach(Edge edge in minNode.edges)//遍历该结点的所有边
                {
                    Node toNode = edge.to;//获取每条边所指向的结点
                    if (!distanceDic.ContainsKey(toNode))//如果字典中不存在该点
                        distanceDic.Add(toNode, distance + edge.weight);//将该结点添加到字典中
                    int toNodeDistance;
                    distanceDic.TryGetValue(toNode, out toNodeDistance);
                    distanceDic.Add(edge.to, Math.Min(toNodeDistance, distance + edge.weight));//更新字典中的距离为更小
                }
                selectedNodes.Add(minNode);
                minNode = GetMinDistanceAndUnselectedNode(distanceDic, selectedNodes);//将该结点放入 selectedNode 中，以后再也不碰
            }
            return distanceDic;
        }



        public static Node GetMinDistanceAndUnselectedNode(Dictionary<Node, int> distanceDic, HashSet<Node> touchedNodes)
        {
            Node minNode = null;
            int minDistance = int.MaxValue;
            ///代码未完成
            return minNode;
        }
    }
}
