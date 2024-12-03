using System;

namespace Example
{
    public class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            bool canContinue = true;
            while (canContinue)
            {
                System.Console.WriteLine("Please input first number:");
                string str1 = Console.ReadLine();
                if (str1.ToLower()=="end") // 不論大小寫都視為小寫
                {
                    break; // 強制結束，跳出迴圈
                }
                // int x = int.Parse(str1); // Parse可能會拋出錯誤，若沒有設計好會導致程式崩潰
                int x = 0;
                try
                {
                    x = int.Parse(str1);
                }
                catch
                {
                    Console.WriteLine("Error! Please restart.");
                    continue; // 如果輸入錯誤就跳過，重新執行程式
                }

                System.Console.WriteLine("Please input second number:");
                string str2 = Console.ReadLine();
                 if (str2.ToLower()=="end") // 不論大小寫都視為小寫
                {
                    break; // 強制結束，跳出迴圈
                }
                // int y = int.Parse(str2); // Parse可能會拋出錯誤，若沒有設計好會導致程式崩潰
                int y = 0;
                try
                {
                    y = int.Parse(str2);
                }
                catch
                {
                    Console.WriteLine("Error! Please restart.");
                    continue; // 如果輸入錯誤就跳過，重新執行程式
                }

                int sum = x + y;
                if (sum == 100)
                {
                    score++;
                    System.Console.WriteLine("Correct! {0}+{1}={2}", x, y, sum);
                }
                else
                {
                    System.Console.WriteLine("Wrong! {0}+{1}={2}", x, y, sum);
                    canContinue = false;
                }
            }
            System.Console.WriteLine("Your score is {0}", score);
            System.Console.WriteLine("GAME OVER!");
        }
    }
}
