using System;

namespace IspExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new Driver(new Car());
            driver.Drive();
        }
    }

    class Driver
    {
        private IVehicle _vehicle;
        public Driver(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public void Drive()
        {
            _vehicle.Run();
        }
    }

    interface IVehicle
    {
        void Run();
    }

    class Car : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Car is running...");
        }
    }

    class Truck : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Truck is running...");
        }
    }

    // 解法: 將一個接口拆成兩個(另一個是原本的IVehicle)
    interface IWeapon
    {
        void Fire();
    }

    interface ITank : IVehicle, IWeapon // 分離接口
    {
    }

    // interface ITank
    // {
    //     void Fire(); // 永遠有功能用不到 -> 違反接口隔離原則
    //     void Run();
    // }

    class LightTank : ITank
    {
        public void Fire()
        {
            System.Console.WriteLine("Boom!");
        }

        public void Run()
        {
            System.Console.WriteLine("Ka Ka Ka...");
        }
    }

    class MediumTank : ITank
    {
        public void Fire()
        {
            System.Console.WriteLine("Boom!!");
        }

        public void Run()
        {
            System.Console.WriteLine("Ka! Ka! Ka!...");
        }
    }

    class HeavyTank : ITank
    {
        public void Fire()
        {
            System.Console.WriteLine("Boom!!!");
        }

        public void Run()
        {
            System.Console.WriteLine("Ka!! Ka!! Ka!!...");
        }
    }
}