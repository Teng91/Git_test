using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    // 錯誤:函數不能獨立於Class或是結構體之外
    // double Add(double a, double b)
    // {
    //     return a + b;
    // }
    // 
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Console.WriteLine("Hello World!");
    //     }
    // }

    public class Program
    {
        public static void Main(string[] args)
        {
            Calculator c = new Calculator();
            Console.WriteLine(c.GetCircleArea(10));
            Console.WriteLine(c.GetCylinderVolume(10, 3));
            Console.WriteLine(c.GetConeVolume(10, 3));
        }
    }

    class Calculator
    {
        // 沒有方法重用 -> 如果要修改需要依序將全部有使用到的都修改
        // public double GetCircleArea(double r)
        // {
        //     return 3.14 * r * r;
        // }

        // public double GetCylinderVolume(double r, double h)
        // {
        //     return 3.14 * r * r * h;
        // }

        // public double GetConeVolume(double r, double h)
        // {
        //     return 3.14 * r * r * h / 3;
        // }

        // 方法重用 -> 方便日後修改程式，找到源頭修改即可
        public double GetCircleArea(double r)
        {
            return Math.PI * r * r;
        }

        public double GetCylinderVolume(double r, double h)
        {
            return GetCircleArea(r) * h;
        }

        public double GetConeVolume(double r, double h)
        {
            return GetCylinderVolume(r, h) / 3;
        }
    }
}