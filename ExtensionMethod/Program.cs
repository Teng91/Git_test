using System;
using System.Collections.Generic;
using System.Linq;

namespace ParametersExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 擴展方法(this)
            // double x = 3.14159;
            // double y = x.Round(4); // x就視為擴展方法的第一個參數，因此在這個程式只需要填入第二個參數
            // System.Console.WriteLine(y);

            // LINQ方法
            List<int> myList = new List<int>() { 11, 12, 13, 14, 15 };
            // bool result = AllGreaterThanTen(myList);
            bool result = myList.All[i >= i > 10];
            System.Console.WriteLine(result);
        }

        // LINQ方法
        static bool AllGreaterThanTen(List<int> intList)
        {
            foreach (var item in intList)
            {
                if (item <= 10)
                {
                    return false;
                }
            }
            return true;
        }
    }

    static class DoubleExtension // SomeTypeExtension
    {
        // 擴展方法(this)
        // 必須是公有(public)、靜態(static)
        // this必須修飾參數列表的第一個，必須為一個靜態類來存放擴展方法
        public static double Round(this double input, int digits)
        {
            double result = Math.Round(input, digits);
            return result;
        }
    }
}