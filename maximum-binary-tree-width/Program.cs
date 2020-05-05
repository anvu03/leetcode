using System;

namespace maximum_binary_tree_width {
    class Node {
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    class Program {
        static int Min = int.MaxValue;
        static int Max = int.MinValue;
        static void Main (string[] args) {
            var tree = CreateTree ();
            Traverse (tree, 0);

            Console.WriteLine ($"Max width = {Max - Min}");
        }

        static void Traverse (Node tree, int pos) {
            if (pos < Min)
                Min = pos;
            if (pos > Max)
                Max = pos;
            if (tree.Left != null)
                Traverse (tree.Left, pos - 1);
            if (tree.Right != null)
                Traverse (tree.Right, pos + 1);
        }

        static Node CreateTree () {
            return new Node {
                Left = new Node (),
                    Right = new Node ()
            };
        }
    }
}