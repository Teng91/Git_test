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
            MyDele<int> deleAdd = new MyDele<int>(Add);
            int result = deleAdd(100, 200);
            Console.WriteLine(result);
            MyDele<double> deleMul = new MyDele<double>(Mul);
            double result2 = deleMul(100, 200);
            Console.WriteLine(result2);
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

    delegate T MyDele<T>(T a, T b); // 泛型委託(特化) -> 避免類膨脹或是成員膨脹
}