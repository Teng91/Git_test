using System;
using System.Collections;

// 有可以替換的地方，就會有接口的存在
// 接口是為了鬆耦合和解藕合而生(方便功能替換)
namespace InterfaceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 寬鬆的耦合: 只需更換要使用的function名稱
            var user = new PhoneUser(new NokiaPhone());
            user.UsePhone();
            var user2 = new PhoneUser(new EricssonPhone());
            user2.UsePhone();
        }
    }

    class PhoneUser
    {
        private IPhone _phone;
        public PhoneUser(IPhone phone) // 接收接口類型的構造器
        {
            _phone = phone;
        }

        public void UsePhone()
        {
            _phone.Dail();
            _phone.Pickup();
            _phone.Send();
            _phone.Receive();
        }
    }
    
    interface IPhone
    {
        void Dail();
        void Pickup();
        void Send();
        void Receive();
    }

    class NokiaPhone : IPhone
    {
        public void Dail()
        {
            Console.WriteLine("Nokia calling...");
        }
        public void Pickup()
        {
            Console.WriteLine("Hello! This is Joy.");
        }

        public void Send()
        {
            Console.WriteLine("Hello!");
        }

        public void Receive()
        {
            Console.WriteLine("Nokia message ring...");
        }
    }

    class EricssonPhone : IPhone
    {
       public void Dail()
        {
            Console.WriteLine("Ericsson calling...");
        }
        public void Pickup()
        {
            Console.WriteLine("Hi! This is Joy.");
        }

        public void Send()
        {
            Console.WriteLine("Good evening!");
        }

        public void Receive()
        {
            Console.WriteLine("Ericsson ring...");
        } 
    }
}