using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator c = new Calculator();
            int x = c.Add(100, 100); // 會自動去搜尋是否有符合條件的方法並且執行
            System.Console.WriteLine(x);
        }
    }

    class Calculator
    {
        // 方法簽名: 相同方法給予不同的輸入類別和個數
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        public double Add(double x, double y)
        {
            return x + y;
        }
    }
}