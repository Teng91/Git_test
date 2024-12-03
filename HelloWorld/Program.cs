using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // for (int i = 0; i < 3; i++)
            // {
            //     Console.WriteLine("Hello World!");
            // }

            // 九九乘法表
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= i; j++) // 不顯示重複的部分
                {
                    System.Console.WriteLine("{0}*{1}={2}", i, j, i*j);
                }
                System.Console.WriteLine();
            }

            // 打印三角形的星號
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    System.Console.WriteLine("*");
                }
                System.Console.WriteLine();
            }
        }
    }
}