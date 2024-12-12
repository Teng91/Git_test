using System;

namespace HelloEnum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Person person = new Person();
            person.Level = Level.Employee;
            person.Name = "Joy";
            person.Skill = Skill.Drive | Skill.Cook | Skill.Program | Skill.Teach; // 按位取或，就能同時符合(不需要建立List去遍歷(太耗性能))
            System.Console.WriteLine(person.Skill); // 輸出15(1111)
            System.Console.WriteLine(person.Skill & Skill.Cook);
            
            Person boss = new Person();
            boss.Level = Level.Boss;

            System.Console.WriteLine(boss.Level>person.Level);
            System.Console.WriteLine((int)Level.Employee); // 要進行顯式類型轉換才能看到值
            System.Console.WriteLine((int)Level.Manager);
            System.Console.WriteLine((int)Level.Boss);
            System.Console.WriteLine((int)Level.BigBoss);
        }
    }

    enum Level // 後面都要加逗號(最後一個可加可不加)
    {
        Employee, // 也可以自己給數值(Employe=100)
        Manager,
        Boss,
        BigBoss,
    }

    enum Skill // Bit位用法
    {
        Drive = 1, // 0001
        Cook = 2, // 0010
        Program = 4, // 0100
        Teach = 8, // 1000
    }

    class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Level Level { get; set; } // 設定枚舉類型，只能從這幾個裡面選
        public Skill Skill { get; set; }
    }
}