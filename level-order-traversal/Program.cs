using System;
using System.Collections.Generic;

namespace LevelOrderTraversal {
    class Node {
        public Node (object data) {
            Data = data;
        }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public object Data { get; set; }
    }

    class Program {
        static void Main (string[] args) {
            Node tree = new Node ("a");
            tree.Right = new Node ("b");
            tree.Right.Left = new Node ("c");
            tree.Left = new Node ("d");
            LevelOrderTraverse (tree);
        }

        static void LevelOrderTraverse (Node tree) {
            Queue<Node> queue = new Queue<Node> ();
            queue.Enqueue (tree);
            int max = 0;
            while (queue.Count > 0) {
                if (max < queue.Count)
                    max = queue.Count;
                var currentNode = queue.Dequeue ();
                Console.WriteLine (currentNode.Data);
                if (currentNode.Left != null)
                    queue.Enqueue (currentNode.Left);
                if (currentNode.Right != null)
                    queue.Enqueue (currentNode.Right);
            }
            Console.WriteLine ("Width=" + max);
        }
    }
}