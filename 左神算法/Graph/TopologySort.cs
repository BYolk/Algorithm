using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.Graph
{
    internal class TopologySort
    {
        ///拓扑排序算法：
        /// 1、拓扑排序适用范围：要求有向图，且有入度为 0 的点，并且没有环
        /// 2、输出所有入度为 0 的点，然后把该点的出度全部擦掉，得到下一个入度为 0 的点
        /// 3、如此反复，将整张图结点输出
        /// 
        public static List<Node> SortedTopology(Graph graph)
        {
            Dictionary<Node, int> inMap = new();//用于保存结点以及其入度数
            Queue<Node> zeroInQueue = new();//入度为 0 的点入队

            foreach(Node node in graph.nodes.Values)
            {
                inMap.Add(node, node.inCount);//向哈希表中存放图的结点以及结点对应的入度
                if(node.inCount == 0)//如果入度为 0，入队，此时队列中存在第一批入度为 0 的点
                    zeroInQueue.Enqueue(node);
            }

            List<Node> result = new();
            while(zeroInQueue.Count > 0)//只要队列不为空，即只要队列里面包含有入度为 0 的结点
            {
                Node cur = zeroInQueue.Dequeue();//将队列内入度为 0 的点出队
                result.Add(cur);//添加到结果集里面
                foreach(Node next in cur.nexts)//遍历该节点的所有邻接点
                {
                    int inCount;
                    inMap.TryGetValue(next, out inCount);
                    inCount--;//下一个邻接点入度 -1，因为它的入度结点已经遍历了
                    inMap.Add(next, inCount);
                    if (inCount == 0)
                        zeroInQueue.Enqueue(next);//如果入度为 0，入队
                }
            }
            return result;
        }

    }
}
