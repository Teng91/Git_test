using System;

// 顯式接口實現(C#獨有功能)
namespace IspExample3
{
    class Program
    {
        static void Main(string[] args)
        {
            var wk = new WarmKiller();
            wk.Love(); // 顯式接口實現，此時看不到Kill()
            IKiller killer = wk; // 此時可以直接用先前的實例，或是再建立一個新的實例都可以
            // IKiller killer = new WarmKiller();
            killer.Kill(); //
        }
    }

    interface IGentleman
    {
        void Love();
    }

    interface IKiller
    {
        void Kill();
    }

    class WarmKiller : IGentleman, IKiller
    {
        // 程式運行上沒問題，但使用設計上不符合邏輯(有些接口並不想輕易讓人使用)
        // public void Kill()
        // {
        //     System.Console.WriteLine("Kill the enemy.");
        // }

        // 顯式接口實現
        void IKiller.Kill()
        {
            System.Console.WriteLine("Let me kill the enemy.");
        }

        public void Love()
        {
            System.Console.WriteLine("I will love you.");
        }
    }
}