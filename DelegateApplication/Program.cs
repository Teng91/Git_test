using System;
using System.Collections.Generic;

// 1.模板方法
// namespace DelegateExample
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             ProductFactory productFactory = new ProductFactory();
//             WrapFactory wrapFactory = new WrapFactory();

//             Func<Product> func1 = new Func<Product>(productFactory.MakePizza);
//             Func<Product> func2 = new Func<Product>(productFactory.MakeToyCar);

//             Box box1 = wrapFactory.WrapProduct(func1);
//             Box box2 = wrapFactory.WrapProduct(func2);

//             System.Console.WriteLine(box1.product.Name);
//             System.Console.WriteLine(box2.product.Name);
//         }
//     }
    
//     class Product
//     {
//         public string Name { get; set; }
//     }

//     class Box
//     {
//         public Product product { get; set;}
//     }

//     class WrapFactory
//     {
//         public Box WrapProduct(Func<Product> getProduct)
//         {
//             Box box = new Box();
//             Product product = getProduct.Invoke();
//             box.product = product;
//             return box;
//         }
//     }
    
//     class ProductFactory
//     {
//         public Product MakePizza()
//         {
//             Product product = new Product();
//             product.Name = "Pizza";
//             return product;
//         }

//         public Product MakeToyCar()
//         {
//             Product product = new Product();
//             product.Name = "Toy Car";
//             return product;
//         }
//     }
// }

// 2.回調方法
namespace DelegateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductFactory productFactory = new ProductFactory();
            WrapFactory wrapFactory = new WrapFactory();

            Func<Product> func1 = new Func<Product>(productFactory.MakePizza);
            Func<Product> func2 = new Func<Product>(productFactory.MakeToyCar);

            Logger logger = new Logger();
            Action<Product> log = new Action<Product>(logger.log);

            Box box1 = wrapFactory.WrapProduct(func1, log);
            Box box2 = wrapFactory.WrapProduct(func2, log);

            System.Console.WriteLine(box1.product.Name);
            System.Console.WriteLine(box2.product.Name);
        }
    }
    
    class Logger // 紀錄程式的運行狀況
    {
        public void log(Product product)
        {
            System.Console.WriteLine("Product '{0}' created at {1}. Price is {2}.", product.Name, DateTime.UtcNow, product.Price);
        }
    }

    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Box
    {
        public Product product { get; set;}
    }

    class WrapFactory
    {
        public Box WrapProduct(Func<Product> getProduct, Action<Product> logCallback) // 沒有回傳值應該用Action委託
        {
            Box box = new Box();
            Product product = getProduct.Invoke();
            if (product.Price >= 50)
            {
                logCallback(product);
            }

            box.product = product;
            return box;
        }
    }
    
    class ProductFactory
    {
        public Product MakePizza()
        {
            Product product = new Product();
            product.Name = "Pizza";
            product.Price = 12;
            return product;
        }

        public Product MakeToyCar()
        {
            Product product = new Product();
            product.Name = "Toy Car";
            product.Price = 100;
            return product;
        }
    }
}