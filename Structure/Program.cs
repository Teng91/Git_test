using System;

namespace HelloStruct
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Student stu1 = new Student(){ID = 101, Name = "Joy"};
            Student stu2 = stu1; // 複製(copy)，兩個實例可以獨立變化
            stu2.ID = 1001;
            stu2.Name = "John";
            System.Console.WriteLine($"#{stu1.ID} Name:{stu1.Name}");
            System.Console.WriteLine($"#{stu2.ID} Name:{stu2.Name}");
            stu1.Speak();
            Student student = new Student(1, "Jack");
            student.Speak();
        }
    }

    interface ISpeak // 結構體也可以實現接口
    {
        void Speak();
    }

    struct Student : ISpeak // 結構體類型是值類型
    {
        public Student(int id, string name) // 不允許顯式無參構造器(有參數就可以)
        {
            this.ID = id;
            this.Name = name;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public void Speak()
        {
            System.Console.WriteLine($"I'm #{this.ID} student {this.Name}");
        }
    }
}