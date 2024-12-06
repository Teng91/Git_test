using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

// 一般委託和多播委託
namespace MulticastDelegateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stu1 = new Student() { ID = 1, PenColor = ConsoleColor.Yellow };
            Student stu2 = new Student() { ID = 2, PenColor = ConsoleColor.Green };
            Student stu3 = new Student() { ID = 3, PenColor = ConsoleColor.Red };
            Action action1 = new Action(stu1.DoHomework);
            Action action2 = new Action(stu2.DoHomework);
            Action action3 = new Action(stu3.DoHomework);

            // 一般委託
            action1();
            action2();
            action3();
            // 多播委託(multicast) -> 多播委託同步調用
            action1 += action2;
            action1 += action3;
            action1(); // 優先執行action1，接著合併action2，最後合併action3
        }
    }

    class Student
    {
        public int ID { get; set;}
        public ConsoleColor PenColor { get; set;}

        public void DoHomework()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = this.PenColor;
                Console.WriteLine("Student {0} doing homework {1} hours.", this.ID, i);
                Thread.Sleep(1000);
            }
        }
    }
}

// 同步調用
namespace MulticastDelegateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stu1 = new Student() { ID = 1, PenColor = ConsoleColor.Yellow };
            Student stu2 = new Student() { ID = 2, PenColor = ConsoleColor.Green };
            Student stu3 = new Student() { ID = 3, PenColor = ConsoleColor.Red };
            
            // 1.直接同步調用(直接在主線程內進行三個方法的調用)
            stu1.DoHomework();
            stu2.DoHomework();
            stu3.DoHomework();

            // 2.單播委託間接同步調用
            Action action1 = new Action(stu1.DoHomework);
            Action action2 = new Action(stu2.DoHomework);
            Action action3 = new Action(stu3.DoHomework);

            action1.Invoke();
            action2.Invoke();
            action3.Invoke();

            // 3.多播委託間接同步調用
            Action action1 = new Action(stu1.DoHomework);
            Action action2 = new Action(stu2.DoHomework);
            Action action3 = new Action(stu3.DoHomework);

            action1 += action2;
            action1 += action3;
            action1(); // 優先執行action1，接著合併action2，最後合併action3

            // (高級)隱式異步調用(Task.Run()) -> 還是隱式但使用了API
            Task.Run(() => stu1.DoHomework());
            Task.Run(() => stu2.DoHomework());
            Task.Run(() => stu3.DoHomework());

            // 顯式異步調用(Thread)
            Thread thread1 = new Thread(new ThreadStart(stu1.DoHomework));
            Thread thread2 = new Thread(new ThreadStart(stu2.DoHomework));
            Thread thread3 = new Thread(new ThreadStart(stu3.DoHomework));
            
            thread1.Start();
            thread2.Start();
            thread3.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Main thread {0}.", i);
                Thread.Sleep(1000);
            }
        }
    }

    class Student
    {
        public int ID { get; set;}
        public ConsoleColor PenColor { get; set;}

        public void DoHomework()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = this.PenColor;
                Console.WriteLine("Student {0} doing homework {1} hours.", this.ID, i);
                Thread.Sleep(1000);
            }
        }
    }
}