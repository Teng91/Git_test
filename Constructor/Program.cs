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
            // Student stu = new Student();
            Student stu = new Student(2, "Joy");
            System.Console.WriteLine(stu.ID);
            System.Console.WriteLine(stu.Name);
            System.Console.WriteLine("===================");
            Student stu2 = new Student();
            System.Console.WriteLine(stu2.ID);
            System.Console.WriteLine(stu2.Name);
        }
    }

    class Student
    {   
        // 自定義的Constructor(非系統默認的)
        public Student()
        {
            this.ID = 1;
            this.Name = "No name";
        }

        // 強迫Constructor有個初始值，因此Program在使用時就要先給定
        public Student(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
        public int ID;
        public string Name;
    }
}