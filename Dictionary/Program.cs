using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Student> stuDic = new Dictionary<string, Student>();
            for (int i = 1; i <= 100; i++)
            {
                Student stu = new Student();
                stu.Name = "s_" + i.ToString();
                stu.Score = 100;
                stuDic.Add(stu.Name, stu);
            }

            Student number6 = stuDic["s_6"];
            System.Console.WriteLine(number6.Score);
        }
    }

    class Student
    {
        public string Name;
        public int Score;
    }
}