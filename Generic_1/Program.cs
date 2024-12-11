using System;

// 泛型無法直接在編程使用，要經過特化才能進行編程
namespace HelloGeneric
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Apple apple = new Apple(){Color = "Red"};
            Book book = new Book(){Name = "New Book"};
            // 問題: 類型膨脹
            AppleBox applebox = new AppleBox(){Cargo = apple};
            Bookbox bookbox = new Bookbox(){Cargo = book};
            // 問題: 成員膨脹(每次只有一個屬性是有用的)
            Box box1 = new Box() {Apple = apple}; // box1實例只用到Apple屬性(沒用到Book)
            Box box2 = new Box() {Book = book}; // box2實例只用到Book屬性(沒用到Apple)
            // 問題: object類型要取得屬性需要強制類型轉換
            Box box3 = new Box() {Cargo = apple};
            Box box4 = new Box() {Cargo = book};
            // 泛型實體不能直接編程，要先進行特化
            Box<Apple> box5 = new Box<Apple>(){Cargo = apple}; // 可以理解成用Apple取代Cargo
            Box<Book> box6 = new Box<Book>(){Cargo = book}; // 轉化後都是「強類型」
            System.Console.WriteLine(box5.Cargo.Color);
            System.Console.WriteLine(box6.Cargo.Name);
        }
    }

    class Apple
    {
        public string Color { get; set; }
    }

    class Book
    {
        public string Name { get; set;}
    }

    // 運行沒問題，但已經發生「類型(class)膨脹」
    class AppleBox
    {
        public Apple Cargo { get; set; }
    }

    class Bookbox
    {
        public Book Cargo { get; set; }
    }

    // 運行也沒問題，但仍然有「成員膨脹」問題
    class Box
    {
        public Apple Apple { get; set; }
        public Book Book { get; set; }
        // 依序往下新增...

        // object類型要取得屬性需要強制類型轉換(不是好方法)
        public object Cargo { get; set; } 
    }

    class Box<TCargo> // <>放入類型參數(泛化類型)
    {
        public TCargo Cargo { get; set; }
    }
}