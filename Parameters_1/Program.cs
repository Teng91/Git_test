using System;
using System.Collections.Generic;

namespace ParametersExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 值類型傳值參數
            Student stu = new Student();
            int y = 100;
            stu.AddOne(y);
            System.Console.WriteLine(y); // 對傳值參數的操作不會影響方法體外部變量的值
            
            // 引用類型傳值參數
            Student stu2 = new Student() {Name = "Tim"};
            SomeMethod(stu2);
            System.Console.WriteLine("{0}, {1}", stu2.GetHashCode(), stu2.Name); // 用GetHashCode()來檢查兩個參數是否不同
        }
        // 引用類型傳值參數
        static void SomeMethod(Student stu2)
        {
            stu2 = new Student() {Name = "Tim"};
            System.Console.WriteLine("{0}, {1}", stu2.GetHashCode(), stu2.Name); // 用GetHashCode()來檢查兩個參數是否不同
        }
    }

    class Student
    {
        // 值類型傳值參數
        public void AddOne(int x) // x是傳值參數
        {
            x = x + 1;
            System.Console.WriteLine(x); // 傳進來的值在方法體內部有個副本，實際上改變的是副本的值
        }

        // 引用類型傳值參數
        public string Name { get; set; }
    }
}