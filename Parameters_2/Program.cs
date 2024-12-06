using System;
using System.Collections.Generic;

namespace ParametersExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 值類型的引用參數(ref)
            int y = 1;
            IWantSideEffect(ref y); // 方法體內部和外部的地址指向同一個，會得到更新後的值
            System.Console.WriteLine(y); 

            // 引用類型的引用參數(ref)
            Student outterStu = new Student() {Name = "Tim"};
            System.Console.WriteLine("HashCode={0}, Name={1}", outterStu.GetHashCode(), outterStu.Name);
            System.Console.WriteLine("----------------------");
            IWantSideEffect2(ref outterStu); // 方法體內部和外部的地址指向同一個，會得到更新後的值
            System.Console.WriteLine("HashCode={0}, Name={1}", outterStu.GetHashCode(), outterStu.Name);
        }
        // 值類型的引用參數(ref)
        static void IWantSideEffect(ref int x) // 引用參數不會創建變量的副本
        {
            x = x + 100; // 直接改變方法體外部參數的值
        }

        // 引用類型的引用參數(ref)
        static void IWantSideEffect2(ref Student stu)
        {
            stu = new Student() {Name = "Tom"};
            System.Console.WriteLine("HashCode={0}, Name={1}", stu.GetHashCode(), stu.Name);
        }
    }

    // 引用類型的引用參數(ref)
    class Student
    {
        public string Name { get; set;}
    }
}