using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = Math.Pow(2, 10);
            System.Console.WriteLine("x = " + x);

            double y = Math.Sqrt(x);
            System.Console.WriteLine("y = " + y);

            Calculator c = new Calculator();
            int z = c.Add(2, 3);
            Console.WriteLine("z = " + z);

            Calculator d = new Calculator();
            string str = d.Today();
            Console.WriteLine(str);

            c.PrintSum(4, 6);
        }
    }

    class Calculator
    {
        public int Add(int a, int b)
        {
            int result = a + b;
            return result;
        }

        public string Today()
        {
            int day = DateTime.Now.Day;
            return day.ToString();
        }

        public void PrintSum(int a, int b)
        {
            int result = a + b;
            Console.WriteLine(result);
        }
    }
}
