using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CartesianProduct
{
    class Program
    {
        //保存笛卡尔结果集的全局变量
        public static List<string> result = new List<string>();
        static void Main(string[] args)
        {
            List<List<string>> words=new List<List<string>>()
            {
                new List<string>(){"你","我","他"},
                new List<string>(){"食","衣","住","行"},
                new List<string>(){"北京","四川"},
                new List<string>(){"1","2"}
            };
            CartesianProduct(new List<string>(),words);
            Console.WriteLine("=============笛卡尔积记录条数:{0}=============",result.Count);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        /// <summary>
        /// 求集合的笛卡尔积递归算法
        /// </summary>
        /// <param name="temp">用于保存求得的某条笛卡尔记录的临时变量</param>
        /// <param name="words">包含要求笛卡尔积的集合数组</param>
        public  static void CartesianProduct(List<string> temp, List<List<string>> words)
        {
            //递归结束条件，当集合数组中只剩最后一个数组时，说明已经递归到最里层
            //此时只需将该数组中的元素依次添加到temp中。
            if (words.Count == 1) {
                foreach (var item in words[0])
                {
                    var t = new List<string>(temp);
                    t.Add(item);
                    result.Add(string.Join(",", t));
                }
                return;
            }
            //取出第一个数组中的元素和子集的笛卡尔积进行组合，就是所求笛卡尔积
            var row = words[0];
            foreach (var item in row)
            {
                var t = new List<string>(temp);
                var w = new List<List<string>>(words);
                w.Remove(row);
                t.Add(item);
                CartesianProduct(t,w);
            }
        }
    }
}
