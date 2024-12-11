using System;
using System.Collections.Generic;

namespace HelloGeneric
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IList<int> list = new List<int>(); // 用int特化List泛型接口
            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            foreach (var item in list)
            {
                System.Console.WriteLine(item);
            }

            // 泛型不一定只能接收一個參數
            IDictionary<int, string> dict = new Dictionary<int, string>();
            dict[1] = "Joy";
            dict[2] = "Timothy";
            System.Console.WriteLine($"Student #1 is {dict[1]}");
            System.Console.WriteLine($"Student #2 is {dict[2]}");
        }
    }
}