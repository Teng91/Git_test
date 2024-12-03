using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExample
{
    class Program
    {
        public static void Main(string[] args)
        {
            Calculator c = new Calculator();

            c.PrintXTo1(10);

            int result = c.SumFrom1ToX(100);
            Console.WriteLine(result);
        }
    }

    class Calculator
    {
        // public void PrintXTo1(int x) // 循環
        // {
        //     for (int i = x; i > 0; i--)
        //     {
        //         Console.WriteLine(i);
        //     }
        // }

        public void PrintXTo1(int x) // 遞迴
        {
            if (x == 1)
            {
                System.Console.WriteLine(x);
            }
            else
            {
                System.Console.WriteLine(x);
                PrintXTo1(x - 1);
            }
        }

        // public int SumFrom1ToX(int x) // 循環
        // {
        //     int result = 0;
        //     for (int i = 1; i < x+1; i++)
        //     {
        //         result = result + i;
        //     }
        //     return result;
        // }

        public int SumFrom1ToX(int x) // 遞迴
        {
            if (x == 1)
            {
                return 1;
            }
            else
            {
                int result = x + SumFrom1ToX(x - 1);
                return result;
            }
        }
    }
}