using System;

namespace Combine
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lambda(1.匿名方法 2.inline方法)
            
            // Func<int, int, int> func = new Func<int, int, int>((int a, int b) => { return a + b; });
            // Func<int, int, int> func = new Func<int, int, int>((a, b) => { return a + b; });
            // Func<int, int, int> func = (a, b) => { return a + b; };
            Func<int, int, int> func = (a, b) => a + b; // 最簡寫法
            int result = func(100, 200);
            Console.WriteLine(result);

            DoSomeCalc((a, b) => a * b, 100, 200); // 泛型委託可以自動推斷類型
        }

        // 有名字且不是inline的方法
        // static int Add(int x, int y)
        // {
        //     return x + y;
        // }

        static void DoSomeCalc<T>(Func<T, T, T> func, T x, T y)
        {
            T res = func(x, y);
            Console.WriteLine(res);
        }
    }
}