using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 算法.GreedyAlgorithm
{
    internal class BestArrange
    {
        ///例题：
        /// 一些项目要占用一个会议室宣讲，会议室不能同时容纳两个项目的宣讲。给你每一个项目开始的时间和结束的时间
        /// 给你一个数组，里面是一个个具体的项目，你来安排宣讲的日程，要求会议室进行的宣讲的场次最多。返回这个最多的宣讲场次。
        /// 
        ///思路：
        /// 1、不能安排开始时间最早的，应为最早的那个项目可以贯穿一整天
        /// 2、不能安排宣讲时间最短的，应为它虽然短，但是它可能同时占用了多个别的宣讲项目
        /// 3、最好的做法（贪心算法）：选择结束时间最早的
        /// 

        ///宣讲项目类
        public class Program
        {
            public int start;//开始时间
            public int end;//结束时间

            public Program(int start,int end)
            {
                this.start = start;
                this.end = end; 
            }
        }


        public class ProgramComparator : IComparer<Program>
        {
            public int Compare(Program? x, Program? y)
            {
                if (x != null && y != null)
                    return x.end - y.end;//看哪个结束时间早
                else
                    return 0;
            }
        }


        /// <summary>
        /// 最好的安排算法
        /// </summary>
        /// <param name="programs">所有的宣讲项目</param>
        /// <param name="start">场馆开始的时间</param>
        /// <returns></returns>
        public static int BestArrangeAlgorithm(Program[] programs, int start)
        {
            Array.Sort(programs, new ProgramComparator());//根据项目比较器定义的比较方法排序数组
            int result = 0;//表示可以安排多少个项目
            for(int i = 0; i < programs.Length; i++)
            {
                if(start <= programs[i].start)//如果该项目在场馆之后开始，安排它
                {
                    result++;
                    start = programs[i].end;//下一次项目的开始时间来到该项目结束之后
                }
            }
            return result;
        }
    }
}
