using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.Graph
{
    internal class Kruskal
    {
        ///Kruskal 算法：
        /// 1、要求：无向图
        /// 2、目的：生成最小生成树（以边的角度）
        /// 3、最小生成树：（注意，这里的树不是二叉树，可理解为多个分叉的树）
        ///     1、保证图中的点都要作为树的结点
        ///     2、保证每个结点的连通性
        ///     3、但是边不需要跟图中的边一样多
        ///     4、即：将图生成为————保证连通性，并且边的权值最小的树
        /// 4、思想：
        ///     1、将边进行排序
        ///     2、从最小的边开始加
        ///     3、如果加上边不会形成环，那就把边加上
        ///     4、如果加上边会形成环，那就不加边
        /// 5、问题在于：怎么知道加上边后会不会形成环？————集合查询方法（时间复杂度为 O(1) )
        ///     1、让每一个点都放在一个集合内（认为一开始所有的点都不是连通的）
        ///     2、当添加一条边之后，将那条边所连接的两个点添加到一个集合去，如连接的是 A 和 C，那么 A集合 和 C集合 合并起来
        ///     3、如此反复，一边添加边一边合并集合
        ///     4、当发现一条边所连接的两个点都在一个集合内，表示该边会形成环，不能添加这一条边


        public class MySets
        {

            //以下实现过程可以实现 Kruskal，但是它并没有并查集快（并查集后面再学）
            public Dictionary<Node, List<Node>> setDic;

            public MySets(List<Node> nodes)//拿到图中所有结点
            {
                foreach (Node cur in nodes)
                {
                    List<Node> set = new();//一个结点都放入一个集合中
                    set.Add(cur);
                    setDic.Add(cur, set);//将每个结点及其所在集合以键值对方式放入字典中
                }
            }

            /// <summary>
            /// 判断是否是同一个集合
            /// </summary>
            /// <param name="from"></param>
            /// <param name="to"></param>
            /// <returns></returns>
            public bool IsSameSet(Node from, Node to)
            {
                List<Node> fromSet = new();
                setDic.TryGetValue(from, out fromSet);
                List<Node> toSet = new();
                setDic.TryGetValue(to, out toSet);
                return fromSet == toSet;//判断两个结点所在的集合是不是同一个集合
            }


            /// <summary>
            /// 如果两个集合不是处于同一个集合之中，将两个集合合并到一个集合中
            /// </summary>
            public void Union(Node from, Node to)
            {
                //获取 from 结点和 to 结点所对应的集合
                List<Node> fromSet;
                setDic.TryGetValue(from, out fromSet);
                List<Node> toSet;
                setDic.TryGetValue(to, out toSet);

                //将 to 结点集合中的所有结点都添加到 from 结点所在的集合中，并让 to 结点所指向的集合指向 from 结点所在的集合
                foreach(Node toNode in toSet)
                {
                    fromSet.Add(toNode);
                    setDic.Add(toNode, fromSet);
                }
            }






            ///Kruskal 算法代码：
            ///
            


            ///比较器：
            ///
            /*public class EdgeComparator : IComparable<Edge>
            {
                public int CompareTo(Edge o1, Edge o2)
                {
                    return o1.weight - o2.weight;
                }
            }*/
        }
    }
}
