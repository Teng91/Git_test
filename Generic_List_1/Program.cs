// top-level statements -> List默認構造器
int[] array = new int[] { 100, 200, 300, 400 };
System.Console.WriteLine(array is IEnumerable<int>);

List<int> list = new List<int>(array);
// List<int> list = new List<int>(50); // 提前初始化 -> 內存空間不會變化 -> 提高性能
System.Console.WriteLine($"{list.Count}/{list.Capacity}");
System.Console.WriteLine(string.Join(", ", list));

// Add: 已有序列的尾部增加數字(等同其他語言的Append)
// list.Add(100);

// AddRange: 把兩個list接在一起(頭尾)
List<int> list2 = new List<int>() { 10, 20, 30, 40 };
list2.AddRange(list);
System.Console.WriteLine($"{list2.Count}/{list2.Capacity}");
System.Console.WriteLine(string.Join(", ", list2));

// Insert: 向後平移幾個空間，再插入元素
list2.Insert(0, 1000); // insert第一個
list2.Insert(list2.Count, 1001); // insert最後一個
System.Console.WriteLine($"{list2.Count}/{list2.Capacity}");
System.Console.WriteLine(string.Join(", ", list2));

// InsertRange: 把兩個list接在一起(任意位置)
list2.InsertRange(2, list);
System.Console.WriteLine($"{list2.Count}/{list2.Capacity}");
System.Console.WriteLine(string.Join(", ", list2));

// Clear: 清除內容，但不會清除底層數組I(list.Capacity)
list2.Clear();
System.Console.WriteLine($"{list2.Count}/{list2.Capacity}");
System.Console.WriteLine(string.Join(", ", list2));

// RemoveAt(0): 移除第一個
// RemoveAt(list.Count-1): 移除第最後一個
// RemoveRange(0, list.Count-1)
// RemoveAll(e => e == 400): 用Lambda表達式移除所有特定的數值