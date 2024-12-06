using System;
using System.Collections.Generic;

namespace ParametersExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 值類型的輸出參數(out)
            // System.Console.WriteLine("請輸入第一個數:");
            // string arg1 = Console.ReadLine();
            // double x = 0;
            // bool b1 = double.TryParse(arg1, out x);
            // if (b1==false)
            // {
            //     System.Console.WriteLine("input error");
            //     return;
            // }

            // System.Console.WriteLine("請輸入第二個數:");
            // string arg2 = Console.ReadLine();
            // double y = 0;
            // bool b2 = double.TryParse(arg2, out y);
            // if (b2==false)
            // {
            //     System.Console.WriteLine("input error");
            //     return;
            // }

            // double z = x + y;
            // System.Console.WriteLine("{0}+{1}={2}", x, y, z);

            // 引用類型的輸出參數(out)
            Student stu = null;
            bool b = StudentFactory.Create("Tim", 34, out stu);
            if (b==true)
            {
                System.Console.WriteLine("Student {0}, age is {1}.", stu.Name, stu.Age);
            }
        }

        // 值類型的輸出參數(out)
        // class DoubleParser
        // {
        //     public static bool TryParse(string input, out double result)
        //     {
        //         try
        //         {
        //             result = double.Parse(input); // 輸出參數在方法體裡面必須要被賦值
        //             return true;
        //         }
        //         catch
        //         {
        //             result = 0; // 輸出參數在方法體裡面必須要被賦值
        //             return false;
        //         }
        //     }
        // }

        // 引用類型的輸出參數(out)
        class Student
        {
            public int Age { get; set; }
            public string Name { get; set; }
        }

        class StudentFactory
        {
            public static bool Create(string stuName, int stuAge, out Student result)
            {
                result = null;
                if (string.IsNullOrEmpty(stuName))
                {
                    return false;
                }

                if (stuAge < 20 || stuAge > 80)
                {
                    return false;
                }

                result = new Student() { Name = stuName, Age = stuAge};
                return true;
            }
        }
    }
}