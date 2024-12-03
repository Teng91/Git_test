// Array 陣列

int[] scores = {50, 60, 70, 80, 90}; // 用大括號把值都寫進去
string[] phones = new string[10]; // 不確定裡面的值是甚麼的時候，先創建一個空的array，指定裡面可以放幾個值

phones[0] = "0123456789";
phones[1] = "088888888";

System.Console.WriteLine(phones);
System.Console.WriteLine(phones[0]);
System.Console.WriteLine(phones[1]);

// 基本計算機

System.Console.WriteLine("請輸入第一個數: ");
string num1 = System.Console.ReadLine();
System.Console.WriteLine("請輸入第二個數: ");
string num2 = System.Console.ReadLine();
System.Console.WriteLine(num1 + num2);
// 輸出結果是32 -> string的相加就是連在一起

System.Console.WriteLine("請輸入第一個數: ");
int num1 = System.Console.ReadLine();
System.Console.WriteLine("請輸入第二個數: ");
int num2 = System.Console.ReadLine();
System.Console.WriteLine(num1 + num2);
// 會報錯 -> Readline本身讀取的內容是字串，不能擅自改變資料型態為int

System.Console.WriteLine("請輸入第一個數: ");
int num1 = System.Convert.ToInt32(System.Console.ReadLine());
System.Console.WriteLine("請輸入第二個數: ");
int num2 = System.Convert.ToInt32(System.Console.ReadLine());
System.Console.WriteLine(num1 + num2);
// 用Convert將字串轉成數字(還考慮的不夠全面，應該直接改成double)