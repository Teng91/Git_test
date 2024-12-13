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
            List<double> list1 = new List<double>() { 100.0, 200.0, 300.0, 400.0 };
            Book book1 = new Book() { Id = 1, Name = "Book-1", Price = 10 }, book6 = book1;
            Book book2 = new Book() { Id = 2, Name = "Book-2", Price = 20 };
            Book book3 = new Book() { Id = 3, Name = "Book-3", Price = 30 };
            Book book4 = new Book() { Id = 4, Name = "Book-4", Price = 40 };
            Book book5 = new Book() { Id = 1, Name = "Book-1", Price = 10 };
            List<Book> list2 = new List<Book>() { book1, book2, book3, book4 };
            
            // Find(): 找元素並打印(從頭) FindLast(): 找元素並打印(從尾)
            var res1 = list2.FindLast(e => e.Price % 3 == 0);
            System.Console.WriteLine(res1);
            // FindAll(): 找到的所有元素放到新創建的list裡面
            var res2 = list1.FindAll(e => e % 3 == 0);
            System.Console.WriteLine(string.Join(",", res2));
            // FindIndex()跟IndexOf()的方法重載是相同的

            // binary search -> 要先sort
            list1.Sort();
            var res3 = list1.BinarySearch(300);
            System.Console.WriteLine(res3);

            // 不是.Net預設的類型 -> 自定義Compare To方法(還要實現IComparable泛型接口)
            list2.Sort();
            var res4 = list2.BinarySearch(book5); // 因為已經自定義Equal，所以找得到book5
            System.Console.WriteLine(res4);
        }
    }

    public class Book : IComparable<Book> // IComparable泛型接口
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        // 自定義重寫方法
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            Book other = obj as Book;
            if (other == null)
            {
                return false;
            }
            if (other.Id == this.Id && other.Name == this.Name && other.Price == this.Price)
            {
                return true;
            }
            return false;
        }

        public int CompareTo(Book? other) // ?表示接收的值有可能是null
        {
            if (other == null)
            {
                return 1;
            }
            return this.Id - other.Id;
        }
    }
}