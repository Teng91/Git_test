using System;
using System.Collections.Generic;

namespace IndexExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stu = new Student();
            stu["Math"] = 90;
            var MathScore = stu["Math"];
            System.Console.WriteLine(MathScore);
        }
    }

    class Student
    {
        private Dictionary<string, int> scoreDictionary = new Dictionary<string, int>();

        public int? this[string subject] // int?代表可控類型，允許存取null
        {
            get
            {
                if (this.scoreDictionary.ContainsKey(subject))
                {
                    return this.scoreDictionary[subject];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value.HasValue==false)
                {
                    throw new Exception("Score cannot be null.");
                }
                if (this.scoreDictionary.ContainsKey(subject))
                {
                    this.scoreDictionary[subject] = value.Value; // 字典接收的成績一定是int，不能是null
                } // 可控類型value.Value才代表真正的數值
                else
                {
                    this.scoreDictionary.Add(subject, value.Value);
                }
            }
        }
    }
}