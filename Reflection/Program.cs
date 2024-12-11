using System;
using System.Reflection; // 反射的library(.net架構都有)
// 終端機輸入指令: dotnet add package Microsoft.Extensions.DependencyInjection
using Microsoft.Extensions.DependencyInjection; // 依賴注入的library

namespace IspExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 未封裝的反射(實務上比較少用)
            ITank tank = new HeavyTank();
            // ==========================
            var t = tank.GetType();
            object o = Activator.CreateInstance(t);
            MethodInfo fireMi = t.GetMethod("Fire");
            MethodInfo runMi = t.GetMethod("Run");
            fireMi.Invoke(o, null);
            runMi.Invoke(o, null);

            // 封裝好的反射 -> 依賴注入(結合接口跟反射)
            // 可以理解成這些東西都已經註冊在container裡面，創建實例的時候就不用再new一個新的
            var sc = new ServiceCollection();
            sc.AddScoped(typeof(ITank), typeof(HeavyTank)); // 只要修改HeavyTank就能更改調用不同類別
            sc.AddScoped(typeof(IVehicle), typeof(Car));
            sc.AddScoped<Driver>();
            var sp = sc.BuildServiceProvider();
            // ================================
            ITank tank= sp.GetService<ITank>(); // 優點: 減少new操作符的數量，避免一直修改數值
            tank.Fire();
            tank.Run();
            // ================================
            var driver = sp.GetService<Driver>();
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