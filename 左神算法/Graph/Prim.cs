using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.Graph
{
    internal class Prim
    {
        ///Prim 算法：
        /// 1、要求：无向图
        /// 2、目的：生成最小生成树（以点的角度）
        /// 3、最小生成树：（注意，这里的树不是二叉树，可理解为多个分叉的树）
        ///     1、保证图中的点都要作为树的结点
        ///     2、保证每个结点的连通性
        ///     3、但是边不需要跟图中的边一样多
        ///     4、即：将图生成为————保证连通性，并且边的权值最小的树
        /// 4、思想：
        ///     1、可以从任意点出发，无所谓
        ///     2、认为所有的边都还没有被解锁
        ///     3、假设从一个点 A 出发，那么连接该点的边就会全部被解锁
        ///     4、挑选权值最小的边，把该边连接的结点 C 添加进来
        ///     5、那么添加的结点 C 又可以解锁很多条边
        ///     6、同样道理，选择刚解锁的权值最小的边，把边连接的点添加进来，如此反复
        ///     7、当选择的边所连接的结点已经在集合内，该边不能选，选择另一条权值较小的边……直到所有的点都添加进集合，即得到最小生成树
        ///     8、集合可以使用哈希集，用于判断某个点是否已经存在集合中，速度更快

        public static HashSet<Edge> PrimMST(Graph graph)
        {
            PriorityQueue<Edge, int> priorityQuene = new();
            HashSet<Node> set = new();
            HashSet<Edge> result = new();
            int priorityQueneIndex = 0;
            foreach(Node node in graph.nodes.Values)//循环是用于处理森林问题的（多片不连通的图）
            {
                if (!set.Contains(node))//如果哈希集中不包含结点
                {
                    set.Add(node);//将结点添加进哈希集
                    foreach(Edge edge in node.edges)//遍历该结点的所以后边，把所有的边都进队
                    {
                        priorityQuene.Enqueue(edge, priorityQueneIndex);
                        priorityQueneIndex++;
                    }
                    while(priorityQuene.Count > 0)//如果队列有元素
                    {
                        Edge edge = priorityQuene.Dequeue();//出队
                        Node toNode = edge.to;//找到这条边的去向的结点
                        if (!set.Contains(toNode))//如果边的去向结点不在集合中，添加到集合内
                        {
                            set.Add(toNode);
                            result.Add(edge);
                            foreach (Edge nextEdge in toNode.edges)//遍历去向结点的所有边，添加到队列内
                            {
                                priorityQuene.Enqueue(nextEdge, priorityQueneIndex);
                                priorityQueneIndex++;
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
