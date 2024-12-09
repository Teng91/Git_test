using System;

namespace AbstractExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle v = new RaceCar();
            v.Run();
        }
    }

    abstract class Vehicle // 跟著修改為抽象類
    {
        public void Stop()
        {
            Console.WriteLine("Stopped!");
        }

        public void Fuel()
        {
            Console.WriteLine("Pay and fuel...");
        }

        // 違反開閉原則:除非修bug或是新增功能，否則不能隨意更改關閉的類別
        // public void Run(string type)
        // {
        //     if (type == "car")
        //     {
        //         Console.WriteLine("Car is running ...");
        //     }
        //     else if (type == "truck")
        //     {
        //         Console.WriteLine("Truck is running ...");
        //     }
        //     else if (type == "racecar")
        //     {
        //         Console.WriteLine("Race car is running ...");
        //     }
        // }

        // 該方法表示的內容本身也沒有意義，但移除掉會變成沒有方法的函式
        // private virtual void Run()
        // {
        //     Console.WriteLine("Vecihle is running ...");
        // }

        public abstract void Run(); // 方法沒有被實現 -> 修改為抽象類
    }
    
    class Car : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Car is running ...");
        }
    }

    class Truck : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Truck is running ...");
        }
    }

    class RaceCar : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Race car is running ...");
        }
    }
}