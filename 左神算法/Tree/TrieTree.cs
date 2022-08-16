using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.Tree
{
    internal class TrieTree
    {
        ///前缀树：
        /// 1、何为前缀树？
        /// 2、如何生成前缀树？
        /// 3、例子：
        ///     1、一个字符串类型的数组 arr1，另一个字符串类型的数组 arr2。
        ///     2、arr2 中有哪些字符是 arr1 中出现的?请打印。
        ///     3、arr2 中有哪些字符，是作为 arr1 中某个字符串前缀出现的?请打印。
        ///     4、arr2 中有哪些字符，是作为 arr1 中某个字符串前缀出现的?请打印 arr2 中出现次数最大的前缀。
        ///     



        ///前缀树结点：
        ///
        public class TrieNode
        {
            public int path;//通过该结点的次数
            public int end;//以该节点为终点的次数
            public TrieNode[] nexts;//该节点往下还有多少个结点
            public TrieNode()
            {
                path = 0;
                end = 0;
                nexts = new TrieNode[26];//为26个字母创建26个树结点，如果字符过多，可以使用哈希表Dictionary<Char,Node>,表示char 下一个结点是谁
            }
        }


        public class Trie//前缀树
        {
            private TrieNode root;//最开始的根结点
            public Trie()
            {
                root = new TrieNode();
            }


            /// <summary>
            /// 注意，最开始的 root 结点表示空字符串
            /// 如果需要往前缀树添加空字符串，那么 root 结点的 pass 和 end 都要自增，end 的值就是空字符串的个数
            /// </summary>
            /// <param name="word"></param>
            public void Insert(String word)//将传递过来的字符串插入前缀树中
            {
                if (word == null) return;

                char[] chs = word.ToCharArray();//将字符串转为字符数组
                TrieNode node = root;//创建一个根结点
                int index = 0;
                for(int i = 0; i < chs.Length; i++)
                {
                    index = chs[i] - 'a';//让每一个字符减去 'a' 字符的 AscII 码，如果该字符是'a'，减去之后得0，如果字符是b，减去之后得1
                    if (node.nexts[index] == null)//如果从'a' 到该字符的路径不存在，新建一个结点，添加该路径
                        node.nexts[index] = new TrieNode();
                    node = node.nexts[index];//将指针指向新建的结点
                    node.path++;//通过该节点的次数加1
                }
                //遍历完成，说明当前结点是结尾结点，end 加 1
                node.end++;
            }
        

            public int Search(string word)
            {
                if (word == null) return 0;//如果为空字符串，返回 0
                char[] chs = word.ToCharArray();
                TrieNode node = root;
                int index = 0;
                for(int i = 0; i < chs.Length; i++)
                {
                    index = chs[i] - 'a';
                    if (node.nexts[index] == null)//如果找不到对应的路径，说明树中没有该字符串
                        return 0;
                    node = node.nexts[index];//如果当前字符存在路径，判断下个字符的路径是否存在
                }
                //代码走到这里，说明已经找到该字符串在前缀树中的路径
                return node.end;//返回前缀树中有多少条该字符串的路径
            }

            /// <summary>
            /// 从前缀树中删除某一串字符串所代表的路径
            /// </summary>
            /// <param name="word"></param>
            public void delete(string word)
            {
                if(Search(word) != 0)//先判断该路径在不在前缀树中，在才删除，不在不删除
                {
                    char[] chs = word.ToCharArray();
                    TrieNode node = root;//指向根结点
                    int index = 0;
                    for(int i = 0; i < chs.Length; i++)//遍历字符串每一个字符，在前缀树中找到该字符的路径
                    {
                        index = chs[i] - 'a';
                        if (--node.nexts[index].path == 0)//如果当前结点删除后，通过次数减 1 等于0,表示没有路径通过该结点了,该节点已经无用
                        {
                            node.nexts[index] = null;//该结点已经没有用了，将它的下一个结点置为空,将其释放
                            return;//删除完毕
                        }
                        node = node.nexts[index];//指向下一个结点，对下个结点做同样操作
                    }
                    node.end--;//如果代码走这里，说明表示该字符串的路径有多条，该路径的次数减 1
                }
            }

            /// <summary>
            /// 前缀为 pre 的字符串有多少个
            /// </summary>
            /// <param name="pre"></param>
            /// <returns></returns>
            public int PrefixNumber(string pre)
            {
                if (pre == null) return 0;

                char[] chs = pre.ToCharArray();
                TrieNode node = root;
                int index = 0; 
                for(int i = 0; i < chs.Length; i++)
                {
                    index = chs[i] - 'a';
                    if (node.nexts[index] == null)//如果当前路径下一个结点为空，表示该字符串路径在前缀树中不存在
                        return 0;
                    node = node.nexts[index];//如果当前路径下一个结点存在，将指针指向下个结点，对下个结点做同样判断
                }
                return node.path;//node 结点即为字符串 pre 的最后一个字符，通过该结点多少次，表示前缀树中有多少个字符串前缀是 pre
            }
        }



        /*public static void Main(string[] args)
        {
            Trie trie = new Trie();
            Console.WriteLine(trie.Search("zuo"));
            trie.Insert("zuo");
            Console.WriteLine(trie.Search("zuo"));
            trie.delete("zuo");
            Console.WriteLine(trie.Search("zuo"));
            trie.Insert("zuo");
            trie.Insert("zuo");
            trie.delete("zuo");
            Console.WriteLine(trie.Search("zuo"));
            trie.delete("zuo");
            Console.WriteLine(trie.Search("zuo"));
            trie.Insert("zuoa");
            trie.Insert("zuoac");
            trie.Insert("zuoab");
            trie.Insert("zuoad");
            trie.delete("zuoa");
            Console.WriteLine(trie.Search("zuoa"));
            Console.WriteLine(trie.PrefixNumber("zuo"));

        }*/
    }
}
