using System;

// 泛型委託
namespace HelloGeneric
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Action只能委託沒有返回值的方法(void)
            Action<string> a1 = Say;
            a1.Invoke("Joy"); // 間接調用
            a1("Joy"); // 委託的另一種寫法
            Action<int> a2 = Mul;
            a2.Invoke(1);
            a2(1);

            // 有返回值 -> Function泛型委託(會自動去搜尋有沒有符合的class)
            Func<int, int, int> func1 = Add; // 前兩個是輸入參數類型，最後一個是輸出參數類型
            var result = func1(100, 200);
            System.Console.WriteLine(result);
            // Lambda表達式: 簡化一些簡單運算的程式碼
            Func<int, int, int> func2 = (int a, int b) => { return a + b; }; // 已經確認泛型的類別為int，(int a, int b)可以再簡化為(a, b)
            var result2 = func2(200, 300);
            System.Console.WriteLine(result2);
        }

        // Action泛型委託
        static void Say(string str)
        {
            Console.WriteLine($"Hello, {str}!");
        }

        static void Mul(int x)
        {
            Console.WriteLine(x * 100);
        }

        // Function泛型委託
        static int Add(int a, int b)
        {
            return a + b;
        }

        static double Add(double a, double b)
        {
            return a + b;
        }
    }
}