int Answer = 88;
int input = 0; // 給定初始值作為while迴圈的起始判斷條件
int count = 0; // 設定猜測次數，初始值為0
int limit = 3;
bool win = false; // 判斷是否猜對

while (input != Answer && count < limit)
{
    System.Console.Write("請輸入猜測的數字: ");
    int guess = Convert.ToInt32(System.Console.ReadLine());
    count += 1;
    if (guess > Answer)
    {
        System.Console.WriteLine("猜小一點");
    }
    else if (guess < Answer)
    {
        System.Console.WriteLine("猜大一點");
    }
    else
    {
        System.Console.WriteLine("猜對了!遊戲結束");
        win = true;
    }
}
if (!win)
{
    System.Console.WriteLine("抱歉你輸了");
}