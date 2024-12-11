using System;

// 泛型的正交性很好，泛型與接口的正交叫做「泛型接口」
namespace HelloGeneric
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 1. 尚未確定類型 -> 自訂
            Student<int> stu = new Student<int>();
            stu.ID = 101;
            stu.Name = "Joy";
            Student<ulong> stu2 = new Student<ulong>();
            stu2.ID = 1000000000000001;
            stu2.Name = "Joy";
            // 2. 已經確定類型 -> 直接調用
            Student2 student2 = new Student2();
            student2.ID = 1000000000000001;
            student2.Name = "Joy";
        }
    }

    interface IUnique<TId> // 接口尚未確定類型 -> 泛型接口(常以T表示，更詳細可以在後面加上敘述)
    {
        TId ID { get; set; } // 接口不用加public(預設就是public)
    }

    class Student<TId> : IUnique<TId> // 重點: class要實現泛型接口，本身也要是泛型的
    {
        public TId ID { get; set; }
        public string Name { get; set; }
    }

    class Student2 : IUnique<ulong> // 已經確定類型可以直接宣告，此時class就不用是泛型
    {
        public ulong ID { get; set; }
        public string Name { get; set; }
    }
}