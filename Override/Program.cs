using System;
using System.Collections.Generic;
using System.Linq;

namespace OverrideExample
{
    class Program
    {
        // override:沒有增加方法，只是更新原有方法的使用邏輯
        static void Main(string[] args)
        {
            var car = new Car();
            car.Run();

            var vehicle = new Vehicle();
            vehicle.Run();

            Vehicle v = new RaceCar();
            v.Run();

            RaceCar rc = new RaceCar();
            rc.Run();
        }
    }

    class Vehicle
    {
        public virtual void Run()
        {
            System.Console.WriteLine("I'm running.");
        }
    }

    class Car : Vehicle
    {
        public override void Run()
        {
            System.Console.WriteLine("Car is running.");
        }
    }
    // 如果沒寫virtual和override視為子類對父類的隱藏

    class RaceCar : Car
    {
        public override void Run()
        {
            System.Console.WriteLine("Race car is running.");
        }
    }
}