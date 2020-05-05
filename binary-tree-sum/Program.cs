using System;
using System.Collections.Generic;

namespace binary_tree_sum {
    class Node {
        public Node (int value) {
            Value = value;
        }
        public Node Parrent { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Value { get; set; }
    }

    class Program {
        static Dictionary<int, int> Hash = new Dictionary<int, int> ();
        static int Min = int.MaxValue;
        static int Max = int.MinValue;

        static void Main (string[] args) {
            var tree = CreateTree ();
            AddToHashSet (tree, 0);

            foreach (var kvp in Hash) {
                Console.WriteLine ($"{kvp.Key}={kvp.Value}");
            }

            int line = 0;

            Console.WriteLine ($"Sum of line {line} is {Hash[line + Min]}");
        }

        static void AddToHashSet (Node node, int grade) {
            if (!Hash.ContainsKey (grade))
                Hash.Add (grade, node.Value);
            else
                Hash[grade] += node.Value;
            if (grade < Min)
                Min = grade;
            if (grade > Max)
                Max = grade;
            if (node.Left != null)
                AddToHashSet (node.Left, grade + 1);
            if (node.Right != null)
                AddToHashSet (node.Right, grade - 1);
        }

        static Node CreateTree () {
            var parent = new Node (5);
            parent.Left = new Node (10);
            parent.Right = new Node (20);
            return parent;
        }
    }
}