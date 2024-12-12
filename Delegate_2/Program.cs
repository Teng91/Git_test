using System;
using System.Collections.Generic;
using System.Linq;

namespace Combine
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDele dele1 = new MyDele(M1); // dele1這個變量引用MyDele類型的實例，這個實例包裹著M1這個方法
            Student stu = new Student();
            dele1 += stu.SayHello; // 再加入一次方法 -> 多播委託
            // dele1 += (new Student()).SayHello; // 簡化寫法
            dele1.Invoke(); // 也可以簡化成dele1()
            // 使用委託的時候，大部分都是拿著委託類型的變量像函數一樣去調用
        }

        static void M1() // 符合MyDele委託(1.返回值為空 2.參數列表為空)
        {
            System.Console.WriteLine("M1 is called!");
        }

        class Student
        {
            public void SayHello()
            {
                System.Console.WriteLine("Hello! I'm a student.");
            }
        }
    }

    delegate void MyDele();
}