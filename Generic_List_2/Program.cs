using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace ListDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> intlist = new List<int> { 100, 200, 300, 400 }; // int is Value type
            List<Book> booklist = new List<Book>(); // Book is Reference type
            for (int i = 1; i < 10; i++)
            {
                booklist.Add(new Book { Id = i, Name = $"Book-{i}", Price = 10 * i });
            }

            System.Console.WriteLine($"{intlist.Count}/{intlist.Capacity}");
            System.Console.WriteLine($"{booklist.Count}/{booklist.Capacity}");
            System.Console.WriteLine("===================================");
            System.Console.WriteLine(booklist[0]);
            System.Console.WriteLine(booklist[booklist.Count - 1]);
            System.Console.WriteLine("===================================");
            //  intlist[0] = 1000; // 修改數值
            var seg = intlist.GetRange(1, 2);
            System.Console.WriteLine(string.Join(",", seg));

            // 利用操作符進行運算(增、刪、查、改)
            for (int i = 0; i < intlist.Count; i++)
            {
                if (intlist[i] % 100 == 0)
                {
                    intlist.RemoveAt(i); // 漏掉某些元素
                    i--; // 用來抵銷 i++
                }
            }
            System.Console.WriteLine(string.Join(",", intlist));
        
            var e = booklist.GetEnumerator();
            System.Console.WriteLine(e.Current); // null值 -> 打印出空行
            while (e.MoveNext())
            {
                System.Console.WriteLine(e.Current);
            }
            System.Console.WriteLine(e.Current); // null值 -> 打印出空行
        
            // foreach: 避免迭代器在開始和最後指向沒有元素的空位置
            foreach (var item in booklist)
            {
                System.Console.WriteLine(item); // 直接拿到第一個元素
                // 增、刪、改都不行 (foreach是唯讀) -> 解法: 轉成Array
            }

            // 用Lambda表達式遍歷並加總
            int sum = 0;
            intlist.ForEach(val => sum += val);
            System.Console.WriteLine(sum);
        }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}