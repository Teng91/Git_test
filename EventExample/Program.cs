using System;
using System.Threading;

// 自定義事件
namespace EventExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer(); // 1.事件的擁有者
            Waiter waiter = new Waiter(); // 3.事件的響應者
            customer.Order += waiter.Action; // 2.事件 5.事件訂閱
            customer.Action();
            customer.PayTheBill();
        }
    }

    public class OrderEventArgs : EventArgs // 派生自EventArgs這個類別(內建) 4.事件處理器
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }

    // 1.委託專門用來聲明事件 2.表明委託用來約束事件處理器 3.創建出來的實例專門用於事件處理器
    public delegate void OrderEventHandler(Customer customer, OrderEventArgs e); // 不能放在class裡面，就變成不是委託類型的字段了

    public class Customer
    {
        private OrderEventHandler orderEventHandler; // 用來存儲事件處理器

        public event OrderEventHandler Order
        {
            add
            {
                this.orderEventHandler += value;
            }

            remove
            {
                this.orderEventHandler -= value;
            }
        }

        public double Bill { get; set; }
        public void PayTheBill()
        {
            System.Console.WriteLine("I will pay ${0}.", this.Bill);
        }

        public void WalkIn()
        {
            System.Console.WriteLine("Walk into the restaurant.");
        }

        public void SitDown()
        {
            System.Console.WriteLine("Sit down.");
        }

        public void Think()
        {
            for (int i = 0; i < 5; i++)
            {
                System.Console.WriteLine("Let me think...");
                Thread.Sleep(1000);
            }
        }

        // 觸發 Order 事件的程式碼要放在 Action() 中
        public void Action()
        {
            Console.ReadLine(); // 程式會等待使用者按enter才開始動作
            this.WalkIn();
            this.SitDown();
            this.Think();

            // 觸發事件，創建事件参數並傳遞
            if (this.orderEventHandler != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = "KongPao Chicken";
                e.Size = "large";
                this.orderEventHandler.Invoke(this, e); // 觸發事件
            }
        }
    }

    public class Waiter
    {
        public void Action(Customer customer, OrderEventArgs e)
        {
            System.Console.WriteLine("I will serve you the dish - {0}", e.DishName);
            double price = 10;

            switch (e.Size.ToLower())
            {
                case "small":
                    price = price * 0.5;
                    break;
                case "large":
                    price = price * 1.5;
                    break;
                default:
                    break;
            }

            customer.Bill += price;
        }
    }
}
