using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//H 红桃            C 梅花          D 方块            S 黑桃

namespace Test
{
    internal class Poker
    {
        public static string[] suits = { "H", "C", "D", "S" };
        public static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

        public static void Main(string[] args)
        {
            Card[] cards = Poker.GetPoker();//得到扑克牌

            Console.WriteLine("请以“花色 + 数字”的形式输入两张扑克牌，以H表示红桃, C表示梅花, D表示方块，S表示黑桃：");
            Console.WriteLine("请输入第一张牌：");
            string card1 = Console.ReadLine();
            Console.WriteLine("请输入第二张牌：");
            string card2 = Console.ReadLine();

            Poker.GetStraights(cards, card1, card2);//得到所有顺子
        }

        //获得一副扑克牌
        public static Card[] GetPoker()
        {
            Card[] cards = new Card[52];
            
            int index = 0;
            #region 测试
            /*for (int num = 0; num < numbers.Length; num++)//数字
            {
                for (int suit = 0; suit < suits.Length; suit++)//花色
                {
                    cards[index] = new Card(suits[suit], numbers[num]);
                    index++;
                }
            }*/
            #endregion

            for (int suit = 0; suit < suits.Length; suit++)//花色
            {
                for (int num = 0; num < numbers.Length; num++)
                {
                    cards[index] = new Card(suits[suit], num);
                    index++;
                }
                    
            }
            
            return cards;
        }

        /// <summary>
        /// 获得两张牌的所有顺子
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        public static void GetStraights(Card[] cards, string c1, string c2)
        {
            #region 验证非法性
            if (c1 == c2)
            {
                Console.WriteLine("两张牌不能相同!");
            }

            

            //代码走这里说明牌不相同
            //将用户输入的字符串制成卡牌
            Card card1 = new Card(Convert.ToString(c1[0]), Convert.ToInt32(c1.Substring(1)));
            Card card2 = new Card(Convert.ToString(c2[0]), Convert.ToInt32(c2.Substring(1)));
            string card1Suit = card1.suit;//卡1花色
            int card1Num = card1.number;//卡1数字
            string card2Suit = card2.suit;//卡2花色
            int card2Num = card2.number;//卡2数字


            if (
                !//对下面结果取反
                (card1Suit == "H" || card1Suit == "C" || card1Suit == "D" || card1Suit == "S") //如果是花色
                &&
                (card1Num > 0 || card1Num < 14)//如果没有超出范围
                )
            {
                Console.WriteLine("第一张牌不合法！！！");
                return;
            }

            if (
                !//对下面结果取反
                (card2Suit == "H" || card2Suit == "C" || card2Suit == "D" || card2Suit == "S") //如果是花色
                &&
                (card2Num > 0 || card2Num < 14)//如果没有超出范围
                )
            {
                Console.WriteLine("第二张牌不合法！！！");
                return;
            }



            if (Math.Abs(Convert.ToInt32(card1.number) - Convert.ToInt32(card2.number)) > 4)
            {
                Console.WriteLine("相差超过4，不能形成顺子。");
                return;
            }

            if(card1.number == card2.number)
            {
                Console.WriteLine("两张牌数字相同，不能形成顺子");
                return;
            }
            #endregion


            //代码走这里说明卡牌合法,可以形成顺子
            Console.WriteLine("打印结果:");


            Dictionary<int, HashSet<int[]>> allStrightDir = GetAllStraight();//每个数字所有可能的顺子
            List<int[]> commonList = GetCommonStrightList(allStrightDir, card1Num, card2Num);//两个数字共同的顺子
            List<string[]> allSuitCombination = GetAllSuitCombination();//剩余三张牌的所有可能排列情况

            
            if (card1Suit == card2Suit)
                GetAllStraightsContainFlushs(commonList, allSuitCombination, card1, card2);//获取包含同花顺的顺子
            else
                GetAllStraight(commonList, allSuitCombination, card1, card2);//获取不包含同花顺的顺子

        }

