using System;
using System.Collections;

namespace TasksLibrary
{
    public abstract class BinarySearchTree<T> : IteratorAggregate where T : IComparable
    {
        public Node<T> root { get; private set; }

        public BinarySearchTree(T rootValue)
        {
            root = new Node<T>(rootValue);
        }

        public void Add(T value)
        {
            Node<T> child = new Node<T>(value);
            Node<T> current = root;
            while (true)
            {
                var condition = current.Value.CompareTo(value);

                if (condition > 0)
                {
                    if  (current.Left == null)
                    {
                        current.Left = child;
                        child.Parent = current;
                        return;
                    }
                    else
                    {
                        current = current.Left;
                        continue;
                    }
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = child;
                        child.Parent = current;
                        return;
                    }
                    else
                    {
                        current = current.Right;
                        continue;
                    }
                }
            }
        }

        public abstract override IEnumerator GetEnumerator();
    }

    public class Node<T>
    {
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node<T> Parent { get; set; }
        public T Value { get; set; }

        public Node(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
