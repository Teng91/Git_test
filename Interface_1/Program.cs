using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace InterfaceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = new int[] { 1, 2, 3, 4, 5 };
            ArrayList nums2 = new ArrayList() { 1, 2, 3, 4, 5 };
            System.Console.WriteLine(Sum(nums1));
            System.Console.WriteLine(Avg(nums1));
            System.Console.WriteLine(Sum2(nums2));
            System.Console.WriteLine(Avg2(nums2));
        }

        static int Sum(int[] nums)
        {
            int sum = 0;
            foreach (var n in nums)
            {
                sum += n;        
            }
            return sum;
        }

        static double Avg(int[] nums)
        {
            int sum = 0;
            double count = 0;
            foreach (var n in nums)
            {
                sum += n;
                count ++;
            }
            return sum / count;
        }

        // 如果不用接口或契約，就需要新增兩個函數符合ArrayList
        static int Sum2(ArrayList nums)
        {
            int sum = 0;
            foreach (var n in nums)
            {
                sum += (int)n; // ArrayList要進行強制類型轉換        
            }
            return sum;
        }

        static double Avg2(ArrayList nums)
        {
            int sum = 0;
            double count = 0;
            foreach (var n in nums)
            {
                sum += (int)n; // ArrayList要進行強制類型轉換
                count ++;
            }
            return sum / count;
        }

        // 使用接口: 資料格式都能通用的方法(int[]和ArrayList都能用IEnumerable)
        static int Sum(IEnumerable nums)
        {
            int sum = 0;
            foreach (var n in nums)
            {
                sum += (int)n; // 同樣要進行強制類型轉換
            }
            return sum;
        }

        static double Avg(IEnumerable nums)
        {
            int sum = 0;
            double count = 0;
            foreach (var n in nums)
            {
                sum += (int)n; // 同樣要進行強制類型轉換
                count ++;
            }
            return sum / count;
        }
    }
}