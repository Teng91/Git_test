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
            List<double> list1 = new List<double>() { 100.0, 200.0, 300.0, 400.0, 100.0, 200.0, 300.0, 400.0 };
            Book book1 = new Book() { Id = 1, Name = "Book-1", Price = 10 }, book6 = book1;
            Book book2 = new Book() { Id = 2, Name = "Book-2", Price = 20 };
            Book book3 = new Book() { Id = 3, Name = "Book-3", Price = 30 };
            Book book4 = new Book() { Id = 4, Name = "Book-4", Price = 40 };
            Book book5 = new Book() { Id = 1, Name = "Book-1", Price = 10 };
            List<Book> list2 = new List<Book>() { book1, book2, book3, book4 };
        
            // Contains(): 檢查是否包含(只比較數值本身，跟類型無關)
            bool res1 = list2.Contains(book5); // False 不是同一個對象(實例)，儘管屬性跟內容都相等也不成立
            bool res2 = list2.Contains(book6); // True  book1 和 book6 引用同一個對象
            // 要解決這個問題 -> 底下自定義重寫方法
            System.Console.WriteLine(res1);
            System.Console.WriteLine(res2);

            // Exists(): 檢查是否存在或是符合條件的元素
            // TrueForAll(): 檢查是否所有條件都符合或所有元素都存在
            bool res3 = list1.Exists(e => e >= 500);
            bool res4 = list2.TrueForAll(e => e.Price <= 40);
            System.Console.WriteLine(res3);
            System.Console.WriteLine(res4);

            // IndexOf(): 找元素所在的位置(只比較數值本身，跟類型無關)
            // LastIndexOf(): 從尾開始找 (x, y, z) x: list的數值, y: 起始位置(非必要), z: 找幾個(非必要)
            int res5 = list1.IndexOf(500); // 沒有就回傳-1
            System.Console.WriteLine(res5);

            // 找出list1所有300的位置
            int i = -1;
            while (true)
            {
                i = list1.IndexOf(300, i + 1);
                if (i == -1)
                {
                    break;
                }
                System.Console.WriteLine(i);
            }
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
    }
}