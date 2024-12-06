using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calculator
{
    // class Program
    // {
    //     static void Main(string[] args)
    //     {
    //         double x = Math.Pow(2, 10);
    //         System.Console.WriteLine("x = " + x);

    //         double y = Math.Sqrt(x);
    //         System.Console.WriteLine("y = " + y);

    //         Calculator c = new Calculator();
    //         int z = c.Add(2, 3);
    //         Console.WriteLine("z = " + z);

    //         Calculator d = new Calculator();
    //         string str = d.Today();
    //         Console.WriteLine(str);

    //         c.PrintSum(4, 6);
    //     }
    // }

    // class Calculator
    // {
    //     public int Add(int a, int b)
    //     {
    //         int result = a + b;
    //         return result;
    //     }

    //     public string Today()
    //     {
    //         int day = DateTime.Now.Day;
    //         return day.ToString();
    //     }

    //     public void PrintSum(int a, int b)
    //     {
    //         int result = a + b;
    //         Console.WriteLine(result);
    //     }
    // }

    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student(1, "Joy"); // 滿足自定義構造器的參數需求
            // Student student = new Student() { ID = 1, Name = "Joy"};
            student.Report(); // Report()不是靜態方法，不能直接透過類名來調用
            // 解法:如果真的要調用類名，需要聲明Report()為靜態方法(前面加上static修飾)
        
            Type t = typeof(Student);
            object o = Activator.CreateInstance(t, 1, "Joy"); // 用反射(object)創建實例
            Student stu = (Student)o; // 把丟失的類別找回來
            Console.WriteLine(stu.Name);

            dynamic stu2 = Activator.CreateInstance(t, 1, "Joy"); // 用動態方法創建實例
            Console.WriteLine(stu2.Name);
        }
    }

    

    class Student
    {
        public Student(int id, string name) // 自定義構造器(名字要跟class一模一樣)，看起來像是方法但沒有返回值
        {
            this.ID = id;
            this.Name = name;
        }

        ~Student() // 析構器
        {
            System.Console.WriteLine("Finish...");
        }

        public int ID { get; set; }
        public string Name { get; set; }

        public void Report()
        {
            System.Console.WriteLine($"I'm #{ID} student, my name is {Name}."); // 兩種寫法是一樣的
            // System.Console.WriteLine("I'm #{0} student, my name is {1}.", ID, Name);
        }
        
    }
}