        /// <summary>
        /// 获取包含同花顺的所有顺子
        /// </summary>
        /// <param name="commonList">两张牌共同的顺子</param>
        /// <param name="allSuitCombination">剩下三张牌的花色组合</param>
        /// <param name="card1">牌1</param>
        /// <param name="card2">牌2</param>
        public static void GetAllStraightsContainFlushs(List<int[]> commonList, List<string[]> allSuitCombination, Card card1, Card card2)
        {
            //因为是同花色
            string suit = card1.suit;//卡1花色
            int card1Num = card1.number;//卡1数字
            int card2Num = card2.number;//卡2数字
            int strightSum = 0 ;

            int suitIndex = 0;
            //输出同花之外的顺子：
            for (int i = 0; i < commonList.Count; i++)//遍历每一个顺子
            {
                for(int j = 0; j < allSuitCombination.Count; j++)//遍历每一个花色组合
                {
                    for (int k = 0; k < commonList[i].Length; k++)//遍历顺子中的每一个数字，让一个顺子匹配所有的花色组合
                    {
                        //输出同花顺
                        if (allSuitCombination[j][0] == suit &&
                            allSuitCombination[j][0] == allSuitCombination[j][1] && 
                            allSuitCombination[j][0] == allSuitCombination[j][2])
                        {
                            Console.Write("SF->");
                            foreach (int num in commonList[i])
                            {
                                Console.Write(suit + num + ", ");
                            }
                            k = commonList[i].Length;//commonList[i] 顺子中的所有数字输出完毕，不用遍历该顺子的每一个数字，跳到下一条顺子
                        }


                        //代码走这里说明不是同花顺
                        else if (commonList[i][k] == card1Num || commonList[i][k] == card2Num)
                        {
                            Console.Write(suit + commonList[i][k] + ", ");
                        }
                        else
                        {
                            Console.Write(allSuitCombination[j][suitIndex] + commonList[i][k] + ", ");
                            suitIndex++;
                        }

                    }

                    //遍历完一条顺子之后，整理数据
                    suitIndex = 0;
                    strightSum++;
                    Console.WriteLine();
                }
            }
            Console.WriteLine("共包含"+ strightSum + "条顺子");
        }

        /// <summary>
        /// 获取不包含同花顺的所有顺子
        /// </summary>
        /// <param name="commonList">两张牌共同的顺子</param>
        /// <param name="allSuitCombination">剩下三张牌的花色组合</param>
        /// <param name="card1">牌1</param>
        /// <param name="card2">牌2</param>
        public static void GetAllStraight(List<int[]> commonList, List<string[]> allSuitCombination, Card card1, Card card2)
        {
            //因为是同花色
            string suit1 = card1.suit;//卡1花色
            string suit2 = card2.suit;//卡1花色
            int card1Num = card1.number;//卡1数字
            int card2Num = card2.number;//卡2数字
            int strightSum = 0;

            int suitIndex = 0;
            //输出同花之外的顺子：
            for (int i = 0; i < commonList.Count; i++)//遍历每一个顺子
            {
                for (int j = 0; j < allSuitCombination.Count; j++)//遍历每一个花色组合
                {
                    foreach (int num in commonList[i])//遍历顺子中的每一个数字，让一个顺子匹配所有的花色组合
                    {
                        if (num == card1Num)
                        {
                            Console.Write(suit1 + num + ", ");
                        }
                        else if(num == card2Num)
                        {
                            Console.Write(suit2 + num + ", ");
                        }
                        else
                        {
                            Console.Write(allSuitCombination[j][suitIndex] + num + ", ");
                            suitIndex++;
                        }
                    }
                    suitIndex = 0;
                    Console.WriteLine();
                    strightSum++;
                }
            }
            Console.WriteLine("共包含" + strightSum + "条顺子");
        }

        /// <summary>
        /// 获取1-13所有顺子
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, HashSet<int[]>> GetAllStraight()
        {
            Dictionary<int, HashSet<int[]>> strightDir = new();
            for (int i = 1; i <= 13; i++)//获取每个数字的顺子
                strightDir.Add(i, GetStrightByNumber(i));
            return strightDir;
        }

        /// <summary>
        /// 获取某个数字对应的所有顺子
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static HashSet<int[]> GetStrightByNumber(int i)
        {
            HashSet<int[]> list = new();
            if (i >= 1 && i <= 4)//1 到 4 存在的顺子
            {
                for (int j = 1; j <= i; j++)
                {
                    list.Add(new int[] { j, j + 1, j + 2, j + 3, j + 4 });
                }
                Console.WriteLine(i + "的顺子：");
                
                return list;
            }
            else if (i >= 5 && i <= 9)//5 到 9 存在的顺子
            {
                for (int j = i; j <= i + 4; j++)
                {
                    list.Add(new int[] { j - 4, j - 3, j - 2, j - 1, j - 0 });
                }
                
                return list;
            }
            else if (i >= 10 && i <= 13)// 10 到 13 存在的顺子
            {
                for (int j = i - 4; j + 4 <= 13; j++)
                {
                    list.Add(new int[] { j, j + 1, j + 2, j + 3, j + 4 });
                }
                /*Console.WriteLine(i + "的顺子：");
                foreach (int[] arr in list)
                {
                    foreach (int number in arr)
                    {
                        Console.Write(number + " ");
                    }
                    Console.WriteLine();
                }*/
                return list;
            }
            else
            {
                Console.WriteLine("数字不合法");
                return null;
            }
        }

