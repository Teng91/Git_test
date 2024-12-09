using System;

namespace HelloAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("Joy");
            Console.WriteLine(car.Owner);
        }
    }

    class Vehicle // 基類(父類)Base
    {
        public Vehicle(string owner)
        {
            this.Owner = owner;
        }
        public string Owner { get; set; }
    }

    class Car : Vehicle // 派生類(子類)Derive
    {
        // 父類的實例構造器不會被子類繼承
        public Car(string owner): base(owner)
        {
            this.Owner = owner;
        }

        public void ShowOwner()
        {
            Console.WriteLine(Owner);
        }
    }
}