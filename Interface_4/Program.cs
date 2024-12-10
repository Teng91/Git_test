using System;
using System.Collections;

namespace IspExample2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = { 1, 2, 3, 4, 5 };
            ArrayList nums2 = new ArrayList { 1, 2, 3, 4, 5 };
            System.Console.WriteLine(Sum(nums1));
            System.Console.WriteLine(Sum(nums2));
            var nums3 = new ReadOnlyCollection(nums1);
            System.Console.WriteLine(Sum(nums3));
        }

        // static int Sum(ICollection nums) // ICollection為系統內建的基底介面
        static int Sum(IEnumerable nums) // 傳進來的接口不應該有使用不到的功能
        {
            int sum = 0;
            foreach (var n in nums)
            {
                sum += (int)n; // ArrayList需要強制類型轉換
            }

            return sum;
        }

    class ReadOnlyCollection : IEnumerable
    {
        private int[] _array;

        public ReadOnlyCollection(int[] array)
        {
            _array = array;
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        public class Enumerator : IEnumerator
        {
            private ReadOnlyCollection _collection;
            private int _head;

            public Enumerator(ReadOnlyCollection collection)
            {
                _collection = collection;
                _head = -1;
            }

            public object Current
            {
                get
                {
                    object o = _collection._array[_head];
                    return o; // 這邊不能直接返回整數 -> 需裝箱
                }
            }

            public bool MoveNext()
            {
                if (++_head < _collection._array.Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                _head = -1;
            }
        }
    }

    }   
}