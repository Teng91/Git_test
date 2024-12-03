using System;

namespace TryExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Calculator c = new Calculator();
            // int r = c.Add("abc", "200");
            // 為了接收丟過來的錯誤，要再寫一個try處理
            int r = 0;
            try
            {
                r = c.Add("abc", "200");
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
            
            Console.WriteLine(r);
        }
    }

    class Calculator
    {
        public int Add(string arg1, string arg2)
        {
            int a = 0;
            int b = 0;
            
            // 用作執行finally時的判斷
            bool hasError = false;

            // 變數放入try語句後，須注意底下還會不會再用到
            try
            {
                a = int.Parse(arg1);
                b = int.Parse(arg2);
            }
            // 1.通用類型的catch
            // catch 
            // {
            //     Console.WriteLine("error");
            // }
            // 2.特定類型的catch(自定義輸出)
            // catch (ArgumentNullException)
            // {
            //     Console.WriteLine("Your argument(s) are null.");
            // }
            // catch (FormatException)
            // {
            //     Console.WriteLine("Your argument(s) are not number.");
            // }
            // catch (OverflowException)
            // {
            //     Console.WriteLine("Your argument(s) are out of range.");
            // }
            // 3.特定類型的catch(利用變量預設輸出)
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
                hasError = true;
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                hasError = true;
            }
            catch (OverflowException oe)
            {
                // Console.WriteLine(oe.Message);
                // hasError = true;
                throw oe; // 不想在這邊處理oe錯誤，就丟回原本呼叫他的程式(Main)
            }
            // 不論前面多少條件，最後一定會執行
            finally
            {
                if (hasError)
                {
                    Console.WriteLine("Execution has error.");
                }
                else
                {
                    Console.WriteLine("Execution done.");
                }
            }
            int result = a + b;
            return result;
        }
    }
}