        /// <summary>
        /// 获取两个数字共同顺子
        /// </summary>
        /// <param name="strightDir">每一个数字对应的顺子</param>
        /// <param name="card1">数字1</param>
        /// <param name="card2">数字2</param>
        /// <returns></returns>
        public static List<int[]> GetCommonStrightList(Dictionary<int, HashSet<int[]>> strightDir, int card1Num, int card2Num)
        {
            HashSet<int[]> num1StrightSet;
            strightDir.TryGetValue(card1Num, out num1StrightSet);//获取数字1可以凑成的所有顺子组合

            List<int[]> commonList = new();//用于存放数字1 和 数字2 组成的顺子集合
            foreach (int[] arr in num1StrightSet)//如果数字1 的所有顺子集合中有数字2，说明该顺子包含两个数字，也是我们最终所需的数字
            {
                foreach (int i in arr)
                {
                    if (i == card2Num)
                    {
                        commonList.Add(arr);
                        continue;
                    }
                }
            }

            return commonList;
        }

        /// <summary>
        /// 在四个花色之间获取三个花色所有的组合
        /// </summary>
        /// <returns></returns>
        public static List<string[]> GetAllSuitCombination()
        {
            string[] toBeCombination = new string[] { "H", "C", "D", "S" };
            List<string[]> list = new();

            //三种同花
            for (int i = 0; i < 4; i++)
            {
                list.Add(new[] { toBeCombination[i], toBeCombination[i], toBeCombination[i] });
                Console.Write(toBeCombination[i]);
                Console.Write(toBeCombination[i]);
                Console.Write(toBeCombination[i]);
                Console.WriteLine();
            }
            //两张同花
            for (int i = 0; i < 4; i++)
            {
                list.Add(new[] { toBeCombination[i], toBeCombination[i], toBeCombination[(i + 1) % 4] });
                list.Add(new[] { toBeCombination[i], toBeCombination[i], toBeCombination[(i + 2) % 4] });
                list.Add(new[] { toBeCombination[i], toBeCombination[i], toBeCombination[(i + 3) % 4] });

                list.Add(new[] { toBeCombination[i], toBeCombination[(i + 1) % 4], toBeCombination[i] });
                list.Add(new[] { toBeCombination[i], toBeCombination[(i + 2) % 4], toBeCombination[i] });
                list.Add(new[] { toBeCombination[i], toBeCombination[(i + 3) % 4], toBeCombination[i] });

                list.Add(new[] { toBeCombination[(i + 1) % 4], toBeCombination[i], toBeCombination[i] });
                list.Add(new[] { toBeCombination[(i + 2) % 4], toBeCombination[i], toBeCombination[i] });
                list.Add(new[] { toBeCombination[(i + 3) % 4], toBeCombination[i], toBeCombination[i] });

            }
            //三张都不同花
            for (int i = 0; i < 4; i++)
            {
                list.Add(new[] { toBeCombination[i], toBeCombination[(i + 1) % 4], toBeCombination[(i + 2) % 4] });
                list.Add(new[] { toBeCombination[i], toBeCombination[(i + 2) % 4], toBeCombination[(i + 1) % 4] });

                list.Add(new[] { toBeCombination[i], toBeCombination[(i + 1) % 4], toBeCombination[(i + 3) % 4] });
                list.Add(new[] { toBeCombination[i], toBeCombination[(i + 3) % 4], toBeCombination[(i + 1) % 4] });


                list.Add(new[] { toBeCombination[i], toBeCombination[(i + 2) % 4], toBeCombination[(i + 3) % 4] });
                list.Add(new[] { toBeCombination[i], toBeCombination[(i + 3) % 4], toBeCombination[(i + 2) % 4] });
                
                Console.WriteLine();
            }

            return list;
        }
    }
}

public class Card
{
    public string suit;
    //public string number;
    public int number;

    /*public Card(string suit, string number)
    {
        this.suit = suit;
        this.number = number;
    }*/

    public Card(string suit, int number)
    {
        this.suit = suit;
        this.number = number;
    }

    public override string ToString()
    {
        return suit + number;
    }
}

















