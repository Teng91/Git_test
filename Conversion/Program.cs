using System;

namespace ConversionExample
{
	class Program
	{
		static void Main(string[] args)
		{
			// 顯式類型轉換
			string str1 = Console.ReadLine(); //使用者輸入1
			string str2 = Console.ReadLine(); //使用者輸入2
			int x = Convert.ToInt32(str1); //ReadLine預設是string，要轉換為int才能進行運算
			int y = Convert.ToInt32(str2);
			Console.WriteLine(x + y); //進行數字相加

			// 不丟失精度的隱式類型轉換(類似子集合概念)
			int x = int.MaxValue;
			long y = x;
			Console.WriteLine(y); // long涵蓋的範圍比int大，因此不會丟失精度

			// 子類向父類的隱式類型轉換(多型的概念)
			Teacher t = new Teacher(); // 使用t變量引用Teacher這個class的實例
			Human h = t; // h可以調用Think()和Eat()，但無法調用Teach() ，能使用自己本身和繼承來的函式
			Animal a = h; // 同理a只能調用Eat()，只有自己本身，沒有繼承

			// 自定義類型轉換字符
			Stone stone = new Stone();
			stone.Age = 5000
			Monkey Wukong = (Monkey)stone;
			Console.WriteLine(Wukong);
		}
	}
	
	// 子類向父類的隱式類型轉換(多型的概念)
	class Animal
	{
		public void Eat()
		{
			Console.WriteLine("Eating.");
		}
	}
	class Human : Animal
	{
		public void Think()
		{
			Console.WriteLine("Who am I?");
		}
	}
	class Teacher : Animal
	{
		public void Teach()
		{
			Console.WriteLine("I teach programming.")
		}
	}

	// 自定義類型轉換字符
	class Stone
	{
		public int Age;

		public static explicit operator Monkey(Stone stone)
		{
			Monkey m = new Monkey();
			m.Age = stone.Age / 500;
			return m;
		}
	}
	class Monkey
	{
		public int Age;
	}
}