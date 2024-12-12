using System;
using System.Collections.Generic;
using System.Linq;

// 自定義委託
namespace Combine
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = new Action<string>(SayHello);
            action("Joy");
            Func<int, int, int> func = new Func<int, int, int>(Add);
            int result = func(100, 200);
            Console.WriteLine(result);
            Func<double, double, double> func2 = new Func<double, double, double>(Mul);
            double result2 = func2(100, 200);
            Console.WriteLine(result2);
        }

        static void M1()
        {
            Console.WriteLine("M1 is called.");
        }

        static void SayHello(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }

        static int Add(int x, int y)
        {
            return x + y;
        }

        static double Mul(double x, double y)
        {
            return x * y;
        }
    }
}