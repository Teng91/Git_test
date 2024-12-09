using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloRider
{
    class Program
    {
        static void Main(string[] args)
        {
            var values = Enumerable.Range(0, 10).ToArray();
            var bst = GetTree(values, 0, values.Length - 1);
            InOrderDFS(bst);
            System.Console.WriteLine("============");
            PreOrderDFS(bst);
            System.Console.WriteLine("============");
            PostOrderDFS(bst);
            System.Console.WriteLine("============");
            BFS(bst);
        }

        static Node GetTree(int[] values, int lowerindex, int higherindex)
        {
            if (lowerindex > higherindex) return null;
            var middle = lowerindex + (higherindex - lowerindex) / 2; // 找中間的index
            var node = new Node(values[middle]);
            node.Left = GetTree(values, lowerindex, middle - 1);
            node.Right = GetTree(values, middle + 1, higherindex);
            return node;
        }

        // DFS中序遍歷(左->中->右)
        static void InOrderDFS(Node node)
        {
            if (node == null) return;
            InOrderDFS(node.Left);
            System.Console.WriteLine(node.Value);
            InOrderDFS(node.Right);
        }

        // 補充: 前序遍歷(中->左->右)
        static void PreOrderDFS(Node node)
        {
            if (node == null) return;
            System.Console.WriteLine(node.Value);
            PreOrderDFS(node.Left);
            PreOrderDFS(node.Right);
        }

        // 補充: 後序遍歷(左->右->中)
        static void PostOrderDFS(Node node)
        {
            if (node == null) return;
            PostOrderDFS(node.Left);
            PostOrderDFS(node.Right);
            System.Console.WriteLine(node.Value);
        }

        //BFS
        static void BFS(Node root)
        {
            var q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var node = q.Dequeue();
                System.Console.WriteLine(node.Value);
                if (node.Left != null) q.Enqueue(node.Left);
                if (node.Right != null) q.Enqueue(node.Right);
            }
        }
    }

    class Node
    {
        public int Value { get; set;}
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int value)
        {
            Value = value;
        }
    }
}