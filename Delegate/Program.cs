using System;
using System.Collections.Generic;
using System.Linq;

// C#內建的委託(Action, Func)
// namespace DelegateExample
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Calculator calculator = new Calculator();
//             Action action = new Action(calculator.Report); // 只是需要方法名，不要加()，加()代表要調用方法
//             calculator.Report(); // 直接調用
//             action.Invoke(); // 間接調用(使用委託)
//             action(); // 間接調用(使用委託-簡略)

//             Func<int, int, int> func1 = new Func<int, int, int>(calculator.Add); // 泛型委託<>
//             Func<int, int, int> func2 = new Func<int, int, int>(calculator.Sub); // 泛型委託<>

//             int x = 100;
//             int y = 200;
//             int z = 0;

//             z = func1.Invoke(x, y); // 間接調用(使用委託)
//             z = func1(x, y); // 間接調用(使用委託-簡略)
//             Console.WriteLine(z);
//             z = func2.Invoke(x, y); // 間接調用(使用委託)
//             z = func2(x, y); // 間接調用(使用委託-簡略)
//             Console.WriteLine(z);
//         }
//     }

//     class Calculator
//     {
//         public void Report()
//         {
//             Console.WriteLine("I have 3 methods.");
//         }

//         public int Add(int a, int b)
//         {
//             int result = a + b;
//             return result;
//         }

//         public int Sub(int a, int b)
//         {
//             int result = a - b;
//             return result;
//         }
//     }
// }

// 自定義委託(delegate)
namespace DelegateExample
{
    public delegate double Calc(double x, double y); // 聲明委託(本身也是一種class)，double為目標方法的返回值類型
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Calc calc1 = new Calc(calculator.Add); // 只是需要方法名，不要加()，加()代表要調用方法
            Calc calc2 = new Calc(calculator.Sub); // 只是需要方法名，不要加()，加()代表要調用方法
            Calc calc3 = new Calc(calculator.Mul); // 只是需要方法名，不要加()，加()代表要調用方法
            Calc calc4 = new Calc(calculator.Div); // 只是需要方法名，不要加()，加()代表要調用方法

            double a = 100;
            double b = 200;
            double c = 0;
            
            c = calc1(a, b);
            System.Console.WriteLine(c);
            c = calc2(a, b);
            System.Console.WriteLine(c);
            c = calc3(a, b);
            System.Console.WriteLine(c);
            c = calc4(a, b);
            System.Console.WriteLine(c);
        }
    }

    class Calculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }

        public double Mul(double x, double y)
        {
            return x * y;
        }

        public double Div(double x, double y)
        {
            return x / y;
        }
    }
}